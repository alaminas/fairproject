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
    internal class ZoneGateway
    {
        string connectionString = ConfigurationManager.ConnectionStrings["visitorCon"].ConnectionString;

        public void Save(Zone zone)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string query = "INSERT INTO zone VALUES('" + zone.Name + "')";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();

            sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public List<Zone> ShowAll()
        {
            List<Zone> zoneList = new List<Zone>();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string query = "SELECT * FROM zone";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            SqlDataReader myReader = command.ExecuteReader();
            while (myReader.Read())
            {
                Zone zone = new Zone();
                zone.Id = Convert.ToInt32(myReader["id"].ToString());
                zone.Name = myReader["name"].ToString();

                zoneList.Add(zone);
            }
            return zoneList;
        }

        public List<Zone> GetZoneTypes()
        {
            List<Zone> zones = new List<Zone>();

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM zone";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Zone zone = new Zone();

                zone.Id = int.Parse(reader["id"].ToString());
                zone.Name = reader["name"].ToString();
                
                zones.Add(zone);

            }
            reader.Close();
            connection.Close();
            return zones;
        }

        public int GetAllVisitors()
        {
            int totalvisitors = 0;
            SqlConnection connection = new SqlConnection(connectionString);
            //string query = "SELECT SUM(z_NoOfVisitors) FROM tbl_Zone";
            string query = "SELECT COUNT(visitor_id) FROM visitor_details";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                totalvisitors = int.Parse(reader[0].ToString());

            }


            reader.Close();
            connection.Close();
            return totalvisitors;
        }

        public List<Zone> GetAllZone()
        {
            List<Zone> ZonesList = new List<Zone>();

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT b.name name,COUNT(a.visitor_id) no_visit FROM visitor_details a join zone b on b.id=a.zone_id group by b.name";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Zone zone = new Zone();

                
                zone.Name = reader["name"].ToString();
                zone.NoOfVisitor = int.Parse(reader["no_visit"].ToString());

                ZonesList.Add(zone);

            }


            reader.Close();
            connection.Close();
            return ZonesList;
        }
    }
}
