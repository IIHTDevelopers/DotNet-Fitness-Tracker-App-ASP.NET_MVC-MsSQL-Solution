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

        public async Task<int> DeleteWorkout(int workoutId)
        {
            var res= _repo.DeleteWorkout(workoutId);
            return res.Id;
        }

        public Task<Workout> GetWorkoutByID(int workoutId)
        {
            return _repo.GetWorkoutByID(workoutId);
        }
        public void Save()
        {
            _repo.Save();
        }


        Task<IEnumerable<Workout>> IFitnessTrackerInterface.GetWorkouts()
        {
            return (Task<IEnumerable<Workout>>)(IEnumerable<Workout>)_repo.GetWorkouts();
        }

        Task<Workout> IFitnessTrackerInterface.InsertWorkout(Workout workout)
        {
            return _repo.InsertWorkout(workout);
        }

        Task<bool> IFitnessTrackerInterface.UpdateWorkout(Workout workout)
        {
            return _repo.UpdateWorkout(workout);
        }
    }
}