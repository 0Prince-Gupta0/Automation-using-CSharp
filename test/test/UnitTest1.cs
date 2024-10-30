using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace test
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
            driver.Url = "https://testautomationpractice.blogspot.com/";


            IWebElement dropdown = driver.FindElement(By.XPath("//*[@id='country']"));

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", dropdown);

            SelectElement select = new SelectElement(dropdown);
            select.SelectByValue("germany");
            IList<IWebElement> list = select.Options;
            foreach (var option in list)
            {
                Console.WriteLine(option.Text);
            }

            Thread.Sleep(5000);
            js.ExecuteScript("window.scrollTo(0,0)");
            Thread.Sleep(3000);
            js.ExecuteScript("window.scrollTo(0,document.body.clientHeight)");
            Thread.Sleep(3000);
            js.ExecuteScript("window.scrollTo(document.body.clientHeight,0)");
           
           


            Assert.Pass();
        }
    }
}