using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Big_Project
{
    public partial class NewUserAdmin : Form
    {
        public NewUserAdmin(string databaseString)
        {
            connString = databaseString;
            InitializeComponent();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }

        public void Modify(string name, string pass, string type)
        {
            textBox1.Text = name;
            textBox2.Text = pass;
            textBox3.Text = type;
            textBox1.ReadOnly = true;
            button1.Text = "Modify user acc";
            modify = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                string sqlExpr;
                if (modify)
                {
                    sqlExpr = string.Format("update Users set password='{0}', type={1} where name='{2}'", textBox2.Text,
                        textBox3.Text,
                        textBox1.Text);
                }
                else
                {
                    sqlExpr = string.Format("insert into Users values ('{0}','{1}',{2})", textBox1.Text,
                        textBox2.Text,
                        textBox3.Text);
                }

                SqlCommand comm = new SqlCommand(sqlExpr, conn);
                var res = comm.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                resultOfAdd = Auxiliary.States.Close;
                MessageBox.Show(exception.Message, "Error");
                this.Close();
            }
            finally
            {
                conn.Close();
            }

            resultOfAdd = Auxiliary.States.Reload;
            this.Close();
        }
    }
}
