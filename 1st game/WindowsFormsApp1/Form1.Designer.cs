namespace WindowsFormsApp1
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.playerbox = new System.Windows.Forms.PictureBox();
            this.Player = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.playerbox)).BeginInit();
            this.SuspendLayout();
            // 
            // playerbox
            // 
            this.playerbox.BackColor = System.Drawing.Color.Transparent;
            this.playerbox.Image = ((System.Drawing.Image)(resources.GetObject("playerbox.Image")));
            this.playerbox.Location = new System.Drawing.Point(520, 403);
            this.playerbox.Name = "playerbox";
            this.playerbox.Size = new System.Drawing.Size(110, 100);
            this.playerbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.playerbox.TabIndex = 0;
            this.playerbox.TabStop = false;
            // 
            // Player
            // 
            this.Player.Enabled = true;
            this.Player.Interval = 30;
            this.Player.Tick += new System.EventHandler(this.Player_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1109, 533);
            this.Controls.Add(this.playerbox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.playerbox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox playerbox;
        private System.Windows.Forms.Timer Player;
    }
}

