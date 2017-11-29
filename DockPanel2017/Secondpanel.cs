using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace DockPanel2017
{
    public partial class Secondpanel : DockContent
    {
        public Secondpanel()
        {
            InitializeComponent();
        }

        private void Secondpanel_Load(object sender, EventArgs e)
        {

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            MessageBox.Show("Chiudo!");
            bool cancel = false;
            e.Cancel = cancel;
            base.OnFormClosing(e);
        }
    }
}
