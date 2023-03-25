using log4net;
using log4net.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrelloTest.PageObjects
{
    public class LoginPage
    {

        protected IWebDriver driver;
        protected WebDriverWait driverWait;

        // Create a logger instance for the test class
        ILog log = LogManager.GetLogger(typeof(LoginPage));

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            driverWait = new WebDriverWait(driver, new System.TimeSpan(0, 0, 0, 30, 0));

            // Load the Log4Net configuration file
            log4net.Util.LogLog.InternalDebugging = true;
            XmlConfigurator.Configure(new FileInfo("../../../Config/log4net.config"));
        }
        public By inputEmail => By.Id("user");
        public By continueButton => By.Id("login");
        public By inputPassword => By.Id("password");
        public By loginButton => By.Id("login-submit");

        public void setEmailField(String email)
        {
            try
            {
                IWebElement inputEmailElement = driver.FindElement(inputEmail);
                driverWait.Until(e => inputEmailElement);
                inputEmailElement.Clear();
                inputEmailElement.SendKeys(email);
            }
            catch (Exception ex)
            {
                log.Error("Error while filling the email ", ex);
            }
        }

        public void clickContinueLoginButton()
        {
            try
            {
                IWebElement continueButtonElement = driver.FindElement(continueButton);

                driverWait.Until(e => continueButtonElement);
                continueButtonElement.Click();
            }
            catch (Exception ex)
            {
                log.Error("Error while clicking on the continue button after filling the email ", ex);
            }
        }

        public void setPasswordField(String password)
        {
            Thread.Sleep(5000);
            try
            {
                IWebElement inputPasswordElement = driver.FindElement(inputPassword);

                inputPasswordElement.Clear();
                inputPasswordElement.SendKeys(password);
            }
            catch (Exception ex)
            {
                log.Error("Error while filling the password ", ex);
            }
        }

        public BoardsPage clickLoginButton()
        {
            try
            {
                BoardsPage boardsPage = new BoardsPage(driver);
                IWebElement loginButtonElement = driver.FindElement(loginButton);

                driverWait.Until(e => loginButtonElement);
                loginButtonElement.Click();
                return boardsPage;

            }
            catch (Exception ex)
            {
                log.Error("Error while clicking on login button ", ex);
                return null;
            }
        }
    }
}
