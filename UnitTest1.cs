using OpenQA.Selenium.DevTools;
using TrelloTest.PageObjects;
using TrelloTest;
using log4net.Config;
using log4net;
using OpenQA.Selenium;
using System.Configuration;
using RestSharp;
using System.Net;
using System;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using TrelloTestAutomation.DataEntities;
using TrelloTestAutomation.BackendAPI;
using System.Collections.Immutable;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Firefox;

namespace TrelloTestAutomation
{
    public class Tests
    {

        IWebDriver driver;
        EnvironmentConfig environmentConfig;
        // Create a logger instance for the test class
        ILog log = LogManager.GetLogger(typeof(Tests));

        //Varibles that will be stored from App.config
        string emailUser1;
        string passwordUser1;
        string emailUser2;
        string passwordUser2;
        string apiKey;
        string token;
        string username;
        string boardNameUI;
        string boardNameAPI;

        [SetUp]
        public void Setup()
        {
            //Create reference for the browser
           // driver = new ChromeDriver();
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--headless");
            driver = new ChromeDriver(chromeOptions);

            environmentConfig = new EnvironmentConfig();

            //Values reading from App.config file
            var configFileMap = new ExeConfigurationFileMap { ExeConfigFilename = "../../../App.config" };
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);

            emailUser1 = config.AppSettings.Settings["emailUser1"].Value;
            passwordUser1 = config.AppSettings.Settings["passwordUser1"].Value;
            emailUser2 = config.AppSettings.Settings["emailUser2"].Value;
            passwordUser2 = config.AppSettings.Settings["passwordUser2"].Value;
            apiKey = config.AppSettings.Settings["key"].Value;
            token = config.AppSettings.Settings["token"].Value;
            username = config.AppSettings.Settings["usernameUser1"].Value;
            boardNameUI = config.AppSettings.Settings["boardNameUI"].Value;
            boardNameAPI = config.AppSettings.Settings["boardNameAPI"].Value;

            // Load the Log4Net configuration file
            log4net.Util.LogLog.InternalDebugging = true;
            XmlConfigurator.Configure(new FileInfo("../../../Config/log4net.config"));
        }

        [Test, Order(1)]
        public void TestUIInviteMemberToBoardViaEmail()
        {
            log.Info("Testing UI function TestUIInviteMemberToBoardViaEmail Started");

            String trollyLoginUrl = environmentConfig.getTrollyLoginURL();
            driver.Navigate().GoToUrl(trollyLoginUrl);

            log.Debug("Authenticate with User 1: " + emailUser1);
            LoginPage loginPage = new LoginPage(driver);
            loginPage.setEmailField(emailUser1);
            loginPage.clickContinueLoginButton();
            loginPage.setPasswordField(passwordUser1);
            BoardsPage boardsPage = loginPage.clickLoginButton();


            BoardsPage boardPage = new BoardsPage(driver);
            log.Debug("Check if Board: " + boardNameUI + " is available");
            if (boardPage.isBoardAvailable(boardNameUI))
            {
                log.Debug("Click on the Board Created: "+ boardNameUI);
                boardPage.clickOnBoard();

                log.Debug("Click on Share button to invite User 2: " + emailUser2);
                TestBoardPage testBoardPage = new TestBoardPage(driver);
                testBoardPage.clickOnShareButton();

                log.Debug("Invite user 2 " + emailUser2 + " to join the board");
                testBoardPage.inviteUserToBoard(emailUser2);

                log.Debug("Check if user 2 is invited");
                if (testBoardPage.IsUser2Available(driver))
                {
                    log.Debug("User 2: " + emailUser2 + " is invited to joint the board");
                    Assert.IsTrue(true, "User 2: " + emailUser2 + " is invited to join the board");

                    //Close the browser to authenticate with user 2 and check the invite
                    driver.Quit();
                    //driver = new OpenQA.Selenium.Chrome.ChromeDriver();
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("--headless");
                    driver = new ChromeDriver(chromeOptions);

                    driver.Navigate().GoToUrl(trollyLoginUrl);

                    log.Debug("Authenticate with User 2: " + emailUser2);
                    loginPage = new LoginPage(driver);
                    loginPage.setEmailField(emailUser2);
                    loginPage.clickContinueLoginButton();
                    loginPage.setPasswordField(passwordUser2);
                    boardsPage = loginPage.clickLoginButton();

                    //click on notification button
                    log.Debug("Click on Notification button");
                    boardPage.clickOnNotificationButton(driver);

                    //Check if the notification is displayed
                    log.Debug("Check if the notification is displayed");
                    Assert.IsTrue(boardPage.isNotificationDisplayed(driver));

                    //Check if the notification content is correct
                    Assert.IsTrue(boardPage.isContentNotificationDisplayed(driver, boardNameUI));
                    log.Debug("Notification Content is displayed: Added you to the board " + boardNameUI + " a few seconds ago");
                }
                else
                {
                    log.Error("Something went wrong: User 2 " + emailUser2 + " has not been invited to joint the board");
                    Assert.Fail("Something went wrong: User 2 " + emailUser2 + " has not been invited to joint the board");
                }
            }
            else
            {
                log.Error("Board with " + boardNameUI + " name is not found");
                Assert.Fail("Board with " + boardNameUI + " name is not found");
            }

        }

