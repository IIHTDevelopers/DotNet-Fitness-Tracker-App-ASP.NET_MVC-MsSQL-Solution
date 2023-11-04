using FitnessTrackerApp.DAL.Interface;
using FitnessTrackerApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace FitnessTrackerApp.DAL.Repository
{
    public class FitnessTrackerRepository : IFitnessTrackerRepository
    {
        private FitnessTrackerDbContext _context;
        public FitnessTrackerRepository(FitnessTrackerDbContext Context)
        {
            this._context = Context;
        }
        public async Task<IEnumerable<Workout>> GetWorkouts()
        {
             return _context.Workouts.ToList();
        }
        public async Task<Workout> GetWorkoutByID(int id)
        {
            return _context.Workouts.Find(id);
        }
        public async Task<Workout> InsertWorkout(Workout workout)
        {
            return _context.Workouts.Add(workout);
        }
        public async Task<int> DeleteWorkout(int workoutID)
        {
            Workout workout = _context.Workouts.Find(workoutID);
            var res= _context.Workouts.Remove(workout);
            return res.Id;
        }
        public async Task<bool> UpdateWorkout(Workout workout)
        {
            var res= _context.Entry(workout).State = EntityState.Modified;
            return res.Equals("workout");
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
