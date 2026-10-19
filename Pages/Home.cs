using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomatedScript.Pages
{
    public class Home
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public Home(IWebDriver Driver, WebDriverWait Wait)
        {
            driver = Driver;
            wait = Wait;
        }

        private IWebElement SearchButton => wait.Until(d => driver.FindElement(By.Id("nav-search-submit-button")));
        private IWebElement SearchTextBox => wait.Until(d => driver.FindElement(By.Id("twotabsearchtextbox")));
        private IWebElement ContinueShoppingButton => wait.Until(d => driver.FindElement(By.XPath("//button[@class='a-button-text' and text()='Continue shopping']")));
        private IWebElement btnStayOnAmazon => wait.Until(d => driver.FindElement(By.Id("redir-stay-at-www")));

        public void SearchFor(string inputParameter)
        {
            SearchTextBox.SendKeys(inputParameter);
            SearchButton.Click();
        }

        public void ContinueShopping()
        {
            try
            {
                if (ContinueShoppingButton.Displayed)
                {
                    ContinueShoppingButton.Click();
                }
            }
            catch 
            {
                Console.WriteLine("Continue shopping button was not displayed. Continuing execution...");
            }
        }

        public void StayOnAmazon()
        {
            try
            {
                if (btnStayOnAmazon.Displayed)
                {
                    btnStayOnAmazon.Click();
                }
            }
            catch
            {
                Console.WriteLine("Stay on Amazon.com button was not displayed. Continuing execution...");
            }
        }
    }
}