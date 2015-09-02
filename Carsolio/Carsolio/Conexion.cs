using System;
using System.Collections;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace Carsolio
{
     public class Conexion
     {
         
         static string strcon = "Data Source=localhost\\MSSQL10_50.SQLEXPRESS; Initial Catalog=carsolio";
          SqlConnection con= new  SqlConnection(strcon);
          SqlCommand cmd;
          SqlDataReader dr;
          SqlDataAdapter da;
         
         string str;
         object obj;

         public bool login(string user, string contra)
         {
              bool resp; 
              con.Open();
              str = "select count(*) from user where User=@UserName and Password =@Password";
              cmd = new  SqlCommand(str, con);
              cmd.CommandType = CommandType.Text;
              cmd.Parameters.AddWithValue("@UserName", user);
              cmd.Parameters.AddWithValue("@Password", contra);
              obj = cmd.ExecuteScalar();
              if (Convert.ToInt32(obj) != 0)
              {
                   resp = true;
              }
              else
              {
                   resp = false;
              }
              con.Close();
              return resp;
         }

         public bool AddStock(long code, string nombre, string modulo, int cantidad, string descripcion,string date)
         {
             bool resp = false;
             using(cmd = new  SqlCommand("insert into Stock (idProduct,NameProd,NameModule,Quantity,Description,date) values(@id,@nombre,@modulo,@cantidad,@desc,@date)",con)){
                 cmd.Parameters.AddWithValue("@id", code);
                 cmd.Parameters.AddWithValue("@nombre", nombre);
                 cmd.Parameters.AddWithValue("@modulo", modulo);
                 cmd.Parameters.AddWithValue("@cantidad", cantidad);
                 cmd.Parameters.AddWithValue("@desc", descripcion);
                 cmd.Parameters.AddWithValue("@date", date);
                 cmd.Connection = con;
                 con.Open();
                 cmd.ExecuteNonQuery();
                 con.Close();
                 resp = true;
             }    
             
             return resp;
         }

         public bool AddMod(string modulo)
         {
             bool resp = false;
             using (cmd = new  SqlCommand("insert into modules (modules) values(@module)", con))
             {
                 cmd.Parameters.AddWithValue("@module", modulo);
                 cmd.Connection = con;
                 con.Open();
                 cmd.ExecuteNonQuery();
                 con.Close();
                 resp = true;
             }
             return resp;
         }

         public bool VerificacionProd(long code)
         {
             bool resp;
             con.Open();
             str = "select count(*) from stock where idProduct=@id";
             cmd = new  SqlCommand(str, con);
             cmd.CommandType = CommandType.Text;
             cmd.Parameters.AddWithValue("@id", code);
             obj = cmd.ExecuteScalar();
             if (Convert.ToInt32(obj) != 0)
             {
                 resp = true;
             }
             else
             {
                 resp = false;
             }
             con.Close();
             return resp;
         }
       
         public List<string> FillModulos(string tabla)
         {
             List<string> modulos = new List<string>();
             int contador = 0;
             con.Open();
            
                 cmd = new  SqlCommand("select "+tabla+" from "+tabla+"", con);
                  SqlDataReader leer = cmd.ExecuteReader();
                 while (leer.Read())
                 {
                     modulos.Insert(contador, leer.GetString(0));
                     contador++;
                 }
                 con.Close();
             return modulos;
         }

         public bool AddPersona(string persona)
         {
             bool resp = false;
             using (cmd = new  SqlCommand("insert into personal (personal) values(@nombre)", con))
             {
                 cmd.Parameters.AddWithValue("@nombre", persona);
                 cmd.Connection = con;
                 con.Open();
                 cmd.ExecuteNonQuery();
                 con.Close();
                 resp = true;
             }
             return resp;
         }

         public bool AddTran(long code, string date, string persona,string producto, string cantidad)
         {
             bool resp = false;
             using (cmd = new  SqlCommand("insert into transacciones (idProd,Producto,Cantidad,Fecha,Persona) values(@id,@producto,@cantidad,@fecha,@persona)", con))
             {
                 cmd.Parameters.AddWithValue("@id", code);
                 cmd.Parameters.AddWithValue("@fecha", date);
                 cmd.Parameters.AddWithValue("@persona", persona);
                 cmd.Parameters.AddWithValue("@producto", producto);
                 cmd.Parameters.AddWithValue("@cantidad", Convert.ToInt32(cantidad));
                 cmd.Connection = con;
                 con.Open();
                 cmd.ExecuteNonQuery();
                 con.Close();
                 resp = true;
             }
             UpDateTran(code, cantidad);
             return resp;
         }

         public void UpDateTran(long code, string cantidad)
         {
             using (cmd = new  SqlCommand("update stock set Quantity = Quantity - @cantidad where  IdProduct = @id", con))
             {
                 cmd.Parameters.AddWithValue("@id", code);              
                 cmd.Parameters.AddWithValue("@cantidad", Convert.ToInt32(cantidad));
                 cmd.Connection = con;
                 con.Open();
                 cmd.ExecuteNonQuery();
                 con.Close();
                 
             }
         }
         public void consultaCodigo(GridView tabla, long codigo)
         {
             con.Open();
             DataSet datos = new DataSet();
             cmd = new  SqlCommand("select IdProduct as ID, NameProd as Producto, NameModule as Modulo, Quantity as Cantidad, Date as Fecha, Description as Descripcion from stock where IdProduct=" + "'" + codigo + "'", con);
              SqlDataAdapter adapter = new  SqlDataAdapter(cmd);
             adapter.Fill(datos);
             tabla.DataSource = datos;
             tabla.DataBind();

             con.Close();

         }

         public void consultaGeneral(GridView tabla, string producto)
         {
             con.Open();
             DataSet datos = new DataSet();
             cmd = new  SqlCommand("select sum(Quantity) as Cantidad, NameModule as Modulo from stock where NameProd like" + "'%" + producto + "%'", con);
              SqlDataAdapter adapter = new  SqlDataAdapter(cmd);
             adapter.Fill(datos);
             tabla.DataSource = datos;
             tabla.DataBind();
             con.Close();
         }

         public DataSet GenerarReporte()
         {

             con.Open();
             DataSet datos = new DataSet();
             cmd = new  SqlCommand("select * from stock", con);
             cmd.ExecuteNonQuery();
              SqlDataAdapter adapter = new  SqlDataAdapter(cmd);

             adapter.Fill(datos);

             con.Close();

             return datos;



         }

         public int ConsultaExistencia(long codigo) {
             con.Open();
             int exis;
             cmd = new  SqlCommand("select Quantity from Stock where IdProduct='" + codigo + "'", con);
             exis = Convert.ToInt32(cmd.ExecuteScalar());
             con.Close();
             return exis;
             
         
         }


         public int Columnas()
         {
 
             con.Open();

             cmd = new  SqlCommand("SELECT count(*) FROM information_schema.columns WHERE table_name = 'stock'", con);
             int cols = Convert.ToInt32(cmd.ExecuteScalar());

             con.Close();

             return cols;


         }

         public int Prueba1(long codigo) {
             con.Open();
             cmd = new  SqlCommand("Select IdProduct from stock where IdProduct='" + codigo + "'", con);
             int result = Convert.ToInt32(cmd.ExecuteScalar());
             con.Close();
             return result;
         }
         public string LlenarTicket(long codigo)
         {

             con.Open();
             cmd = new  SqlCommand("Select NameProd from stock where IdProduct=" + "'" + codigo + "'", con);
             string producto = Convert.ToString(cmd.ExecuteScalar());

             con.Close();
             return producto;
         }
     }
}