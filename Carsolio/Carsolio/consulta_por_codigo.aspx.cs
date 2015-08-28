using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
namespace Carsolio
{
     public partial class consulta_por_codigo : System.Web.UI.Page
     {
         Conexion obj = new Conexion();
          protected void Page_Load(object sender, EventArgs e)
          {
               Menu nav_bar = new Menu(Nav);
               Tabla1.Visible = false;

          }


          protected void Button1_Click(object sender, EventArgs e)
          {
              obj.consultaCodigo(Tabla1, Convert.ToInt64(txtConCod.Text));
              Tabla1.Visible = true;
              txtConCod.Text = "";
          }

          
     }
}