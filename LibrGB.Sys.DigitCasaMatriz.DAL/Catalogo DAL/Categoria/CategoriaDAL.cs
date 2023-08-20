using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//-------REFERENCIAS-----------
using System.Data.SqlClient;
using LibrGB.Sys.DigitCasaMatriz.EN.Catalogo.Categoria;

namespace LibrGB.Sys.DigitCasaMatriz.DAL.CatalogoDAL.Categoria
{
    public class CategoriaDAL
    {
        public int GuardarCategoria(CategoriaEN pCategoriaGuardar)
        {
            //----------- INICIO VALIDACION CODIGO YA EXISTENTE ----------

            //Obtener todas las categorias
            var categorias = ObtenerCategoria();

            //Expresion Lambda para buscar una categoria usando FirstOrDefault que obtiene el primer registro que coincida con el parametro pCategoriaGuardar.Codigo
            var categoria = categorias.FirstOrDefault(c => c.Codigo == pCategoriaGuardar.Codigo);
            //Validar si la categoria es NULL 
            if (categoria != null)
            {
                return 0;
            }

            //----------- FINAL VALIDACION CODIGO YA EXISTENTE ----------


            SqlCommand command = ComunBD.ObtenerComando();
            // Obtener un SqlCommand a través del método ObtenerComando() de la clase ComunBD.

            command.CommandType = System.Data.CommandType.StoredProcedure;
            // Establecer el tipo de comando como un procedimiento almacenado.

            command.CommandText = "SPGuardarCategoria";
            // Establecer el nombre del procedimiento almacenado a ejecutar.

            //---------------------- TRAEMOS LOS PARAMETROS Y DESPUES DEL . VA EL NOMBRE DEL ATRIBUTO DECLARADO EN LA "EN"---------------------------

            // @Nombre: Asigna el valor de la propiedad Nombre del objeto pCategoriaGuardar al parámetro.
            command.Parameters.AddWithValue("@Nombre", pCategoriaGuardar.Nombre);

            // @Codigo: Asigna el valor de la propiedad Codigo del objeto pCategoriaGuardar al parámetro.
            command.Parameters.AddWithValue("@Codigo", pCategoriaGuardar.Codigo);

            // @Descripcion: Asigna el valor de la propiedad Descripcion del objeto pCategoriaGuardar al parámetro.
            command.Parameters.AddWithValue("@Descripcion", pCategoriaGuardar.Descripcion);

            // @FechaCreacion: Asigna el valor de la propiedad FechaCreacion del objeto pCategoriaGuardar al parámetro.
            command.Parameters.AddWithValue("@FechaCreacion", pCategoriaGuardar.FechaCreacion);

            return ComunBD.EjecutarComando(command);
            // Ejecutar el comando a través del método EjecutarComando() de la clase ComunBD y devolver el resultado.

        }

        public int ModificarCategoria(CategoriaEN pCategoriaModificar)
        {
            SqlCommand command = ComunBD.ObtenerComando();
            // Obtener un SqlCommand a través del método ObtenerComando() de la clase ComunBD.

            command.CommandType = System.Data.CommandType.StoredProcedure;
            // Establecer el tipo de comando como un procedimiento almacenado.

            command.CommandText = "SPModificarCategoria";
            // Establecer el nombre del procedimiento almacenado a ejecutar.

            //---------------------- TRAEMOS LOS PARAMETROS Y DESPUES DEL . VA EL NOMBRE DEL ATRIBUTO DECLARADO EN LA "EN"---------------------------

            // Agregar un parámetro llamado @Id con el valor de la propiedad Id del objeto pCategoriaModificar.
            command.Parameters.AddWithValue("@Id", pCategoriaModificar.Id);

            // Agregar un parámetro llamado @Nombre con el valor de la propiedad Nombre del objeto pCategoriaModificar.
            command.Parameters.AddWithValue("@Nombre", pCategoriaModificar.Nombre);

            // Agregar un parámetro llamado @Codigo con el valor de la propiedad Codigo del objeto pCategoriaModificar.
            command.Parameters.AddWithValue("@Codigo", pCategoriaModificar.Codigo);

            // Agregar un parámetro llamado @Descripcion con el valor de la propiedad Descripcion del objeto pCategoriaModificar.
            command.Parameters.AddWithValue("@Descripcion", pCategoriaModificar.Descripcion);

            // Agregar un parámetro llamado @FechaModificacion con el valor de la propiedad FechaModificacion del objeto pCategoriaModificar.
            command.Parameters.AddWithValue("@FechaModificacion", pCategoriaModificar.FechaModificacion);

            return ComunBD.EjecutarComando(command);
            // Ejecutar el comando a través del método EjecutarComando() de la clase ComunBD y devolver el resultado.

        }

