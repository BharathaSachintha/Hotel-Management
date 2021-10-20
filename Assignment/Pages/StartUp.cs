using Assignment.Database_Connection;
using Assignment.Pages;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment
{
    public partial class Form1 : Form
    {
        MySqlConnection cn = new MySqlConnection();
        MySqlCommand cm = new MySqlCommand();
        Connection dbcon = new Connection();
        int i;
        public Form1()
        {
            InitializeComponent();
            cn = new MySqlConnection(dbcon.MyConnection());
        }

        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                i = 0;
                    cn.Open();
                    cm = cn.CreateCommand();
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "SELECT * FROM login WHERE Username='" + txtUser.Text + "' AND Password='" + txtPassword.Text + "'";
                    cm.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    MySqlDataAdapter da = new MySqlDataAdapter(cm);
                    da.Fill(dt);
                    i = Convert.ToInt32(dt.Rows.Count.ToString());
                    if (i == 0)
                    {
                        lblError.Visible = true;
                    }
                    else
                    {
                        lblError.Visible = false;
                        Dashboard dash = new Dashboard();
                        this.Hide();
                        dash.Show();
                    }
                    cn.Close();

            }
            catch (Exception ex) { }

        }
    }
}
