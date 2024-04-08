using mage.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Security.AccessControl;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace mage
{
    public partial class FormText : Form, Editor
    {
        // fields
        private struct TextList
        {
            public string type;
            public int offset;
            public int count;
        }
        private List<TextList> textLists;

        private List<ushort> textVals;
        private int prevLen;
        private Bitmap textImg;
        private Palette palette;
        private string display;

        private Dictionary<ushort, string> chars;
        private Dictionary<string, ushort> codes;

        private FormMain main;
        private ByteStream romStream;
        private Status status;
        private bool loading;

        // custom related
        private string charFilePath;
        private byte charWidth;

        // constructor
        public FormText(FormMain main)
        {
            InitializeComponent();

            //set numericUpDown_charWidth.Hexadecimal according to value of Hex.ToHex (ture -> hex, false -> decimal）
            numericUpDown_charWidth.Hexadecimal = Hex.ToHex;

            this.main = main;
            this.romStream = ROM.Stream;

            Initialize();
        }

        public void UpdateEditor()
        {
            palette = new Palette(romStream, Version.TextPaletteOffset, 1);
            pictureBox_palette.Image = palette.Draw(15, 0, 1);
            DrawText();
        }

        private void Initialize()
        {
            status = new Status(statusLabel_changes, button_apply);

            // initialize dictionaries
            chars = new Dictionary<ushort, string>();
            codes = new Dictionary<string, ushort>();

            //string[] charList = Version.CharacterList;
            //foreach (string s in charList)
            //{
            //    string[] items = s.Split('\t');
            //    ushort val = Convert.ToUInt16(items[0], 16);

            //    chars.Add(val, items[1]);
            //    if (!codes.ContainsKey(items[1]))
            //    {
            //        codes.Add(items[1], val);
            //    }
            //}

            if(string.IsNullOrEmpty(Version.CharFilePath) || !CheckCustomFile(Version.CharFilePath))
            {//use default char table
                SetCharTable(Version.CharacterList);
            }
            else
            {
                //use custom, initialize custom groupbox part
                checkBox_customChar.Checked = true;
                charWidth = Version.CharWidth;
                //check charWidth
                if (charWidth < 0 || charWidth > numericUpDown_charWidth.Maximum || charWidth < numericUpDown_charWidth.Minimum)
                {
                    MessageBox.Show(Resources.formText_ChaWidthNotValid,
                                Resources.formText_CustomFileErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else numericUpDown_charWidth.Value = charWidth;
                textBox_file.Text = charFilePath = Version.CharFilePath;

                //use custom char table
                SetCharTable(System.IO.File.ReadAllLines(charFilePath));
            }

            // initialize text options
            string gameCode = Version.GameCode;
            string[] lines = Properties.Resources.textLists.Split(
                new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            int index = 0;
            while (!lines[index].Contains(gameCode))
            {
                index++;
            }
            index++;

            textLists = new List<TextList>();
            while (index < lines.Length)
            {
                MatchCollection mc = Regex.Matches(lines[index++], @"[^,]+");
                if (mc.Count != 3) { break; }

                TextList tl;
                tl.offset = Convert.ToInt32(mc[0].Value, 16);
                tl.count = Convert.ToInt32(mc[1].Value, 16);
                tl.type = mc[2].Value;
                textLists.Add(tl);
            }

            // fill combo boxes
            foreach (TextList tl in textLists)
            {
                comboBox_text.Items.Add(tl.type);
            }
            comboBox_language.Items.AddRange(Version.Languages);

            // get palette and draw
            palette = new Palette(romStream, Version.TextPaletteOffset, 1);
            pictureBox_palette.Image = palette.Draw(15, 0, 1);
            
            comboBox_language.SelectedIndex = 2;
            comboBox_text.SelectedIndex = 0;
        }

        private void SetCharTable(string[] charList)
        {
            chars.Clear();
            codes.Clear();
            foreach (string s in charList)
            {
                string[] items = s.Split('\t');
                ushort val = Convert.ToUInt16(items[0], 16);

                chars.Add(val, items[1]);
                if (!codes.ContainsKey(items[1]))
                {
                    codes.Add(items[1], val);
                }
            }
        }

        private void GetText()
        {
            // get offset
            int type = comboBox_text.SelectedIndex;
            int language = comboBox_language.SelectedIndex;
            int number = comboBox_number.SelectedIndex;

            int offset = romStream.ReadPtr(textLists[type].offset + language * 4);
            offset = romStream.ReadPtr(offset + number * 4);
            textBox_offsetVal.Text = Hex.ToString(offset);

            // get text
            textVals = new List<ushort>();
            while (true)
            {
                ushort val = romStream.Read16(offset);
                textVals.Add(val);
                if (val == 0xFF00) { break; }
                offset += 2;
            }
            prevLen = textVals.Count;

            DrawText();
            DisplayText();
            status.LoadNew();
        }

        private void DisplayText()
        {
            display = "";
            foreach (ushort val in textVals)
            {
                if (chars.ContainsKey(val))
                {
                    display += chars[val];
                }
                else
                {
                    int ctrl = val >> 8;
                    if (ctrl == 0x80) { display += "[INDENT=" + Hex.ToString((byte)val) + "]"; }
                    else if (ctrl == 0x81) { display += "[COLOR=" + Hex.ToString((byte)val % 0xF) + "]"; }
                    else if (val >> 12 == 9) { display += "[MUSIC=" + Hex.ToString(val & 0xFFF) + "]"; }
                    else if (ctrl == 0xE1) { display += "[DELAY=" + Hex.ToString((byte)val) + "]"; }
                    else if (ctrl == 0xFD) { display += "[NEXT]\r\n"; }
                    else if (ctrl == 0xFE)
                    {
                        if (checkBox_newLine.Checked) { display += "[NEWLINE]"; }
                        else { display += "\r\n"; }
                    }
                    else if (val >> 8 == 0xFF) { break; }
                    else { display += @"[\x" + Hex.ToString(val) + "]"; }
                }
            }

            // set text
            loading = true;
            textBox.Text = display;
            loading = false;
        }

        private unsafe void DrawText()
        {
            // get number of rows of text
            int rows = 1;
            foreach (ushort val in textVals)
            {
                if (val == 0xFB00 || val == 0xFD00 || val == 0xFE00) { rows++; }
            }

            // draw text
            textImg = new Bitmap(240, rows * 16, PixelFormat.Format8bppIndexed);
            palette.SetBitmapPalette(textImg, 0, 1);
            BitmapData imgData = textImg.LockBits(new Rectangle(0, 0, 240, rows * 16), ImageLockMode.WriteOnly, textImg.PixelFormat);

            int gfxOffset = Version.TextGfxOffset;
            int charWidthsOffset = Version.CharacterWidthsOffset;
            Point pos = new Point(8, 0);

            byte color, change;
            if (Version.IsMF) { color = change = 2; }
            else { color = change = 4; }

            byte* startPtr = (byte*)imgData.Scan0;
            byte* imgPtr;

            foreach (ushort val in textVals)
            {
                if (val < 0x8000)
                {
                    imgPtr = startPtr + pos.Y * 240 + pos.X;

                    int cw;
                    if (val < 0x4A0)
                    {
                        cw = romStream.Read8(charWidthsOffset + val);
                    }
                    else
                    {
                        //cw = 10;
                        //if use custom char table is checked, use custom char width
                        cw = checkBox_customChar.Checked ? (int)numericUpDown_charWidth.Value : 10;
                    }

                    int w = (int)Math.Ceiling(cw / 8.0);
                    if (pos.X > 240 - w * 8) { continue; }
                    pos.X += cw;

                    for (int y = 0; y < 2; y++)  // for each tile down
                    {
                        int tOffset = gfxOffset + val * 0x20 + y * 0x400;

                        for (int x = 0; x < w; x++)  // for each tile across
                        {
                            for (int r = 0; r < 8; r++)  // for each row in tile
                            {
                                for (int pp = 0; pp < 4; pp++)  // for each pixel pair
                                {
                                    byte c = romStream.Read8(tOffset++);

                                    if ((c & 0xF) == change) { *imgPtr++ = color; }
                                    else { *imgPtr++ = (byte)(c & 0xF); }

                                    if ((c >> 4) == change) { *imgPtr++ = color; }
                                    else { *imgPtr++ = (byte)(c >> 4); }
                                }
                                imgPtr += 232;  // 240 - 8
                            }
                            imgPtr -= 1912;  // 240 * 8 - 8
                        }
                        imgPtr += (1920 - w * 8);  // 240 * 8 - w * 8
                    }
                }
                else if (val >> 8 == 0x80)
                {
                    pos.X += val & 0xFF;
                }
                else if (val >> 8 == 0x81)
                {
                    if (Version.IsMF) { color = (byte)((change + (val & 0xFF) * 2) % 0xF); }
                    else { color = (byte)Math.Max(4, (val & 0xFF) % 0xF); }
                }
                else if (val == 0xFB00 || val == 0xFD00 || val == 0xFE00)
                {
                    pos.X = 8;
                    pos.Y += 16;
                }
            }

            textImg.UnlockBits(imgData);

            pictureBox_text.BackColor = palette.GetOpaqueColor(0, 0);
            pictureBox_text.Image = textImg;
            pictureBox_text.Size = textImg.Size;
        }

        private bool ParseText()
        {
            textVals = new List<ushort>();
            string text = textBox.Text;
            int i = 0;

            try
            {
                for (; i < text.Length; i++)
                {
                    // bracketed expression
                    if (text[i] == '[')
                    {
                        string str = "[";
                        do
                        {
                            str += text[++i];
                        } while (text[i] != ']');

                        if (str[1] == '\\')  // raw char data
                        {
                            string tmp = str.Substring(3, str.Length - 4);
                            textVals.Add(Hex.ToUshort(tmp));
                        }
                        else if (codes.ContainsKey(str))  // special label
                        {
                            textVals.Add(codes[str]);
                        }
                        else if (str == "[NEWLINE]") { textVals.Add(0xFE00); }
                        else if (str == "[NEXT]")
                        {
                            textVals.Add(0xFD00);
                            // check for optional newline after [NEXT]
                            if (i + 2 < text.Length && text[i + 1] == '\r' && text[i + 2] == '\n') { i += 2; }
                        }
                        else  // label with value
                        {
                            string[] strs = str.Substring(1, str.Length - 2).Split('=');
                            if (strs[0] == "COLOR") { textVals.Add((ushort)(0x8100 + Hex.ToByte(strs[1]))); }
                            else if (strs[0] == "INDENT") { textVals.Add((ushort)(0x8000 + Hex.ToByte(strs[1]))); }
                            else if (strs[0] == "MUSIC") { textVals.Add((ushort)(0x9000 + Hex.ToUshort(strs[1]))); }
                            else if (strs[0] == "DELAY") { textVals.Add((ushort)(0xE100 + Hex.ToUshort(strs[1]))); }
                            else
                            {
                                //MessageBox.Show("Text could not be parsed.\r\nThe contents of the brackets at character " 
                                //    + Hex.ToString(i) + " are not valid.", "Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                MessageBox.Show(string.Format(Properties.Resources.formText_BracketNotValid, Hex.ToString(i)),
                                    Properties.Resources.formText_ParsingErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                        }
                    }
                    // new line
                    else if (text[i] == '\r')
                    {
                        if (text[++i] == '\n') { textVals.Add(0xFE00); }
                        else
                        {
                            //MessageBox.Show("Text could not be parsed.\r\nInvalid newline at character " 
                            //    + Hex.ToString(i) + ".", "Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            MessageBox.Show(string.Format(Properties.Resources.formText_InvalidNewLine, Hex.ToString(i)),
                                Properties.Resources.formText_ParsingErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    // escaped character
                    else if (text[i] == '\\') { textVals.Add(codes[text[++i].ToString()]); }
                    // normal character
                    else { textVals.Add(codes[text[i].ToString()]); }
                }

                textVals.Add(0xFF00);
            }
            catch (IndexOutOfRangeException)
            {
                //MessageBox.Show("Text could not be parsed.\r\nMake sure brackets are closed.", 
                //    "Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(Properties.Resources.formText_BracketNotClose,
                    Properties.Resources.formText_ParsingErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (KeyNotFoundException)
            {
                //MessageBox.Show("Text could not be parsed.\r\nCharacter " 
                //    + Hex.ToString(i) + " was not recognized.", "Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(string.Format(Properties.Resources.formText_CharNotRecognize, Hex.ToString(i)),
                    Properties.Resources.formText_ParsingErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (FormatException)
            {
                //MessageBox.Show("Text could not be parsed.\r\nThe value starting at character " 
                //    + Hex.ToString(i) + " is not valid.", "Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(string.Format(Properties.Resources.formText_CharNotValid, Hex.ToString(i)),
                    Properties.Resources.formText_ParsingErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void comboBox_text_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = textLists[comboBox_text.SelectedIndex].count;

            comboBox_number.Items.Clear();
            for (int i = 0; i < count; i++)
            {
                comboBox_number.Items.Add(Hex.ToString(i));
            }

            comboBox_number.SelectedIndex = 0;
        }

        private void comboBox_language_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_text.SelectedIndex == -1) { return; }
            GetText();
        }

        private void comboBox_number_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetText();
        }

        private void checkBox_wordWrap_CheckedChanged(object sender, EventArgs e)
        {
            textBox.WordWrap = checkBox_wordWrap.Checked;
        }

        private void checkBox_newLine_CheckedChanged(object sender, EventArgs e)
        {
            if (ParseText()) { DisplayText(); }
        }

        private void button_editPalette_Click(object sender, EventArgs e)
        {
            FormPalette form = new FormPalette(main, Version.TextPaletteOffset, 1);
            form.Show();
        }

        private void button_editGfx_Click(object sender, EventArgs e)
        {
            FormGraphics form = new FormGraphics(main, Version.TextGfxOffset, 32, 32, Version.TextPaletteOffset);
            form.Show();
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            if (ParseText()) { DrawText(); }
        }

        private void textBox_MouseClick(object sender, MouseEventArgs e)
        {
            label_pos.Text = Hex.ToString(textBox.SelectionStart);
        }

        private void textBox_KeyUp(object sender, KeyEventArgs e)
        {
            label_pos.Text = Hex.ToString(textBox.SelectionStart);
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (loading) { return; }
            label_pos.Text = Hex.ToString(textBox.SelectionStart);
            status.ChangeMade();
        }

        private void button_apply_Click(object sender, EventArgs e)
        {
            if (!ParseText()) { return; }

            // get data
            ByteStream dataToWrite = new ByteStream();

            foreach (ushort val in textVals)
            {
                dataToWrite.Write16(val);
            }

            // get pointer
            int type = comboBox_text.SelectedIndex;
            int language = comboBox_language.SelectedIndex;
            int number = comboBox_number.SelectedIndex;
            int pointer = romStream.ReadPtr(textLists[type].offset + language * 4) + number * 4;
            
            // write new data
            romStream.Write(dataToWrite, prevLen * 2, pointer, false);

            // set new length
            prevLen = textVals.Count;

            DrawText();
            status.Save();

            //process custom
            CustomInfo();
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkBox_customChar_CheckedChanged(object sender, EventArgs e)
        {
            enableCustom(checkBox_customChar.Checked);
        }

        private void enableCustom(bool val)
        {
            numericUpDown_charWidth.Enabled = val;
            button_selectFile.Enabled = val;
            textBox_file.Enabled = val;
        }

        private void button_selectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = Resources.formText_TxtFilterText;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                if (CheckCustomFile(openFile.FileName))
                {
                    //display custom file name
                    textBox_file.Text = openFile.FileName;
                    SetCharTable(System.IO.File.ReadAllLines(openFile.FileName));
                    status.ChangeMade();
                }
            }
        }

        private bool CheckCustomFile(string filename)
        {
            try
            {
                //get file contents
                string[] fileContentsList = System.IO.File.ReadAllLines(filename);
                string fileContents = System.IO.File.ReadAllText(filename);

                //check file
                bool isValid = true;
                string[] shareCtrlChar = { "[DEL]", "[L_box_left]", "[L_box_right]", "[R_box_left]", "[R_box_right]", "[X_1]", "[X_2]", "[X_3]", "[X_4]",
                        "[X_5]", "[X_6]", "[box_top_left]", "[box_top_middle]", "[box_top_right]", "[Up_button_left]", "[Up_button_right]", "[Down_button_left]",
                        "[Down_button_right]", "[Left_button_left]", "[Left_button_right]", "[Right_button_left]", "[Right_button_right]", "[A_button_left]",
                        "[A_button_right]", "[B_button_left]", "[B_button_right]", "[L_button_left]", "[L_button_right]", "[R_button_left]", "[R_button_right]",
                        "[sup_er]", "[sup_re]", "[sup_e]", "[box_bottom_left]", "[box_bottom_middle]", "[box_bottom_right]", "[SHY]", "[DEL]", "[/COLOR]", "[YES]",
                        "[NO]" };
                string[] mfCtrlChar = { "[SAMUS_FACE]", "[SA-X_FACE]", "[TARGET]", "[ADAM]", "[SAMUS]", "[FEDERATION]", "[POPUP_OPEN]", "[POPUP_CLOSE]",
                        "[OBJECTIVE]", "[ARROW]" };
                string[] zmCtrlChar = { "[Select_button_1]", "[Select_button_2]", "[Select_button_3]", "[Select_button_4]" };


                //check the format of each line
                for (int i = 0; i < fileContentsList.Length && isValid; i++)
                {
                    if (!fileContentsList[i].Contains("\t"))
                    {
                        isValid = false;
                        MessageBox.Show(Resources.formText_FileNotVaild,
                            Resources.formText_CustomFileErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return isValid;
                    }
                }

                //check control characters
                foreach (string ctrl in shareCtrlChar)
                {
                    if (!fileContents.Contains(ctrl))
                    {
                        isValid = false;
                        MessageBox.Show(string.Format(Resources.formText_MissShareCtrlChar, ctrl),
                            Resources.formText_CustomFileErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return isValid;
                    }
                }
                if (Version.IsMF)
                {
                    foreach (string ctrl in mfCtrlChar)
                    {
                        if (!fileContents.Contains(ctrl))
                        {
                            isValid = false;
                            MessageBox.Show(string.Format(Resources.formText_MissMFCtrlChar, ctrl),
                                Resources.formText_CustomFileErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return isValid;
                        }
                    }
                }
                else
                {
                    foreach (string ctrl in zmCtrlChar)
                    {
                        if (!fileContents.Contains(ctrl))
                        {
                            isValid = false;
                            MessageBox.Show(string.Format(Resources.formText_MissZMCtrlChar, ctrl),
                                Resources.formText_CustomFileErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return isValid;
                        }
                    }
                }

                if (isValid)
                {
                    foreach (string line in fileContentsList)
                    {
                        //pair[0] -> code, pair[1] -> char
                        string[] pair = line.Split('\t');
                        //check code part: is hex string convert to ushort, else FormatException
                        ushort code = ushort.Parse(pair[0], NumberStyles.HexNumber, CultureInfo.CurrentCulture);
                        if (!string.IsNullOrEmpty(pair[1]))
                        {
                            //check char
                            if (pair[1].Length > 1 && (pair[1][0] != '[' || pair[1][pair[1].Length - 1] != ']'))
                            {
                                isValid = false;
                                MessageBox.Show(string.Format(Resources.formText_CustomCharNotVaild, pair[1]),
                                    Resources.formText_CustomFileErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return isValid;
                            }
                            
                        }
                        else
                        {
                            isValid = false;
                            MessageBox.Show(string.Format(Resources.formText_CharIsNullOrEmpty, pair[0]),
                                Resources.formText_CustomFileErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return isValid;
                        }
                    }
                }

                return isValid;

            }
            catch (FormatException)
            {
                //MessageBox.Show("Text could not be parsed.\r\nThe value starting at character " 
                //    + Hex.ToString(i) + " is not valid.", "Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(Resources.formText_CodeNotValid,
                    Resources.formText_CustomFileErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show(Resources.formText_CustomFileNotFound,
                    Resources.formText_CustomFileErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show(Resources.formText_CustomFileNotFound,
                    Resources.formText_CustomFileErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private void CustomInfo()
        {
            if(checkBox_customChar.Checked)
            {
                charFilePath = this.textBox_file.Text;
                charWidth = (byte)this.numericUpDown_charWidth.Value;
            }
            else
            {
                charFilePath = null;
                Version.CharFilePath = null;
            }


            if (!string.IsNullOrEmpty(charFilePath))
            {   //write custom info to project
                Version.CharFilePath = charFilePath;
                //Version.CharWidth = Convert.ToString(charWidth,16).ToUpper();
                Version.CharWidth = charWidth;
            }
        }

        private void numericUpDown_charWidth_ValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(charFilePath))
            {
                status.ChangeMade();
            }
        }
    }
}
