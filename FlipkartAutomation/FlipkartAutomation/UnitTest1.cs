using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FlipkartAutomation
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

            driver.Url = "https://www.flipkart.com/";
            driver.FindElement(By.XPath("//a[@class='_1ch8e_']")); //X-Path for the highlighted area


            driver.FindElement(By.XPath("//input[@class='Pke_EE']")).SendKeys("IPhone");
            driver.FindElement(By.XPath("//input[@class='Pke_EE']")).Submit();
            driver.FindElement(By.XPath("//div[@class='KzDlHZ']")).Click();
            //Assert.Pass();
        }
    }
}