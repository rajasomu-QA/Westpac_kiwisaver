using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System;

namespace Westpac_kiwisaver
{
    public class Tests
    {
        IWebDriver webDriver = new ChromeDriver(".");
        [OneTimeSetUp]
        public void StartChrome()
        {
            
            webDriver.Navigate().GoToUrl("https://www.westpac.co.nz/");
            webDriver.Manage().Window.Maximize();
            Assert.AreEqual("Bank | Westpac New Zealand - Helping Kiwis with their personal banking", webDriver.Title);
            Assert.Pass();

        }

        [Test]
        public void Scenario1()
        {
            webDriver.FindElement(By.XPath("/html[1]/body[1]/div[2]/header[1]/div[1]/nav[3]/ul[1]/li[6]/a[1]")).Click();
            Thread.Sleep(200);
            webDriver.FindElement(By.XPath("/html[1]/body[1]/div[2]/header[1]/div[1]/nav[3]/ul[1]/li[6]/div[1]/ol[1]/li[2]/ul[1]/li[7]/a[1]")).Click();
            Thread.Sleep(200);
            webDriver.FindElement(By.XPath("/html[1]/body[1]/div[2]/main[1]/div[1]/div[1]/aside[1]/nav[1]/div[1]/ul[1]/li[4]/ul[1]/li[2]/a[1]/span[1]")).Click();
            Thread.Sleep(1000);
            webDriver.SwitchTo().Frame(0);
            IWebElement info = webDriver.FindElement(By.CssSelector("div[help-id='CurrentAge'] i[class='icon']"));
            info.Click();
            Thread.Sleep(1000);
            Assert.AreEqual("This calculator has an age limit of 64 years old as you need to be under the age of 65 to join KiwiSaver.", webDriver.FindElement(By.XPath("//p[contains(text(),'This calculator has an age limit of 18 to 64 years')]")).Text);
            webDriver.Quit(); 

        }
        [Test]

        public void Scenario2_a()
        {
            //•	User whose Current age is 30 is Employed @ a Salary 82000 p/a, contributes to KiwiSaver @ 4% 
            //and chooses a Defensive risk profile can calculate his projected balances at retirement.
            webDriver.Navigate().GoToUrl("https://www.westpac.co.nz/");
            webDriver.Manage().Window.Maximize();
            webDriver.FindElement(By.XPath("/html[1]/body[1]/div[2]/header[1]/div[1]/nav[3]/ul[1]/li[6]/a[1]")).Click();
            Thread.Sleep(100);
            webDriver.FindElement(By.XPath("/html[1]/body[1]/div[2]/header[1]/div[1]/nav[3]/ul[1]/li[6]/div[1]/ol[1]/li[2]/ul[1]/li[7]/a[1]")).Click();
            Thread.Sleep(100);
            webDriver.FindElement(By.XPath("/html[1]/body[1]/div[2]/main[1]/div[1]/div[1]/aside[1]/nav[1]/div[1]/ul[1]/li[4]/ul[1]/li[2]/a[1]/span[1]")).Click();
            Thread.Sleep(1000);
            webDriver.SwitchTo().Frame(0);
            Thread.Sleep(1000);
            var currentage = webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]"));
            currentage.SendKeys("30");
            Thread.Sleep(1000);
            webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]")).Click();
            Thread.Sleep(1000);
            webDriver.FindElement(By.XPath("//div[@class='label']//span[@class='ng-scope'][normalize-space()='Employed']")).Click();
            Thread.Sleep(1000);
            var salary = webDriver.FindElement(By.XPath("//div[contains(@model,'ctrl.data.AnnualIncome')]//input[@type='text']"));
            salary.SendKeys("82000");
            Thread.Sleep(500);
            webDriver.FindElement(By.Id("radio-option-04F")).Click();
            Thread.Sleep(500);
            webDriver.FindElement(By.Id("radio-option-013")).Click();
            Thread.Sleep(1000);
            webDriver.FindElement(By.XPath("//span[normalize-space()='View your KiwiSaver retirement projections']")).Click();
            Thread.Sleep(1000);
            Assert.AreEqual("$\r\n436,365", webDriver.FindElement(By.XPath("//span[@class='result-value result-currency ng-binding']")).Text);
            Console.WriteLine("Projected balance calculated for the Defensive Risk profile");

