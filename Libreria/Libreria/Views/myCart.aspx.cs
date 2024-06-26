﻿using Libreria.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Libreria.Models;

namespace Libreria.Views
{
    public partial class myCart : System.Web.UI.Page
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
                }
                else
                {
                    Response.Redirect("main.aspx");
                }
            }
        }
    }
}