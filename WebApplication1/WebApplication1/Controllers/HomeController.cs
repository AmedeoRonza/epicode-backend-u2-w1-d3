using WebApplication1.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDb"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            List<Scarpe> Scarpe = new List<Scarpe>();

            try
            {
                conn.Open();
                string query = "SELECT * FROM Scarpe WHERE Visible = 1";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Scarpe scarpa = new Scarpe();
                    scarpa.IdProdotto = Convert.ToInt32(reader["IdProdotto"]);
                    scarpa.NomeProdotto = reader["NomeProdotto"].ToString();
                    scarpa.Prezzo = Convert.ToDecimal(reader["Prezzo"]);
                    scarpa.Descrizione = reader["Descrizione"].ToString();
                    scarpa.img1 = reader["img1"].ToString();
                    scarpa.img2 = reader["img2"].ToString();
                    scarpa.img3 = reader["img3"].ToString();
                    scarpa.Visible = Convert.ToBoolean(reader["Visible"]);
                    Scarpe.Add(scarpa);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return View(Scarpe);
        }


        public ActionResult DettaglioProdotto(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            string connectionString = ConfigurationManager.ConnectionStrings["MyDb"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            Scarpe scarpe = new Scarpe();

            try
            {
                conn.Open();
                string query = "SELECT * FROM Scarpe WHERE IdProdotto = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    scarpe.IdProdotto = Convert.ToInt32(reader["IdProdotto"]);
                    scarpe.NomeProdotto = reader["NomeProdotto"].ToString();
                    scarpe.Prezzo = Convert.ToDecimal(reader["Prezzo"]);
                    scarpe.Descrizione = reader["Descrizione"].ToString();
                    scarpe.img1 = reader["img1"].ToString();
                    scarpe.img2 = reader["img2"].ToString();
                    scarpe.img3 = reader["img3"].ToString();
                    scarpe.Visible = Convert.ToBoolean(reader["Visible"]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return View(scarpe);
        }

        public ActionResult DeleteProduct(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDb"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                string query = "UPDATE Scarpe SET Visible = 0 WHERE IdProdotto = " + id;
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}