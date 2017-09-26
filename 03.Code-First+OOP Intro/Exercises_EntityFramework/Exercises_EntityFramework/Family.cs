using System;
using System.Collections.Generic;

namespace Exercises_EntityFramework
{
    class Family
    {
        private List<Person> members;

        public Family()
        {
           this.members=new List<Person>();
        }

        public List<Person> Members
        {
            get { return members; }
        }

        public void AddMember(Person member)
        {
            members.Add(member);
        }

        public void  GetOldestMember()
        {
            int maxAge = 0;
            string nameOfMaxAgePerson = "";
            foreach (var age in members)
            {
                if (maxAge<age.Age)
                {
                    maxAge = age.Age;
                    nameOfMaxAgePerson = age.Name;
                }
               
            }
            string nameAge = nameOfMaxAgePerson + " " + Convert.ToString(maxAge);
            Console.WriteLine(nameAge);
           
        }
    }
}
