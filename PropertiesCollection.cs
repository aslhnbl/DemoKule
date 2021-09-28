using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoKule
{
    enum PropertyType
    {
        Id,
        Name,
        LinkText,
        ClassName,
        XPath
    }
    class PropertiesCollection
    {
        public static IWebDriver driver { get; set; }
    }
}
