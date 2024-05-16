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
            this.button_apply = new System.Windows.Forms.Button();
            this.button_close = new System.Windows.Forms.Button();
            this.button_update = new System.Windows.Forms.Button();
            this.label_line = new System.Windows.Forms.Label();
            this.gfxView_preview = new mage.GfxView();
            this.label_pos = new System.Windows.Forms.Label();
            this.panel_preview.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox.Location = new System.Drawing.Point(12, 38);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox.Size = new System.Drawing.Size(280, 296);
            this.textBox.TabIndex = 3;
            this.textBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox_MouseClick);
            this.textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            // 
            // panel_preview
            // 
            this.panel_preview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel_preview.AutoScroll = true;
            this.panel_preview.Controls.Add(this.gfxView_preview);
            this.panel_preview.Location = new System.Drawing.Point(298, 38);
            this.panel_preview.Name = "panel_preview";
            this.panel_preview.Size = new System.Drawing.Size(497, 295);
            this.panel_preview.TabIndex = 5;
            // 
            // button_apply
            // 
            this.button_apply.Location = new System.Drawing.Point(12, 11);
            this.button_apply.Name = "button_apply";
            this.button_apply.Size = new System.Drawing.Size(75, 21);
            this.button_apply.TabIndex = 0;
            this.button_apply.Text = "Apply";
            this.button_apply.UseVisualStyleBackColor = true;
            this.button_apply.Click += new System.EventHandler(this.button_apply_Click);
            // 
            // button_close
            // 
            this.button_close.Location = new System.Drawing.Point(93, 11);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(75, 21);
            this.button_close.TabIndex = 1;
            this.button_close.Text = "Close";
            this.button_close.UseVisualStyleBackColor = true;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // button_update
            // 
            this.button_update.Location = new System.Drawing.Point(308, 11);
            this.button_update.Name = "button_update";
            this.button_update.Size = new System.Drawing.Size(75, 21);
            this.button_update.TabIndex = 2;
            this.button_update.Text = "Update";
            this.button_update.UseVisualStyleBackColor = true;
            this.button_update.Click += new System.EventHandler(this.button_update_Click);
            // 
            // label_line
            // 
            this.label_line.AutoSize = true;
            this.label_line.Location = new System.Drawing.Point(202, 16);
            this.label_line.Name = "label_line";
            this.label_line.Size = new System.Drawing.Size(41, 12);
            this.label_line.TabIndex = 6;
            this.label_line.Text = "Line: ";
            // 
            // gfxView_preview
            // 
            this.gfxView_preview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gfxView_preview.Location = new System.Drawing.Point(0, 0);
            this.gfxView_preview.Name = "gfxView_preview";
            this.gfxView_preview.Size = new System.Drawing.Size(480, 295);
            this.gfxView_preview.TabIndex = 4;
            this.gfxView_preview.TabStop = false;
            // 
            // label_pos
            // 
            this.label_pos.AutoSize = true;
            this.label_pos.Location = new System.Drawing.Point(236, 16);
            this.label_pos.Name = "label_pos";
            this.label_pos.Size = new System.Drawing.Size(11, 12);
            this.label_pos.TabIndex = 7;
            this.label_pos.Text = "1";
            // 
            // FormCredits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 344);
            this.Controls.Add(this.label_pos);
            this.Controls.Add(this.label_line);
            this.Controls.Add(this.button_update);
            this.Controls.Add(this.button_close);
            this.Controls.Add(this.button_apply);
            this.Controls.Add(this.panel_preview);
            this.Controls.Add(this.textBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(823, 383);
            this.Name = "FormCredits";
            this.Text = "Credits Editor";
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
    }
}