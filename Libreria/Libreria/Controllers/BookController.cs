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

        public void DeleteCart(int bookedId)
        {
            DatabaseHelper.Database database = new DatabaseHelper.Database();

            database.DeleteCart(bookedId);
        }

        public void DeleteFavBook(int bookedId)
        {
            DatabaseHelper.Database database = new DatabaseHelper.Database();

            database.DeleteFavBook(bookedId);
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