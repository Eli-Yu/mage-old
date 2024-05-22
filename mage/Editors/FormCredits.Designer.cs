namespace mage
{
    partial class FormCredits
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCredits));
            this.textBox = new System.Windows.Forms.TextBox();
            this.panel_preview = new System.Windows.Forms.Panel();
            this.gfxView_preview = new mage.GfxView();
            this.button_apply = new System.Windows.Forms.Button();
            this.button_close = new System.Windows.Forms.Button();
            this.button_update = new System.Windows.Forms.Button();
            this.label_line = new System.Windows.Forms.Label();
            this.label_pos = new System.Windows.Forms.Label();
            this.button_help = new System.Windows.Forms.Button();
            this.button_test = new System.Windows.Forms.Button();
            this.panel_preview.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox
            // 
            resources.ApplyResources(this.textBox, "textBox");
            this.textBox.Name = "textBox";
            this.textBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox_MouseClick);
            this.textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            // 
            // panel_preview
            // 
            resources.ApplyResources(this.panel_preview, "panel_preview");
            this.panel_preview.Controls.Add(this.gfxView_preview);
            this.panel_preview.Name = "panel_preview";
            // 
            // gfxView_preview
            // 
            resources.ApplyResources(this.gfxView_preview, "gfxView_preview");
            this.gfxView_preview.Name = "gfxView_preview";
            this.gfxView_preview.TabStop = false;
            // 
            // button_apply
            // 
            resources.ApplyResources(this.button_apply, "button_apply");
            this.button_apply.Name = "button_apply";
            this.button_apply.UseVisualStyleBackColor = true;
            this.button_apply.Click += new System.EventHandler(this.button_apply_Click);
            // 
            // button_close
            // 
            resources.ApplyResources(this.button_close, "button_close");
            this.button_close.Name = "button_close";
            this.button_close.UseVisualStyleBackColor = true;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // button_update
            // 
            resources.ApplyResources(this.button_update, "button_update");
            this.button_update.Name = "button_update";
            this.button_update.UseVisualStyleBackColor = true;
            this.button_update.Click += new System.EventHandler(this.button_update_Click);
            // 
            // label_line
            // 
            resources.ApplyResources(this.label_line, "label_line");
            this.label_line.Name = "label_line";
            // 
            // label_pos
            // 
            resources.ApplyResources(this.label_pos, "label_pos");
            this.label_pos.Name = "label_pos";
            // 
            // button_help
            // 
            resources.ApplyResources(this.button_help, "button_help");
            this.button_help.Name = "button_help";
            this.button_help.UseVisualStyleBackColor = true;
            this.button_help.Click += new System.EventHandler(this.button_help_Click);
            // 
            // button_test
            // 
            resources.ApplyResources(this.button_test, "button_test");
            this.button_test.Name = "button_test";
            this.button_test.UseVisualStyleBackColor = true;
            this.button_test.Click += new System.EventHandler(this.button_test_Click);
            // 
            // FormCredits
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_test);
            this.Controls.Add(this.button_help);
            this.Controls.Add(this.label_pos);
            this.Controls.Add(this.label_line);
            this.Controls.Add(this.button_update);
            this.Controls.Add(this.button_close);
            this.Controls.Add(this.button_apply);
            this.Controls.Add(this.panel_preview);
            this.Controls.Add(this.textBox);
            this.Name = "FormCredits";
            this.panel_preview.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox;
        private GfxView gfxView_preview;
        private System.Windows.Forms.Panel panel_preview;
        private System.Windows.Forms.Button button_apply;
        private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.Button button_update;
        private System.Windows.Forms.Label label_line;
        private System.Windows.Forms.Label label_pos;
        private System.Windows.Forms.Button button_help;
        private System.Windows.Forms.Button button_test;
    }
}