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

    }
}