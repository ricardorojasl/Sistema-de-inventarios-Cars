using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Carsolio
{
     public partial class consulta_por_nombre : System.Web.UI.Page
     {
         Conexion obj = new Conexion();
          protected void Page_Load(object sender, EventArgs e)
          {
               Menu nav_bar = new Menu(Nav);
               Tabla2.Visible = false;

          }

          protected void Button1_Click(object sender, EventArgs e)
          {
              obj.consultaGeneral(Tabla2, Convert.ToString(txtcnnombre.Text));

              Tabla2.Visible = true;
              txtcnnombre.Text = "";
          }
     }
}