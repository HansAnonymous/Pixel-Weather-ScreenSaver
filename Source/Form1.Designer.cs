namespace Pixel_Weather_ScreenSaver
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
            this.TIMER = new System.Windows.Forms.Timer(this.components);
            this.Icon = new System.Windows.Forms.PictureBox();
            this.temp = new System.Windows.Forms.Label();
            this.desc = new System.Windows.Forms.Label();
            this.LOC = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Icon)).BeginInit();
            this.SuspendLayout();
            // 
            // TIMER
            // 
            this.TIMER.Enabled = true;
            this.TIMER.Interval = 1000;
            this.TIMER.Tick += new System.EventHandler(this.TIMER_TOCK);
            // 
            // Icon
            // 
            this.Icon.Image = ((System.Drawing.Image)(resources.GetObject("Icon.Image")));
            this.Icon.Location = new System.Drawing.Point(155, 12);
            this.Icon.Name = "Icon";
            this.Icon.Size = new System.Drawing.Size(516, 528);
            this.Icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Icon.TabIndex = 0;
            this.Icon.TabStop = false;
            // 
            // temp
            // 
            this.temp.AccessibleName = "";
            this.temp.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.temp.ForeColor = System.Drawing.Color.White;
            this.temp.Location = new System.Drawing.Point(497, 329);
            this.temp.Name = "temp";
            this.temp.Size = new System.Drawing.Size(245, 127);
            this.temp.TabIndex = 1;
            this.temp.Text = "???";
            this.temp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // desc
            // 
            this.desc.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desc.ForeColor = System.Drawing.Color.White;
            this.desc.Location = new System.Drawing.Point(110, 145);
            this.desc.Name = "desc";
            this.desc.Size = new System.Drawing.Size(100, 47);
            this.desc.TabIndex = 2;
            this.desc.Text = "???";
            this.desc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LOC
            // 
            this.LOC.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LOC.ForeColor = System.Drawing.Color.White;
            this.LOC.Location = new System.Drawing.Point(32, 422);
            this.LOC.Name = "LOC";
            this.LOC.Size = new System.Drawing.Size(100, 66);
            this.LOC.TabIndex = 3;
            this.LOC.Text = "???";
            this.LOC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(778, 544);
            this.Controls.Add(this.LOC);
            this.Controls.Add(this.desc);
            this.Controls.Add(this.temp);
            this.Controls.Add(this.Icon);
            this.Name = "Form1";
            this.Text = "Pixel Weather ScreenSaver";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_Click);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.Icon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer TIMER;
        private System.Windows.Forms.PictureBox Icon;
        private System.Windows.Forms.Label temp;
        private System.Windows.Forms.Label desc;
        private System.Windows.Forms.Label LOC;
    }
}

