using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace GithubTest_53_Hao
{
    [TestClass]
    public class TestCreate_53_Hao
    {
        public PhuongThucChung_53_Hao method_53_Hao = new PhuongThucChung_53_Hao();
        [TestInitialize]
        public void Init()
        {
            method_53_Hao.Login_53_Hao();
        }
        [TestMethod]
        public void TC1_TaorepositoryThanhCong_53_Hao()
        {
                string nameRepo_53_Hao = "TC1_KTPM_Thanhcong_53_Hao10";
                // Chờ 2 giây để load web
                Thread.Sleep(2000);

                // Click vào nút tạo repository
                method_53_Hao.driver_53_Hao.FindElement(By.XPath("/html/body/div[1]/div[5]/div/div/aside/div/div/loading-context/div/div[1]/div/div[1]/a")).Click();

                // Chờ 2 giây để load web
                Thread.Sleep(2000);

                // Nhập tên repository
                IWebElement nameRespoEle_53_Hao = method_53_Hao.driver_53_Hao.FindElement(By.CssSelector("#\\:r9\\:"));
                nameRespoEle_53_Hao.SendKeys(nameRepo_53_Hao);

                // Nhấn nút tạo repository
                Thread.Sleep(2000);
                method_53_Hao.driver_53_Hao.FindElement(By.ClassName("jLvIcQ")).Click();
                // Chờ để load lấy url
                Thread.Sleep(5000);
                // Lấy url
                string currentUrl_53_Hao = method_53_Hao.driver_53_Hao.Url;
                Console.WriteLine("Actual URL: " + method_53_Hao.driver_53_Hao.Url);
                // Pass: url nếu tạo thành công sẽ chứa tên repo vừa tạo
                Assert.IsTrue(currentUrl_53_Hao.Contains(nameRepo_53_Hao), "URL không chứa tên repository!");
        }
        [TestMethod]
        public void TC2_TaoRepoThatBaiRepoNameDaTonTai_53_Hao()
        {
            string existingRepoName = "KTPM"; // Tên repository đã tồn tại
            string expectedErrorMessage = "The repository " + existingRepoName + " already exists on this account.";
            try
            {
                // 1. Mở trang tạo repository
                Thread.Sleep(2000);
                method_53_Hao.driver_53_Hao.FindElement(By.XPath("/html/body/div[1]/div[5]/div/div/aside/div/div/loading-context/div/div[1]/div/div[1]/a")).Click();
                Thread.Sleep(2000);

                // 2. Nhập tên repository trùng/sai định dạng
                IWebElement nameRespoInput_53_Hao = method_53_Hao.driver_53_Hao.FindElement(By.CssSelector("#\\:r9\\:"));
                nameRespoInput_53_Hao.SendKeys(existingRepoName);

                // Nhấn nút tạo repository
                Thread.Sleep(2000);
                method_53_Hao.driver_53_Hao.FindElement(By.ClassName("jLvIcQ")).Click();
                Thread.Sleep(5000);

                // 4. Kiểm tra THẤT BẠI NHƯ MONG ĐỢI (verify error message)
                IWebElement errorElement = method_53_Hao.driver_53_Hao.FindElement(
                           By.Id("RepoNameInput-message"));
                Assert.IsTrue(errorElement.Text.Contains(expectedErrorMessage),
           $"Thông báo lỗi không khớp. Mong đợi: '{expectedErrorMessage}', Thực tế: '{errorElement.Text}'");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Test case không chạy đúng: {ex.Message}");
            }
        }
        [TestMethod]
        public void TC3_TaoRepoThatBaiRepoNameTrong_53_Hao()
        {
            string existingRepoName = ""; 
            string expectedErrorMessage = "New repository name must not be blank";
            try
            {
                // 1. Mở trang tạo repository
                Thread.Sleep(2000);
                method_53_Hao.driver_53_Hao.FindElement(By.XPath("/html/body/div[1]/div[5]/div/div/aside/div/div/loading-context/div/div[1]/div/div[1]/a")).Click();
                Thread.Sleep(2000);

                // 2. Nhập tên repository là chuỗi rỗng
                IWebElement nameRespoInput_53_Hao = method_53_Hao.driver_53_Hao.FindElement(By.CssSelector("#\\:r9\\:"));
                nameRespoInput_53_Hao.SendKeys(existingRepoName);

                // Nhấn nút tạo repository
                Thread.Sleep(2000);
                method_53_Hao.driver_53_Hao.FindElement(By.ClassName("jLvIcQ")).Click();
                Thread.Sleep(5000);

                // 4. Kiểm tra THẤT BẠI NHƯ MONG ĐỢI (verify error message)
                IWebElement errorElement = method_53_Hao.driver_53_Hao.FindElement(
                           By.Id("RepoNameInput-message"));
                Assert.IsTrue(errorElement.Text.Contains(expectedErrorMessage),
           $"Thông báo lỗi không khớp. Mong đợi: '{expectedErrorMessage}', Thực tế: '{errorElement.Text}'");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Test case không chạy đúng: {ex.Message}");
            }
        }
    }
}
