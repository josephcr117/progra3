using Libreria.Controllers;
using Libreria.DatabaseHelper;
using Libreria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Libreria.Views
{
    public partial class myBooks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["isbn"] != null)
                {
                    string isbn = Request.QueryString["isbn"];
                    BindBookDetails(isbn);
                }
            }

            if (Session["userEmail"] != null)
            {
                string userEmail = Session["userEmail"].ToString();
            }
        }

        private void BindBookDetails(string isbn)
        {
            LibroController libroController = new LibroController();
            Libros book = libroController.GetLibro(isbn);

            if (book != null)
            {
                List<Libros> bookList = new List<Libros>();
                bookList.Add(book);

                repeaterMyBooks.DataSource = bookList;
                repeaterMyBooks.DataBind();
            }
        }
        protected void btnBuy_Click(object sender, EventArgs e)
        {
            try
            {
                Button btnBuy = (Button)sender;
                string isbn = btnBuy.CommandArgument;

                string userEmail = Session["userEmail"] as string;

                if (string.IsNullOrEmpty(userEmail))
                {
                    Response.Redirect("main.aspx");
                    return;
                }

                DateTime purchaseDate = DateTime.Now;

                BookController bookController = new BookController();

                bookController.SaveCompra(userEmail, isbn, purchaseDate);

                Response.Redirect("myCart.aspx");
            }
            catch (Exception ex)
            {
                string errorMessage = "An error occurred while processing the purchase. Please try again later.";
                ClientScript.RegisterStartupScript(this.GetType(), "errorAlert", $"alert('{errorMessage}');", true);
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

        protected void btnLogin_ServerClick(object sender, EventArgs e)
        {
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
    }
}