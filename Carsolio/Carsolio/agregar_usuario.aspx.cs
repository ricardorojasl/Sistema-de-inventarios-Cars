using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Carsolio
{
     public partial class agregar_usuario : System.Web.UI.Page
     {
         Conexion obj = new Conexion();
          protected void Page_Load(object sender, EventArgs e)
          {
               Menu nav_bar = new Menu(Nav);
          }

          protected void Button1_Click(object sender, EventArgs e)
          {
              bool resp = obj.AddPersona(txtPersona.Text);
              if (resp)
              {
                  ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('Se guardo correctamente la persona');</script>", false);
                      txtPersona.Text = null;
              }
              else
              {
                  ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('Uppss, no se guardo correctamente a la persona');</script>", false);

              }
          }
     }
}