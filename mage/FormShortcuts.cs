using mage.Properties;
using System;
using System.Windows.Forms;

namespace mage
{
    public partial class FormShortcuts : Form
    {
        // fields
        private bool isMF;
        private FormMain main;
        
        //hatch number: use to define the number of hatch in fusion
        private byte hatchNumber = 1;

        // constructor
        public FormShortcuts(FormMain main)
        {
            InitializeComponent();

            this.main = main;
            Initialize();
        }

        private void Initialize()
        {
            isMF = Version.IsMF;

            if (isMF)
            {
                groupBox_super.Enabled = false;
                button_lava_weak.Enabled = false;
                label_lava_weak.Enabled = false;
                button_lava_strong.Enabled = false;
                label_lava_strong.Enabled = false;
                button_acid.Enabled = false;
                label_acid.Enabled = false;
                button_crumble_slow.Enabled = false;
                label_crumble_slow.Enabled = false;

                //grey hatch: navigation room use
                button_grey.Enabled = true;
                label_grey.Enabled = true;
                //default hatch 1
                foreach (Control label in groupBox_hatch.Controls)
                {
                    if(label is Label)
                    {
                        if (label == label_grey) continue;
                        else label.Text += (" " + hatchNumber);
                    }
                }
            }
        }

        private void button_air_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0;
        }

