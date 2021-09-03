using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;


namespace DemoKule
{


    public class Rezervasyon
    {

        IWebDriver driver;
        String test_url = "http://demokule.lstyazilim.com:8088/";
        Random rndm = new Random();

        [Test]
        public void DatePicker()
        {

            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = test_url;

            int randomPersonNumberMax = 0;
            int i = 0;

            #region selectdate

            //Tarih Seçimi

            int currentMonth = DateTime.Now.Month;
            int selectDay = 0;
            int selectMonth = 0;

            driver.FindElement(By.Id("calendar-icon")).Click(); //Takvimi aç          

            if (driver.FindElement(By.Id("mc-current--year")).Text.Equals(DateTime.Now.Year.ToString()))
            {

                selectMonth = rndm.Next(currentMonth, 12);

                for (int j = currentMonth; j < selectMonth; j++)
                {
                    driver.FindElement(By.Id("mc-picker__month--next")).Click();
                }

                Thread.Sleep(1000);
                IList<IWebElement> activeDayList = driver.FindElements(By.XPath("//tbody[@class='mc-table__body']/tr[@class='mc-table__week']/td[@class!='mc-date mc-date--inactive']"));


                selectDay = rndm.Next(1, activeDayList.Count());
                activeDayList[selectDay - 1].Click();
                Thread.Sleep(1000);
            }


            #endregion selectdate


            #region selecttime
            //Saat Aralığı Seçimi         
            IList<IWebElement> timeSlot = driver.FindElements(By.Name("btnradiohour"));
            IList<IWebElement> activeTimeSlotList = timeSlot.Where(t => t.GetAttribute("disabled") == null).ToList();

            int randomTimeSlotIndexValue = rndm.Next(0, (activeTimeSlotList.Count()));
            var id = activeTimeSlotList[randomTimeSlotIndexValue].GetAttribute("id");
            var lblTimeSlot = driver.FindElement(By.Id("lbltimeslot-" + id.Split("-")[1]));

            lblTimeSlot.Click();
            Thread.Sleep(2000);

            #endregion selecttime



            #region selectkat
            //Kat Seçimi
            IList<IWebElement> areaList = driver.FindElements(By.Name("btnradioArea"));


            int randomAreaIndexValue = rndm.Next(0, (areaList.Count()));
            var areaId = areaList[randomAreaIndexValue].GetAttribute("id");
            var kat = areaId.Split("-")[1];

            if (kat == "1")
                randomPersonNumberMax = 6;
            else
                randomPersonNumberMax = 8;

            var lblArea = driver.FindElement(By.Id("lblAreaKat-" + (areaId.Split("-")[1])));
            lblArea.Click();
            //Thread.Sleep(2000);
            #endregion selectkat


            #region selectperson
            //Kişi Seçimi

            int randomPersonNumber = rndm.Next(1, randomPersonNumberMax);

            for (i = 1; i < randomPersonNumber; i++)
                driver.FindElement(By.ClassName("plus")).Click();
            #endregion selectperson


            #region selecttable       
            //Masa Seçimi
            IList<IWebElement> tableList = driver.FindElements(By.ClassName("masa"));
            tableList = tableList.Where(t => int.Parse(t.GetAttribute("minperson")) <= randomPersonNumber).ToList();

            int randomTableIndexValue = rndm.Next(0, (tableList.Count()));
            var tableclick = tableList[randomTableIndexValue];
            tableclick.Click();
            #endregion selecttable


            //İsim Soyisim Tel
            driver.FindElement(By.Id("NameSurname")).SendKeys("Aslıhan BAL");
            driver.FindElement(By.Id("PhoneNumber")).SendKeys("5555555555");
            IWebElement RezervationButton = driver.FindElement(By.XPath("//div[@id='divRezervationButton']/button[@type='button']"));
            RezervationButton.SendKeys(Keys.Enter);

            //Ödeme Bilgileri
            driver.FindElement(By.Id("card-name")).SendKeys("John Doe");
            driver.FindElement(By.Id("card-number")).SendKeys("5528790000000008");
            driver.FindElement(By.Id("tarihsx")).SendKeys("12/25");
            driver.FindElement(By.Id("cvv")).SendKeys("123");
            driver.FindElement(By.Id("chkAccept")).Click();
            //Thread.Sleep(1000);


            driver.FindElement(By.XPath("//div[@class='modal-content']/div[@class='modal-footer']/button[@onclick='HideModal();']")).Click();
            //driver.FindElement(By.XPath("//div[@class='modal-content']/div[@class='modal-footer']/button[@onclick='HideModal();']")).Click();

            //driver.FindElement(By.XPath("//button[contains(text(),'Tamam')]")).Click();
            driver.FindElement(By.Id("confirm")).Click();

        }
    }
}





