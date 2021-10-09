using AutomationPracticeProject.Helpers;
using AutomationPracticeProject.WrapperElement;
using OpenQA.Selenium;

namespace AutomationPracticeProject.PageObjects
{
    public class OrderHistoryPage : BasePage
    {
        private WrapperWebElement OrdersTable => new WrapperWebElement(By.XPath("//*[@id='order-list']"));

        public string GetOrdersTableText()
        {
            LogHelper.Info("Getting the Orders Table Text");
            return OrdersTable.Text;
        }
    }
}