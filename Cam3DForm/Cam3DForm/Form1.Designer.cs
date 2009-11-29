namespace Cam3DForm
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;

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
            this.leftCameraImage = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.rightCameraImage = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // leftCameraImage
            // 
            this.leftCameraImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.leftCameraImage.Location = new System.Drawing.Point(0, 0);
            this.leftCameraImage.Name = "leftCameraImage";
            this.leftCameraImage.Size = new System.Drawing.Size(602, 424);
            this.leftCameraImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.leftCameraImage.TabIndex = 0;
            this.leftCameraImage.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rightCameraImage
            // 
            this.rightCameraImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rightCameraImage.Location = new System.Drawing.Point(0, 0);
            this.rightCameraImage.Name = "rightCameraImage";
            this.rightCameraImage.Size = new System.Drawing.Size(602, 424);
            this.rightCameraImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.rightCameraImage.TabIndex = 2;
            this.rightCameraImage.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 424);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.leftCameraImage);
            this.Controls.Add(this.rightCameraImage);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox leftCameraImage;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox rightCameraImage;
    }
}

