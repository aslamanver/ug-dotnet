using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DBL
{
    public class Res
    {
        String id;
        String client;
        String tourfrom;
        String tourto;
        String tourkm;
        String touramount;
        String cab;
        String date;
        String comment;
        String status;

        public String Id
        {
            get { return id; }
            set { id = value; }
        }
        public String Client
        {
            get { return client; }
            set { client = value; }
        }
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
        public String Cab
        {
            get { return cab; }
            set { cab = value; }
        }
        public String Date
        {
            get { return date; }
            set { date = value; }
        }
        public String Comment
        {
            get { return comment; }
            set { comment = value; }
        }
        public String Status
        {
            get { return status; }
            set { status = value; }
        }


        public void addRes(Res obj)
        {
            String sql = "INSERT INTO restb VALUES ('" + obj.client + "','" + obj.tourfrom + "','" + obj.tourto + "','" + obj.tourkm + "','" + obj.touramount + "','" + obj.cab + "','" + obj.date + "','" + obj.comment + "','" + obj.status + "')";
            DBConnection dbcon = new DBConnection();
            dbcon.addvalues(sql);
        }
        public void statusRes(Res obj)
        {
            String sql = "UPDATE restb SET comment='" + obj.comment + "',status='completed' WHERE taxi = '" + obj.cab + "' and status = 'hire' ";
            DBConnection dbcon = new DBConnection();
            dbcon.addvalues(sql);
        }
        public void statusResFailed(Res obj)
        {
            String sql = "UPDATE restb SET comment='" + obj.comment + "',status='failed' WHERE taxi = '" + obj.cab + "' and status = 'hire' ";
            DBConnection dbcon = new DBConnection();
            dbcon.addvalues(sql);
        }
        public void statusResCanceled(Res obj)
        {
            String sql = "UPDATE restb SET comment='" + obj.comment + "',status='canceled' WHERE taxi = '" + obj.cab + "' and status = 'hire' ";
            DBConnection dbcon = new DBConnection();
            dbcon.addvalues(sql);
        }
        public SqlDataReader getRes(Res obj)
        {
            String sql = "SELECT * FROM restb WHERE ID = '" + obj.id + "'";
            DBConnection dbcon = new DBConnection();
            return dbcon.getdata(sql);
        }
        public SqlDataReader getResCom(Res obj)
        {
            String sql = "SELECT * FROM restb WHERE status ='hire' and taxi = '" + obj.cab + "'";
            DBConnection dbcon = new DBConnection();
            return dbcon.getdata(sql);
        }

    }
}
