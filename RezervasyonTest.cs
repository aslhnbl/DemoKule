using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using DemoKule.BaseClass;


namespace DemoKule
{
    [TestFixture]
    [Parallelizable]
    public class RezervasyonTest : BaseTest
    {
        //DemoPageObject page = new DemoPageObject();

        String test_url = "http://demokule.lstyazilim.com:8088/";

        //Random rndm = new Random();

        RezervasyonPage Rezervasyon = new RezervasyonPage();

        [SetUp]
        public void Setup()
        {
            PropertiesCollection.driver.Url = test_url;
        }

        [Test]
        public void DatePicker()
        {

            Rezervasyon.SelectDate(driver);
            Rezervasyon.SelectTime(driver);
            Rezervasyon.SelectArea(driver);
            Rezervasyon.SelectPersonAndTable(driver);
            Rezervasyon.CompleteData(driver);

            ////#region selectdate

            ////Tarih Seçimi

            ////int currentMonth = DateTime.Now.Month;
            //int selectDay = 0;
            ////int selectMonth = 0;
            ////DemoPageObject obj = new DemoPageObject();
            ////SeleniumSetMethod.Click(By.Id("calendar-icon"), PropertyType.Id);
            //SeleniumSetMethod.Click("calendar-icon", PropertyType.Id);
            ////driver.FindElement(By.Id("calendar-icon")).Click(); //Takvimi aç
            //Thread.Sleep(1000);

            //if (PropertiesCollection.driver.FindElement(By.Id("mc-current--year")).Text.Equals(DateTime.Now.Year.ToString()))
            //{

            //    //selectMonth = rndm.Next(currentMonth, 12);
            //    int selectMonth = SeleniumSetMethod.Random(rndm, DateTime.Now.Month, 12);

            //    for (int j = DateTime.Now.Month; j < selectMonth; j++)
            //    {

            //        SeleniumSetMethod.Click("mc-picker__month--next", PropertyType.Id);
            //        //driver.FindElement(By.Id("mc-picker__month--next")).Click();
            //    }

            //    Thread.Sleep(1000);

            //    IList<IWebElement> activeDayList = SeleniumSetMethod.Liste("//tbody[@class='mc-table__body']/tr[@class='mc-table__week']/td[@class!='mc-date mc-date--inactive']", "XPath");
            //    //IList<IWebElement> activeDayList = driver.FindElements(By.XPath("//tbody[@class='mc-table__body']/tr[@class='mc-table__week']/td[@class!='mc-date mc-date--inactive']"));

            //    selectDay = SeleniumSetMethod.Random(rndm, 1, activeDayList.Count());
            //    //selectDay = rndm.Next(1, activeDayList.Count());
            //    activeDayList[selectDay - 1].Click();
            //    Thread.Sleep(1000);
            //}

            //#endregion selectdate


            //#region selecttime
            ////Saat Aralığı Seçimi
            //IList<IWebElement> timeSlot = SeleniumSetMethod.Liste("btnradiohour", PropertyType.Name);
            ////IList<IWebElement> timeSlot = driver.FindElements(By.Name("btnradiohour"));

            //IList<IWebElement> activeTimeSlotList = timeSlot.Where(t => t.GetAttribute("disabled") == null).ToList();


            //int randomTimeSlotIndexValue = SeleniumSetMethod.Random(rndm, 0, (activeTimeSlotList.Count()));
            ////int randomTimeSlotIndexValue = rndm.Next(0, (activeTimeSlotList.Count()));
            //var id = activeTimeSlotList[randomTimeSlotIndexValue].GetAttribute("id");
            //var lblTimeSlot = PropertiesCollection.driver.FindElement(By.Id("lbltimeslot-" + id.Split("-")[1]));

            //lblTimeSlot.Click();
            //Thread.Sleep(1000);

            //#endregion selecttime



            //#region selectkat
            ////Kat Seçimi
            //IList<IWebElement> areaList = SeleniumSetMethod.Liste("btnradioArea", PropertyType.Name);
            ////IList<IWebElement> areaList = driver.FindElements(By.Name("btnradioArea"));


            //int randomAreaIndexValue = SeleniumSetMethod.Random(rndm, 0, (areaList.Count()));
            ////int randomAreaIndexValue = rndm.Next(0, (areaList.Count()));
            //var areaId = areaList[randomAreaIndexValue].GetAttribute("id");
            //var kat = areaId.Split("-")[1];

            //if (kat == "1")
            //    randomPersonNumberMax = 6;
            //else
            //    randomPersonNumberMax = 8;

            //var lblArea = PropertiesCollection.driver.FindElement(By.Id("lblAreaKat-" + (areaId.Split("-")[1])));
            //lblArea.Click();
            ////Thread.Sleep(2000);
            //#endregion selectkat


            //#region selectperson
            ////Kişi Seçimi

            //int randomPersonNumber = SeleniumSetMethod.Random(rndm, 1, randomPersonNumberMax);
            ////int randomPersonNumber = rndm.Next(1, randomPersonNumberMax);

            //for (i = 1; i < randomPersonNumber; i++)
            //    PropertiesCollection.driver.FindElement(By.ClassName("plus")).Click();
            //#endregion selectperson


            //#region selecttable       
            ////Masa Seçimi
            //IList<IWebElement> tableList = SeleniumSetMethod.Liste("masa", PropertyType.ClassName);
            ////IList<IWebElement> tableList = driver.FindElements(By.ClassName("masa"));
            //tableList = tableList.Where(t => int.Parse(t.GetAttribute("minperson")) <= randomPersonNumber).ToList();


            //int randomTableIndexValue = SeleniumSetMethod.Random(rndm, 0, (tableList.Count()));
            ////int randomTableIndexValue = rndm.Next(0, (tableList.Count()));
            //var tableclick = tableList[randomTableIndexValue];
            //tableclick.Click();
            //#endregion selecttable


            ////İsim Soyisim Tel
            //SeleniumSetMethod.EnterText("NameSurname", "Aslıhan BAL", PropertyType.Id);
            ////driver.FindElement(By.Id("NameSurname")).SendKeys("Aslıhan BAL");
            //SeleniumSetMethod.EnterText("PhoneNumber", "5555555555", PropertyType.Id);
            ////driver.FindElement(By.Id("PhoneNumber")).SendKeys("5555555555");

            //IWebElement RezervationButton = PropertiesCollection.driver.FindElement(By.XPath("//div[@id='divRezervationButton']/button[@type='button']"));
            //RezervationButton.SendKeys(Keys.Enter);

            ////Ödeme Bilgileri
            //SeleniumSetMethod.EnterText("card-name", "John Doe", PropertyType.Id);
            ////driver.FindElement(By.Id("card-name")).SendKeys("John Doe");

            //SeleniumSetMethod.EnterText("card-number", "5528790000000008", PropertyType.Id);
            ////driver.FindElement(By.Id("card-number")).SendKeys("5528790000000008");

            //SeleniumSetMethod.EnterText("tarihsx", "12/25", PropertyType.Id);
            ////driver.FindElement(By.Id("tarihsx")).SendKeys("12/25");

            //SeleniumSetMethod.EnterText("cvv", "123", PropertyType.Id);
            ////driver.FindElement(By.Id("cvv")).SendKeys("123");

            //SeleniumSetMethod.Click("chkAccept", PropertyType.Id);
            ////driver.FindElement(By.Id("chkAccept")).Click();

            //SeleniumSetMethod.EnterText("chkAccept", Keys.Enter, PropertyType.Id);
            ////driver.FindElement(By.Id("chkAccept")).SendKeys(Keys.Enter);
            ////Thread.Sleep(1000);

            //SeleniumSetMethod.Click("//div[@class='modal-content']/div[@class='modal-footer']/button[@onclick='HideModal();']", PropertyType.XPath);
            ////driver.FindElement(By.XPath("//div[@class='modal-content']/div[@class='modal-footer']/button[@onclick='HideModal();']")).Click();

            ////driver.FindElement(By.XPath("//button[contains(text(),'Tamam')]")).Click();
            //SeleniumSetMethod.Click("//button[contains(text(),'Tamam')]", PropertyType.XPath);

            //SeleniumSetMethod.EnterText("confirm", Keys.Enter, PropertyType.Id);
            ////driver.FindElement(By.Id("confirm")).Click();


        }
    }
}





