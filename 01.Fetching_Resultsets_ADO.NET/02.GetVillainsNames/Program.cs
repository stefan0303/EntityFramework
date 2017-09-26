using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        //Connecting to SQL Minions
        string connectionString = "Server=(localdb)\\MSSQLLocalDB; Database=MinionsDB ;Integrated Security=true";
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open(); //Open the connection

        string selectVillians = @"SELECT v.Name, COUNT(vm.MinionId) AS MinionsCount FROM Villains as v 
                                    INNER JOIN MinionsVillains as vm
                                    ON v.Id = vm.VillainId
                                    GROUP BY v.Name
                                    HAVING COUNT(vm.MinionId) >= 3
                                    ORDER BY MinionsCount DESC";
        
        SqlCommand command = new SqlCommand(selectVillians, connection);
        using (connection)
        {
           SqlDataReader reader=  command.ExecuteReader();
            while (reader.Read())
            {
                string villainName = (string)reader["name"];
                int countSurbonates = (int)reader["MinionsCount"];
                Console.WriteLine(villainName+" "+countSurbonates);
            }
        }
    }
}

