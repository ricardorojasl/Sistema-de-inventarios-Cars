using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;

namespace Carsolio
{
    public partial class BarCode : System.Web.UI.Page
    {
        public static Conexion obj = new Conexion();
        AddProducts prod = new AddProducts();

       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GenerarBarra();
            }
  
            

        }

        public void GenerarBarra()
        {
            long idran;
            bool check = false;
            do
            {
                idran = prod.GenerarID();
                check = obj.VerificacionProd(idran);


            } while (check);
            //bool resp = obj.AddStock(idran, txtNombre.Text, txtModulo.SelectedItem.ToString(), Convert.ToInt32(txtCantidad.Text), txtDesc.Text, txtFecha.Text);
            //if (resp)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('Se guardo correctamente el producto');</script>", false);
            //    txtCodigo.Text = null;
            //    txtNombre.Text = null;
            //    txtModulo.Text = null;
            //    txtCantidad.Text = null;
            //    txtDesc.Text = null;

            //}
            
            //prod.txtCodigo.Text = idran.ToString();


           string codigofinal  = idran.ToString();
            // Multiply the lenght of the code by 40 (just to have enough width)
            int w = codigofinal.Length * 80;

            // Create a bitmap object of the width that we calculated and height of 100
            Bitmap oBitmap = new Bitmap(w, 150);

            // then create a Graphic object for the bitmap we just created.
            Graphics oGraphics = Graphics.FromImage(oBitmap);

            // Now create a Font object for the Barcode Font
            // (in this case the IDAutomationHC39M) of 18 point size
            Font oFont = new Font("IDAutomationHC39M Free Version", 18);

            // Let's create the Point and Brushes for the barcode
            PointF oPoint = new PointF(2f, 2f);
            SolidBrush oBrushWrite = new SolidBrush(Color.Black);
            SolidBrush oBrush = new SolidBrush(Color.White);

            // Now lets create the actual barcode image
            // with a rectangle filled with white color
            oGraphics.FillRectangle(oBrush, 0, 0, w, 150);

            // We have to put prefix and sufix of an asterisk (*),
            // in order to be a valid barcode
            oGraphics.DrawString("*" + codigofinal + "*", oFont, oBrushWrite, oPoint);

            // Then we send the Graphics with the actual barcode

            Response.ContentType = "image/jpeg";

            oBitmap.Save(Response.OutputStream, ImageFormat.Jpeg);
            //try
            //{
            //    bool resp = obj.AddStock(idran, txtNombre.Text, txtModulo.SelectedItem.ToString(), Convert.ToInt32(txtCantidad.Text), txtDesc.Text, fechaNow);
            //    if (resp)
            //    {
            //        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('Se guardo correctamente el producto');</script>", false);
            //        txtCodigo.Text = null;
            //        txtNombre.Text = null;
            //        txtModulo.Text = null;
            //        txtCantidad.Text = null;
            //        txtDesc.Text = null;

            //    }
            //    else
            //    {
            //        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('problemas');</script>", false);
            //    }

            //}
            //catch (Exception ex)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('" + ex.ToString() + "');</script>", false);
            //}

        }
    }
}