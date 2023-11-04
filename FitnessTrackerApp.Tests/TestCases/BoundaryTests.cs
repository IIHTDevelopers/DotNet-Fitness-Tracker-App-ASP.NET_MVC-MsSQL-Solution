
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
    public class BoundaryTests
    {
        private readonly ITestOutputHelper _output;
        public readonly Mock<IFitnessTrackerInterface> fitnesstrackerinterface = new Mock<IFitnessTrackerInterface>();
        private readonly FitnessTrackerRepository repository;
        private readonly IFitnessTrackerInterface _Repository;
        private readonly Workout _workout;

        private static string type = "Boundary";

        public BoundaryTests(ITestOutputHelper output)
        {
            _output = output;
            _workout = new Workout
            {
                Id=1,
                Date=DateTime.Now,
                Exercise="Exercise",
                Reps=10,
                Sets=10
            };
        }

        [Fact]
        public async Task<bool> Testfor_Exercise_NotNull()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            int id = 1;

            //Action
            try
            {
                var workout = new Workout { Id = 1, Exercise = "Workout 1" };
                _Repository.InsertWorkout(workout);

                // Act
                workout.Exercise = "Updated Workout";
                repository.UpdateWorkout(workout);
                repository.Save();

                // Assert
                var updatedWorkout = await repository.GetWorkoutByID(1);


                //Assertion
                if (updatedWorkout.Exercise == null)
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
        public async Task<bool> Testfor_Set_NotNull()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            int id = 1;

            //Action
            try
            {
                var workout = new Workout { Id = 1, Exercise = "Workout 1" };
             

                // Act
                workout.Exercise = "Updated Workout";
                repository.DeleteWorkout(1);
                repository.Save();

                // Assert
                var updatedWorkout = await repository.GetWorkoutByID(1);

                //Assertion
                if (updatedWorkout.Sets == null)
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
        public async Task<bool> Testfor_Reps_NotNull()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            int id = 1;

            //Action
            try
            {
                var workout = new Workout { Id = 1, Exercise = "Workout 1" };
                

                // Act
                workout.Exercise = "Updated Workout";
                repository.DeleteWorkout(1);
                repository.Save();

                // Assert
                var updatedWorkout = await repository.GetWorkoutByID(1);

                //Assertion
                if (updatedWorkout.Reps == null)
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
        public async Task<bool> Testfor_Date_NotNull()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            int id = 1;

            //Action
            try
            {
                var workout = new Workout { Id = 1, Exercise = "Workout 1" };
             

                // Act
                workout.Exercise = "Updated Workout";
                repository.DeleteWorkout(1);
                repository.Save();

                // Assert
                var updatedWorkout = await repository.GetWorkoutByID(1);

                //Assertion
                if (updatedWorkout.Date == null)
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