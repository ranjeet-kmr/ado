using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ado
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // var con = new SqlConnection("data source=RANJEET\\NOOB; database=Ranjeet; integrated security =SSPI");
            // var cmd = new SqlCommand("select * from sales", con);
            // con.Open();
            //// SqlDataReader rdr = cmd.ExecuteReader();
            ////GridView1.DataSource = rdr;
            // GridView1.DataSource = cmd.ExecuteReader();
            // GridView1.DataBind();
            // con.Close();

            //string con = "data source=RANJEET\\NOOB; database=Ranjeet; integrated security =SSPI";
            //using(var sqlcon = new SqlConnection(con))
            //{
            //    var sqlcmd = new SqlCommand("select * from sales", sqlcon);
            //    sqlcon.Open();
            //    GridView1.DataSource = sqlcmd.ExecuteReader();
            //    GridView1.DataBind();
            //}

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (var con = new SqlConnection(cs))
            {
                var cmd = new SqlCommand("select * from tblProduct; select * from tblProductSales", con);
                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    GridView1.DataSource = dr;
                    GridView1.DataBind();

                    while (dr.NextResult())
                    {
                        GridView2.DataSource = dr;
                        GridView2.DataBind();
                    }

                }

            }
        }
    }
}