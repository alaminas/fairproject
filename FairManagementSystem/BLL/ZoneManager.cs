using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairManagementSystem.DAL;
using FairManagementSystem.Model;

namespace FairManagementSystem.BLL
{
    class ZoneManager
    {
        ZoneGateway myGateway = new ZoneGateway();
        VisitorGateway myVisitorGateway = new VisitorGateway();
        public void Save(Zone zone)
        {
            myGateway.Save(zone);
        }

        public List<Zone> ShowAll()
        {
            return myGateway.ShowAll();
        }

        public int GetAllVisitors()
        {
            return myGateway.GetAllVisitors();
        }

        /*public IEnumerable GetAllZones()
        {
            null;
        }*/

        public List<Zone> GetAllZones()
        {
            return myGateway.GetAllZone();
        }

        public  List<Visitor> GetVisitorListByZone(string typeName)
        {
            return myVisitorGateway.GetVisitors(typeName);
        }

        
    }
}
