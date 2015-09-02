using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
 
using System.Data;
namespace Carsolio
{
    public partial class AddProducts : System.Web.UI.Page
    {
        public static Conexion obj = new Conexion();

        string fechaNow;
        string fechaNow2 = "";
        public string codigofinal;
        string modulo = "";
        List<string> modulos2;

        public string pruebaCodigo;


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Menu navbar = new Menu(Nav);
                DateNow();
                this.FillCombo();
                
            }
            
                
               

          

                
            



        }

        public void DateNow()
        {
            DateTime Hoy = DateTime.Today;
            fechaNow = Hoy.ToString("yyyy-MM-dd");
            txtFecha.Text = fechaNow;
        }
        public void FillCombo()
        {
            List<string> modulos = obj.FillModulos("modules");

            modulos2 = modulos.Distinct().ToList();
            foreach (string valor in modulos)
            {
                txtModulo.Items.Add(valor);
            }
            //txtModulo.Items.Clear();

        }

        public Int64 GenerarID()
        {
            Random r = new Random();
            long idr;
            long ran = r.Next(1111, 9999);


            string num = ran.ToString();
            idr = Convert.ToInt64(num);

            return idr;
        }

        [WebMethod]
        public static string Verficacion(string codigo)
        {

            string status = "";
            bool resp = obj.VerificacionProd(Convert.ToInt64(codigo));
            if (resp)
            {
                status = "Producto Repetido";
            }
            return status;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (txtCodigo.Text != "")
            {

                //int query = obj.Prueba1(Convert.ToInt64(txtCodigo.Text));
                //if (query > 0)
                //{
                    try
                    {
                       long verif = Convert.ToInt64(txtCodigo.Text);
                       bool check= obj.VerificacionProd(verif);
                       if (check){
                           ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('El Id ya existe');</script>", false);
                           txtCodigo.Text = "";
                       }
                       else { 

                        bool resp = obj.AddStock(Convert.ToInt64(txtCodigo.Text), txtNombre.Text, txtModulo.SelectedItem.ToString(), Convert.ToInt32(txtCantidad.Text), txtDesc.Text, fechaNow);
                        if (resp)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('Se guardo correctamente el producto');</script>", false);
                            txtCodigo.Text = null;
                            txtNombre.Text = null;
                            txtModulo.Text = null;
                            txtCantidad.Text = null;
                            txtDesc.Text = null;

                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('problemas');</script>", false);
                        }
                    }
                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('" + ex.ToString() + "');</script>", false);
                    }

                    txtModulo.Items.Clear();
                    FillCombo();

                //}
                //else
                //{

                //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('El producto ya existe');</script>", false);
                //}





            }
            else {
                
                //Habre en una nueva pestaña el codigo de barra generado y borrando los campos de los texfield de la cantidad, nombre y descripcion del producto
                string _open = "window.open('BarCode.aspx', '_blank');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

                
                txtCantidad.Text = null;
                txtNombre.Text = null;
                txtDesc.Text = null;

            }
           

            
           




        }

        protected void Button2_Click(object sender, EventArgs e)
        {
         
        }

        //public void GenerarBarra() {
        //    long idran;
        //    bool check = false;
        //    do
        //    {
        //        idran = this.GenerarID();
        //        check = obj.VerificacionProd(idran);

               
        //    } while (check);
        //    //bool resp = obj.AddStock(idran, txtNombre.Text, txtModulo.SelectedItem.ToString(), Convert.ToInt32(txtCantidad.Text), txtDesc.Text, txtFecha.Text);
        //    //if (resp)
        //    //{
        //    //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('Se guardo correctamente el producto');</script>", false);
        //    //    txtCodigo.Text = null;
        //    //    txtNombre.Text = null;
        //    //    txtModulo.Text = null;
        //    //    txtCantidad.Text = null;
        //    //    txtDesc.Text = null;

        //    //}

        //        txtCodigo.Text = idran.ToString();


        //        codigofinal = txtCodigo.Text;
        //        // Multiply the lenght of the code by 40 (just to have enough width)
        //        int w = codigofinal.Length * 80;

        //        // Create a bitmap object of the width that we calculated and height of 100
        //        Bitmap oBitmap = new Bitmap(w, 150);

        //        // then create a Graphic object for the bitmap we just created.
        //        Graphics oGraphics = Graphics.FromImage(oBitmap);

        //        // Now create a Font object for the Barcode Font
        //        // (in this case the IDAutomationHC39M) of 18 point size
        //        Font oFont = new Font("IDAutomationHC39M Free Version", 18);

        //        // Let's create the Point and Brushes for the barcode
        //        PointF oPoint = new PointF(2f, 2f);
        //        SolidBrush oBrushWrite = new SolidBrush(Color.Black);
        //        SolidBrush oBrush = new SolidBrush(Color.White);

        //        // Now lets create the actual barcode image
        //        // with a rectangle filled with white color
        //        oGraphics.FillRectangle(oBrush, 0, 0, w, 150);

        //        // We have to put prefix and sufix of an asterisk (*),
        //        // in order to be a valid barcode
        //        oGraphics.DrawString("*" + codigofinal + "*", oFont, oBrushWrite, oPoint);

        //        // Then we send the Graphics with the actual barcode

        //        Response.ContentType = "image/jpeg";
           
        //        oBitmap.Save(Response.OutputStream, ImageFormat.Jpeg);

        //        //try
        //        //{
        //        //    bool resp = obj.AddStock(idran, txtNombre.Text, txtModulo.SelectedItem.ToString(), Convert.ToInt32(txtCantidad.Text), txtDesc.Text, fechaNow);
        //        //    if (resp)
        //        //    {
        //        //        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('Se guardo correctamente el producto');</script>", false);
        //        //        txtCodigo.Text = null;
        //        //        txtNombre.Text = null;
        //        //        txtModulo.Text = null;
        //        //        txtCantidad.Text = null;
        //        //        txtDesc.Text = null;

        //        //    }
        //        //    else
        //        //    {
        //        //        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('problemas');</script>", false);
        //        //    }

        //        //}
        //        //catch (Exception ex)
        //        //{
        //        //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('" + ex.ToString() + "');</script>", false);
        //        //}
            
        //}

        
      




        

        
    }
}