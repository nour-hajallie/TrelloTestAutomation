# Trello Project

The aim of this project is to implement automation testing on the Trello website with the objective of validating two key scenarios: inviting a member to a board via email and deleting a board

The repository include functions that can simulate user actions on the Trello website and verify that the expected results are achieved.

In addition to testing the scenarios on the frontend of the Trello website, this project will also involve testing the same scenarios on the backend using the Trello API.

In other words, both scenarios were tested from the UI and from the API directly.

# Technologies and Languages

Sample Test Automation project written in C#

Project uses RestSharp and NUnit for the API functions and Selenium for the UI functions of Trello application

Visual Studio 2022 was used to run locally the project/tests and Jenkins was used to create the pipeline.

All dependencies installed from NuGet for easy management.

# Directories and Files

The project contains 

	- BackendAPI directory: this directory contains the class that returns the responses of the APIs.

	- Config directory: this directory contains the environment config class and the log4net config file.

	- DataEntities directory:  this directory contains the classes to map the response of the api used in the backend functions.
	
	- PageObjects directory: in this directory you will find the classes containing the selectors and functions related to each page used 
	
	in the front end functions.

	- App.config file storing the sensitive information.

	- UnitTest1.cs: class where the Test functions are created, 2 functions for the frontend features and 2 for the backend features.

	- Jenkinsfile: this file includes the Pipeline that defines a series of steps that are executed in a specific order to automate a software development process. In our case, 3 steps will be executed: CheckOut, Test and Retrieve logs.

## Credentials Cofiguration

This application uses Credentials Configuration to securely store sensitive information, such as usernames and passwords, separately from the application code.

To configure your credentials, open the App.config file and replace your_username_here and your_password_here with your actual credentials.

## Log4Net Configuration

This application uses log4net to log important information and errors. 

To configure the logging, you will need to modify the 'log4net.config' file, located in the root directory of the project.

The 'log4net.config' file contains the logging configuration settings. 

By default, the file is configured to log to a file named 'LogReport_yyyyMMdd.txt' in the directory 'bin\Debug\net6.0\Logs\LogReport.logLogs'.

To modify the logging configuration, you can modify the 'log4net.config' file directly. 

For example, you can change the logging level, the output location, or the formatting of the log messages.


# Pre-Requisite

Below are the requirements or conditions that need to be met before the testing can be carried out:

1- Create two test users for our project on [Trello](https://www.trello.com).

2- Create a board named "TestBoard" from user 1 account.

3- Create a board named "TestBoard2" from user 1 account. 

4- Generate api key and token for the trello api.

5- Fill the emails and passwords created in step 1 (you need also the username), the board name UI created in step 2, the board name API created in step 3, in addition to the api key and token created in the step 4 IN the App.config

App.config should be filled in this way: 

```
	<appSettings>
		<add key="emailUser1" value="email_user1@hotmail.com" />
		<add key="passwordUser1" value="pass_user_1" />
		<add key="usernameUser1" value="username-user1"/>
		<add key="emailUser2" value="email_user2@hotmail.com"/>
		<add key="passwordUser2" value="pass_user_2" />
		<add key="key" value="the32hexcharsapikeyyougotfromtrelloapi"/>
		<add key="token" value="the64hexcharstoken"/>
		<add key="boardNameUI" value="TestBoard"/>
		<add key="boardNameAPI" value="TestBoard2"/>
	</appSettings>
```

# Installation
1.	Clone the repository: 

```
git clone https://github.com/nour-hajallie/TrelloTestAutomation.git
```

2.	Open the solution file TrelloTestAutomation.sln in Visual Studio.

3.	Install the NuGet packages by selecting from the "Manage NuGet Packages".

4. Build the solution by selecting "Build Solution" from the "Build" menu or pressing Ctrl+Shift+B.

## Running the project Locally

The project was designed to run in a headless mode (headless browser), so the below steps can be executed to run the project locally and in a normal mode ( You will be able to see the browser executing the test):

1. In UnitTest1.cs make sure to **remove the comment** from lines 47 
```
//driver = new ChromeDriver();
```

and 115 (lines related to Test with Browser) 

```
//driver = new ChromeDriver();
```

2. In UnitTest1.cs make sure to **comment** lines 50-51-52 

```
var chromeOptions = new ChromeOptions();
chromeOptions.AddArgument("--headless");
driver = new ChromeDriver(chromeOptions);
```


and lines 118-119-120 (lines related to Test without Browser (headless))

```
var chromeOptions = new ChromeOptions();
chromeOptions.AddArgument("--headless");
driver = new ChromeDriver(chromeOptions);
```

3. Open the Test Explorer by selecting "Test Explorer" from the "Test" menu.

4. Run the tests by selecting "Run All" in the Test Explorer or by pressing Ctrl+R, A.

## Running the Jenkins Pipeline

To run the Jenkins pipeline, follow these steps:

1. Install Jenkins on your local machine or any server on the cloud.

	1.1. Make sure to install the needed plugins for this project in Jenkins

		- Git

		- ChromeDriver

		- DotNet SDK Support

2. Create a new Jenkins job and select "Pipeline" as the job type.

	2.1. Configure the project/pipeline created by clicking on "Configure".

	2.2. Under Build Triggers section, select "GitHub hook trigger for GITScm polling".

	2.3. Under Pipeline section, fill the below:

		- Definition:pipeline script from scm 
		
		- SCM: Git 
		
		- repository url: you_repo_url 

		- Branch Specifier: main 

		- Script Path: Jenkinfile (that the name of the file we have in our repo)

	2.4. Apply and Save the configuration.

3. Establish a connection between Github and Jenkins (using [Webhook](https://www.cprime.com/resources/blog/how-to-integrate-jenkins-github/)).
	
		- The Jenkins pipeline will be reading the Jenkins file from this repo to run the stages or in case any push was done to the repo, the pipeline will be running automatically.

4. Save the job configuration and click on "Build Now" to run the pipeline.

Picture showing Pipeline running without and with errors: [PipelineRun](pipelinePicture.png)