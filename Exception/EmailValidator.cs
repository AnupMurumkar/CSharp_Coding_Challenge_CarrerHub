
using System;
using System.Text.RegularExpressions;

namespace CareerHub.exception
{
    public static class EmailValidator
    {
        public static void ValidateEmail(string email)
        {
            
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(email, pattern))
            {
                throw new InvalidEmailException("Invalid email format. Please enter a valid email address.");
            }
        }
    }
}
