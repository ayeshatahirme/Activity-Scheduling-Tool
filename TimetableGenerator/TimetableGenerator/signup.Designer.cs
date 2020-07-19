namespace TimetableGenerator
{
    partial class signup
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.ShowConfirm = new System.Windows.Forms.CheckBox();
            this.ShowPassword = new System.Windows.Forms.CheckBox();
            this.L_Name = new System.Windows.Forms.TextBox();
            this.F_Name = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Email = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.UserID = new System.Windows.Forms.TextBox();
            this.warning = new System.Windows.Forms.Label();
            this.pas = new System.Windows.Forms.TextBox();
            this.cpass = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(246, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(352, 41);
            this.label5.TabIndex = 7;
            this.label5.Text = "Timetable Generator";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(680, 391);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 31);
            this.button1.TabIndex = 8;
            this.button1.Text = "Signup";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(29, 391);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 31);
            this.button2.TabIndex = 9;
            this.button2.Text = "Back";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ShowConfirm
            // 
            this.ShowConfirm.AutoSize = true;
            this.ShowConfirm.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowConfirm.Location = new System.Drawing.Point(588, 295);
            this.ShowConfirm.Name = "ShowConfirm";
            this.ShowConfirm.Size = new System.Drawing.Size(108, 18);
            this.ShowConfirm.TabIndex = 39;
            this.ShowConfirm.Text = "Show Password";
            this.ShowConfirm.UseVisualStyleBackColor = true;
            this.ShowConfirm.CheckedChanged += new System.EventHandler(this.ShowConfirm_CheckedChanged);
            // 
            // ShowPassword
            // 
            this.ShowPassword.AutoSize = true;
            this.ShowPassword.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowPassword.Location = new System.Drawing.Point(235, 294);
            this.ShowPassword.Name = "ShowPassword";
            this.ShowPassword.Size = new System.Drawing.Size(108, 18);
            this.ShowPassword.TabIndex = 38;
            this.ShowPassword.Text = "Show Password";
            this.ShowPassword.UseVisualStyleBackColor = true;
            this.ShowPassword.CheckedChanged += new System.EventHandler(this.ShowPassword_CheckedChanged);
            // 
            // L_Name
            // 
            this.L_Name.Location = new System.Drawing.Point(558, 115);
            this.L_Name.Name = "L_Name";
            this.L_Name.Size = new System.Drawing.Size(138, 20);
            this.L_Name.TabIndex = 37;
            // 
            // F_Name
            // 
            this.F_Name.Location = new System.Drawing.Point(205, 115);
            this.F_Name.Name = "F_Name";
            this.F_Name.Size = new System.Drawing.Size(138, 20);
            this.F_Name.TabIndex = 36;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(406, 254);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(134, 17);
            this.label7.TabIndex = 34;
            this.label7.Text = "Confirm Password:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(453, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 17);
            this.label6.TabIndex = 33;
            this.label6.Text = "Last Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(100, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 17);
            this.label4.TabIndex = 32;
            this.label4.Text = "First Name:";
            // 
            // Email
            // 
            this.Email.Location = new System.Drawing.Point(558, 179);
            this.Email.Multiline = true;
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(138, 45);
            this.Email.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(100, 254);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 17);
            this.label3.TabIndex = 29;
            this.label3.Text = "Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(430, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 17);
            this.label2.TabIndex = 28;
            this.label2.Text = "Email Address:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(98, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 27;
            this.label1.Text = "Username:";
            // 
            // UserID
            // 
            this.UserID.Location = new System.Drawing.Point(205, 186);
            this.UserID.Multiline = true;
            this.UserID.Name = "UserID";
            this.UserID.Size = new System.Drawing.Size(138, 20);
            this.UserID.TabIndex = 26;
            // 
            // warning
            // 
            this.warning.AutoSize = true;
            this.warning.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.warning.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.warning.Location = new System.Drawing.Point(441, 355);
            this.warning.Name = "warning";
            this.warning.Size = new System.Drawing.Size(16, 15);
            this.warning.TabIndex = 50;
            this.warning.Text = "...";
            // 
            // pas
            // 
            this.pas.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.pas.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pas.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pas.Location = new System.Drawing.Point(205, 250);
            this.pas.Name = "pas";
            this.pas.Size = new System.Drawing.Size(138, 21);
            this.pas.TabIndex = 53;
            this.pas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.pas.UseSystemPasswordChar = true;
            // 
            // cpass
            // 
            this.cpass.CausesValidation = false;
            this.cpass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.cpass.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cpass.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cpass.Location = new System.Drawing.Point(558, 250);
            this.cpass.Name = "cpass";
            this.cpass.Size = new System.Drawing.Size(138, 21);
            this.cpass.TabIndex = 54;
            this.cpass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cpass.UseSystemPasswordChar = true;
            // 
            // signup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cpass);
            this.Controls.Add(this.pas);
            this.Controls.Add(this.warning);
            this.Controls.Add(this.ShowConfirm);
            this.Controls.Add(this.ShowPassword);
            this.Controls.Add(this.L_Name);
            this.Controls.Add(this.F_Name);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Email);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UserID);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Name = "signup";
            this.Text = "signup";
            this.Load += new System.EventHandler(this.signup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox ShowConfirm;
        private System.Windows.Forms.CheckBox ShowPassword;
        private System.Windows.Forms.TextBox L_Name;
        private System.Windows.Forms.TextBox F_Name;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Email;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox UserID;
        private System.Windows.Forms.Label warning;
        private System.Windows.Forms.TextBox pas;
        private System.Windows.Forms.TextBox cpass;
    }
}