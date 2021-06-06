<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Catalogo.aspx.cs" Inherits="TP_WEB_ASP.NET_Menendez_Rasjido.Catalogo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="jumbotron">
        <h1>NUESTROS PRODUCTOS</h1>
        <p class="lead">Hechale un vistazo a nuestros productos!</p>
    </div>

    <div class="container">
    <div class="row clearfix">
        
        <%  
            foreach (Dominio.Articulo item in listaCatalogo)
            {
            %>
        
    <div class="col-lg-3 col-md-4 col-sm-12">
        <div class="card">
            <section id="<% =item.ID %>">
            <img src="<% =item.URLimagen %>" onerror="this.src='https://img.icons8.com/pastel-glyph/452/file-not-found--v2.png'" class="card-img-top" alt="..." />
             </section>
            <div class="card-body">
                
                <h3 class="card-text-title"><% =item.Nombre %>  </h3>
                     
                <h5 class="card-text"><% =item.Descripcion %></h5>
                <h6 class="card-text">$<% =item.precio %></h6>
                <a href="Detalles de Productos.aspx?id=<% =item.ID %>"  class="cart-btn-primary"><img class="cart-img-secundary" src="https://img.icons8.com/pastel-glyph/2x/info.png" alt="..." /> </a>
                <a href="Carrito de Compra" class="cart-btn-primary"><img class="cart-img-primary" src="https://img.icons8.com/material-sharp/452/add-shopping-cart.png" alt="..." /> </a> 
           
            </div>
        </div>
    </div>
           
        <%} %>
     
</div>
</div>
    
</asp:Content>
