using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NuWay
{
    public partial class MyMealForm : Form
    {
        List<string> meals = new List<string>();
        public string MealSelect{ get; set; }
        public OleDbConnection conn;
        public OleDbCommand cmd;
        public OleDbDataReader reader;
        public string CurrentUser { get; set; }
        List<CustomMeals> customMeals = new List<CustomMeals>();
        List<string> customMealProfiles = new List<string>();

        public static string selectString = "SELECT UserName, [Meal 1], [Meal 2], [Meal 3], [Meal 4], [Meal 5], [Meal 6], [Meal 7], [Meal 8], [Meal 9], [Meal 10] FROM userMeals";


        public MyMealForm()
        {
            InitializeComponent();
            for (int i = 1; i <= 10; i++)
            {
                lbMealNum.Items.Add("Meal " + i);
                meals.Add("Combo #1 $5.29;Spicy Dog $1.99");
            }
        }

        private void MyMealForm_Load(object sender, EventArgs e)
        {
            lbMealNum.SelectedIndex = 0;
            ConnectToDb();
            tbMeal.Text = meals.ElementAt(0).Replace(";", "\r\n");
            MealSelect = "";
        }

        private void ConnectToDb()
        {
            conn = new OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;" + @"Data source= userMeals.mdb;";
            try
            {
                conn.Open();
                cmd = new OleDbCommand(selectString, conn);
                reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    customMealProfiles.Add(reader["UserName"].ToString());
                    customMeals.Add(new CustomMeals(reader["Meal 1"].ToString(), reader["Meal 2"].ToString(), 
                        reader["Meal 3"].ToString(), reader["Meal 4"].ToString(), reader["Meal 5"].ToString(), reader["Meal 6"].ToString(),
                        reader["Meal 7"].ToString(), reader["Meal 8"].ToString(), reader["Meal 9"].ToString(), reader["Meal 10"].ToString()));
                }

                if(!customMealProfiles.Contains(CurrentUser))
                {
                    string insertString = "INSERT INTO userMeals ([UserName],[Meal 1],[Meal 2],[Meal 3],[Meal 4],[Meal 5],[Meal 6],[Meal 7],[Meal 8],[Meal 9],[Meal 10]) VALUES (@User, @Meal1, @meal2, @meal3, @meal4, @meal5, @meal6, @meal7, @meal8, @meal9, @meal10)";
                    cmd = new OleDbCommand(insertString, conn);
                    cmd.Parameters.AddWithValue("@User", CurrentUser);
                    cmd.Parameters.AddWithValue("@Meal1", "Combo #1 $5.29;Spicy Dog $1.99");
                    cmd.Parameters.AddWithValue("@Meal2", "Combo #1 $5.29;Spicy Dog $1.99");
                    cmd.Parameters.AddWithValue("@Meal3", "Combo #1 $5.29;Spicy Dog $1.99");
                    cmd.Parameters.AddWithValue("@Meal4", "Combo #1 $5.29;Spicy Dog $1.99");
                    cmd.Parameters.AddWithValue("@Meal5", "Combo #1 $5.29;Spicy Dog $1.99");
                    cmd.Parameters.AddWithValue("@Meal6", "Combo #1 $5.29;Spicy Dog $1.99");
                    cmd.Parameters.AddWithValue("@Meal7", "Combo #1 $5.29;Spicy Dog $1.99");
                    cmd.Parameters.AddWithValue("@Meal8", "Combo #1 $5.29;Spicy Dog $1.99");
                    cmd.Parameters.AddWithValue("@Meal9", "Combo #1 $5.29;Spicy Dog $1.99");
                    cmd.Parameters.AddWithValue("@Meal10", "Combo #1 $5.29;Spicy Dog $1.99");
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    int index = customMealProfiles.IndexOf(CurrentUser);
                    meals = new List<string>();
                    meals.Add(customMeals.ElementAt(index).Meal1);
                    meals.Add(customMeals.ElementAt(index).Meal2);
                    meals.Add(customMeals.ElementAt(index).Meal3);
                    meals.Add(customMeals.ElementAt(index).Meal4);
                    meals.Add(customMeals.ElementAt(index).Meal5);
                    meals.Add(customMeals.ElementAt(index).Meal6);
                    meals.Add(customMeals.ElementAt(index).Meal7);
                    meals.Add(customMeals.ElementAt(index).Meal8);
                    meals.Add(customMeals.ElementAt(index).Meal9);
                    meals.Add(customMeals.ElementAt(index).Meal10);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Failed to connect");
            }
            finally
            {
                conn.Close();
            }
        }

        private void lbMealNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbMeal.Text = meals.ElementAt(lbMealNum.SelectedIndex).Replace(";", "\r\n");
        }

        private void bSelect_Click(object sender, EventArgs e)
        {
            MealSelect = meals.ElementAt(lbMealNum.SelectedIndex);
            Close();
        }
    }
}
