using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairManagementSystem.Model
{
    class Visitor
    {
        private int id;
        private string name;
        private string email;
        private string contact;

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

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Contact
        {
            get { return contact; }
            set { contact = value; }
        }
    }
}
