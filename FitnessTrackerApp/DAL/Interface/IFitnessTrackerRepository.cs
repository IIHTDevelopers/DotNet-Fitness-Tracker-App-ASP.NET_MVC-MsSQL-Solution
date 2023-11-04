
using FitnessTrackerApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTrackerApp.DAL.Interface
{
    public interface IFitnessTrackerRepository
    {
        Task<IEnumerable<Workout>> GetWorkouts();
        Task<Workout> GetWorkoutByID(int workoutId);
        Task<Workout> InsertWorkout(Workout workout);
        Task<int> DeleteWorkout(int workoutId);
        Task<bool> UpdateWorkout(Workout workout);
        void Save();
    }
}