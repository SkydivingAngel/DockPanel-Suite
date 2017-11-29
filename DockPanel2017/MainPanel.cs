using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace DockPanel2017
{
    public partial class MainPanel : DockContent
    {
        public MainPanel()
        {
            InitializeComponent();
            // Prevent this content from being closed
            CloseButton = false;

            // Hide the close button so the user isn't even tempted
            CloseButtonVisible = false;
        }

        private void MainPanel_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello");
        }

        private void MainPanel_Shown(object sender, EventArgs e)
        {
            panel1.AutoScrollPosition = new Point(0, 0);
        }
    }
}
