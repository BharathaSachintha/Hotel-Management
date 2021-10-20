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
            pnlmove.Left = btnAddRoom.Left;
            uC_AddRoom2.Visible = true;
            uc_CustomerRegistration2.Visible = false;
            uC_AddRoom2.BringToFront();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            uC_AddRoom2.Visible = false;
            uc_CustomerRegistration2.Visible = false;
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

        private void btnAddRooms_Click(object sender, EventArgs e)
        {
            pnlmove.Left = btnAddRooms.Left;
            uC_AddRoom3.Visible = true;
            uc_CustomerRegistration2.Visible = false;
            uC_AddRoom3.BringToFront();
        }

        private void btnCustomerReg_Click(object sender, EventArgs e)
        {
            pnlmove.Left = btnCustomerReg.Left;
            uc_CustomerRegistration3.Visible = true;
            uc_CustomerRegistration3.BringToFront();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            uC_CustomerCheckOut2.Visible = true;
            uC_AddRoom3.Visible = false;
            uc_CustomerRegistration3.Visible = false;
            uC_CustomerCheckOut2.BringToFront();
            pnlmove.Left = btnCheck.Left + 9;
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            customerDetails1.Visible = true;
            uC_CustomerCheckOut2.Visible = false;
            uC_AddRoom3.Visible = false;
            uc_CustomerRegistration3.Visible = false;
            customerDetails1.BringToFront();
            pnlmove.Left = btnDetail.Left + 9;
        }

        private void btnEmp_Click(object sender, EventArgs e)
        {
            uC_Employee1.Visible = true;
            customerDetails1.Visible = false;
            uC_CustomerCheckOut2.Visible = false;
            uC_AddRoom3.Visible = false;
            uc_CustomerRegistration3.Visible = false;
            uC_Employee1.BringToFront();
            pnlmove.Left = btnEmp.Left + 9;
        }
    }
}
