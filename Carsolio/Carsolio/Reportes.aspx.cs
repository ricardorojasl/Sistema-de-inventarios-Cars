using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text.html.simpleparser;
 
using System.Data;
using System.IO;
using System.Data.SqlClient;
namespace Carsolio
{
    public partial class Reportes : System.Web.UI.Page
    {
        string[] nombres = new string[6];

        Conexion bd = new Conexion();
        protected void Page_Load(object sender, EventArgs e)
        {
            Menu nav_bar = new Menu(Nav);
          

        }
        protected void crear_pdf()
        {
            nombres[0] = "Id";
            nombres[1] = "Producto";
            nombres[2] = "Módulo";
            nombres[3] = "Cantidad";
            nombres[4] = "Fecha";
            nombres[5] = "Descripción";
            DataSet datos = new DataSet();
            datos = bd.GenerarReporte();
            Tabla1.DataSource = datos;
            Tabla1.DataBind();

            int cols = bd.Columnas();
            iTextSharp.text.Table table = new iTextSharp.text.Table(cols);
            table.Cellpadding = 2;
            table.Width = 100;
            ///////////////////////////////////////////////////////
            /*AQUI SE COMIENZA A CREAR UNA TABLA EN EL PDF USANDO LOS DATOS DEL GRIDVIEW */
            ///////////////////////////////////////////////////////

            for (int i = 0; i < cols; i++)
            {

                string cellText = Server.HtmlDecode

                                          (nombres[i]);

                iTextSharp.text.Cell cell = new iTextSharp.text.Cell(cellText);

                cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#93a31d"));

                table.AddCell(cell);

            }

            for (int i = 0; i < Tabla1.Rows.Count; i++)
            {

                if (Tabla1.Rows[i].RowType == DataControlRowType.DataRow)
                {

                    for (int j = 0; j < cols; j++)
                    {

                        string cellText = Server.HtmlDecode

                                          (Tabla1.Rows[i].Cells[j].Text);

                        iTextSharp.text.Cell cell = new iTextSharp.text.Cell(cellText);
                        //Set Color of Alternating row
                        if (i % 2 != 0)
                        {
                            cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#dce0bc"));
                        }

                        table.AddCell(cell);
                    }
                }
            }
            //////////////////////////////////////////////////////////
            /* CREACION DEL DOCUMENTO PDF USANDO LA LIBRERIA iTextSharp*/
            //////////////////////////////////////////////////////////

            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);

            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);

            pdfDoc.Open();

            pdfDoc.Add(table);

            pdfDoc.Close();

            Response.ContentType = "application/pdf";


            Response.AddHeader("content-disposition", "attachment;" +

                                           "filename=Inventario.pdf");

            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            Response.Write(pdfDoc);

            Response.End();
        }
        protected void crear_excel()
        {
            ////////////////////////////////////////////////////////////////////////////////////////////
            /*HACER LA CONSULTA DIRECTAMENTE DESDE ESTE MEDIO PARA EVITAR PROBLEMAS CON FILAS/COLUMNAS */
            ///////////////////////////////////////////////////////////////////////////////////////////

            SqlConnection con = new SqlConnection();
            SqlCommand cmd;
            con.ConnectionString = "Data Source=.\\SQLExpress;Integrated Security=true;Initial Catalog=carsolio";
            con.Open();
            DataTable datos = new DataTable();
            cmd = new SqlCommand("select IdProduct as ID, NameProd as Producto, NameModule as Modulo, Quantity as Cantidad, Date as fecha, Description as Descripcion from stock", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(datos);
            con.Close();


            ///////////////////////////////////////////
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=Inventario.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                Tabla1.AllowPaging = false;
                Tabla1.DataSource = datos;
                Tabla1.DataBind();
                Page page = new Page();
                page.EnableEventValidation = false;
                //Tabla1.HeaderRow.BackColor = System.Drawing.Color.Transparent;
                foreach (TableCell cell in Tabla1.HeaderRow.Cells)
                {
                    cell.BackColor = Tabla1.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in Tabla1.Rows)
                {
                    row.BackColor = System.Drawing.Color.Transparent;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = Tabla1.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = Tabla1.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                Tabla1.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();

            }
        }
        protected void reporte_personal(string personal)
        {
            ////////////////////////////////////////////////////////////////////////////////////////////
            /*HACER LA CONSULTA DIRECTAMENTE DESDE ESTE MEDIO PARA EVITAR PROBLEMAS CON FILAS/COLUMNAS */
            ///////////////////////////////////////////////////////////////////////////////////////////

            SqlConnection con = new SqlConnection();
            SqlCommand cmd;
            con.ConnectionString = "Data Source=.\\SQLExpress;Integrated Security=true;Initial Catalog=carsolio";
            con.Open();
            DataTable datos = new DataTable();
            cmd = new SqlCommand("select idProd as Codigo, Producto, Cantidad, Fecha  from transacciones where Persona= '"+personal+"'", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(datos);
            con.Close();


            ///////////////////////////////////////////
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=Transacciones "+personal+".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                Tabla1.AllowPaging = false;
                Tabla1.DataSource = datos;
                Tabla1.DataBind();
              
                Page page = new Page();
                page.EnableEventValidation = false;
                
                //Tabla1.HeaderRow.BackColor = System.Drawing.Color.Transparent;
              
                foreach (TableCell cell in Tabla1.HeaderRow.Cells)
                {
                    cell.BackColor = Tabla1.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in Tabla1.Rows)
                {
                    row.BackColor = System.Drawing.Color.Transparent;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = Tabla1.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = Tabla1.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                Tabla1.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();

            }
        }
        protected void ButtonExcel_Click(object sender, EventArgs e)
        {
            crear_excel();
        }
        public void FillCombo()
        {
            List<string> personas = bd.FillModulos("personal");

            foreach (string valor in personas)
            {
                DropPersona.Items.Add(valor);
            }
        }


        //protected void ButtonPDF_Click(object sender, EventArgs e)
        //{
        //    crear_pdf();
        //}

        public override void VerifyRenderingInServerForm(Control control)
        {
            return;
        }

        protected void BtnPersonas_Click(object sender, EventArgs e)
        {

            DropPersona.Visible = true;
            BtnGenerar.Visible = true;
            FillCombo();

        }

        protected void BtnGenerar_Click(object sender, EventArgs e)
        {
            
            string persona = DropPersona.SelectedItem.ToString();
            
      
            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('"+DropPersona.SelectedItem.ToString()+"');</script>", false);
            DropPersona.Items.Clear();
            FillCombo();
            reporte_personal(persona);
        }
    }
}