using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessTrackerApp.Models
{
    public class Workout
    {
        public int Id { get; set; }
        public string Exercise { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public DateTime Date { get; set; }
    }

}