using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Appliedproject1
{
    
    public partial class WebForm1 : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }
       
        public String constring = " Data Source=yarlagadda\\sqlexpress;Initial Catalog = appliedproject; Integrated Security = True";
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm2.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=yarlagadda\\sqlexpress;Initial Catalog = appliedproject; Integrated Security = True";
            con.Open();
            string Email = TextBox1.Text;
            string password = TextBox2.Text;
            SqlCommand cmd = new SqlCommand("select Email,password from Table_1 where Email='" + TextBox1.Text + "'and password='" + TextBox2.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Session["wname"] = TextBox1.Text;
            if (dt.Rows.Count > 0)
            {
                
                Response.Redirect("WebForm3.aspx");
            }
            else
            {
                Label1.Visible = true;
            }
            con.Close();
        }
    }
} 
    

    