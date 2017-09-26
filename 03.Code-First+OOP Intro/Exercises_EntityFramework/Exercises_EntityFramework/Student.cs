
namespace Exercises_EntityFramework
{
    class Student
    {
        private string name;
        public static int countStudents = 0;              

        public string Name
        {
            get { return this.name; }
            set
            {
                countStudents++;
                this.name = value;
            }
        }
    }
}
