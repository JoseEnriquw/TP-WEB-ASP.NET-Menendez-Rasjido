<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Catalogo.aspx.cs" Inherits="TP_WEB_ASP.NET_Menendez_Rasjido.Catalogo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="jumbotron">
        <h1>NUESTROS PRODUCTOS</h1>
        <p class="lead">Hechale un vistazo a nuestros productos!</p>
    </div>

    <aside>
    <div class="row-panel-find">
        <div class="col-sm-3-list">
            
            <!--left col-->

           <img class="img-find" src="https://i.postimg.cc/V6mxf8V0/LOGOSS.png" alt="..." />

           <h3 class="list-h3">FILTROS</h3>

            <ul class="list-group">
                <asp:Button CssClass="Btton" ID="Button0" runat="server" Text="Por defecto" Onclick="filterDefault"/>
                <asp:Button CssClass="Btton" ID="Button1" runat="server" Text="De menor a mayor precio" Onclick="filterMinPrecio"/>
                <asp:Button CssClass="Btton" ID="Button2" runat="server" Text="De mayor a menor precio" Onclick="filterMaxPrecio"/>
                <asp:Button CssClass="Btton" ID="Button3" runat="server" Text="Lo mas reciente primero" Onclick="filterRecientes"/>
                <asp:Button CssClass="Btton" ID="Button4" runat="server" Text="Lo mas antiguo primero" Onclick="filterAntiguos"/>
            </ul>

            <h3 class="list-h3">PRECIOS</h3>
            <ul class="list-group">
                <asp:Label CssClass="lblfilter" Text="Desde:" runat="server" /> 
                <asp:TextBox CssClass="filter" ID="TextBox1" runat="server" Text="" OnTextChanged="filterprecio"></asp:TextBox>
                <asp:Label CssClass="lblfilter" Text="Hasta:" runat="server" />
                <asp:TextBox CssClass="filter" ID="TextBox2" runat="server" Text="" OnTextChanged="filterprecio"></asp:TextBox>
            </ul>
                <h3 class="list-h3">CATEGORIAS</h3>
            <ul class="list-group">
                <asp:DropDownList CssClass="dropitem" ID="DropDownList2" runat="server" OnSelectedIndexChanged="filterCat" AutoPostBack="true"></asp:DropDownList>
            </ul>
                <h3 class="list-h3">MARCAS</h3>
            <ul class="list-group">
                <asp:DropDownList CssClass="dropitem" ID="DropDownList3" runat="server" OnSelectedIndexChanged="filterMar" AutoPostBack="true"
></asp:DropDownList>
            </ul>
        </div>
    </div>
    </aside>


    <div class="container-extra">
    <div class="row clearfix">
        
        <%  
            foreach (Dominio.Articulo item in listaCatalogo)
            {
            %>
    <div class="col-lg-3 col-md-4 col-sm-12">
        <div class="card">
            <section id="<% =item.ID %>">
            <img src="<% =item.URLimagen %>" onerror="this.src='https://i.postimg.cc/FKLCS5hD/404.png'" class="card-img-top" alt="..." />
             </section>
            <div class="card-body">
                
                <h3 class="card-text-title"><% =item.Nombre %>  </h3>
                     
                <h5 class="card-text"><% =item.Descripcion %></h5>
                <h6 class="card-text">$<% =item.precio %></h6>
                <a href="Detalles de Productos.aspx?id=<% =item.ID %>"  class="cart-btn-primary"><img class="cart-img-secundary" src="https://img.icons8.com/pastel-glyph/2x/info.png" alt="..." /> </a>
                <a href="Carrito de Compra.aspx?id=<% = item.ID %>&e=t" class="cart-btn-primary"><img class="cart-img-primary" src="https://img.icons8.com/material-sharp/452/add-shopping-cart.png" alt="..." /> </a> 
                    
            </div>
        </div>
    </div>
           
        <%} %>
     
</div>
</div>
    
</asp:Content>

