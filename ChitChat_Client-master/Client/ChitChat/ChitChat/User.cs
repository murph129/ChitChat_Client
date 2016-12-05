using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChitChat
{
    class User
    {
        String firstName;
        String lastName;
        String dateOfBirth;
        String email;
        String username;
        String password;

        public User()
        {
            firstName = string.Empty;
            lastName = string.Empty;
            dateOfBirth = string.Empty;
            email = string.Empty;
            username = string.Empty;
            password = string.Empty;
        }

        public String FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }

        public String LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }

        public String DateOfBirth
        {
            get
            {
                return dateOfBirth;
            }
            set
            {
                dateOfBirth = value;
            }
        }

        public String Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }

        public String UserName
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }

        public String Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }
    }
}
