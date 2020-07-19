namespace TimetableGenerator
{
    partial class login
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
            this.label5 = new System.Windows.Forms.Label();
            this.loginbut = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Show = new System.Windows.Forms.CheckBox();
            this.Password_textBox = new System.Windows.Forms.TextBox();
            this.UserID_textBox = new System.Windows.Forms.TextBox();
            this.SignUp = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(231, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(352, 41);
            this.label5.TabIndex = 6;
            this.label5.Text = "Timetable Generator";
            // 
            // loginbut
            // 
            this.loginbut.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginbut.Location = new System.Drawing.Point(667, 395);
            this.loginbut.Name = "loginbut";
            this.loginbut.Size = new System.Drawing.Size(94, 33);
            this.loginbut.TabIndex = 7;
            this.loginbut.Text = "Login";
            this.loginbut.UseVisualStyleBackColor = true;
            this.loginbut.Click += new System.EventHandler(this.loginbut_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(41, 395);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 33);
            this.button1.TabIndex = 8;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Show
            // 
            this.Show.AutoSize = true;
            this.Show.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Show.Location = new System.Drawing.Point(560, 226);
            this.Show.Name = "Show";
            this.Show.Size = new System.Drawing.Size(108, 18);
            this.Show.TabIndex = 26;
            this.Show.Text = "Show Password";
            this.Show.UseVisualStyleBackColor = true;
            // 
            // Password_textBox
            // 
            this.Password_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password_textBox.Location = new System.Drawing.Point(347, 223);
            this.Password_textBox.Name = "Password_textBox";
            this.Password_textBox.Size = new System.Drawing.Size(186, 26);
            this.Password_textBox.TabIndex = 25;
            this.Password_textBox.UseSystemPasswordChar = true;
            // 
            // UserID_textBox
            // 
            this.UserID_textBox.Location = new System.Drawing.Point(347, 144);
            this.UserID_textBox.Multiline = true;
            this.UserID_textBox.Name = "UserID_textBox";
            this.UserID_textBox.Size = new System.Drawing.Size(186, 28);
            this.UserID_textBox.TabIndex = 24;
            // 
            // SignUp
            // 
            this.SignUp.BackColor = System.Drawing.Color.Gainsboro;
            this.SignUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignUp.Location = new System.Drawing.Point(439, 322);
            this.SignUp.Name = "SignUp";
            this.SignUp.Size = new System.Drawing.Size(94, 33);
            this.SignUp.TabIndex = 23;
            this.SignUp.Text = "SignUp";
            this.SignUp.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(259, 327);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 18);
            this.label4.TabIndex = 22;
            this.label4.Text = "Don\'t have account?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(217, 225);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 18);
            this.label2.TabIndex = 21;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(217, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 18);
            this.label1.TabIndex = 20;
            this.label1.Text = "User ID";
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Show);
            this.Controls.Add(this.Password_textBox);
            this.Controls.Add(this.UserID_textBox);
            this.Controls.Add(this.SignUp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.loginbut);
            this.Controls.Add(this.label5);
            this.Name = "login";
            this.Text = "login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button loginbut;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox Show;
        private System.Windows.Forms.TextBox Password_textBox;
        private System.Windows.Forms.TextBox UserID_textBox;
        private System.Windows.Forms.Button SignUp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}