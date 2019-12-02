using Microsoft.AspNet.Identity;
using strataGEM.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace strataGEM.Controllers
{
    public class ReviewController : Controller
    {
        // GET: Review
        public ActionResult IndexRev(int id)
        {
            List<Review> LReviews = Clases.BD.TraerReseñasXJuego(id);
            Game juego = Clases.BD.TraerJuego(LReviews[0].Review_IdGame);
            ViewBag.Juego = juego;
            return View(LReviews);
        }

        // GET: Review/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Review/Create
        public ActionResult Crear(int id)
        {
            Game juego = Clases.BD.TraerJuego(id);
            ViewBag.Juego = juego;

            var b = User.Identity.GetUserId();
            var c = User.Identity.GetUserName();

            Review BB = new Review(juego.Game_Id, b, c);
            return View(BB);
        }

        // POST: Review/Create
        [HttpPost]
        public ActionResult Crear(Review Tempo)
        {
            try
            {
                // TODO: Add insert logic here
                Clases.BD.AgregarReview(Tempo.Review_IdGame, Tempo.Review_Rating, Tempo.Review_Description, Tempo.Review_IdUser, Tempo.Review_UserName);
                return RedirectToAction("IndexRev", new { id = Tempo.Review_IdGame });
            }
            catch
            {
                return View();
            }
        }

        // GET: Review/Edit/5
        public ActionResult Edit(int id)
        {
            Review BB = Clases.BD.TraerReview(id);
            return View(BB);
        }

        // POST: Review/Edit/5
        [HttpPost]
        public ActionResult Edit(Review collection)
        {
            Review aaa = collection;
            try
            {
                // TODO: Add update logic here
                Clases.BD.UpdateReview(collection.Review_Id, collection.Review_Rating, collection.Review_Description);
                return RedirectToAction("IndexRev", new { id = collection.Review_IdGame });
            }
            catch
            {
                return View();
            }
        }

        // GET: Review/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Review/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}