using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Carsolio
{
     public class Menu
     {
          public Menu(Panel nav)
          {
               nav.Controls.Add(navbar());
          }

          public Literal navbar()
          {
               Literal nav = new Literal();

               nav.Text = "<div class='header'>"
                + "<div class='header-left'>" + "<img src='images/logoUNISON.gif'/></div>"
               + "<div class='header-right'>"
              + "<ul class='nav1'>"
                   + "<li><a href='Trsaccion.aspx'>Salidas</a></li>"
                    + "<li><a href='AddProducts.aspx'>Entradas</a></li>"
                   + "<li><a href='#'>Consultas</a>"

                   + "<ul>"
                   + "<li><a href='consulta_por_nombre.aspx'>Nombre</a></li>"
                   + "<li><a href='consulta_por_codigo.aspx'>Código</a></li>"
                   +"</ul></li>"

                  
                    
                    + "<li><a href='AddModulo.aspx'>Agregar Módulo</a></li>"
                    + "<li><a href='agregar_usuario.aspx'>Agregar Personal</a></li>"
                    + "<li><a href='Reportes.aspx'>Reportes</a></li>"
                    + "<li><a href='index.aspx'>Logout</a></li>"
               + "</ul>"
               + "</div>"
          + "</div>";

               return nav;
          }
     }
}