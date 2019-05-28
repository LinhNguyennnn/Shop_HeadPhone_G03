using System;
using HP_Persistence;
using HP_DAL;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace HP_BL
{
    public class Item_BL
    {
        private Item_DAL IDAL;
        public Item_BL()
        {
            IDAL = new Item_DAL();
        }

        public Items GetItemByProduceCode(int? Produce_Code)
        {
            if (Produce_Code == null)
            {
                return null;
            }
            Regex regex = new Regex("[0-9]");
            MatchCollection matchCollection = regex.Matches(Produce_Code.ToString());
            if (matchCollection.Count < Produce_Code.ToString().Length)
            {
                return null;
            }
            return IDAL.GetItemByProduceCode(Produce_Code);
        }
        public Items GetItemByProduceCodeAndTradeMark(int? Produce_Code, string trademark)
        {
            if (Produce_Code == null)
            {
                return null;
            }
            Regex regex = new Regex("[0-9]");
            MatchCollection matchCollection = regex.Matches(Produce_Code.ToString());
            if (matchCollection.Count < Produce_Code.ToString().Length)
            {
                return null;
            }
            return IDAL.GetItemByProduceCodeAndTradeMark(Produce_Code, trademark);
        }
        public Items GetItemByProduceCodeAndAttribute(int? Produce_Code, string attribute)
        {
            if (Produce_Code == null)
            {
                return null;
            }
            Regex regex = new Regex("[0-9]");
            MatchCollection matchCollection = regex.Matches(Produce_Code.ToString());
            if (matchCollection.Count < Produce_Code.ToString().Length)
            {
                return null;
            }
            return IDAL.GetItemByProduceCodeAndAttribute(Produce_Code, attribute);
        }
        public List<Items> GetAllItems()
        {
            return IDAL.GetAllItems();
        }

        public List<Items> GetItemByTradeMark(string trademark)
        {
            return IDAL.GetItemByTradeMark(trademark);
        }

        public List<Items> GetItemByAttribute(string attribute)
        {
            return IDAL.GetItemByAttribute(attribute);
        }
    }
}