using OfficeOpenXml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using WindowsFormsApp1;

// Khai báo namespace cho unit test
namespace HinhTronTest_53_Hao
{
    // Đánh dấu lớp này là lớp chứa các test case
    [TestClass]
    public class UnitTestHT_53_Hao
    {
        // Test case 1: Kiểm tra tính chu vi với kết quả đúng
        [TestMethod]
        public void TC1_TinhChuVi_Pass_53_Hao()
        {
            // Chuẩn bị dữ liệu test
            double expected_53_Hao, actual_53_Hao;
            HinhTron_53_Hao tron_53_Hao = new HinhTron_53_Hao(1.0);

            // Thực hiện tính toán và gán giá trị mong đợi
            expected_53_Hao = 6.283;
            actual_53_Hao = tron_53_Hao.TinhChuVi_53_Hao();

            // So sánh kết quả
            Assert.AreEqual(expected_53_Hao, actual_53_Hao, 0.01, "TC1: Tính chu vi đúng");
        }
        // Test case 2: Kiểm tra tính chu vi với kết quả sai
        [TestMethod]
        public void TC2_TinhChuVi_Failed_53_Hao()
        {
            // Chuẩn bị dữ liệu test
            double expected_53_Hao, actual_53_Hao;
            HinhTron_53_Hao tron_53_Hao = new HinhTron_53_Hao(1.0);

            // Thực hiện tính toán và gán giá trị mong đợi sai
            expected_53_Hao = 7.7;
            actual_53_Hao = tron_53_Hao.TinhChuVi_53_Hao();

            // So sánh kết quả
            Assert.AreEqual(expected_53_Hao, actual_53_Hao, 0.01, "TC1: Tính chu vi đúng");
        }

        // Test case 3: Kiểm tra tính diện tích với kết quả đúng
        [TestMethod]
        public void TC3_TinhDienTich_Pass_53_Hao()
        {
            // Chuẩn bị dữ liệu test
            double expected_53_Hao, actual_53_Hao;
            HinhTron_53_Hao tron_53_Hao = new HinhTron_53_Hao(3.0);

            // Thực hiện tính toán và gán giá trị mong đợi
            expected_53_Hao = 28.274;
            actual_53_Hao = tron_53_Hao.TinhDienTich_53_Hao();

            // So sánh kết quả
            Assert.AreEqual(expected_53_Hao, actual_53_Hao, 0.01, "TC3: Tính diện tích đúng");
        }
        // Test case 4: Kiểm tra tính diện tích với kết quả đúng
        [TestMethod]
        public void TC4_TinhDienTich_Failed_53_Hao()
        {
            // Chuẩn bị dữ liệu test
            double expected_53_Hao, actual_53_Hao;
            HinhTron_53_Hao tron_53_Hao = new HinhTron_53_Hao(3.0);

            // Thực hiện tính toán và gán giá trị mong đợi
            expected_53_Hao = 33.331;
            actual_53_Hao = tron_53_Hao.TinhDienTich_53_Hao();

            // So sánh kết quả
            Assert.AreEqual(expected_53_Hao, actual_53_Hao, 0.01, "TC3: Tính diện tích đúng");
        }
        // Khởi tạo tĩnh - chạy trước khi bất kỳ test nào được thực thi
        static UnitTestHT_53_Hao()
        {
            // Cấu hình license cho EPPlus
            ExcelPackage.License.SetNonCommercialPersonal("HinhTronTest_53_Hao");
        }

        // Đường dẫn tới file Excel chứa test data
        private const string ExcelFilePath = @"Data_53_Hao\TestData_53_Hao.xlsx";

        // Test case 3: Kiểm tra tính chu vi sử dụng dữ liệu từ Excel
        [TestMethod]
        public void TC3_TinhChuViWithDataSource_53_Hao()
        {
            try
            {
                // Tạo đường dẫn đầy đủ tới file Excel
                string fullPath = Path.Combine(Directory.GetCurrentDirectory(), ExcelFilePath);

                // Kiểm tra file có tồn tại không
                if (!File.Exists(fullPath))
                {
                    // Báo lỗi nếu không tìm thấy file
                    Assert.Fail($"File test không tồn tại: {fullPath}");
                    return;
                }

                // Mở file Excel
                using (var package = new ExcelPackage(new FileInfo(fullPath)))
                {
                    // Kiểm tra có worksheet nào không
                    if (package.Workbook.Worksheets.Count == 0)
                    {
                        Assert.Fail("File Excel không có worksheet nào");
                        return;
                    }

                    // Lấy worksheet đầu tiên
                    var worksheet = package.Workbook.Worksheets[0];

                    // Duyệt qua các dòng dữ liệu
                    for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                    {
                        // Đọc bán kính từ cột 1
                        double banKinh = worksheet.Cells[row, 1].GetValue<double>();

                        // Đọc chu vi mong đợi từ cột 2
                        double chuViDuKien = worksheet.Cells[row, 2].GetValue<double>();

                        // Tạo đối tượng hình tròn
                        var tron = new HinhTron_53_Hao(banKinh);

                        // Tính toán chu vi thực tế
                        double chuViThucTe = tron.TinhChuVi_53_Hao();

                        // So sánh kết quả
                        Assert.AreEqual(chuViDuKien, chuViThucTe, 0.1,
                                      $"Sai số ở dòng {row}. Bán kính: {banKinh}");
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ
                Assert.Fail($"Lỗi khi xử lý: {ex.Message}");
            }
        }

        // Test case 4: Kiểm tra tính diện tích sử dụng dữ liệu từ Excel
        [TestMethod]
        public void TC4_TinhDienTichWithDataSource_53_Hao()
        {
            try
            {
                // Tạo đường dẫn đầy đủ
                string fullPath = Path.Combine(Directory.GetCurrentDirectory(), ExcelFilePath);

                // Kiểm tra file tồn tại
                if (!File.Exists(fullPath))
                {
                    Assert.Fail($"File test không tồn tại: {fullPath}");
                    return;
                }

                // Mở file Excel
                using (var package = new ExcelPackage(new FileInfo(fullPath)))
                {
                    // Kiểm tra worksheet
                    if (package.Workbook.Worksheets.Count == 0)
                    {
                        Assert.Fail("File Excel không có worksheet nào");
                        return;
                    }

                    // Lấy worksheet đầu tiên
                    var worksheet = package.Workbook.Worksheets[0];

                    // Duyệt qua các dòng dữ liệu
                    for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                    {
                        // Đọc bán kính từ cột 1
                        double banKinh = worksheet.Cells[row, 1].GetValue<double>();

                        // Đọc diện tích mong đợi từ cột 3
                        double dienTichDuKien = worksheet.Cells[row, 3].GetValue<double>();

                        // Tạo đối tượng hình tròn
                        var tron = new HinhTron_53_Hao(banKinh);

                        // Tính toán diện tích thực tế
                        double dienTichThucTe = tron.TinhDienTich_53_Hao();

                        // So sánh kết quả
                        Assert.AreEqual(dienTichDuKien, dienTichThucTe, 0.1,
                                      $"Sai số ở dòng {row}. Bán kính: {banKinh}");
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ
                Assert.Fail($"Lỗi khi xử lý: {ex.Message}");
            }
        }
    }
}