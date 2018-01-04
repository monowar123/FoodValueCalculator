using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DBAccess
{
    public class FoodDBContext : DbContext
    {
        public FoodDBContext() : base("name=FoodDBConnection") { }

        public DbSet<FoodItem> FoodItems { get; set; }
    }
}
