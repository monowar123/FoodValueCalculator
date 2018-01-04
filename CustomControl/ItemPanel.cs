using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBAccess;

namespace CustomControl
{
    public partial class ItemPanel: UserControl
    {
        public string SelectedItem
        {
            get
            {
                if (cmbItemList.SelectedIndex > -1)
                    return cmbItemList.SelectedItem.ToString();
                else
                    return "";
            }
        }

        public double Ammount
        {
            get
            {
                return double.Parse(txtAmount.Text);
            }
        }

        public ItemPanel()
        {
            InitializeComponent();
        }

        private void ItemPanel_Load(object sender, EventArgs e)
        {
            FoodDBContext dbContext = new FoodDBContext();
            var qeury = from item in dbContext.FoodItems orderby item.ItemName ascending select item.ItemName;
            string[] ItemArray = qeury.ToArray();

            cmbItemList.Items.AddRange(ItemArray);
        }

        private void cmbItemList_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
    }
}
