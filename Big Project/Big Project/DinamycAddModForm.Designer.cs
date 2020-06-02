using System.Collections.Generic;
using System.Windows.Forms;
using Label = System.Reflection.Emit.Label;

namespace Big_Project
{
    partial class DinamycAddModForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(50, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(499, 373);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(609, 300);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(117, 97);
            this.buttonSend.TabIndex = 2;
            this.buttonSend.Text = "button2";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // DinamycAddModForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.groupBox1);
            this.Name = "DinamycAddModForm";
            this.Text = "DinamycAddModForm";
            this.Load += new System.EventHandler(this.DinamycAddModForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private List<string> labelTexts;
        private List<System.Windows.Forms.Label> labels;
        private List<TextBox> textBoxes;
        private List<string> values;
        private bool isMod;
        private string connStr, tableName;
        private System.Windows.Forms.GroupBox groupBox1;
        private Button buttonSend;
    }
}