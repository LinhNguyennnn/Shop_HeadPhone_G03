using System;
using HP_Persistence;
using HP_DAL;
using System.Text.RegularExpressions;

namespace HP_BL
{
    public class Customer_BL
    {
        private Customer_DAL CDAL = new Customer_DAL();
        public Customers Login(string username, string password)
        {
            if ((username == null) || (password == null))
            {
                return null;
            }
            Regex regex = new Regex("[a-zA-Z0-9_]");
            MatchCollection MatchCollectionUsername = regex.Matches(username);
            MatchCollection MatchCollectionPassword = regex.Matches(password);
            if (MatchCollectionUsername.Count < username.Length || MatchCollectionPassword.Count < password.Length)
            {
                return null;
            }
            return CDAL.Login(username, password);
        }
    }
}