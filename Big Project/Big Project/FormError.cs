using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Big_Project
{
    public partial class FormError : Form
    {
        public FormError(ResXResourceSet resX, ResXResourceSet globalResX, string errMsg)
        {
            
            InitializeComponent();
            resource = resX;
            globalRes = globalResX;
            errorMessage = errMsg;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
             
        }

        private void FormError_Load(object sender, EventArgs e)
        {
            labelServer.Text = resource.GetString("Lab_Serv_Name");
            labelDataBase.Text = resource.GetString("Lab_DB_Name");
            labelUser.Text = resource.GetString("Lab_User_Name");
            labelPassword.Text = resource.GetString("Lab_Pwd_Name");


            textBoxServer.Text = globalRes.GetString("server");
            textBoxDatabase.Text = globalRes.GetString("database");
            textBoxUser.Text = globalRes.GetString("user");
            textBoxPwd.Text = globalRes.GetString("password");

            buttonSaveReload.Text = resource.GetString("Btn_SaveAndRel");


            rTBError.Text = errorMessage;

            this.result = Auxiliary.States.Close;
        }

        private void buttonSaveReload_Click(object sender, EventArgs e)
        {
            using (ResXResourceWriter resWriter = new ResXResourceWriter(Auxiliary.ResxFilePath+ "Resources.resx"))
            {
                resWriter.AddResource("server",textBoxServer.Text);
                resWriter.AddResource("user", textBoxUser.Text);
                resWriter.AddResource("password", textBoxPwd.Text);
                resWriter.AddResource("database", textBoxDatabase.Text);

                resWriter.AddResource("timeout",globalRes.GetString("timeout"));
                resWriter.AddResource("Resource","ru");

            }

            result = Auxiliary.States.Reload;
            this.Close();
        }

        private void FormError_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void FormError_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
