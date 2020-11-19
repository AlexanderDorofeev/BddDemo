using OpenQA.Selenium;
using System;
using System.Linq;

namespace BddDemo.Test.Framework.Pages
{
    public class MainPage : Page
    {
        public MainPage(IWebDriver driver,string baseUrl) 
            : base(driver,baseUrl)
        {
        }

        public override bool IsCurrent
        {
            get
            {
                var uri = new Uri(_driver.Url).AbsolutePath.ToLowerInvariant();
                return uri == string.Empty || uri == "/" || uri == "/home";
            }
        }

        public override void Navigate()
        {
            _driver.Url = string.Concat(_baseUrl, "/Home");
        }

    }
}
