using FitnessTrackerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTrackerApp.DAL.Interface
{
    public interface IFitnessTrackerInterface 
    {
        IEnumerable<Workout> GetWorkouts();
        Workout GetWorkoutByID(int workoutId);
        Workout InsertWorkout(Workout workout);
        int DeleteWorkout(int workoutId);
        bool UpdateWorkout(Workout workout);
        void Save();
    }
}