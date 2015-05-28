using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairManagementSystem.Model
{
    class Zone
    {
        private int id;
        private string name;
        private int noOfVisitor;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int NoOfVisitor
        {
            get { return noOfVisitor; }
            set { noOfVisitor = value; }
        }
    }
}
