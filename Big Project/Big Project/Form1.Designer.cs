using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Resources;
using System.Windows.Forms;

namespace Big_Project
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControlDisplayTableInfo = new System.Windows.Forms.TabControl();
            this.labelTableInfo = new System.Windows.Forms.Label();
            this.buttonRus = new System.Windows.Forms.Button();
            this.buttonEng = new System.Windows.Forms.Button();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.dataGridViewAll = new System.Windows.Forms.DataGridView();
            this.contextMenuStripAdmin = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifySelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonBackUp = new System.Windows.Forms.Button();
            this.buttonRestore = new System.Windows.Forms.Button();
            this.comboBoxTables = new System.Windows.Forms.ComboBox();
            this.comboBoxExpr = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxExpr = new System.Windows.Forms.TextBox();
            this.buttonExpr = new System.Windows.Forms.Button();
            this.labelStat = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripWriter = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAll)).BeginInit();
            this.contextMenuStripAdmin.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStripWriter.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlDisplayTableInfo
            // 
            this.tabControlDisplayTableInfo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tabControlDisplayTableInfo.Location = new System.Drawing.Point(949, 85);
            this.tabControlDisplayTableInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControlDisplayTableInfo.Multiline = true;
            this.tabControlDisplayTableInfo.Name = "tabControlDisplayTableInfo";
            this.tabControlDisplayTableInfo.SelectedIndex = 0;
            this.tabControlDisplayTableInfo.Size = new System.Drawing.Size(489, 114);
            this.tabControlDisplayTableInfo.TabIndex = 0;
            this.tabControlDisplayTableInfo.SelectedIndexChanged += new System.EventHandler(this.tabControlDisplayTableInfo_SelectedIndexChanged);
            // 
            // labelTableInfo
            // 
            this.labelTableInfo.AutoSize = true;
            this.labelTableInfo.Location = new System.Drawing.Point(951, 49);
            this.labelTableInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTableInfo.Name = "labelTableInfo";
            this.labelTableInfo.Size = new System.Drawing.Size(46, 17);
            this.labelTableInfo.TabIndex = 1;
            this.labelTableInfo.Text = "label1";
            this.labelTableInfo.Visible = false;
            // 
            // buttonRus
            // 
            this.buttonRus.Image = ((System.Drawing.Image)(resources.GetObject("buttonRus.Image")));
            this.buttonRus.Location = new System.Drawing.Point(1364, 753);
            this.buttonRus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonRus.Name = "buttonRus";
            this.buttonRus.Size = new System.Drawing.Size(33, 31);
            this.buttonRus.TabIndex = 4;
            this.buttonRus.UseVisualStyleBackColor = true;
            this.buttonRus.Click += new System.EventHandler(this.buttonRus_Click);
            // 
            // buttonEng
            // 
            this.buttonEng.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonEng.BackgroundImage")));
            this.buttonEng.Image = ((System.Drawing.Image)(resources.GetObject("buttonEng.Image")));
            this.buttonEng.Location = new System.Drawing.Point(1405, 753);
            this.buttonEng.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonEng.Name = "buttonEng";
            this.buttonEng.Size = new System.Drawing.Size(33, 31);
            this.buttonEng.TabIndex = 5;
            this.buttonEng.UseVisualStyleBackColor = true;
            this.buttonEng.Click += new System.EventHandler(this.buttonEng_Click);
            // 
            // buttonConnect
            // 
            this.buttonConnect.AutoSize = true;
            this.buttonConnect.Location = new System.Drawing.Point(1264, 49);
            this.buttonConnect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(175, 28);
            this.buttonConnect.TabIndex = 8;
            this.buttonConnect.Text = "button1";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Visible = false;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // dataGridViewAll
            // 
            this.dataGridViewAll.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAll.Location = new System.Drawing.Point(40, 159);
            this.dataGridViewAll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewAll.Name = "dataGridViewAll";
            this.dataGridViewAll.RowHeadersWidth = 51;
            this.dataGridViewAll.Size = new System.Drawing.Size(741, 427);
            this.dataGridViewAll.TabIndex = 9;
            // 
            // contextMenuStripAdmin
            // 
            this.contextMenuStripAdmin.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripAdmin.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addUserToolStripMenuItem,
            this.modifySelectedToolStripMenuItem,
            this.toolStripMenuItem1});
            this.contextMenuStripAdmin.Name = "contextMenuStripAdmin";
            this.contextMenuStripAdmin.Size = new System.Drawing.Size(185, 76);
            // 
            // addUserToolStripMenuItem
            // 
            this.addUserToolStripMenuItem.Name = "addUserToolStripMenuItem";
            this.addUserToolStripMenuItem.Size = new System.Drawing.Size(184, 24);
            this.addUserToolStripMenuItem.Text = "Add user";
            this.addUserToolStripMenuItem.Click += new System.EventHandler(this.addUserToolStripMenuItem_Click);
            // 
            // modifySelectedToolStripMenuItem
            // 
            this.modifySelectedToolStripMenuItem.Name = "modifySelectedToolStripMenuItem";
            this.modifySelectedToolStripMenuItem.Size = new System.Drawing.Size(184, 24);
            this.modifySelectedToolStripMenuItem.Text = "Modify selected";
            this.modifySelectedToolStripMenuItem.Click += new System.EventHandler(this.modifySelectedToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(184, 24);
            this.toolStripMenuItem1.Text = "Delete user";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // buttonBackUp
            // 
            this.buttonBackUp.Location = new System.Drawing.Point(1288, 368);
            this.buttonBackUp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonBackUp.Name = "buttonBackUp";
            this.buttonBackUp.Size = new System.Drawing.Size(151, 74);
            this.buttonBackUp.TabIndex = 10;
            this.buttonBackUp.Text = "Back up all database";
            this.buttonBackUp.UseVisualStyleBackColor = true;
            this.buttonBackUp.Visible = false;
            this.buttonBackUp.Click += new System.EventHandler(this.buttonBackUp_Click);
            // 
            // buttonRestore
            // 
            this.buttonRestore.Location = new System.Drawing.Point(949, 368);
            this.buttonRestore.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonRestore.Name = "buttonRestore";
            this.buttonRestore.Size = new System.Drawing.Size(151, 74);
            this.buttonRestore.TabIndex = 11;
            this.buttonRestore.Text = "Restore all database";
            this.buttonRestore.UseVisualStyleBackColor = true;
            this.buttonRestore.Visible = false;
            this.buttonRestore.Click += new System.EventHandler(this.buttonRestore_Click);
            // 
            // comboBoxTables
            // 
            this.comboBoxTables.FormattingEnabled = true;
            this.comboBoxTables.Location = new System.Drawing.Point(527, 110);
            this.comboBoxTables.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxTables.Name = "comboBoxTables";
            this.comboBoxTables.Size = new System.Drawing.Size(253, 24);
            this.comboBoxTables.TabIndex = 12;
            this.comboBoxTables.SelectedIndexChanged += new System.EventHandler(this.comboBoxTables_SelectedIndexChanged);
            // 
            // comboBoxExpr
            // 
            this.comboBoxExpr.FormattingEnabled = true;
            this.comboBoxExpr.Location = new System.Drawing.Point(949, 218);
            this.comboBoxExpr.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxExpr.Name = "comboBoxExpr";
            this.comboBoxExpr.Size = new System.Drawing.Size(253, 24);
            this.comboBoxExpr.TabIndex = 13;
            this.comboBoxExpr.Visible = false;
            this.comboBoxExpr.SelectedIndexChanged += new System.EventHandler(this.comboBoxExpr_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1117, 267);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // textBoxExpr
            // 
            this.textBoxExpr.Location = new System.Drawing.Point(949, 258);
            this.textBoxExpr.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxExpr.Name = "textBoxExpr";
            this.textBoxExpr.Size = new System.Drawing.Size(129, 22);
            this.textBoxExpr.TabIndex = 15;
            this.textBoxExpr.Visible = false;
            // 
            // buttonExpr
            // 
            this.buttonExpr.Location = new System.Drawing.Point(949, 304);
            this.buttonExpr.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonExpr.Name = "buttonExpr";
            this.buttonExpr.Size = new System.Drawing.Size(131, 28);
            this.buttonExpr.TabIndex = 16;
            this.buttonExpr.Text = "Send Expression";
            this.buttonExpr.UseVisualStyleBackColor = true;
            this.buttonExpr.Visible = false;
            this.buttonExpr.Click += new System.EventHandler(this.buttonExpr_Click);
            // 
            // labelStat
            // 
            this.labelStat.AutoSize = true;
            this.labelStat.Location = new System.Drawing.Point(1392, 570);
            this.labelStat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStat.Name = "labelStat";
            this.labelStat.Size = new System.Drawing.Size(46, 17);
            this.labelStat.TabIndex = 17;
            this.labelStat.Text = "label2";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.infoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1455, 28);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.infoToolStripMenuItem.Text = "Info";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(133, 26);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // contextMenuStripWriter
            // 
            this.contextMenuStripWriter.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripWriter.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.contextMenuStripWriter.Name = "contextMenuStripAdmin";
            this.contextMenuStripWriter.ShowImageMargin = false;
            this.contextMenuStripWriter.Size = new System.Drawing.Size(186, 80);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(185, 24);
            this.toolStripMenuItem2.Text = "Add user";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(185, 24);
            this.toolStripMenuItem3.Text = "Modify selected";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1455, 799);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.labelStat);
            this.Controls.Add(this.buttonExpr);
            this.Controls.Add(this.textBoxExpr);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxExpr);
            this.Controls.Add(this.comboBoxTables);
            this.Controls.Add(this.buttonRestore);
            this.Controls.Add(this.buttonBackUp);
            this.Controls.Add(this.dataGridViewAll);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.buttonEng);
            this.Controls.Add(this.buttonRus);
            this.Controls.Add(this.labelTableInfo);
            this.Controls.Add(this.tabControlDisplayTableInfo);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAll)).EndInit();
            this.contextMenuStripAdmin.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStripWriter.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        enum ErrorKeys
        {
            BadConnection = 1,
            SuccessConnection = 2
        }

        enum Language
        {
            ru,
            en
        }

        

        private ResXResourceSet resSource, globalResourceSet;
        private CultureInfo cul;
        private Language lang;
        private SqlConnection conn;

        private Dictionary<string, DataTable> tablesDict;
        private List<string> tablesName = new List<string> {"Client","Room_info","Employee","Room","Service"};
        private Dictionary<string,string> procedureDict = new Dictionary<string, string>() {{"Get info about room","Get_Room"},{"Get info about some employee", "Get_All_Employee_Info_By_Service_Type" }, {"Get employee amd thier rooms", "Get_All_Employee" } };
        private List<string> procedureExpresions = new List<string>() {"Get info about room","Get info about some employee", "Get employee amd thier rooms" };
        private List<string> labelTextsList = new List<string>(){"Select room number", "Select service type"};
        private Auxiliary.Properties property;

        private List<string> colNames;

        private string FileToBackUp;

        private string AuthConnString;
        private string adminDatabase;
        private string connectionStringToBackupOrRestore;
        private string connectionString;
        private string PathFileINI = @"C:\Users\andre\Desktop\Big Project\Big Project\bin\Debug\File.ini";

        //private static string ResxFilePath = @"C:\Users\Андрей\Documents\Stud Projects\Big Project\Big Project\Properties\";


        private System.Windows.Forms.TabControl tabControlDisplayTableInfo;
        private System.Windows.Forms.Label labelTableInfo;
        private System.Windows.Forms.Button buttonRus;
        private System.Windows.Forms.Button buttonEng;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.DataGridView dataGridViewAll;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripAdmin;
        private System.Windows.Forms.ToolStripMenuItem addUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifySelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Button buttonBackUp;
        private System.Windows.Forms.Button buttonRestore;
        private System.Windows.Forms.ComboBox comboBoxTables;
        private System.Windows.Forms.ComboBox comboBoxExpr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxExpr;
        private System.Windows.Forms.Button buttonExpr;
        private Label labelStat;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem infoToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ContextMenuStrip contextMenuStripWriter;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
    }
}

