using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BddDemo.Test.Framework.Pages
{
    public class LoginPage : Page
    {
        private const string RELATIVE_URL = "/Home/Login";

        private IReadOnlyDictionary<string, string> _fieldMap = new Dictionary<string, string>
        {
            { "Имя пользователя","UserName"},
            { "Пароль","Password"}
        };

        public LoginPage(IWebDriver driver, string baseUrl) : base(driver, baseUrl)
        {
        }

        public override bool IsCurrent => new Uri(_driver.Url).AbsolutePath.ToLowerInvariant() == RELATIVE_URL.ToLowerInvariant();

        public override void Navigate()
        {
            _driver.Url = string.Concat(_baseUrl, RELATIVE_URL);
        }

        public void ClickButton(string name)
        {
            _driver.FindElement(By.CssSelector($"[value=\"{name}\"]")).Click();
        }

        public void SetInputValue(string name,string value) 
        {
            var fieldName = GetFieldName(name);
            _driver.FindElement(By.CssSelector($"input[name=\"{fieldName}\"]")).SendKeys(value);
        }

        public void ClearInputValue(string name)
        {
            var fieldName = GetFieldName(name);
            _driver.FindElement(By.CssSelector($"input[name=\"{fieldName}\"]")).Clear();
        }

        public string GetFieldErrror(string name) 
        {
            var fieldName = GetFieldName(name);
            return _driver.FindElement(By.Id(fieldName + "-error")).Text;
        }

        public string ErrorMessage { get => _driver.FindElement(By.Id("errorMessage")).Text; }

        private string GetFieldName(string name)
        {
            return _fieldMap.ContainsKey(name) ? _fieldMap[name] : name;
        }
    }
}
