using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace Big_Project
{
    public partial class FormAuthentication : Form
    {
        public FormAuthentication(ResXResourceSet langResource, string connectionString)
        {

            this.langRes = langResource;
            this.connString = connectionString;
            InitializeComponent();
        }

        private void Registration()
        {
            SqlConnection conn = null;

            try
            {
                SqlConnectionStringBuilder connBuilder = new SqlConnectionStringBuilder(connString);
                connBuilder.ConnectTimeout = 5;
                conn = new SqlConnection(connBuilder.ToString());
                conn.Open();
                string sqlExpr =
                    string.Format(
                        "select name from users where name = '{0}'",
                        textBoxUserName.Text);
                var command = new SqlCommand(sqlExpr, conn);
                var reader = command.ExecuteReader();
                if (!reader.Read())
                {
                    reader.Close();
                    string SqlRegExpr =
                        string.Format("insert into Users (name,password,type) values ('{0}','{1}',2)", textBoxUserName.Text,
                            textBoxPassword.Text);
                    var comm = new SqlCommand(SqlRegExpr,conn);
                    var resReg = comm.ExecuteNonQuery();
                    MessageBox.Show(langRes.GetString("Succ_Reg"), "");
                    ConnectToUsersDB();
                }



            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "error");
            }
            finally
            {

            }
        }

        private void ConnectToUsersDB()
        {
            SqlConnection conn = null;

            try
            {
                SqlConnectionStringBuilder connBuilder = new SqlConnectionStringBuilder(connString);
            connBuilder.ConnectTimeout = 5;
                conn = new SqlConnection(connBuilder.ToString());
                conn.Open();
                string sqlExpr =
                    string.Format("select Permissions from User_Prop where type in (select type from Users where name = '{0}' and password = '{1}')",textBoxUserName.Text,textBoxPassword.Text);
                var command = new SqlCommand(sqlExpr, conn);
                var reader = command.ExecuteReader();
                reader.Read();
                var prop = reader[0].ToString().Replace(" ","");
                switch (prop)
                {
                    case "admin":
                    {
                        userProperty = Auxiliary.Properties.admin;
                        conn.Close();
                        this.Close();
                            break;
                    }
                    case "reader":
                    {
                        userProperty = Auxiliary.Properties.reader;
                        conn.Close();
                        this.Close();
                            break;
                    }
                    case "writer":
                    {
                        userProperty = Auxiliary.Properties.writer;
                        conn.Close();
                        this.Close();
                            break;
                    }
                    default:
                        MessageBox.Show(langRes.GetString("ErrText"), "");
                        break;
                }

                
                conn.Close();
          



            }
            catch (Exception e)
            {
                MessageBox.Show(langRes.GetString("ErrText"), "Error");
            }
            finally
            {
                conn?.Close();
            }
        }

        private void FormAuthentication_Load(object sender, EventArgs e)
        {
            this.Text = langRes.GetString("Form_Auth_Name");
            labelUser.Text = langRes.GetString("Lab_User_Auth");
            labelPass.Text = langRes.GetString("Lab_User_Pass");
            buttonAuth.Text = langRes.GetString("Btn_Login");
            buttonRegistr.Text = langRes.GetString("Btn_Reg");
            textBoxPassword.UseSystemPasswordChar = true;
            userProperty = Auxiliary.Properties.CloseAll;
        }

        private void buttonAuth_Click(object sender, EventArgs e)
        {
            ConnectToUsersDB();
        }


        
        private void buttonUnPassw_Click(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = !textBoxPassword.UseSystemPasswordChar;
            

        }

        private void buttonRegistr_Click(object sender, EventArgs e)
        {
            Registration();
        }
    }
}
