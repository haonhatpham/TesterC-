using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class HinhTron_53_Hao
    {
        //Khai báo biến dữ liệu bán kính 
        private double banKinh_53_Hao;
        public HinhTron_53_Hao(double banKinh_53_Hao)
        {
            //Gán giá trị của tham số vào biến dữ liệu
            this.banKinh_53_Hao = banKinh_53_Hao; 
        }
        public double TinhChuVi_53_Hao()
        {
            //Công thức tính chu vi hình tròn
            double chuVi_53_Hao = 2 * Math.PI * banKinh_53_Hao;
            //Làm tròn kết quả chu vi lên 2 chữ số thập phân
            return Math.Round(chuVi_53_Hao, 2); 
        }
        public double TinhDienTich_53_Hao()
        {
            //Công thức tính diện tích hình tròn
            double dienTich_53_Hao = Math.PI * Math.Pow(banKinh_53_Hao,2);
            //Làm tròn kết quả diện tích lên 2 chữ số thập phân
            return Math.Round(dienTich_53_Hao, 2); 
        }
    }
}
