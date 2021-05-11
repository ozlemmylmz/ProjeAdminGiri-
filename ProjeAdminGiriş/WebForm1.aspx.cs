using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace ProjeAdminGiriş
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection bağlantı = new SqlConnection(@"DESKTOP-9F7BBAK\SQLEXPRESS;İnital Catalog=ProjeAdminDb ; Integrated Security=True");
            bağlantı.Open();
            SqlCommand komut = new SqlCommand("Select * from TBLADMİN where KULLANICI=@P1 AND ŞİFRE=@P2", bağlantı);
            komut.Parameters.AddWithValue("@P1", TextBox1.Text);
            komut.Parameters.AddWithValue("@P", TextBox2.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                Response.Redirect("veriler.aspx");
            }
            else
            {
                Response.Write("Hatalı Veri Girişi.");
            }
            bağlantı.Close();
        }
    }
}