using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Tree
{
    internal class Restaurant : TreeNode
    {
        public int id;
        public string name;

        public Restaurant()
        {
        }

        public Restaurant(int id, string name)
        {
            this.id = id;
            this.name = name;
            this.Text = name;
        }
    }
}
