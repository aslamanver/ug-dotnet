using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DBL
{
    public class User
    {
        string Name;
        string Username;
        string Password;
        string Mobile;
        string Branch;

        public string Name1
        {
            get { return Name; }
            set { Name = value; }
        }
        public string Username1
        {
            get { return Username; }
            set { Username = value; }
        }
        public string Password1
        {
            get { return Password; }
            set { Password = value; }
        }
        public string Mobile1
        {
            get { return Mobile; }
            set { Mobile = value; }
        }
        public string Branch1
        {
            get { return Branch; }
            set { Branch = value; }
        }

        public void addUser(User obj)
        {
            String sql = "INSERT INTO userstb VALUES ('" + obj.Name + "','" + obj.Username + "','" + obj.Password + "','" + obj.Mobile + "','" + obj.Branch + "')";
            DBConnection dbcon = new DBConnection();
            dbcon.addvalues(sql);
        }
        public void deleteUser(User obj)
        {
            String sql = "DELETE FROM userstb WHERE username = '"+obj.Username+"'";
            DBConnection dbcon = new DBConnection();
            dbcon.addvalues(sql);
        }
        public SqlDataReader getUser(User obj)
        {
            String sql = "SELECT * FROM userstb WHERE username = '" + obj.Username + "'";
            DBConnection dbcon = new DBConnection();
            return dbcon.getdata(sql);
        }

        public bool IsValidUser(User obj)
        {
            String sql = "SELECT * FROM userstb WHERE username = '" + obj.Username + "' and password = '"+ obj.Password +"'";
            DBConnection dbcon = new DBConnection();

            if (dbcon.getdata(sql).Read())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsHeadOfficeUser(User obj)
        {
            String sql = "SELECT * FROM userstb WHERE username = '" + obj.Username + "' and branch = 'head'";
            DBConnection dbcon = new DBConnection();

            if (dbcon.getdata(sql).Read())
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