        public int EliminarCategoria(CategoriaEN pCategoriaEliminar)
        {
            SqlCommand command = ComunBD.ObtenerComando();
            // Obtener un SqlCommand a través del método ObtenerComando() de la clase ComunBD.

            command.CommandType = System.Data.CommandType.StoredProcedure;
            // Establecer el tipo de comando como un procedimiento almacenado.

            command.CommandText = "SPEliminarCategoria";
            // Establecer el nombre del procedimiento almacenado a ejecutar.

            //---------------------- TRAEMOS LOS PARAMETROS Y DESPUES DEL . VA EL NOMBRE DEL ATRIBUTO DECLARADO EN LA "EN"---------------------------

            command.Parameters.AddWithValue("@Id", pCategoriaEliminar.Id);
            // Agregar un parámetro llamado "@Id" con el valor de la propiedad Id del objeto pCategoriaEliminar.

            return ComunBD.EjecutarComando(command);
            // Ejecutar el comando a través del método EjecutarComando() de la clase ComunBD y devolver el resultado.

        }

        public List<CategoriaEN> ObtenerCategoria()
        {
            List<CategoriaEN> listaCategoria = new List<CategoriaEN>();
            // Crear una nueva lista de objetos de tipo CategoriaEN.

            SqlCommand command = ComunBD.ObtenerComando();
            // Obtener un SqlCommand a través del método ObtenerComando() de la clase ComunBD.

            command.CommandType = System.Data.CommandType.StoredProcedure;
            // Establecer el tipo de comando como un procedimiento almacenado.

            command.CommandText = "SPMostrarCategoria";
            // Establecer el nombre del procedimiento almacenado a ejecutar.

            SqlDataReader reader = ComunBD.EjecutarComandoReader(command);
            // Ejecutar el comando y obtener un SqlDataReader a través del método EjecutarComandoReader() de la clase ComunBD.

            while (reader.Read())
            {
                CategoriaEN ObjCategoria = new CategoriaEN();
                // Crear una nueva instancia de la clase CategoriaEN para almacenar los datos de la categoría.

                //----- Nombres de los Campos en el Data Grid ------

                ObjCategoria.Id = reader.GetInt32(0);
                // Asignar el valor entero del primer campo (índice 0) al Id de ObjCategoria.

                ObjCategoria.Nombre = reader.GetString(1);
                // Asignar el valor de cadena del segundo campo (índice 1) al Nombre de ObjCategoria.

                ObjCategoria.Codigo = reader.GetString(2);
                // Asignar el valor de cadena del tercer campo (índice 2) al Codigo de ObjCategoria.

                ObjCategoria.Descripcion = reader.GetString(5);
                // Asignar el valor de cadena del sexto campo (índice 5) a Descripcion de ObjCategoria.

                ObjCategoria.FechaCreacion = reader.GetDateTime(3);
                // Asignar el valor de fecha y hora del cuarto campo (índice 3) a FechaCreacion de ObjCategoria.

                ObjCategoria.FechaModificacion = reader.GetDateTime(4);
                // Asignar el valor de fecha y hora del quinto campo (índice 4) a FechaModificacion de ObjCategoria.

                listaCategoria.Add(ObjCategoria);
                // Agregar ObjCategoria a la lista de categorías.
            }
            return listaCategoria;
            // Devolver la lista de categorías.

        }