        [Test, Order(2)]
        public void TestUIDeleteBoard()
        {
            log.Info("Testing function TestUIDeleteBoard Started");

            String trollyLoginUrl = environmentConfig.getTrollyLoginURL();
            driver.Navigate().GoToUrl(trollyLoginUrl);

            log.Debug("Authenticate with User 1: " + emailUser1);
            LoginPage loginPage = new LoginPage(driver);
            loginPage.setEmailField(emailUser1);
            loginPage.clickContinueLoginButton();
            loginPage.setPasswordField(passwordUser1);
            BoardsPage boardsPage = loginPage.clickLoginButton();

            BoardsPage boardPage = new BoardsPage(driver);
            log.Debug("Check if Board: "+ boardNameUI + " is available");
            if (boardPage.isBoardAvailable(boardNameUI))
            {
                log.Debug("Click on the Board Created: "+ boardNameUI);
                boardPage.clickOnBoard();

                log.Debug("Click on 3 dots to close the board");
                TestBoardPage testBoardPage = new TestBoardPage(driver);
                testBoardPage.clickOndotsButton();
                testBoardPage.clickOnCloseBoardButton();

                log.Debug("Check if board is closed successfully");
                Assert.IsTrue(testBoardPage.IsClosedBoardSuccessMessageAvailable(driver), "Board Closed Success Message is not displayed");

                log.Debug("Board is closed successfully");
                log.Debug("Delete the board");
                boardPage = testBoardPage.clickOnDeleteButton();
                log.Debug("Board Deleted successfully");
            }
            else
            {
                log.Error("Board with "+ boardNameUI + " name is not found");
                Assert.Fail("Board with "+ boardNameUI + " name is not found");
            }
            driver.Quit();
        }

        [Test, Order(3)]
        public void TestAPIInviteMemberToBoardViaEmail()
        {
            log.Info("Testing API function TestAPIInviteMemberToBoardViaEmail Started");

            TrelloApi trelloApi = new TrelloApi();

            //Get board id based on member
            log.Info("Call Get Boards by member api to store the board id");
            List<Board> getBoardByMember = trelloApi.GetBoardsByMember(username, apiKey, token); 

            //filter the list of boards by name and retrieve the ID of the matching board
            Board board = getBoardByMember.FirstOrDefault(b => b.name == boardNameAPI && b.closed == false);
            if (board != null)
            {
                string boardId = board.id;
                log.Info("Board Id found: "+ boardId);

                //Getting the board memberships before any invitation is done
                log.Info("Calling api function to Get Memberships of a Board before any invitation is done");
                List<Membership> membershipListBeforeInvitation = trelloApi.GetMembershipsOfABoard(boardId, apiKey, token, "all");

                //Invite a member via email
                log.Info("Calling api function to Invite a Member to a Board via their email address");
                InviteMemberResponse response = trelloApi.InviteMemberViaEmail(boardId, apiKey, token, emailUser2);

                if (response != null)
                {
                    //Getting the board memberships after invitation is done
                    log.Info("Calling api function to Get Memberships of a Board after invitation was done");
                    List<Membership> membershipListAfterInvitation = trelloApi.GetMembershipsOfABoard(boardId, apiKey, token, "all");

                    // Find the new member added to the board
                    Membership newMember = null;
                    foreach (var membership in membershipListAfterInvitation)
                    {
                        if (!membershipListBeforeInvitation.Any(m => m.id == membership.id))
                        {
                            newMember = membership;
                            break;
                        }
                    }

                    if (newMember == null)
                    {
                        //Error log in case no new member has been added to the board after invitation
                        log.Error("No new member has been added to the board");
                    }
                    // Assert that a new member has been added
                    Assert.IsNotNull(newMember, "New member was not added to the board");
                    log.Info($"New member {newMember.idMember} ({newMember.memberType}) has been added to the board");
                }
            }
            else
            {
                log.Error("Board with name " + boardNameAPI + " and status 'open' not found");
                Assert.Fail("Board with name '{0}' and status 'open' not found", boardNameAPI);
            }
        }

        [Test, Order(4)]
        public void TestAPIDeleteBoard()
        {
            log.Info("Testing API function TestAPIDeleteBoard Started");

            TrelloApi trelloApi = new TrelloApi();
            RestClient client = new RestClient("https://api.trello.com");

            //Get board id based on member
            log.Info("Call Get Boards by member api to store the board id");
            List<Board> getBoardByMember = trelloApi.GetBoardsByMember(username,apiKey,token);

            //filter the list of boards by name and retrieve the ID of the matching board
            Board board = getBoardByMember.FirstOrDefault(b => b.name == boardNameAPI && b.closed == false);
            if (board != null)
            {
                string boardId = board.id;
                log.Info("Board Id found: " + boardId);

                //Delete the board with the board Id retrieved
                log.Info("Calling api function to delete a board");
                RestResponse deleteBoard = trelloApi.DeleteBoard(boardId, apiKey, token);

                 if (deleteBoard.StatusCode == HttpStatusCode.OK)
                 {
                     log.Info("Board with name " + boardNameAPI + " and id "+boardId+" is deleted");
                 }
                 else
                 {
                     log.Error("Board is not deleted");
                 }
            }
            else
            {
                    log.Error("Board with name " + boardNameAPI + " and status 'open' not found");
                    Assert.Fail("Board with name '{0}' and status 'open' not found", boardNameAPI);
            }  
        }
    }
}