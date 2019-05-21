using System;
using HP_Persistence;
using HP_DAL;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace HP_BL
{
    public class Item_BL
    {
        private Item_DAL IDAL = new Item_DAL();

        public Items GetItemByProduceCode(int? Produce_Code)
        {
            Regex regex = new Regex("[a-zA-Z0-9]");
            MatchCollection matchCollection = regex.Matches(Produce_Code.ToString());
            if (Produce_Code == null)
            {
                return null;
            }
            else if (matchCollection.Count < Produce_Code.ToString().Length)
            {
                return null;
            }
            return IDAL.GetItemByProduceCode(Produce_Code);
        }
    }
}