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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }
        public String constring = " Data Source=yarlagadda\\sqlexpress;Initial Catalog = appliedproject; Integrated Security = True";

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(constring);
            try
            {
                connection.Open();
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    String ins_emp = "insert into Table_1(FirstName,LastName,Email,password,AgeYear,AgeMonth,AgeDay,gender,favoritecuisine) values(@FirstName,@LastName,@EmailAddress,@Password,@AgeYear,@AgeMonth,@AgeDay,@Gender,@FavoriteCuisine)";
                    SqlCommand cmd = new SqlCommand(ins_emp, connection);

                    cmd.Parameters.AddWithValue("@FirstName", TextBox1.Text);
                    cmd.Parameters.AddWithValue("@LastName", TextBox2.Text);
                    cmd.Parameters.AddWithValue("@EmailAddress", TextBox3.Text);
                    cmd.Parameters.AddWithValue("@Password", TextBox4.Text);

                    cmd.Parameters.AddWithValue("@AgeYear", DropDownList1.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@AgeMonth", DropDownList2.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@AgeDay", DropDownList3.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@Gender", RadioButtonList1.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@FavoriteCuisine", DropDownList4.SelectedItem.Value);

                    cmd.ExecuteNonQuery();
                    Response.Write("registration successful");

                }
                else
                {
                    Label2.Visible = true;
                  
                    Button1.Visible = true;
                    Button1.Text = "Details Was not Submitted";

                }

            }
            catch (Exception ex)
            {
              //  Response.Write("Cannot connect to database: " + ex.Message);
                Label2.Visible = true;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
    }
}