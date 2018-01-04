using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomControl;
using DBAccess;

namespace FoodValueCalculator
{
    public partial class Form1 : Form
    {
        BusinessHelper businessHelper = new BusinessHelper();
        static int ItemPanelCounter = 0;

        public Form1()
        {
            InitializeComponent();
            Add_ItemPanel();
            Add_ItemPanel();
        }

        private void Add_ItemPanel(int initialHeight = 15)
        {
            ItemPanel itemPanel = new ItemPanel();
            itemPanel.Name = "itemPanel_" + ItemPanelCounter;
            itemPanel.Location = new Point(0, ItemPanelCounter * itemPanel.Height + initialHeight);

            groupBox1.Controls.Add(itemPanel);
            ItemPanelCounter++;
        }

        private void btnAddNewItem_Click(object sender, EventArgs e)
        {
            Add_ItemPanel();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            Dictionary<string, double> itemDictionary = new Dictionary<string, double>();
            foreach (ItemPanel control in groupBox1.Controls)
            {
                itemDictionary[control.SelectedItem] = control.Ammount;
            }
            var Ingredients = businessHelper.CalculateIngredients(itemDictionary);

            txtVitamin.Text = Convert.ToString(Ingredients.Vitamin);
            txtMineral.Text = Convert.ToString(Ingredients.Mineral);
            txtProtein.Text = Convert.ToString(Ingredients.Protein);
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            dataGridView1.DataSource = businessHelper.GetAllFoodItems();
            dataGridView1.Refresh();
        }
    }
}
