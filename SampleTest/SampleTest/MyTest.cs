using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
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
            Assert.AreEqual("PERSONAL STATEMENT", driver.FindElement(By.Id("comp-jyreof4u2")).Text, "Title not match.");
            Console.WriteLine("CheckPersonalStatement: Passed");
        }

        [Test]
        public void CheckMenuDefaultState()
        {
            Assert.IsTrue(driver.FindElement(By.Id("comp-jyrecvy10")).GetAttribute("data-state").Equals("menu selected idle link notMobile"), "Home menu is not selected.");
            Console.WriteLine("CheckMenuDefaultState: Home menu is selected by default. Passed");
            Assert.IsTrue(driver.FindElement(By.Id("comp-jyrecvy11")).GetAttribute("data-state").Equals("menu  idle link notMobile"), "Blog should not be in selected mode right now.");
            Console.WriteLine("CheckMenuDefaultState: Blog menu is not selected by default. Passed");
        }

        [Test]
        public void CheckRedirectedToBlogPage()
        {
            driver.FindElement(By.Id("comp-jyrecvy11")).Click();
            Console.WriteLine("CheckRedirectedToBlogPage: Clicked on Blog menu. Passed");
            Thread.Sleep(7000);
            Assert.AreEqual("https://shahirabd.wixsite.com/shahirabd/blog-1", driver.Url, "URL not matched, might not be redirected correctly.");
            Console.WriteLine("CheckRedirectedToBlogPage: Passed");
        }

        [TestCase("Jane Doe", "1, 11 Street", "janedoe@mailinator.com", "0121234567", "Hello", "I would like to know more")]
        public void GetInTouchTest(string name, string address, string email, string phone, string title, string message)
        {
            driver.FindElement(By.Id("comp-jyreoi97input")).SendKeys(name);
            Console.WriteLine("GetInTouchTest: Entered name. Passed");
            driver.FindElement(By.Id("comp-jyreoi98input")).SendKeys(address);
            Console.WriteLine("GetInTouchTest: Entered address. Passed");
            driver.FindElement(By.Id("comp-jyreoi9ainput")).SendKeys(email);
            Console.WriteLine("GetInTouchTest: Entered email. Passed");
            driver.FindElement(By.Id("comp-jyreoi9binput")).SendKeys(phone);
            Console.WriteLine("GetInTouchTest: Entered phone number. Passed");
            driver.FindElement(By.Id("comp-jyreoi9cinput")).SendKeys(title);
            Console.WriteLine("GetInTouchTest: Entered message title. Passed");
            driver.FindElement(By.Id("comp-jyreoi9ftextarea")).SendKeys(message);
            Console.WriteLine("GetInTouchTest: Entered message. Passed");
            driver.FindElement(By.Id("comp-jyreoihmlabel")).Click();
            Thread.Sleep(7000);
            Assert.AreEqual("Thanks for submitting!", driver.FindElement(By.Id("comp-jyreoihl")).FindElement(By.TagName("p")).FindElement(By.TagName("span")), "Message not matched");
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            driver.Close();
            driver.Quit();
        }
    }
}