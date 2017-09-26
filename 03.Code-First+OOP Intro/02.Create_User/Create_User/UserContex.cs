using Create_User.Models;

namespace Create_User
{
    using System.Data.Entity;

    public class UserContex : DbContext
    {
        
        public UserContex()
            : base("name=UserContex")
        {

        }
        public IDbSet<User> Users { get; set; }

    }
  
}