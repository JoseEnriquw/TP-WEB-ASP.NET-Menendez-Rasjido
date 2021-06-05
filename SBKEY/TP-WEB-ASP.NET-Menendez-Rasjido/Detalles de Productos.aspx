<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalles de Productos.aspx.cs" Inherits="TP_WEB_ASP.NET_Menendez_Rasjido.Detalles_de_Productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>CONOCE TU PRODUCTO</h1>
        <p class="lead">Agrega, modifica y elige tus productos favoritos.</p>
    </div>

    <div class="container bootdey">
        <div class="col-md-12">
            <section class="panel">
                <div class="panel-body">
                    <div class="col-md-6">
                        <div class="pro-img-details">
                            <img class="principal-img" src="https://via.placeholder.com/550x380/FFB6C1/000000" alt="">
                        </div>
                    </div>
                    <div class="col-md-6">
                        <h4 class="pro-d-title">Nombre del producto</h4>
                        <p>Descripcion bla bla bla. Compralo plss</p>
                        <div class="product_meta">
                            <span class="posted_in"> <strong>Categoria:</strong> <a rel="tag" href="#">Jackets</a></span>
                            <span class="tagged_as"><strong>Tags:</strong> <a rel="tag" href="#">mens</a></span>
                        </div>
                        <div class="m-bot15"> <strong>Precio: </strong> <span class="amount">$99.99</span></div>
                            <div class="form-group">
                                <label>Cantidad</label>
                                <input type="quantiy" placeholder="1" class="form-control quantity">
                            </div>
                        <p>
                        <button class="btn btn-round btn-danger" type="button"><i class="fa fa-shopping-cart"></i>Añadir al carro</button>
                        </p>
                    </div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>
