using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Carsolio
{
     public partial class AddModulo : System.Web.UI.Page
     {
         Conexion obj = new Conexion();
          protected void Page_Load(object sender, EventArgs e)
          {
               Menu nav_bar = new Menu(Nav);
          }

          protected void Button1_Click(object sender, EventArgs e)
          {
              if (txtModule.Text == txtModuleVer.Text)
              {
                  bool resp = obj.AddMod(txtModule.Text);
                  if (resp)
                  {
                      ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('Se guardo correctamente el modulo');</script>", false);
                      txtModule.Text = null;
                      txtModuleVer.Text = null;
                  }
                  else
                  {
                      ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('No se pudo guardar correctamente el modulo');</script>", false);
                  }
              }
              else
              {
                  ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('Nombre no corresponden. Por favor vuelva a escribir los modulos');</script>", false);
                  txtModule.Text = null;
                  txtModuleVer.Text = null;
              }
          }
     }
}