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
    public partial class Gallery : Form
    {
        public Gallery()
        {
            InitializeComponent();
        }

        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {
            Dashboard u = new Dashboard();
            u.Show();
            this.Hide();
        }
        int count = 1;
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (count < 10)
            {
                count++;
            }
            pictureBox1.Image = imageList1.Images[count];
        }

        private void btngallery_Click(object sender, EventArgs e)
        {
            if (count >0)
            {
                count--;
            }
            pictureBox1.Image = imageList1.Images[count];
        }
        
    }
}
