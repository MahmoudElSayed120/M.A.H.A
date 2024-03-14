using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace M.A.H.A
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            RoleBox.Items.Add("Administrator");
            RoleBox.Items.Add("Accountant");
            RoleBox.Items.Add("Doctor");
            RoleBox.Items.Add("Nurse");
            RoleBox.Items.Add("Receptionist");

            RoleBox.SelectedIndexChanged += RoleBox_SelectedIndexChanged;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void RoleBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show($"Selected item: {RoleBox.SelectedItem}");
        }
    }
}
