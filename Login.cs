using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using DemoKule.BaseClass;

namespace DemoKule
{
    public class Login : BaseTest
    {
        string adminUrl = "http://demokule.lstyazilim.com:8088/Admin/Panel/Login";
        string kullaniciAdi = "a";
        string parola = "a";

        Random rndm = new Random();

        [SetUp]
        public void Setup()
        {
            PropertiesCollection.driver.Url = adminUrl;
        }

        [Test]
        [Parallelizable]
        public void Test()
        {
            Console.WriteLine("Login sayfasi acildi");
            PropertiesCollection.driver.FindElement(By.Id("txtkull")).SendKeys(kullaniciAdi);
            PropertiesCollection.driver.FindElement(By.Id("txtparola")).SendKeys(parola);
            PropertiesCollection.driver.FindElement(By.Id("btngirs")).Click();
            Thread.Sleep(2000);

            PropertiesCollection.driver.FindElement(By.LinkText("5")).Click();

            #region RezervasyonListe
            int selectItemNumber = 0;
            int selectTableNumber = 0;
            int selectTimeSlotNumber = 0;

            PropertiesCollection.driver.FindElement(By.XPath("//ul[@class='menu-content']/li/a[@onclick='onSuccessGetReservationList()']")).Click();

            IList<IWebElement> itemListEdit = PropertiesCollection.driver.FindElements(By.XPath("//table[@id='reservationTable']/tbody/tr/td/input[@value='Düzenle']"));
            selectItemNumber = rndm.Next(1, itemListEdit.Count());
            itemListEdit[selectItemNumber - 1].Click();

            Thread.Sleep(2000);

            PropertiesCollection.driver.FindElement(By.Id("NameSurname")).Clear();
            PropertiesCollection.driver.FindElement(By.Id("NameSurname")).SendKeys("Ali Yılmaz");
            PropertiesCollection.driver.FindElement(By.Id("PhoneNumber")).Clear();
            PropertiesCollection.driver.FindElement(By.Id("PhoneNumber")).SendKeys("5554444444");
            PropertiesCollection.driver.FindElement(By.Id("Email")).Clear();
            PropertiesCollection.driver.FindElement(By.Id("Email")).SendKeys("slhnbl@gmail.com");


            //Kat seç
            IWebElement drpKat = PropertiesCollection.driver.FindElement(By.Id("AreaId"));
            SelectElement selectKat = new SelectElement(drpKat);

            Thread.Sleep(2000);
            selectKat.SelectByValue("2");

            //Tarih Seçimi

            int selectDay = 0;
            int selectMonth = 0;
            var reservationDate = PropertiesCollection.driver.FindElement(By.Id("ReservationDate")).GetAttribute("value");
            var reservationYear = reservationDate.Split(".")[2];
            int reservationMonth = Convert.ToInt32(reservationDate.Split(".")[1]);
            //int reservationDay = Convert.ToInt32(reservationDate.Split(".")[0]);                       

            PropertiesCollection.driver.FindElement(By.Id("ReservationDate")).Click(); //Takvimi aç

            if (PropertiesCollection.driver.FindElement(By.Id("mc-current--year")).Text.Equals(reservationYear.ToString()))
            {

                selectMonth = rndm.Next(reservationMonth, 12);

                for (int j = reservationMonth; j < selectMonth; j++)
                {
                    PropertiesCollection.driver.FindElement(By.Id("mc-picker__month--next")).Click();
                }

                IList<IWebElement> activeDayList = PropertiesCollection.driver.FindElements(By.XPath("//tbody[@class='mc-table__body']/tr[@class='mc-table__week']/td[@class!='mc-date mc-date--inactive']"));

                selectDay = rndm.Next(1, activeDayList.Count());
                activeDayList[selectDay - 1].Click();
            }


            //Saat dilimi seç
            IWebElement timeSlot = PropertiesCollection.driver.FindElement(By.Id("TimeSlotId"));
            SelectElement selecttimeSlot = new SelectElement(timeSlot);

            IList<IWebElement> selecttimeSlotList = PropertiesCollection.driver.FindElements(By.XPath("//select[@id='TimeSlotId']/option"));

            selectTimeSlotNumber = rndm.Next(1, selecttimeSlotList.Count() + 1);
            Thread.Sleep(2000);
            selecttimeSlot.SelectByIndex(selectTimeSlotNumber - 1);



            //Masa seç
            IWebElement table = PropertiesCollection.driver.FindElement(By.Id("TableId"));
            SelectElement selectTable = new SelectElement(table);

            IList<IWebElement> selectTableList = PropertiesCollection.driver.FindElements(By.XPath("//select[@id='TableId']/option"));

            selectTableNumber = rndm.Next(1, selectTableList.Count() + 1);

            Thread.Sleep(2000);
            selectTable.SelectByIndex(selectTableNumber - 1);


            PropertiesCollection.driver.FindElement(By.XPath("//div/button[@class='btn btn-primary mr-sm-1 mb-1 mb-sm-0']")).Click();
            PropertiesCollection.driver.FindElement(By.XPath("//div[@class='swal2-buttonswrapper']/button[@class='swal2-confirm swal2-styled']")).Click();

            #endregion RezervasyonListe


            #region MasaAyarları

            PropertiesCollection.driver.FindElement(By.XPath("//ul[@class='menu-content']/li/a[@onclick='onSuccessGetTableConfiguration()']")).Click();

            IList<IWebElement> tableList = PropertiesCollection.driver.FindElements(By.XPath("//table[@id='masaTable']/tbody/tr/td/input[@class='form-control']"));


            selectTableNumber = rndm.Next(1, tableList.Count());
            tableList[selectTableNumber - 1].Click();

            //driver.FindElement(By.Id("//select[@id='AreaId']")).SendKeys(Keys.Enter);
            //driver.FindElement(By.XPath("//select[@id='AreaId']/option[@value='2']")).Click();


            IWebElement element = PropertiesCollection.driver.FindElement(By.Id("AreaId"));
            SelectElement select_elem = new SelectElement(element);

            Thread.Sleep(4000);

            select_elem.SelectByValue("2");

            #endregion MasaAyarları


            #region MasaDurumları

            PropertiesCollection.driver.FindElement(By.XPath("//ul[@class='menu-content']/li/a[@onclick='onSuccessTableInformation()']")).Click();
            PropertiesCollection.driver.FindElement(By.XPath("//button[@onclick='showByArea(2)']")).Click();

            #endregion MasaDurumları

        }
    }
}
