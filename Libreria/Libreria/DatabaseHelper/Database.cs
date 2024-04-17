using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using Libreria.Models;

namespace Libreria.DatabaseHelper
{
    public class Database
    {
        const string database = "LibreriaInternacional";
        const string server = "NELA";
        SqlConnection connection = new SqlConnection($"Data Source={server};Initial Catalog={database};Integrated Security=True");

        public DataTable GetLibros()
        {
            return Fill("spGetLibros", null);
        }

        public bool ValidateUser(string email, string password)
        {
            bool isValid = false;

            try
            {
                List<SqlParameter> paramList = new List<SqlParameter>();
                paramList.Add(new SqlParameter("@Email", email));
                paramList.Add(new SqlParameter("@Password", password));

                DataTable result = Fill("spValidateUser", paramList);

                // Check if any rows were returned and if the flag IsValidUser is true
                isValid = result.Rows.Count > 0 && Convert.ToBoolean(result.Rows[0]["IsValidUser"]);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isValid;
        }

        public void SaveCompra(string email, string isbn, DateTime purchaseDate)
        {
            try
            {
                List<SqlParameter> paramList = new List<SqlParameter>();

                paramList.Add(new SqlParameter("@Email", email));
                paramList.Add(new SqlParameter("@ISBN", isbn));
                paramList.Add(new SqlParameter("@FechaCompra", purchaseDate));

                Execute("spSaveCompra", paramList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetCompra(string email)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@Email", email));
            return Fill("spGetCompra", paramList);
        }

        public DataTable GetLibros(string criteria)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();

            paramList.Add(new SqlParameter("@ISBN", criteria));
            paramList.Add(new SqlParameter("@nombreLibro", criteria));


            return Fill("spSearchBook", paramList);
        }

        public DataTable GetCart(string email)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();

            paramList.Add(new SqlParameter("@email", email));

            return Fill("spGetCart", paramList);
        }

        public void SaveBook(Libros libros)
        {
            try
            {
                List<SqlParameter> paramList = new List<SqlParameter>();

                paramList.Add(new SqlParameter("ISBN", libros.ISBN));
                paramList.Add(new SqlParameter("@nombreLibro", libros.nombreLibro));
                paramList.Add(new SqlParameter("@autorLibro", libros.autorLibro));
                paramList.Add(new SqlParameter("@precio", libros.precio));
                paramList.Add(new SqlParameter("@fechaPublicacion", libros.fechaPublicacion));
                paramList.Add(new SqlParameter("@rutaFoto", libros.rutaFoto));
                paramList.Add(new SqlParameter("@email", libros.email));

                Execute("spSaveBook", paramList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void InsertUserData(string nombreCompleto, string email, string pais, string provincia, string direccion, string codigoPostal, string password)
        {
            try
            {
                List<SqlParameter> paramList = new List<SqlParameter>();
                paramList.Add(new SqlParameter("@nombreCompleto", nombreCompleto));
                paramList.Add(new SqlParameter("@email", email));
                paramList.Add(new SqlParameter("@pais", pais));
                paramList.Add(new SqlParameter("@provincia", provincia));
                paramList.Add(new SqlParameter("@direccion", direccion));
                paramList.Add(new SqlParameter("@codigoPostal", codigoPostal));
                paramList.Add(new SqlParameter("@password", password));

                Execute("spInsertUserData", paramList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void FavBook(Libros libros)
        {
            try
            {
                List<SqlParameter> paramList = new List<SqlParameter>();

                paramList.Add(new SqlParameter("@ISBN", libros.ISBN));
                paramList.Add(new SqlParameter("@nombreLibro", libros.nombreLibro));
                paramList.Add(new SqlParameter("@autorLibro", libros.autorLibro));
                paramList.Add(new SqlParameter("@precio", libros.precio));
                paramList.Add(new SqlParameter("@fechaPublicacion", libros.fechaPublicacion));
                paramList.Add(new SqlParameter("@rutaFoto", libros.rutaFoto));
                paramList.Add(new SqlParameter("@email", libros.email));

                Execute("spFavBook", paramList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteCart(string isbn)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();

            paramList.Add(new SqlParameter("@ISBN", isbn));

            Execute("spDeleteCart", paramList);
        }

        public void DeleteFavBook(int isbn)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();

            paramList.Add(new SqlParameter("@ISBN", isbn));

            Execute("spDeleteFavBook", paramList);
        }



        public DataTable Fill(string storedProcedure, List<SqlParameter> paramList)
        {
            //control de errores
            try
            {
                //usamos la conexion
                using (this.connection)
                {
                    //abra la conexion a la base de datos
                    connection.Open();
                    //creamos un comando de base de datos
                    SqlCommand cmd = connection.CreateCommand();
                    //el comando es de tipo store procedure
                    cmd.CommandType = CommandType.StoredProcedure;
                    //le damos el noombre del store procedure
                    cmd.CommandText = storedProcedure;

                    if (paramList != null)
                    {
                        foreach (SqlParameter param in paramList)
                        {
                            cmd.Parameters.Add(param);
                        }
                    }

                    //creamos el objeto que almacena los datos
                    DataTable ds = new DataTable();
                    //el adaptador ejecuta el comando a la base de datos
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    //llena el objeto con los datos que devolvio el adapter
                    adapter.Fill(ds);
                    //retornamos el objeto lleno de datos
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Execute(string storedProcedure, List<SqlParameter> paramList)
        {
            //control de errores
            try
            {
                //usamos la conexion
                using (this.connection)
                {
                    //abra la conexion a la base de datos
                    connection.Open();
                    //creamos un comando de base de datos
                    SqlCommand cmd = connection.CreateCommand();
                    //el comando es de tipo store procedure
                    cmd.CommandType = CommandType.StoredProcedure;
                    //le damos el noombre del store procedure
                    cmd.CommandText = storedProcedure;

                    if (paramList != null)
                    {
                        foreach (SqlParameter param in paramList)
                        {
                            cmd.Parameters.Add(param);
                        }
                    }

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}