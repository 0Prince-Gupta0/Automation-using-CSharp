using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System;
using SeleniumExtras.WaitHelpers;

namespace AT6
{
    public class Tests
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); 
        }

        [Test]
        public void Test1()
        {
            driver.Url = "https://testautomationpractice.blogspot.com/";

            Actions action = new Actions(driver);

            IWebElement popUp = wait.Until(d => d.FindElement(By.Id("PopUp")));

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", popUp);

            action.KeyDown(Keys.Control).Click(popUp).KeyUp(Keys.Control).Perform();

            string originalWindow = driver.CurrentWindowHandle;

            wait.Until(d => d.WindowHandles.Count > 1);
            var allWindowHandles = driver.WindowHandles;

            foreach (var windowHandle in allWindowHandles)
            {
                if (windowHandle != originalWindow)
                {
                    driver.SwitchTo().Window(windowHandle);
                    string newWindowTitle = driver.Title;

                    string expectedTitle = "Selenium";
                    if (newWindowTitle.Equals(expectedTitle, StringComparison.OrdinalIgnoreCase))
                    {
                        
                        IWebElement about = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("navbarDropdown")));
                        action.Click(about).Perform();

                        IWebElement history = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//a[@class='dropdown-item'][5]")));
                        action.Click(history).Perform();
                        Thread.Sleep(3000);
                    }
                    else
                    {
                        Console.WriteLine("The window title does not match.");
                    }
                    driver.Close();
                }
            }
            driver.SwitchTo().Window(originalWindow);


            // Alert functionality

            IWebElement promptBtn = wait.Until(d => d.FindElement(By.Id("promptBtn")));
            IJavaScriptExecutor js1 = (IJavaScriptExecutor)driver;
            js1.ExecuteScript("arguments[0].scrollIntoView(true);", promptBtn);
        
            action.Click(promptBtn).Perform();

            var alert = wait.Until(ExpectedConditions.AlertIsPresent());
            driver.SwitchTo().Alert();
            alert.SendKeys(Keys.Backspace);
            Thread.Sleep(5000);
            string textToInput = "Prince Gupta";
            alert.SendKeys("Prince Gupta");
            Thread.Sleep(5000);
            alert.Accept();
            Thread.Sleep(5000);
            Assert.Pass();
        }

        [TearDown]
        public void TearDown()
        {
       
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose(); 
                driver = null; 
            }
        }
    }
}
