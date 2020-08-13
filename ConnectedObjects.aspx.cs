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

    public partial class ConnectedObjects : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-TF8J12F;Initial Catalog=JulDotnetBatch2020;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        DataTable dt;
        public void ShowGrid()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from EmployeeTbl", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();//empty table
            dt.Load(dr);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            dr.Close();
            conn.Close();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            // using (SqlConnection conn = new SqlConnection())
            // {

            // }

            //conn.Open();
            //SqlCommand cmd = new SqlCommand("select * from EmployeeTbl",conn);

            //SqlDataReader dr = cmd.ExecuteReader();
            //DataTable dt = new DataTable();//empty table
            //dt.Load(dr);
            //GridView1.DataSource = dt;
            //GridView1.DataBind();
            // while (dr.Read())
            // {
            //    GridView1.DataSource = dr;
            // DropDownList1.DataSource = dr[1];

            //   GridView1.DataBind();
            //  DropDownList1.DataBind();
            // }
            //dr.Close();
            // conn.Close();
            if (!IsPostBack)
            {
                ShowGrid();
            }
        }

        protected void btnInsertEmp_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into EmployeeTbl(empName,empSal)values('" + txtEname.Text + "'," + txtEsal.Text + ")", conn);
            int x = cmd.ExecuteNonQuery();
            conn.Close();
            ShowGrid();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("update EmployeeTbl set EmpName=@empName,empSal=@empsal where empId=@empid", conn);
            cmd.Parameters.Add("@empid", SqlDbType.Int).Value = Convert.ToInt32(txtEid.Text);
            cmd.Parameters.Add("@empname", SqlDbType.VarChar,20).Value = txtEname.Text;
            cmd.Parameters.Add("@empsal", SqlDbType.Float).Value = Convert.ToSingle(txtEsal.Text);
            if (cmd.ExecuteNonQuery() > 0)
            {
                Response.Write("alert(one row updated)");
            }
            conn.Close();
            ShowGrid();
        }

        protected void btnDeleteWithSP_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("sp_deleteEmp", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@empid", SqlDbType.Int).Value = Convert.ToInt32(txtEid.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            ShowGrid();
        }

        protected void BtnInstWSp_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("sp_Insert", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empname", txtEname.Text);
            cmd.Parameters.AddWithValue("@EmpSal", txtEsal.Text);
            int k = cmd.ExecuteNonQuery();
            conn.Close();
            ShowGrid();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("sp_searchEmp", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@empid", SqlDbType.Int).Value = Convert.ToInt32(txtEid.Text);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtEname.Text = dr[1].ToString();
                txtEsal.Text = dr["empsal"].ToString();
            }
            dr.Close();
            conn.Close();
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {

        }

        protected void btnInstPara_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("insert into EmployeeTbl (EmpName,EmpSal) values(@EmpName, @EmpSal)", conn);
            cmd.Parameters.AddWithValue("@EmpName", txtEname.Text);
            cmd.Parameters.AddWithValue("@EmpSal", txtEsal.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            ShowGrid();

        }

        protected void btnUpSp_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("sp_updt", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@empid", SqlDbType.Int).Value = Convert.ToInt32(txtEid.Text);
            cmd.Parameters.AddWithValue("@empname", txtEname.Text);
            cmd.Parameters.AddWithValue("@EmpSal", txtEsal.Text);
            if (cmd.ExecuteNonQuery() > 0)
            {
                Response.Write("alert(one row updated)");
            }
            conn.Close();
            ShowGrid();
        }

        protected void btnDelPara_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("delete from EmployeeTbl  where empId=@empid", conn);
            cmd.Parameters.Add("@empid", SqlDbType.Int).Value = Convert.ToInt32(txtEid.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            ShowGrid();
        }

        protected void btnUpQ_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Update EmployeeTbl set Empname='" + txtEname.Text + "',EmpSal='" + txtEsal.Text + "' where EmpId='" + txtEid.Text + "'", conn);

            cmd.ExecuteNonQuery();
            conn.Close();
            ShowGrid();
        }

        protected void btnDelq_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from EmployeeTbl   where EmpId='" + txtEid.Text + "'", conn);

            cmd.ExecuteNonQuery();
            conn.Close();
            ShowGrid();
        }
    }
}