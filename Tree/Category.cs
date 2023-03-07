using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Tree
{
    internal class Category : TreeNode
    {
        public int id;
        public string name;

        public Category()
        {
            this.id = -1;
        }

        public Category(int id, string name)
        {
            this.id = id;   
            this.name = name;
            this.Text = name;
        }

        public override bool Equals(object obj)
        {
            base.Equals(obj);
            return obj is Category category &&
                   id == category.id &&
                   name == category.name;
        }
    }
}
