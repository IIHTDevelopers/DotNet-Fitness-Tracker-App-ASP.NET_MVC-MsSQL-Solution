using FitnessTrackerApp.DAL.Interface;
using FitnessTrackerApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessTrackerApp.DAL.Repository
{
    public class FitnessTrackerService : IFitnessTrackerInterface
    {
        private IFitnessTrackerRepository _repo;
        public FitnessTrackerService(IFitnessTrackerRepository repo)
        {
            this._repo = repo;
        }

        public int DeleteWorkout(int workoutId)
        {
            var res= _repo.DeleteWorkout(workoutId);
            return res;
        }

        public Workout GetWorkoutByID(int workoutId)
        {
            return _repo.GetWorkoutByID(workoutId);
        }
        public void Save()
        {
            _repo.Save();
        }


        IEnumerable<Workout> IFitnessTrackerInterface.GetWorkouts()
        {
            return _repo.GetWorkouts();
        }

        Workout IFitnessTrackerInterface.InsertWorkout(Workout workout)
        {
            return _repo.InsertWorkout(workout);
        }

        bool IFitnessTrackerInterface.UpdateWorkout(Workout workout)
        {
            return _repo.UpdateWorkout(workout);
        }
    }
}