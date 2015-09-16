<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddModulo.aspx.cs" Inherits="Carsolio.AddModulo" %>

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
    <div>
    <div class="nav-bar">
             <asp:Panel ID="Nav" runat="server"></asp:Panel>
         </div>
         

         <asp:Panel ID="contenedorMod" runat="server">
              <div class="AgregarMod">
              <asp:Label ID="Label1" Style="padding-right: 10%;" runat="server" Text="Nombre del Módulo: "></asp:Label><br /> 
              <asp:TextBox ID="txtModule" Class="form-control" runat="server" placeholder="Nombre Módulo" required></asp:TextBox> <br /> <br /> <br />

              <asp:Label ID="Label2" Style="padding-right: 8%;" runat="server" Text="Verificar Nombre: "></asp:Label><br /> 
              <asp:TextBox ID="txtModuleVer" Class="form-control" runat="server" Style="padding-right:50px;" placeholder="Nombre Módulo" required></asp:TextBox><br /> <br /> 

              <asp:Button ID="Button1" CssClass="form-control" runat="server" Text="Aceptar" style="width:100px; margin-left: 30%; " BackColor="#0066FF" BorderColor="Black" ForeColor="White" OnClick="Button1_Click" />
              </div>
         </asp:Panel>
    </div>
    </form>
</body>
</html>
