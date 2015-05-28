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

namespace FairManagementSystem.UI
{
    public partial class VisitoReportUI : Form
    {
        ZoneManager myManager = new ZoneManager();
        public VisitoReportUI()
        {
            InitializeComponent();
        }

        private void VisitoReportUI_Load(object sender, EventArgs e)
        {
            LoadCombox();
            LoadVisitorsinListView();
        }

        private void LoadVisitorsinListView()
        {
            int count = 0;
            string typeName = zoneComboBox.Text;
            visitorListView.Items.Clear();

            foreach (var list in myManager.GetVisitorListByZone(typeName))
            {
                ListViewItem item = new ListViewItem();
                item.Text = list.Name;
                item.SubItems.Add(list.Email);
                item.SubItems.Add(list.Contact);

                visitorListView.Items.Add(item);
                count++;
            }

            totalTextBox.Text = count.ToString();

        }

        private void LoadCombox()
        {
            zoneComboBox.DataSource = myManager.GetAllZones();
            zoneComboBox.DisplayMember = "name";
            zoneComboBox.ValueMember = "Id";
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            LoadAllVisitorByZoneName();
        }

        private void LoadAllVisitorByZoneName()
        {
            int count = 0;
            string typeName = zoneComboBox.Text;
            visitorListView.Items.Clear();

            foreach (var list in myManager.GetVisitorListByZone(typeName))
            {
                ListViewItem item = new ListViewItem();
                item.Text = list.Name;
                item.SubItems.Add(list.Email);
                item.SubItems.Add(list.Contact);

                visitorListView.Items.Add(item);
                count++;
            }

            totalTextBox.Text = count.ToString();
        }

        private void MyExcelExport()
        {
            try
            {
                //lvPDF is nothing but the listview control name
                string[] st = new string[visitorListView.Columns.Count];
                DirectoryInfo di = new DirectoryInfo(@"c:\file");
                if (di.Exists == false)
                    di.Create();
                //StreamWriter sw = new StreamWriter(@"c:\PDFExtraction\" + txtBookName.Text.Trim() + ".xls", false);
                StreamWriter sw = new StreamWriter(@"c:\file\visitor.xls", false);
                sw.AutoFlush = true;
                for (int col = 0; col < visitorListView.Columns.Count; col++)
                {
                    sw.Write("\t" + visitorListView.Columns[col].Text.ToString());
                }

                int rowIndex = 1;
                int row = 0;
                string st1 = "";
                for (row = 0; row < visitorListView.Items.Count; row++)
                {
                    if (rowIndex <= visitorListView.Items.Count)
                        rowIndex++;
                    st1 = "\n";
                    for (int col = 0; col < visitorListView.Columns.Count; col++)
                    {
                        st1 = st1 + "\t" + "'" + visitorListView.Items[row].SubItems[col].Text.ToString();
                    }
                    sw.WriteLine(st1);
                }
                sw.Close();
                FileInfo fil = new FileInfo(@"c:\file\visitor.xls");
                if (fil.Exists == true)
                    MessageBox.Show("Process Completed", "Export to Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

            }
        }

        private void ExcelExport()
        {
            string zonename = zoneComboBox.Text;
            Microsoft.Office.Interop.Excel.Application xla = new Microsoft.Office.Interop.Excel.Application();
            xla.Visible = true;

            Microsoft.Office.Interop.Excel.Workbook wb =
                xla.Workbooks.Add(Microsoft.Office.Interop.Excel.XlSheetType.xlWorksheet);

            Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)xla.ActiveSheet;

            int i = 1;

            int j = 1;
            ws.Cells[i, j + 1] = "Digital Innovation Fair 2015";
            i++;
            ws.Cells[i, j + 1] = "List Of People Visited in " + zonename;
            i++;
            ws.Cells[i, j] = "Name";
            ws.Cells[i, j + 1] = "Email";
            ws.Cells[i, j + 2] = "Contact No";

            i++;



            foreach (ListViewItem comp in visitorListView.Items)
            {

                ws.Cells[i, j] = comp.Text.ToString();

                foreach (ListViewItem.ListViewSubItem drv in comp.SubItems)
                {

                    ws.Cells[i, j] = drv.Text.ToString();

                    j++;

                }

                j = 1;

                i++;
            }
        }
        private void expButton_Click(object sender, EventArgs e)
        {
            //MyExcelExport();
            ExcelExport();
        }

        
        
    }
}
