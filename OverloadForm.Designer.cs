namespace Overload_Warning
{
    partial class OverloadForm
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
            this.WarnText = new System.Windows.Forms.Label();
            this.DescripText = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // WarnText
            // 
            this.WarnText.AutoSize = true;
            this.WarnText.BackColor = System.Drawing.Color.MistyRose;
            this.WarnText.Font = new System.Drawing.Font("Sans Serif Collection", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.WarnText.ForeColor = System.Drawing.Color.Firebrick;
            this.WarnText.Location = new System.Drawing.Point(97, 52);
            this.WarnText.Name = "WarnText";
            this.WarnText.Size = new System.Drawing.Size(454, 56);
            this.WarnText.TabIndex = 0;
            this.WarnText.Text = "Warning: Course Overload";
            this.WarnText.Click += new System.EventHandler(this.label1_Click);
            // 
            // DescripText
            // 
            this.DescripText.AutoSize = true;
            this.DescripText.BackColor = System.Drawing.Color.MistyRose;
            this.DescripText.Font = new System.Drawing.Font("Sans Serif Collection", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DescripText.Location = new System.Drawing.Point(180, 108);
            this.DescripText.Name = "DescripText";
            this.DescripText.Size = new System.Drawing.Size(280, 32);
            this.DescripText.TabIndex = 1;
            this.DescripText.Text = "You Have Added 5.0+ Credits";
            this.DescripText.Click += new System.EventHandler(this.label2_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(245, 173);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(151, 30);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // OverloadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(644, 267);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.DescripText);
            this.Controls.Add(this.WarnText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OverloadForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label WarnText;
        private Label DescripText;
        private Button okButton;
    }
}
