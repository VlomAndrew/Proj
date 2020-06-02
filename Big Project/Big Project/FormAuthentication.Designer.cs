using System.Resources;

namespace Big_Project
{
    partial class FormAuthentication
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

        public Auxiliary.Properties userProperty;

        private string connString;
        private ResXResourceSet langRes;
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAuthentication));
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelUser = new System.Windows.Forms.Label();
            this.labelPass = new System.Windows.Forms.Label();
            this.buttonAuth = new System.Windows.Forms.Button();
            this.buttonRegistr = new System.Windows.Forms.Button();
            this.buttonUnPassw = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(217, 84);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(218, 20);
            this.textBoxUserName.TabIndex = 0;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(217, 120);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(218, 20);
            this.textBoxPassword.TabIndex = 1;
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Location = new System.Drawing.Point(54, 91);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(35, 13);
            this.labelUser.TabIndex = 2;
            this.labelUser.Text = "label1";
            // 
            // labelPass
            // 
            this.labelPass.AutoSize = true;
            this.labelPass.Location = new System.Drawing.Point(54, 127);
            this.labelPass.Name = "labelPass";
            this.labelPass.Size = new System.Drawing.Size(35, 13);
            this.labelPass.TabIndex = 3;
            this.labelPass.Text = "label2";
            // 
            // buttonAuth
            // 
            this.buttonAuth.Location = new System.Drawing.Point(270, 146);
            this.buttonAuth.Name = "buttonAuth";
            this.buttonAuth.Size = new System.Drawing.Size(119, 50);
            this.buttonAuth.TabIndex = 4;
            this.buttonAuth.Text = "button1";
            this.buttonAuth.UseVisualStyleBackColor = true;
            this.buttonAuth.Click += new System.EventHandler(this.buttonAuth_Click);
            // 
            // buttonRegistr
            // 
            this.buttonRegistr.Location = new System.Drawing.Point(270, 202);
            this.buttonRegistr.Name = "buttonRegistr";
            this.buttonRegistr.Size = new System.Drawing.Size(119, 24);
            this.buttonRegistr.TabIndex = 5;
            this.buttonRegistr.Text = "button2";
            this.buttonRegistr.UseVisualStyleBackColor = true;
            this.buttonRegistr.Click += new System.EventHandler(this.buttonRegistr_Click);
            // 
            // buttonUnPassw
            // 
            this.buttonUnPassw.Image = ((System.Drawing.Image)(resources.GetObject("buttonUnPassw.Image")));
            this.buttonUnPassw.Location = new System.Drawing.Point(458, 120);
            this.buttonUnPassw.Name = "buttonUnPassw";
            this.buttonUnPassw.Size = new System.Drawing.Size(28, 20);
            this.buttonUnPassw.TabIndex = 6;
            this.buttonUnPassw.UseVisualStyleBackColor = true;
            this.buttonUnPassw.Click += new System.EventHandler(this.buttonUnPassw_Click);
            // 
            // FormAuthentication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 285);
            this.Controls.Add(this.buttonUnPassw);
            this.Controls.Add(this.buttonRegistr);
            this.Controls.Add(this.buttonAuth);
            this.Controls.Add(this.labelPass);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxUserName);
            this.Name = "FormAuthentication";
            this.Text = "FormAuthentication";
            this.Load += new System.EventHandler(this.FormAuthentication_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Label labelPass;
        private System.Windows.Forms.Button buttonAuth;
        private System.Windows.Forms.Button buttonRegistr;
        private System.Windows.Forms.Button buttonUnPassw;
    }
}