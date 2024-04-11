namespace Login_Window
{
    partial class New_Login_Window
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
            this.cbx_showPassword = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl_softwareName = new System.Windows.Forms.Label();
            this.txb_passWord = new System.Windows.Forms.TextBox();
            this.txb_userName = new System.Windows.Forms.TextBox();
            this.lbl_password = new System.Windows.Forms.Label();
            this.lbl_userName = new System.Windows.Forms.Label();
            this.btn_login = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbx_showPassword
            // 
            this.cbx_showPassword.AutoSize = true;
            this.cbx_showPassword.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbx_showPassword.Location = new System.Drawing.Point(319, 163);
            this.cbx_showPassword.Name = "cbx_showPassword";
            this.cbx_showPassword.Size = new System.Drawing.Size(132, 24);
            this.cbx_showPassword.TabIndex = 20;
            this.cbx_showPassword.Text = "Show Password";
            this.cbx_showPassword.UseVisualStyleBackColor = true;
            this.cbx_showPassword.CheckedChanged += new System.EventHandler(this.cbx_showPassword_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Login_Window.Properties.Resources.unnamed;
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.Location = new System.Drawing.Point(467, 56);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(149, 117);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // lbl_softwareName
            // 
            this.lbl_softwareName.AutoSize = true;
            this.lbl_softwareName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_softwareName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl_softwareName.Location = new System.Drawing.Point(18, 28);
            this.lbl_softwareName.Name = "lbl_softwareName";
            this.lbl_softwareName.Size = new System.Drawing.Size(374, 36);
            this.lbl_softwareName.TabIndex = 19;
            this.lbl_softwareName.Text = "KJN Scholar Registration";
            // 
            // txb_passWord
            // 
            this.txb_passWord.Location = new System.Drawing.Point(116, 127);
            this.txb_passWord.Name = "txb_passWord";
            this.txb_passWord.Size = new System.Drawing.Size(335, 27);
            this.txb_passWord.TabIndex = 16;
            this.txb_passWord.UseSystemPasswordChar = true;
            this.txb_passWord.TextChanged += new System.EventHandler(this.txb_passWord_TextChanged);
            // 
            // txb_userName
            // 
            this.txb_userName.Location = new System.Drawing.Point(114, 77);
            this.txb_userName.Name = "txb_userName";
            this.txb_userName.Size = new System.Drawing.Size(337, 27);
            this.txb_userName.TabIndex = 15;
            this.txb_userName.TextChanged += new System.EventHandler(this.txb_userName_TextChanged);
            // 
            // lbl_password
            // 
            this.lbl_password.AutoSize = true;
            this.lbl_password.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl_password.Location = new System.Drawing.Point(26, 132);
            this.lbl_password.Name = "lbl_password";
            this.lbl_password.Size = new System.Drawing.Size(70, 20);
            this.lbl_password.TabIndex = 14;
            this.lbl_password.Text = "Password";
            // 
            // lbl_userName
            // 
            this.lbl_userName.AutoSize = true;
            this.lbl_userName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl_userName.Location = new System.Drawing.Point(26, 80);
            this.lbl_userName.Name = "lbl_userName";
            this.lbl_userName.Size = new System.Drawing.Size(82, 20);
            this.lbl_userName.TabIndex = 13;
            this.lbl_userName.Text = "User Name";
            // 
            // btn_login
            // 
            this.btn_login.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_login.Location = new System.Drawing.Point(114, 160);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(97, 29);
            this.btn_login.TabIndex = 12;
            this.btn_login.Text = "Login";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // New_Login_Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(642, 239);
            this.Controls.Add(this.cbx_showPassword);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbl_softwareName);
            this.Controls.Add(this.txb_passWord);
            this.Controls.Add(this.txb_userName);
            this.Controls.Add(this.lbl_password);
            this.Controls.Add(this.lbl_userName);
            this.Controls.Add(this.btn_login);
            this.Name = "New_Login_Window";
            this.Text = "New_Login_Window";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CheckBox cbx_showPassword;
        private PictureBox pictureBox1;
        private Label lbl_softwareName;
        private TextBox txb_passWord;
        private TextBox txb_userName;
        private Label lbl_password;
        private Label lbl_userName;
        private Button btn_login;
    }
}