<%@ Page EnableEventValidation="true" Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito de Compra.aspx.cs" Inherits="TP_WEB_ASP.NET_Menendez_Rasjido.Carrito_de_Compra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="jumbotron">
        <h1>TU CARRITO DE COMPRAS</h1>
        <p class="lead">Agrega, modifica y elige tus productos favoritos.</p>
    </div>


    <div class="container bootstrap snippets bootdey">
        <div class="col-md-9 col-sm-8 content">
            <div class="row">
                <div class="col-md-12">
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="carritoPanel">
                        <div class="panel-heading">
                            <h3>
                            <img class="img-circle img-thumbnail" src="https://bootdey.com/img/Content/user_3.jpg">
                            NOMBRE DE USUARIO
                        </h3>
                    </div>
                    <div class="panel-body"> 
                        <div class="table-responsive">
                            <table class="table">
                            <thead>
                            <tr>
                                <th>Producto</th>
                                <th>Descripcion</th>
                                <th>Cantidad</th>
                                <th>Precio</th>
                                <th>Total</th>
                            </tr>
                            </thead>
                            <tbody>

                                

                             
            <asp:Repeater runat="server" ID="repetidorCompra">
            <ItemTemplate>
                <tr>    
                    <td><img src="<%#Eval("UrlImagen")%>" onerror="this.src='https://img.icons8.com/pastel-glyph/452/file-not-found--v2.png'" class="img-cart"></td>
                    <td><strong><%#Eval("Nombre")%></strong><p><%#Eval("Marca")%></p></td>
                    <td>
                         <input class="form-control" type="text" value="1">
                         <a href="Detalles de Productos.aspx?id=<%#Eval("ID")%>" class="cart-item-list"><img class="cart-item-list" src="https://i.postimg.cc/xd0j382C/info.png" alt="..." /> </a>
                         <a href="carrito de compras" class="cart-item-list"><img class="cart-item-list" src="https://icons555.com/images/icons-red/image_icon_delete_pic_512x512.png" alt="..." /> </a>
                    </td>
                    <td><%#Eval("Precio")%></td>

                </tr>
            </ItemTemplate>
        </asp:Repeater>




                                <tr>
                                    <td colspan="6">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="4" class="text-right">PRECIO TOTAL DE PRODUCTOS</td>
                                    <td>$86.00</td>
                                </tr>
                                <tr>
                                    <td colspan="4" class="text-right">ADICIONAL</td>
                                    <td>$2.00</td>
                                </tr>
                                <tr>
                                    <td colspan="4" class="text-right"><strong>TOTAL</strong></td>
                                    <td>$88.00</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
                </div>
                <a href="Catalogo#<%#Eval("ID")%>"  class="btn btn-success"><span class="glyphicon glyphicon-arrow-left"></span>&nbsp;Seguir Explorando</a>
                <a href="#" class="btn btn-primary pull-right">Comprar!<span class="glyphicon glyphicon-chevron-right"></span></a>
            </div>
        </div>
    </div>
</div>
</asp:Content>
