using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBAccess;
using System.Data;
using System.Data.Entity;

namespace FoodValueCalculator
{
    public class BusinessHelper
    {
        FoodDBContext dbContext;
        public BusinessHelper()
        {
            dbContext = new FoodDBContext();
        }

        public IEnumerable<FoodItem> GetAllFoodItems()
        {
            var query = from item in dbContext.FoodItems select item;
            IEnumerable<FoodItem> itemList = query.ToList();

            return itemList;
        }

        public dynamic CalculateIngredients(Dictionary<string, double> itemDictionary)
        {
            double vitamin = 0;
            double mineral = 0;
            double protein = 0;

            foreach (string key in itemDictionary.Keys)
            {
                if (key == "")
                    continue;

                var query = (from item in dbContext.FoodItems where item.ItemName == key select new { item.VitaminUnit, item.MineralUnit, item.ProteinUnit }).Single();
                
                vitamin += itemDictionary[key] * query.VitaminUnit;
                mineral += itemDictionary[key] * query.MineralUnit;
                protein += itemDictionary[key] * query.ProteinUnit;
            }

            return new { Vitamin = vitamin, Mineral = mineral, Protein = protein };
        }

    }
}
