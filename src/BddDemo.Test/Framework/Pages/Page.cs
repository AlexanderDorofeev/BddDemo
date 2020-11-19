using OpenQA.Selenium;
using System.Linq;

namespace BddDemo.Test.Framework.Pages
{
    public abstract class Page
    {
        protected readonly IWebDriver _driver;

        protected readonly string _baseUrl;

        public Page(IWebDriver driver, string baseUrl)
        {
            _driver = driver;
            _baseUrl = baseUrl;
        }

        public abstract bool IsCurrent { get; }

        public abstract void Navigate();

        public bool HasLink(string linkName) => _driver.FindElements(By.LinkText(linkName)).Any();

        public void ClickLink(string linkName) => _driver.FindElement(By.LinkText(linkName)).Click();
    }
    
}
