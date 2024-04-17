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
    public partial class myCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["session"] != null)
            {
                FirebaseUser user = (FirebaseUser)Session["session"];
                Session["userEmail"] = user.email;
                Session["userName"] = user.displayName;

                LoadBooked();
                bookPayment();

            }
            else
            {
                Response.Redirect("main.aspx");
            }
        }

        public void LoadBooked()
        {
            BookController bookController = new BookController();

            FirebaseUser user = (FirebaseUser)Session["session"];

            repetidorLibros.DataSource = bookController.GetCart(user.email);
            repetidorLibros.DataBind();
        }

        public void bookPayment()
        {
            BookController bookController = new BookController();

            FirebaseUser user = (FirebaseUser)Session["session"];

            repetidorPagos.DataSource = bookController.GetCart(user.email);
            repetidorPagos.DataBind();

        }

        protected void btnDelete_ServerClick(object sender, EventArgs e)
        {
            var button = (HtmlButton)sender;
            string dataId = button.Attributes["dataId"];

            if (dataId != null)
            {
                BookController bookController = new BookController(); 
                int id = int.Parse(dataId);
                bookController.DeleteCart(id);
                bookPayment();
                LoadBooked();
            }
        }
    }
}