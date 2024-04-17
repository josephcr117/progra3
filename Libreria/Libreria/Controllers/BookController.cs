using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Libreria.Models;

namespace Libreria.Controllers
{
    public class BookController
    {
        public void SaveCompra(string email, string isbn, DateTime purchaseDate)
        {
            try
            {
                DatabaseHelper.Database database = new DatabaseHelper.Database();
                database.SaveCompra(email, isbn, purchaseDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveBook(Libros libros)
        {
            try
            {
                DatabaseHelper.Database database = new DatabaseHelper.Database();

                database.SaveBook(libros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void FavBook(Libros booked)
        {
            try
            {
                DatabaseHelper.Database database = new DatabaseHelper.Database();

                database.FavBook(booked);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteCart(string isbn)
        {
            DatabaseHelper.Database database = new DatabaseHelper.Database();

            database.DeleteCart(isbn);
        }

        public void DeleteFavBook(int isbn)
        {
            DatabaseHelper.Database database = new DatabaseHelper.Database();

            database.DeleteFavBook(isbn);
        }

        public List<Compra> GetCompra(string email)
        {
            List<Compra> compraList = new List<Compra>();

            try
            {
                DatabaseHelper.Database database = new DatabaseHelper.Database();
                // Call the stored procedure to retrieve the user's purchase history
                DataTable dtCompra = database.GetCompra(email);

                // Map the data from DataTable to List<Compra>
                foreach (DataRow dr in dtCompra.Rows)
                {
                    Compra compra = new Compra
                    {
                        idCompra = Convert.ToInt32(dr["idCompra"]),
                        email = dr["email"].ToString(),
                        ISBN = dr["ISBN"].ToString(),
                        fechaCompra = Convert.ToDateTime(dr["fechaCompra"]),
                        nombreLibro = dr["nombreLibro"].ToString()
                    };
                    compraList.Add(compra);
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                throw ex;
            }

            return compraList;
        }

        public List<Libros> GetCart(string email)
        {
            List<Libros> bookList = new List<Libros>();

            DatabaseHelper.Database database = new DatabaseHelper.Database();

            DataTable dsBooked = database.GetCart(email);

            foreach (DataRow dr in dsBooked.Rows)
            {
                bookList.Add(new Libros
                {
                    ISBN = dr["ISBN"].ToString(),
                    nombreLibro = dr["nombreLibro"].ToString(),
                    rutaFoto = dr["rutaFoto"].ToString(),
                    fechaPublicacion = Convert.ToDateTime(dr["fechaPublicacion"]).ToShortDateString(),
                    precio = Convert.ToDecimal(dr["precio"])
                });
            }

            return bookList;
        }
    }
}