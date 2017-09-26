using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace Create_User.Models
{
    public class User
    {
        private string password;
        private string email;
        [Key]
        public int Id { get; set; }

        [MaxLength(30), MinLength(4)]
        [Required]
        public string Username { get; set; }


        [Required, MaxLength(50), MinLength(6)]

        public string Password
        {
            get { return this.password; }
            set
            {
                bool containsDijit = value.Any(char.IsDigit);
                char[] specialSymbols = new char[] { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+', '<', '>', '?' };
                bool isMatch = false;
                foreach (char c in value)
                {
                    if (specialSymbols.Contains(c))
                    {
                        isMatch = true;
                    }
                }

                if (isMatch == false)
                {
                    throw new ArgumentException("Passowrd did not have special symbol!");
                }

                if (!value.Any(c => char.IsUpper(c)) && !value.Any(c => char.IsLower(c)) && containsDijit == false)
                {

                    throw new ArgumentException("There is no Upper letter, Lower Letter or there is digit");
                }
                this.password = value;
            }
        }
        public string Email
        {
            get { return this.email; }
            set
            {
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match matchValue = regex.Match(value);
                if (!matchValue.Success)
                {
                    throw new ArgumentException("Email is invalid!");
                }
                this.email = value;
            }
        }
        [MaxLength(1024 * 1024)]
        public byte[] ProfilePicture { get; set; }

        public DateTime RegisterOn { get; set; }
        public DateTime LastTimeLoggedIn { get; set; }

        [Range(1, 120)]
        public int Age { get; set; }

        public bool isDeleted { get; set; }
    }
}
