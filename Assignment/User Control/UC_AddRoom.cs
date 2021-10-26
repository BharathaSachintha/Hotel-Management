using Assignment.Pages;
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
    public partial class UC_AddRoom : UserControl
    {
        function fn = new function();
        String query;
        public UC_AddRoom()
        {
            InitializeComponent();
        }

        private void UC_AddRoom_Load(object sender, EventArgs e)
        {
            query = "SELECT * FROM rooms";
            DataSet ds = fn.getData(query);
            DataGridView1.DataSource = ds.Tables[0];
        }
        public void clearAll()
        {
            txtPrice.Clear();
            txtRoomNo.Clear();
            cmdBed.SelectedIndex = -1;
            cmdRoomType.SelectedIndex = -1;
        }
        private void btnAddroom_Click(object sender, EventArgs e)
        {
            if(txtRoomNo.Text!="" && txtPrice.Text!="" && cmdBed.Text!="" && cmdRoomType.Text != "")
            {
                String roomno = txtRoomNo.Text;
                String type = cmdRoomType.Text;
                String bed = cmdBed.Text;
                Int64 price = Int64.Parse(txtPrice.Text);
                query = "INSERT INTO rooms(roomNo,roomType,bed,price)VALUES('"+roomno+"','"+type+"','"+bed+"','"+price+"')";
                fn.SetData(query, "Room Added");
                UC_AddRoom_Load(this, null);
                clearAll();
            }
            else
            {
                MessageBox.Show("Fill All Fields!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UC_AddRoom_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

        private void UC_AddRoom_Enter(object sender, EventArgs e)
        {
            UC_AddRoom_Load(this, null);
        }

        private void btngallery_Click(object sender, EventArgs e)
        {
            Gallery u = new Gallery();
            u.Visible = true;
            //Form formBackground = new Form();
            //try
            //{
            //    using(Gallery u=new Gallery())
            //    {
            //        formBackground.StartPosition = FormStartPosition.Manual;
            //        formBackground.FormBorderStyle = FormBorderStyle.None;
            //        formBackground.Opacity = .70d;
            //        formBackground.BackColor = Color.Black;
            //        formBackground.WindowState = FormWindowState.Maximized;
            //        formBackground.TopMost = true;
            //        formBackground.Location = this.Location;
            //        formBackground.ShowInTaskbar = false;
            //        formBackground.Show();
            //        u.Owner = formBackground;
            //        u.ShowDialog();
            //        formBackground.Dispose();
            //    }
            //}catch(Exception ex) {
            //    MessageBox.Show(ex.Message);
            //}
            //finally
            //{
            //    formBackground.Dispose();
            //}
        }
    }
}
