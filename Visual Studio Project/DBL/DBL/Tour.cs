using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DBL
{
    public class Tour
    {
        String tourfrom;
        String tourto;
        String tourkm;
        String touramount;

        String id;

        public String Tourfrom
        {
            get { return tourfrom; }
            set { tourfrom = value; }
        }
        public String Tourto
        {
            get { return tourto; }
            set { tourto = value; }
        }
        public String Tourkm
        {
            get { return tourkm; }
            set { tourkm = value; }
        }
        public String Touramount
        {
            get { return touramount; }
            set { touramount = value; }
        }
        public String Id
        {
            get { return id; }
            set { id = value; }
        }

        public void addTour(Tour obj)
        {
            String sql = "INSERT INTO tourtb VALUES ('" + obj.tourfrom + "','" + obj.tourto + "','" + obj.tourkm + "','" + obj.touramount + "')";
            DBConnection dbcon = new DBConnection();
            dbcon.addvalues(sql);
        }
        public void deleteTour(Tour obj)
        {
            String sql = "DELETE FROM tourtb WHERE ID = '" + obj.id + "'";
            DBConnection dbcon = new DBConnection();
            dbcon.addvalues(sql);
        }
        public SqlDataReader getTour(Tour obj)
        {
            String sql = "SELECT * FROM tourtb WHERE ID = '" + obj.id + "'";
            DBConnection dbcon = new DBConnection();
            return dbcon.getdata(sql);
        }

    }
}
