using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
    {
        static void Main(string[] args)
        {
        string connectionString = "Server=(localdb)\\MSSQLLocalDB; Database=MinionsDB ;Integrated Security=true";
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open(); //Open the connection

        connection.Open();
            using (connection)
            {

                SqlCommand updateTowns = new SqlCommand($@"
                                                UPDATE Towns 
                                                SET TownName = UPPER(TownName)
                                                WHERE Country = @countryName", connection);
                updateTowns.Parameters.AddWithValue("@Country", countryName);
                int affectedRows = updateTowns.ExecuteNonQuery();

                Console.WriteLine($"{affectedRows} names were affected.");

                SqlCommand selectUpdated = new SqlCommand($@"SELECT TownName FROM Towns WHERE Country = '{countryName}'", connection);
                SqlDataReader reader = selectUpdated.ExecuteReader();
                List<string> updatedTowns = new List<string>();

                while (reader.Read())
                {
                    updatedTowns.Add(reader[0].ToString());
                }

                Console.WriteLine($"[{String.Join(", ", updatedTowns)}]");

            }
        }
    }
