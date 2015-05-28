using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FairManagementSystem.UI
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void visitorEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VisitorEntryUI myVisitorEntryUi = new VisitorEntryUI();
            myVisitorEntryUi.Show();
        }

        private void zoneTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ZoneTypeEntryUI myZoneTypeEntryUi = new ZoneTypeEntryUI();
            myZoneTypeEntryUi.Show();
        }

        private void zoneSpecificUserDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VisitoReportUI myVisitoReportUi = new VisitoReportUI();
            myVisitoReportUi.Show();
        }

        private void zoneWiseCountingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VisitorNuimberReportUI myVisitorNuimberReportUi = new VisitorNuimberReportUI();
            myVisitorNuimberReportUi.Show();
        }
    }
}
