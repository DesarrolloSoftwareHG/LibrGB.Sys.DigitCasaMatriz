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

            // Crea un nuevo comando SQL utilizando la conexión de la base de datos.
            SqlCommand command = ComunBD.ObtenerComando();

            // Establece el tipo de comando como una llamada a un procedimiento almacenado.
            command.CommandType = System.Data.CommandType.StoredProcedure;

            // Define el nombre del procedimiento almacenado que se utilizará.
            command.CommandText = "SPGuardarCategoria";

            // Agrega parámetros al comando para representar los valores de la categoría a guardar.
            command.Parameters.AddWithValue("@Nombre", pCategoriaGuardar.Nombre);
            command.Parameters.AddWithValue("@Codigo", pCategoriaGuardar.Codigo);
            command.Parameters.AddWithValue("@Descripcion", pCategoriaGuardar.Descripcion);
            command.Parameters.AddWithValue("@FechaCreacion", pCategoriaGuardar.FechaCreacion);

            // Ejecuta el comando a través del método EjecutarComando() de la clase ComunBD y devuelve el resultado.
            return ComunBD.EjecutarComando(command);
        }

        public int ModificarCategoria(CategoriaEN pCategoriaModificar)
        {
            // Crea un nuevo comando SQL utilizando la conexión de la base de datos.
            SqlCommand command = ComunBD.ObtenerComando();

            // Establece el tipo de comando como una llamada a un procedimiento almacenado.
            command.CommandType = System.Data.CommandType.StoredProcedure;

            // Define el nombre del procedimiento almacenado que se utilizará para la modificación de categorías.
            command.CommandText = "SPModificarCategoria";

            // Agrega parámetros al comando para representar los valores de la categoría a modificar.
            command.Parameters.AddWithValue("@Id", pCategoriaModificar.Id);
            command.Parameters.AddWithValue("@Nombre", pCategoriaModificar.Nombre);
            command.Parameters.AddWithValue("@Codigo", pCategoriaModificar.Codigo);
            command.Parameters.AddWithValue("@Descripcion", pCategoriaModificar.Descripcion);
            command.Parameters.AddWithValue("@FechaModificacion", pCategoriaModificar.FechaModificacion);

            // Ejecuta el comando a través del método EjecutarComando() de la clase ComunBD y devuelve el resultado.
            return ComunBD.EjecutarComando(command);

        }

        public int EliminarCategoria(CategoriaEN pCategoriaEliminar)
        {
            // Crea un nuevo comando SQL utilizando la conexión de la base de datos.
            SqlCommand command = ComunBD.ObtenerComando();

            // Establece el tipo de comando como una llamada a un procedimiento almacenado.
            command.CommandType = System.Data.CommandType.StoredProcedure;

            // Define el nombre del procedimiento almacenado que se utilizará para la eliminación de categorías.
            command.CommandText = "SPEliminarCategoria";

            // Agrega un parámetro al comando para representar el ID de la categoría a eliminar.
            command.Parameters.AddWithValue("@Id", pCategoriaEliminar.Id);

            // Ejecuta el comando a través del método EjecutarComando() de la clase ComunBD y devuelve el resultado.
            return ComunBD.EjecutarComando(command);

        }

        public List<CategoriaEN> ObtenerCategoria()
        {
            // Crea una nueva lista para almacenar objetos de categoría.
            List<CategoriaEN> listaCategoria = new List<CategoriaEN>();

            // Crea un nuevo comando SQL utilizando la conexión de la base de datos.
            SqlCommand command = ComunBD.ObtenerComando();

            // Establece el tipo de comando como una llamada a un procedimiento almacenado.
            command.CommandType = System.Data.CommandType.StoredProcedure;

            // Define el nombre del procedimiento almacenado que se utilizará para obtener las categorías.
            command.CommandText = "SPMostrarCategoria";

            // Ejecuta el comando y obtiene un lector de datos para leer los resultados.
            SqlDataReader reader = ComunBD.EjecutarComandoReader(command);

            // Itera a través del lector de datos para obtener los detalles de cada categoría.
            while (reader.Read())
            {
                // Crea una nueva instancia de la clase CategoriaEN para almacenar los datos de la categoría.
                CategoriaEN ObjCategoria = new CategoriaEN();

                // Asigna los valores de las columnas del lector de datos a las propiedades del objeto.
                ObjCategoria.Id = reader.GetInt32(0);
                ObjCategoria.Nombre = reader.GetString(1);
                ObjCategoria.Codigo = reader.GetString(2);
                ObjCategoria.Descripcion = reader.GetString(3);
                ObjCategoria.FechaCreacion = reader.GetDateTime(4);
                ObjCategoria.FechaModificacion = reader.GetDateTime(5);

                // Agrega el objeto CategoriaEN a la lista de categorías.
                listaCategoria.Add(ObjCategoria);
            }

            // Devuelve la lista de categorías.
            return listaCategoria;

        }

        public CategoriaEN ObtenerCategoriaPorId(int? pId)
        {
            // Crea un nuevo comando SQL utilizando la conexión de la base de datos.
            SqlCommand command = ComunBD.ObtenerComando();

            // Establece el tipo de comando como una llamada a un procedimiento almacenado.
            command.CommandType = System.Data.CommandType.StoredProcedure;

            // Define el nombre del procedimiento almacenado que se utilizará para obtener una categoría por su ID.
            command.CommandText = "SPObtenerCategoriaPorId";

            // Agrega un parámetro al comando con el valor del ID de categoría proporcionado.
            command.Parameters.AddWithValue("@Id", pId);

            // Ejecuta el comando y obtiene un lector de datos para leer los resultados.
            SqlDataReader reader = ComunBD.EjecutarComandoReader(command);

            // Crea una nueva instancia de la clase CategoriaEN para almacenar los datos de la categoría.
            CategoriaEN categoria = new CategoriaEN();

            // Si el lector de datos contiene al menos una fila, asigna los valores a las propiedades del objeto.
            if (reader.Read())
            {
                categoria.Id = reader.GetInt32(0);
                categoria.Nombre = reader.GetString(1);
                categoria.Codigo = reader.GetString(2);
                categoria.Descripcion = reader.GetString(3);
                categoria.FechaCreacion = reader.GetDateTime(4);
                categoria.FechaModificacion = reader.GetDateTime(5);
            }

            // Devuelve el objeto CategoriaEN con los valores leídos del lector de datos.
            return categoria;
        }

        public List<CategoriaEN> ObtenerCategoriasLike(string pNombre)
        {
            // Crea una nueva lista de objetos CategoriaEN para almacenar las categorías encontradas.
            List<CategoriaEN> listaCategoria = new List<CategoriaEN>();

            // Crea un nuevo comando SQL utilizando la conexión de la base de datos.
            SqlCommand command = ComunBD.ObtenerComando();

            // Establece el tipo de comando como una llamada a un procedimiento almacenado.
            command.CommandType = System.Data.CommandType.StoredProcedure;

            // Define el nombre del procedimiento almacenado que se utilizará para obtener categorías que coincidan con un nombre dado.
            command.CommandText = "SPObtenerCategoriasLike";

            // Agrega un parámetro al comando con el valor del nombre de categoría proporcionado.
            command.Parameters.AddWithValue("@Nombre", pNombre);

            // Ejecuta el comando y obtiene un lector de datos para leer los resultados.
            SqlDataReader reader = ComunBD.EjecutarComandoReader(command);

            // Lee los datos del lector de datos y crea objetos CategoriaEN con los valores correspondientes.
            while (reader.Read())
            {
                CategoriaEN ObjCategoria = new CategoriaEN();

                ObjCategoria.Id = reader.GetInt32(0);
                ObjCategoria.Nombre = reader.GetString(1);
                ObjCategoria.Codigo = reader.GetString(2);
                ObjCategoria.Descripcion = reader.GetString(3);
                ObjCategoria.FechaCreacion = reader.GetDateTime(4);
                ObjCategoria.FechaModificacion = reader.GetDateTime(5);

                // Agrega el objeto CategoriaEN a la lista de categorías llamada listaCategoria.
                listaCategoria.Add(ObjCategoria);
            }

            // Devuelve la lista de objetos CategoriaEN que coinciden con el nombre proporcionado.
            return listaCategoria;

        }
    }
}
