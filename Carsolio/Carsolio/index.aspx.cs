using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Carsolio
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
             Conexion obj = new Conexion();
             bool resp = obj.login(usuario.Text,contra.Text);
             if (resp)
             {
                 Response.Redirect("AddModulo.aspx");
             }
             else
             {
                 ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('Usuario y/o contraseña incorrecta');</script>", false);
                 usuario.Text = null;
                 contra.Text = null;
             }
        }


    }
}