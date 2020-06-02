using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Big_Project
{
    public sealed class Auxiliary
    {

        
        public enum States
        {
            Reload,
            Close
        }

        public enum Properties
        {
            admin,
            reader,
            writer,
            CloseAll
        }

        

        public static string ResxFilePath = @"C:\Users\andre\Desktop\Big Project\Big Project\Properties\";
        public static SqlConnectionStringBuilder GetConnectionString(string server, string database,int timeout = 5)
        {

            string strConn =  string.Format("Server ={0}; Database ={1}; Trusted_Connection = True", server, database);
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(strConn);
            builder.ConnectTimeout = timeout;
            return builder;
        }


        public static SqlConnection GetConnection(string connString)
        {
            return  new SqlConnection(connString);
        }

    }
}
