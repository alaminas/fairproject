using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairManagementSystem.Model;

namespace FairManagementSystem.DAL
{
    class VisitorGateway
    {
        string connectionString = ConfigurationManager.ConnectionStrings["visitorCon"].ConnectionString;
            

        private List<int> selectedZoneId = new List<int>();

        public void GetCheckBoxes(List<string> checkBoxList)
        {
            foreach (string checkboxname in checkBoxList)
            {
                int id = GetZoneId(checkboxname);

                selectedZoneId.Add(id);

            }
        }

        public int GetZoneId(string zoneName)
        {
            int zoneId = 0;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT id FROM zone WHERE name='" + zoneName + "'";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                zoneId += int.Parse(reader["id"].ToString());

            }


            reader.Close();
            connection.Close();
            return zoneId;
        }

        public int Save(Visitor visitor)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = string.Format("INSERT INTO visitor OUTPUT INSERTED.id VALUES('{0}','{1}','{2}')", visitor.Name, visitor.Contact, visitor.Email);



            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            // int rowsAffected = command.ExecuteNonQuery();

            int vid = (int)command.ExecuteScalar();

            connection.Close();
            // MessageBox.Show(vid.ToString());

            connection.Open();

            foreach (int id in selectedZoneId)
            {


                string query1 = string.Format("INSERT INTO visitor_details VALUES('{0}','{1}')", vid, id);

                //string query2 = "UPDATE zone SET z_NoOfVisitors+=1 WHERE z_id='" + id + "'";

                SqlCommand command1 = new SqlCommand(query1, connection);
                //SqlCommand command2 = new SqlCommand(query2, connection);
                command1.ExecuteNonQuery();
                //command2.ExecuteNonQuery();

            }
            connection.Close();
            return vid;
        }

        public List<Visitor> GetVisitors(string typeName)
        {
            int id = GetZoneId(typeName);

            List<Visitor> visitors = new List<Visitor>();

            SqlConnection connection = new SqlConnection(connectionString);
            string query =
                "SELECT visitor.name,visitor.email,visitor.contact FROM visitor JOIN  visitor_details ON visitor.id=visitor_details.visitor_id JOIN zone ON visitor_details.zone_id=zone.id WHERE zone.id='" + id + "'";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Visitor visitor = new Visitor();

                visitor.Name = reader[0].ToString();
                visitor.Email = reader[1].ToString();
                visitor.Contact = reader[2].ToString();
                //MessageBox.Show(visitor.Name);

                visitors.Add(visitor);


            }
            reader.Close();
            connection.Close();

            return visitors;
        }
    }
}
