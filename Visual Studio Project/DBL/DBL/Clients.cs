using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DBL
{
    public class Clients
    {
        String name;
        String username;
        String password;
        String mobile;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        public String Username
        {
            get { return username; }
            set { username = value; }
        }
        public String Password
        {
            get { return password; }
            set { password = value; }
        }
        public String Mobile
        {
            get { return mobile; }
            set { mobile = value; }
        }


        public void addClient(Clients obj)
        {
            String sql = "INSERT INTO clientstb VALUES ('" + obj.name + "','" + obj.username + "','" + obj.password + "','" + obj.mobile + "')";
            DBConnection dbcon = new DBConnection();
            dbcon.addvalues(sql);
        }
        public void deleteClient(Clients obj)
        {
            String sql = "DELETE FROM clientstb WHERE username = '" + obj.username + "'";
            DBConnection dbcon = new DBConnection();
            dbcon.addvalues(sql);
        }
        public SqlDataReader getClient(Clients obj)
        {
            String sql = "SELECT * FROM clientstb WHERE username = '" + obj.username + "'";
            DBConnection dbcon = new DBConnection();
            return dbcon.getdata(sql);
        }
    }
}
