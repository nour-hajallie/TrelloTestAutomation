using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Policy;
using static System.Net.WebRequestMethods;
using OpenQA.Selenium.Chrome;
using log4net;
using TrelloTestAutomation.BackendAPI;
using log4net.Config;

namespace TrelloTest.PageObjects
{
    public class BoardsPage
    {
        protected IWebDriver driver;
        protected WebDriverWait driverWait;

        // Create a logger instance for the test class
        ILog log = LogManager.GetLogger(typeof(BoardsPage));

        public BoardsPage(IWebDriver driver)
        {
            this.driver = driver;
            driverWait = new WebDriverWait(driver, new System.TimeSpan(0, 0, 0, 30, 0));

            // Load the Log4Net configuration file
            log4net.Util.LogLog.InternalDebugging = true;
            XmlConfigurator.Configure(new FileInfo("../../../Config/log4net.config"));
        }

        public By boardCreated => By.XPath("//*[@id=\"content\"]/div/div[2]/div/div/div/div/div[2]/div/div/div/div[2]/div/div[2]/ul/li[2]/a/div/div[1]/div");
        public By boardDeletedSuccessMessage => By.XPath("/div/div/div[1]");
        public By notificationButton => By.XPath("//*[@id=\"header\"]/div[3]/div[2]/div[1]/button/span");
        public By notificationBoardAccess => By.XPath("/html/body/div[3]/div/section/div/div[3]/div/div[3]/div/div[1]/div/div/div/div[4]");

        public string notificationContent = "Added you to the board ";
        public string timeNotification = "  a few seconds ago";

        public void clickOnBoard()
        {
            Thread.Sleep(5000);
            try
            {
                IWebElement boardCreatedElement = driver.FindElement(boardCreated);
                boardCreatedElement.Click();
            }
            catch (Exception ex)
            {
                log.Error("Error clicking on board created", ex);
            }
}

        public Boolean isBoardAvailable(string boardName)
        {
            Thread.Sleep(5000);
            try
            {
                IWebElement boardCreatedElement = driver.FindElement(boardCreated);
                string boardCreatedValue = boardCreatedElement.Text;

                return boardCreatedValue.Equals(boardName);
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void clickOnNotificationButton(IWebDriver driver)
        {
            Thread.Sleep(10000);
            try
            {
                IWebElement notificationButtonElement = driver.FindElement(notificationButton);
                notificationButtonElement.Click();
            }
            catch (Exception ex)
            {
                log.Error("Error clicking on notification button", ex);
            }
         
        }
        public bool isNotificationDisplayed(IWebDriver driver)
        {
            Thread.Sleep(5000);
            try
            {
                IWebElement notificationButtonElement = driver.FindElement(notificationBoardAccess);
                return notificationButtonElement.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool isContentNotificationDisplayed(IWebDriver driver, String boardName)
        {
            try
            {
                IWebElement notificationButtonElement = driver.FindElement(notificationBoardAccess);
                string notificationButtonValue = notificationButtonElement.Text;
                string fullNotificationValue = notificationContent + boardName + timeNotification;
                return notificationButtonValue.Equals(fullNotificationValue);
            }catch (NoSuchElementException)
            {
                return false;
            }
        }

    }
}
