using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Dotnetframeworkwedapp_ADO.net
{           
    public partial class Brand : System.Web.UI.Page
    {
        private string connectionString = @"Server=MANASWINIREDDY\MSSQLSERVERMANU;Database=BikeStores;Trusted_Connection=True;";

        protected void Updatebtn_Click(object sender, EventArgs e)
        {
            ResetResultLabels();
            string brandName = BrandNametxt.Text;
            int brandID;
            if (!int.TryParse(BrandIDtxt.Text, out brandID))
            {
                UpdateBtnResLbl.Text = "Invalid Brand ID.";
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE production.brands SET brand_name = @barndName WHERE brand_id = @brandId";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@barndName", brandName);
                cmd.Parameters.AddWithValue("@brandId", brandID);

                try
                {
                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                        UpdateBtnResLbl.Text = "Update successful!";
                    else
                        UpdateBtnResLbl.Text = "No records updated.";
                }
                catch (Exception ex)
                {
                    UpdateBtnResLbl.ForeColor = System.Drawing.Color.Red;
                    UpdateBtnResLbl.Text = "Error: " + ex.Message;
                }
            }
            LoadBrands();
            ClearInputFields();
        }
        protected void Deletebtn_Click(object sender, EventArgs e)
        {
            ResetResultLabels();
            int brandID;
            if (!int.TryParse(BrandIDtxt.Text, out brandID))
            {
                Deletereslbl.Text = "Invalid Brand ID.";
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                ResetResultLabels();
                string query = "Delete FROM production.brands WHERE brand_id = @brandId";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@brandId", brandID);

                try
                {
                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                        Deletereslbl.Text = "Delete successful!";
                    else
                        Deletereslbl.Text = "No records deleted.";
                }
                catch (Exception ex)
                {
                    Deletereslbl.ForeColor = System.Drawing.Color.Red;
                    Deletereslbl.Text = "Error: " + ex.Message;
                }
            }
            LoadBrands();
            ClearInputFields();
        }
        protected void Insertbtn_Click(object sender, EventArgs e)
        {
            ResetResultLabels();
            string brandName = BrandNametxt.Text;
            if (!brandName.Equals(""))
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO production.brands (brand_name) VALUES (@barndName)";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@barndName", brandName);

                    try
                    {
                        connection.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                            Insertreslbl.Text = "Insertion Successful!";
                        else
                            Insertreslbl.Text = "No records inserted.";
                    }
                    catch (Exception ex)
                    {
                        Insertreslbl.ForeColor = System.Drawing.Color.Red;
                        Insertreslbl.Text = "Error: " + ex.Message;
                    }
                }
                LoadBrands();
            }
            else
            {
                Insertreslbl.Text = "Enter Brand Name to insert the records.";
            }
            ClearInputFields();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadBrands();
            }
        }

        private void LoadBrands()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM production.brands";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                BrandsGridView.DataSource = dt;
                BrandsGridView.DataBind();
            }
        }
        private void ResetResultLabels()
        {
            Insertreslbl.Text = "";
            UpdateBtnResLbl.Text = "";
            Deletereslbl.Text = "";

            Insertreslbl.ForeColor = System.Drawing.Color.Black;
            UpdateBtnResLbl.ForeColor = System.Drawing.Color.Black;
            Deletereslbl.ForeColor = System.Drawing.Color.Black;
        }

        private void ClearInputFields()
        {
            BrandIDtxt.Text = "";
            BrandNametxt.Text = "";
        }
    }
}