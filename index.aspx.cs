using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace App_Login
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuariologueado"] != null)
            {
                string usuariologueado = Session["usuariologueado"].ToString();
                lblBienvenida.Text = "Bienvenido/a " + usuariologueado;
            }
            else
            {
                Response.Redirect("App_login.aspx");
            }
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            Session.Remove("usuariologueado");
            Response.Redirect("App_login.aspx");
        }
    }
}