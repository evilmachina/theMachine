namespace GUI
{
    partial class frmBase
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
            this.ForwardButton = new System.Windows.Forms.Button();
            this.ForwardRight = new System.Windows.Forms.Button();
            this.Right = new System.Windows.Forms.Button();
            this.BackRight = new System.Windows.Forms.Button();
            this.Back = new System.Windows.Forms.Button();
            this.Left = new System.Windows.Forms.Button();
            this.BackLeft = new System.Windows.Forms.Button();
            this.ForwardLeft = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.direction = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TimeBox = new System.Windows.Forms.Label();
            this.StepValue = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.xCenter = new System.Windows.Forms.TextBox();
            this.degrees = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.zCenter = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ForwardButton
            // 
            this.ForwardButton.Location = new System.Drawing.Point(295, 54);
            this.ForwardButton.Name = "ForwardButton";
            this.ForwardButton.Size = new System.Drawing.Size(30, 23);
            this.ForwardButton.TabIndex = 0;
            this.ForwardButton.Tag = "";
            this.ForwardButton.Text = "F";
            this.ForwardButton.UseVisualStyleBackColor = true;
            this.ForwardButton.Click += new System.EventHandler(this.ForwardButton_Click);
            // 
            // ForwardRight
            // 
            this.ForwardRight.Location = new System.Drawing.Point(331, 72);
            this.ForwardRight.Name = "ForwardRight";
            this.ForwardRight.Size = new System.Drawing.Size(30, 23);
            this.ForwardRight.TabIndex = 1;
            this.ForwardRight.Text = "FR";
            this.ForwardRight.UseVisualStyleBackColor = true;
            // 
            // Right
            // 
            this.Right.Location = new System.Drawing.Point(347, 101);
            this.Right.Name = "Right";
            this.Right.Size = new System.Drawing.Size(30, 23);
            this.Right.TabIndex = 2;
            this.Right.Text = "R";
            this.Right.UseVisualStyleBackColor = true;
            // 
            // BackRight
            // 
            this.BackRight.Location = new System.Drawing.Point(331, 130);
            this.BackRight.Name = "BackRight";
            this.BackRight.Size = new System.Drawing.Size(30, 23);
            this.BackRight.TabIndex = 3;
            this.BackRight.Text = "BR";
            this.BackRight.UseVisualStyleBackColor = true;
            // 
            // Back
            // 
            this.Back.Location = new System.Drawing.Point(295, 147);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(30, 23);
            this.Back.TabIndex = 4;
            this.Back.Text = "B";
            this.Back.UseVisualStyleBackColor = true;
            // 
            // Left
            // 
            this.Left.Location = new System.Drawing.Point(243, 101);
            this.Left.Name = "Left";
            this.Left.Size = new System.Drawing.Size(30, 23);
            this.Left.TabIndex = 5;
            this.Left.Text = "L";
            this.Left.UseVisualStyleBackColor = true;
            // 
            // BackLeft
            // 
            this.BackLeft.Location = new System.Drawing.Point(259, 130);
            this.BackLeft.Name = "BackLeft";
            this.BackLeft.Size = new System.Drawing.Size(30, 23);
            this.BackLeft.TabIndex = 6;
            this.BackLeft.Text = "BL";
            this.BackLeft.UseVisualStyleBackColor = true;
            // 
            // ForwardLeft
            // 
            this.ForwardLeft.Location = new System.Drawing.Point(259, 72);
            this.ForwardLeft.Name = "ForwardLeft";
            this.ForwardLeft.Size = new System.Drawing.Size(30, 23);
            this.ForwardLeft.TabIndex = 7;
            this.ForwardLeft.Text = "FL";
            this.ForwardLeft.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(287, 92);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(46, 40);
            this.button9.TabIndex = 8;
            this.button9.Text = "Home";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // direction
            // 
            this.direction.Location = new System.Drawing.Point(15, 35);
            this.direction.MaxLength = 3;
            this.direction.Name = "direction";
            this.direction.Size = new System.Drawing.Size(48, 20);
            this.direction.TabIndex = 9;
            this.direction.Text = "90";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Direction";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "StepValue";
            // 
            // TimeBox
            // 
            this.TimeBox.AutoSize = true;
            this.TimeBox.Location = new System.Drawing.Point(12, 124);
            this.TimeBox.Name = "TimeBox";
            this.TimeBox.Size = new System.Drawing.Size(48, 13);
            this.TimeBox.TabIndex = 12;
            this.TimeBox.Text = "TimeBox";
            // 
            // StepValue
            // 
            this.StepValue.Location = new System.Drawing.Point(15, 89);
            this.StepValue.Name = "StepValue";
            this.StepValue.Size = new System.Drawing.Size(48, 20);
            this.StepValue.TabIndex = 13;
            this.StepValue.Text = "1";
            this.StepValue.Leave += new System.EventHandler(this.StepValue_Leave);
            this.StepValue.Enter += new System.EventHandler(this.StepValue_Enter);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(15, 140);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(48, 20);
            this.textBox2.TabIndex = 14;
            this.textBox2.Text = "1";
            this.textBox2.Leave += new System.EventHandler(this.StepValue_Leave);
            this.textBox2.Enter += new System.EventHandler(this.StepValue_Enter);
            // 
            // xCenter
            // 
            this.xCenter.Location = new System.Drawing.Point(15, 251);
            this.xCenter.Name = "xCenter";
            this.xCenter.Size = new System.Drawing.Size(48, 20);
            this.xCenter.TabIndex = 18;
            this.xCenter.Text = "0";
            this.xCenter.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.xCenter.Leave += new System.EventHandler(this.StepValue_Leave);
            this.xCenter.Enter += new System.EventHandler(this.StepValue_Enter);
            // 
            // degrees
            // 
            this.degrees.Location = new System.Drawing.Point(15, 200);
            this.degrees.Name = "degrees";
            this.degrees.Size = new System.Drawing.Size(48, 20);
            this.degrees.TabIndex = 17;
            this.degrees.Text = "1";
            this.degrees.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            this.degrees.Leave += new System.EventHandler(this.StepValue_Leave);
            this.degrees.Enter += new System.EventHandler(this.StepValue_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 235);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "X center";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Degrees";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // zCenter
            // 
            this.zCenter.Location = new System.Drawing.Point(15, 300);
            this.zCenter.Name = "zCenter";
            this.zCenter.Size = new System.Drawing.Size(48, 20);
            this.zCenter.TabIndex = 20;
            this.zCenter.Text = "0";
            this.zCenter.Leave += new System.EventHandler(this.StepValue_Leave);
            this.zCenter.Enter += new System.EventHandler(this.StepValue_Enter);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 284);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Y center";
            // 
            // frmBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 387);
            this.Controls.Add(this.zCenter);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.xCenter);
            this.Controls.Add(this.degrees);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.StepValue);
            this.Controls.Add(this.TimeBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.direction);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.ForwardLeft);
            this.Controls.Add(this.BackLeft);
            this.Controls.Add(this.Left);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.BackRight);
            this.Controls.Add(this.Right);
            this.Controls.Add(this.ForwardRight);
            this.Controls.Add(this.ForwardButton);
            this.Name = "frmBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmBase_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ForwardButton;
        private System.Windows.Forms.Button ForwardRight;
        private System.Windows.Forms.Button Right;
        private System.Windows.Forms.Button BackRight;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.Button Left;
        private System.Windows.Forms.Button BackLeft;
        private System.Windows.Forms.Button ForwardLeft;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.TextBox direction;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label TimeBox;
        private System.Windows.Forms.TextBox StepValue;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox xCenter;
        private System.Windows.Forms.TextBox degrees;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox zCenter;
        private System.Windows.Forms.Label label5;

    }
}

