using System;
using HP_Persistence;
using HP_DAL;
using System.Text.RegularExpressions;
using System.Collections.Generic;

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
        public Customers GetProfileCus(string username)
        {
            if (username == null)
            {
                return null;
            }
            Regex regex = new Regex("[a-zA-Z0-9_]");
            MatchCollection matchCollectionUser = regex.Matches(username);
            if (matchCollectionUser.Count < username.Length)
            {
                return null;
            }
            return CDAL.GetProfileCus(username);
        }
    }
}