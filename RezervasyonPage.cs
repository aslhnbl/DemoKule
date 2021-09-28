using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DemoKule
{
    public class RezervasyonPage
    {
        #region Tanımlamalar 
        public int i = 0;
        public int selectDay = 0;
        public int randomPersonNumberMax = 0;
        public Random rndm = new Random();
        #endregion Tanımlamalar 

        #region WebElementler
        public By calendaricon = By.Id("calendar-icon");
        public By currentyear = By.Id("mc-current--year");
        public By monthnext = By.Id("mc-picker__month--next");
        public By activedaylistWE = By.XPath("//tbody[@class='mc-table__body']/tr[@class='mc-table__week']/td[@class!='mc-date mc-date--inactive']");

        public By timeslotWE = By.Name("btnradiohour");
        public By lbltimeslotWE = By.Id("lbltimeslot");

        public By arealistWE = By.Name("btnradioArea");

        public By addperson = By.ClassName("plus");

        public By tablelistWE = By.ClassName("masa");

        public By namesurname = By.Id("NameSurname");
        public By phonenumber = By.Id("PhoneNumber");
        public By rezervasyonbuton = By.XPath("//div[@id='divRezervationButton']/button[@type='button']");

        public By cardname = By.Id("card-name");
        public By cardnumber = By.Id("card-number");
        public By carddate= By.Id("tarihsx");          
        public By cvv = By.Id("cvv");
        public By chkaccept = By.Id("chkAccept");
        public By hidemodal = By.XPath("//div[@class='modal-content']/div[@class='modal-footer']/button[@onclick='HideModal();']");
        public By ok = By.XPath("//button[contains(text(),'Tamam')]");
        public By confirm = By.Id("confirm");

        #endregion WebElementler

        public void SelectDate(IWebDriver driver)

        {
            //SeleniumSetMethod.Click(calendaricon);
            driver.FindElement(calendaricon).Click();
            Thread.Sleep(1000);

            if (driver.FindElement(currentyear).Text.Equals(DateTime.Now.Year.ToString()))
            {
                int selectMonth = SeleniumSetMethod.Random(rndm, DateTime.Now.Month, 12);

                for (int j = DateTime.Now.Month; j < selectMonth; j++)
                {
                    //SeleniumSetMethod.Click(monthnext, PropertyType.Id);
                    driver.FindElement(monthnext).Click();
                }

                Thread.Sleep(1000);

                //IList<IWebElement> activeDayList = SeleniumSetMethod.Liste("//tbody[@class='mc-table__body']/tr[@class='mc-table__week']/td[@class!='mc-date mc-date--inactive']", "XPath");
                IList<IWebElement> activeDayList = driver.FindElements(activedaylistWE);

                //selectDay = SeleniumSetMethod.Random(rndm, 1, activeDayList.Count());
                selectDay = rndm.Next(1, activeDayList.Count);
                activeDayList[selectDay - 1].Click();
                Thread.Sleep(1000);
            }
        }

        public void SelectTime(IWebDriver driver)
        {
            IList<IWebElement> timeslot = driver.FindElements(timeslotWE);

            IList<IWebElement> activeTimeSlotList = timeslot.Where(t => t.GetAttribute("disabled") == null).ToList();
            int randomTimeSlotIndexValue = rndm.Next(0, (activeTimeSlotList.Count()));

            var id = activeTimeSlotList[randomTimeSlotIndexValue].GetAttribute("id");
            var lblTimeSlot = driver.FindElement(By.Id("lbltimeslot-" + id.Split("-")[1]));
            //var lblTimeSlot = driver.FindElement(By.Id(lbltimeslotWE + "-" + id.Split(" -")[1]));

            lblTimeSlot.Click();
            Thread.Sleep(1000);
        }

        public void SelectArea(IWebDriver driver)
        {
            IList<IWebElement> areaList = driver.FindElements(arealistWE);
            int randomAreaIndexValue = rndm.Next(0, areaList.Count());
            var areaId = areaList[randomAreaIndexValue].GetAttribute("id");
            var kat = areaId.Split("-")[1];

            if (kat == "1")
                randomPersonNumberMax = 6;
            else
                randomPersonNumberMax = 8;

            var lblArea = driver.FindElement(By.Id("lblAreaKat-" + (areaId.Split("-")[1])));
            lblArea.Click();
            Thread.Sleep(1000);

        }

        public void SelectPersonAndTable(IWebDriver driver)
        {
            int randomPersonNumber = rndm.Next(1, randomPersonNumberMax);
            for (i = 1; i < randomPersonNumber; i++)
               driver.FindElement(addperson).Click();


            IList<IWebElement> tableList = driver.FindElements(tablelistWE);
            tableList = tableList.Where(t => int.Parse(t.GetAttribute("minperson")) <= randomPersonNumber).ToList();
            int randomTableIndexValue = rndm.Next( 0, tableList.Count());
            //int randomTableIndexValue = rndm.Next(0, (tableList.Count()));
            var tableclick = tableList[randomTableIndexValue];
            tableclick.Click();
        }

        public void CompleteData(IWebDriver driver)
        {
            driver.FindElement(namesurname).SendKeys("Aslıhan BAL");
            driver.FindElement(phonenumber).SendKeys("5555555555");
            driver.FindElement(rezervasyonbuton).SendKeys(Keys.Enter);
            driver.FindElement(cardname).SendKeys("John Doe");
            driver.FindElement(cardnumber).SendKeys("5528790000000008");
            driver.FindElement(carddate).SendKeys("12/25");

            driver.FindElement(cvv).SendKeys("123");
            driver.FindElement(chkaccept).Click();
            //driver.FindElement(chkaccept).SendKeys(Keys.Enter);
            driver.FindElement(hidemodal).Click();
            driver.FindElement(ok).Click();
            driver.FindElement(confirm).SendKeys(Keys.Enter);
        
        }
    }
}

