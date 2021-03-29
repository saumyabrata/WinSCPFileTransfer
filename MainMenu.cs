using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinSCPFileTransfer
{
    public partial class MainMenu : MetroFramework.Forms.MetroForm
    {

        public MainMenu()
        {
            InitializeComponent();
        }

        
        private void MainMenu_Load(object sender, EventArgs e)
        {

        }
        private void bttnAbout_Click(object sender, EventArgs e)
        {
            Form About = new Form();
            About.MdiParent = this;
            About.Text = "Add/Edit Server List";
            About.Show();

        }
    }
}
