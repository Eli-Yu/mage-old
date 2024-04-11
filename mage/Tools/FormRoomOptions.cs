using System;
using System.Drawing;
using System.Windows.Forms;

namespace mage
{
    public partial class FormRoomOptions : Form
    {
        // fields
        private FormMain main;
        private Room room;

        private bool updatedScreenBoxes = false;
        private bool updatedBlocksBoxes = false;

        // constructor
        public FormRoomOptions(FormMain main)
        {
            InitializeComponent();

            this.main = main;
            this.room = main.Room;
            Initialize();
        }

        private void Initialize()
        {
            checkBox_bg0.Enabled = room.BG0.IsRLE;
            checkBox_bg1.Enabled = room.BG1.IsRLE;
            checkBox_bg2.Enabled = room.BG2.IsRLE;

            textBox_width.Text = Hex.ToString(room.Width);
            textBox_height.Text = Hex.ToString(room.Height);
        }

        private void UpdateText(TextBox textBox, TextBox label, int size)
        {
            updatedScreenBoxes = true;
            try
            {
                double screen = Hex.ToByte(textBox.Text);
                screen = Math.Round((screen - 4) / size, 4);
                label.Text = screen.ToString();
                if (screen % 1 == 0 & screen > 0)
                {
                    label.ForeColor = Color.Black;
                }
                else
                {
                    label.ForeColor = Color.DarkRed;
                }
            }
            catch
            {
                label.Text = "–";
                label.ForeColor = Color.DarkRed;
            }
            updatedScreenBoxes = false;
        }

        //update blocks value by editing screens
        private void UpdateBlockText(TextBox textBox, TextBox label, int size)
        {
            updatedBlocksBoxes = true;
            try
            {
                int blocks = Hex.ToByte(textBox.Text);
                blocks = blocks * size + 4;
                label.Text = Hex.ToString(blocks);
                if (blocks % 1 == 0 & blocks > 0)
                {
                    label.ForeColor = Color.Black;
                }
                else
                {
                    label.ForeColor = Color.DarkRed;
                }
            }
            catch
            {
                label.Text = "0";
                label.ForeColor = Color.DarkRed;
            }
            updatedBlocksBoxes = false;
        }

        private void textBox_width_TextChanged(object sender, EventArgs e)
        {
            if (updatedBlocksBoxes) return;
            UpdateText(textBox_width, textBox_screenX, 15);
        }

        private void textBox_height_TextChanged(object sender, EventArgs e)
        {
            if (updatedBlocksBoxes) return;
            UpdateText(textBox_height, textBox_screenY, 10);
        }

        private void button_clearBG_Click(object sender, EventArgs e)
        {
            if (checkBox_bg0.Checked)
            {
                room.BG0.Clear();
                checkBox_bg0.Checked = false;
            }
            if (checkBox_bg1.Checked)
            {
                room.BG1.Clear();
                checkBox_bg1.Checked = false;
            }
            if (checkBox_bg2.Checked)
            {
                room.BG2.Clear();
                checkBox_bg2.Checked = false;
            }
            if (checkBox_clip.Checked)
            {
                room.Clip.Clear();
                checkBox_clip.Checked = false;
            }

            //add clear sprites, doors and scrolls options
            if (checkBox_sprites.Checked)
            {
                foreach (EnemyList l in room.enemyLists) l?.Clear();
                checkBox_sprites.Checked = false;
            }

            if (checkBox_doors.Checked)
            {
                room.doorList.Clear();
                checkBox_doors.Checked = false;
            }

            if (checkBox_scrolls.Checked)
            {
                room.scrollList.Clear();
                checkBox_scrolls.Checked = false;
            }

            main.ReloadRoom(true);
            room = main.Room;
        }

        private void button_resize_Click(object sender, EventArgs e)
        {
            // get width and height
            byte width, height;
            try
            {
                width = Hex.ToByte(textBox_width.Text);
                height = Hex.ToByte(textBox_height.Text);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("One of the values entered was not valid.\n\n" + ex.Message, 
                    //"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(Properties.Resources.form_OneValueNotValidErrorText + ex.Message,
                    Properties.Resources.form_ErrorMessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // check if valid
            try
            {
                Room.CheckValidSize(width, height);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.Message, Properties.Resources.form_ErrorMessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            room.backgrounds.ResizeRoom(width, height);
            main.ReloadRoom(true);
            room = main.Room;
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox_screenX_TextChanged(object sender, EventArgs e)
        {
            if(updatedScreenBoxes) return;
            UpdateBlockText(textBox_screenX, textBox_width, 15);
        }

        private void textBox_screenY_TextChanged(object sender, EventArgs e)
        {
            if (updatedScreenBoxes) return;
            UpdateBlockText(textBox_screenY, textBox_height, 10);
        }
    }
}
