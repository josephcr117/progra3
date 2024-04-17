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
    public partial class Checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userEmail"] != null)
                {
                    string userEmail = Session["userEmail"].ToString();

                    List<Compra> compraList = new BookController().GetCompra(userEmail);

                    gvCompra.DataSource = compraList;
                    gvCompra.DataBind();

                    decimal totalPrice = compraList.Sum(item => item.precio);
                    lblTotal.Text = totalPrice.ToString("0.00");
                }
                else
                {
                    Response.Redirect("main.aspx");
                }
            }

        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
        }
    }
}