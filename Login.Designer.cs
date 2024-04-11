namespace Login_GUI
{
    partial class formWin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.errortxt = new System.Windows.Forms.TextBox();
            this.okB = new System.Windows.Forms.Button();
            this.fPassword = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // errortxt
            // 
            this.errortxt.BackColor = System.Drawing.Color.MistyRose;
            this.errortxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.errortxt.Font = new System.Drawing.Font("Times New Roman", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.errortxt.ForeColor = System.Drawing.Color.Brown;
            this.errortxt.Location = new System.Drawing.Point(65, 51);
            this.errortxt.Name = "errortxt";
            this.errortxt.Size = new System.Drawing.Size(363, 27);
            this.errortxt.TabIndex = 0;
            this.errortxt.TabStop = false;
            this.errortxt.Text = " Invalid Username and/or Password";
            this.errortxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.errortxt.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // okB
            // 
            this.okB.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.okB.Location = new System.Drawing.Point(326, 123);
            this.okB.Name = "okB";
            this.okB.Size = new System.Drawing.Size(94, 29);
            this.okB.TabIndex = 1;
            this.okB.Text = "OK";
            this.okB.UseVisualStyleBackColor = true;
            this.okB.Click += new System.EventHandler(this.okB_Click);
            // 
            // fPassword
            // 
            this.fPassword.AutoSize = true;
            this.fPassword.LinkColor = System.Drawing.Color.SteelBlue;
            this.fPassword.Location = new System.Drawing.Point(65, 123);
            this.fPassword.Name = "fPassword";
            this.fPassword.Size = new System.Drawing.Size(125, 20);
            this.fPassword.TabIndex = 3;
            this.fPassword.TabStop = true;
            this.fPassword.Text = "Forgot Password?";
            // 
            // formWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(482, 211);
            this.Controls.Add(this.fPassword);
            this.Controls.Add(this.okB);
            this.Controls.Add(this.errortxt);
            this.Name = "formWin";
            this.Text = "Login Error";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox errortxt;
        private Button okB;
        private LinkLabel fPassword;
    }
}