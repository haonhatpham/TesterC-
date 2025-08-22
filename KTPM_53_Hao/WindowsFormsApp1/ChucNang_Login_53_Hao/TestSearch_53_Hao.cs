using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace ChucNang_Login_53_Hao
{
    [TestClass]
    public class TestSearch_53_Hao
    {

        private IWebDriver driver_53_Hao;

        [TestInitialize] // Khởi tạo trước mỗi test method.

        // Phương thức này dùng để truy cập vào trang web
        public void SetUp_53_Hao()
        {
            driver_53_Hao = new ChromeDriver(); // Khởi tạo driver bằng trình duyệt Chrome
            driver_53_Hao.Navigate().GoToUrl("https://github.com/");// Đưa url vào để mở trang web
        }
        [TestMethod]
        public void TC1_53_Hao_TimKiemVoiTuKhoaTonTai()
        {
            //Khai báo từ khóa dữ liệu đầu vào
            string keywords_40_Hao = "KTPM";
            //Điều hướng tới trang web
            driver_53_Hao.Navigate().GoToUrl("https://github.com/");
            //Nhấn vào button tìm kiếm
            driver_53_Hao.FindElement(By.XPath("/html/body/div[1]/div[3]/header/div/div[2]/div/div/qbsearch-input/div[1]/button")).Click();
            //Lấy input của nút tìm kiếm
            IWebElement inputSearch_53_Hao = driver_53_Hao.FindElement(By.Name("query-builder-test"));
            // Nhập từ khóa vào ô tìm kiếm
            inputSearch_53_Hao.SendKeys(keywords_40_Hao);
            // Chờ 2 giây để load web
            Thread.Sleep(2000);
            // Nhấn Enter tìm kiếm
            inputSearch_53_Hao.SendKeys(Keys.Enter);
            //Lấy số lượng kết quả sau khi tìm kiếm
            WebDriverWait wait = new WebDriverWait(driver_53_Hao, TimeSpan.FromSeconds(10));
            IWebElement searchResult_53_Hao = wait.Until(d => d.FindElement(By.ClassName("jJRiHe")));
            string actualResult_53_Hao = searchResult_53_Hao.Text.Trim();
            if (searchResult_53_Hao != null && !searchResult_53_Hao.Text.Contains("0 results"))
            {
                // In ra dòng chữ " Đã tìm thấy sản phẩm " cùng với tên sản phẩm đó
                Console.WriteLine("TC1_Search_53_Hao \n Da tim thay ket qua lien quan: " + keywords_40_Hao);
                Assert.IsTrue(true); // Xác nhận tìm thấy sản phẩm thành công bằng Assert
            }
            else
            {
                Assert.IsTrue(false);

            }
            // Đóng trình duyệt sau khi hoàn thành công việc
            driver_53_Hao.Quit();  
        }
        [TestMethod]
        public void TC2_53_Hao_TimKiemTuKhoaKhongTonTai()
        {
            //Khai báo từ khóa dữ liệu đầu vào
            string keywords_40_Hao = "axxxxxxxxxxabc";
            //Điều hướng tới trang web
            driver_53_Hao.Navigate().GoToUrl("https://github.com/");
            //Nhấn vào button tìm kiếm
            driver_53_Hao.FindElement(By.XPath("/html/body/div[1]/div[3]/header/div/div[2]/div/div/qbsearch-input/div[1]/button")).Click();
            //Lấy input của nút tìm kiếm
            IWebElement inputSearch_53_Hao = driver_53_Hao.FindElement(By.Name("query-builder-test"));
            // Nhập từ khóa vào ô tìm kiếm
            inputSearch_53_Hao.SendKeys(keywords_40_Hao);
            // Chờ 2 giây để load web
            Thread.Sleep(2000);
            // Nhấn Enter tìm kiếm
            inputSearch_53_Hao.SendKeys(Keys.Enter);
            //Lấy số lượng kết quả sau khi tìm kiếm
            WebDriverWait wait = new WebDriverWait(driver_53_Hao, TimeSpan.FromSeconds(10));
            IWebElement searchResult_53_Hao = wait.Until(d => d.FindElement(By.ClassName("jJRiHe")));
            string actualResult_53_Hao = searchResult_53_Hao.Text.Trim();
            string resultexpected_53_Hao = "0 results";
            Assert.AreEqual(actualResult_53_Hao, resultexpected_53_Hao);
            driver_53_Hao.Quit();
        }
    }
}
