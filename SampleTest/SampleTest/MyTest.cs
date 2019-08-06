using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace MyTests
{
    public class Tests
    {
        private readonly IWebDriver driver = new ChromeDriver("C:\\SampleTest");
        public void NavigateTo(string strUrl)
        {
            driver.Navigate().GoToUrl(strUrl);
            driver.Manage().Window.Maximize();
            Thread.Sleep(3000);
        }

        [SetUp]
        public void SetUp()
        {
            NavigateTo("https://shahirabd.wixsite.com/shahirabd");
        }

        [Test]
        public void CheckPersonalStatement()
        {
            Assert.AreEqual("PERSONAL STATEMENT", driver.FindElement(By.Id("comp-jyreof4u2")).Text);
        }

        [Test]
        public void CheckMenuDefaultState()
        {
            Assert.IsTrue(driver.FindElement(By.Id("comp-jyrecvy10")).GetAttribute("data-state").Equals("menu selected idle link notMobile"), "Home menu is not selected.");
            Assert.IsTrue(driver.FindElement(By.Id("comp-jyrecvy11")).GetAttribute("data-state").Equals("menu  idle link notMobile"), "Blog should not be in selected mode right now.");
        }

        [Test]
        public void CheckRedirectedToBlogPage()
        {
            driver.FindElement(By.Id("comp-jyrecvy11")).Click();
            Thread.Sleep(7000);
            Assert.AreEqual("https://shahirabd.wixsite.com/shahirabd/blog-1", driver.Url);
        }

        [Test]
        public void GetInTouchTest()
        {
            driver.FindElement(By.Id("comp-jyreoi97input")).SendKeys("Jane Doe");
            driver.FindElement(By.Id("comp-jyreoi98input")).SendKeys("1, 11 Street");
            driver.FindElement(By.Id("comp-jyreoi9ainput")).SendKeys("janedoe@mailinator.com");
            driver.FindElement(By.Id("comp-jyreoi9binput")).SendKeys("0121234567");
            driver.FindElement(By.Id("comp-jyreoi9cinput")).SendKeys("Hello");
            driver.FindElement(By.Id("comp-jyreoi9ftextarea")).SendKeys("I would like to know more");
            driver.FindElement(By.Id("comp-jyreoihmlabel")).Click();
            Thread.Sleep(7000);
            Assert.AreEqual("Thanks for submitting!", driver.FindElement(By.Id("comp-jyreoihl")).FindElement(By.TagName("p")).FindElement(By.TagName("span")), "Message not matched");
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Close();
            driver.Quit();
        }
    }
}