using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using FluentAssertions;
using OpenQA.Selenium;
using BddDemo.Test.Framework.Pages;
using OpenQA.Selenium.Chrome;
using BddDemo.Test.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BddDemo.Test.Steps
{
    [Binding]
    public partial class AuthenticationSteps:Features.AuthenticationFeature,IDisposable 
    {
        private readonly IWebDriver _driver=new ChromeDriver();
        private readonly string _baseUrl= "https://localhost:5001";

        private readonly ScenarioContext _scenarioContext;
        private readonly Sut _sut;

        public AuthenticationSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _sut = new Sut(_driver, _baseUrl);
        }

        [Given(@"пользователь зашел на главную страницу")]
        public void GivenПользовательЗашелНаГлавнуюСтраницу()
        {
            _sut.MainPage.Navigate();
        }


        [Then(@"доступна ссылка ""(.*)""")]
        public void ThenДоступнаСсылка(string label)
        {
            _sut.MainPage.HasLink(label).Should().BeTrue();
        }

        [Then(@"недоступна ссылка ""(.*)""")]
        public void ThenНедоступнаСсылка(string label)
        {
            _sut.MainPage.HasLink(label).Should().BeFalse();
        }

       

        [When(@"пользователь нажал на ссылку ""(.*)""")]
        public void WhenПользовательНажалНаСсылку(string linkName)
        {
            _sut.MainPage.ClickLink(linkName);
        }

        [Then(@"должна открыться страница авторизации")]
        public void ThenДолжнаОткрытьсяСтраницаАвторизации()
        {
            _sut.LoginPage.IsCurrent.Should().BeTrue();
        }

        [When(@"пользователь авторизовался")]
        public void WhenПользовательАвторизовался()
        {
            _sut.LoginPage.SetInputValue("UserName", "partner");
            _sut.LoginPage.SetInputValue("Password", "secret");
            _sut.LoginPage.ClickButton("Вход");
        }

        [Then(@"пользователь должен быть перенаправлен на главную страницу")]
        public void ThenПользовательДолженБытьПеренаправленНаГлавнуюСтраницу()
        {
            _sut.MainPage.IsCurrent.Should().BeTrue();
        }

        [Then(@"пользователь должен быть перенаправлен в партнерский раздел")]
        public void ThenПользовательДолженБытьПеренаправленВПартнерскийРаздел()
        {
            _sut.PartnerPage.IsCurrent.Should().BeTrue();
        }

        [Given(@"пользователь зашел на страницу авторизации")]
        public void GivenПользовательЗашелНаСтраницуАвторизации()
        {
            _sut.LoginPage.Navigate();
        }

        [When(@"пользователь нажал на кнопку ""(.*)""")]
        public void WhenПользовательНажалНаКнопку(string buttonName)
        {
            _sut.LoginPage.ClickButton(buttonName);
        }

        [Given(@"пользователь ввел ""(.*)"" в поле ""(.*)""")]
        public void GivenПользовательВвелВПоле(string fieldValue, string fieldName)
        {
            _sut.LoginPage.SetInputValue(fieldName, fieldValue);
        }

        [Given(@"пользователь оставил поле ""(.*)"" пустым")]
        public void GivenПользовательОставилПолеПустым(string fieldName)
        {
            _sut.LoginPage.ClearInputValue(fieldName);
        }

        [Then(@"появилось сообщение ""(.*)"" у поля ""(.*)""")]
        public void ThenПоявилосьСообщениеУПоля(string error, string fieldName)
        {
            _sut.LoginPage.GetFieldErrror(fieldName).Should().Be(error);
        }

        [Then(@"пользователь остался на странице авторизации")]
        public void ThenПользовательОсталсяНаСтраницеАвторизации()
        {
            _sut.LoginPage.IsCurrent.Should().BeTrue();
        }


        [Then(@"появилось сообщение об ошибке ""(.*)""")]
        public void ThenПоявилосьСообщение(string errorMessage)
        {
            _sut.LoginPage.ErrorMessage.Should().Be(errorMessage);
        }

        [Given(@"пользователь неавторизованный пользовователь пытается перейти на партнерский раздел сайта по прямой ссылке")]
        public void GivenПользовательНеавторизованныйПользововательПытаетсяПерейтиНаПартнерскийРазделСайтаПоПрямойСсылке()
        {
            _sut.PartnerPage.Navigate();
        }

        [Then(@"пользователь должен быть перенаправлен на страницу авторизации")]
        public void ThenПользовательДолженБытьПеренаправленНаСтраницуАвторизации()
        {
            _sut.LoginPage.IsCurrent.Should().BeTrue();
        }


        public void Dispose()
        {
            _driver.Close();
            _driver.Dispose();
        }
    }
}
