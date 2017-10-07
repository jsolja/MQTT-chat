namespace upgraded_client
{
    partial class FrmConnectedToTopic
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
            this.outputChat = new System.Windows.Forms.RichTextBox();
            this.inputChat = new System.Windows.Forms.TextBox();
            this.inputSend = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.inputMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.inputSignout = new System.Windows.Forms.ToolStripMenuItem();
            this.inputSound = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // outputChat
            // 
            this.outputChat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputChat.Location = new System.Drawing.Point(12, 43);
            this.outputChat.Name = "outputChat";
            this.outputChat.Size = new System.Drawing.Size(260, 194);
            this.outputChat.TabIndex = 13;
            this.outputChat.Text = "";
            // 
            // inputChat
            // 
            this.inputChat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputChat.Location = new System.Drawing.Point(12, 243);
            this.inputChat.Name = "inputChat";
            this.inputChat.Size = new System.Drawing.Size(260, 20);
            this.inputChat.TabIndex = 14;
            this.inputChat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inputChat_KeyPress);
            // 
            // inputSend
            // 
            this.inputSend.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.inputSend.Location = new System.Drawing.Point(150, 269);
            this.inputSend.Name = "inputSend";
            this.inputSend.Size = new System.Drawing.Size(83, 25);
            this.inputSend.TabIndex = 15;
            this.inputSend.Text = "Send";
            this.inputSend.UseVisualStyleBackColor = true;
            this.inputSend.Click += new System.EventHandler(this.inputSend_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inputMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // inputMenu
            // 
            this.inputMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inputSignout});
            this.inputMenu.Name = "inputMenu";
            this.inputMenu.Size = new System.Drawing.Size(50, 20);
            this.inputMenu.Text = "Menu";
            // 
            // inputSignout
            // 
            this.inputSignout.Name = "inputSignout";
            this.inputSignout.Size = new System.Drawing.Size(152, 22);
            this.inputSignout.Text = "Sign out";
            this.inputSignout.Click += new System.EventHandler(this.inputSignout_Click);
            // 
            // inputSound
            // 
            this.inputSound.Location = new System.Drawing.Point(12, 269);
            this.inputSound.Name = "inputSound";
            this.inputSound.Size = new System.Drawing.Size(25, 25);
            this.inputSound.TabIndex = 18;
            this.inputSound.UseVisualStyleBackColor = true;
            this.inputSound.Click += new System.EventHandler(this.inputSound_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::upgraded_client.Properties.Resources.foi_logo;
            this.pictureBox1.Location = new System.Drawing.Point(239, 269);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // FrmConnectedToTopic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 309);
            this.Controls.Add(this.inputSound);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.outputChat);
            this.Controls.Add(this.inputChat);
            this.Controls.Add(this.inputSend);
            this.Name = "FrmConnectedToTopic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "M2MQTT Chat";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmConnectedToTopic_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox outputChat;
        private System.Windows.Forms.TextBox inputChat;
        private System.Windows.Forms.Button inputSend;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem inputMenu;
        private System.Windows.Forms.ToolStripMenuItem inputSignout;
        private System.Windows.Forms.Button inputSound;
    }
}