using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class GoogleResultsPage
    {
        private IWebDriver driver;
        private IList<IWebElement> Result;
        ReadOnlyCollection <IWebElement> searchResults;
        private WebDriverWait wait;
        public GoogleResultsPage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
        public bool ResultsDisplayed()
        {
            IWebElement reasultsPanel = driver.FindElement(By.Id("search"));
            wait.Until//תחכה עד שהאלמנט יהיה במצב IsVisible
                (SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible((By.XPath(".//a") )) )   ;
            //פונקציה למציאת כל הערכים שעלו בדפדפן
            searchResults = reasultsPanel.FindElements(By.XPath(".//a"));
            //החזר רק אם יש תוצאות
            return searchResults.Count() > 0;
        }


        public string GetFirstResultTitle()
        {
            return searchResults[0].FindElement(By.TagName("h3")).Text;
        }
        public void ClickFirstResult()
        {
            searchResults[0].FindElement(By.TagName("h3")).Click();
        }
    }



    
}
