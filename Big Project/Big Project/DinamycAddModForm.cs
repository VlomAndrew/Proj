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
using Label = System.Reflection.Emit.Label;

namespace Big_Project
{
    public partial class DinamycAddModForm : Form
    {
        public DinamycAddModForm(string[] param, bool modify, string conn, string tName, List<string> vals = null)
        {
            labelTexts = new List<string>(param);
            isMod = modify;
            tableName = tName;
            connStr = conn;
            if(vals != null)
                values = new List<string>(vals);
            InitializeComponent();
        }

        private void DinamycAddModForm_Load(object sender, EventArgs e)
        {
            
            textBoxes = new List<TextBox>(labelTexts.Count);
            labels = new List<System.Windows.Forms.Label>(labelTexts.Count);
            for (int i = 1; i <= labelTexts.Count; i++)
            {
                var lab = new System.Windows.Forms.Label();
                var tb = new TextBox();
                lab.Text = labelTexts[i - 1];
                lab.Location = new Point(0, (tb.Height + 20)*i);
                tb.Location = new Point(100, (tb.Height + 20) * i);
                
                labels.Add(lab); 
                textBoxes.Add(tb);


            }
            groupBox1.Controls.AddRange(labels.ToArray());
            groupBox1.Controls.AddRange(textBoxes.ToArray());
            if (isMod)
            {
                buttonSend.Text = "Modify data";
                for (int i = 0; i < textBoxes.Count; i++)
                {
                    textBoxes[i].Text = values[i];
                }
            }
            else
            {
                buttonSend.Text = "Add data";
            }

            groupBox1.Text = tableName;
            if (tableName!="Room_info")
            textBoxes[0].ReadOnly = true;
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            string expr = string.Empty;
            if (!isMod)
            {
                switch (tableName)
                {
                    case "Client":
                    {
                            expr = string.Format("insert into Client values ('{0}','{1}','{2}','{3}')",textBoxes[1].Text,textBoxes[2].Text,textBoxes[3].Text,textBoxes[4].Text);

                            break;
                    }
                    case "Room":
                    {
                        expr = string.Format("insert into Room values ({0},{1})",textBoxes[1].Text,textBoxes[2].Text);
                        break;
                        
                    }

                    case "Room_info":
                    {
                        expr = string.Format("insert into Room_info values ({0},{1},{2},'{3}','{4}')", textBoxes[0].Text,
                            textBoxes[1].Text, textBoxes[2].Text, textBoxes[3].Text, textBoxes[4].Text);
                        break;
                    }
                    case "Employee":
                    {
                        expr = string.Format("insert into Employee values ('{0}','{1}','{2}')", textBoxes[1].Text,
                            textBoxes[2].Text, textBoxes[3].Text);
                            break;
                            
                        }

                    case "Service":
                    {
                        expr = string.Format("insert into Service values('{0}','{1}','{2}')", textBoxes[1].Text,
                            textBoxes[2].Text, textBoxes[3].Text);
                        break;
                        
                    }
                }

                try
                { 
                    SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder(connStr);
                SqlConnection conn = new SqlConnection(sb.ToString());
                conn.Open();
                SqlCommand comm = new SqlCommand(expr,conn);
                comm.ExecuteNonQuery();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }

            }
            else
            {
                switch (tableName)
                {
                    case "Client":
                        {
                            expr = string.Format("update Client set Name = '{0}', SerName = '{1}', Address = '{2}', Birthday = '{3}' where Id = {4}", textBoxes[1].Text, textBoxes[2].Text, textBoxes[3].Text, textBoxes[4].Text,textBoxes[0].Text);

                            break;
                        }
                    case "Room":
                        {
                            expr = string.Format("update Room set Type = {0}, Room_number = {1} where Id = {4}", textBoxes[1].Text, textBoxes[2].Text, textBoxes[0].Text);
                            break;

                        }

                    case "Room_info":
                        {
                            expr = string.Format("update Room_info set Room_id = {0}, Client_id = {1}, Service_id = {2}, Data_entr = '{3}', Data_leave = '{4}' where Room_id = {0}", textBoxes[0].Text, textBoxes[1].Text, textBoxes[2].Text, textBoxes[3].Text, textBoxes[4].Text);
                            break;
                        }
                    case "Employee":
                        {
                            expr = string.Format("update Employee set Name = '{0}', SerName = '{1}', Address = '{2}' where Id = {3}", textBoxes[1].Text, textBoxes[2].Text, textBoxes[3].Text, textBoxes[0].Text);
                            
                            break;

                        }

                    case "Service":
                    {
                        expr = string.Format(
                            "update Service set Type = '{0}', Employee_id = {1}, Time_table = '{2}' where Id = {3}",
                            textBoxes[1].Text, textBoxes[2].Text, textBoxes[3].Text, textBoxes[0].Text);
                            break;

                        }
                }

                try
                {
                    SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder(connStr);
                    SqlConnection conn = new SqlConnection(sb.ToString());
                    conn.Open();
                    SqlCommand comm = new SqlCommand(expr, conn);
                    comm.ExecuteNonQuery();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }

            MessageBox.Show("Success modyfiy");
            this.Close();
        }
    }
}
