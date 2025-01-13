using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProjeStaj
{
    public partial class NewProduct : Form
    {
        SqlConnection conn;
        SqlDataAdapter da;
        DataSet ds;

        public static string progress_type;
        public static string type;
        public static int minValue;
        public static int maxValue;
        public int coefficient;
        public NewProduct()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            AddProgressTypetoCombobox();
            comboBoxProgressType.SelectedItem = MainPage.progress_type;
            radioButtonFile.Checked = true;

        }

        public int IsThere(string progress_type, string type, int min_value, int max_value, int coefficient)
        {
            int result = 0;
            string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "SELECT COUNT(product_id) FROM Product WHERE progress_type = @progress_type AND " +
                                   "type = @type AND min_value = @min_value AND max_value = @max_value AND coefficient = @coefficient";

                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@progress_type", progress_type);
                    command.Parameters.AddWithValue("@type", type);
                    command.Parameters.AddWithValue("@min_value", min_value);
                    command.Parameters.AddWithValue("@max_value", max_value);
                    command.Parameters.AddWithValue("@coefficient", coefficient);

                    conn.Open();
                    result = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            return result;
        }

        public void AddProgressTypetoCombobox()
        {
            comboBoxProgressType.Items.Clear();
            conn = new SqlConnection();
            SqlDataReader dr;

            string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Select * from ProgressType", conn);

                    conn.Open();
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        comboBoxProgressType.Items.Add(dr["ProgressType"]);
                    }

                    conn.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }

            }
        }

        private void comboBoxHakedisTipi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxProgressType.SelectedItem.ToString() == "INDIVIDUAL" || comboBoxProgressType.SelectedItem.ToString() == "PRODUCT")
            {
                radioButtonFile.Enabled = false;
                radioButtonParcel.Enabled = false;
                textBoxMinValue.Enabled = false;
                textBoxMaxValue.Enabled = false;
                textBoxCoefficient.Enabled = true;
            }
            else
            {
                radioButtonFile.Enabled = true;
                radioButtonParcel.Enabled = true;
                textBoxMinValue.Enabled = true;
                textBoxMaxValue.Enabled = true;
                textBoxCoefficient.Enabled = true;
            }
        }

        private void AddInfoToSql()
        {
            conn = new SqlConnection();
            string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string add = "insert into Product(progress_type,type,min_value,max_value,coefficient) values (@progress_type,@type, @min_value, @max_value,@coefficient)";
                    SqlCommand command = new SqlCommand(add, conn);


                    command.Parameters.AddWithValue("@progress_type", progress_type);
                    command.Parameters.AddWithValue("@type", type);
                    command.Parameters.AddWithValue("@min_value", minValue);
                    command.Parameters.AddWithValue("@max_value", maxValue);
                    command.Parameters.AddWithValue("@coefficient", int.Parse(textBoxCoefficient.Text));

                    command.ExecuteNonQuery();

                    conn.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void buttonEkle_Click(object sender, EventArgs e)
        {
            progress_type = comboBoxProgressType.SelectedItem.ToString();
            minValue = 0;
            maxValue = 999;

            type = "";
            bool isChecked = radioButtonFile.Checked;
            if (isChecked)
                type = radioButtonFile.Text;
            else
                type = radioButtonParcel.Text;


            if (progress_type == "INDIVIDUAL" || progress_type == "PRODUCT")
            {
                if(textBoxCoefficient.Text.ToString().Length == 0)
                {
                    MessageBox.Show("You have to fill in the coefficient field.", "Error");
                }

                else
                {
                    minValue = 0;
                    maxValue = 999;
                    if (IsThere(progress_type, type, minValue, maxValue, int.Parse(textBoxCoefficient.Text)) != 0)
                    {
                        MessageBox.Show("You cannot add the same record again.", "Error.");                      
                    }
                    else
                    {
                        AddInfoToSql();
                        MessageBox.Show("Information added successfully.", "Successfull");
                        this.Close();
                    }

                }

            }
            else
            {
                if (textBoxMinValue.Text.ToString().Length == 0 || textBoxMaxValue.Text.ToString().Length == 0 || textBoxCoefficient.Text.ToString().Length == 0)
                {
                    MessageBox.Show("Please complete all.", "Error");
                }
                else
                {
                    if (System.Text.RegularExpressions.Regex.IsMatch(textBoxMinValue.Text, "[^0-9]"))
                    {
                        minValue = int.Parse(textBoxMinValue.Text.Replace("+", ""));
                        maxValue = 999;

                    }
                    else
                    {
                        minValue = int.Parse(textBoxMinValue.Text);
                        maxValue = int.Parse(textBoxMaxValue.Text);

                    }

                    if (IsThere(progress_type, type, minValue, maxValue, int.Parse(textBoxCoefficient.Text)) != 0)
                    {
                        MessageBox.Show("You cannot add same info again.", "Error.");
                    }
                    else
                    {
                        AddInfoToSql();
                        MessageBox.Show("Info added successfully.", "Successfull");
                        this.Close();
                    }
                }              
            }
            
        }
       
    }
    
}
