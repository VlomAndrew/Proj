using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Big_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }

        private void ChangeAllText()
        {
           
            this.labelTableInfo.Text = resSource.GetString("LableName");
       
            this.Text = resSource.GetString("FormTitle");
            this.buttonConnect.Text = resSource.GetString("Btn_Conn");
        }


        private void DoReloadOrClose(Auxiliary.States whatDo)
        {
            
        }


        private void tabControlDisplayTableInfo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void Switch_lang()
        {
            if (lang == Language.ru)
            {
                cul = CultureInfo.CreateSpecificCulture("rus");
                resSource = new ResXResourceSet(Auxiliary.ResxFilePath+"Res.ru.resx");
            }
            else if (lang == Language.en)
            {
                cul = CultureInfo.CreateSpecificCulture("en");
                resSource = new ResXResourceSet(Auxiliary.ResxFilePath+"Res.en.resx");
            }
        }


        private void ParseIniFile()
        {
            var iniStrings = File.ReadAllLines(PathFileINI);
            connectionString = iniStrings[0].Substring(iniStrings[0].IndexOf('=') + 1);
            AuthConnString = iniStrings[1].Substring(iniStrings[1].IndexOf('=') + 1);
            adminDatabase = iniStrings[2].Substring(iniStrings[2].IndexOf('=') + 1);
            connectionStringToBackupOrRestore = iniStrings[3].Substring(iniStrings[3].IndexOf('=') + 1);
            FileToBackUp = iniStrings[4].Substring(iniStrings[4].IndexOf('=') + 1).Replace(@"\\",@"\");
        }
        private void ShowSucsessConnectionDlg()
        {
            string caption = resSource.GetString("DlgSuccessCaption"),
                text = resSource.GetString("DlgSuccessText");
            labelStat.Text = property.ToString();
            var res = MessageBox.Show(text+" ваши права доступа - "+property.ToString(), caption, MessageBoxButtons.OK);

        }

        private void LoadAdminDB()
        {
            SqlConnectionStringBuilder sqlBuider = new SqlConnectionStringBuilder(adminDatabase);

            SqlConnection adminConn = new SqlConnection(sqlBuider.ToString());

            string sqlExpr = @"select * from Users";

            SqlCommand adminCommand = new SqlCommand(sqlExpr,adminConn);

            SqlDataAdapter adapter = new SqlDataAdapter(adminCommand);

            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridViewAll.DataSource = dt;
            dataGridViewAll.AutoSize = true;
            dataGridViewAll.ReadOnly = true;
            adminConn.Close();

        }

        private void LoadMainDB()
        {
            try
            {
                SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder(connectionString);
            

            foreach (var tabl in tablesName)
            {
                string sqlExpr = @"select * from " + tabl;
                SqlConnection userConn = new SqlConnection(sqlBuilder.ToString());
                SqlCommand comm = new SqlCommand(sqlExpr,userConn);
                SqlDataAdapter adapter = new SqlDataAdapter(comm);

                DataTable dt = new DataTable();
                adapter.Fill(dt);
                comboBoxTables.Items.Add(tabl);
                tablesDict.Add(tabl,new DataTable());
                tablesDict[tabl] = dt;
                userConn.Close();
                comm.Dispose();
                adapter.Dispose();
            }

            comboBoxTables.SelectedIndex = 0;
            dataGridViewAll.DataSource = tablesDict[tablesName[0]];
            dataGridViewAll.AutoSize = true;
            dataGridViewAll.ReadOnly = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private void LoadInfoAboutTables(List<string> tables, string connectionString)
        {
            SqlConnection connection = null;
            try
            {
                SqlConnectionStringBuilder sqlBuider = new SqlConnectionStringBuilder(connectionString);
                connection = new SqlConnection(sqlBuider.ToString());
                connection.Open();
                int i = 0;
                foreach (var tab in tables)
                {

                    string sqlExpr =
                        string.Format(
                            "SELECT COLUMN_NAME as [column name], DATA_TYPE as [data type], IS_NULLABLE as [is null] FROM INFORMATION_SCHEMA.COLUMNS WHERE table_name = '{0}'",
                            tab);
                    SqlCommand comm = new SqlCommand(sqlExpr,connection);
                    var reader = comm.ExecuteReader();
                    var rtbx = new RichTextBox();
                    rtbx.Size = tabControlDisplayTableInfo.Controls[0].Size;
                    rtbx.ReadOnly = true;
                    while (reader.Read())
                    {
                        for (int j = 0; j < reader.FieldCount; j++)
                        {
                            rtbx.Text += string.Format(colNames[j] +" = " + reader[j].ToString() + " ; ");
                        }
                        rtbx.Text += "\n";

                    }
                    reader.Close();
                    reader.Dispose();
                    comm.Dispose();
                    tabControlDisplayTableInfo.Controls[i].Controls.Add(rtbx);
                    i++;
                }
                
                
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");

            }
            finally
            {
                connection?.Close();
            }
        }

        private void LoadTableInfo(string dataBaseToInfo)
        {
            SqlConnection connection = null;
            try
            {
                List<string> tables = new List<string>();
                SqlConnectionStringBuilder sqlBuider = new SqlConnectionStringBuilder(dataBaseToInfo);
                connection = new SqlConnection(sqlBuider.ToString());
                connection.Open();
                
                string SqlExpr = @"select table_name from information_schema.tables";
                SqlCommand comm = new SqlCommand(SqlExpr, connection);
                var reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        tables.Add(reader[i].ToString());
                    }
                }

                reader.Close();
                comm.Dispose();
                foreach (var table in tables)
                {
                    tabControlDisplayTableInfo.Controls.Add(new TabPage(table));   
                }
                connection.Close();
                LoadInfoAboutTables(tables,dataBaseToInfo);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");

            }
            finally
            {
                conn?.Close();
            }
            
        }


        private KeyValuePair<ErrorKeys,string> ConnectToDb()
        {
            
            string server = globalResourceSet.GetString("server"), database = globalResourceSet.GetString("database");
            int timeout = int.Parse(globalResourceSet.GetString("timeout"));
            KeyValuePair<ErrorKeys,string> resultConn;
            resultConn = new KeyValuePair<ErrorKeys, string>(ErrorKeys.SuccessConnection,"");
            try
            {
                SqlConnectionStringBuilder connString = Auxiliary.GetConnectionString(server, database, timeout);
                conn = new SqlConnection(connString.ToString());
                conn.Open();
            }
            catch (Exception e)
            {
                conn.Dispose();
                resultConn =  new KeyValuePair<ErrorKeys, string>(ErrorKeys.BadConnection, e.Message);
            }
            finally
            {
                conn.Close();
            }

            

            return resultConn;




        }
        private void Form1_Load(object sender, EventArgs e)
        {


            globalResourceSet = new ResXResourceSet(Auxiliary.ResxFilePath + "Resources.resx");
            cul = CultureInfo.CreateSpecificCulture(globalResourceSet.GetString("Resource"));
            if (globalResourceSet.GetString("Resource") == "ru")
                lang = Language.ru;
            else if (globalResourceSet.GetString("Resource") == "en")
                lang = Language.en;
                
            Switch_lang();
            ChangeAllText();

            buttonEng.FlatAppearance.BorderSize = 0;
            buttonEng.FlatStyle = FlatStyle.Flat;
            buttonRus.FlatAppearance.BorderSize = 0;
            buttonRus.FlatStyle = FlatStyle.Flat;

            ParseIniFile();

            colNames = new List<string>();
            colNames.Add("column name");
            colNames.Add("type");
            colNames.Add("is nullable");
            tablesDict = new Dictionary<string, DataTable>();
            comboBoxExpr.Items.AddRange(procedureExpresions.ToArray());
            comboBoxExpr.SelectedIndex = 0;

        }

        private void ShowExtentions()
        {
            comboBoxExpr.Visible = true;
            textBoxExpr.Visible = true;
            label1.Visible = true;
            buttonExpr.Visible = true;
        }

        private void SetAdmin()
        {
            
            buttonBackUp.Visible = true;
            buttonRestore.Visible = true;
            
            dataGridViewAll.ContextMenuStrip = contextMenuStripAdmin;
            LoadTableInfo(adminDatabase);
            LoadAdminDB();
        }

        private void SetReader()
        {
            
            ShowExtentions();
            LoadMainDB();
        }

        private void SetWriter()
        {

            dataGridViewAll.ContextMenuStrip = contextMenuStripWriter;
            ShowExtentions();
            LoadMainDB();
        }
        private void ChangeFormByProp()
        {
            switch (property)
            {
                case Auxiliary.Properties.admin:
                {
                    SetAdmin();
                    break;
                }
                case Auxiliary.Properties.writer:
                {
                    SetWriter();
                    break;
                }
                case Auxiliary.Properties.reader:
                {
                    SetReader();
                    break;
                }
            }
        }
        private void AuthenticationUser()
        {
            FormAuthentication fAuth = new FormAuthentication(resSource,this.AuthConnString);
            fAuth.ShowDialog();
            property = fAuth.userProperty;
            fAuth.Dispose();
            if (property == Auxiliary.Properties.CloseAll)
            {
                MessageBox.Show(resSource.GetString("Not_Auth"), "");
                this.Close();
            }
        }

        private void buttonRus_Click(object sender, EventArgs e)
        {
            lang = Language.ru;
            Switch_lang();
            ChangeAllText();
        }

        private void buttonEng_Click(object sender, EventArgs e)
        {
            lang = Language.en;
            Switch_lang();
            ChangeAllText();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            AuthenticationUser();
            //property = Auxiliary.Properties.writer;
            
            ConnectOrReconect();
            ChangeFormByProp();
            
        }

        private int ConnectOrReconect()
        {
            var connectResult = ConnectToDb();

            if (connectResult.Key == ErrorKeys.BadConnection)
            {
                FormError form = new FormError(resSource, globalResourceSet, connectResult.Value);
                form.ShowDialog();
                var resulFromErrForm = form.result;

                form.Dispose();

                if (resulFromErrForm == Auxiliary.States.Reload)
                {
                    globalResourceSet.Dispose();
                    globalResourceSet = new ResXResourceSet(Auxiliary.ResxFilePath+"Resources.resx");
                    ConnectOrReconect();
                }
                else if (resulFromErrForm == Auxiliary.States.Close)
                    return 0;


            }
            else if (connectResult.Key == ErrorKeys.SuccessConnection)
            {
                ShowSucsessConnectionDlg();
            }

            return 1;
        }
        private void buttonConnect_Click(object sender, EventArgs e)
        {
            ConnectOrReconect();
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewUserAdmin form = new NewUserAdmin(adminDatabase);
            form.ShowDialog();
            var res = form.resultOfAdd;
            form.Dispose();
            switch (res)
            {
                case Auxiliary.States.Close:
                {
                    break;
                    
                }
                case Auxiliary.States.Reload:
                {

                    dataGridViewAll.DataSource = null;
                    LoadAdminDB();
                    break;


                }
            }
            }

        private void modifySelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var row = dataGridViewAll.SelectedRows;
                var name = row[0].Cells[1].Value.ToString().Replace(" ","");
                var password = row[0].Cells[2].Value.ToString().Replace(" ", "");
                var perm = row[0].Cells[3].Value.ToString().Replace(" ", "");

                NewUserAdmin form = new NewUserAdmin(adminDatabase);
                form.Modify(name,password,perm);
                form.ShowDialog();
                var res = form.resultOfAdd;
                form.Dispose();
                switch (res)
                {
                    case Auxiliary.States.Close:
                    {
                        break;

                    }
                    case Auxiliary.States.Reload:
                    {

                        dataGridViewAll.DataSource = null;
                        LoadAdminDB();
                        break;


                    }
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error");
            }
            

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(adminDatabase);
            try
            {
                connection.Open();
                var row = dataGridViewAll.SelectedRows;
                var name = row[0].Cells[1].Value.ToString().Replace(" ", "");
                if (name == "admin")  
                    throw new Exception("admin cannot delete");
                string sqlExpr = string.Format("delete from Users where name = '{0}'", name);
                SqlCommand comm = new SqlCommand(sqlExpr,connection);

                var res = comm.ExecuteNonQuery();

                dataGridViewAll.DataSource = null;
                LoadAdminDB();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error");
            }
            finally
            {
                connection.Close();
            }
        }

        private void buttonBackUp_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionStringToBackupOrRestore);

            try
            {
                connection.Open();
                string sqlExpr = string.Format(@"backup database examdb to disk = '{0}examdb'",FileToBackUp).Replace(@"\\",@"\");
                string sqlExpr2 = string.Format(@"backup database authdb to disk = '{0}authdb'", FileToBackUp).Replace(@"\\", @"\");
                SqlCommand comm1 = new SqlCommand(sqlExpr,connection);

                var res = comm1.ExecuteNonQuery();
                comm1.Dispose();
                connection.Close();
                connection.Dispose();
                connection = new SqlConnection(connectionStringToBackupOrRestore);
                connection.Open();
                comm1 = new SqlCommand(sqlExpr2,connection);
                comm1.ExecuteNonQuery();
                comm1.Dispose();
                MessageBox.Show("Back up is success", "Message");

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error");
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }

        private void buttonRestore_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionStringToBackupOrRestore);
            
            try
            {
                connection.Open();
                string sqlExpr = string.Format(@"alter database [examdb] set single_user with rollback immediate; restore database examdb from disk = '{0}examdb' with replace;ALTER DATABASE [examdb] SET MULTI_USER;", FileToBackUp).Replace(@"\\", @"\");
                string sqlExpr2 = string.Format(@"alter database [authdb] set single_user with rollback immediate; restore database authdb from disk = '{0}authdb' with replace;ALTER DATABASE [authdb] SET MULTI_USER;", FileToBackUp).Replace(@"\\", @"\");
                SqlCommand comm1 = new SqlCommand(sqlExpr, connection);

                var res = comm1.ExecuteNonQuery();
                comm1.Dispose();
                connection.Close();
                connection.Dispose();
                connection = new SqlConnection(connectionStringToBackupOrRestore);
                connection.Open();
                comm1 = new SqlCommand(sqlExpr2, connection);
                comm1.ExecuteNonQuery();
                comm1.Dispose();
                SetAdmin();
                MessageBox.Show("Restore is success", "Message");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error");
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }

        private void comboBoxTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridViewAll.DataSource = tablesDict[tablesName[comboBoxTables.SelectedIndex]];
        }

        private void buttonExpr_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnectionStringBuilder sB = new SqlConnectionStringBuilder(connectionString);
                SqlConnection connection = new SqlConnection(sB.ToString());
                string expr = procedureDict[procedureExpresions[comboBoxExpr.SelectedIndex]] + " " + textBoxExpr.Text;
                SqlCommand command = new SqlCommand(expr,connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewAll.DataSource = dt;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);

            }
        }

        private void comboBoxExpr_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxExpr.ReadOnly = false;
            if (comboBoxExpr.SelectedIndex != 2)
            label1.Text = labelTextsList[comboBoxExpr.SelectedIndex];
            else
            {
                textBoxExpr.Text = string.Empty;
                textBoxExpr.ReadOnly = true;
                label1.Text = "Not need some params";
            }
        }

        private void abloutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox fAboutBox = new AboutBox();
            fAboutBox.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox fAboutBox = new AboutBox();
            
            fAboutBox.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            List<string> namesList = new List<string>();
            for (int i = 0; i < dataGridViewAll.ColumnCount; i++)
            {
                namesList.Add(dataGridViewAll.Columns[i].HeaderText);
            }

            DinamycAddModForm f = new DinamycAddModForm(namesList.ToArray(), false, connectionString,
                tablesName[comboBoxTables.SelectedIndex]);

            f.ShowDialog();
            try
            {
                SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder(connectionString);
                string sqlExpr = @"select * from " + tablesName[comboBoxTables.SelectedIndex];
                SqlConnection userConn = new SqlConnection(sqlBuilder.ToString());
                SqlCommand comm = new SqlCommand(sqlExpr, userConn);
                SqlDataAdapter adapter = new SqlDataAdapter(comm);

                DataTable dt = new DataTable();
                adapter.Fill(dt);
                tablesDict[comboBoxTables.SelectedText.ToString()] = dt;
                dataGridViewAll.DataSource = dt;


            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            var row = dataGridViewAll.SelectedRows;
            List<string> valuesList = new List<string>();
            for (int i = 0; i < dataGridViewAll.ColumnCount; i++)
            {
                var zap = row[0].Cells[i].Value.ToString();
                if (zap.Contains("0:00:00")) 
                    zap = zap.Replace("0:00:00", "");
                valuesList.Add(zap.Replace(" ",""));
            }
            List<string> namesList = new List<string>();
            for (int i = 0; i < dataGridViewAll.ColumnCount; i++)
            {
                namesList.Add(dataGridViewAll.Columns[i].HeaderText);
            }
            DinamycAddModForm f = new DinamycAddModForm(namesList.ToArray(), true, connectionString, tablesName[comboBoxTables.SelectedIndex],valuesList);

            f.ShowDialog();
            try
            {
                SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder(connectionString);
                string sqlExpr = @"select * from " + tablesName[comboBoxTables.SelectedIndex];
                SqlConnection userConn = new SqlConnection(sqlBuilder.ToString());
                SqlCommand comm = new SqlCommand(sqlExpr, userConn);
                SqlDataAdapter adapter = new SqlDataAdapter(comm);

                DataTable dt = new DataTable();
                adapter.Fill(dt);
                tablesDict[comboBoxTables.SelectedText.ToString()] = dt;
                dataGridViewAll.DataSource = dt;


            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        //.Rows[0].Cells[i].Value.ToString()
    }
}
