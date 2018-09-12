using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DBL
{
    public class Driver
    {
        String name;
        String username;
        String password;
        String mobile;
        String branch;
        String status;
        String taxi;

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
        public String Branch
        {
            get { return branch; }
            set { branch = value; }
        }
        public String Status
        {
            get { return status; }
            set { status = value; }
        }
        public String Taxi
        {
            get { return taxi; }
            set { taxi = value; }
        }

        public void addDriver(Driver obj)
        {
            String sql = "INSERT INTO drivertb VALUES ('" + obj.name + "','" + obj.username + "','" + obj.password + "','" + obj.mobile + "','" + obj.branch + "', '" + obj.status + "', '" + obj.taxi + "')";
            DBConnection dbcon = new DBConnection();
            dbcon.addvalues(sql);
        }
        public void deleteDriver(Driver obj)
        {
            String sql = "DELETE FROM drivertb WHERE taxi = '" + obj.taxi + "'";
            DBConnection dbcon = new DBConnection();
            dbcon.addvalues(sql);
        }
        public void statusDriver(Driver obj)
        {
            String sql = "UPDATE drivertb SET status='"+obj.status+"' WHERE taxi = '" + obj.taxi + "'";
            DBConnection dbcon = new DBConnection();
            dbcon.addvalues(sql);
        }
        public SqlDataReader getDriver(Driver obj)
        {
            String sql = "SELECT * FROM drivertb WHERE taxi = '" + obj.taxi + "'";
            DBConnection dbcon = new DBConnection();
            return dbcon.getdata(sql);
        }
    }
}
