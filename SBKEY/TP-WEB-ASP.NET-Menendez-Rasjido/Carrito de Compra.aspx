<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito de Compra.aspx.cs" Inherits="TP_WEB_ASP.NET_Menendez_Rasjido.Carrito_de_Compra" %>
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

                                




                                <tr>
                                    <td><img src="https://via.placeholder.com/400x200/FFB6C1/000000" class="img-cart"></td>
                                    <td><strong>Product 1</strong><p>Size : 26</p></td>
                                    <td>
 
                                        <input class="form-control" type="text" value="1">
                                        <a href="Detalles de Productos" class="cart-item-list"><img class="cart-item-list" src="https://i.postimg.cc/xd0j382C/info.png" alt="..." /> </a>
                                        <a href="Detalles de Productos" class="cart-item-list"><img class="cart-item-list" src="https://icons555.com/images/icons-red/image_icon_delete_pic_512x512.png" alt="..." /> </a>
  
                                    </td>
                                    <td>$54.00</td>
                                    <td>$54.00</td>
                                </tr>





                                <tr>
                                    <td><img src="https://via.placeholder.com/400x200/87CEFA/000000" class="img-cart"></td>
                                    <td><strong>Product 2</strong><p>Size : M</p></td>
                                    <td>

                                        <input class="form-control" type="text" value="1">
                                        <a href="Detalles de Productos" class="cart-item-list"><img class="cart-item-list" src="https://i.postimg.cc/xd0j382C/info.png" alt="..." /> </a>
                                        <a href="Detalles de Productos" class="cart-item-list"><img class="cart-item-list" src="https://icons555.com/images/icons-red/image_icon_delete_pic_512x512.png" alt="..." /> </a>

                                    </td>
                                    <td>$16.00</td>
                                    <td>$32.00</td>
                                </tr>




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
                <a href="#" class="btn btn-success"><span class="glyphicon glyphicon-arrow-left"></span>&nbsp;Continue Shopping</a>
                <a href="#" class="btn btn-primary pull-right">Next<span class="glyphicon glyphicon-chevron-right"></span></a>
            </div>
        </div>
    </div>
</div>
</asp:Content>
