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
        //bomb->bomb chian, slope->ceiling
        private bool isSwitch = false;
        //horizontal, vertical bomb chain number
        private byte hNumber = 1, vNumber = 1;

        // constructor
        public FormShortcuts(FormMain main)
        {
            InitializeComponent();

            this.main = main;
            Initialize();
            //mouse wheel events, can not use designer bind
            button_bomb.MouseWheel += button_bomb_MouseWheel;
            button_bomb_never.MouseWheel += button_bomb_never_MouseWheel;
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

                //switch groupBox ladder, and hide groupBox super
                groupBox_super.Visible = false;
                groupBox_ladder.Enabled = true;
                groupBox_ladder.Visible = true;

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
            if (isSwitch) main.Clipdata = 0x21;
            else main.Clipdata = 0x11;
        }

        private void button_slope45_neg_Click(object sender, EventArgs e)
        {
            if (isSwitch) main.Clipdata = 0x22;
            else main.Clipdata = 0x12;
        }

        private void button_slope27_Lpos_Click(object sender, EventArgs e)
        {
            if (isSwitch) main.Clipdata = 0x23;
            else main.Clipdata = 0x13;
        }

        private void button_slope27_Upos_Click(object sender, EventArgs e)
        {
            if (isSwitch) main.Clipdata = 0x24;
            else main.Clipdata = 0x14;
        }

        private void button_slope27_Uneg_Click(object sender, EventArgs e)
        {
            if (isSwitch) main.Clipdata = 0x25;
            else main.Clipdata = 0x15;
        }

        private void button_slope27_Lneg_Click(object sender, EventArgs e)
        {
            if (isSwitch) main.Clipdata = 0x26;
            else main.Clipdata = 0x16;
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
            if(isSwitch)
            {//vertical
                main.Clipdata = (ushort)(0x70 + vNumber - 1);
            }
            else 
            { 
                if (isMF) { main.Clipdata = 0x56; }
                else { main.Clipdata = 0x67; }
            }
        }

        private void button_bomb_never_Click(object sender, EventArgs e)
        {
            if (isSwitch)
            {//horizontal bomb chain
                main.Clipdata = (ushort)(0x74 + hNumber - 1);
            }
            else 
            {
                if (isMF) { main.Clipdata = 0x55; }
                else { main.Clipdata = 0x57; }
            }
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

        #region ladder
        private void button_ladder_ceiling_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0x18;
        }

        private void button_ladder_right_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0x19;
        }

        private void button_ladder_left_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0x1A;
        }
        #endregion

        //input 1-6(inlude number pad 1-6) to select slot of hatch and modify hatch label in fusion
        private void FormShortcuts_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D1:
                case Keys.NumPad1:
                    hatchNumber = 1;
                    break;
                case Keys.D2:
                case Keys.NumPad2:
                    hatchNumber = 2;
                    break;
                case Keys.D3:
                case Keys.NumPad3:
                    hatchNumber = 3;
                    break;
                case Keys.D4:
                case Keys.NumPad4:
                    hatchNumber = 4;
                    break;
                case Keys.D5:
                case Keys.NumPad5:
                    hatchNumber = 5;
                    break;
                case Keys.D6:
                case Keys.NumPad6:
                    hatchNumber = 6;
                    break;
                case Keys.C:
                    isSwitch = !isSwitch;
                    switchType();
                    break;
                default: return;
            }

            if(!isMF) return;
            foreach (Control label in groupBox_hatch.Controls)
            {
                if(label is Label)
                {
                    if (label == label_grey) continue;
                    else if(hatchNumber!=0) label.Text = label.Text.Remove(label.Text.Length -1, 1) + hatchNumber;
                }
            }
        }

        private void button_bomb_MouseWheel(object sender, MouseEventArgs e)
        {
            if (isSwitch)
            {
                if(e.Delta > 0)
                {//scroll up, number -, when less than 1 set 4 (max value of bomb chain) -> cycle rolling
                    vNumber = (byte)(--vNumber < 1? 4 : vNumber);
                }
                else if(e.Delta < 0)
                {//scroll down, number +
                    vNumber = (byte)(++vNumber > 4 ? 1 : vNumber);
                }
                //change label
                label_bomb.Text = Resources.formShortcut_VBombChain_Text + vNumber.ToString();
            }
        }

        private void button_bomb_never_MouseWheel(object sender, MouseEventArgs e)
        {
            if (isSwitch)
            {
                if (e.Delta > 0)
                {//scroll up, number -
                    hNumber = (byte)(--hNumber < 1 ? 4 : hNumber);
                }
                else if (e.Delta < 0)
                {//scroll down, number +
                    hNumber = (byte)(++hNumber > 4 ? 1 : hNumber);
                }
                label_bomb_never.Text = Resources.formShortcuts_HBombChain_Text + hNumber.ToString();
            }
        }

        private void switchType()
        {
            if (!isSwitch)
            {
                var resource = new System.Resources.ResourceManager("mage.FormShortcuts", System.Reflection.Assembly.GetExecutingAssembly());
                label_bomb.Text = resource.GetString("label_bomb.Text");
                label_bomb_never.Text = resource.GetString("label_bomb_never.Text");

                groupBox_slopes.Text = resource.GetString("groupBox_slopes.Text");
                label_slope_steep.Text = resource.GetString("label_slope_steep.Text");
                label_slope_slight.Text = resource.GetString("label_slope_slight.Text");
                button_slope45_pos.Image = Resources.shortcut_slope45_pos;
                button_slope45_neg.Image = Resources.shortcut_slope45_neg;
                button_slope27_Lpos.Image = Resources.shortcut_slope27_Lpos;
                button_slope27_Upos.Image = Resources.shortcut_slope27_Upos;
                button_slope27_Lneg.Image = Resources.shortcut_slope27_Lneg;
                button_slope27_Uneg.Image = Resources.shortcut_slope27_Uneg;

            }
            else
            {
                label_bomb.Text = Resources.formShortcut_VBombChain_Text + vNumber.ToString();
                label_bomb_never.Text = Resources.formShortcuts_HBombChain_Text + hNumber.ToString();

                groupBox_slopes.Text = Resources.formShortcuts_groupBox_slopes_Text;
                label_slope_steep.Text = Resources.formShortcuts_slope_steep_Text;
                label_slope_slight.Text = Resources.formShortcuts_slope_slight_Text;
                button_slope45_pos.Image = Resources.shorcut_ceiling45_pos;
                button_slope45_neg.Image = Resources.shorcut_ceiling45_neg;
                button_slope27_Lpos.Image = Resources.shorcut_ceiling27_Upos;
                button_slope27_Upos.Image = Resources.shorcut_ceiling27_Lpos;
                button_slope27_Lneg.Image = Resources.shorcut_ceiling27_Uneg;
                button_slope27_Uneg.Image = Resources.shorcut_ceiling27_Lneg;
            }
        }
    }
}
