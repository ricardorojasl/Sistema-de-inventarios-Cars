<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="consulta_por_codigo.aspx.cs" Inherits="Carsolio.consulta_por_codigo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/css/bootstrap.min.css"/>
    <link href="css/Style.css" rel="stylesheet" />
     <link rel='shortcut icon' href='images/logounison.png'   type='image/png'/>

    <script src="js/jquery-2.1.3.js"></script>
    <script src="js/Script.js"></script>
    <title>Sistema de Inventarios</title>
    <style type="text/css">
        .contenedor {
            height: 409px;
            width: 372px;
        }
    </style>
</head>
<body>
    <form id="formulario" runat="server">
   <div>
       <asp:Panel ID="Nav" runat="server"></asp:Panel>

        <asp:Panel ID="contenedor" runat="server">
            <div class="Codigo">

                 <asp:Label ID="label_codigo" runat="server" Text="CÓDIGO:"></asp:Label>
                <asp:TextBox ID="txtConCod" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:Button ID="Button1" CssClass="form-control" runat="server" Text="Aceptar" style="width:100px; margin-left: 210px; margin-top: 10px;" BackColor="#0066FF" BorderColor="Black" ForeColor="White" OnClick="Button1_Click"  />

            </div>
             <asp:GridView ID="Tabla1" runat="server" BackColor="White" BorderStyle="Ridge" Height="67px" Width="317px"></asp:GridView> 
         
        </asp:Panel>
   </div>

    </form>
</body>
</html>
