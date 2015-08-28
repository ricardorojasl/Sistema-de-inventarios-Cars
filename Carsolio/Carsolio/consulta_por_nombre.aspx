<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="consulta_por_nombre.aspx.cs" Inherits="Carsolio.consulta_por_nombre" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/Style.css" rel="stylesheet" />
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/css/bootstrap.min.css"/>
     <link rel='shortcut icon' href='images/logounison.png'   type='image/png'/>
    <title>Sistema de Inventarios</title>
</head>
<body>
    <form id="CNombre" runat="server">
        <br />
    <asp:Panel ID="Nav" runat="server"></asp:Panel>
      <div>
       <asp:Panel ID="PanelCNM" runat="server">

        
            <div class="CNNombre">

                <asp:Label ID="label_cnnombre" runat="server" Text="NOMBRE:"></asp:Label>
                <asp:TextBox ID="txtcnnombre" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:Button ID="Button1" CssClass="form-control" runat="server" Text="Aceptar" style="width:100px; margin-left: 210px; margin-top: 10px;" BackColor="#0066FF" BorderColor="Black" ForeColor="White" OnClick="Button1_Click" />
            </div>
           <asp:GridView ID="Tabla2" runat="server" BackColor="White" BorderStyle="Ridge" Height="46px" Width="248px"></asp:GridView>
               
        </asp:Panel>
   </div>
    </form>
</body>
</html>
