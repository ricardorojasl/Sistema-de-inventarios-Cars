<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Carsolio.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="UTF-8"/>
<link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/css/bootstrap.min.css"/>
<link href="css/Style.css" rel="stylesheet" />
<link rel='shortcut icon' href='images/logounison.png'   type='image/png'/>
   <script src="js/jquery-2.1.3.js"></script>
    <title>Sistema de Inventarios</title>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class ="cabeza">
            <h2>Sistema de inventarios</h2>
           
        </div>
        <div class="login">          
            <div class="logo">
            <img src="images/logoUNISON.gif" />
            </div>
            <div class="formulario">
               <asp:Label ID="Label1" runat="server" Text="Usuario: "></asp:Label>
                <asp:TextBox ID="usuario" runat="server" Class="form-control" placeholder="Usuario"   style="margin-left: 49px;"></asp:TextBox>
                <br /><br /><br />
               <asp:Label ID="Label2" runat="server" Text="Contraseña: "></asp:Label>
                <asp:TextBox ID="contra" type="Password" runat="server" Class="form-control" placeholder="Contraseña" ></asp:TextBox>
                <asp:Button ID="btnEnviar" runat="server" CssClass="form-control" Text="Entrar"  style="width:100px; margin-left: 300px;" BackColor="#0066FF" BorderColor="Black" ForeColor="White" OnClick="btnEnviar_Click" />                 
            </div>
            <div class="leyenda">
                <p>Sistema de inventarios del departamento de economía. Elaborado por Ramón Ramírez Preciado y Ricado Rojas León.</p>
                <br /><br />
                <p><a target="_blank" href="http://csti.isi.uson.mx/">@CSTI</a></p>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
