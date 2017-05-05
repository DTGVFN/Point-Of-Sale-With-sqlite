using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.Windows.Forms;

namespace pos2017.DB
{
    class DB_Connect
    {
        public const string Connection_String = "Data Source=data.sqlite;Version=3;";
        public static SQLiteConnection POSCONNECTMYSQL = new SQLiteConnection();

        public static DataTable SqlCommandToDataTable(string sql)
        {
            if (POSCONNECTMYSQL.State.ToString() == "Closed")
            {
                POSCONNECTMYSQL.ConnectionString = Connection_String;
                POSCONNECTMYSQL.Open();
            }
           
            SQLiteDataAdapter da = new SQLiteDataAdapter(sql, POSCONNECTMYSQL);
            da.SelectCommand.CommandTimeout = 10;
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
    }
}
