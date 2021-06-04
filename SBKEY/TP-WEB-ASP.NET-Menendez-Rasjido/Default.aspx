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


            <div class="col-lg-6 col-md-6">
                <div class="single_event position-relative">
                    <div class="event_thumb">
                        <img src="https://via.placeholder.com/500x500/20B2AA/000000" alt="" />
                    </div>
                    <div class="event_details">
                        <div class="d-flex mb-4">
                            <div class="date"><span>PRODUCTO 1</span></div>
                            <div class="time-location">
                                <h2>$99.99ARS</h2>
                            </div>
                        </div>
                        <a href="Detalles de Productos" class="btn btn-primary rounded-0 mt-3">Ver producto</a>
                    </div>
                </div>
            </div>


            <div class="col-lg-6 col-md-6">
                <div class="single_event position-relative">
                    <div class="event_thumb">
                        <img src="https://via.placeholder.com/500x500/20B2AA/000000" alt="" />
                    </div>
                    <div class="event_details">
                        <div class="d-flex mb-4">
                            <div class="date"><span>PRODUCTO 2</span></div>
                            <div class="time-location">
                                <h2>$99.99ARS</h2>
                            </div>
                        </div>
                        <a href="Detalles de Productos" class="btn btn-primary rounded-0 mt-3">Ver producto</a>
                    </div>
                </div>
            </div>
            

            <div class="col-lg-12">
                <div class="text-center pt-lg-5 pt-3">
                    <a href="Catalogo" class="event-link"> VER TODOS LOS PRODUCTOS <img src="img/next.png" alt="" /> </a>
                </div>
            </div>
        </div>
    </div>
</div>

</asp:Content>
