using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace mage
{
    public partial class FormCredits : Form
    {
        // fields
        private byte[] gfxData;
        private Palette palette;
        private ushort[] tileTable;
        private int ttbIndex;

        // for update credits
        private int dataIndex = 0;
        private byte[] newData;
        private ushort[] newTable;

        private Bitmap image;
        private ByteStream romStream;

        public FormCredits()
        {
            InitializeComponent();

            this.romStream = ROM.Stream;
            Initialize();
        }

        private void Initialize()
        {
            // get palette
            palette = Version.IsMF? new Palette(romStream, 0x7478A0, 3): new Palette(romStream, 0x54A6D4, 3);

            // get graphics
            gfxData = Version.IsMF? new byte[0x2400]: new byte[0x2800];
            if (Version.IsMF)
            {
                Array.Copy(romStream.Data, 0x747900, gfxData, 0, 0x1400);
                Array.Copy(romStream.Data, 0x748D00, gfxData, 0x1400, 0x1C0);
                Array.Copy(romStream.Data, 0x748EC0, gfxData, 0x1800, 0x240);
                Array.Copy(romStream.Data, 0x749100, gfxData, 0x1C00, 0x2C0);
                Array.Copy(romStream.Data, 0x7493C0, gfxData, 0x2000, 0x2C0);
            }
            else
            {
                try
                {
                    int len = romStream.Read32(0x54E2F0) >> 8;
                    if (romStream.Read8(0x54E2F0) != 0x10 || len == 0)
                    {
                        throw new FormatException();
                    }
                    byte[] zmGFX = new GFX(romStream, 0x54E2F0).data;
                    //copy small uppercase
                    Array.Copy(zmGFX, 0, gfxData, 0, 0x400);
                    //copy big uppercase
                    Array.Copy(zmGFX, 0x800, gfxData, 0x400, 0x800);
                    //copy big lowercase
                    Array.Copy(zmGFX, 0x1000, gfxData, 0xC00, 0x800);
                    //copy copyright 1
                    Array.Copy(zmGFX, 0x1860, gfxData, 0x1400, 0x1C0);
                    //copy copyright2
                    Array.Copy(zmGFX, 0x1C20, gfxData, 0x1800, 0x240);
                    //copy copyright3
                    Array.Copy(zmGFX, 0x1FE0, gfxData, 0x1C00, 0x2C0);
                    //copy copyright4
                    Array.Copy(zmGFX, 0x2420, gfxData, 0x2000, 0x2C0);
                    //copy small lowercase
                    Array.Copy(zmGFX, 0x400, gfxData, 0x2400, 0x400);
                }
                catch(Exception ex) { MessageBox.Show(ex.Message); }
            }



            // get tile table
            int addr = Version.IsMF ? 0x74B0B0: 0x54C10C;
            //get offset from pointer
            //int addr = Version.IsMF ? romStream.ReadPtr(0xA231C): romStream.ReadPtr(0x856C8);
            int position = 0;
            StringBuilder text = new StringBuilder();

            int lines = GetNumberOfLines(addr);
            //label_line.Text = "Lines: " + lines;
            tileTable = new ushort[lines * 0x20];

            bool reading = true;
            while (reading)
            {
                int offset = addr + position * 0x24;
                byte inst = romStream.Read8(offset++);

                switch (inst)
                {
                    case 0:
                        text.Append("[1B]");
                        ReadOneLine(text, offset, 0x1000);
                        break;
                    case 1:
                        text.Append("[1R]");
                        ReadOneLine(text, offset, 0x2000);
                        break;
                    case 2:
                        text.Append("[2W]");
                        ReadTwoLines(text, offset);
                        break;
                    case 3:
                        text.Append("[1W]");
                        ReadOneLine(text, offset, 0x0000);
                        break;
                    case 5:
                        text.Append("[1]");
                        ttbIndex += 0x20;
                        break;
                    case 6:
                        text.Append("[END]");
                        reading = false;
                        break;
                    case 0xA:
                        text.Append("[Copyright1]");
                        ReadCopyright(0xE, 8, 0xA0);
                        break;
                    case 0xB:
                        text.Append("[Copyright2]");
                        ReadCopyright(0x12, 6, 0xC0);
                        break;
                    case 0xC:
                        text.Append("[Copyright3]");
                        ReadCopyright(0x16, 4, 0xE0);
                        break;
                    case 0xD:
                        text.Append("[Copyright4]");
                        ReadCopyright(0x12, 6, 0x100);
                        break;
                }

                text.Append("\r\n");
                position++;
            }

            //textBox.Text = text.ToString();
            //remove empty row
            textBox.Text = text.Remove(text.Length - 2, 2).ToString();
            image = new Bitmap(240, tileTable.Length / 4 + 160, PixelFormat.Format8bppIndexed);
            Draw();
            gfxView_preview.Size = new Size(480, image.Height * 2);
            gfxView_preview.BackgroundImage = image;
        }

        private int GetNumberOfLines(int offset)
        {
            int lines = 0;

            while (true)
            {
                byte inst = romStream.Read8(offset);
                if (inst == 6) { lines++; break; }

                if (inst == 2) { lines += 2; }
                else { lines++; }
                offset += 0x24;
            }

            return lines;
        }

        private void ReadOneLine(StringBuilder text, int offset, ushort color)
        {
            int index = ttbIndex;

            while (true)
            {
                byte ch = romStream.Read8(offset++);
                if (0x41 <= ch && ch <= 0x5A)
                {
                    text.Append((char)ch);
                    tileTable[index] = (ushort)(color | (ch - 0x40));
                }
                else if (0x61 <= ch && ch <= 0x7A)
                {//only zero mission support
                    text.Append((char)ch);
                    // samll lowercase offset fix, the gfx every row have 32(0x20) characters, samll lowercase move down 8 rows , so offset = 0x20*8 =0x100(256)
                    tileTable[index] = (ushort)(color | (ch - 0x41 + 0x100));
                }
                else if (ch == 0x26)
                {
                    text.Append('&');
                    tileTable[index] = (ushort)(color | 0x1D);
                }
                else if (ch == 0x2C)
                {
                    text.Append(',');
                    tileTable[index] = (ushort)(color | 0x1C);
                }
                else if (ch == 0x2E)
                {
                    text.Append('.');
                    tileTable[index] = (ushort)(color | 0x1D);
                }
                else if (ch == 0)
                {
                    break;
                }
                else
                {
                    text.Append(' ');
                }

                index++;
            }

            ttbIndex += 0x20;
        }

        private void ReadTwoLines(StringBuilder text, int offset)
        {
            int index = ttbIndex;

            while (true)
            {
                byte ch = romStream.Read8(offset++);
                if (0x41 <= ch && ch <= 0x5A)
                {
                    text.Append((char)ch);
                    tileTable[index] = (ushort)(ch - 0x21);
                    tileTable[index + 0x20] = (ushort)(ch - 1);
                }
                else if (0x61 <= ch && ch <= 0x7A)
                {
                    text.Append((char)ch);
                    tileTable[index] = (ushort)(ch - 1);
                    tileTable[index + 0x20] = (ushort)(ch + 0x1F);
                }
                else if (ch == 0x2B)
                {
                    text.Append('í');
                    tileTable[index] = 0x7A;
                    tileTable[index + 0x20] = 0x9A;
                }
                else if (ch == 0x2C)
                {
                    text.Append(',');
                    tileTable[index + 0x20] = 0x5C;
                }
                else if (ch == 0x2D)
                {
                    text.Append('\'');
                    //fix ' display error
                    //tileTable[index + 0x20] = 0x3A;
                    tileTable[index] = 0x3A;
                }
                else if (ch == 0x2E)
                {
                    text.Append('.');
                    tileTable[index + 0x20] = 0x5B;
                }
                else if (ch == 0)
                {
                    break;
                }
                else
                {
                    text.Append(' ');
                }

                index++;
            }

            ttbIndex += 0x40;
        }

        private void ReadCopyright(int len, int indent, ushort value)
        {
            for (int i = 0; i < len; i++)
            {
                tileTable[ttbIndex + indent + i] = (ushort)(value + i);
            }
            ttbIndex += 0x20;
        }

        private unsafe void Draw()
        {
            int w = image.Width;
            int index = 0;
            palette.SetBitmapPalette(image, 0, 3);

            Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);
            BitmapData imgData = image.LockBits(rect, ImageLockMode.WriteOnly, image.PixelFormat);

            byte* startPtr = (byte*)imgData.Scan0;
            startPtr += w * 160;
            byte* imgPtr = startPtr;

            for (int t = 0; t < tileTable.Length; t++)
            {
                if (t % 32 >= 30)
                {
                    index++;
                    continue;
                }

                int x = (t % 32) * 8;
                int y = (t / 32) * 8;
                imgPtr = startPtr + y * w + x;

                ushort currTile = tileTable[index++];
                int tileNum = (currTile & 0x3FF) * 0x20;
                int pal = (currTile >> 12) << 4;
                int flip = (currTile >> 10) & 3;

                switch (flip)
                {
                    // no flip
                    case 0:
                        for (int r = 0; r < 8; r++)
                        {
                            for (int pp = 0; pp < 4; pp++)
                            {
                                byte val = gfxData[tileNum++];
                                *imgPtr++ = (byte)(pal | val & 0xF);
                                *imgPtr++ = (byte)(pal | val >> 4);
                            }
                            // end of row
                            imgPtr += (w - 8);
                        }
                        break;
                    // x flip
                    case 1:
                        imgPtr += 7;
                        for (int r = 0; r < 8; r++)
                        {
                            for (int pp = 0; pp < 4; pp++)
                            {
                                byte val = gfxData[tileNum++];
                                *imgPtr-- = (byte)(pal | val & 0xF);
                                *imgPtr-- = (byte)(pal | val >> 4);
                            }
                            // end of row
                            imgPtr += (w + 8);
                        }
                        break;
                    // y flip
                    case 2:
                        imgPtr += (w * 7);
                        for (int r = 0; r < 8; r++)
                        {
                            for (int pp = 0; pp < 4; pp++)
                            {
                                byte val = gfxData[tileNum++];
                                *imgPtr++ = (byte)(pal | val & 0xF);
                                *imgPtr++ = (byte)(pal | val >> 4);
                            }
                            // end of row
                            imgPtr -= (w + 8);
                        }
                        break;
                    // xy flip
                    case 3:
                        imgPtr += (w * 7 + 7);
                        for (int r = 0; r < 8; r++)
                        {
                            for (int pp = 0; pp < 4; pp++)
                            {
                                byte val = gfxData[tileNum++];
                                *imgPtr-- = (byte)(pal | val & 0xF);
                                *imgPtr-- = (byte)(pal | val >> 4);
                            }
                            // end of row
                            imgPtr -= (w - 8);
                        }
                        break;
                }
            }

            image.UnlockBits(imgData);
        }

        #region update credits
        private List<KeyValuePair<string, string>> ParseText(out int textLines)
        {
            textLines = 0;
            
            //text length more than 35
            List<string> tooLong = new List<string>();

            var list = new List<KeyValuePair<string, string>>();
            //split new credits:type,contents => list
            string[] newCredits = textBox.Text.Split('\n');

            //cheacking for illegal characters
            Regex regex_1 = new Regex("[^ A-Z\x20,.&]");
            Regex regex_1_zm = new Regex("[^ a-zA-Z\x20,.&]");
            Regex regex_2 = new Regex("[^ a-zA-Z',í.\x20]");

            try
            {
                for (int i = 0; i < newCredits.Length; i++)
                {
                    //remove the '\r' of every row (last row [END] does not contain '\r')
                    if (i < newCredits.Length - 1) newCredits[i] = newCredits[i].Remove(newCredits[i].Length - 1);
                    string pre = "";
                    foreach (char ch in newCredits[i])
                    {
                        pre += ch;
                        if (ch == ']') break;
                    }
                    switch (pre)
                    {
                        case "[1]":
                            list.Add(new KeyValuePair<string, string>(pre, ""));
                            textLines++;
                            break;
                        case "[1W]":
                            // the [1W] only supported in ZM
                            if(Version.IsMF) throw new ArgumentException(string.Format(Properties.Resources.formCredits_ParseText_Ex_1W, Hex.ToString(i + 1), newCredits[i]));
                            if (regex_1_zm.IsMatch(newCredits[i].Substring(4)))
                            {
                                MatchCollection match = regex_1_zm.Matches(newCredits[i].Substring(4));
                                string illegal = string.Join(" ", match.Cast<Match>().Select(m => m.Value).ToArray());
                                throw new ArgumentException(string.Format(Properties.Resources.formCredits_ParseText_illegalChar, illegal, Hex.ToString(i + 1), newCredits[i]));
                            }
                            if (newCredits[i].Substring(4).Length > 35)
                            {
                                //more than 35, cut off anything longer than 35 characters
                                tooLong.Add(Hex.ToString(i + 1));
                                list.Add(new KeyValuePair<string, string>(pre, newCredits[i].Substring(4,35)));
                            }
                            else list.Add(new KeyValuePair<string, string>(pre, newCredits[i].Substring(4)));
                            textLines++;
                            break;
                        case "[1B]":
                        case "[1R]":
                            if (Version.IsMF? regex_1.IsMatch(newCredits[i].Substring(4)): regex_1_zm.IsMatch(newCredits[i].Substring(4)))
                            {
                                MatchCollection match = Version.IsMF? regex_1.Matches(newCredits[i].Substring(4)): regex_1_zm.Matches(newCredits[i].Substring(4));
                                string illegal = string.Join(" ", match.Cast<Match>().Select(m => m.Value).ToArray());
                                throw new ArgumentException(string.Format(Properties.Resources.formCredits_ParseText_illegalChar, illegal, Hex.ToString(i + 1), newCredits[i]));
                            }
                            if (newCredits[i].Substring(4).Length > 35)
                            {
                                //more than 35, cut off anything longer than 35 characters
                                tooLong.Add(Hex.ToString(i + 1));
                                list.Add(new KeyValuePair<string, string>(pre, newCredits[i].Substring(4, 35)));
                            }
                            else list.Add(new KeyValuePair<string, string>(pre, newCredits[i].Substring(4)));
                            textLines++;
                            break;
                        case "[Copyright1]":
                        case "[Copyright2]":
                        case "[Copyright3]":
                        case "[Copyright4]":
                            list.Add(new KeyValuePair<string, string>(pre, ""));
                            textLines++;
                            break;
                        case "[2W]":
                            if (regex_2.IsMatch(newCredits[i].Substring(4)))
                            {
                                MatchCollection match = regex_2.Matches(newCredits[i].Substring(4));
                                string illegal = string.Join(" ", match.Cast<Match>().Select(m => m.Value).ToArray());
                                throw new ArgumentException(string.Format(Properties.Resources.formCredits_ParseText_illegalChar, illegal, Hex.ToString(i + 1), newCredits[i]));
                            }
                            //remap 'í' and '\''
                            newCredits[i] = newCredits[i].Replace('í', '+').Replace('\'', '-');
                            if (newCredits[i].Substring(4).Length > 35)
                            {
                                //more than 35, cut off anything longer than 35 characters
                                tooLong.Add(Hex.ToString(i + 1));
                                list.Add(new KeyValuePair<string, string>(pre, newCredits[i].Substring(4, 35)));
                            }
                            else list.Add(new KeyValuePair<string, string>(pre, newCredits[i].Substring(4)));
                            textLines += 2;
                            break;
                        case "[END]":
                            list.Add(new KeyValuePair<string, string>(pre, ""));
                            textLines++;
                            break;
                        default:
                            throw new ArgumentException(string.Format(Properties.Resources.formCredits_ParseText_InvalidPrefix, Hex.ToString(i + 1), newCredits[i]));
                    }
                }
                //check [END] tag
                //int count = list.Select(kv => kv.Key).ToList().Count(key => key=="[END]");
                List<string> indexes = new List<string>();
                for (int i = 0; i < list.Count; i++) { if (list[i].Key == "[END]") indexes.Add(Hex.ToString(i + 1)); }
                if (indexes.Count == 0) throw new ArgumentException(Properties.Resources.formCredits_ParseText_NoEND);
                else if (indexes.Count > 1)
                {
                    throw new ArgumentException(string.Format(Properties.Resources.FormCredits_ParseText_TooManyEND,string.Join(" ",indexes)));
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, Properties.Resources.form_ErrorMessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                throw;
            }
            if(tooLong?.Count>0) MessageBox.Show(string.Format(Properties.Resources.formCredits_tooLong, string.Join(" ", tooLong)), Properties.Resources.formCredits_tooLong_Attention, MessageBoxButtons.OK, MessageBoxIcon.Information);
            return list;
        }

        private List<byte[]> textToData(List<KeyValuePair<string, string>> creditPairs)
        {
            List<byte[]> data = new List<byte[]> { };
            foreach (var kv in creditPairs)
            {
                //one line have 0x24 byte;
                byte[] line = new byte[0x24];
                switch (kv.Key)
                {
                    case "[1]":
                        line[0] = 5;
                        Encoding.ASCII.GetBytes(kv.Value).CopyTo(line, 1);
                        data.Add(line);
                        break;
                    case "[1B]":
                        line[0] = 0;
                        Encoding.ASCII.GetBytes(kv.Value).CopyTo(line, 1);
                        data.Add(line);
                        break;
                    case "[1R]":
                        line[0] = 1;
                        Encoding.ASCII.GetBytes(kv.Value).CopyTo(line, 1);
                        data.Add(line);
                        break;
                    case "[1W]":
                        line[0] = 3;
                        Encoding.ASCII.GetBytes(kv.Value).CopyTo(line, 1);
                        data.Add(line);
                        break;
                    case "[Copyright1]":
                        line[0] = 0xA;
                        data.Add(line);
                        break;
                    case "[Copyright2]":
                        line[0] = 0xB;
                        data.Add(line);
                        break;
                    case "[Copyright3]":
                        line[0] = 0xC;
                        data.Add(line);
                        break;
                    case "[Copyright4]":
                        line[0] = 0xD;
                        data.Add(line);
                        break;
                    case "[2W]":
                        line[0] = 2;
                        Encoding.ASCII.GetBytes(kv.Value).CopyTo(line, 1);
                        data.Add(line);
                        break;
                    case "[END]":
                        line[0] = 6;
                        data.Add(line);
                        break;
                }
            }
            return data;
        }

        private ushort[] DataToTable(List<byte[]> datas, int lines)
        {
            newTable = new ushort[lines * 0x20];
            dataIndex = 0;
            foreach (byte[] data in datas)
            {
                switch (data[0])
                {
                    case 0:
                        //ReadOneLine(data, 0x1000);
                        ReadOneLine(Version.IsMF? data: Center(data), 0x1000);
                        break;
                    case 1:
                        ReadOneLine(Version.IsMF ? data : Center(data), 0x2000);
                        break;
                    case 2:
                        ReadTwoLines(Version.IsMF ? data : Center(data));
                        break;
                    case 3:
                        ReadOneLine(Center(data), 0x0000);
                        break;
                    case 5:
                        dataIndex += 0x20;
                        break;
                    case 6:
                        break;
                    case 0xA:
                        ReadCopyrightUpdate(0xE, 8, 0xA0);
                        break;
                    case 0xB:
                        ReadCopyrightUpdate(0x12, 6, 0xC0);
                        break;
                    case 0xC:
                        ReadCopyrightUpdate(0x16, 4, 0xE0);
                        break;
                    case 0xD:
                        ReadCopyrightUpdate(0x12, 6, 0x100);
                        break;
                }
            }
            return newTable;
        }

        private void ReadOneLine(byte[] line, ushort color)
        {
            int index = dataIndex;

            for (int i = 1; line[i] != 0 && i < line.Length - 1; i++)
            {
                if (0x41 <= line[i] && line[i] <= 0x5A) //A-Z
                {
                    newTable[index] = (ushort)(color | (line[i] - 0x40));
                }
                else if (0x61 <= line[i] && line[i] <= 0x7A)
                {
                    // samll lowercase offset fix, the gfx every row have 32(0x20) characters, samll lowercase move down 8 rows , so offset = 0x20*8 =0x100(256)
                    newTable[index] = (ushort)(color | (line[i] - 0x41 + 0x100));
                }
                else if (line[i] == 0x26)
                {
                    newTable[index] = (ushort)(color | 0x1D);
                }
                else if (line[i] == 0x2C)
                {
                    newTable[index] = (ushort)(color | 0x1C);
                }
                else if (line[i] == 0x2E)
                {
                    newTable[index] = (ushort)(color | 0x1D);
                }

                index++;
            }

            dataIndex += 0x20;
        }

        private void ReadTwoLines(byte[] line)
        {
            int index = dataIndex;

            for (int i = 1; line[i] != 0 && i < line.Length - 1; i++)
            {
                if (0x41 <= line[i] && line[i] <= 0x5A) //A-Z
                {
                    newTable[index] = (ushort)(line[i] - 0x21);
                    newTable[index + 0x20] = (ushort)(line[i] - 1);
                }
                else if (0x61 <= line[i] && line[i] <= 0x7A) //a-z
                {
                    newTable[index] = (ushort)(line[i] - 1);
                    newTable[index + 0x20] = (ushort)(line[i] + 0x1F);
                }
                else if (line[i] == 0x2B) //+
                {
                    newTable[index] = 0x7A;
                    newTable[index + 0x20] = 0x9A;
                }
                else if (line[i] == 0x2C) //,
                {
                    newTable[index + 0x20] = 0x5C;
                }
                else if (line[i] == 0x2D) //-
                {
                    //newTable[index + 0x20] = 0x3A;
                    newTable[index] = 0x3A;
                }
                else if (line[i] == 0x2E) //.
                {
                    newTable[index + 0x20] = 0x5B;
                }

                index++;
            }

            dataIndex += 0x40;
        }

        private void ReadCopyrightUpdate(int len, int indent, ushort value)
        {
            for (int i = 0; i < len; i++)
            {
                newTable[dataIndex + indent + i] = (ushort)(value + i);
            }
            dataIndex += 0x20;
        }

        private byte[] Center(byte[] data)
        {
            int len = 0;
            int noData = 0;
            for(int i = 1; i < data.Length; i++) 
            {
                if (data[i] != 0 && data[i + 1] == 0) len = i;
            }
            //screen line up to 30 characters
            noData = 30 - len;
            noData = noData%2==0?noData/2:noData/2+1;
            Array.Copy(data, 1, data, noData + 1, len);
            for(int i = 0,j = 1; i < noData; i++) 
            {
                data[j++] = 32; 
            }
            return data;
        }

        private unsafe void DrawUpdate()
        {
            int w = image.Width;
            int index = 0;
            palette.SetBitmapPalette(image, 0, 3);

            Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);
            BitmapData imgData = image.LockBits(rect, ImageLockMode.WriteOnly, image.PixelFormat);

            byte* startPtr = (byte*)imgData.Scan0;
            startPtr += w * 160;
            byte* imgPtr = startPtr;

            for (int t = 0; t < newTable.Length; t++)
            {
                if (t % 32 >= 30)
                {
                    index++;
                    continue;
                }

                int x = (t % 32) * 8;
                int y = (t / 32) * 8;
                imgPtr = startPtr + y * w + x;

                ushort currTile = newTable[index++];
                int tileNum = (currTile & 0x3FF) * 0x20;
                int pal = (currTile >> 12) << 4;
                int flip = (currTile >> 10) & 3;

                switch (flip)
                {
                    // no flip
                    case 0:
                        for (int r = 0; r < 8; r++)
                        {
                            for (int pp = 0; pp < 4; pp++)
                            {
                                byte val = gfxData[tileNum++];
                                *imgPtr++ = (byte)(pal | val & 0xF);
                                *imgPtr++ = (byte)(pal | val >> 4);
                            }
                            // end of row
                            imgPtr += (w - 8);
                        }
                        break;
                    // x flip
                    case 1:
                        imgPtr += 7;
                        for (int r = 0; r < 8; r++)
                        {
                            for (int pp = 0; pp < 4; pp++)
                            {
                                byte val = gfxData[tileNum++];
                                *imgPtr-- = (byte)(pal | val & 0xF);
                                *imgPtr-- = (byte)(pal | val >> 4);
                            }
                            // end of row
                            imgPtr += (w + 8);
                        }
                        break;
                    // y flip
                    case 2:
                        imgPtr += (w * 7);
                        for (int r = 0; r < 8; r++)
                        {
                            for (int pp = 0; pp < 4; pp++)
                            {
                                byte val = gfxData[tileNum++];
                                *imgPtr++ = (byte)(pal | val & 0xF);
                                *imgPtr++ = (byte)(pal | val >> 4);
                            }
                            // end of row
                            imgPtr -= (w + 8);
                        }
                        break;
                    // xy flip
                    case 3:
                        imgPtr += (w * 7 + 7);
                        for (int r = 0; r < 8; r++)
                        {
                            for (int pp = 0; pp < 4; pp++)
                            {
                                byte val = gfxData[tileNum++];
                                *imgPtr-- = (byte)(pal | val & 0xF);
                                *imgPtr-- = (byte)(pal | val >> 4);
                            }
                            // end of row
                            imgPtr -= (w - 8);
                        }
                        break;
                }
            }

            image.UnlockBits(imgData);
        }
        #endregion

        private void button_update_Click(object sender, EventArgs e)
        {
            List<KeyValuePair<string, string>> list = ParseText(out int textLines);
            List<byte[]> datas = textToData(list);
            DataToTable(datas, textLines);

            image = new Bitmap(240, newTable.Length / 4 + 160, PixelFormat.Format8bppIndexed);
            DrawUpdate();
            gfxView_preview.Size = new Size(480, image.Height * 2);
            gfxView_preview.BackgroundImage = image;

        }
        private void button_apply_Click(object sender, EventArgs e)
        {
            var pairs = ParseText(out _);
            var lines = textToData(pairs);

            //todo: size check, fusion size 0x2B98 bytes (310 rows), zm size 0x21C0 (239 rows)
            if (Version.IsMF? lines.Count > 310: lines.Count > 240)
            {
                MessageBox.Show(string.Format(Properties.Resources.formCredits_tooManyLines, Hex.ToString(Version.IsMF ? 310 : 240)), Properties.Resources.form_ErrorMessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            for (int i = 0; i < lines.Count; i++)
            {
                if(Version.IsMF) Array.Copy(lines[i], 0, romStream.Data, 0x74B0B0 + 0x24 * i, 0x24);
                else Array.Copy(lines[i], 0, romStream.Data, 0x54C130 + 0x24 * i, 0x24);
            }
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox_MouseClick(object sender, MouseEventArgs e)
        {
            label_pos.Text = Hex.ToString(textBox.GetLineFromCharIndex(textBox.SelectionStart) + 1);
        }

        private void textBox_KeyUp(object sender, KeyEventArgs e)
        {
            label_pos.Text = Hex.ToString(textBox.GetLineFromCharIndex(textBox.SelectionStart) + 1);
        }

        private void button_help_Click(object sender, EventArgs e)
        {
            string message = Properties.Resources.formCredits_HelpText;
            MessageBox.Show(message,button_help.Text,MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button_test_Click(object sender, EventArgs e)
        {
            button_apply.PerformClick();
            Test.Credit();
        }
    }
}
