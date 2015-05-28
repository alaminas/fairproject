using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FairManagementSystem.BLL;
using FairManagementSystem.Model;

namespace FairManagementSystem.UI
{
    public partial class VisitorNuimberReportUI : Form
    {
        public VisitorNuimberReportUI()
        {
            InitializeComponent();
        }

        ZoneManager myZoneManager = new ZoneManager();
        Zone zone = new Zone();
        private void VisitorNuimberReportUI_Load(object sender, EventArgs e)
        {
            FillNumberofVisitor();
        }

        private void FillNumberofVisitor()
        {
            totalTextBox.Text = myZoneManager.GetAllVisitors().ToString();

            foreach (var zone in myZoneManager.GetAllZones())
            {
                ListViewItem item = new ListViewItem();

                item.Text = zone.Name;

                item.SubItems.Add(zone.NoOfVisitor.ToString());

                VisitorListView.Items.Add(item);


            }
        }
    }
}
