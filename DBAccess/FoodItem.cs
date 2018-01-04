using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAccess
{
    public class FoodItem
    {
        public int FoodItemId { get; set; }
        public string ItemName { get; set; }
        public double VitaminUnit { get; set; }
        public double MineralUnit { get; set; }
        public double ProteinUnit { get; set; }
    }
}
