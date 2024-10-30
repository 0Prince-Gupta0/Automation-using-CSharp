using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace AT7II
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
            using IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://testautomationpractice.blogspot.com/";

            IWebElement col = driver.FindElement(By.Id("colors"));
            IJavaScriptExecutor jpt = (IJavaScriptExecutor)driver;
            jpt.ExecuteScript("arguments[0].scrollIntoView(true);", col);

            IWebElement dt = driver.FindElement(By.Id("datepicker"));
            dt.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IList<IWebElement> list = wait.Until(driver =>
                driver.FindElements(By.XPath("//*[@class='ui-datepicker-calendar']/tbody/tr/td[contains(@data-event, 'click')]"))
            );

            DateTime today = DateTime.UtcNow.Date.AddDays(2);
            string day = today.Day.ToString();

            foreach (var cell in list)
            {
                if (cell.Text.Equals(day))
                {

                    cell.Click();
                    Thread.Sleep(10000);
                    break;
                }
            }

            Thread.Sleep(4000);

            driver.Quit();
            Assert.Pass();
        }
    }
}