            //webDriver.Quit();
            Thread.Sleep(1000);
        }

        [Test]

        public void Scenario2_b()

        {
            //------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
            //User whose current aged 45 is Self-employed, current KiwiSaver balance is $100000, voluntary contributes $90 fortnightly and chooses Conservative risk profile with saving goals
            //requirement of $290000 can calculate his projected balances at retirement.
            Thread.Sleep(500);
            webDriver.Navigate().GoToUrl("https://www.westpac.co.nz/");
            webDriver.Manage().Window.Maximize();
            webDriver.FindElement(By.XPath("/html[1]/body[1]/div[2]/header[1]/div[1]/nav[3]/ul[1]/li[6]/a[1]")).Click();
            Thread.Sleep(100);
            webDriver.FindElement(By.XPath("/html[1]/body[1]/div[2]/header[1]/div[1]/nav[3]/ul[1]/li[6]/div[1]/ol[1]/li[2]/ul[1]/li[7]/a[1]")).Click();
            Thread.Sleep(100);
            webDriver.FindElement(By.XPath("/html[1]/body[1]/div[2]/main[1]/div[1]/div[1]/aside[1]/nav[1]/div[1]/ul[1]/li[4]/ul[1]/li[2]/a[1]/span[1]")).Click();
            Thread.Sleep(1000);
            webDriver.SwitchTo().Frame(0);
            Thread.Sleep(500);
            var currentage = webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]"));

            currentage.SendKeys("45");
            
            Thread.Sleep(1000);
            
            webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]")).Click();
            Thread.Sleep(1500);
            webDriver.FindElement(By.XPath("//span[normalize-space()='Self-employed']")).Click();
            Thread.Sleep(1500);
            var kwsbal = webDriver.FindElement(By.XPath("//div[contains(@model,'ctrl.data.KiwiSaverBalance')]//input[@placeholder='Optional']"));
            kwsbal.SendKeys("100000");
            Thread.Sleep(500);
            var Volcont = webDriver.FindElement(By.XPath("//div[contains(@class,'control-with-period control-with-prefix currency-control')]//input[contains(@placeholder,'Optional')]"));
            Volcont.SendKeys("90");
            Thread.Sleep(500);
            webDriver.FindElement(By.XPath("//div[contains(@class,'no-selection')]//div[contains(@class,'well-value ng-binding')]")).Click();
            Thread.Sleep(1000);
            webDriver.FindElement(By.XPath("//span[normalize-space()='Fortnightly']")).Click();
            Thread.Sleep(1000);
            webDriver.FindElement(By.Id("radio-option-016")).Click();
            Thread.Sleep(1000);
            var kwsproj = webDriver.FindElement(By.XPath("//div[@class='wpnib-field-savings-goal field-group ng-isolate-scope']//div[1]//input[1]"));
            kwsproj.SendKeys("290000");
            Thread.Sleep(1000);
            webDriver.FindElement(By.XPath("//span[normalize-space()='View your KiwiSaver retirement projections']")).Click();
            Thread.Sleep(1000);
            Assert.AreEqual("$\r\n259,581", webDriver.FindElement(By.XPath("//span[@class='result-value result-currency ng-binding']")).Text);
            Console.WriteLine("Projected balance calculated for the Conservative Risk profile");

            //webDriver.Quit();
            Thread.Sleep(1000);
        }

        [Test]

        public void Scenario2_c()

        {
            //------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
            //User whose current aged 55 is not employed, current KiwiSaver balance is $140000, voluntary contributes $10 annually and chooses Balanced risk profile with saving goals 
            //requirement of $200000 is able to calculate his projected balances at retirement.
            Thread.Sleep(500);
            webDriver.Navigate().GoToUrl("https://www.westpac.co.nz/");
            webDriver.Manage().Window.Maximize();
            webDriver.FindElement(By.XPath("/html[1]/body[1]/div[2]/header[1]/div[1]/nav[3]/ul[1]/li[6]/a[1]")).Click();
            Thread.Sleep(100);
            webDriver.FindElement(By.XPath("/html[1]/body[1]/div[2]/header[1]/div[1]/nav[3]/ul[1]/li[6]/div[1]/ol[1]/li[2]/ul[1]/li[7]/a[1]")).Click();
            Thread.Sleep(100);
            webDriver.FindElement(By.XPath("/html[1]/body[1]/div[2]/main[1]/div[1]/div[1]/aside[1]/nav[1]/div[1]/ul[1]/li[4]/ul[1]/li[2]/a[1]/span[1]")).Click();
            Thread.Sleep(1000);
            webDriver.SwitchTo().Frame(0);
            Thread.Sleep(1000);
            var currentage = webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]"));

            currentage.SendKeys("55");

            Thread.Sleep(1000);

            webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]")).Click();
            Thread.Sleep(1500);
            webDriver.FindElement(By.XPath("//span[normalize-space()='Not employed']")).Click();
            Thread.Sleep(1500);
            var kwsbal = webDriver.FindElement(By.XPath("//div[contains(@model,'ctrl.data.KiwiSaverBalance')]//input[@placeholder='Optional']"));
            kwsbal.SendKeys("140000");
            Thread.Sleep(500);
            var Volcont = webDriver.FindElement(By.XPath("//div[contains(@class,'control-with-period control-with-prefix currency-control')]//input[contains(@placeholder,'Optional')]"));
            Volcont.SendKeys("10");
            Thread.Sleep(500);
            webDriver.FindElement(By.XPath("//div[contains(@class,'no-selection')]//div[contains(@class,'well-value ng-binding')]")).Click();
            Thread.Sleep(1000);
            webDriver.FindElement(By.XPath("//span[normalize-space()='Annually']")).Click();
            Thread.Sleep(1000);
            webDriver.FindElement(By.Id("radio-option-019")).Click();
            Thread.Sleep(1000);
            var kwsproj = webDriver.FindElement(By.XPath("//div[@class='wpnib-field-savings-goal field-group ng-isolate-scope']//div[1]//input[1]"));
            kwsproj.SendKeys("200000");
            Thread.Sleep(1000);
            webDriver.FindElement(By.XPath("//span[normalize-space()='View your KiwiSaver retirement projections']")).Click();
            Thread.Sleep(1000);
            Assert.AreEqual("$\r\n197,679", webDriver.FindElement(By.XPath("//span[@class='result-value result-currency ng-binding']")).Text);
            Console.WriteLine("Projected balance calculated for the Balanced Risk profile");

            webDriver.Quit();
        }
    

        [OneTimeTearDown]
        public void CloseTest()
        {
            webDriver.Quit();
            
        }
        
    }
}