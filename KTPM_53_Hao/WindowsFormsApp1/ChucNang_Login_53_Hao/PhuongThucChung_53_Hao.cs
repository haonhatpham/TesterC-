using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChucNang_Login_53_Hao
{
    public class PhuongThucChung_53_Hao
    {
        public IWebDriver driver_53_Hao = new ChromeDriver();
        public PhuongThucChung_53_Hao() { }

        // Phương thức truy cập vào trang chủ github.com
        public void GoHome_53_Hao()
        {
            driver_53_Hao.Navigate().GoToUrl("https://github.com/");
        }

        // Phương thức truy cập vào trang login và thực hiện đăng nhập khi đang ở trang chủ
        public void Login_53_Hao(string username_53_Hao, string password_53_Hao)
        {
            //Truy cập vào trang chủ
            GoHome_53_Hao();

            //Truy cập vào bảng đăng nhập
            IWebElement h_login_53_Hao = driver_53_Hao.FindElement(By.CssSelector("body > div.logged-out.env-production.page-responsive.header-overlay.header-overlay-fixed.js-header-overlay-fixed > div.position-relative.header-wrapper.js-header-wrapper > header > div > div.HeaderMenu.js-header-menu.height-fit.position-lg-relative.d-lg-flex.flex-column.flex-auto.top-0 > div > div > div > a"));
            h_login_53_Hao.Click();

            //Nhập username
            IWebElement h_user1_53_Hao = driver_53_Hao.FindElement(By.Name("login"));
            h_user1_53_Hao.SendKeys(username_53_Hao);

            //Nhập password
            IWebElement h_pass_53_Hao = driver_53_Hao.FindElement(By.Name("password"));
            h_pass_53_Hao.SendKeys(password_53_Hao);

            //Click vào button đăng nhập
            IWebElement loginButton_53_Hao = driver_53_Hao.FindElement(By.Name("commit"));
            loginButton_53_Hao.Click();
        }
    }
}
