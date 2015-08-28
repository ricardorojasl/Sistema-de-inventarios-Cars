using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Carsolio
{
     public partial class Trsaccion : System.Web.UI.Page
     {
        public static Conexion obj = new Conexion();
         string fechaNow = "";
          protected void Page_Load(object sender, EventArgs e)
          {
              if (!IsPostBack)
              {
                  Menu nav_bar = new Menu(Nav);
                  DateTime Hoy = DateTime.Today;
                  fechaNow = Hoy.ToString("yyyy-MM-dd");
                  txtFecha.Text = fechaNow;

                  this.FillCombo();

                  tbConsulta.Visible = false;
                  Button1.Visible = false;
                  txtCod.Focus();
              }
              else { txtCod.Focus();
              }
               

          }
          public void FillCombo()
          {
              List<string> personas = obj.FillModulos("personal");

              foreach (string valor in personas)
              {
                  txtPersona.Items.Add(valor);
              }
          }

          [WebMethod]
          public static string Consultas(string codigo)
          {

              string status = "dafdfasdfs";
              
              return status;
          }

          protected void Button1_Click(object sender, EventArgs e)
          {

              Response.Redirect("Trsaccion.aspx");
              
              
          }

          protected void Button2_Click(object sender, EventArgs e)
          {
              if (txtCod.Text == "")
              {
                  ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('No se Introdujo ningun Codigo');</script>", false);
              }
              try
              {
                  int verif = obj.ConsultaExistencia(Convert.ToInt64(txtCod.Text));
                  if (verif > 0)
                  {
                      obj.consultaCodigo(tbConsulta, Convert.ToInt64(txtCod.Text));
                      string producto = tbConsulta.Rows[0].Cells[1].Text;
                      // string cantidad = tbConsulta.Rows[0].Cells[3].Text;

                      bool resp = obj.AddTran(Convert.ToInt64(txtCod.Text), txtFecha.Text, txtPersona.SelectedItem.ToString(), producto, "1");
                      ListBox1.Items.Add(producto);

                      if (resp)
                      {
                          //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('Se guardo correctamente la transaccion');</script>", false);
                      }
                      else
                      {
                          ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('Upss problemas en la transaccion');</script>", false);

                      }
                      //txtPersona.Items.Clear();
                      //FillCombo();

                      txtCod.Text = null;
                      Button1.Visible = false;
                  }
                  else
                  {

                      ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('Producto Agotado');</script>", false);
                  }
                  txtCod.Text = "";

                  Button1.Visible = true;
                  //txtPersona.Items.Clear();
                  //FillCombo();
              }
              catch (Exception ex) {
                  ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('No se Introdujo ningun Codigo');</script>", false);
              }
          
          }

     }
}