using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace BddDemo.Test.Framework.Pages
{
    public class PartnerPage : Page
    {
        private const string RELATIVE_URL = "/Home/Partners";
        public PartnerPage(IWebDriver driver, string baseUrl) : base(driver, baseUrl)
        {
        }

        public override bool IsCurrent => new Uri(_driver.Url).AbsolutePath.ToLowerInvariant() == RELATIVE_URL.ToLowerInvariant();

        public override void Navigate()
        {
            _driver.Url = string.Concat(_baseUrl, RELATIVE_URL);
        }
    }
}
