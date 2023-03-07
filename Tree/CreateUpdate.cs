using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tree
{
    public partial class CreateUpdate : Form
    {
        public string name;
        public int price;
        public CreateUpdate(string tree, bool checkPrice=false)
        {
            InitializeComponent();
            this.lbTree.Text = tree;
            this.numboxPrice.Visible = checkPrice;
            this.lbPrice.Visible = checkPrice;
            this.numboxPrice.DecMode();
            NumboxColtrols.Numbox.upRange = 10000;
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            this.name = this.textBoxName.Text;
        }

        private void numboxPrice_TextChanged(object sender, EventArgs e)
        {
            this.price = this.numboxPrice.ConvertToInt();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.numboxPrice.Text == string.Empty && this.numboxPrice.Visible || this.textBoxName.Text == string.Empty)
            {
                MessageBox.Show("Заполните поля!");
            }
            else
                this.DialogResult = DialogResult.OK;
        }

        private void btnCanel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