        public CategoriaEN ObtenerCategoriaPorId(int? pId)
        {
            SqlCommand command = ComunBD.ObtenerComando();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "SPObtenerCategoriaPorId";
            command.Parameters.AddWithValue("@Id", pId);
            SqlDataReader reader = ComunBD.EjecutarComandoReader(command);
            // Se crea un objeto SqlCommand llamado "command" y se obtiene un comando de la clase ComunBD
            // Se establece el tipo de comando como StoredProcedure y se asigna el nombre del procedimiento almacenado como "SPObtenerCategoriaPorId"
            // Se agrega un parámetro llamado "@Id" con el valor de "pId" al comando
            // Se ejecuta el comando y se obtiene un SqlDataReader llamado "reader"


            CategoriaEN categoria = new CategoriaEN();
            // Se crea una instancia del objeto CategoriaEN llamada "categoria"

            if (reader.Read())
            {
                // Si hay filas disponibles en el SqlDataReader, se procede a leer los valores de cada columna y asignarlos a las propiedades del objeto "categoria"

                // Lee el valor en la primera columna (índice 0) del SqlDataReader y lo asigna a la propiedad Id del objeto categoria.
                categoria.Id = reader.GetInt32(0);

                // Lee el valor en la segunda columna (índice 1) del SqlDataReader y lo asigna a la propiedad Nombre del objeto categoria.
                categoria.Nombre = reader.GetString(1);

                // Lee el valor en la tercera columna (índice 2) del SqlDataReader y lo asigna a la propiedad Codigo del objeto categoria.
                categoria.Codigo = reader.GetString(2);

                // Lee el valor en la cuarta columna (índice 3) del SqlDataReader y lo asigna a la propiedad Descripcion del objeto categoria.
                categoria.Descripcion = reader.GetString(3);

                // Lee el valor en la quinta columna (índice 4) del SqlDataReader y lo asigna a la propiedad FechaCreacion del objeto categoria.
                categoria.FechaCreacion = reader.GetDateTime(4);

                // Lee el valor en la sexta columna (índice 5) del SqlDataReader y lo asigna a la propiedad FechaModificacion del objeto categoria.
                categoria.FechaModificacion = reader.GetDateTime(5);

            }
            return categoria;
            // Se devuelve el objeto "categoria" que contiene los valores leídos del SqlDataReader

        }

        public List<CategoriaEN> ObtenerCategoriasLike(string pNombre)
        {
            List<CategoriaEN> listaCategoria = new List<CategoriaEN>();
            // Crear una nueva lista de objetos de tipo CategoriaEN.

            SqlCommand command = ComunBD.ObtenerComando();
            // Obtener un SqlCommand a través del método ObtenerComando() de la clase ComunBD.

            command.CommandType = System.Data.CommandType.StoredProcedure;
            // Establecer el tipo de comando como un procedimiento almacenado.

            command.CommandText = "SPObtenerCategoriasLike";
            // Establecer el nombre del procedimiento almacenado a ejecutar.
            command.Parameters.AddWithValue("@Nombre", pNombre);
            // Agregar un parámetro llamado "@Id" con el valor de la propiedad IdCategoria 

            SqlDataReader reader = ComunBD.EjecutarComandoReader(command);
            // Ejecutar el comando y obtener un SqlDataReader a través del método EjecutarComandoReader() de la clase ComunBD.

            while (reader.Read())
            {
                CategoriaEN ObjCategoria = new CategoriaEN();
                // Crear una nueva instancia de la clase CategoriaEN para almacenar los datos de la categoría.

                //----- Nombres de los Campos en el Data Grid ------

                // Leer los valores de las columnas en el SqlDataReader y asignarlos a las propiedades del objeto ObjCategoriaEN.
                ObjCategoria.Id = reader.GetInt32(0);

                ObjCategoria.Nombre = reader.GetString(1);

                ObjCategoria.Codigo = reader.GetString(2);

                ObjCategoria.Descripcion = reader.GetString(3);

                ObjCategoria.FechaCreacion = reader.GetDateTime(4);

                ObjCategoria.FechaModificacion = reader.GetDateTime(5);

                listaCategoria.Add(ObjCategoria);
                // Agregar ObjCategoria a la lista de categorías.
            }
            return listaCategoria;
            // Devolver la lista de categorías.

        }
    }
}
