using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Locator
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
            driver.Url = "https://www.orangehrm.com/";
            
            driver.FindElement(By.Name("locale")).Click();
            driver.FindElement(By.XPath("//a[@class='nav-link-hed'][1]")).Click();
           
            driver.FindElement(By.LinkText("Why OrangeHRM")).Click();
            driver.FindElement(By.LinkText("Resources")).Click();
            driver.FindElement(By.LinkText("Company")).Click();
            driver.FindElement(By.LinkText("Pricing")).Click();
            driver.FindElement(By.LinkText("Book a Free Demo")).Click();
            driver.FindElement(By.LinkText("Contact Sales")).Click();

            driver.FindElement(By.ClassName("nav-logo")).Click();
            driver.FindElement(By.XPath("//input[@id='Form_submitForm_EmailHomePage']")).SendKeys("hello");
            driver.FindElement(By.Id("Form_submitForm_action_request")).Click();
            driver.FindElement(By.ClassName("ytp-impression-link-logo")).Click();
            Assert.Pass();
        }
    }
}