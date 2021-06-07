<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TP_WEB_ASP.NET_Menendez_Rasjido._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>MI PAGINA WEB</h1>
        <p class="lead">Bienvenidos a la pagina oficial de SBKEY.WEB</p>
    </div>

    <div class="events_area">
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-lg-5">
                <div class="main_title">
                    <h1 class="promtext">PROMOCIONES</h1>
                </div>
            </div>
        </div>
        <div class="row">

            <% foreach (Dominio.Articulo item in destacados)
                {
             %>

            <div class="col-lg-6 col-md-6">
                <div class="single_event position-relative">
                    <div class="event_thumb">
                        <img class="destacadosImg" src="<% =item.URLimagen %>" onerror="this.src='https://i.postimg.cc/FKLCS5hD/404.png'" alt="" />
                    </div>
                    <div class="event_details">
                        <div class="d-flex mb-4">
                            <div class="date"><span><%=item.Nombre%></span></div>
                            <div class="time-location">
                                <h2>$<%=item.precio %></h2>
                            </div>
                        </div>
                        <a href="Detalles de Productos.aspx?id=<% =item.ID %>" class="btn btn-primary rounded-0 mt-3">Ver producto</a>
                    </div>
                </div>
            </div>

            <% 
                }
             %>

            

            <div class="col-lg-12">
                <div class="text-center pt-lg-5 pt-3">
                    <a href="Catalogo" class="event-link"> VER TODOS LOS PRODUCTOS <img src="img/next.png" alt="" /> </a>
                </div>
            </div>
        </div>
    </div>
</div>

</asp:Content>
