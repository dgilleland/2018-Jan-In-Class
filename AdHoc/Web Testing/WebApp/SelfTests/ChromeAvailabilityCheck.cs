using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xunit;

namespace WebApp.SelfTests
{
    public class ChromeAvailabilityCheck
    {
        [Fact]
        public void CanGoogle()
        {
            var driver = new ChromeDriver();
            driver.Url = "https://www.google.ca";
            driver.Navigate();

        }
    }
}