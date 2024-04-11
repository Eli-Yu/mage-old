namespace mage
{
    partial class FormRoomOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRoomOptions));
            this.textBox_width = new System.Windows.Forms.TextBox();
            this.textBox_height = new System.Windows.Forms.TextBox();
            this.label_width = new System.Windows.Forms.Label();
            this.label_height = new System.Windows.Forms.Label();
            this.button_resize = new System.Windows.Forms.Button();
            this.button_clearBG = new System.Windows.Forms.Button();
            this.checkBox_bg0 = new System.Windows.Forms.CheckBox();
            this.checkBox_bg1 = new System.Windows.Forms.CheckBox();
            this.checkBox_bg2 = new System.Windows.Forms.CheckBox();
            this.checkBox_clip = new System.Windows.Forms.CheckBox();
            this.groupBox_resize = new System.Windows.Forms.GroupBox();
            this.textBox_screenY = new System.Windows.Forms.TextBox();
            this.textBox_screenX = new System.Windows.Forms.TextBox();
            this.label_blocks = new System.Windows.Forms.Label();
            this.label_screens = new System.Windows.Forms.Label();
            this.groupBox_clear = new System.Windows.Forms.GroupBox();
            this.checkBox_scrolls = new System.Windows.Forms.CheckBox();
            this.checkBox_doors = new System.Windows.Forms.CheckBox();
            this.checkBox_sprites = new System.Windows.Forms.CheckBox();
            this.button_close = new System.Windows.Forms.Button();
            this.groupBox_resize.SuspendLayout();
            this.groupBox_clear.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_width
            // 
            resources.ApplyResources(this.textBox_width, "textBox_width");
            this.textBox_width.Name = "textBox_width";
            this.textBox_width.TextChanged += new System.EventHandler(this.textBox_width_TextChanged);
            // 
            // textBox_height
            // 
            resources.ApplyResources(this.textBox_height, "textBox_height");
            this.textBox_height.Name = "textBox_height";
            this.textBox_height.TextChanged += new System.EventHandler(this.textBox_height_TextChanged);
            // 
            // label_width
            // 
            resources.ApplyResources(this.label_width, "label_width");
            this.label_width.Name = "label_width";
            // 
            // label_height
            // 
            resources.ApplyResources(this.label_height, "label_height");
            this.label_height.Name = "label_height";
            // 
            // button_resize
            // 
            resources.ApplyResources(this.button_resize, "button_resize");
            this.button_resize.Name = "button_resize";
            this.button_resize.UseVisualStyleBackColor = true;
            this.button_resize.Click += new System.EventHandler(this.button_resize_Click);
            // 
            // button_clearBG
            // 
            resources.ApplyResources(this.button_clearBG, "button_clearBG");
            this.button_clearBG.Name = "button_clearBG";
            this.button_clearBG.UseVisualStyleBackColor = true;
            this.button_clearBG.Click += new System.EventHandler(this.button_clearBG_Click);
            // 
            // checkBox_bg0
            // 
            resources.ApplyResources(this.checkBox_bg0, "checkBox_bg0");
            this.checkBox_bg0.Name = "checkBox_bg0";
            this.checkBox_bg0.UseVisualStyleBackColor = true;
            // 
            // checkBox_bg1
            // 
            resources.ApplyResources(this.checkBox_bg1, "checkBox_bg1");
            this.checkBox_bg1.Name = "checkBox_bg1";
            this.checkBox_bg1.UseVisualStyleBackColor = true;
            // 
            // checkBox_bg2
            // 
            resources.ApplyResources(this.checkBox_bg2, "checkBox_bg2");
            this.checkBox_bg2.Name = "checkBox_bg2";
            this.checkBox_bg2.UseVisualStyleBackColor = true;
            // 
            // checkBox_clip
            // 
            resources.ApplyResources(this.checkBox_clip, "checkBox_clip");
            this.checkBox_clip.Name = "checkBox_clip";
            this.checkBox_clip.UseVisualStyleBackColor = true;
            // 
            // groupBox_resize
            // 
            resources.ApplyResources(this.groupBox_resize, "groupBox_resize");
            this.groupBox_resize.Controls.Add(this.textBox_screenY);
            this.groupBox_resize.Controls.Add(this.textBox_screenX);
            this.groupBox_resize.Controls.Add(this.label_blocks);
            this.groupBox_resize.Controls.Add(this.label_screens);
            this.groupBox_resize.Controls.Add(this.label_width);
            this.groupBox_resize.Controls.Add(this.textBox_width);
            this.groupBox_resize.Controls.Add(this.textBox_height);
            this.groupBox_resize.Controls.Add(this.label_height);
            this.groupBox_resize.Controls.Add(this.button_resize);
            this.groupBox_resize.Name = "groupBox_resize";
            this.groupBox_resize.TabStop = false;
            // 
            // textBox_screenY
            // 
            resources.ApplyResources(this.textBox_screenY, "textBox_screenY");
            this.textBox_screenY.Name = "textBox_screenY";
            this.textBox_screenY.TextChanged += new System.EventHandler(this.textBox_screenY_TextChanged);
            // 
            // textBox_screenX
            // 
            resources.ApplyResources(this.textBox_screenX, "textBox_screenX");
            this.textBox_screenX.Name = "textBox_screenX";
            this.textBox_screenX.TextChanged += new System.EventHandler(this.textBox_screenX_TextChanged);
            // 
            // label_blocks
            // 
            resources.ApplyResources(this.label_blocks, "label_blocks");
            this.label_blocks.Name = "label_blocks";
            // 
            // label_screens
            // 
            resources.ApplyResources(this.label_screens, "label_screens");
            this.label_screens.Name = "label_screens";
            // 
            // groupBox_clear
            // 
            resources.ApplyResources(this.groupBox_clear, "groupBox_clear");
            this.groupBox_clear.Controls.Add(this.checkBox_scrolls);
            this.groupBox_clear.Controls.Add(this.checkBox_doors);
            this.groupBox_clear.Controls.Add(this.checkBox_sprites);
            this.groupBox_clear.Controls.Add(this.checkBox_bg0);
            this.groupBox_clear.Controls.Add(this.checkBox_bg1);
            this.groupBox_clear.Controls.Add(this.button_clearBG);
            this.groupBox_clear.Controls.Add(this.checkBox_bg2);
            this.groupBox_clear.Controls.Add(this.checkBox_clip);
            this.groupBox_clear.Name = "groupBox_clear";
            this.groupBox_clear.TabStop = false;
            // 
            // checkBox_scrolls
            // 
            resources.ApplyResources(this.checkBox_scrolls, "checkBox_scrolls");
            this.checkBox_scrolls.Name = "checkBox_scrolls";
            this.checkBox_scrolls.UseVisualStyleBackColor = true;
            // 
            // checkBox_doors
            // 
            resources.ApplyResources(this.checkBox_doors, "checkBox_doors");
            this.checkBox_doors.Name = "checkBox_doors";
            this.checkBox_doors.UseVisualStyleBackColor = true;
            // 
            // checkBox_sprites
            // 
            resources.ApplyResources(this.checkBox_sprites, "checkBox_sprites");
            this.checkBox_sprites.Name = "checkBox_sprites";
            this.checkBox_sprites.UseVisualStyleBackColor = true;
            // 
            // button_close
            // 
            resources.ApplyResources(this.button_close, "button_close");
            this.button_close.Name = "button_close";
            this.button_close.UseVisualStyleBackColor = true;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // FormRoomOptions
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox_clear);
            this.Controls.Add(this.button_close);
            this.Controls.Add(this.groupBox_resize);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormRoomOptions";
            this.groupBox_resize.ResumeLayout(false);
            this.groupBox_resize.PerformLayout();
            this.groupBox_clear.ResumeLayout(false);
            this.groupBox_clear.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_width;
        private System.Windows.Forms.TextBox textBox_height;
        private System.Windows.Forms.Label label_width;
        private System.Windows.Forms.Label label_height;
        private System.Windows.Forms.Button button_resize;
        private System.Windows.Forms.Button button_clearBG;
        private System.Windows.Forms.CheckBox checkBox_bg0;
        private System.Windows.Forms.CheckBox checkBox_bg1;
        private System.Windows.Forms.CheckBox checkBox_bg2;
        private System.Windows.Forms.CheckBox checkBox_clip;
        private System.Windows.Forms.GroupBox groupBox_resize;
        private System.Windows.Forms.GroupBox groupBox_clear;
        private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.Label label_blocks;
        private System.Windows.Forms.Label label_screens;
        private System.Windows.Forms.TextBox textBox_screenY;
        private System.Windows.Forms.TextBox textBox_screenX;
        private System.Windows.Forms.CheckBox checkBox_scrolls;
        private System.Windows.Forms.CheckBox checkBox_doors;
        private System.Windows.Forms.CheckBox checkBox_sprites;
    }
}