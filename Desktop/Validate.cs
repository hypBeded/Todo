using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Desktop
{
      public class Validate
        {
            private readonly string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            public bool ValidateEmail(string email)
            {
                    if (string.IsNullOrEmpty(email))
                    {
                        return false;
                    }
                return Regex.IsMatch(email, emailPattern);
            }
            public bool ValidatePassword(string Password)
            {
                return !string.IsNullOrWhiteSpace(Password) && Password.Length >= 6;
            }

        }
}
