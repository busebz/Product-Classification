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
using System.Data.OleDb;
using Microsoft.Office.Interop.Excel;
using System.Configuration;

namespace ProjeStaj
{
    public partial class MainPage : Form
    {
        SqlConnection conn;
        SqlDataAdapter da;
        DataSet ds;

        NewProduct form2;
        public static string progress_type;
        public bool selectAll;
        public MainPage()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            addProgressTypetoCombobox();
            comboBoxProgressType.SelectedItem = "B2B";
            textBoxProductId.Visible = false;
            addGrid();
        }

        private void buttonEkle_Click(object sender, EventArgs e)
        {      
            form2 = new NewProduct();
            progress_type= comboBoxProgressType.SelectedItem.ToString();
            form2.ShowDialog();
        }

        public void addProgressTypetoCombobox()
        {
            SqlDataReader dr;
            comboBoxProgressType.Items.Clear();
            string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("Select * from ProgressType", conn);

                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        comboBoxProgressType.Items.Add(dr["ProgressType"]);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Hata: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void buttonKaydet_Click(object sender, EventArgs e) {

            string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string add = "DELETE FROM Product WHERE product_id NOT IN (select max (product_id) from Product group by progress_type, " +
                                 "type,min_value,max_value,coefficient)";

                    SqlCommand komut = new SqlCommand(add, conn);

                    komut.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Hata: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

        }

        private void addGrid()
        {
            SqlDataReader dr;
            string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    ds = new DataSet();

                    string add = "Select product_id,progress_type, type, min_value, max_value, coefficient from Product " +
                "where progress_type = '" + comboBoxProgressType.SelectedItem.ToString() + "' order by product_id";
                    SqlCommand cmd = new SqlCommand(add, conn);

                    da = new SqlDataAdapter(cmd);
                    conn.Open();
                    da.Fill(ds, "Product");
                    dataGridView1.DataSource = ds.Tables["Product"];
                    this.dataGridView1.Columns["product_id"].Visible = false;

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Hata: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

        }

        private void buttonAra_Click(object sender, EventArgs e)
        {
            addGrid();
        }

        private void buttonSil_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    if (selectAll)
                    {
                        conn.Open();
                        string add = "Delete from Product where progress_type = @progress_type";
                        SqlCommand komut = new SqlCommand(add, conn);

                        komut.Parameters.AddWithValue("@progress_type", comboBoxProgressType.SelectedItem.ToString());

                        komut.ExecuteNonQuery();

                        conn.Close();
                        addGrid();
                    }
                    else
                    {
                        conn.Open();
                        string add = "Delete from Product where product_id = @product_id";
                        SqlCommand komut = new SqlCommand(add, conn);

                        komut.Parameters.AddWithValue("@product_id", int.Parse(textBoxProductId.Text));

                        komut.ExecuteNonQuery();

                        conn.Close();
                        addGrid();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Hata: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];

            textBoxProductId.Text = selectedRow.Cells[0].Value.ToString();
            
        }

        private void checkBoxTümünüSeç_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSelectAll.Checked)
            {
                dataGridView1.SelectAll();
                selectAll = true;
            }
            else
            {
                dataGridView1.ClearSelection();
                selectAll = false;
            }
        }

        private void ExportToExcel(DataGridView dataGridView)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();

            excel.Visible = true;

            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);

            Microsoft.Office.Interop.Excel.Worksheet sheet1 = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];

            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                sheet1.Cells[1, i + 1] = dataGridView.Columns[i].HeaderText;
            }

            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView.Columns.Count; j++)
                {
                    sheet1.Cells[i + 2, j + 1] = dataGridView.Rows[i].Cells[j].Value.ToString();
                }
            }

            //workbook.SaveAs("D:\\ornek.xlsx", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, true, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Microsoft.Office.Interop.Excel.XlSaveConflictResolution.xlUserResolution, true, Type.Missing, Type.Missing);

            //workbook.Close();

            //excel.Quit();
        }

        private void buttonExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel(dataGridView1);
        }

        private void comboBoxHakedisTipi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
