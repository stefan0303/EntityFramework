using System;
using System.Data.SqlClient;
using System.Linq;

namespace _04.Add_Minion
{
    class Program
    {
        static void Main()
        {
            string[] minionInput = Console.ReadLine().Split(' ').ToArray();
            string[] villianInput = Console.ReadLine().Split(' ').ToArray();
            string minionName = minionInput[1];
            int minionAge = int.Parse(minionInput[2]);
            string minionTown = minionInput[3];
            string villianName = villianInput[1];

            SqlConnection connection = new SqlConnection
          (@"Server=(localdb)\MSSQLLocalDB;
                    Database=MinionsDB;
                        Integrated Security=true");
            connection.Open();

            using (connection)
            {
                string searchTheTown = $"SELECT * FROM Towns WHERE Name = '{minionTown}'";
                SqlCommand searchTheTownCommand = new SqlCommand(searchTheTown, connection);
                SqlDataReader searchTheTownReader = searchTheTownCommand.ExecuteReader();
                int counter = 0;
                if (searchTheTownReader.Read())
                {
                    counter = 1;
                }
                else
                {
                    counter = 0;
                }
                searchTheTownReader.Close();
                if (counter == 1)
                {
                    counter = 0;
                }
                else
                {
                    //identity function is ON
                    string addTown = $"INSERT INTO Towns (Name, Id) VALUES ('{minionTown}', {12})";
                    SqlCommand addTownCommand = new SqlCommand(addTown, connection);
                    addTownCommand.ExecuteNonQuery();
                    Console.WriteLine($"Town {minionTown} was added to the database."); counter = 0;
                }

                string searchTheVillian = $"SELECT * FROM Villians WHERE Name = '{villianName}'";
                SqlCommand searchTheVillianCommand = new SqlCommand(searchTheVillian, connection);
                SqlDataReader searchTheVillianReader = searchTheVillianCommand.ExecuteReader();
                while (searchTheVillianReader.Read())
                {
                    counter += 1;
                }
                searchTheVillianReader.Close();
                if (counter == 1)
                {
                    counter = 0;
                }
                else
                {
                    //identity function is ON
                    string addVillian = $"INSERT INTO Villians (Name, EvilnessFactor) VALUES ('{villianName}', 'evil')";
                    SqlCommand addVillianCommand = new SqlCommand(addVillian, connection);
                    addVillianCommand.ExecuteNonQuery();
                    Console.WriteLine($"Villain {villianName} was added to the database.");
                    counter = 0;
                }
                string selectTownID = $"SELECT ID FROM Towns WHERE Name = '{minionTown}'";

                SqlCommand selectTownIDCommand = new SqlCommand(selectTownID, connection);

                int TownID = 0;
                int VillianID = 0;
                int MinionID = 0;
                SqlDataReader selectTownIDReader = selectTownIDCommand.ExecuteReader();

                while (selectTownIDReader.Read())
                {
                    TownID = (int)selectTownIDReader[0];
                }
                selectTownIDReader.Close();
                string selectVillianID = $"SELECT ID FROM Villians WHERE Name = '{villianName}'";
                SqlCommand selectVillianIDCommand = new SqlCommand(selectVillianID, connection);
                SqlDataReader selectVillianIDReader = selectVillianIDCommand.ExecuteReader();

                while (selectVillianIDReader.Read())
                {
                    VillianID = (int)selectVillianIDReader[0];
                }

                selectVillianIDReader.Close();
                string addMinion = $"INSERT INTO Minions(Name, TownID, Age) VALUES ('{minionName}', {TownID}, {minionAge})";
                SqlCommand addMinionCommand = new SqlCommand(addMinion, connection);
                addMinionCommand.ExecuteNonQuery();
                Console.WriteLine($"Successfully added {minionName} to be minion of {villianName}");

                string selectMinionID = $"SELECT ID FROM Minions WHERE Name = '{minionName}'";
                SqlCommand selectMinionIDCommand = new SqlCommand(selectMinionID, connection);
                SqlDataReader selectMinionIDReader = selectMinionIDCommand.ExecuteReader();

                while (selectMinionIDReader.Read())
                {
                    MinionID = (int)selectMinionIDReader[0];
                }
                selectMinionIDReader.Close();

                string addMinionVillian = $"INSERT INTO MinionsVillians (MinionID, VillianID) VALUES ({MinionID},{VillianID})";
                SqlCommand addMinionVillianCommand = new SqlCommand(addMinionVillian, connection);
                addMinionVillianCommand.ExecuteNonQuery();
            }
        }
    }
}