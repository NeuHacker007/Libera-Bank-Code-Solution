This Project is used for Libra Code Challenge

Here are some basic assumptions 
  - Assume that the storage of till is all in memory
  - Assume that till cannot hold one type of coin multiple times. 
	
	eg.  we cannot have the following two coins within one till object
	  
	```
		  new Coin() {CoinType = CoinType.Quarter, NumOfCoin = 1},
		  new Coin() {CoinType = CoinType.Quarter, NumOfCoin = 5},
	```
  - Assume that the max num of each coin in the till is no more than 255
	
	By given this assumption, the num of coin property in the Coin model class is declared as bytes type
	which save some memory. This also enforced by data annotation to validate the input. 
   
Enviornment 
	
  - code is based on .NET Core 3.1, so please make sure the .net core 3.1 runtime is properly installed.
  - code is developed on Visual Studio 2019 Comminity version 
 

Run instruction

	- Download the zip file and extracted
	- Open the solution file in VS 2019, click run button in the ribbon area. once project is started
	  the default page is http://localhost:5000/api/pos/GetValues which gives the getValues result
		
		**Note: 
			- the port may differ from different machine
			- the url pattern is /api/pos/{action}/{parameter}. Not all action takes parameter.
		** 
	  or 
		use dotnet cli to run this project by
		 - navigate to solution folder
		  - open terminal 
		  - run command "dotnet run"
		**
			Note: 
				- this way it will not open browser
				- instead it will have an pop up window indicating that the project is running
		**
Test instructions

	- install latest postman if you don't have
	- import my postman collection settings which already have couple of simple test settings
	- we can inspect the result from postman it will return JSON and take JSON as parameter from request body
	**
		- As the time limit, I didn't complete the unit test within our solution. So, it currently only
		  support postman test
		- Due to lacking of unit test, so some edge cased need to be tested manually
			eg. the till object is null, it suppose to return server error 500. 
			if we want to make the till object null, we need to modify the startup.cs
		  line 28 - 35. 
	**