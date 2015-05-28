using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FairManagementSystem.BLL;
using FairManagementSystem.Model;


namespace FairManagementSystem.UI
{
    public partial class ZoneTypeEntryUI : Form
    {
        public ZoneTypeEntryUI()
        {
            InitializeComponent();
        }
        Zone myZone = new Zone();
        ZoneManager myZoneManager = new ZoneManager();

        private void ZoneType_Load(object sender, EventArgs e)
        {
            ShowAll();
        }

        private void ShowAll()
        {
            List<Zone> zones = myZoneManager.ShowAll();
            zonelistView.Items.Clear();

            foreach (Zone zone in zones)
            {
                var listViewItem = new ListViewItem(zone.Name);
                //listViewItem.SubItems.Add(zone.Name);
                zonelistView.Items.Add(listViewItem);
            }
        }

       
        private void saveButton_Click(object sender, EventArgs e)
        {
            myZone.Name = typeZoneNameTextBox.Text ;
            if (typeZoneNameTextBox.Text == "")
            {
                MessageBox.Show("Please input Zone type");
            }
            else

            {
                myZoneManager.Save(myZone);
                MessageBox.Show("Save success full");
                ShowAll();
                typeZoneNameTextBox.Text = "";
            }
        }

        
    }
}
