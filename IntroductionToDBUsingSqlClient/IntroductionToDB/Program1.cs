using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;


namespace IntroductionToDBusingSQLCLIENT
{
    class Program1
    {
        static void Main(string[] args)
        {
            var villains = new List<Villain>();

            int ID = int.Parse(Console.ReadLine());
            int counter = 1;
            string connectionstring = @"Server=DESKTOP-FN9KGGA\SQLEXPRESS;" +
                                     @"Database=MinionsDB;" +      // !!! Da se svurzva s tochnata baza
                                     @"Integrated Security=True";
            var connection = new SqlConnection(connectionstring);

            connection.Open();

            using (connection)
            {
                /*  var commandText = "SELECT COUNT(*) FROM EMPLOYEES";  Sus SoftUni bazata

                  var command = new SqlCommand(commandText,connection);

                  var result = command.ExecuteScalar();

                  Console.WriteLine($"Number of Employees: {result}"); */

                /*  var commandText = @"select Villains.Name, Count(MinionsVillains.MinionId) as [MinionsCount] " +
                      @"from Villains join MinionsVillains on Villains.Id = MinionsVillains.VillainId " +
                      @"join Minions on Minions.Id = MinionsVillains.VillainId " +
                      @"group by Villains.Name " +
                      @"having Count(MinionsVillains.MinionId) >= 3 "+
                      @"order by MinionsCount desc"; */

                var commandText = $"SELECT Name FROM Villains " +
                                     $"WHERE Id = {ID}";


                var minionsSql = "SELECT Name, Age FROM Minions " +
                              "WHERE Id IN(SELECT MinionId FROM MinionsVillains " +
                              $"WHERE VillainId = {ID}) " +
                              "ORDER BY Name";

                var command = new SqlCommand(commandText, connection);
                //    command.Parameters.AddWithValue("@ID", ID);

                var reader = command.ExecuteReader();

                /*    while(reader.Read())
                  {
                      string name = (string)reader["Name"];
                      int count = (int)reader[1];
                      var currentvillain = new Villain(name,count);

                      villains.Add(currentvillain);
                  }


                  foreach (var item in villains)
                  {
                      Console.WriteLine(item);
                  }
                 */

                var villainsname = reader.Read() ? reader[0] : null;

                if (villainsname is null)
                {
                    reader.Close();

                    throw new ArgumentException($"No villain with ID {ID} exists in the database.");
                }

                Console.WriteLine($"Villain: {villainsname}");

                reader.Close();
                command = new SqlCommand(minionsSql, connection);
                reader = command.ExecuteReader();
                var exists= reader.Read() ? reader[0] : null;

                if (exists is null)
                {
                    reader.Close();

                    throw new ArgumentException($"(no minions)");
                }
                reader.Close();
                // Ако искам на ново да изпълня същата команда първо трябва да я затворя

                reader = command.ExecuteReader(); 
              

                   
                     while (reader.Read())
                    {
                        string minionsname = (string)reader["Name"];
                        int age = (int)reader["Age"];

                 

                      Console.WriteLine($"{counter}. {minionsname} {age}");
                        counter++;
                    }

                     
             
             
            }
        }
    }

}

