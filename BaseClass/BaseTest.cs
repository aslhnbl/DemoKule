using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoKule.BaseClass
{
    public class BaseTest
    {
        public string adminUrl = "http://demokule.lstyazilim.com:8088/Admin/Panel/Login";
        public string test_url = "http://demokule.lstyazilim.com:8088/";
        public static IWebDriver driver;  

        [SetUp]
        //public void Open()
        //{
        //    PropertiesCollection.driver = new ChromeDriver();
        //    //driver = new ChromeDriver();
        //    PropertiesCollection.driver.Manage().Window.Maximize();           
        //}

        public void Open()
        {
            driver = new ChromeDriver();          
            driver.Manage().Window.Maximize();
            driver.Url = test_url;
            PropertiesCollection.driver = driver;
        }

        //[TearDown]
        //public void Close()
        //{
        //    driver.Quit();
        //    Assert.Pass();
        //}
    }
}
