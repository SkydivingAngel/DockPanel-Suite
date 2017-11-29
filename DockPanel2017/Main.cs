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
    public partial class Main : Form
    {
        //http://docs.dockpanelsuite.com/en/latest/tutorials/basics.html

        //private DockContent dockContent1 = null;

        //CREARE NUOVO PANNELLO STRUMENTI E TRASCINARCI DENTRO LA DLL IN NET 4!
        //NB SETTARE COME MDI CONTAINER IL MAIN FORM!!
        //DERIVARE I FORM FIGLI DA DOCKCONTENT -> public partial class Secondpanel : DockContent

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            dockPanel1.Dock = DockStyle.Fill;
            //dockPanel1.BackColor = Color.Beige;
            dockPanel1.BringToFront();
            dockPanel1.AllowEndUserDocking = false;

            MainPanel mainPanel = new MainPanel();
            mainPanel.Show(dockPanel1, DockState.Document);
        }

        private void aaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AlreadyOpended("Secondpanel"))
                return;

            Secondpanel secondPanel = new Secondpanel();
            secondPanel.Show(dockPanel1, DockState.Document);
        }

        private void bbToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AlreadyOpended("ThirdPanel"))
                return;

            ThirdPanel thirdPanel = new ThirdPanel();
            thirdPanel.Show(dockPanel1, DockState.Document);
        }

        private void dockPanel1_ActiveDocumentChanged(object sender, EventArgs e)
        {
            textBox1.AppendText(@"ActiveDocumentChanged" + Environment.NewLine);
        }

        private void dockPanel1_ContentAdded(object sender, DockContentEventArgs e)
        {
            textBox1.AppendText(@"ContentAdded" + Environment.NewLine);
        }

        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void ccToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i1 = 0; i1 < Application.OpenForms.Count; i1++)
            {
                if (Application.OpenForms[i1] is DockContent)
                {
                    //MessageBox.Show(""+ Application.OpenForms[i1].Text);
                    if(Application.OpenForms[i1].Text.Contains("Second"))
                        Application.OpenForms[i1].Activate();
                }

                //Form f = Application.OpenForms[i1];
                //if (t.IsInstanceOfType(f))
                //    MessageBox.Show(""+ f.Text);
            }
        }

        private void ddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<IDockContent> allDockers = dockPanel1.DocumentsToArray().ToList();
            //MessageBox.Show("" + allDockers.Count);
            for (int i = 0; i < allDockers.Count; i++)
            {
                textBox1.AppendText((allDockers[i] as Form).Text + Environment.NewLine);
            }
        }

        private bool AlreadyOpended(string panelName)
        {
            List<string> allDockers = dockPanel1.DocumentsToArray().Select(x => (x as Form).Text).ToList();
            if (allDockers.Contains(panelName))
            {
                ActivatePanel(panelName);
                return true;
            }

            return false;
        }

        private void ActivatePanel(string panelName)
        {
            IDockContent openedDocker = dockPanel1.DocumentsToArray().FirstOrDefault(x => (x as Form).Text == panelName);
            (openedDocker as Form).Activate();
        }
    }
}
