using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace App_Login
{
    public partial class App_Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        string patron = "AppLogin";

        protected void btnIngresar_Click (object sender,EventArgs e)
        {
            string conectar = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            SqlConnection sqlconectar = new SqlConnection(conectar);
            SqlCommand cmd = new SqlCommand("SP_ValidarUsuario", sqlconectar) 
            { 
                CommandType=CommandType.StoredProcedure
            };
            cmd.Connection.Open();
            cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = tbUsuario.Text;
            cmd.Parameters.Add("@Contrasenia", SqlDbType.VarChar, 50).Value = tbPassword.Text;
            cmd.Parameters.Add("@Patron", SqlDbType.VarChar, 50).Value = patron;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                //Agregamos una sesion de usuario
                Session["usuariologueado"] = tbUsuario.Text;
                Response.Redirect("index.aspx");
            }
            else
            {
                lblError.Text = "Error de Usuario o Contraseña";
            }
            cmd.Connection.Close();
        }
    }
}