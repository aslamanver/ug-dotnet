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
    public partial class manage : Form
    {
        private static manage _instance;

        SqlConnection con = new SqlConnection("Data Source=ASLAM;Initial Catalog=aslamb;Integrated Security=True; User ID=, Password=");
        SqlCommandBuilder cmbl;
        SqlDataAdapter adap;
        DataSet ds;
        String CurrentUser;

        public manage(String CU)
        {
            this.CurrentUser = CU;

            InitializeComponent();
            _instance = this;
            
            labelCU.Text = "Logged In : " + this.CurrentUser;
            labelDate.Text = "Date "+DateTime.Now.ToString("yyyy-M-dd");
            comboBoxResTo.Enabled = false;
            comboBoxResCab.Enabled = false;
            labelResAmount.Text = "";
            labelResKm.Text = "";


            DBL.User ust = new DBL.User();
            ust.Username1 = this.CurrentUser;
            if (ust.IsHeadOfficeUser(ust))
            {
                groupBoxUsers.Enabled = true;
                groupBoxTours.Enabled = true;
                groupBoxDrivers.Enabled = true;

                labelUser.Text = "User Management";
                labelDriver.Text = "Driver Management";
                labelTour.Text = "Tour Management";
            }
            else
            {
                groupBoxUsers.Enabled = false;
                groupBoxTours.Enabled = false;
                groupBoxDrivers.Enabled = false;

                labelUser.Text = "User Management (Only for Head Ofiice)";
                labelDriver.Text = "Driver Management (Only for Head Ofiice)";
                labelTour.Text = "Tour Management (Only for Head Ofiice)";

                dataGridViewUsers.Enabled = false;
                dataGridViewTour.Enabled = false;
                dataGridViewCab.Enabled = false;
            }
            
            allTourTable();
            allUserTable();
            allCabTable();
            allClientTable();
            curResTable();
            comboboxes();

            this.FormClosing += new FormClosingEventHandler(manage_FormClosing);
            this.WindowState = FormWindowState.Maximized;

        }

        private void buttonSearchUsers_Click(object sender, EventArgs e)
        {
            if (textBoxEditUserSearch.Text == "")
            {
                MessageBox.Show("Please fill the required information", "Error");
            }
            else
            {
                try
                {
                    con.Open();
                    adap = new SqlDataAdapter("select id,username,password,name,mobile,branch from userstb where username = '" + textBoxEditUserSearch.Text + "' ", con);
                    ds = new System.Data.DataSet();
                    adap.Fill(ds, "userstb");
                    dataGridViewUsers.DataSource = ds.Tables[0];
                    
                    dataGridViewUsers.Columns["id"].Visible = false;
                    dataGridViewUsers.Columns["username"].ReadOnly = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
                finally
                {
                    con.Close();
                }
            }
        }


        private void buttonUP_Click(object sender, EventArgs e)
        {
            try
            {
                cmbl = new SqlCommandBuilder(adap);
                adap.Update(ds,"userstb");
                MessageBox.Show("Updated Fine", "Success");
                allUserTable();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Update Error : "+ex.Message, "Error");
            }

        }


        private void buttonAllUsers_Click(object sender, EventArgs e)
        {
            allUserTable();
            textBoxEditUserSearch.Text = "";
        }

        private void buttonDeleteUser_Click(object sender, EventArgs e)
        {
            if (textBoxEditUserSearch.Text == "")
            {
                MessageBox.Show("Please fill the required information", "Error");
            }
            else
            {
                try
                {
                    DBL.User user = new DBL.User();
                    user.Username1 = textBoxEditUserSearch.Text;
                    user.deleteUser(user);
                    MessageBox.Show("Deleted Well", "Success");
                    allUserTable();
                    textBoxEditUserSearch.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        private void buttonAddUsers_Click(object sender, EventArgs e)
        {
            if (textBoxEditUserName.Text == "")
            {
                MessageBox.Show("Please fill the required information", "Error");
            }
            else
            {
                try
                {
                    DBL.User user = new DBL.User();
                    user.Name1 = textBoxEditUserName.Text;
                    user.Username1 = textBoxEditUserUsername.Text;
                    user.Password1 = textBoxEditUserPassword.Text;
                    user.Mobile1 = textBoxEditUserMobile.Text;
                    user.Branch1 = textBoxEditUserBranch.Text;
                    user.addUser(user);
                    MessageBox.Show("Inserted Well", "Success");
                    allUserTable();

                    textBoxEditUserName.Text = "";
                    textBoxEditUserUsername.Text = "";
                    textBoxEditUserPassword.Text = "";
                    textBoxEditUserMobile.Text = "";
                    textBoxEditUserBranch.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        private void buttonAllTour_Click(object sender, EventArgs e)
        {
            allTourTable();
            textBoxTourSearch.Text = "";
        }

        private void buttonUpdateTour_Click(object sender, EventArgs e)
        {
            try
            {
                cmbl = new SqlCommandBuilder(adap);
                adap.Update(ds, "tourtb");
                MessageBox.Show("Updated Fine", "Success");
                allTourTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Error : " + ex.Message, "Error");
            }
        }

        private void buttonTourSearch_Click(object sender, EventArgs e)
        {
            if (textBoxTourSearch.Text == "")
            {
                MessageBox.Show("Please fill the required information", "Error");
            }
            else
            {
                try
                {
                    con.Open();
                    adap = new SqlDataAdapter("select * from tourtb where tourfrom = '" + textBoxTourSearch.Text + "' or tourto = '"+ textBoxTourSearch.Text +"' ", con);
                    ds = new System.Data.DataSet();
                    adap.Fill(ds, "tourtb");
                    dataGridViewTour.DataSource = ds.Tables[0];

                    dataGridViewTour.Columns["id"].ReadOnly = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void buttonTourDelete_Click(object sender, EventArgs e)
        {
            if (textBoxTourSearch.Text == "")
            {
                MessageBox.Show("Please fill the required information", "Error");
            }
            else
            {
                try
                {
                    DBL.Tour tour = new DBL.Tour();
                    tour.Id = textBoxTourSearch.Text;
                    tour.deleteTour(tour);
                    MessageBox.Show("Deleted Well", "Success");
                    allTourTable();
                    textBoxTourSearch.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        private void buttonTourSave_Click(object sender, EventArgs e)
        {
            if (textBoxTourFrom.Text == "")
            {
                MessageBox.Show("Please fill the required information", "Error");
            }
            else
            {
                try
                {
                    DBL.Tour tour = new DBL.Tour();
                    tour.Tourfrom = textBoxTourFrom.Text;
                    tour.Tourto = textBoxTourTo.Text;
                    tour.Tourkm = textBoxTourKM.Text;
                    tour.Touramount = textBoxTourAmount.Text;
                    tour.addTour(tour);
                    MessageBox.Show("Inserted Well", "Success");
                    allTourTable();

                    textBoxTourFrom.Text = "";
                    textBoxTourTo.Text = "";
                    textBoxTourKM.Text = "";
                    textBoxTourAmount.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        private void buttonCabAll_Click(object sender, EventArgs e)
        {
            allCabTable();
            textBoxCabSearch.Text = "";
        }

        private void buttonCabSearch_Click(object sender, EventArgs e)
        {
            if (textBoxCabSearch.Text == "")
            {
                MessageBox.Show("Please fill the required information", "Error");
            }
            else
            {
                try
                {
                    con.Open();
                    adap = new SqlDataAdapter("select * from drivertb where taxi = '" + textBoxCabSearch.Text + "' ", con);
                    ds = new System.Data.DataSet();
                    adap.Fill(ds, "drivertb");
                    dataGridViewCab.DataSource = ds.Tables[0];

                    dataGridViewCab.Columns["ID"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void buttonCabUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                cmbl = new SqlCommandBuilder(adap);
                adap.Update(ds, "drivertb");
                MessageBox.Show("Updated Fine", "Success");
                allCabTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Error : " + ex.Message, "Error");
            }
        }

        private void buttonCabDelete_Click(object sender, EventArgs e)
        {
            if (textBoxCabSearch.Text == "")
            {
                MessageBox.Show("Please fill the required information", "Error");
            }
            else
            {
                try
                {
                    DBL.Driver driver = new DBL.Driver();
                    driver.Taxi = textBoxCabSearch.Text;
                    driver.deleteDriver(driver);
                    MessageBox.Show("Deleted Well", "Success");
                    allCabTable();
                    textBoxCabSearch.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        private void buttonCabSave_Click(object sender, EventArgs e)
        {
            if (textBoxCabName.Text == "")
            {
                MessageBox.Show("Please fill the required information", "Error");
            }
            else
            {
                try
                {
                    DBL.Driver driver = new DBL.Driver();
                    driver.Name = textBoxCabName.Text;
                    driver.Username = textBoxCabUsername.Text;
                    driver.Password = textBoxCabPassword.Text;
                    driver.Mobile = textBoxCabMobile.Text;
                    driver.Branch = textBoxCabBranch.Text;
                    driver.Status = textBoxCabStatus.Text;
                    driver.Taxi = textBoxCabNo.Text;
                    driver.addDriver(driver);
                    MessageBox.Show("Inserted Well", "Success");
                    allCabTable();

                    textBoxCabName.Text = "";
                    textBoxCabUsername.Text = "";
                    textBoxCabPassword.Text = "";
                    textBoxCabMobile.Text = "";
                    textBoxCabBranch.Text = "";
                    textBoxCabStatus.Text = "";
                    textBoxCabNo.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        private void buttonClientAll_Click(object sender, EventArgs e)
        {
            allClientTable();
            textBoxCabSearch.Text = "";
        }

        private void buttonClientSearch_Click(object sender, EventArgs e)
        {
            if (textBoxClientSearch.Text == "")
            {
                MessageBox.Show("Please fill the required information", "Error");
            }
            else
            {
                try
                {
                    con.Open();
                    adap = new SqlDataAdapter("select * from clientstb where username = '" + textBoxClientSearch.Text + "' ", con);
                    ds = new System.Data.DataSet();
                    adap.Fill(ds, "clientstb");
                    dataGridViewClient.DataSource = ds.Tables[0];

                    dataGridViewClient.Columns["ID"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void buttonClientUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                cmbl = new SqlCommandBuilder(adap);
                adap.Update(ds, "clientstb");
                MessageBox.Show("Updated Fine", "Success");
                allClientTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Error : " + ex.Message, "Error");
            }
        }

        private void buttonClientDelete_Click(object sender, EventArgs e)
        {
            if (textBoxClientSearch.Text == "")
            {
                MessageBox.Show("Please fill the required information", "Error");
            }
            else
            {
                try
                {
                    DBL.Clients client = new DBL.Clients();
                    client.Username = textBoxClientSearch.Text;
                    client.deleteClient(client);
                    MessageBox.Show("Deleted Well", "Success");
                    allClientTable();
                    textBoxClientSearch.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        private void buttonClientSave_Click(object sender, EventArgs e)
        {
            if (textBoxClientName.Text == "")
            {
                MessageBox.Show("Please fill the required information", "Error");
            }
            else
            {
                try
                {
                    DBL.Clients client = new DBL.Clients();
                    client.Name = textBoxClientName.Text;
                    client.Username = textBoxClientUsername.Text;
                    client.Password = textBoxClientPassword.Text;
                    client.Mobile = textBoxClientMobile.Text;
                    client.addClient(client);
                    MessageBox.Show("Inserted Well", "Success");
                    allClientTable();

                    textBoxClientName.Text = "";
                    textBoxClientUsername.Text = "";
                    textBoxClientPassword.Text = "";
                    textBoxClientMobile.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        private void buttonLogout_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
            login l = new login();
            l.Show();
        }

        private void buttonResAll_Click_1(object sender, EventArgs e)
        {
            allResTable();
            textBoxResSearch.Text = "";
        }

        private void buttonResSearch_Click_1(object sender, EventArgs e)
        {
            if (textBoxResSearch.Text == "")
            {
                MessageBox.Show("Please fill the required information", "Error");
            }
            else
            {
                try
                {
                    con.Open();
                    adap = new SqlDataAdapter("select * from restb where id = '" + textBoxResSearch.Text + "' ", con);
                    ds = new System.Data.DataSet();
                    adap.Fill(ds, "restb");
                    dataGridViewRes.DataSource = ds.Tables[0];

                    dataGridViewRes.Columns["id"].ReadOnly = true;
                    dataGridViewRes.Columns["client"].ReadOnly = true;
                    dataGridViewRes.Columns["tourfrom"].ReadOnly = true;
                    dataGridViewRes.Columns["tourto"].ReadOnly = true;
                    dataGridViewRes.Columns["km"].ReadOnly = true;
                    dataGridViewRes.Columns["amount"].ReadOnly = true;
                    dataGridViewRes.Columns["taxi"].ReadOnly = true;
                    dataGridViewRes.Columns["date"].ReadOnly = true;
                    dataGridViewRes.Columns["comment"].ReadOnly = true;
                    dataGridViewRes.Columns["status"].ReadOnly = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
                finally
                {
                    con.Close();
                }
            }
        }


        private void buttonResUpdate_Click_1(object sender, EventArgs e)
        {
            try
            {
                cmbl = new SqlCommandBuilder(adap);
                adap.Update(ds, "restb");
                MessageBox.Show("Updated Fine", "Success");
                allResTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Error : " + ex.Message, "Error");
            }
        }

        private void comboBoxResFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            findAvailableCabNo();
            fillResToCombo();
        }

        private void buttonResRefresh_Click(object sender, EventArgs e)
        {
            comboboxes();
            comboBoxResTo.Enabled = false;
            comboBoxResCab.Enabled = false;
            buttonResSave.Enabled = false;
            labelResAmount.Text = "";
            labelResKm.Text = "";
        }

        private void comboBoxResCab_SelectedIndexChanged(object sender, EventArgs e)
        {
            calculateResAmount();
        }

        private void buttonResSave_Click(object sender, EventArgs e)
        {
            if (comboBoxResCab.Text == "")
            {
                MessageBox.Show("Please fill the required information", "Error");
            }
            else
            {
                try
                {
                    DBL.Res res = new DBL.Res();
                    res.Client = comboBoxResClient.Text;
                    res.Tourfrom = comboBoxResFrom.Text;
                    res.Tourto = comboBoxResTo.Text;
                    res.Cab = comboBoxResCab.Text;
                    res.Tourkm = labelResKm.Text;
                    res.Touramount = labelResAmount.Text;
                    res.Date = DateTime.Now.ToString("yyyy-M-dd");
                    res.Status = "hire";
                    res.Comment = "";
                    res.addRes(res);

                    DBL.Driver cab = new DBL.Driver();
                    cab.Taxi = comboBoxResCab.Text;
                    cab.Status = "hire";
                    cab.statusDriver(cab);

                    MessageBox.Show("Inserted Well", "Success");
                    curResTable();
                    allCabTable();

                    buttonResRefresh.PerformClick();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        private void buttonCurrentRes_Click(object sender, EventArgs e)
        {
            curResTable();
        }

        /*------------------------------------------------------------------------------------------------------------------------*/

        public void allUserTable()
        {
            try
            {
                con.Open();
                adap = new SqlDataAdapter("select id,username,password,name,mobile,branch from userstb", con);
                ds = new System.Data.DataSet();
                adap.Fill(ds, "userstb");
                dataGridViewUsers.DataSource = ds.Tables[0];

                dataGridViewUsers.Columns["id"].Visible = false;
                dataGridViewUsers.Columns["password"].Visible = false;
                dataGridViewUsers.Columns["username"].ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            finally
            {
                con.Close();
            }
        }

        public void allClientTable()
        {
            try
            {
                con.Open();
                adap = new SqlDataAdapter("select * from clientstb", con);
                ds = new System.Data.DataSet();
                adap.Fill(ds, "clientstb");
                dataGridViewClient.DataSource = ds.Tables[0];

                dataGridViewClient.Columns["id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            finally
            {
                con.Close();
            }
        }
        public void allTourTable()
        {
            try
            {
                con.Open();
                adap = new SqlDataAdapter("select * from tourtb", con);
                ds = new System.Data.DataSet();
                adap.Fill(ds, "tourtb");
                dataGridViewTour.DataSource = ds.Tables[0];

                dataGridViewTour.Columns["id"].ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            finally
            {
                con.Close();
            }
        }

        public void allCabTable()
        {
            try
            {
                con.Open();
                adap = new SqlDataAdapter("select * from drivertb", con);
                ds = new System.Data.DataSet();
                adap.Fill(ds, "drivertb");
                dataGridViewCab.DataSource = ds.Tables[0];

                dataGridViewCab.Columns["ID"].ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            finally
            {
                con.Close();
            }
        }

        public void allResTable()
        {
            try
            {
                con.Open();
                adap = new SqlDataAdapter("select * from restb", con);
                ds = new System.Data.DataSet();
                adap.Fill(ds, "restb");
                dataGridViewRes.DataSource = ds.Tables[0];

                dataGridViewRes.Columns["id"].ReadOnly = true;
                dataGridViewRes.Columns["client"].ReadOnly = true;
                dataGridViewRes.Columns["tourfrom"].ReadOnly = true;
                dataGridViewRes.Columns["tourto"].ReadOnly = true;
                dataGridViewRes.Columns["km"].ReadOnly = true;
                dataGridViewRes.Columns["amount"].ReadOnly = true;
                dataGridViewRes.Columns["taxi"].ReadOnly = true;
                dataGridViewRes.Columns["date"].ReadOnly = true;
                dataGridViewRes.Columns["comment"].ReadOnly = true;
                dataGridViewRes.Columns["status"].ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            finally
            {
                con.Close();
            }
        }

        public void curResTable()
        {
            try
            {
                con.Open();
                adap = new SqlDataAdapter("select * from restb where status = 'hire'", con);
                ds = new System.Data.DataSet();
                adap.Fill(ds, "restb");
                dataGridViewRes.DataSource = ds.Tables[0];

                dataGridViewRes.Columns["id"].ReadOnly = true;
                dataGridViewRes.Columns["client"].ReadOnly = true;
                dataGridViewRes.Columns["tourfrom"].ReadOnly = true;
                dataGridViewRes.Columns["tourto"].ReadOnly = true;
                dataGridViewRes.Columns["km"].ReadOnly = true;
                dataGridViewRes.Columns["amount"].ReadOnly = true;
                dataGridViewRes.Columns["taxi"].ReadOnly = true;
                dataGridViewRes.Columns["date"].ReadOnly = true;
                dataGridViewRes.Columns["comment"].ReadOnly = true;
                dataGridViewRes.Columns["status"].ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            finally
            {
                con.Close();
            }
        }

        public bool foundUser(String username)
        {
            DBL.User user = new DBL.User();
            user.Username1 = username;
            SqlDataReader rdr = user.getUser(user);
            if (rdr.Read())
            {
                /*
                string col = rdr["id"].ToString();
                MessageBox.Show(col, "Success");
                */
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool foundTour(String id)
        {
            DBL.Tour tour = new DBL.Tour();
            tour.Id = id;
            SqlDataReader rdr = tour.getTour(tour);
            if (rdr.Read())
            {
                /*
                string col = rdr["id"].ToString();
                MessageBox.Show(col, "Success");
                */
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool foundCab(String taxi)
        {
            DBL.Driver driver = new DBL.Driver();
            driver.Taxi = taxi;
            SqlDataReader rdr = driver.getDriver(driver);
            if (rdr.Read())
            {
                /*
                string col = rdr["id"].ToString();
                MessageBox.Show(col, "Success");
                */
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool foundClient(String username)
        {
            DBL.Clients client = new DBL.Clients();
            client.Username = username;
            SqlDataReader rdr = client.getClient(client);
            if (rdr.Read())
            {
                /*
                string col = rdr["id"].ToString();
                MessageBox.Show(col, "Success");
                */
                return true;
            }
            else
            {
                return false;
            }
        }

        void manage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                var result = MessageBox.Show("Do you want to Exit ?", "Exit",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
                if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                else if (result == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
        }
        
        public void comboboxes()
        {
            comboBoxResClient.Items.Clear();
            con.Open();
            SqlCommand cmd = new SqlCommand("select username from clientstb", con);
            SqlDataReader DR = cmd.ExecuteReader();
            while (DR.Read())
            {
                comboBoxResClient.Items.Add(DR[0]);
            }
            con.Close();

            comboBoxResFrom.Items.Clear();
            con.Open();
            cmd = new SqlCommand("select distinct tourfrom from tourtb", con);
            DR = cmd.ExecuteReader();
            while (DR.Read())
            {
                comboBoxResFrom.Items.Add(DR[0]);
            }
            con.Close();
        }

        public void findAvailableCabNo()
        {
            comboBoxResCab.Enabled = true;
            comboBoxResCab.Items.Clear();
            con.Open();
            SqlCommand cmd = new SqlCommand("select taxi from drivertb where branch = '"+comboBoxResFrom.Text+"' and status = 'available'", con);
            SqlDataReader DR = cmd.ExecuteReader();
            if (DR.HasRows)
            {
                buttonResSave.Enabled = true;
                labelResAmount.Text = "";
                labelResKm.Text = "";

                while (DR.Read())
                {
                    comboBoxResCab.Items.Add(DR[0]);
                }
            }
            else
            {
                labelResAmount.Text = "NO CABS AVAILABLE";
                labelResKm.Text = "N/A";
                comboBoxResCab.Items.Clear();
                comboBoxResCab.Enabled = false;
                buttonResSave.Enabled = false;
            }
            con.Close();
        }

        public void fillResToCombo()
        {
            comboBoxResTo.Enabled = true;
            comboBoxResTo.Items.Clear();
            con.Open();
            SqlCommand cmd = new SqlCommand("select distinct tourto from tourtb where  tourto != '" + comboBoxResFrom.Text + "'", con);
            SqlDataReader DR = cmd.ExecuteReader();
            while (DR.Read())
            {
                comboBoxResTo.Items.Add(DR[0]);
            }
            con.Close();
        }

        public void calculateResAmount()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tourtb where  tourfrom = '" + comboBoxResFrom.Text + "' and tourto = '"+ comboBoxResTo.Text +"'", con);
            SqlDataReader DR = cmd.ExecuteReader();
            while (DR.Read())
            {
                labelResAmount.Text = DR["touramount"].ToString();
                labelResKm.Text = DR["tourkm"].ToString();
            }
            con.Close();
        }

        private void buttonResCom_Click(object sender, EventArgs e)
        {
            ComRes k = new ComRes();
            k.Show();
        }

        public static void refreshResTableFromOut()
        {
            _instance.curResTable();
        }

        private void comboBoxResTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            calculateResAmount();
        }

        /*------------------------------------------------------------------------------------------------------------------------*/

   }
}
