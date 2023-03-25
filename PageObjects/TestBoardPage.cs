using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using log4net.Config;
using log4net;

namespace TrelloTest.PageObjects
{
    internal class TestBoardPage
    {
        protected IWebDriver driver;
        protected WebDriverWait driverWait;

        // Create a logger instance for the test class
        ILog log = LogManager.GetLogger(typeof(TestBoardPage));


        public TestBoardPage(IWebDriver driver)
        {
            this.driver = driver;
            driverWait = new WebDriverWait(driver, new System.TimeSpan(0, 0, 0, 30, 0));

            // Load the Log4Net configuration file
            log4net.Util.LogLog.InternalDebugging = true;
            XmlConfigurator.Configure(new FileInfo("../../../Config/log4net.config"));
        }

        public By shareButton => By.XPath("//*[@id=\"content\"]/div/div[1]/div[1]/div[2]/span[9]/span/div/button");
        public By inputSharePopUp => By.XPath("//*[@id=\"layer-manager-overlay\"]/div/div/div/div/div/div[2]/div/div/div[1]/div[1]/input");
        public By shareButtonPopUp => By.XPath("//button[text()='Share']");
        public By dotsButton => By.XPath("//*[@id=\"popover-boundary\"]/div/div[1]/nav/div[1]/div/div/div[2]/div/div[3]/ul/div[2]/li[2]/div[2]/div[1]/button");
        public By closeBoardButton => By.XPath("/html/body/div[6]/div/section/div/div/button/span[1]");
        public By closeBoardButtonPopUp => By.XPath("/html/body/div[6]/div/section/div/button");
        public By permanentlyDeleteButton => By.XPath("//*[@id=\"content\"]/div/div/div/div/div/div[2]/button");
        public By deleteButtonPopUp => By.XPath("/html/body/div[6]/div/section/div/button");
        public By UserMenuPopUp => By.XPath("//*[@id=\"header\"]/div[3]/div[2]/button");
        public By user2Added => By.XPath("//*[@id=\"layer-manager-overlay\"]/div/div/div/div/div/div[3]/div[3]/div[3]/div/div/button");
        public By boardClosedSuccessMessage => By.XPath("//*[@id=\"content\"]/div/div/div/div/div/h1");


        public void clickOnShareButton()
        {
            Thread.Sleep(5000); // wait for 5 seconds
            try
            {
                IWebElement shareButtonElement = driver.FindElement(shareButton);
                driverWait.Until(e => shareButtonElement);

                shareButtonElement.Click();
            }
            catch (Exception ex)
            {
                log.Error("Error while clicking on share button ", ex);

            }

        }

        public void inviteUserToBoard(String emailUser2)
        {
            Thread.Sleep(5000); // wait for 5 seconds
            try
            {
                IWebElement inputSharePopUpElement = driver.FindElement(inputSharePopUp);
                driverWait.Until(e => inputSharePopUpElement);

                inputSharePopUpElement.Clear();
                //fill the email of the user that is invited to join the board
                inputSharePopUpElement.SendKeys(emailUser2);
                driverWait = new WebDriverWait(driver, new System.TimeSpan(0, 0, 0, 30, 0));

                //click on the share button in the pop up to send invitation
                IWebElement shareButtonPopUpElement = driver.FindElement(shareButtonPopUp);
                shareButtonPopUpElement.Submit();
                shareButtonPopUpElement.Click();
            }
            catch (Exception ex)
            {
                log.Error("Error while inviting user to board ", ex);

            }

        }

        public bool IsUser2Available(IWebDriver driver)
        {
            try
            {
                Thread.Sleep(5000);
                driver.FindElement(user2Added);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }


        public void clickOndotsButton()
        {
            Thread.Sleep(5000);
            try
            {
                IWebElement ondotsButtonElement = driver.FindElement(dotsButton);
                Actions action = new Actions(driver);
                action.MoveToElement(ondotsButtonElement).Perform();
                ondotsButtonElement.Click();
            }
            catch (Exception ex)
            {
                log.Error("Error while clicking on dots button ", ex);

            }
        }

        public void clickOnCloseBoardButton()
        {
            Thread.Sleep(5000);
            try
            {
                IWebElement closeBoardButtonElement = driver.FindElement(closeBoardButton);
                closeBoardButtonElement.Click();

                Thread.Sleep(5000);

                IWebElement closeBoardButtonPopUpElement = driver.FindElement(closeBoardButtonPopUp);
                closeBoardButtonPopUpElement.Click();
            }
            catch (Exception ex)
            {
                log.Error("Error while clicking on close board button ", ex);

            }
        }

        public bool IsClosedBoardSuccessMessageAvailable(IWebDriver driver)
        {
            try
            {
                Thread.Sleep(5000);
                driver.FindElement(boardClosedSuccessMessage);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public BoardsPage clickOnDeleteButton()
        {
            Thread.Sleep(5000);
            try
            {
                BoardsPage boardsPage = new BoardsPage(driver);

                IWebElement permanentlyDeleteButtonElement = driver.FindElement(permanentlyDeleteButton);
                permanentlyDeleteButtonElement.Click();

                IWebElement deleteButtonPopUpElement = driver.FindElement(deleteButtonPopUp);
                deleteButtonPopUpElement.Click();

                return boardsPage;
            }
            catch (Exception ex)
            {
                log.Error("Error while clicking on delete board button ", ex);
                return null;
            }
        }
    }
}
