<%@ Page EnableEventValidation="true" Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito de Compra.aspx.cs" Inherits="TP_WEB_ASP.NET_Menendez_Rasjido.Carrito_de_Compra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="jumbotron">
        <h1>TU CARRITO DE COMPRAS</h1>
        <p class="lead">Agrega, modifica y elige tus productos favoritos.</p>
    </div>


    <div class="container-extra">
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
                    <td><img src="<%#Eval("articulo.UrlImagen")%>" onerror="this.src='https://i.postimg.cc/FKLCS5hD/404.png'" class="img-cart"></td>
                    <td><strong><%#Eval("articulo.Nombre")%></strong><p><%#Eval("articulo.Marca")%></p></td>
                    <td class="cart-item-list">
                        <a  href="Detalles de Productos.aspx?id=<%#Eval("articulo.ID")%>">
                            <img class="cart-item-list2" src="https://i.postimg.cc/xd0j382C/info.png" alt="..." /></a>

                        <asp:TextBox TextMode="Number" name="ValNum" ID="txtCantidad" runat="server" AutoPostBack="true" OnTextChanged="txtCantidad_TextChanged" />
                         <script>
                            $(document).ready(function () {
                             $("#ValNum").keypress(function (e) {
                                if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {$("#errmsg").html("Digits Only").show().fadeOut("slow"); return false;
                                }
                             });
                            });
                         </script>

                        
                        <asp:ImageButton CssClass="cart-item-list2" ID="ImageButton1" ImageUrl="https://icons555.com/images/icons-red/image_icon_delete_pic_512x512.png"  
                            AlternateText="No Image available" OnClick="btnEliminar3_Click" CommandArgument='<%#Eval("articulo.ID")%>' runat="server" />
                    </td>

                    <td class="cart-item-list"><%#Eval("articulo.precio")%></td>
                    <td class="cart-item-list"><%#Eval("precioSubTotal")%></td>

                </tr>
            </ItemTemplate>
        </asp:Repeater>
                                
                                
        <asp:Repeater runat="server" ID="repetidorData">
        <ItemTemplate>
                                <tr>
                                    <td colspan="5">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="4" class="text-right">PRECIO TOTAL DE PRODUCTOS</td>
                                    <td><strong><%#Eval("totalproductos")%></strong></td>
                                </tr>
                                <tr>
                                    <td colspan="4" class="text-right">ADICIONAL</td>
                                    <td><strong><%#Eval("adicional")%></strong></td>
                                </tr>
                                <tr>
                                    <td colspan="4" class="text-right"><strong>TOTAL</strong></td>
                                    <td><strong><%#Eval("total")%></strong></td>
                                </tr>
        </ItemTemplate>
        </asp:Repeater>  
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
