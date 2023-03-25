# TrelloTest
Sample Test Automation project in C#

Features API and UI testing from the same project.

Project uses RestSharp, Selenium, NUnit

Once cloned, and after setting the credentials in the App.config file, the solution can be run directly from Visual Studio 2022.

All dependencies installed from NuGet for easy management.

# A bit about the project

The Test functions are in UnitTest1.cs and in order, 4 functions are created:

Front End functions: are created using Selenium, the folder PageObjects contains the selectors and functions related to each page
1- TestUIInviteMemberToBoardViaEmail: this function will be able to check if the invitation of a member to a board via an Email is working correctly
Steps:
	1- User 1 authenticate
	2- Search for the board created
	3- Invite member via email
	4- User 2 authenticate
	5- Notification of invitation is checked

2- TestUIDeleteBoard: this function will be able to check the action delete board
Steps:
	1- User 1 authenticate
	2- Search for the board created
	3- Delete the board

BackEnd Function: RestSharp and NUnit are used, the folder DataEntities was created to be aple to map the response of the api into each class
1- TestAPIInviteMemberToBoardViaEmail: this function will be able to check if the api related to invite member via email is working fine
2- TestAPIDeleteBoard: this function will be able to check if the api related to delete a board is working fine


# Pre-Requisite
To have before running the functions

1- Create two test user account and add them in the App.config file

2- Add the apikey and token in the App.config

3- Create a board from user 1 account and add the name board to the key boardNameUI for the UI functions

4- Create a board from user 1 account and add the name board to the key boardNameAPI for the API functions

App.config should be filled in this way: 
	<appSettings>
		<add key="emailUser1" value="nhajallie@hotmail.com" />
		<add key="passwordUser1" value="NourH@j@llie123" />
		<add key="usernameUser1" value="nhajallie"/>
		<add key="emailUser2" value="nourhajallie2@gmail.com"/>
		<add key="passwordUser2" value="NourH@j@llie123" />
		<add key="key" value="0c2b5f557561a0b2fa52e2075bd5948a"/>
		<add key="token" value="ATTA25b95ab7f7b78f13f1c04102248ad5895c7b23764433d281ff07f75aa9522205A3503724"/>
		<add key="boardNameUI" value="TestBoard"/>
		<add key="boardNameAPI" value="TestBoard2"/>
	</appSettings>

# Credentials Cofiguration
This application uses Credentials Configuration to securely store sensitive information, such as usernames and passwords, separately from the application code.

To configure your credentials, open the App.config file and replace your_username_here and your_password_here with your actual credentials.

# Log4Net Configuration
This application uses log4net to log important information and errors. 

To configure the logging, you will need to modify the 'log4net.config' file, located in the root directory of the project.

The 'log4net.config' file contains the logging configuration settings. 

By default, the file is configured to log to a file named 'LogReport.txt' in the project's root directory.

To modify the logging configuration, you can modify the 'log4net.config' file directly. 

For example, you can change the logging level, the output location, or the formatting of the log messages.




