using FitnessTrackerApp.DAL.Interface;
using FitnessTrackerApp.DAL.Repository;
using FitnessTrackerApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FitnessTrackerApp.Controllers
{
    public class FitnessTrackerController : Controller
    {
        private readonly IFitnessTrackerInterface _Repository;
        public FitnessTrackerController(IFitnessTrackerInterface service)
        {
            _Repository = service;
        }
        public FitnessTrackerController()
        {
            // Constructor logic, if needed
        }
        // GET: FitnessTracker
        public ActionResult Index()
        {
            var workouts = from work in (IEnumerable<Workout>)_Repository.GetWorkouts()
                        select work;
            return View(workouts);
        }

        public async Task<ViewResult> Details(int id)
        {
            Workout workout =  await _Repository.GetWorkoutByID(id);
            return View(workout);
        }

        public ActionResult Create()
        {
            return View(new Workout());
        }

        [HttpPost]
        public ActionResult Create(Workout workout)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _Repository.InsertWorkout(workout);
                    _Repository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(workout);
        }

        public async Task<ActionResult> EditAsync(int id)
        {
            Workout workout = await _Repository.GetWorkoutByID(id);
            return View(workout);
        }
        [HttpPost]
        public ActionResult Edit(Workout workout)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _Repository.UpdateWorkout(workout);
                    _Repository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(workout);
        }

        public async Task<ActionResult> Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
            }
            Workout workout = await _Repository.GetWorkoutByID(id);
            return View(workout);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                Workout workout = await _Repository.GetWorkoutByID(id);
                _Repository.DeleteWorkout(id);
                _Repository.Save();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete",
                   new System.Web.Routing.RouteValueDictionary {
        { "id", id },
        { "saveChangesError", true } });
            }
            return RedirectToAction("Index");
        }
    }
}