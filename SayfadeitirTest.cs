// Generated by Selenium IDE
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
[TestFixture]
public class SayfadeitirTest {
  private IWebDriver driver;
  public IDictionary<string, object> vars {get; private set;}
  private IJavaScriptExecutor js;
  [SetUp]
  public void SetUp() {
    driver = new ChromeDriver();
    js = (IJavaScriptExecutor)driver;
    vars = new Dictionary<string, object>();
  }
  [TearDown]
  protected void TearDown() {
    driver.Quit();
  }
  [Test]
  public void sayfadeitir() {
    driver.Navigate().GoToUrl("http://demokule.lstyazilim.com:8088/admin");
    driver.Manage().Window.Size = new System.Drawing.Size(1936, 1056);
    driver.FindElement(By.LinkText("2")).Click();
    driver.FindElement(By.LinkText("3")).Click();
    driver.FindElement(By.Id("reservationTable_ellipsis")).Click();
    driver.FindElement(By.LinkText("5")).Click();
    driver.FindElement(By.LinkText("14")).Click();
    driver.FindElement(By.LinkText("Geri")).Click();
  }
}
