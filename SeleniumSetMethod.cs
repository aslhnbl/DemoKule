using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DemoKule
{
    class SeleniumSetMethod
    {
        public static IList<IWebElement> Liste(IWebElement  element)
        {
            IList<IWebElement> List = new List<IWebElement>(); ///*****

            //if (elementType == PropertyType.Id)
            //{
            //    List = PropertiesCollection.driver.FindElements(By.Id(element));
            //    return List;
            //}

            //if (elementType == PropertyType.XPath)
            //{
            //    List = PropertiesCollection.driver.FindElements(By.XPath(element));
            //    //IList<IWebElement> activeDayList = driver.FindElements(By.XPath("//tbody[@class='mc-table__body']/tr[@class='mc-table__week']/td[@class!='mc-date mc-date--inactive']"));
            //    return List;
            //}

            //if (elementType == PropertyType.Name)
            //{
            //    List = PropertiesCollection.driver.FindElements(By.Name(element));
            //    //IList<IWebElement> activeDayList = driver.FindElements(By.XPath("//tbody[@class='mc-table__body']/tr[@class='mc-table__week']/td[@class!='mc-date mc-date--inactive']"));
            //    return List;
            //}

            //if (elementType == PropertyType.ClassName)
            //{
            //    List = PropertiesCollection.driver.FindElements(By.ClassName(element));
            //    //IList<IWebElement> activeDayList = driver.FindElements(By.XPath("//tbody[@class='mc-table__body']/tr[@class='mc-table__week']/td[@class!='mc-date mc-date--inactive']"));
            //    return List;
            //}

            return List;
        }

        public static void EnterText(IWebElement element, string value)
        {
            element.SendKeys(value);

            //if (elementType == PropertyType.Id)
            //    PropertiesCollection.driver.FindElement(By.Id(element)).SendKeys(value);
            //if (elementType == PropertyType.Name)
            //    PropertiesCollection.driver.FindElement(By.Name(element)).SendKeys(value);
            //if (elementType == PropertyType.ClassName)
            //    PropertiesCollection.driver.FindElement(By.ClassName(element)).SendKeys(value);
            //if (elementType == PropertyType.XPath)
            //    PropertiesCollection.driver.FindElement(By.XPath(element)).SendKeys(value);
            //if (elementType == PropertyType.LinkText)
            //    PropertiesCollection.driver.FindElement(By.LinkText(element)).SendKeys(value);
        }

        public static void Click(IWebElement element)
        {

            element.Click();
            //if (elementType == PropertyType.Id)
            //    PropertiesCollection.driver.FindElement(By.Id(element)).Click();
            //if (elementType == PropertyType.Name)
            //    PropertiesCollection.driver.FindElement(By.Name(element)).Click();
            //if (elementType == PropertyType.ClassName)
            //    PropertiesCollection.driver.FindElement(By.ClassName(element)).Click();
            //if (elementType == PropertyType.XPath)
            //    PropertiesCollection.driver.FindElement(By.XPath(element)).Click();
            //if (elementType == PropertyType.LinkText)
            //    PropertiesCollection.driver.FindElement(By.LinkText(element)).Click();
        }

        public static int Random(Random rndm, int minValue, int maxValue)
        {
            int random = rndm.Next(minValue, maxValue);

            return random;
        }


        public static void SelectDropdown (IWebElement element, int value)

        {
            new SelectElement(element).SelectByIndex(value);


        }
    }
}
