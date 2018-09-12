using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DBL
{
    public class DBConnection
    {
        SqlConnection con;

        public SqlConnection createConnection()
        {
            con = new SqlConnection("Data Source=ASLAM;Initial Catalog=aslamb;Integrated Security=True; User ID=, Password=");
            try
            {
                con.Open();
                return con;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                con = null;
                return con;
            }

        }



        public void addvalues(string Sql)
        {
            con = createConnection();
            SqlCommand cmd = new SqlCommand(Sql, con);
            cmd.ExecuteNonQuery();
        }

        public SqlDataReader getdata(String SQL)
        {
            con = createConnection();
            SqlCommand comm = new SqlCommand();

            comm.CommandText = SQL;
            comm.Connection = con;

            SqlDataReader sqlDReader;

            sqlDReader = comm.ExecuteReader();

            return sqlDReader;
        }
    }
}

