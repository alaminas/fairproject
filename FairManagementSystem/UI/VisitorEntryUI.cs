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

namespace FairManagementSystem
{
    public partial class VisitorEntryUI : Form
    {
        public VisitorEntryUI()
        {
            InitializeComponent();
        }

        VisitorManager myManager = new VisitorManager();
        private void VisitorEntryUI_Load(object sender, EventArgs e)
        {
            /*CheckBox[] chk = new CheckBox[10];
            int height = 1;
            int padding = 10;

            for (int i = 0; i <= 9; i++)
            {

                chk[i] = new CheckBox();

                chk[i].Name = i.ToString();

                chk[i].Text = i.ToString();

                chk[i].TabIndex = i;

                chk[i].AutoCheck = true;

                chk[i].Bounds = new Rectangle(10, 20 + padding + height, 40, 22);

                panel1.Controls.Add(chk[i]);

                height += 22;

            }*/
            GetAllZoneType();
        }

        private void GetAllZoneType()
        {
            List<Zone> zones = myManager.GetAllZones();
            int x = 200, y = 30;

            foreach (Zone zone in zones)
            {
                CheckBox checkBox = new CheckBox();

                checkBox.Text = zone.Name;
                checkBox.Name = string.Format(zone.Name + "CheckBox");
                checkBox.Location = new Point(x, y);
                checkBox.Width = 200;
                checkBox.Checked = true;
                zoneGroupBox.Controls.Add(checkBox);
                y += 30;

            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            GetCheckBoxesItem();
            Visitor visitor = new Visitor();

            visitor.Name = nameTextBox.Text;
            visitor.Email = emailTextBox.Text;
            visitor.Contact = contactTextBox.Text;

            MessageBox.Show(myManager.Save(visitor));
            Reset();
            
        }

        public void Reset()
        {
            nameTextBox.Text = "";
            emailTextBox.Text = "";
            contactTextBox.Text = "";
        }
        private void GetCheckBoxesItem()
        {
            List<string> checkBoxList = new List<string>();

            foreach (Control c in zoneGroupBox.Controls)
            {

                CheckBox cb = c as CheckBox;
                if (cb != null && cb.Checked)
                {
                    checkBoxList.Add(cb.Text);
                }

            }
            myManager.GetCheckBox(checkBoxList);
        }
    }
}
