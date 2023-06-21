using OpenQA.Selenium;
using SeleniumAdvanced.Framework.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAdvanced.Framework.Pages
{
    public class HotelManagementPage : BaseWebPage
    {
        public IWebElement BtnAddd => Driver.FindElement(By.CssSelector("[class=icon-plus]"));

        public void ClickAddButton()
        {
            BtnAddd.Click();  
        }

    }
}
