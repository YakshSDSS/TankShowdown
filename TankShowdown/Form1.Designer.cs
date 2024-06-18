namespace TankShowdown
{
    partial class TankShowdown
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
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.p1L1 = new System.Windows.Forms.PictureBox();
            this.p1L3 = new System.Windows.Forms.PictureBox();
            this.p1L2 = new System.Windows.Forms.PictureBox();
            this.p2L3 = new System.Windows.Forms.PictureBox();
            this.p2L1 = new System.Windows.Forms.PictureBox();
            this.p2L2 = new System.Windows.Forms.PictureBox();
            this.p1Cooldown = new System.Windows.Forms.Label();
            this.p2Cooldown = new System.Windows.Forms.Label();
            this.borderCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.p1L1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1L3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1L2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p2L3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p2L1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p2L2)).BeginInit();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // p1L1
            // 
            this.p1L1.BackColor = System.Drawing.Color.Transparent;
            this.p1L1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.p1L1.Location = new System.Drawing.Point(53, 12);
            this.p1L1.Name = "p1L1";
            this.p1L1.Size = new System.Drawing.Size(33, 28);
            this.p1L1.TabIndex = 0;
            this.p1L1.TabStop = false;
            // 
            // p1L3
            // 
            this.p1L3.BackColor = System.Drawing.Color.Transparent;
            this.p1L3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.p1L3.Location = new System.Drawing.Point(131, 12);
            this.p1L3.Name = "p1L3";
            this.p1L3.Size = new System.Drawing.Size(33, 28);
            this.p1L3.TabIndex = 1;
            this.p1L3.TabStop = false;
            // 
            // p1L2
            // 
            this.p1L2.BackColor = System.Drawing.Color.Transparent;
            this.p1L2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.p1L2.Location = new System.Drawing.Point(92, 12);
            this.p1L2.Name = "p1L2";
            this.p1L2.Size = new System.Drawing.Size(33, 28);
            this.p1L2.TabIndex = 2;
            this.p1L2.TabStop = false;
            // 
            // p2L3
            // 
            this.p2L3.BackColor = System.Drawing.Color.Transparent;
            this.p2L3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.p2L3.Location = new System.Drawing.Point(616, 12);
            this.p2L3.Name = "p2L3";
            this.p2L3.Size = new System.Drawing.Size(33, 28);
            this.p2L3.TabIndex = 3;
            this.p2L3.TabStop = false;
            // 
            // p2L1
            // 
            this.p2L1.BackColor = System.Drawing.Color.Transparent;
            this.p2L1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.p2L1.Location = new System.Drawing.Point(538, 12);
            this.p2L1.Name = "p2L1";
            this.p2L1.Size = new System.Drawing.Size(33, 28);
            this.p2L1.TabIndex = 4;
            this.p2L1.TabStop = false;
            // 
            // p2L2
            // 
            this.p2L2.BackColor = System.Drawing.Color.Transparent;
            this.p2L2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.p2L2.Location = new System.Drawing.Point(577, 12);
            this.p2L2.Name = "p2L2";
            this.p2L2.Size = new System.Drawing.Size(33, 28);
            this.p2L2.TabIndex = 5;
            this.p2L2.TabStop = false;
            // 
            // p1Cooldown
            // 
            this.p1Cooldown.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p1Cooldown.ForeColor = System.Drawing.Color.DodgerBlue;
            this.p1Cooldown.Location = new System.Drawing.Point(170, 12);
            this.p1Cooldown.Name = "p1Cooldown";
            this.p1Cooldown.Size = new System.Drawing.Size(53, 28);
            this.p1Cooldown.TabIndex = 6;
            // 
            // p2Cooldown
            // 
            this.p2Cooldown.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p2Cooldown.ForeColor = System.Drawing.Color.Red;
            this.p2Cooldown.Location = new System.Drawing.Point(479, 12);
            this.p2Cooldown.Name = "p2Cooldown";
            this.p2Cooldown.Size = new System.Drawing.Size(53, 28);
            this.p2Cooldown.TabIndex = 7;
            // 
            // borderCount
            // 
            this.borderCount.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.borderCount.ForeColor = System.Drawing.Color.Lime;
            this.borderCount.Location = new System.Drawing.Point(279, 52);
            this.borderCount.Name = "borderCount";
            this.borderCount.Size = new System.Drawing.Size(206, 28);
            this.borderCount.TabIndex = 8;
            this.borderCount.Text = "Border closing in..";
            // 
            // TankShowdown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 34F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(700, 700);
            this.Controls.Add(this.borderCount);
            this.Controls.Add(this.p2Cooldown);
            this.Controls.Add(this.p1Cooldown);
            this.Controls.Add(this.p2L2);
            this.Controls.Add(this.p2L1);
            this.Controls.Add(this.p2L3);
            this.Controls.Add(this.p1L2);
            this.Controls.Add(this.p1L3);
            this.Controls.Add(this.p1L1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Stencil", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Lime;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.Name = "TankShowdown";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.TankShowdown_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TankShowdown_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TankShowdown_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.p1L1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1L3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1L2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p2L3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p2L1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p2L2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.PictureBox p1L1;
        private System.Windows.Forms.PictureBox p1L3;
        private System.Windows.Forms.PictureBox p1L2;
        private System.Windows.Forms.PictureBox p2L3;
        private System.Windows.Forms.PictureBox p2L1;
        private System.Windows.Forms.PictureBox p2L2;
        private System.Windows.Forms.Label p1Cooldown;
        private System.Windows.Forms.Label p2Cooldown;
        private System.Windows.Forms.Label borderCount;
    }
}

