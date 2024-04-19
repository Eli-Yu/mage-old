namespace mage
{
    partial class FormText
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormText));
            this.comboBox_language = new System.Windows.Forms.ComboBox();
            this.label_language = new System.Windows.Forms.Label();
            this.label_number = new System.Windows.Forms.Label();
            this.comboBox_number = new System.Windows.Forms.ComboBox();
            this.pictureBox_text = new System.Windows.Forms.PictureBox();
            this.checkBox_newLine = new System.Windows.Forms.CheckBox();
            this.checkBox_wordWrap = new System.Windows.Forms.CheckBox();
            this.label_text = new System.Windows.Forms.Label();
            this.comboBox_text = new System.Windows.Forms.ComboBox();
            this.textBox_offsetVal = new System.Windows.Forms.TextBox();
            this.label_offset = new System.Windows.Forms.Label();
            this.panel_gfx = new System.Windows.Forms.Panel();
            this.groupBox_options = new System.Windows.Forms.GroupBox();
            this.label_charPos = new System.Windows.Forms.Label();
            this.label_pos = new System.Windows.Forms.Label();
            this.button_close = new System.Windows.Forms.Button();
            this.button_apply = new System.Windows.Forms.Button();
            this.groupBox_preview = new System.Windows.Forms.GroupBox();
            this.button_editGfx = new System.Windows.Forms.Button();
            this.button_update = new System.Windows.Forms.Button();
            this.button_editPalette = new System.Windows.Forms.Button();
            this.pictureBox_palette = new System.Windows.Forms.PictureBox();
            this.textBox = new System.Windows.Forms.TextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel_changes = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox_Custom = new System.Windows.Forms.GroupBox();
            this.textBox_file = new System.Windows.Forms.TextBox();
            this.button_selectFile = new System.Windows.Forms.Button();
            this.numericUpDown_charWidth = new System.Windows.Forms.NumericUpDown();
            this.label_charWidth = new System.Windows.Forms.Label();
            this.checkBox_customChar = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_text)).BeginInit();
            this.panel_gfx.SuspendLayout();
            this.groupBox_options.SuspendLayout();
            this.groupBox_preview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_palette)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.groupBox_Custom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_charWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox_language
            // 
            resources.ApplyResources(this.comboBox_language, "comboBox_language");
            this.comboBox_language.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_language.FormattingEnabled = true;
            this.comboBox_language.Name = "comboBox_language";
            this.comboBox_language.SelectedIndexChanged += new System.EventHandler(this.comboBox_language_SelectedIndexChanged);
            // 
            // label_language
            // 
            resources.ApplyResources(this.label_language, "label_language");
            this.label_language.Name = "label_language";
            // 
            // label_number
            // 
            resources.ApplyResources(this.label_number, "label_number");
            this.label_number.Name = "label_number";
            // 
            // comboBox_number
            // 
            resources.ApplyResources(this.comboBox_number, "comboBox_number");
            this.comboBox_number.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_number.FormattingEnabled = true;
            this.comboBox_number.Name = "comboBox_number";
            this.comboBox_number.SelectedIndexChanged += new System.EventHandler(this.comboBox_number_SelectedIndexChanged);
            // 
            // pictureBox_text
            // 
            resources.ApplyResources(this.pictureBox_text, "pictureBox_text");
            this.pictureBox_text.Name = "pictureBox_text";
            this.pictureBox_text.TabStop = false;
            // 
            // checkBox_newLine
            // 
            resources.ApplyResources(this.checkBox_newLine, "checkBox_newLine");
            this.checkBox_newLine.Name = "checkBox_newLine";
            this.checkBox_newLine.UseVisualStyleBackColor = true;
            this.checkBox_newLine.CheckedChanged += new System.EventHandler(this.checkBox_newLine_CheckedChanged);
            // 
            // checkBox_wordWrap
            // 
            resources.ApplyResources(this.checkBox_wordWrap, "checkBox_wordWrap");
            this.checkBox_wordWrap.Checked = true;
            this.checkBox_wordWrap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_wordWrap.Name = "checkBox_wordWrap";
            this.checkBox_wordWrap.UseVisualStyleBackColor = true;
            this.checkBox_wordWrap.CheckedChanged += new System.EventHandler(this.checkBox_wordWrap_CheckedChanged);
            // 
            // label_text
            // 
            resources.ApplyResources(this.label_text, "label_text");
            this.label_text.Name = "label_text";
            // 
            // comboBox_text
            // 
            resources.ApplyResources(this.comboBox_text, "comboBox_text");
            this.comboBox_text.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_text.FormattingEnabled = true;
            this.comboBox_text.Name = "comboBox_text";
            this.comboBox_text.SelectedIndexChanged += new System.EventHandler(this.comboBox_text_SelectedIndexChanged);
            // 
            // textBox_offsetVal
            // 
            resources.ApplyResources(this.textBox_offsetVal, "textBox_offsetVal");
            this.textBox_offsetVal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_offsetVal.Name = "textBox_offsetVal";
            this.textBox_offsetVal.ReadOnly = true;
            this.textBox_offsetVal.TabStop = false;
            // 
            // label_offset
            // 
            resources.ApplyResources(this.label_offset, "label_offset");
            this.label_offset.Name = "label_offset";
            // 
            // panel_gfx
            // 
            resources.ApplyResources(this.panel_gfx, "panel_gfx");
            this.panel_gfx.Controls.Add(this.pictureBox_text);
            this.panel_gfx.Name = "panel_gfx";
            // 
            // groupBox_options
            // 
            resources.ApplyResources(this.groupBox_options, "groupBox_options");
            this.groupBox_options.Controls.Add(this.label_charPos);
            this.groupBox_options.Controls.Add(this.label_pos);
            this.groupBox_options.Controls.Add(this.button_close);
            this.groupBox_options.Controls.Add(this.button_apply);
            this.groupBox_options.Controls.Add(this.comboBox_text);
            this.groupBox_options.Controls.Add(this.comboBox_language);
            this.groupBox_options.Controls.Add(this.textBox_offsetVal);
            this.groupBox_options.Controls.Add(this.label_language);
            this.groupBox_options.Controls.Add(this.label_offset);
            this.groupBox_options.Controls.Add(this.comboBox_number);
            this.groupBox_options.Controls.Add(this.label_text);
            this.groupBox_options.Controls.Add(this.label_number);
            this.groupBox_options.Controls.Add(this.checkBox_newLine);
            this.groupBox_options.Controls.Add(this.checkBox_wordWrap);
            this.groupBox_options.Name = "groupBox_options";
            this.groupBox_options.TabStop = false;
            // 
            // label_charPos
            // 
            resources.ApplyResources(this.label_charPos, "label_charPos");
            this.label_charPos.Name = "label_charPos";
            // 
            // label_pos
            // 
            resources.ApplyResources(this.label_pos, "label_pos");
            this.label_pos.Name = "label_pos";
            // 
            // button_close
            // 
            resources.ApplyResources(this.button_close, "button_close");
            this.button_close.Name = "button_close";
            this.button_close.UseVisualStyleBackColor = true;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // button_apply
            // 
            resources.ApplyResources(this.button_apply, "button_apply");
            this.button_apply.Name = "button_apply";
            this.button_apply.UseVisualStyleBackColor = true;
            this.button_apply.Click += new System.EventHandler(this.button_apply_Click);
            // 
            // groupBox_preview
            // 
            resources.ApplyResources(this.groupBox_preview, "groupBox_preview");
            this.groupBox_preview.Controls.Add(this.button_editGfx);
            this.groupBox_preview.Controls.Add(this.button_update);
            this.groupBox_preview.Controls.Add(this.button_editPalette);
            this.groupBox_preview.Controls.Add(this.pictureBox_palette);
            this.groupBox_preview.Controls.Add(this.panel_gfx);
            this.groupBox_preview.Name = "groupBox_preview";
            this.groupBox_preview.TabStop = false;
            // 
            // button_editGfx
            // 
            resources.ApplyResources(this.button_editGfx, "button_editGfx");
            this.button_editGfx.Name = "button_editGfx";
            this.button_editGfx.UseVisualStyleBackColor = true;
            this.button_editGfx.Click += new System.EventHandler(this.button_editGfx_Click);
            // 
            // button_update
            // 
            resources.ApplyResources(this.button_update, "button_update");
            this.button_update.Name = "button_update";
            this.button_update.UseVisualStyleBackColor = true;
            this.button_update.Click += new System.EventHandler(this.button_update_Click);
            // 
            // button_editPalette
            // 
            resources.ApplyResources(this.button_editPalette, "button_editPalette");
            this.button_editPalette.Name = "button_editPalette";
            this.button_editPalette.UseVisualStyleBackColor = true;
            this.button_editPalette.Click += new System.EventHandler(this.button_editPalette_Click);
            // 
            // pictureBox_palette
            // 
            resources.ApplyResources(this.pictureBox_palette, "pictureBox_palette");
            this.pictureBox_palette.Name = "pictureBox_palette";
            this.pictureBox_palette.TabStop = false;
            // 
            // textBox
            // 
            resources.ApplyResources(this.textBox, "textBox");
            this.textBox.Name = "textBox";
            this.textBox.TabStop = false;
            this.textBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox_MouseClick);
            this.textBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            this.textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            // 
            // statusStrip
            // 
            resources.ApplyResources(this.statusStrip, "statusStrip");
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel_changes});
            this.statusStrip.Name = "statusStrip";
            // 
            // statusLabel_changes
            // 
            resources.ApplyResources(this.statusLabel_changes, "statusLabel_changes");
            this.statusLabel_changes.Name = "statusLabel_changes";
            // 
            // groupBox_Custom
            // 
            resources.ApplyResources(this.groupBox_Custom, "groupBox_Custom");
            this.groupBox_Custom.Controls.Add(this.textBox_file);
            this.groupBox_Custom.Controls.Add(this.button_selectFile);
            this.groupBox_Custom.Controls.Add(this.numericUpDown_charWidth);
            this.groupBox_Custom.Controls.Add(this.label_charWidth);
            this.groupBox_Custom.Controls.Add(this.checkBox_customChar);
            this.groupBox_Custom.Name = "groupBox_Custom";
            this.groupBox_Custom.TabStop = false;
            // 
            // textBox_file
            // 
            resources.ApplyResources(this.textBox_file, "textBox_file");
            this.textBox_file.AllowDrop = true;
            this.textBox_file.Name = "textBox_file";
            this.textBox_file.ReadOnly = true;
            this.textBox_file.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox_file_DragDrop);
            this.textBox_file.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBox_file_DragEnter);
            // 
            // button_selectFile
            // 
            resources.ApplyResources(this.button_selectFile, "button_selectFile");
            this.button_selectFile.Name = "button_selectFile";
            this.button_selectFile.UseVisualStyleBackColor = true;
            this.button_selectFile.Click += new System.EventHandler(this.button_selectFile_Click);
            // 
            // numericUpDown_charWidth
            // 
            resources.ApplyResources(this.numericUpDown_charWidth, "numericUpDown_charWidth");
            this.numericUpDown_charWidth.Hexadecimal = true;
            this.numericUpDown_charWidth.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numericUpDown_charWidth.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_charWidth.Name = "numericUpDown_charWidth";
            this.numericUpDown_charWidth.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_charWidth.ValueChanged += new System.EventHandler(this.numericUpDown_charWidth_ValueChanged);
            // 
            // label_charWidth
            // 
            resources.ApplyResources(this.label_charWidth, "label_charWidth");
            this.label_charWidth.Name = "label_charWidth";
            // 
            // checkBox_customChar
            // 
            resources.ApplyResources(this.checkBox_customChar, "checkBox_customChar");
            this.checkBox_customChar.Name = "checkBox_customChar";
            this.checkBox_customChar.UseVisualStyleBackColor = true;
            this.checkBox_customChar.CheckedChanged += new System.EventHandler(this.checkBox_customChar_CheckedChanged);
            // 
            // FormText
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox_Custom);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.groupBox_preview);
            this.Controls.Add(this.groupBox_options);
            this.Controls.Add(this.textBox);
            this.Name = "FormText";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_text)).EndInit();
            this.panel_gfx.ResumeLayout(false);
            this.groupBox_options.ResumeLayout(false);
            this.groupBox_options.PerformLayout();
            this.groupBox_preview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_palette)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.groupBox_Custom.ResumeLayout(false);
            this.groupBox_Custom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_charWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_language;
        private System.Windows.Forms.Label label_language;
        private System.Windows.Forms.Label label_number;
        private System.Windows.Forms.ComboBox comboBox_number;
        private System.Windows.Forms.PictureBox pictureBox_text;
        private System.Windows.Forms.CheckBox checkBox_newLine;
        private System.Windows.Forms.CheckBox checkBox_wordWrap;
        private System.Windows.Forms.Label label_text;
        private System.Windows.Forms.ComboBox comboBox_text;
        private System.Windows.Forms.TextBox textBox_offsetVal;
        private System.Windows.Forms.Label label_offset;
        private System.Windows.Forms.Panel panel_gfx;
        private System.Windows.Forms.GroupBox groupBox_options;
        private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.Button button_apply;
        private System.Windows.Forms.GroupBox groupBox_preview;
        private System.Windows.Forms.Button button_update;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Label label_pos;
        private System.Windows.Forms.Label label_charPos;
        private System.Windows.Forms.Button button_editPalette;
        private System.Windows.Forms.PictureBox pictureBox_palette;
        private System.Windows.Forms.Button button_editGfx;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel_changes;
        private System.Windows.Forms.GroupBox groupBox_Custom;
        private System.Windows.Forms.Label label_charWidth;
        private System.Windows.Forms.CheckBox checkBox_customChar;
        private System.Windows.Forms.TextBox textBox_file;
        private System.Windows.Forms.Button button_selectFile;
        private System.Windows.Forms.NumericUpDown numericUpDown_charWidth;
    }
}