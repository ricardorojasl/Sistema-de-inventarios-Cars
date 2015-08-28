<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="consulta_por_nombre_marca.aspx.cs" Inherits="Carsolio.consulta_por_nombre_marca" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/Style.css" rel="stylesheet" />
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/css/bootstrap.min.css"/>
     <link rel='shortcut icon' href='images/logounison.png'   type='image/png'/>
    <title>Sistema de Inventarios</title>
</head>
<body>
    <asp:Panel ID="Nav" runat="server"></asp:Panel>
    <form id="form1" runat="server">
       <div>
       <asp:Panel ID="PanelCNM" runat="server">

        
            <div class="CNMNombre">

                <asp:Label ID="label_cnmnombre" runat="server" Text="NOMBRE:"></asp:Label>
                <asp:TextBox ID="txtcnnombre" CssClass="form-control" runat="server"></asp:TextBox>
              
            </div>
            <div class="CNMarca">

                <asp:Label ID="label_cnmmarca" runat="server" Text="MARCA:"></asp:Label>
                <asp:TextBox ID="txtcnmmarca" CssClass="form-control" runat="server"></asp:TextBox>
              
            </div>
            <div class="CNMnombre">
                <asp:Label ID="label_cnmnombreproducto" runat="server" Text="NOMBRE:"></asp:Label>
                <asp:Label ID="label_cnmproducto" runat="server" Text="Nombre del Producto"></asp:Label>
            </div>
            <div class="CNModulo">
                <asp:Label ID="label_cnmmodulo" runat="server" Text="MÓDULO:"></asp:Label>
                <asp:Label ID="label_modulocnm" runat="server" Text="Nombre del Módulo"></asp:Label>
            </div>
            <div class="CNMCantidad">
                <asp:Label ID="label_cnmcantidad" runat="server" Text="CANTIDAD:"></asp:Label>
                <asp:Label ID="label_cantidadcnm" runat="server" Text="XXXXXXX"></asp:Label>
            </div>
               
        </asp:Panel>
   </div>
    </form>
</body>
</html>
