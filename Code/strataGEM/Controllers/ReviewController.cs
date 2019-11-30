using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using strataGEM.Models;
using Microsoft.AspNet.Identity;

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
            return View();
        }
        // POST: Review/Create
        [HttpPost]
        public ActionResult Crear(Review Tempo)
        {
            try
            {
                Tempo.Review_IdUser = User.Identity.GetUserId();
                Tempo.Review_UserName = User.Identity.GetUserName();
                // TODO: Add insert logic here
                Clases.BD.AgregarReview(Tempo.Review_IdGame, Tempo.Review_Rating, Tempo.Review_IdUser, Tempo.Review_Description, Tempo.Review_UserName);
                return RedirectToAction("Index");
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
                return RedirectToAction("IndexRev", new { id = collection.Review_IdGame});
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
