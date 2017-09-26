using System;
using System.Data.SqlClient;

namespace _03.Get_Minion_Names
{
    class Program
    {
        static void Main()
        {
            //Connecting to SQL Minions
            string connectionString = "Server=(localdb)\\MSSQLLocalDB; Database=MinionsDB ;Integrated Security=true";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open(); //Open the connection

            using (connection)
            {
                //Make the SELECT QUERY
                int villainId = int.Parse(Console.ReadLine());
                //string FindNamequery = File.ReadAllText("../../nameOftheFile");
                string selectionString = "select m.name, age\n" +
                    "FROM Villains v\n" +
                    "JOIN MinionsVillains mv ON v.Id = mv.VillainId\n" +
                    "JOIN Minions m ON m.id = mv.MinionId\n" +
                    "WHERE v.Id = 1";
                SqlCommand findVillainNameCommand = new SqlCommand(selectionString, connection);
                SqlParameter villainIdParam = new SqlParameter("@villainName", villainId);

                findVillainNameCommand.Parameters.Add(villainIdParam);
                SqlDataReader reader = findVillainNameCommand.ExecuteReader();
                // SqlDataReader reader = selectCommand.ExecuteReader();

                if (reader.Read())
                {
                    string villName = (string)reader["name"];
                    Console.WriteLine("Villain: "+villName);
                    string findMinionsQuery = @"SELECT Name,Age FROM Minions as m
                                            INNER JOIN MinionsVillains as Vm
                                            ON vm.MinionId = m.Id
                                            WHERE Id = @villainId";
                  
                }
                else
                {
                    Console.WriteLine("No villain with ID {0} exists in the database.",villainId);
                }
                using (reader)
                {
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.Write(reader[i] + " ");
                        }
                        Console.WriteLine();
                    }
                    reader.Close();
                }
            }

        }
    }
}
