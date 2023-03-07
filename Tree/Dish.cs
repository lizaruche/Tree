using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Tree
{
    internal class Dish : TreeNode
    {
        public int id;
        string name;
        double price;

        public Dish()
        {
        }

        public Dish(int id, string name, double price)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.Text = name;
        }

        public override bool Equals(object obj)
        {
            return obj is Dish dish &&
                   id == dish.id;
        }
    }
}
