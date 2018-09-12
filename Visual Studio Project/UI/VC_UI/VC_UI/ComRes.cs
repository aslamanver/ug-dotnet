using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DBL;

namespace VC_UI
{
    public partial class ComRes : Form
    {
        public ComRes()
        {
            InitializeComponent();
            panelCom.Hide();
        }

        private void buttonComFind_Click(object sender, EventArgs e)
        {
            DBL.Res res = new DBL.Res();
            res.Cab = textBoxComCab.Text;
            SqlDataReader rdr = res.getResCom(res);
            if (rdr.Read())
            {
                labelComCab.Text = rdr["taxi"].ToString();
                labelComClient.Text = rdr["client"].ToString();
                labelComFrom.Text = rdr["tourfrom"].ToString();
                labelComTo.Text = rdr["tourto"].ToString();
                labelComAmount.Text = rdr["amount"].ToString();
                labelComKM.Text = rdr["km"].ToString();
                labelComDate.Text = rdr["date"].ToString();
                panelCom.Show();
            }
            else
            {
                MessageBox.Show("Not Found","Error",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                panelCom.Hide();
            }
            
        }

        private void buttonComComplete_Click(object sender, EventArgs e)
        {
            if (richTextBoxComComment.Text == "")
            {
                MessageBox.Show("Please type any comment", "Error");
            }
            else
            {
                try
                {
                    DBL.Res res = new DBL.Res();
                    res.Cab = labelComCab.Text;
                    res.Comment = richTextBoxComComment.Text;
                    res.statusRes(res);

                    DBL.Driver cab = new DBL.Driver();
                    cab.Taxi = labelComCab.Text;
                    cab.Status = "available";
                    cab.statusDriver(cab);

                    MessageBox.Show("Success", "Success");

                    manage.refreshResTableFromOut();

                    this.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        private void buttonComFailed_Click(object sender, EventArgs e)
        {
            if (richTextBoxComComment.Text == "")
            {
                MessageBox.Show("Please type any comment", "Error");
            }
            else
            {
                try
                {
                    DBL.Res res = new DBL.Res();
                    res.Cab = labelComCab.Text;
                    res.Comment = richTextBoxComComment.Text;
                    res.statusResFailed(res);

                    DBL.Driver cab = new DBL.Driver();
                    cab.Taxi = labelComCab.Text;
                    cab.Status = "available";
                    cab.statusDriver(cab);

                    MessageBox.Show("Success", "Success");

                    manage.refreshResTableFromOut();

                    this.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        private void buttonComCancel_Click(object sender, EventArgs e)
        {
            if (richTextBoxComComment.Text == "")
            {
                MessageBox.Show("Please type any comment", "Error");
            }
            else
            {
                try
                {
                    DBL.Res res = new DBL.Res();
                    res.Cab = labelComCab.Text;
                    res.Comment = richTextBoxComComment.Text;
                    res.statusResCanceled(res);

                    DBL.Driver cab = new DBL.Driver();
                    cab.Taxi = labelComCab.Text;
                    cab.Status = "available";
                    cab.statusDriver(cab);

                    MessageBox.Show("Success", "Success");

                    manage.refreshResTableFromOut();

                    this.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }


    }
}
