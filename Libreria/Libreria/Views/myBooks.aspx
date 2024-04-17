<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="myBooks.aspx.cs" Inherits="Libreria.Views.myBooks" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>

    <title>My Books</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%--Menu--%>
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
            <%--Repetidor--%>
            <div class="row" style="margin-top: 20px; display: flex; justify-content: center; align-items: center;">
                <asp:Repeater ID="repetidorLibros" runat="server">
                    <HeaderTemplate></HeaderTemplate>
                    <ItemTemplate>
                        <%--Detalle del trip--%>
                        <div class="card mb-3" style="width: 18rem; margin-left: 12px; height: auto">
                            <h3 class="card-header"><%# Eval("nombreLibro")%></h3>
                            <img src="<%# Eval("rutaFoto")%>" class="d-block w-100" alt="..." />
                            <div class="card-body">
                            </div>
                    </ItemTemplate>
                    <FooterTemplate></FooterTemplate>
                </asp:Repeater>
                <%--Detalle de la reservacion--%>
                <div class="card" style="width: 30rem; margin-left: 12px; height: 35rem">
                    <div class="card-body">
                        <div class="form-group">
                            <div class="row">
                                <div class="col">
                                    <label for="txtNombreLibro" class="form-label mt-4">Nombre de Libro</label>
                                </div>
                                <div class="col">
                                    <input runat="server" type="text" class="form-control" id="txtNombreLibro" placeholder="Harry Potter" autocomplete="off" />
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <div class="col">
                                    <label for="checkout" class="form-label mt-4">Autor del Libro</label>
                                </div>
                                <div class="col">
                                    <input runat="server" type="text" class="form-control" id="txtAutorLibro" placeholder="J.K Rowling" autocomplete="off" />
                                </div>
                            </div>
                        </div>
                        <hr />
                        <hr />
                        <div class="form-group">
                            <div class="row">
                                <label for="checkout" class="form-label mt-4"><label runat="server" id="bookPrice"></label></label>
                            </div>
                            <div class="row">
                                <button runat="server" id="btnSaveBooked" class="btn btn-primary" onserverclick="btnSaveBooked_ServerClick">Buy Book</button>
                                <button runat="server" id="btnSaveFav" class="btn btn-primary" onserverclick="btnSaveFav_ServerClick">Save Favorite Book</button>

                            </div>
                            <div runat="server" id="alertError" class="alert alert-danger" hidden="hidden" role="alert">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
