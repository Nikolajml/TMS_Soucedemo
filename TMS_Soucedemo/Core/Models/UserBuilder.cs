using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class UserBuilder
    {
        private User user;

        public UserBuilder()
        {
            user = new User();
        }

        public UserBuilder SetUsername(string username)
        {
            user.Username = username;
            return this;
        }

        public UserBuilder SetPassword(string password)
        {
            user.Password = password;
            return this;
        }

        public UserBuilder SetFirstName(string firstName)
        {
            user.FirstName = firstName;
            return this;
        }

        public UserBuilder SetLastName(string lastName)
        {
            user.LastName = lastName;
            return this;
        }

        public UserBuilder SetZipCode(string userCode)
        {
            user.UserCode = userCode;
            return this;
        }

        public User Build()
        {
            return user;
        }
    }
}