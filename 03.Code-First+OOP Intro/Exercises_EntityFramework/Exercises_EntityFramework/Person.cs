using System;

namespace Exercises_EntityFramework
{
    class Person
    {
        private string name { get; set; }
        private int age { get; set; }

        public Person()
        {
            this.Name = "No name";
            this.Age= 1;
        }

        public Person(string name) :this(name,1)
        {
            this.Name = name;
            this.Age = 1;
        }

        public Person(int age):this("No name!",age)
        {
            this.Name = "No name!";
            this.Age = age;
        }

        public Person(string name, int age)
        {
            this.Age = age;
            this.Name = name;
        }
        public int Age
        {
            get { return this.age; }

            set
            {
                if (value<0)
                {
                    throw  new ArgumentException("Invalid age!");
                }
                this.age = value;
            }

        }

        public  string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid first name!");
                }
                this.name = value;
            }

        }
    }
}
