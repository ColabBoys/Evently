using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Evently.Models;
using Evently.ViewModels;
using Microsoft.AspNet.Identity;

namespace Evently.Controllers
{
    public class EventsController : Controller
    {
        private ApplicationDbContext _context;

        public EventsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Events
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ViewResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new EventsFormViewModel
            {
                Genres = genres
            };
            
            return View("EventForm", viewModel);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var events = _context.Events.SingleOrDefault(c => c.Id == id);

            if (events == null)
                return HttpNotFound();

            var viewModel = new EventsFormViewModel(events)
            {
                //Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("EventForm", viewModel);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Events.SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }
        [Authorize]
        public ActionResult Save(Event events)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new EventsFormViewModel
                {
                    Genres = _context.Genres.ToList()
                };

                return View("EventForm", viewModel);
            }

            if (events.Id == 0)
            {
                string currentUserId = User.Identity.GetUserId();
                ApplicationUser currentUser = _context.Users.FirstOrDefault(x => x.Id == currentUserId);

                events.DateAdded = DateTime.Now;
                events.OwnerId = currentUserId; //User.Identity.GetUserId();
                _context.Events.Add(events);
            }
            else
            {
                var eventInDb = _context.Events.Single(m => m.Id == events.Id);
                eventInDb.GenreId = events.GenreId;
                // doesnt apply for edit movieInDb.DateAdded = movie.DateAdded;
                eventInDb.Name = events.Name;
            }

            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }

            return RedirectToAction("Index", "Events");
        }
    }
}