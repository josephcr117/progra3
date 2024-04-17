using Libreria.Controllers;
using Libreria.DatabaseHelper;
using Libreria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Libreria.Views
{
    public partial class main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LibroController libroController = new LibroController();

            List<Libros> listaLibros = libroController.GetLibros(String.Empty);

            repetidorLibros.DataSource = listaLibros;
            repetidorLibros.DataBind();
        }

        protected void btnLogin_ServerClick(object sender, EventArgs e)
        {
            FirebaseUser user = new FirebaseUser()
            {
                email = txtEmail.Value,
                password = txtPwd.Value
            };

            LoginController loginController = new LoginController();

            user = loginController.FirebaseAuth(user);

            try
            {
                string email = txtEmail.Value;
                string password = txtPwd.Value;

                if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                {
                    string errorScript = "alert('Please enter both email and password.');";
                    ClientScript.RegisterStartupScript(this.GetType(), "errorAlert", errorScript, true);
                    return;
                }

                Database db = new Database();
                bool isValidUser = db.ValidateUser(email, password);

                if (isValidUser)
                {
                    Session["userEmail"] = email;

                    string successScript = "alert('Sign in successful.'); window.location.href = 'main.aspx';";
                    ClientScript.RegisterStartupScript(this.GetType(), "successAlert", successScript, true);
                }
                else
                {
                    string errorScript = "alert('Invalid email or password. Please try again.');";
                    ClientScript.RegisterStartupScript(this.GetType(), "errorAlert", errorScript, true);
                }
            }
            catch (Exception ex)
            {
                string errorMessage = "An error occurred while attempting to login. Please try again later.";
                throw ex;
            }
        }

        protected void btnLogout_ServerClick(object sender, EventArgs e)
        {
            try
            {
                Session.Clear();
                Response.Redirect("main.aspx");
            }
            catch (Exception ex)
            {
                string errorMessage = "An error occurred while attempting to logout. Please try again later.";
                throw ex;
            }
        }

        protected void btnSignUp_ServerClick(object sender, EventArgs e)
        {
            string nombreCompleto = txtDisplayName.Value;
            string email = txtSignUpEmail.Value;
            string password = txtSignUpPwd.Value;
            string pais = txtCountry.Value;
            string provincia = txtProvincia.Value;
            string direccion = txtAddress.Value;
            string codigoPostal = txtZipCode.Value;

            if (string.IsNullOrWhiteSpace(nombreCompleto) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(pais) ||
                string.IsNullOrWhiteSpace(provincia) ||
                string.IsNullOrWhiteSpace(direccion) ||
                string.IsNullOrWhiteSpace(codigoPostal))
            {
                string errorScript = "alert('Please fill out all required fields.');";
                ClientScript.RegisterStartupScript(this.GetType(), "errorAlert", errorScript, true);
                return;
            }
            else
            {
                Database database = new Database();
                database.InsertUserData(nombreCompleto, email, pais, provincia, direccion, codigoPostal, password);

                Response.Redirect("main.aspx");
            }
        }


        protected void btnSearch_ServerClick(object sender, EventArgs e)
        {
            string criteria = txtSearch.Value;

            LibroController libroController = new LibroController();

            List<Libros> listaLibros = libroController.GetLibros(criteria);

            repetidorLibros.DataSource = listaLibros;
            repetidorLibros.DataBind();
        }
    }
}