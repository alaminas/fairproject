using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairManagementSystem.DAL;
using FairManagementSystem.Model;

namespace FairManagementSystem.BLL
{
    class VisitorManager
    {
        ZoneGateway myZoneGateway = new ZoneGateway();
        VisitorGateway myVisitorGateway = new VisitorGateway();
        public List<Zone> GetAllZones()
        {
            return myZoneGateway.GetZoneTypes();
        }

        public string Save(Visitor visitor)
        {
            int value = myVisitorGateway.Save(visitor);

            if (value > 0)
            {



                return "Information Saved Successfully";


            }

            else
            {
                return "Save Operation Failed";
            }
        }

        public void GetCheckBox(List<string> checkBoxList)
        {
            myVisitorGateway.GetCheckBoxes(checkBoxList);
        }
    }
}
