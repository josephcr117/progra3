<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="Libreria.Views.Checkout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Checkout - Libreria Internacional</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
</head>
<body class="dark-bg">
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg bg-dark" data-bs-theme="dark">
            <div class="container-fluid">
                <a runat="server" id="UserNameIfLogged" class="navbar-brand" href="main.aspx">Libreria Internacional</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarColor01" aria-controls="navbarColor01" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarColor01">
                    <ul class="navbar-nav me-auto">
                        <li class="nav-item">
                            <a class="nav-link active" href="main.aspx">Home
                <span class="visually-hidden">(current)</span>
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" data-bs-toggle="offcanvas" data-bs-target="#offcanvasRight" href="#">Login</a>
                        </li>
                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" data-bs-toggle="dropdown" href="#" role="button" aria-haspopup="true" aria-expanded="false">Services</a>
                            <div class="dropdown-menu">
                                <a class="dropdown-item" href="myCart.aspx">My Cart</a>
                                <a class="dropdown-item" href="myBooks.aspx">My Book Wish List</a>
                                <div class="dropdown-divider"></div>
                                <a class="dropdown-item" href="#">Separated link</a>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
        <div class="container mt-5">
            <h2 class="text-white">Checkout</h2>
            <asp:GridView ID="gvCompra" runat="server" CssClass="table table-dark" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="nombreLibro" HeaderText="Book" />
                    <asp:BoundField DataField="autorLibro" HeaderText="Author" />
                    <asp:BoundField DataField="precio" HeaderText="Price" DataFormatString="${0:0.00}" />
                </Columns>
            </asp:GridView>
            <div class="text-end">
                <h4 class="text-white">Total:
                    <asp:Label ID="lblTotal" runat="server" CssClass="text-white" /></h4>
            </div>
        </div>
    </form>
</body>
</html>
