<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="myCart.aspx.cs" Inherits="Libreria.Views.myCart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>My Cart - Libreria Internacional</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</head>
<body class="bg-dark">
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
            <h2 class="text-center text-light mb-4">My Cart</h2>
            <div class="row">
                <asp:Repeater ID="gvCompra" runat="server">
                    <HeaderTemplate>
                        <div class="row">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="col-md-12 mb-3">
                            <div class="card">
                                <div class="card-body">
                                    <h5 class="card-title"><%# Eval("nombreLibro") %></h5>
                                    <p class="card-text">ISBN: <%# Eval("ISBN") %></p>
                                    <p class="card-text">Date: <%# Eval("fechaCompra", "{0:MM/dd/yyyy}") %></p>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                    <FooterTemplate>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
            <div class="text-center">
                <a href="checkout.aspx" class="btn btn-success">Proceed to Checkout</a>
            </div>
        </div>
    </form>
</body>
</html>
