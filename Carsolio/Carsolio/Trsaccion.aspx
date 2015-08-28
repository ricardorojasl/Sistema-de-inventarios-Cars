<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Trsaccion.aspx.cs" Inherits="Carsolio.Trsaccion" %>

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
    <div>
             <div class="nav-bar">
             <asp:Panel ID="Nav" runat="server">
                 <asp:ScriptManager ID="ScriptManager1" runat="server">
                 </asp:ScriptManager>
                 </asp:Panel>
         </div>
         

         <asp:Panel ID="contenedorTran" runat="server">
              <div class="trasaccion">
                  <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                      <ContentTemplate>
                          <asp:Label ID="Label5" runat="server" Style="padding-right: 5%;" Text="Personal: "></asp:Label>
                          <asp:DropDownList ID="txtPersona" runat="server" Class="form-control">
                          </asp:DropDownList>
                          <asp:Label ID="Label6" runat="server" Style="padding-right: 14.5%;" Text="Fecha: "></asp:Label>
                          <asp:TextBox ID="txtFecha" runat="server" Class="form-control" placeholder="Año/Mes/Dia" required=""></asp:TextBox>
                          <asp:Label ID="Label1" runat="server" Style="padding-right: 12%;" Text="Código: "></asp:Label>
                          <asp:TextBox ID="txtCod" runat="server" Class="form-control" placeholder="Codigo"></asp:TextBox>
                          <asp:Button ID="Button2" runat="server" BackColor="#0066FF" BorderColor="Black" CssClass="form-control" ForeColor="White" OnClick="Button2_Click" style="width:100px; margin-left: 70%; margin-top: 10px;" Text="Buscar" />
                          <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
                          <br />
                          <asp:GridView ID="tbConsulta" runat="server" BackColor="White" BorderStyle="Ridge" Height="158px" Width="379px">
                          </asp:GridView>
                          <asp:Button ID="Button1" runat="server" BackColor="#0066FF" BorderColor="Black" CssClass="form-control" ForeColor="White" OnClick="Button1_Click" style="width:100px; margin-left: 70%; margin-top:10%;"  Text="Aceptar" />
                          <br />
                      </ContentTemplate>
                      <Triggers>
                          <asp:AsyncPostBackTrigger ControlID="Button2" EventName="Click" />
                      </Triggers>
                  </asp:UpdatePanel>
                  <br />
                  <br />
                  <br />
                  <br />
                  <br />
                  <br />
                  <br />
                  <br />
              </div>
         </asp:Panel>
    </div>
    </form>
</body>
</html>
