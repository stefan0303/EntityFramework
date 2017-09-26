using System;
using System.Collections.Generic;
using System.Linq;
using Create_User.Models;

namespace Create_User
{
    class Program
    {
        static void Main()
        {
      
            UserContex contex = new UserContex();

            string commmand = Console.ReadLine();//Write number of command (12 or  13)
            if (commmand == "12")
            {
                GetUsersByEmailProvider(contex);
            }
            if (commmand == "13")
            {
              RemoveInactiveUsers(contex);
            }
      
        }

        static void GetUsersByEmailProvider(UserContex contex)
        {
            string email = Console.ReadLine();
            foreach (var u in contex.Users)
            {
                if (u.Email.Substring(u.Email.Length-email.Length,email.Length)==email)
                {

                    Console.WriteLine(u.Username+" "+u.Email);
                }
            }
        }

        static void RemoveInactiveUsers(UserContex contex)
        {
            string[] date = Console.ReadLine().Split().ToArray();

            string day = date[0];
            string month = date[1];
            string year = date[2];
            string dates = day + "/" + month + "/" + year;
            DateTime dt = Convert.ToDateTime(dates);
            int count = 0;
            List<User> usersForDelete = new List<User>();
            foreach (var u in contex.Users)
            {
                if (dt > u.LastTimeLoggedIn && u.isDeleted == false)
                {
                    count += 1;
                    u.isDeleted = true;

                    usersForDelete.Add(u);
                }
            }
            if (count > 0)
            {
                Console.WriteLine(count + " users have been deleted");
            }
            else
            {
                Console.WriteLine("No users have been deleted");
            }
            foreach (var u in usersForDelete)
            {

                contex.Users.Remove(u);
            }
            contex.SaveChanges();
        }
    }
}
