using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace projectIMSBasicWFA
{
    class DBConnect
    {
        //public string ConnString = "Data Source=localhost; Initial Catalog=DBprojectIMSBasicWFA; Integrated Security=True";
        public string ConnString = "Data Source=DESKTOP-LPIKMUM; Initial Catalog=Northwind; Integrated Security=True";
        public string Sql { get; set; }
        public string SqlWhere { get; set; }
        public  SqlConnection SqlConn { get; set; }
        public SqlCommand Cmd { get; set; }
        public  SqlDataAdapter DA { get; set; }

        public string tableName = "";
        public string searchProperty = "";
        public int searchValue = 0;

        public DBConnect(string tableName)
        {
            Sql = "SELECT * FROM " + tableName;
            SqlConn = new SqlConnection(ConnString);
            Cmd = new SqlCommand(Sql, SqlConn);
            DA = new SqlDataAdapter(Cmd);
            SqlCommandBuilder cmdBuild = new SqlCommandBuilder(DA);
        }

        public DBConnect(string tableName, string sqlWhere)
        {
            Sql = "SELECT * FROM " + tableName + " WHERE " + sqlWhere;
            SqlConn = new SqlConnection(ConnString);
            Cmd = new SqlCommand(Sql, SqlConn);
            DA = new SqlDataAdapter(Cmd);
            SqlCommandBuilder cmdBuild = new SqlCommandBuilder(DA);
        }

    }

}
