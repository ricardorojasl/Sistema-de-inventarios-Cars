<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="Carsolio.Reportes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/css/bootstrap.min.css"/>
    <link href="css/Style.css" rel="stylesheet" />
     <link rel='shortcut icon' href='images/logounison.png'   type='image/png'/>
    <title>Sistema de Inventarios</title>

    <script src="js/jquery-2.1.3.js"></script>
    
</head>
<body>
      <form id="form1" runat="server">
    <asp:Panel ID="Nav" runat="server"></asp:Panel>
      

          <div>
       <asp:Panel ID="PanelReportes" runat="server">
    <asp:Button ID="ButtonExcel" CssClass="form-control" runat="server" Text="Generar Reporte Stock" style="width:220px; margin-left:25%; margin-top:5%;" BackColor="#0066FF" BorderColor="Black" ForeColor="White" OnClick="ButtonExcel_Click"  />
<%--    <asp:Button ID="ButtonPDF" CssClass="form-control" runat="server" Text="Generar PDF" style="width:120px; margin-left:35%; margin-top:20%;" BackColor="#0066FF" BorderColor="Black" ForeColor="White"  OnClick="ButtonPDF_Click"/>--%>
       <asp:Button ID="BtnPersonas" CssClass="form-control" runat="server" Text="Generar Reporte Transacciones" style="width:220px; margin-left:25%; margin-top:5%;" BackColor="#0066FF" BorderColor="Black" ForeColor="White" OnClick="BtnPersonas_Click"  />
          <asp:DropDownList ID="DropPersona"  Class="form-control" runat="server" Visible="False"></asp:DropDownList>
                  <asp:Button ID="BtnGenerar" CssClass="form-control" runat="server" Text="Generar" style="width:120px; margin-left:40%; margin-top:5%;" BackColor="#0066FF" BorderColor="Black" ForeColor="White" OnClick="BtnGenerar_Click" Visible="False"  />


        </asp:Panel>
   </div>
          <asp:GridView ID="Tabla1" runat="server"></asp:GridView>
    </form>
</body>
</html>
