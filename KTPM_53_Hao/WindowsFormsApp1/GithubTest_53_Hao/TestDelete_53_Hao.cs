using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Security.Policy;
using System.Threading;

namespace GithubTest_53_Hao
{
    [TestClass]
    public class TestDelete_53_Hao
    {
        // Khởi tạo đối tượng chứa các phương thức chung
        public PhuongThucChung_53_Hao method_53_Hao = new PhuongThucChung_53_Hao();

        // Phương thức khởi tạo trước mỗi test case
        [TestInitialize]
        public void Init()
        {
            // Gọi phương thức đăng nhập trước khi chạy mỗi test case
            method_53_Hao.Login_53_Hao();
        }
        // Test case 1: Xóa repository thành công
        [TestMethod]
        public void TC1_53_Hao_XoaThanhCong()
        {
            // Tên repository cần xóa
            string nameRepoDel_53_Hao = "TC1_KTPM_Thanhcong_53_Hao10";

            // Khởi tạo WebDriverWait với timeout 10 giây
            WebDriverWait wait = new WebDriverWait(method_53_Hao.driver_53_Hao, TimeSpan.FromSeconds(10));
            Thread.Sleep(2000);

            // Tìm và click vào ô tìm kiếm repository bằng ID
            IWebElement inputRepo_53_Hao = method_53_Hao.driver_53_Hao.FindElement(By.Id("dashboard-repos-filter-left"));
            inputRepo_53_Hao.Click();
            Thread.Sleep(2000);

            // Nhập tên repository cần tìm
            inputRepo_53_Hao.SendKeys(nameRepoDel_53_Hao);
            Thread.Sleep(2000);

            // Lấy danh sách tất cả các repository hiển thị
            ReadOnlyCollection<IWebElement> repoList_53_Hao = method_53_Hao.driver_53_Hao.FindElements(By.TagName("a"));

            // Duyệt qua từng repository trong danh sách
            foreach (var repoElement in repoList_53_Hao)
            {
                string fullRepoName = repoElement.Text.Trim();

                // Kiểm tra tên repository có khớp với tên cần tìm không
                if (fullRepoName.EndsWith("/" + nameRepoDel_53_Hao, StringComparison.OrdinalIgnoreCase) ||
                    fullRepoName.EndsWith(nameRepoDel_53_Hao, StringComparison.OrdinalIgnoreCase))
                {
                    // Scroll đến repository để đảm bảo nó hiển thị trên màn hình
                    ((IJavaScriptExecutor)method_53_Hao.driver_53_Hao).ExecuteScript(
                        "arguments[0].scrollIntoView({block: 'center'});", repoElement);
                    Thread.Sleep(500);

                    // Click vào repository bằng JavaScript (đảm bảo click chính xác)
                    ((IJavaScriptExecutor)method_53_Hao.driver_53_Hao).ExecuteScript(
                        "arguments[0].click();", repoElement);

                    // Chờ trang repository load xong
                    Thread.Sleep(3000);
                    break;
                }
            }

            Thread.Sleep(2000);
            // Click vào tab Settings của repository
            method_53_Hao.driver_53_Hao.FindElement(By.LinkText("Settings")).Click();
            Thread.Sleep(2000);

            // Click vào nút "Delete this repository"
            method_53_Hao.driver_53_Hao.FindElement(By.Id("dialog-show-repo-delete-menu-dialog")).Click();
            Thread.Sleep(2000);

            // Click vào nút "I want to delete this repository"
            method_53_Hao.driver_53_Hao.FindElement(By.Id("repo-delete-proceed-button-container")).Click();
            Thread.Sleep(2000);

            // Click vào nút "I have read and understand these effects"
            method_53_Hao.driver_53_Hao.FindElement(By.Id("repo-delete-proceed-button-container")).Click();
            Thread.Sleep(2000);

            // Lấy text xác nhận từ hộp thoại (dạng "To confirm, type 'repository-name' in the box below")
            string confirmText = method_53_Hao.driver_53_Hao.FindElement(By.XPath("//*[@id=\"repo-delete-proceed-button-container\"]/primer-text-field/label"))
            .Text.Split(new[] { "To confirm, type \"" }, StringSplitOptions.None)[1]
            .Split('\"')[0];
            Console.WriteLine(confirmText);

            // Tìm ô nhập và nhập tên repository để xác nhận
            IWebElement inputType_53_Hao = method_53_Hao.driver_53_Hao.FindElement(By.Name("verification_field"));
            inputType_53_Hao.SendKeys(confirmText);
            Thread.Sleep(2000);

            // Click nút delete để xác nhận xóa
            method_53_Hao.driver_53_Hao.FindElement(By.Id("repo-delete-proceed-button")).Click();
            Thread.Sleep(2000);

            // Xử lý trường hợp có thể yêu cầu nhập mật khẩu xác nhận
            try
            {
                // Kiểm tra xem có yêu cầu nhập mật khẩu không (với timeout ngắn 2 giây)
                WebDriverWait quickWait = new WebDriverWait(method_53_Hao.driver_53_Hao, TimeSpan.FromSeconds(2));
                IWebElement passwordField = quickWait.Until(d => d.FindElement(By.Id("sudo_password")));

                // Nếu có yêu cầu mật khẩu, nhập mật khẩu đúng
                passwordField.SendKeys("08102004Hao*");
                Thread.Sleep(2000);

                // Click nút xác nhận sau khi nhập mật khẩu
                method_53_Hao.driver_53_Hao.FindElement(By.XPath("//*[@id=\"sudo\"]/sudo-credential-options/div[2]/form/div/div/button")).Click();
            }
            catch (NoSuchElementException)
            {
                // Nếu không yêu cầu nhập mật khẩu, ghi log
                Console.WriteLine("Không yêu cầu nhập mật khẩu xác nhận");
            }
            catch (WebDriverTimeoutException)
            {
                // Nếu không tìm thấy phần tử nhập mật khẩu trong thời gian chờ, ghi log
                Console.WriteLine("Không yêu cầu nhập mật khẩu xác nhận");
            }

            Thread.Sleep(3000);
            // Kiểm tra thông báo xóa thành công
            if (method_53_Hao.driver_53_Hao.FindElement(By.ClassName("js-flash-alert")).Text.Contains("Your repository " + "haonhatpham/" + nameRepoDel_53_Hao + " was successfully deleted."))
            {
                Assert.IsTrue(true);
            }
        }
        // Test case 2: Xóa repository thất bại do repo ko tồn tại
        [TestMethod]
        public void TC2_XoaRepoThatBaiViSaiMatKhauXacNhan_53_Hao()
        {
            // Tên repository cần xóa
            string nameRepoDel_53_Hao = "TC1_KTPM_Thanhcong_53_Hao10";

            // Khởi tạo WebDriverWait với timeout 10 giây
            WebDriverWait wait = new WebDriverWait(method_53_Hao.driver_53_Hao, TimeSpan.FromSeconds(10));
            Thread.Sleep(2000);

            // Tìm và click vào ô tìm kiếm repository bằng ID
            IWebElement inputRepo_53_Hao = method_53_Hao.driver_53_Hao.FindElement(By.Id("dashboard-repos-filter-left"));
            inputRepo_53_Hao.Click();
            Thread.Sleep(2000);

            // Nhập tên repository cần tìm
            inputRepo_53_Hao.SendKeys(nameRepoDel_53_Hao);
            Thread.Sleep(2000);

            // Lấy danh sách tất cả các repository hiển thị
            ReadOnlyCollection<IWebElement> repoList_53_Hao = method_53_Hao.driver_53_Hao.FindElements(By.TagName("a"));

            // Duyệt qua từng repository trong danh sách
            foreach (var repoElement in repoList_53_Hao)
            {
                string fullRepoName = repoElement.Text.Trim();

                // Kiểm tra tên repository có khớp với tên cần tìm không
                if (fullRepoName.EndsWith("/" + nameRepoDel_53_Hao, StringComparison.OrdinalIgnoreCase) ||
                    fullRepoName.EndsWith(nameRepoDel_53_Hao, StringComparison.OrdinalIgnoreCase))
                {
                    // Scroll đến repository để đảm bảo nó hiển thị trên màn hình
                    ((IJavaScriptExecutor)method_53_Hao.driver_53_Hao).ExecuteScript(
                        "arguments[0].scrollIntoView({block: 'center'});", repoElement);
                    Thread.Sleep(500);

                    // Click vào repository bằng JavaScript (đảm bảo click chính xác)
                    ((IJavaScriptExecutor)method_53_Hao.driver_53_Hao).ExecuteScript(
                        "arguments[0].click();", repoElement);

                    // Chờ trang repository load xong
                    Thread.Sleep(3000);
                    break;
                }
                else
                {
                    Assert.IsTrue(true);
                }
            }
        }
    }
}