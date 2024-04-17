using Libreria.Controllers;
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
    public partial class myBooks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["session"] != null)
            {
                FirebaseUser user = (FirebaseUser)Session["session"];

                UserNameIfLogged.InnerText = "Welcome " + user.displayName;

                string isbn = Request.QueryString["isbn"];

                LibroController libroController = new LibroController();

                List<Libros> tripList = libroController.GetLibros(isbn);

                repetidorLibros.DataSource = tripList;
                repetidorLibros.DataBind();
            }
            else
            {
                Response.Redirect("main.aspx");
            }
        }

        protected void btnSaveFav_ServerClick(object sender, EventArgs e)
        {
            try
            {
                BookController bookController = new BookController();

                FirebaseUser user = (FirebaseUser)Session["session"];

                Libros libros = new Libros
                {
                    ISBN = Request.QueryString["isbn"],
                    email = user.email,
                    nombreLibro = txtNombreLibro.Value,
                    autorLibro = txtAutorLibro.Value,
                    precio = Convert.ToDecimal(bookPrice.InnerText) * Convert.ToInt16(selectBooks.Value)
                };

                bookController.SaveBook(libros);

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Your trip was saved successfully')", true);
            }
            catch (Exception ex)
            {
                alertError.InnerText = ex.Message;
                alertError.Attributes.Remove("hidden");
            }
        }

        protected void btnSaveBooked_ServerClick(object sender, EventArgs e)
        {
            try
            {
                BookController bookController = new BookController();

                FirebaseUser user = (FirebaseUser)Session["session"];

                Libros libros = new Libros
                {
                    ISBN = Request.QueryString["isbn"],
                    email = user.email,
                    nombreLibro = txtNombreLibro.Value,
                    autorLibro = txtAutorLibro.Value,
                    precio = Convert.ToDecimal(bookPrice.InnerText) * Convert.ToInt16(selectBooks.Value)
                };

                bookController.GetCart(libros);

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Your trip was saved successfully')", true);
            }
            catch (Exception ex)
            {
                alertError.InnerText = ex.Message;
                alertError.Attributes.Remove("hidden");
            }
        }
    }
}