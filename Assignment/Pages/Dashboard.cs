using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment.Pages
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCustomerRegister_Click(object sender, EventArgs e)
        {
            MovingPanel.Left = btnCustomerRegister.Left;
            uc_CustomerRegistration1.Visible = true;
            uc_CustomerRegistration1.BringToFront();
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            MovingPanel.Left = btnCheckOut.Left + 9;
        }

        private void btnCustomerDetails_Click(object sender, EventArgs e)
        {
            MovingPanel.Left = btnCustomerDetails.Left + 9;
        }

        private void CustomerEmployee_Click(object sender, EventArgs e)
        {
            MovingPanel.Left = btnEmployee.Left+9;
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            MovingPanel.Left = btnAddRoom.Left;
            uC_AddRoom1.Visible = true;
            uc_CustomerRegistration1.Visible = false;
            uC_AddRoom1.BringToFront();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            uC_AddRoom1.Visible = false;
            uc_CustomerRegistration1.Visible = false;
            btnAddRoom.PerformClick();
        }

        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2CirclePictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
