using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoalTestBTS.Models
{
    public class ShoppingContext: DbContext
    {
        public string Connectionstring { get; set; }

        public ShoppingContext(string connectionstring)
        {
            this.Connectionstring = connectionstring;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(Connectionstring);
        }

        public List<Shopping> GetShoppedItem()
        {
            List<Shopping> list = new List<Shopping>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from shopping", conn);

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Shopping()
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Name = reader["name"].ToString(),
                        CreatedDate = DateTime.Parse(reader["created_date"].ToString()),
                    });
                }
            }
            return list;
        }

        public Shopping StoreShoppedItem(string name, DateTime createdDate)
        {
            Shopping item = new Shopping();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO shopping(name, created_date) VALUES (" + name + ", " + createdDate.ToString("yyyy-MM-dd") + ")", conn);

                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@created_date", createdDate);

                /*
                if (cmd.ExecuteNonQuery() > 0)
                {
                    //
                }
                */
            }

            return item;
        }
    }
}
