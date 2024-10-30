using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace AT5
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


            IWebElement colors = driver.FindElement(By.Id("colors"));

            IJavaScriptExecutor js= (IJavaScriptExecutor) driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);",colors);

            SelectElement select=new SelectElement(colors);
            select.SelectByValue("red");
            select.SelectByValue("blue");
            select.SelectByValue("white");
            Thread.Sleep(2000);

            IWebElement animals = driver.FindElement(By.Id("animals"));
            IJavaScriptExecutor jsp = (IJavaScriptExecutor)driver;
            jsp.ExecuteScript("arguments[0].scrollIntoView(true)", animals);

            SelectElement newselect = new SelectElement(animals);
            newselect.SelectByValue("giraffe");
            Thread.Sleep(2000);
            Actions action = new Actions(driver);

            IWebElement source = driver.FindElement(By.Id("draggable"));
            IWebElement target = driver.FindElement(By.Id("droppable"));
            action.DragAndDrop(source, target).Perform();

            IWebElement popup = driver.FindElement(By.Id("PopUp"));
            IJavaScriptExecutor js1 = (IJavaScriptExecutor)driver;
            js1.ExecuteScript("arguments[0].scrollIntoView(true)", popup);

            action.KeyDown(Keys.Control).Click(popup).KeyUp(Keys.Control).Perform();

            var windowHandles = driver.WindowHandles;
            driver.SwitchTo().Window(windowHandles[1]);
            Thread.Sleep(5000);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            Thread.Sleep(5000);
           
            Thread.Sleep(5000);
            driver.Quit();

            Assert.Pass();
        }
    }
}