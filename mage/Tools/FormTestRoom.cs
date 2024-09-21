using System;
using System.Windows.Forms;

namespace mage
{
    public partial class FormTestRoom : Form
    {
        // fields
        private FormMain main;

        // constructor
        public FormTestRoom(FormMain main)
        {
            InitializeComponent();
            InitStatus();
            this.main = main;
        }

        private void InitStatus()
        {
            //init numericUpDown
            numericUpDown_energy.Hexadecimal = numericUpDown_energyMax.Hexadecimal = numericUpDown_missile.Hexadecimal = numericUpDown_missileMax.Hexadecimal
                = numericUpDown_power.Hexadecimal = numericUpDown_powerMax.Hexadecimal = numericUpDown_super.Hexadecimal = numericUpDown_superMax.Hexadecimal = Hex.ToHex;
            if(Version.IsMF)
            {
                numericUpDown_energy.Maximum = numericUpDown_energyMax.Maximum = 2099;
                numericUpDown_missile.Maximum = numericUpDown_missileMax.Maximum = byte.MaxValue;
                numericUpDown_power.Maximum = numericUpDown_powerMax.Maximum = byte.MaxValue;
                numericUpDown_super.Enabled = numericUpDown_superMax.Enabled = false;

                //label_event.Visible = comboBox_event.Visible = true;
                //comboBox_event.SelectedIndex = Test.Status.events;
            }
            else
            {
                numericUpDown_energy.Maximum = numericUpDown_energyMax.Maximum = ushort.MaxValue;
                numericUpDown_missile.Maximum = numericUpDown_missileMax.Maximum = ushort.MaxValue;
                numericUpDown_power.Maximum = numericUpDown_powerMax.Maximum = byte.MaxValue;
                numericUpDown_super.Maximum = numericUpDown_superMax.Maximum = byte.MaxValue;
            }
            numericUpDown_energy.Value = Test.Status.energy;
            numericUpDown_energyMax.Value = Test.Status.energyMax;
            numericUpDown_missile.Value = Test.Status.missile;
            numericUpDown_missileMax.Value = Test.Status.missileMax;
            numericUpDown_power.Value = Test.Status.power;
            numericUpDown_powerMax.Value = Test.Status.powerMax;
            numericUpDown_super.Value = Test.Status.super;
            numericUpDown_superMax.Value = Test.Status.superMax;

            comboBox_language.Items.AddRange(Version.Languages);
            comboBox_language.SelectedIndex = Test.Status.language;
            comboBox_difficulty.SelectedIndex = Test.Status.difficulty;
            
            if (Version.IsMF)
            {
                checkedListBox_beamBomb.Enabled = false;
                comboBox_suit.Enabled = false;
                for (int i = 0; i < checkedListBox_fusionBeam.Items.Count; i++)
                {
                    //checkedListBox_fusionBeam.SetItemChecked(i, Test.Status.fusionBeam.HasFlag((Test.FusionBeam)Math.Pow(i, 2)));
                    checkedListBox_fusionBeam.SetItemChecked(i, Test.Status.fusionBeam.HasFlag((Test.FusionBeam)(1 << i)));
                }
                for (int i = 0; i < checkedListBox_missileBomb.Items.Count; i++)
                {
                    checkedListBox_missileBomb.SetItemChecked(i, Test.Status.missileBomb.HasFlag((Test.MissileBomb)(1 << i)));
                }
            }
            else
            {
                checkedListBox_fusionBeam.Enabled = false;
                checkedListBox_missileBomb.Enabled = false;
                for (int i = 0; i < checkedListBox_beamBomb.Items.Count; i++)
                {
                    if(i == checkedListBox_beamBomb.Items.Count - 1) checkedListBox_beamBomb.SetItemChecked(i, Test.Status.beamBomb.HasFlag(Test.BeamBomb.Bomb));
                    else checkedListBox_beamBomb.SetItemChecked(i, Test.Status.beamBomb.HasFlag((Test.BeamBomb)(1 << i)));
                }
                comboBox_suit.SelectedIndex = Test.Status.suit;
            }
            for (int i = 0; i < checkedListBox_suitMisc.Items.Count; i++)
            {
                checkedListBox_suitMisc.SetItemChecked(i, Test.Status.suitMisc.HasFlag((Test.SuitMisc)(1 << i)));
            } 
        }

