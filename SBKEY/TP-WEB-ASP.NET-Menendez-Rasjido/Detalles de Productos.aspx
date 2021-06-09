<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalles de Productos.aspx.cs" Inherits="TP_WEB_ASP.NET_Menendez_Rasjido.Detalles_de_Productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>CONOCE TU PRODUCTO</h1>
        <p class="lead">Agrega, modifica y elige tus productos favoritos.</p>
    </div>

    <div class="container-extra">

        <div class="col-md-12">
            <section class="panel">
                <div class="panel-body">
                    <div class="col-md-6">
                        <div class="pro-img-details">
                            <img class="principal-img" src="<% =detalleArt.URLimagen %>" onerror="this.src='https://i.postimg.cc/FKLCS5hD/404.png'" alt="">
                        </div>
                    </div>
                    <div class="col-md-6 det">
                        <h4 class="pro-d-title"><% =detalleArt.Nombre %></h4>
                        <p><% =detalleArt.Descripcion %></p>
                        <div class="product_meta">
                            <span class="posted_in"> <strong>Categoria: </strong> <a rel="tag" href="#"><% =detalleArt.Categoria %></a></span>
                            <span class="tagged_as"><strong>Marca:</strong> <a rel="tag" href="#"><% =detalleArt.Marca %></a></span>
                        </div>
                        <div class="m-bot15"> <strong>Precio: </strong> <span class="amount">$<% =detalleArt.precio %></span></div>
                        <p>
                        <a href="Carrito de Compra.aspx?id=<%=detalleArt.ID %>&e=t" class="adddesc">AÑADIR PRODUCTO<span class="glyphicon glyphicon-chevron-right"></span></a>
                        </p>
                    </div>
                </div>
            </section>
        </div>
    </div>

    <a href="Catalogo#<% =detalleArt.ID%>"  class="btn btn-success"><span class="glyphicon glyphicon-arrow-left"></span>&nbsp;Seguir Explorando</a>
    <a href="Carrito de Compra.aspx?id=<%=detalleArt.ID %>&e=t" class="btn btn-primary pull-right">Ir al carrito! <span class="glyphicon glyphicon-chevron-right"></span></a>
              
</asp:Content>
