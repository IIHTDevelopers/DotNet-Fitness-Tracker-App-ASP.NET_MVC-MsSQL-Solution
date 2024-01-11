
using FitnessTrackerApp.DAL;
using FitnessTrackerApp.DAL.Interface;
using FitnessTrackerApp.DAL.Repository;
using FitnessTrackerApp.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace FitnessTrackerApp.Tests.TestCases
{
    public class ExceptionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly IFitnessTrackerInterface _fitnessTrackerService;
        public readonly Mock<IFitnessTrackerRepository> fitnnesstrackerservice = new Mock<IFitnessTrackerRepository>();
        private readonly Workout _workout;
        private readonly IEnumerable<Workout> workoutList;

        private static string type = "Exception";

        public ExceptionalTests(ITestOutputHelper output)
        {
            _fitnessTrackerService = new FitnessTrackerService(fitnnesstrackerservice.Object);
            _output = output;
            _workout = new Workout
            {
                Id = 1,
                Date = DateTime.Now,
                Exercise = "Exercise",
                Reps = 10,
                Sets = 10
            };
            workoutList = new List<Workout>
        {
            new Workout
            {
                Id = 1,
                Date = DateTime.Now,
                Exercise = "Exercise",
                Reps = 10,
                Sets = 10
            },
            new Workout
            {
                Id = 2,
                Date = DateTime.Now.AddDays(-1), // Example: One day ago
                Exercise = "Exercise 2",
                Reps = 15,
                Sets = 8
            },
            // Add more Workout instances as needed
        };

        }

        [Fact]
        public async Task<bool> Testfor_Get_Workout_ById_NotNull()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            int id = 1;

            //Action
            try
            {
                fitnnesstrackerservice.Setup(repos => repos.GetWorkoutByID(_workout.Id)).Returns(_workout);
                var result = _fitnessTrackerService.GetWorkoutByID(_workout.Id);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> Testfor_Update_Workout_NotNull()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            int id = 1;

            //Action
            try
            {
                fitnnesstrackerservice.Setup(repos => repos.UpdateWorkout(_workout)).Returns(true);
                var result = _fitnessTrackerService.UpdateWorkout(_workout);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }


    }
}