using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment.User_Control
{
    public partial class CustomerDetails : UserControl
    {
        function fn = new function();
        String query;
        public CustomerDetails()
        {
            InitializeComponent();
        }

        private void txtSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtSearchBy.SelectedIndex == 0)
            {
                query = "SELECT customer.cid,customer.cname,customer.mobile,customer.nationality,customer.gender,customer.dob,customer.idproof,customer.address,customer.checkout,rooms.roomNo,rooms.roomType,rooms.bed,rooms.price FROM customer INNER JOIN rooms ON customer.roomid=rooms.roomid";
                getRecord(query);
            }
            else if(txtSearchBy.SelectedIndex==1){
                query = "SELECT customer.cid,customer.cname,customer.mobile,customer.nationality,customer.gender,customer.dob,customer.idproof,customer.address,customer.checkin,customer.checkout,rooms.roomNo,rooms.roomType,rooms.bed,rooms.price FROM customer INNER JOIN rooms ON customer.roomid=rooms.roomid WHERE checkout is null";
                getRecord(query);
            }
            else if (txtSearchBy.SelectedIndex == 2)
            {
                query = "SELECT customer.cid,customer.cname,customer.mobile,customer.nationality,customer.gender,customer.dob,customer.idproof,customer.address,customer.checkin,customer.checkout,rooms.roomNo,rooms.roomType,rooms.bed,rooms.price FROM customer INNER JOIN rooms ON customer.roomid=rooms.roomid WHERE checkout is not null";
                getRecord(query);
            }
        }
        private void getRecord(String query1)
        {
            DataSet ds = fn.getData(query1);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }
    }
}
