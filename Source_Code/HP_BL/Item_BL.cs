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
        public List<Items> GetAllItems()
        {
            return IDAL.GetAllItems();
        }

        public List<Items> GetItemByTradeMark(string trademark)
        {
            if (trademark == null)
            {
                return null;
            }

            Regex regex = new Regex("[a-zA-Z ]");
            MatchCollection matchCollectionTrademark = regex.Matches(trademark);
            if (matchCollectionTrademark.Count < trademark.Length)
            {
                return null;
            }
            return IDAL.GetItemByTradeMark(trademark);
        }

        public List<Items> GetItemByAttribute(string attribute)
        {
            if (attribute == null)
            {
                return null;
            }

            Regex regex = new Regex("[a-zA-Z ]");
            MatchCollection matchCollectionTrademark = regex.Matches(attribute);
            if (matchCollectionTrademark.Count < attribute.Length)
            {
                return null;
            }
            return IDAL.GetItemByAttribute(attribute);
        }
    }
}