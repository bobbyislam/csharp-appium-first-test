using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.Android;
using NUnit;
using NUnit.Framework;
using System.Collections.Generic;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Service.Options;

namespace AppiumCsharpFirstTest
{
    [TestFixture]
    public class AndroidWebTest
    {
        // you have configured an access key as environment variable,
        // use the line below. Otherwise, specify the key directly.
        private string accessKey = Environment.GetEnvironmentVariable("SEETEST_IO_ACCESS_KEY");
        private string testName = "Android Web Test with C#";

        protected AndroidDriver<AndroidElement> driver = null;

        DesiredCapabilities dc = new DesiredCapabilities();

        [SetUp()]
        public void SetupTest()
        {
            dc.SetCapability("testName", testName);
            dc.SetCapability("accessKey", accessKey);
            dc.SetCapability(MobileCapabilityType.BrowserName, "chrome");
            dc.SetCapability(MobileCapabilityType.PlatformName, "Android");
            
            driver = new AndroidDriver<AndroidElement>(new Uri("https://cloud.seetest.io:443/wd/hub"), dc);
        }

        [Test()]
        public void TestAndroidApp()
        {
            driver.Navigate().GoToUrl("https://amazon.com");
            if (driver.Capabilities.GetCapability("device.category").Equals("TABLET"))
            {
                driver.FindElement(By.XPath("//*[@name='field-keywords']")).SendKeys("iPhone");
                driver.FindElement(By.XPath("//*[@text='Go']")).Click();
            }
            else
            {
                driver.FindElement(By.XPath("//*[@name='k']")).SendKeys("iPhone");
                driver.FindElement(By.XPath("//*[@value='Go']")).Click();
            }
        }

        [TearDown()]
        public void TearDown()
        {   
            if(driver != null)
            {
                Console.WriteLine(driver.Capabilities.GetCapability("reportUrl"));
                driver.Quit();
            }

        }
    }
}
