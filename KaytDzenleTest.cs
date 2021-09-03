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
public class KaytDzenleTest {
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
  public void kaytDzenle() {
    driver.Navigate().GoToUrl("http://demokule.lstyazilim.com:8088/Admin/Panel/Login");
    driver.Manage().Window.Size = new System.Drawing.Size(1552, 840);
    driver.FindElement(By.Id("txtkull")).Click();
    driver.FindElement(By.Id("txtkull")).SendKeys("a");
    driver.FindElement(By.CssSelector(".login")).Click();
    driver.FindElement(By.Id("txtparola")).Click();
    driver.FindElement(By.Id("txtparola")).SendKeys("a");
    driver.FindElement(By.Id("btngirs")).Click();
    driver.FindElement(By.CssSelector(".odd:nth-child(7) .btn-secondary")).Click();
    driver.FindElement(By.Id("AreaId")).Click();
    {
      var dropdown = driver.FindElement(By.Id("AreaId"));
      dropdown.FindElement(By.XPath("//option[. = 'Restoran']")).Click();
    }
    driver.FindElement(By.Id("ReservationDate")).Click();
    driver.FindElement(By.CssSelector(".mc-table__week:nth-child(5) > .mc-date:nth-child(7)")).Click();
    driver.FindElement(By.Id("TimeSlotId")).Click();
    {
      var dropdown = driver.FindElement(By.Id("TimeSlotId"));
      dropdown.FindElement(By.XPath("//option[. = '15:00 - 17:00']")).Click();
    }
    driver.FindElement(By.Id("TableId")).Click();
    {
      var dropdown = driver.FindElement(By.Id("TableId"));
      dropdown.FindElement(By.XPath("//option[. = 'Masa43 (4 kişilik)']")).Click();
    }
    driver.FindElement(By.CssSelector(".mr-sm-1")).Click();
    driver.FindElement(By.CssSelector(".swal2-confirm")).Click();
    js.ExecuteScript("window.scrollTo(0,0)");
  }
}
