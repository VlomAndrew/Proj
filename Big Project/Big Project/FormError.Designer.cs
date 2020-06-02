using System.Resources;

namespace Big_Project
{
    partial class FormError
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
            this.textBoxServer = new System.Windows.Forms.TextBox();
            this.textBoxDatabase = new System.Windows.Forms.TextBox();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.textBoxPwd = new System.Windows.Forms.TextBox();
            this.labelServer = new System.Windows.Forms.Label();
            this.labelDataBase = new System.Windows.Forms.Label();
            this.labelUser = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.rTBError = new System.Windows.Forms.RichTextBox();
            this.buttonSaveReload = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxServer
            // 
            this.textBoxServer.Location = new System.Drawing.Point(240, 198);
            this.textBoxServer.Name = "textBoxServer";
            this.textBoxServer.Size = new System.Drawing.Size(100, 20);
            this.textBoxServer.TabIndex = 0;
            // 
            // textBoxDatabase
            // 
            this.textBoxDatabase.Location = new System.Drawing.Point(240, 224);
            this.textBoxDatabase.Name = "textBoxDatabase";
            this.textBoxDatabase.Size = new System.Drawing.Size(100, 20);
            this.textBoxDatabase.TabIndex = 1;
            // 
            // textBoxUser
            // 
            this.textBoxUser.Location = new System.Drawing.Point(240, 250);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(100, 20);
            this.textBoxUser.TabIndex = 2;
            // 
            // textBoxPwd
            // 
            this.textBoxPwd.Location = new System.Drawing.Point(240, 276);
            this.textBoxPwd.Name = "textBoxPwd";
            this.textBoxPwd.Size = new System.Drawing.Size(100, 20);
            this.textBoxPwd.TabIndex = 3;
            // 
            // labelServer
            // 
            this.labelServer.AutoSize = true;
            this.labelServer.Location = new System.Drawing.Point(104, 205);
            this.labelServer.Name = "labelServer";
            this.labelServer.Size = new System.Drawing.Size(35, 13);
            this.labelServer.TabIndex = 4;
            this.labelServer.Text = "label1";
            // 
            // labelDataBase
            // 
            this.labelDataBase.AutoSize = true;
            this.labelDataBase.Location = new System.Drawing.Point(104, 231);
            this.labelDataBase.Name = "labelDataBase";
            this.labelDataBase.Size = new System.Drawing.Size(35, 13);
            this.labelDataBase.TabIndex = 5;
            this.labelDataBase.Text = "label2";
            this.labelDataBase.Click += new System.EventHandler(this.label2_Click);
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Location = new System.Drawing.Point(104, 257);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(35, 13);
            this.labelUser.TabIndex = 6;
            this.labelUser.Text = "label3";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(104, 283);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(35, 13);
            this.labelPassword.TabIndex = 7;
            this.labelPassword.Text = "label4";
            this.labelPassword.Click += new System.EventHandler(this.label4_Click);
            // 
            // rTBError
            // 
            this.rTBError.Location = new System.Drawing.Point(12, 12);
            this.rTBError.Name = "rTBError";
            this.rTBError.ReadOnly = true;
            this.rTBError.Size = new System.Drawing.Size(561, 157);
            this.rTBError.TabIndex = 8;
            this.rTBError.Text = "";
            // 
            // buttonSaveReload
            // 
            this.buttonSaveReload.Location = new System.Drawing.Point(455, 198);
            this.buttonSaveReload.Name = "buttonSaveReload";
            this.buttonSaveReload.Size = new System.Drawing.Size(118, 98);
            this.buttonSaveReload.TabIndex = 9;
            this.buttonSaveReload.Text = "button1";
            this.buttonSaveReload.UseVisualStyleBackColor = true;
            this.buttonSaveReload.Click += new System.EventHandler(this.buttonSaveReload_Click);
            // 
            // FormError
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 376);
            this.Controls.Add(this.buttonSaveReload);
            this.Controls.Add(this.rTBError);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.labelDataBase);
            this.Controls.Add(this.labelServer);
            this.Controls.Add(this.textBoxPwd);
            this.Controls.Add(this.textBoxUser);
            this.Controls.Add(this.textBoxDatabase);
            this.Controls.Add(this.textBoxServer);
            this.Name = "FormError";
            this.Text = "FormError";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormError_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormError_FormClosed);
            this.Load += new System.EventHandler(this.FormError_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        

        private ResXResourceSet resource, globalRes;
        private string errorMessage;
        public  Auxiliary.States result;


        private System.Windows.Forms.TextBox textBoxServer;
        private System.Windows.Forms.TextBox textBoxDatabase;
        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.TextBox textBoxPwd;
        private System.Windows.Forms.Label labelServer;
        private System.Windows.Forms.Label labelDataBase;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.RichTextBox rTBError;
        private System.Windows.Forms.Button buttonSaveReload;
    }
}