using BddDemo.Test.Framework.Pages;
using OpenQA.Selenium;

namespace BddDemo.Test.Framework
{
    public class  Sut
    {
        private readonly IWebDriver _driver;
        private readonly string _baseUrl;

        public Sut(IWebDriver driver, string baseUrl)
        {
            _driver = driver;
            _baseUrl = baseUrl;
            MainPage = new MainPage(driver, baseUrl);
            LoginPage = new LoginPage(driver, baseUrl);
            PartnerPage = new PartnerPage(driver, baseUrl);
        }

        public MainPage MainPage { get; }

        public LoginPage LoginPage { get; }

        public PartnerPage PartnerPage { get; }
    }
}
