<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProducts.aspx.cs" Inherits="Carsolio.AddProducts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/css/bootstrap.min.css"/>
<link href="css/Style.css" rel="stylesheet" />
<link rel='shortcut icon' href='images/logounison.png'   type='image/png'/>
    <script src="js/jquery-2.1.3.js"></script>
    <script src="js/Script.js"></script>
    <title>Sistema de Inventarios</title>
</head>
<body>
    <form id="form1" runat="server">
    <div >
         <div class="nav-bar">
             <asp:Panel ID="Nav" runat="server"></asp:Panel>
         </div>
         

         <asp:Panel ID="contenedorProd" runat="server">
              <div class="Agregar">
              <asp:Label ID="Label1" Style="padding-right: 10%;" runat="server" Text="Código: "></asp:Label>
              <asp:TextBox ID="txtCodigo" Class="form-control" runat="server" placeholder="Codigo" onkeypress="ValidaSoloNumeros" type="text"></asp:TextBox><br />
<%--              <asp:Button ID="Button2" CssClass="form-control" runat="server" Text="Generar" style="width:100px; margin-left: 290px;   margin-top: 8px;" BackColor="#0066FF" BorderColor="Black" ForeColor="White" OnClick="Button2_Click"  /> <br /> <br />--%>
             
              <asp:Label ID="Label2" Style="padding-right: 8%;" runat="server" Text="Nombre: "></asp:Label>
              <asp:TextBox ID="txtNombre" Class="form-control" runat="server" Style="padding-right:50px;" placeholder="Nombre" required></asp:TextBox><br /> <br /> <br /> 

              <asp:Label ID="Label3" Style="padding-right: 10%;" runat="server" Text="Módulo: "></asp:Label>
              <asp:DropDownList ID="txtModulo"  Class="form-control" runat="server" ></asp:DropDownList>
              <%--<asp:TextBox ID="txtModulo" Class="form-control" runat="server" placeholder="Modulo" required></asp:TextBox>--%><br /> <br /> <br />

              <asp:Label ID="Label4" Style="padding-right: 6%;" runat="server" Text="Cantidad: "></asp:Label>
              <asp:TextBox ID="txtCantidad" Class="form-control" runat="server" placeholder="Cantidad" required></asp:TextBox><br /> <br /> <br /> 

              <asp:Label ID="Label5" Style="padding-right: 10%;" runat="server" Text="Descripción: "></asp:Label> <br />
              <asp:TextBox ID="txtDesc" Style="margin-left: 150px;" Class="form-control required" runat="server" Height="140px" TextMode="MultiLine" Width="60%" placeholder="Descripcion" required></asp:TextBox><br /> <br /> <br />

              <asp:Label ID="Label6" Style="padding-right: 14%;" runat="server" Text="Fecha: "></asp:Label>
              <asp:TextBox ID="txtFecha" Class="form-control" runat="server" placeholder="Año/Mes/Dia" required></asp:TextBox><br />                
                  <br /> 



              <asp:Button ID="Button1" CssClass="form-control" runat="server" Text="Aceptar" style="width:100px; margin-left: 290px;" BackColor="#0066FF" BorderColor="Black" ForeColor="White" OnClick="Button1_Click" />
              </div>
         </asp:Panel>
    </div>
    </form>
     
</body>
</html>
