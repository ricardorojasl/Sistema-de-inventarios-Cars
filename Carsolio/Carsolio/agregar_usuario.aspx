<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="agregar_usuario.aspx.cs" Inherits="Carsolio.agregar_usuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Sistema de Inventarios</title>
    <link href="css/Style.css" rel="stylesheet" />
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/css/bootstrap.min.css"/>
     <link rel='shortcut icon' href='images/logounison.png'   type='image/png'/>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Panel ID="Nav" runat="server"></asp:Panel>

  <div>
       <asp:Panel ID="Panelagregar_usuario" runat="server">
                 <asp:Label ID="Label1" Style="padding-right: 10%;" runat="server" Text="Nombre: "></asp:Label><br /> 
                 <asp:TextBox ID="txtPersona" Class="form-control" runat="server" placeholder="Personal" required></asp:TextBox> <br /> <br /> <br />
                
                 <asp:Button ID="Button1" CssClass="form-control" runat="server" Text="Aceptar" style="width:100px; margin-left: 361px; " BackColor="#0066FF" BorderColor="Black" ForeColor="White" OnClick="Button1_Click" />

        </asp:Panel>
   </div>
    </form>
</body>
</html>
