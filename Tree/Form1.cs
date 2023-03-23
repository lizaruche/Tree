using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tree
{
    public partial class Form1 : Form
    {
        const string cs = @"Data Source=DESKTOP-RCGIBL6\SQLEXPRESS; Initial Catalog=Restaurants; Integrated Security=true;";
        Category[] categories;
        static bool loaded;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            loaded = true;
            treeData.Nodes.Clear();
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                var sql = @"select * from Restaurants.dbo.restaurants;";
                var cmd = new SqlCommand(sql, conn);

                var dr = cmd.ExecuteReader();
                categories = LoadCategories();
                while (dr.Read())
                {
                    Restaurant cur = new Restaurant(Convert.ToInt32(dr["id"].ToString()), dr["name"].ToString());
                    treeData.Nodes.Add(cur);
                    Category[] curCat = LoadCategories();
                    cur.Nodes.AddRange(curCat);
                    for (int i = 0; i < curCat.Length; i++)
                    {
                        curCat[i].Nodes.AddRange(LoadDishes(cur.id, curCat[i].id));
                    }
                }
            }
        }
        private Category[] LoadCategories()
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                List<Category> nodes = new List<Category>();
                conn.Open();
                var sql = @"select * from Restaurants.dbo.categories;";
                var cmd = new SqlCommand(sql, conn);

                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Category curCat = new Category(Convert.ToInt32(dr["id"].ToString()), dr["name"].ToString());
                    nodes.Add(curCat);
                }
                return nodes.ToArray();
            }
        }
        private TreeNode[] LoadDishes(int rest_id, int cat_id)
        {
            
            using (SqlConnection conn = new SqlConnection(cs))
            {
                List<TreeNode> nodes = new List<TreeNode>();
                conn.Open();
                var sql = @"select d.id, d.name, d.price from Restaurants.dbo.dishes as d
                            where d.restaurant_id = @rest_id and d.category_id = @cat_id;";
                var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@rest_id", rest_id);
                cmd.Parameters.AddWithValue("@cat_id", cat_id);

                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Dish curCat = new Dish(Convert.ToInt32(dr["id"].ToString()), dr["name"].ToString(), Convert.ToDouble(dr["price"].ToString()));
                    nodes.Add(curCat);
                }
                return nodes.ToArray();
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            switch (treeData.SelectedNode)
            {
                case Restaurant _:
                    удалитьToolStripMenuItem.Enabled = true;
                    изменитьToolStripMenuItem.Enabled = true;
                    рестаранToolStripMenuItem.Enabled = true;
                    категориюToolStripMenuItem.Enabled = true;
                    блюдоToolStripMenuItem.Enabled = false;
                    break;
                case Category _:
                    удалитьToolStripMenuItem.Enabled = true;
                    изменитьToolStripMenuItem.Enabled = true;
                    рестаранToolStripMenuItem.Enabled = true;
                    категориюToolStripMenuItem.Enabled = true;
                    блюдоToolStripMenuItem.Enabled = true;
                    break;
                case Dish _:
                    удалитьToolStripMenuItem.Enabled = true;
                    изменитьToolStripMenuItem.Enabled = true;
                    рестаранToolStripMenuItem.Enabled = true;
                    категориюToolStripMenuItem.Enabled = true;
                    блюдоToolStripMenuItem.Enabled = true;
                    break;
                default:
                    удалитьToolStripMenuItem.Enabled = false;
                    изменитьToolStripMenuItem.Enabled = false;
                    рестаранToolStripMenuItem.Enabled = loaded;
                    категориюToolStripMenuItem.Enabled = false;
                    блюдоToolStripMenuItem.Enabled = false;
                    break;
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (treeData.SelectedNode)
            {
                case Restaurant _:
                    DeleteRestaurant();
                    treeData.SelectedNode.Remove();
                    break;
                case Category _:
                    DeleteCategory();
                    LoadData();
                    break;
                case Dish _:
                    DeleteDish();
                    treeData.SelectedNode.Remove();
                    break;
            }
        }
        private void DeleteRestaurant()
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                var sql = @"delete from Restaurants.dbo.restaurants where id = @rest_id";
                var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@rest_id", ((Restaurant)treeData.SelectedNode).id);
                cmd.ExecuteNonQuery();
            }
        }
        private void DeleteCategory()
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                var sql = @"delete from Restaurants.dbo.categories where id = @cat_id";
                var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@cat_id", ((Category)treeData.SelectedNode).id);
                cmd.ExecuteNonQuery();
            }
        }
        private void DeleteDish()
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                var sql = @"delete from Restaurants.dbo.dishes where id = @dish_id";
                var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@dish_id", ((Dish)treeData.SelectedNode).id);
                cmd.ExecuteNonQuery();
            }
        }
        private void NewRestaurant(string name)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                var sql = $"insert into Restaurants.dbo.restaurants (name) values ('{name}');";
                var cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
        }
        private void NewCategory(string name)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                var sql = $"insert into Restaurants.dbo.categories (name) values ('{name}');";
                var cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
        }
        private void NewDish(string name, int price, int restId, int catId)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                var sql = $"insert into Restaurants.dbo.dishes (name, price, category_id, restaurant_id) values ('{name}', {price}, {restId}, {catId});";
                var cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
        }

        private void рестаранToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var c = new CreateUpdate("Новый ресторан"))
            {
                if (c.ShowDialog() == DialogResult.OK)
                {
                    NewRestaurant(c.name);
                    LoadData();
                    c.Close();
                }
                else c.Close();
            }
        }
        private void категориюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var c = new CreateUpdate("Hoвая Категория"))
            {
                if (c.ShowDialog() == DialogResult.OK)
                {
                    NewCategory(c.name);
                    LoadData();
                    c.Close();
                }
                else c.Close();
            }
        }

        private void блюдоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeData.SelectedNode is Dish)
            {
                using (var c = new CreateUpdate(treeData.SelectedNode.Parent.Text + " => " + treeData.SelectedNode.Parent.Parent.Text, true))
                {
                    if (c.ShowDialog() == DialogResult.OK)
                    {
                        NewDish(c.name, c.price, ((Category)treeData.SelectedNode.Parent).id, ((Restaurant)treeData.SelectedNode.Parent.Parent).id);
                        LoadData();
                        c.Close();
                    }
                    else c.Close();
                }
            }
            else
            {
                using (var c = new CreateUpdate(treeData.SelectedNode.Text + " => " + treeData.SelectedNode.Parent.Text, true))
                {
                    if (c.ShowDialog() == DialogResult.OK)
                    {
                        NewDish(c.name, c.price, ((Category)treeData.SelectedNode).id, ((Restaurant)treeData.SelectedNode.Parent).id);
                        LoadData();
                        c.Close();
                    }
                    else c.Close();
                }
            }
            
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (treeData.SelectedNode)
            {
                case Restaurant _:
                    using (var c = new CreateUpdate("Изменить Ресторан"))
                    {
                        if (c.ShowDialog() == DialogResult.OK)
                        {
                            EditRestaurant(c.name);
                            LoadData();
                            c.Close();
                        }
                        else c.Close();
                    }
                    break;
                case Category _:
                    using (var c = new CreateUpdate("Изменить Категорию"))
                    {
                        if (c.ShowDialog() == DialogResult.OK)
                        {
                            EditCategory(c.name);
                            LoadData();
                            c.Close();
                        }
                        else c.Close();
                    }
                    break;
                case Dish _:
                    using (var c = new CreateUpdate("Изменить Блюдо", true))
                    {
                        if (c.ShowDialog() == DialogResult.OK)
                        {
                            EditDish(c.name, c.price);
                            LoadData();
                            c.Close();
                        }
                        else c.Close();
                    }
                    break;
            }
        }
        private void EditDish(string name, int price)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                var sql = @"update Restaurants.dbo.dishes 
                            set name=@name, price=@price
                            where id=@dish_id;";
                var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@dish_id", ((Dish)treeData.SelectedNode).id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.ExecuteNonQuery();
            }
        }
        private void EditRestaurant(string name)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                var sql = @"update Restaurants.dbo.restaurants 
                            set name=@name
                            where id=@rest_id;";
                var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@rest_id", ((Restaurant)treeData.SelectedNode).id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.ExecuteNonQuery();
            }
        }
        private void EditCategory(string name)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                var sql = @"update Restaurants.dbo.categories 
                            set name=@name
                            where id=@category_id;";
                var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@category_id", ((Category)treeData.SelectedNode).id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
