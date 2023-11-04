BackEnd-Commands
* On command prompt, cd into your project folder (cd <Your-Project-folder>).

* To connect SQL  server from terminal:
(FitnessTrackerApp /sqlcmd -S localhost -U sa -P pass@word1)
	-To create database from terminal - 
	1> Create Database FitnessTrackerDb
	2> Go

*	Steps to Apply Migration(Code first approach):
	- Press Ctrl+C to get back to command prompt
	- Run following command to apply migration-
             (FitnessTrackerApp  /dotnet-ef database update)


* To check whether migrations are applied from terminal:
(FitnessTrackerApp /sqlcmd -S localhost -U sa -P pass@word1)

	1> Use FitnessTrackerDb
	2> Go
	1> Select * From __EFMigrationsHistory
	2> Go

* To build your project use command:
	(FitnessTrackerApp /dotnet build)

* To launch your application, Run the following command to run the application:
	(FitnessTrackerApp /dotnet run)


* To test web-based applications on a browser, use the internal browser in the workspace. Click on the second last option on the left panel of IDE, you can find Browser Preview, where you can launch the application.
	Note: The application will not run in the local browser

* To run the test cases in CMD, Run the following command to test the application:
	(FitnessTrackerApp.Tests/dotnet test --logger "console;verbosity=detailed")
	(You can run this command multiple times to identify the test case status,and refactor code  to make maximum test cases passed before final submission)             
* You need to use CTRL+Shift+B - command compulsorily on code IDE, before final submission as well. This will push or save the updated contents in the internal git/repository, and will be used to evaluate the code quality.
