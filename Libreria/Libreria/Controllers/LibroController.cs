using Libreria.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Libreria.Controllers
{
    public class LibroController
    {
        public List<Libros> GetLibros(string criteria)
        {
            List<Libros> listaLibros = new List<Libros>();
            DataTable dsLibros;

            DatabaseHelper.Database database = new DatabaseHelper.Database();

            if (criteria == string.Empty)
            {
                dsLibros = database.GetLibros();
            }
            else
            {
                dsLibros = database.GetLibros(criteria);
            }

            foreach (DataRow dr in dsLibros.Rows)
            {
                listaLibros.Add(new Libros
                {
                    ISBN = dr["ISBN"].ToString(),
                    nombreLibro = dr["nombreLibro"].ToString(),
                    autorLibro = dr["autorLibro"].ToString(),
                    precio = Convert.ToDecimal(dr["precio"]),
                    rutaFoto = dr["rutaFoto"].ToString()
                });
            }

            return listaLibros;
        }

        public List<Libros> GetLibro(string ISBN)
        {
            List<Libros> listaLibros = GetLibros(string.Empty);

            foreach (Libros libros in listaLibros)
            {
                if (libros.ISBN == ISBN)
                {
                    listaLibros.Clear();
                    listaLibros.Add(libros);
                    return listaLibros;
                }
            }

            return null;
        }
    }
}