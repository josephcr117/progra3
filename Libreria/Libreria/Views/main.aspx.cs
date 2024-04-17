using Libreria.Controllers;
using Libreria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
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
                email = signInEmail.Value,
                password = signInPw.Value
            };

            LoginController loginController = new LoginController();

            user = loginController.FirebaseAuth(user);

            if (user != null)
            {
                if (user.registered)
                {
                    Session["session"] = user;

                    UserNameIfLogged.InnerText = "Welcome " + user.displayName;

                    //Mostranto el boton logout
                    divLogout.Attributes.Remove("hidden");
                    //Ocultando el login
                    divLogin.Attributes.Add("hidden", "hidden");

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Login approved')", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Login denied')", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('User not found')", true);
            }
        }

        protected void btnLogout_ServerClick(object sender, EventArgs e)
        {
            //Mostrando el login
            divLogin.Attributes.Remove("hidden");
            //Ocultando el boton logout
            divLogout.Attributes.Add("hidden", "hidden");

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Session has been closed')", true);
            Session.Clear();
        }

        protected void btnSignUp_ServerClick(object sender, EventArgs e)
        {
            FirebaseUser user = new FirebaseUser()
            {
                displayName = signUpName.Value,
                email = signUpEmail.Value,
                password = signUpPassword.Value
            };

            LoginController loginController = new LoginController();

            if (loginController.FirebaseSignUp(user))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sign Up completed')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sign Up failed')", true);
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