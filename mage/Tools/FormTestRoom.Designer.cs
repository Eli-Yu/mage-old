namespace mage
{
    partial class FormTestRoom
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTestRoom));
            this.button_go = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.checkBox_debug = new System.Windows.Forms.CheckBox();
            this.label_xPos = new System.Windows.Forms.Label();
            this.label_yPos = new System.Windows.Forms.Label();
            this.textBox_xPos = new System.Windows.Forms.TextBox();
            this.textBox_yPos = new System.Windows.Forms.TextBox();
            this.groupBox_equipment = new System.Windows.Forms.GroupBox();
            this.label_suitType = new System.Windows.Forms.Label();
            this.comboBox_suit = new System.Windows.Forms.ComboBox();
            this.checkedListBox_beamBomb = new System.Windows.Forms.CheckedListBox();
            this.checkedListBox_missileBomb = new System.Windows.Forms.CheckedListBox();
            this.checkedListBox_suitMisc = new System.Windows.Forms.CheckedListBox();
            this.checkedListBox_fusionBeam = new System.Windows.Forms.CheckedListBox();
            this.groupBox_hud = new System.Windows.Forms.GroupBox();
            this.numericUpDown_energyMax = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_energy = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_missileMax = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_missile = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_powerMax = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_power = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_superMax = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_super = new System.Windows.Forms.NumericUpDown();
            this.label_power = new System.Windows.Forms.Label();
            this.label_super = new System.Windows.Forms.Label();
            this.label_missile = new System.Windows.Forms.Label();
            this.label_energy = new System.Windows.Forms.Label();
            this.groupBox_misc = new System.Windows.Forms.GroupBox();
            this.comboBox_difficulty = new System.Windows.Forms.ComboBox();
            this.label_difficulty = new System.Windows.Forms.Label();
            this.comboBox_language = new System.Windows.Forms.ComboBox();
            this.label_language = new System.Windows.Forms.Label();
            this.label_event = new System.Windows.Forms.Label();
            this.comboBox_event = new System.Windows.Forms.ComboBox();
            this.groupBox_equipment.SuspendLayout();
            this.groupBox_hud.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_energyMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_energy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_missileMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_missile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_powerMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_power)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_superMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_super)).BeginInit();
            this.groupBox_misc.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_go
            // 
            resources.ApplyResources(this.button_go, "button_go");
            this.button_go.Name = "button_go";
            this.button_go.UseVisualStyleBackColor = true;
            this.button_go.Click += new System.EventHandler(this.button_go_Click);
            // 
            // button_cancel
            // 
            resources.ApplyResources(this.button_cancel, "button_cancel");
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // checkBox_debug
            // 
            resources.ApplyResources(this.checkBox_debug, "checkBox_debug");
            this.checkBox_debug.Checked = true;
            this.checkBox_debug.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_debug.Name = "checkBox_debug";
            this.checkBox_debug.UseVisualStyleBackColor = true;
            // 
            // label_xPos
            // 
            resources.ApplyResources(this.label_xPos, "label_xPos");
            this.label_xPos.Name = "label_xPos";
            // 
            // label_yPos
            // 
            resources.ApplyResources(this.label_yPos, "label_yPos");
            this.label_yPos.Name = "label_yPos";
            // 
            // textBox_xPos
            // 
            resources.ApplyResources(this.textBox_xPos, "textBox_xPos");
            this.textBox_xPos.Name = "textBox_xPos";
            // 
            // textBox_yPos
            // 
            resources.ApplyResources(this.textBox_yPos, "textBox_yPos");
            this.textBox_yPos.Name = "textBox_yPos";
            // 
            // groupBox_equipment
            // 
            resources.ApplyResources(this.groupBox_equipment, "groupBox_equipment");
            this.groupBox_equipment.Controls.Add(this.label_suitType);
            this.groupBox_equipment.Controls.Add(this.comboBox_suit);
            this.groupBox_equipment.Controls.Add(this.checkedListBox_beamBomb);
            this.groupBox_equipment.Controls.Add(this.checkedListBox_missileBomb);
            this.groupBox_equipment.Controls.Add(this.checkedListBox_suitMisc);
            this.groupBox_equipment.Controls.Add(this.checkedListBox_fusionBeam);
            this.groupBox_equipment.Name = "groupBox_equipment";
            this.groupBox_equipment.TabStop = false;
            // 
            // label_suitType
            // 
            resources.ApplyResources(this.label_suitType, "label_suitType");
            this.label_suitType.Name = "label_suitType";
            // 
            // comboBox_suit
            // 
            resources.ApplyResources(this.comboBox_suit, "comboBox_suit");
            this.comboBox_suit.DropDownWidth = 100;
            this.comboBox_suit.FormattingEnabled = true;
            this.comboBox_suit.Items.AddRange(new object[] {
            resources.GetString("comboBox_suit.Items"),
            resources.GetString("comboBox_suit.Items1"),
            resources.GetString("comboBox_suit.Items2")});
            this.comboBox_suit.Name = "comboBox_suit";
            // 
            // checkedListBox_beamBomb
            // 
            resources.ApplyResources(this.checkedListBox_beamBomb, "checkedListBox_beamBomb");
            this.checkedListBox_beamBomb.CheckOnClick = true;
            this.checkedListBox_beamBomb.FormattingEnabled = true;
            this.checkedListBox_beamBomb.Items.AddRange(new object[] {
            resources.GetString("checkedListBox_beamBomb.Items"),
            resources.GetString("checkedListBox_beamBomb.Items1"),
            resources.GetString("checkedListBox_beamBomb.Items2"),
            resources.GetString("checkedListBox_beamBomb.Items3"),
            resources.GetString("checkedListBox_beamBomb.Items4"),
            resources.GetString("checkedListBox_beamBomb.Items5")});
            this.checkedListBox_beamBomb.Name = "checkedListBox_beamBomb";
            // 
            // checkedListBox_missileBomb
            // 
            resources.ApplyResources(this.checkedListBox_missileBomb, "checkedListBox_missileBomb");
            this.checkedListBox_missileBomb.CheckOnClick = true;
            this.checkedListBox_missileBomb.FormattingEnabled = true;
            this.checkedListBox_missileBomb.Items.AddRange(new object[] {
            resources.GetString("checkedListBox_missileBomb.Items"),
            resources.GetString("checkedListBox_missileBomb.Items1"),
            resources.GetString("checkedListBox_missileBomb.Items2"),
            resources.GetString("checkedListBox_missileBomb.Items3"),
            resources.GetString("checkedListBox_missileBomb.Items4"),
            resources.GetString("checkedListBox_missileBomb.Items5")});
            this.checkedListBox_missileBomb.Name = "checkedListBox_missileBomb";
            // 
            // checkedListBox_suitMisc
            // 
            resources.ApplyResources(this.checkedListBox_suitMisc, "checkedListBox_suitMisc");
            this.checkedListBox_suitMisc.CheckOnClick = true;
            this.checkedListBox_suitMisc.FormattingEnabled = true;
            this.checkedListBox_suitMisc.Items.AddRange(new object[] {
            resources.GetString("checkedListBox_suitMisc.Items"),
            resources.GetString("checkedListBox_suitMisc.Items1"),
            resources.GetString("checkedListBox_suitMisc.Items2"),
            resources.GetString("checkedListBox_suitMisc.Items3"),
            resources.GetString("checkedListBox_suitMisc.Items4"),
            resources.GetString("checkedListBox_suitMisc.Items5"),
            resources.GetString("checkedListBox_suitMisc.Items6"),
            resources.GetString("checkedListBox_suitMisc.Items7")});
            this.checkedListBox_suitMisc.Name = "checkedListBox_suitMisc";
            // 
            // checkedListBox_fusionBeam
            // 
            resources.ApplyResources(this.checkedListBox_fusionBeam, "checkedListBox_fusionBeam");
            this.checkedListBox_fusionBeam.CheckOnClick = true;
            this.checkedListBox_fusionBeam.FormattingEnabled = true;
            this.checkedListBox_fusionBeam.Items.AddRange(new object[] {
            resources.GetString("checkedListBox_fusionBeam.Items"),
            resources.GetString("checkedListBox_fusionBeam.Items1"),
            resources.GetString("checkedListBox_fusionBeam.Items2"),
            resources.GetString("checkedListBox_fusionBeam.Items3"),
            resources.GetString("checkedListBox_fusionBeam.Items4")});
            this.checkedListBox_fusionBeam.Name = "checkedListBox_fusionBeam";
            // 
            // groupBox_hud
            // 
            resources.ApplyResources(this.groupBox_hud, "groupBox_hud");
            this.groupBox_hud.Controls.Add(this.numericUpDown_energyMax);
            this.groupBox_hud.Controls.Add(this.numericUpDown_energy);
            this.groupBox_hud.Controls.Add(this.numericUpDown_missileMax);
            this.groupBox_hud.Controls.Add(this.numericUpDown_missile);
            this.groupBox_hud.Controls.Add(this.numericUpDown_powerMax);
            this.groupBox_hud.Controls.Add(this.numericUpDown_power);
            this.groupBox_hud.Controls.Add(this.numericUpDown_superMax);
            this.groupBox_hud.Controls.Add(this.numericUpDown_super);
            this.groupBox_hud.Controls.Add(this.label_power);
            this.groupBox_hud.Controls.Add(this.label_super);
            this.groupBox_hud.Controls.Add(this.label_missile);
            this.groupBox_hud.Controls.Add(this.label_energy);
            this.groupBox_hud.Name = "groupBox_hud";
            this.groupBox_hud.TabStop = false;
            // 
            // numericUpDown_energyMax
            // 
            resources.ApplyResources(this.numericUpDown_energyMax, "numericUpDown_energyMax");
            this.numericUpDown_energyMax.Name = "numericUpDown_energyMax";
            // 
            // numericUpDown_energy
            // 
            resources.ApplyResources(this.numericUpDown_energy, "numericUpDown_energy");
            this.numericUpDown_energy.Name = "numericUpDown_energy";
            // 
            // numericUpDown_missileMax
            // 
            resources.ApplyResources(this.numericUpDown_missileMax, "numericUpDown_missileMax");
            this.numericUpDown_missileMax.Name = "numericUpDown_missileMax";
            // 
            // numericUpDown_missile
            // 
            resources.ApplyResources(this.numericUpDown_missile, "numericUpDown_missile");
            this.numericUpDown_missile.Name = "numericUpDown_missile";
            // 
            // numericUpDown_powerMax
            // 
            resources.ApplyResources(this.numericUpDown_powerMax, "numericUpDown_powerMax");
            this.numericUpDown_powerMax.Name = "numericUpDown_powerMax";
            // 
            // numericUpDown_power
            // 
            resources.ApplyResources(this.numericUpDown_power, "numericUpDown_power");
            this.numericUpDown_power.Name = "numericUpDown_power";
            // 
            // numericUpDown_superMax
            // 
            resources.ApplyResources(this.numericUpDown_superMax, "numericUpDown_superMax");
            this.numericUpDown_superMax.Name = "numericUpDown_superMax";
            // 
            // numericUpDown_super
            // 
            resources.ApplyResources(this.numericUpDown_super, "numericUpDown_super");
            this.numericUpDown_super.Name = "numericUpDown_super";
            // 
            // label_power
            // 
            resources.ApplyResources(this.label_power, "label_power");
            this.label_power.Name = "label_power";
            // 
            // label_super
            // 
            resources.ApplyResources(this.label_super, "label_super");
            this.label_super.Name = "label_super";
            // 
            // label_missile
            // 
            resources.ApplyResources(this.label_missile, "label_missile");
            this.label_missile.Name = "label_missile";
            // 
            // label_energy
            // 
            resources.ApplyResources(this.label_energy, "label_energy");
            this.label_energy.Name = "label_energy";
            // 
            // groupBox_misc
            // 
            resources.ApplyResources(this.groupBox_misc, "groupBox_misc");
            this.groupBox_misc.Controls.Add(this.comboBox_difficulty);
            this.groupBox_misc.Controls.Add(this.label_difficulty);
            this.groupBox_misc.Controls.Add(this.comboBox_language);
            this.groupBox_misc.Controls.Add(this.label_language);
            this.groupBox_misc.Name = "groupBox_misc";
            this.groupBox_misc.TabStop = false;
            // 
            // comboBox_difficulty
            // 
            resources.ApplyResources(this.comboBox_difficulty, "comboBox_difficulty");
            this.comboBox_difficulty.FormattingEnabled = true;
            this.comboBox_difficulty.Items.AddRange(new object[] {
            resources.GetString("comboBox_difficulty.Items"),
            resources.GetString("comboBox_difficulty.Items1"),
            resources.GetString("comboBox_difficulty.Items2")});
            this.comboBox_difficulty.Name = "comboBox_difficulty";
            // 
            // label_difficulty
            // 
            resources.ApplyResources(this.label_difficulty, "label_difficulty");
            this.label_difficulty.Name = "label_difficulty";
            // 
            // comboBox_language
            // 
            resources.ApplyResources(this.comboBox_language, "comboBox_language");
            this.comboBox_language.FormattingEnabled = true;
            this.comboBox_language.Name = "comboBox_language";
            // 
            // label_language
            // 
            resources.ApplyResources(this.label_language, "label_language");
            this.label_language.Name = "label_language";
            // 
            // label_event
            // 
            resources.ApplyResources(this.label_event, "label_event");
            this.label_event.Name = "label_event";
            // 
            // comboBox_event
            // 
            resources.ApplyResources(this.comboBox_event, "comboBox_event");
            this.comboBox_event.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_event.FormattingEnabled = true;
            this.comboBox_event.Name = "comboBox_event";
            // 
            // FormTestRoom
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBox_event);
            this.Controls.Add(this.label_event);
            this.Controls.Add(this.groupBox_misc);
            this.Controls.Add(this.groupBox_hud);
            this.Controls.Add(this.groupBox_equipment);
            this.Controls.Add(this.textBox_yPos);
            this.Controls.Add(this.textBox_xPos);
            this.Controls.Add(this.label_yPos);
            this.Controls.Add(this.label_xPos);
            this.Controls.Add(this.checkBox_debug);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_go);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormTestRoom";
            this.groupBox_equipment.ResumeLayout(false);
            this.groupBox_equipment.PerformLayout();
            this.groupBox_hud.ResumeLayout(false);
            this.groupBox_hud.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_energyMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_energy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_missileMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_missile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_powerMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_power)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_superMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_super)).EndInit();
            this.groupBox_misc.ResumeLayout(false);
            this.groupBox_misc.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_go;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.CheckBox checkBox_debug;
        private System.Windows.Forms.Label label_xPos;
        private System.Windows.Forms.Label label_yPos;
        private System.Windows.Forms.TextBox textBox_xPos;
        private System.Windows.Forms.TextBox textBox_yPos;
        private System.Windows.Forms.GroupBox groupBox_equipment;
        private System.Windows.Forms.GroupBox groupBox_hud;
        private System.Windows.Forms.Label label_super;
        private System.Windows.Forms.Label label_missile;
        private System.Windows.Forms.Label label_energy;
        private System.Windows.Forms.Label label_power;
        private System.Windows.Forms.NumericUpDown numericUpDown_energyMax;
        private System.Windows.Forms.NumericUpDown numericUpDown_energy;
        private System.Windows.Forms.NumericUpDown numericUpDown_missileMax;
        private System.Windows.Forms.NumericUpDown numericUpDown_missile;
        private System.Windows.Forms.NumericUpDown numericUpDown_powerMax;
        private System.Windows.Forms.NumericUpDown numericUpDown_power;
        private System.Windows.Forms.NumericUpDown numericUpDown_superMax;
        private System.Windows.Forms.NumericUpDown numericUpDown_super;
        private System.Windows.Forms.CheckedListBox checkedListBox_suitMisc;
        private System.Windows.Forms.CheckedListBox checkedListBox_fusionBeam;
        private System.Windows.Forms.CheckedListBox checkedListBox_missileBomb;
        private System.Windows.Forms.CheckedListBox checkedListBox_beamBomb;
        private System.Windows.Forms.Label label_suitType;
        private System.Windows.Forms.ComboBox comboBox_suit;
        private System.Windows.Forms.GroupBox groupBox_misc;
        private System.Windows.Forms.ComboBox comboBox_difficulty;
        private System.Windows.Forms.Label label_difficulty;
        private System.Windows.Forms.ComboBox comboBox_language;
        private System.Windows.Forms.Label label_language;
        private System.Windows.Forms.Label label_event;
        private System.Windows.Forms.ComboBox comboBox_event;
    }
}