        private void button_solid_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0x10;
        }

        #region energy tanks
        private void button_energy_Click(object sender, EventArgs e)
        {
            if (isMF) { main.Clipdata = 0x63; }
            else { main.Clipdata = 0x5C; }
        }

        private void button_energy_hidden_Click(object sender, EventArgs e)
        {
            if (isMF) { main.Clipdata = 0x65; }
            else { main.Clipdata = 0x6C; }
        }

        private void button_energy_water_Click(object sender, EventArgs e)
        {
            if (isMF) { main.Clipdata = 0x67; }
            else { main.Clipdata = 0x7C; }
        }
        #endregion

        #region missiles
        private void button_missile_Click(object sender, EventArgs e)
        {
            if (isMF) { main.Clipdata = 0x62; }
            else { main.Clipdata = 0x5D; }
        }

        private void button_missile_hidden_Click(object sender, EventArgs e)
        {
            if (isMF) { main.Clipdata = 0x64; }
            else { main.Clipdata = 0x6D; }
        }

        private void button_missile_water_Click(object sender, EventArgs e)
        {
            if (isMF) { main.Clipdata = 0x66; }
            else { main.Clipdata = 0x7D; }
        }

        private void button_missile_block_no_Click(object sender, EventArgs e)
        {
            if (isMF) { main.Clipdata = 0x5E; }
            else { main.Clipdata = 0x68; }
        }

        private void button_missile_block_never_Click(object sender, EventArgs e)
        {
            if (isMF) { main.Clipdata = 0x54; }
            else { main.Clipdata = 0x58; }
        }
        #endregion

        #region super missiles
        private void button_super_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0x5E;
        }

        private void button_super_hidden_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0x6E;
        }

        private void button_super_water_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0x7E;
        }

        private void button_super_block_no_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0x69;
        }

        private void button_super_block_never_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0x59;
        }
        #endregion

        #region power bombs
        private void button_power_Click(object sender, EventArgs e)
        {
            if (isMF) { main.Clipdata = 0x68; }
            else { main.Clipdata = 0x5F; }
        }

        private void button_power_hidden_Click(object sender, EventArgs e)
        {
            if (isMF) { main.Clipdata = 0x69; }
            else { main.Clipdata = 0x6F; }
        }

        private void button_power_water_Click(object sender, EventArgs e)
        {
            if (isMF) { main.Clipdata = 0x6A; }
            else { main.Clipdata = 0x7F; }
        }

        private void button_power_block_never_Click(object sender, EventArgs e)
        {
            if (isMF) { main.Clipdata = 0x57; }
            else { main.Clipdata = 0x5B; }
        }
        #endregion

        #region liquids
        private void button_water_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0x1B;
        }

        private void button_lava_weak_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0xA0;
        }

        private void button_lava_strong_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0xA1;
        }

        private void button_acid_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0xA2;
        }
        #endregion

        #region transitions
        private void button_trans_door_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0x20;
        }

        private void button_trans_up_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0x27;
        }

        private void button_trans_down_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0x28;
        }
        #endregion

        #region slopes
        private void button_slope45_pos_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0x11;
        }

        private void button_slope45_neg_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0x12;
        }

        private void button_slope27_Lpos_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0x13;
        }

        private void button_slope27_Upos_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0x14;
        }

        private void button_slope27_Uneg_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0x15;
        }

        private void button_slope27_Lneg_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0x16;
        }
        #endregion

        #region ground
        private void button_dusty_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0x1D;
        }

        private void button_dusty_very_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0x2D;
        }

        private void button_wet_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0x1C;
        }

        private void button_bubbly_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0x2C;
        }
        #endregion

        #region breakable
        private void button_bomb_Click(object sender, EventArgs e)
        {
            if (isMF) { main.Clipdata = 0x56; }
            else { main.Clipdata = 0x67; }
        }

        private void button_bomb_never_Click(object sender, EventArgs e)
        {
            if (isMF) { main.Clipdata = 0x55; }
            else { main.Clipdata = 0x57; }
        }

        private void button_speed_Click(object sender, EventArgs e)
        {
            if (isMF) { main.Clipdata = 0x6B; }
            else { main.Clipdata = 0x6A; }
        }

        private void button_speed_no_Click(object sender, EventArgs e)
        {
            if (isMF) { main.Clipdata = 0x58; }
            else { main.Clipdata = 0x5A; }
        }

        private void button_screw_no_Click(object sender, EventArgs e)
        {
            if (isMF) { main.Clipdata = 0x59; }
            else { main.Clipdata = 0x6B; }
        }

        private void button_crumble_Click(object sender, EventArgs e)
        {
            if (isMF) { main.Clipdata = 0x5A; }
            else {main.Clipdata = 0x56; }
        }

        private void button_crumble_slow_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0x66;
        }
        #endregion

        #region shot
        private void button_shot_Click(object sender, EventArgs e)
        {
            if (isMF) { main.Clipdata = 0x53; }
            else { main.Clipdata = 0x62; }
        }

        private void button_shot_no_Click(object sender, EventArgs e)
        {
            if (isMF) { main.Clipdata = 0x5B; }
            else { main.Clipdata = 0x55; }
        }

        private void button_shot_never_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0x52;
        }

        private void button_shot_TL_no_Click(object sender, EventArgs e)
        {
            if (isMF) { main.Clipdata = 0x5C; }
            else { main.Clipdata = 0x53; }
        }

        private void button_shot_TR_no_Click(object sender, EventArgs e)
        {
            if (isMF) { main.Clipdata = 0x5D; }
            else { main.Clipdata = 0x54; }
        }

        private void button_shot_BL_no_Click(object sender, EventArgs e)
        {
            if (isMF) { main.Clipdata = 0x6C; }
            else { main.Clipdata = 0x63; }
        }

        private void button_shot_BR_no_Click(object sender, EventArgs e)
        {
            if (isMF) { main.Clipdata = 0x6D; }
            else { main.Clipdata = 0x64; }
        }

        private void button_shot_TL_never_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0x50;
        }

        private void button_shot_TR_never_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0x51;
        }

        private void button_shot_BL_never_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0x60;
        }

        private void button_shot_BR_never_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0x61;
        }
        #endregion

        #region hatch
        private void button_white_Click(object sender, EventArgs e)
        {
            if(!isMF) main.Clipdata = 0x30;
            else
            {
                main.Clipdata = hatchNumber switch
                {
                    1 => 0x30,
                    2 => 0x31,
                    3 => 0x32,
                    4 => 0x33,
                    5 => 0x34,
                    6 => 0x35,
                    _ => 0x30,
                };
            }
        }

        private void button_blue_Click(object sender, EventArgs e)
        {
            if(!isMF) main.Clipdata = 0x36;
            else
            {
                main.Clipdata = hatchNumber switch
                {
                    1 => 0x36,
                    2 => 0x37,
                    3 => 0x38,
                    4 => 0x39,
                    5 => 0x3A,
                    6 => 0x3B,
                    _ => 0x36,
                };
            }
        }

        private void button_red_Click(object sender, EventArgs e)
        {
            if(!isMF) main.Clipdata = 0x40;
            else
            {
                main.Clipdata = hatchNumber switch
                {
                    1 => 0x3C,
                    2 => 0x3D,
                    3 => 0x3E,
                    4 => 0x4C,
                    5 => 0x4D,
                    6 => 0x4E,
                    _ => 0x3C,
                };
            }
        }

        private void button_green_Click(object sender, EventArgs e)
        {
            if (!isMF) main.Clipdata = 0x46;
            else
            {
                main.Clipdata = hatchNumber switch
                {
                    1 => 0x40,
                    2 => 0x41,
                    3 => 0x42,
                    4 => 0x43,
                    5 => 0x44,
                    6 => 0x45,
                    _ => 0x40,
                };
            }
        }

        private void button_yellow_Click(object sender, EventArgs e)
        {
            if(!isMF) main.Clipdata = 0x4C;
            else
            {
                main.Clipdata = hatchNumber switch
                {
                    1 => 0x46,
                    2 => 0x47,
                    3 => 0x48,
                    4 => 0x49,
                    5 => 0x4A,
                    6 => 0x4B,
                    _ => 0x46,
                };
            }
        }

        private void button_grey_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0x3F;
        }
        #endregion

        //input 1-6(inlude number pad 1-6) to select slot of hatch and modify hatch label in fusion
        private void FormShortcuts_KeyDown(object sender, KeyEventArgs e)
        {
            if(!isMF) return;
            hatchNumber = e.KeyCode switch 
            {
                Keys.D1 => 1,
                Keys.NumPad1 => 1,
                Keys.D2 => 2,
                Keys.NumPad2 => 2,
                Keys.D3 => 3,
                Keys.NumPad3 => 3,
                Keys.D4 => 4,
                Keys.NumPad4 => 4,
                Keys.D5 => 5,
                Keys.NumPad5 => 5,
                Keys.D6 => 6,
                Keys.NumPad6 => 6,
                _ => 0,
            };
            foreach (Control label in groupBox_hatch.Controls)
            {
                if(label is Label)
                {
                    if (label == label_grey) continue;
                    else if(hatchNumber!=0) label.Text = label.Text.Remove(label.Text.Length -1, 1) + hatchNumber;
                }
            }
        }
    }
}
