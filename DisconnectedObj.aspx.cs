using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace AdoConnection
{
    public partial class DisconnectedObj : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-TF8J12F;Initial Catalog=JulDotnetBatch2020;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from EmployeeTbl", conn);
            SqlCommand cmd1 = new SqlCommand("select * from BookTbl", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataSet ds = new DataSet();
            da.Fill(ds, "Emp");
            da1.Fill(ds, "Book");
            GridView1.DataSource = ds.Tables["Emp"];
            GridView1.DataBind();
            GridView2.DataSource = ds.Tables["Book"];
            GridView2.DataBind();
        }
    }
}