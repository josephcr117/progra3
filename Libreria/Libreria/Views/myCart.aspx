<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="myCart.aspx.cs" Inherits="Libreria.Views.myCart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>

    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <nav class="navbar navbar-expand-lg bg-primary" data-bs-theme="dark">
                <div class="container-fluid">
                    <a runat="server" id="UserNameIfLogged" class="navbar-brand" href="#">TripAdvisor</a>
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
                                <a class="nav-link dropdown-toggle" data-bs-toggle="dropdown" href="#" role="button" aria-haspopup="true" aria-expanded="false">Dropdown</a>
                                <div class="dropdown-menu">
                                    <a class="dropdown-item" href="#">Action</a>
                                    <a class="dropdown-item" href="#">Another action</a>
                                    <a class="dropdown-item" href="#">Something else here</a>
                                    <div class="dropdown-divider"></div>
                                    <a class="dropdown-item" href="#">Separated link</a>
                                </div>
                            </li>
                        </ul>
                    </div>
                </div>
            </nav>
            <!---Trip Box with payment info--->
            <div class="container">
                <div class="row" style="margin-top: 20px">
                    <asp:Repeater ID="repetidorLibros" runat="server">
                        <HeaderTemplate></HeaderTemplate>
                        <ItemTemplate>
                            <div class="col-md-8">
                                <div class="card-body">
                                    <h5 class="card-title"><%# Eval("nombreLibro")%></h5>
                                    <p class="card-text">Author: <%# Eval("autorLibro")%></p>
                                    <p class="card-text">Fecha de Publicacion: $<%# Eval("fechaPublicacion")%></p>
                                    <p class="card-text">ISBN: <%# Eval("ISBN")%></p>
                                    <a href="myBooks.aspx?id=<%# Eval("ISBN")%>" class="btn btn-primary">Buy this Book for $<%# Eval("precio")%></a>
                                </div>
                            </div>
                            <hr>
                            
                            <button id="btnPayment" type="button" data-bs-toggle="offcanvas" data-bs-target="#paymentOffcanvas" class="btn btn-primary">Payment</button>
                            </div>
                            </div>
                        </ItemTemplate>
                        <FooterTemplate></FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </form>
    <!-- Offcanvas To Pay with Credit/Debit Card-->
    <div class="offcanvas offcanvas-end" tabindex="-1" id="paymentOffcanvas" aria-labelledby="paymentOffcanvasLabel">
        <div class="offcanvas-header">
            <h5 id="paymentOffcanvasLabel">Payment Information</h5>
            <button type="button" class="btn-close text-reset" data-bs-dismiss="offcanvas" aria-label="Close"></button>
        </div>
        <div class="offcanvas-body">
            <div class="container">
                <asp:Repeater ID="repetidorPagos" runat="server">
                    <HeaderTemplate></HeaderTemplate>
                    <ItemTemplate>
                        <div class="card shadow-sm" style="max-width: 25rem; margin-left: 12px;">
                            <h5 class="card-title"><%# Eval("Name")%></h5>
                            <hr>
                            <strong>Total:</strong> $<label><%# Eval("Total")%></label>
                        </div>
                    </ItemTemplate>
                    <FooterTemplate></FooterTemplate>
                </asp:Repeater>
            </div>
            <hr>
            <div id="totalAmount">
                <strong>Total Amount: </strong>$<span id="total"></span>
            </div>
            <hr>
            <div id="paymentForm">
                <form action="myPayment.aspx" method="post">
                    <div class="form-group">
                        <div class="form-floating mb-4">
                            <input type="text" class="form-control" id="name" name="name" required>
                            <label for="name">Name on Card</label>
                        </div>
                        <div class="form-floating mb-4">
                            <input type="number" class="form-control" id="card_number" name="card_number" required>
                            <label for="card_number">Card Number</label>
                        </div>
                        <div class="form-floating mb-4">
                            <input type="text" class="form-control" id="expiration_date" name="expiration_date" pattern="(0[1-9]|1[0-2])\/[0-9]{2}" placeholder="MM/YY" required>
                            <label for="expiration_date">Expiration Date (MM/YY)</label>
                            <div class="invalid-feedback">Please enter a valid expiration date in the format MM/YY</div>
                        </div>

                        <div class="form-floating mb-4">
                            <input type="number" class="form-control" id="cvv" name="cvv" required>
                            <label for="cvv">CVV</label>
                        </div>
                        <button type="submit" class="btn btn-success mt-3">Pay Now</button>
                    </div>
                </form>
            </div>
        </div>
    </div>
</body>
</html>
