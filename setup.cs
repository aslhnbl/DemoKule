using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;


namespace DemoKule
{
    class setup
    {

        String test_url = "http://demokule.lstyazilim.com:8088/";

        IWebDriver driver;


        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = test_url;

        }
    }
}
