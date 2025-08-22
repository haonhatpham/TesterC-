using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmHT_53_Hao : Form
    {
        public frmHT_53_Hao()
        {
            InitializeComponent();
        }

        private void btnTinh_53_Hao_Click(object sender, EventArgs e)
        {   //Khai báo 3 biến
            double banKinh_53_Hao, chuVi_53_Hao, dienTich_53_Hao;
            //Lấy giá trị từ txt gán vào biến
            banKinh_53_Hao = double.Parse(txtBK_53_Hao.Text); 
            HinhTron_53_Hao tron_53_Hao = new HinhTron_53_Hao(banKinh_53_Hao); //Tạo một đối tượng mới
            //Lấy phương thức và gán vào biến chu vi
            chuVi_53_Hao = tron_53_Hao.TinhChuVi_53_Hao();
            //Lấy phương thức và gán vào biến diện tích
            dienTich_53_Hao = tron_53_Hao.TinhDienTich_53_Hao();
            //Hiển thị kết quả chu vi vào ô txt
            txtCV_53_Hao.Text = chuVi_53_Hao.ToString();
            //Hiển thị kết quả diện tích vào ô txt
            txtDT_53_Hao.Text = dienTich_53_Hao.ToString();
        }
    }
}