        private void UpdateStatus()
        {
            Test.Status.energy = (ushort)numericUpDown_energy.Value;
            Test.Status.energyMax = (ushort)numericUpDown_energyMax.Value;
            Test.Status.missile = (ushort)numericUpDown_missile.Value;
            Test.Status.missileMax = (ushort)numericUpDown_missileMax.Value;
            Test.Status.power = (byte)numericUpDown_power.Value;
            Test.Status.powerMax = (byte)numericUpDown_powerMax.Value;
            if (!Version.IsMF)
            {
                Test.Status.super = (byte)numericUpDown_super.Value;
                Test.Status.superMax = (byte)numericUpDown_superMax.Value;
            }

            Test.Status.language = (byte)comboBox_language.SelectedIndex;
            Test.Status.difficulty = (byte)comboBox_difficulty.SelectedIndex;

            if (Version.IsMF)
            {
                //beam
                Test.Status.fusionBeam = Test.FusionBeam.None;
                for (int i = 0; i < checkedListBox_fusionBeam.Items.Count; i++)
                {
                    //if (checkedListBox_fusionBeam.GetItemChecked(i) == true) fusionBeam |= (Test.FusionBeam)Math.Pow(i, 2);
                    if (checkedListBox_fusionBeam.GetItemChecked(i) == true) Test.Status.fusionBeam |= (Test.FusionBeam)(1 << i);
                }
                //missile and bombs
                Test.Status.missileBomb = Test.MissileBomb.None;
                for (int i = 0; i < checkedListBox_missileBomb.Items.Count; i++)
                {
                    //if(checkedListBox_missileBomb.GetItemChecked(i)) missileBomb |= (Test.MissileBomb)Math.Pow(i, 2);
                    if(checkedListBox_missileBomb.GetItemChecked(i)) Test.Status.missileBomb |= (Test.MissileBomb)(1 << i);
                }
                Test.Status.events = (byte)comboBox_event.SelectedIndex;
            }
            else
            {
                //beam and bomb
                Test.Status.beamBomb = Test.BeamBomb.None;
                for(int i = 0;i<checkedListBox_beamBomb.Items.Count;i++)
                {
                    //if(checkedListBox_beamBomb.GetItemChecked(i)) beamBomb |= (Test.BeamBomb)Math.Pow(i, 2);
                    if (checkedListBox_beamBomb.GetItemChecked(i))
                    {
                        if (i == checkedListBox_beamBomb.Items.Count - 1)
                            Test.Status.beamBomb |= Test.BeamBomb.Bomb;
                        else
                            Test.Status.beamBomb |= (Test.BeamBomb)(1 << i);
                    }
                }
                //suit type
                Test.Status.suit = (byte)comboBox_suit.SelectedIndex;
            }
            //suit and misc
            Test.Status.suitMisc = Test.SuitMisc.None;
            for (int i = 0; i < checkedListBox_suitMisc.Items.Count; i++)
            {
                //if (checkedListBox_suitMisc.GetItemChecked(i)) suitMisc |= (Test.SuitMisc)Math.Pow(i, 2);
                if (checkedListBox_suitMisc.GetItemChecked(i)) Test.Status.suitMisc |= (Test.SuitMisc)(1 << i);
            }
        }

        private void button_go_Click(object sender, EventArgs e)
        {
            try
            {
                bool debug = checkBox_debug.Checked;
                byte xPos = Hex.ToByte(textBox_xPos.Text);
                byte yPos = Hex.ToByte(textBox_yPos.Text);
                
                //use new status
                UpdateStatus();
                Test.Room(main, debug, xPos, yPos);

                Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("One of the values entered was not valid.\n\n" + ex.Message,
                //    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(Properties.Resources.form_OneValueNotValidErrorText + ex.Message,
                    Properties.Resources.form_ErrorMessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
