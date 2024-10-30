using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AT7
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
            driver.Url = "https://demo.guru99.com/test/guru99home/";
            IWebElement ift = driver.FindElement(By.XPath("//iframe[@id='a077aa5e']"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true)", ift);
            Thread.Sleep(1000);
            ift.Click();
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            driver.FindElement(By.XPath("//span[@class='nav-drop-title-wrap']")).Click();

            Assert.Pass();
        }
    }
}