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

namespace Assignment.User_Control
{
    public partial class Uc_CustomerRegistration : UserControl
    {
        function fn = new function();
        String query;
        public Uc_CustomerRegistration()
        {
            InitializeComponent();
        }
        public void setComboBox(String query,ComboBox combo)
        {
            MySqlDataReader sdr = fn.getForCombo(query);
            while (sdr.Read())
            {
                for(int i = 0; i < sdr.FieldCount; i++)
                {
                    combo.Items.Add(sdr.GetString(i));
                }
            }
            sdr.Close();
        }

        private void cmdroom_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdroomno.Items.Clear();
            txtprice.Clear();
            query = "SELECT roomNo from rooms WHERE bed='" + cmdbed.Text + "' AND roomType='" + cmdroom.Text + "' AND booked='NO'";
            setComboBox(query, cmdroomno);
        }

        private void cmdbed_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdroom.SelectedIndex = -1;
            cmdroomno.Items.Clear();
            txtprice.Clear();
        }
        public void ClearAll()
        {
            txtprice.Clear();
            txtnationality.Clear();
            txtname.Clear();
            txtmobile.Clear();
            txtID.Clear();
            txtAddress.Clear();
            cmdbed.SelectedIndex = -1;
            cmdgender.SelectedIndex = -1;
            cmdroom.SelectedIndex = -1;
            cmdroomno.SelectedIndex = -1;
            DateofB.ResetText();
            txtcheckin.ResetText();
        }
        int rid;
        private void cmdroomno_SelectedIndexChanged(object sender, EventArgs e)
        {
            query = "SELECT price,roomid FROM rooms WHERE roomNo='" + cmdroomno.Text + "'";
            DataSet ds = fn.getData(query);
            txtprice.Text = ds.Tables[0].Rows[0][0].ToString();
            rid = int.Parse(ds.Tables[0].Rows[0][1].ToString());
        }
        
        private void btnallocate_Click(object sender, EventArgs e)
        {
            if(txtAddress.Text!="" && txtID.Text!="" && txtmobile.Text!="" && txtname.Text!="" && txtnationality.Text!="" && txtprice.Text!="" && cmdbed.Text!="" && cmdgender.Text!="" && cmdroom.Text!="" && cmdroomno.Text != "")
            {
                String name = txtname.Text;
                Int64 mobile = Int64.Parse(txtmobile.Text);
                String national = txtnationality.Text;
                String gender = cmdgender.Text;
                String dob = DateofB.Text;
                String idproof = txtID.Text;
                String address = txtAddress.Text;
                String checkin = txtcheckin.Text;
                query = "INSERT INTO customer(cname,mobile,nationality,gender,dob,idproof,address,checkin,roomid)VALUES('"+name+"','"+mobile+"','"+national+"','"+gender+"','"+dob+"','"+idproof+"','"+address+"','"+checkin+"',"+rid+")";
                String query2 = "UPDATE rooms SET booked='YES' WHERE roomNo='" + cmdroomno.Text + "'";
                fn.SetData(query, "Room No" + cmdroomno.Text + "Allocation Successful.");
                fn.SetData(query2, "Room No" + cmdroomno.Text + "Allocation Successful.");
                ClearAll();
            }
            else
            {
                MessageBox.Show("All Fields are madtory.", "Information !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Uc_CustomerRegistration_Leave(object sender, EventArgs e)
        {
            ClearAll();
        }
    }
}
