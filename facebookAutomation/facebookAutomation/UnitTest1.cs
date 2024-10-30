using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace facebookAutomation
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            WebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Url = "https://www.google.co.in/";
            IWebElement google = driver.FindElement(By.XPath("//textarea[@class='gLFyf']"));
            google.SendKeys("Facebook");
            google.Submit();

            driver.FindElement(By.PartialLinkText("log in")).Click();
            driver.FindElement(By.LinkText("Sign up for Facebook")).Click();

            driver.FindElement(By.XPath("//input[@name='firstname']")).SendKeys("XYZ");
            driver.FindElement(By.XPath("//input[@name='lastname']")).SendKeys("ABC");
            driver.FindElement(By.XPath("//select[@name='birthday_day']")).SendKeys("15");
            driver.FindElement(By.XPath("//select[@name='birthday_month']")).SendKeys("Aug");
            driver.FindElement(By.XPath("//select[@name='birthday_year']")).SendKeys("1947");
            driver.FindElement(By.XPath("//input[@value='2']")).Click();
            driver.FindElement(By.XPath("//input[@name='reg_email__']")).SendKeys("gokax68503@paxnw.com");
            driver.FindElement(By.XPath("//input[@name='reg_passwd__']")).SendKeys("xyzabc@facebook.com");
            driver.FindElement(By.XPath("//button[@name='websubmit']")).Submit();

            Thread.Sleep(10000);
            driver.Quit();
            Assert.Fail();
        }
    }
}