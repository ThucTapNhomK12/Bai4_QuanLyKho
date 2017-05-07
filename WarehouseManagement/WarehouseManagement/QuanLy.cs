using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarehouseManagement.Utils;

namespace WarehouseManagement
{
    public partial class QuanLy : Form
    {
        db_warehouse_managementEntities db = new db_warehouse_managementEntities();

        public static tai_khoan USER_LOGIN = DangNhap.USER_LOGIN;

        public static hang_hoa selectedProduct = null;

        public static hang_nhap selectedCoupon = null;

        public static hang_xuat selectedBill = null;
        public QuanLy()
        {
            InitializeComponent();
        }

        private void QuanLy_Load(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabHome;
            refresh();
        }

        public void refresh()
        {
            loadNhaCungCap();
            loadHangHoa();
            loadHangNhap();
            loadHangXuat();
            loadSearchView();
            loadStatistic();
        }



        // Huong_code Hang hoa
        public void loadHangHoa()
        {
            selectedProduct = null;
            List<ActionForm> listAction = new List<ActionForm>()
            {
                new ActionForm("choose", "Chọn thao tác"),
                new ActionForm("create", "Thêm sản phẩm"),
                new ActionForm("update", "Sửa thông tin"),
                new ActionForm("delete", "Xóa sản phẩm")
            };
            cbProductAction.DataSource = listAction;
            cbProductAction.DisplayMember = "action";
            cbProductAction.ValueMember = "key";
            dgvHangHoa.DataSource = new db_warehouse_managementEntities().hang_hoa.ToList();
        }


        // end Huong
        public void loadSearchView()
        {
            List<ActionForm> listAction = new List<ActionForm>()
            {
                new ActionForm("default", "Chọn tiêu chí"),
                new ActionForm("product_id", "Mã hàng hóa"),
                new ActionForm("supplier", "Nhà cung cấp")
            };
            cbSearchType.DataSource = listAction;
            cbSearchType.DisplayMember = "action";
            cbSearchType.ValueMember = "key";
            dgvSearch.DataSource = new db_warehouse_managementEntities().hang_hoa.ToList();
        }

        private void cbSearchType_SelectedValueChanged(object sender, EventArgs e)
        {
            string selectedType = cbSearchType.SelectedValue.ToString();
            switch (selectedType)
            {
                case "product_id":
                    cbSearchValue.DataSource = new db_warehouse_managementEntities().hang_hoa.ToList();
                    cbSearchValue.DisplayMember = "ma_hang_hoa";
                    cbSearchValue.ValueMember = "ma_hang_hoa";
                    break;
                case "supplier":
                    cbSearchValue.DataSource = new db_warehouse_managementEntities().nha_cung_cap.ToList();
                    cbSearchValue.DisplayMember = "ten_nha_cung_cap";
                    cbSearchValue.ValueMember = "ma_nha_cung_cap";
                    break;
            }
        }

        private void dgvSearch_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvSearch.Columns[e.ColumnIndex].Name == "search_ma_nha_cung_cap")
            {
                if (e.Value != null)
                {
                    nha_cung_cap supplier = db.nha_cung_cap.Find(e.Value);
                    e.Value = supplier.ten_nha_cung_cap;
                }
            }
            if (this.dgvSearch.Columns[e.ColumnIndex].Name == "search_don_gia")
            {
                if (e.Value != null)
                {
                    e.Value = String.Format("{0:0,0}", e.Value);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int selectedValue = int.Parse(cbSearchValue.SelectedValue.ToString());
            string selectedType = cbSearchType.SelectedValue.ToString();
            switch (selectedType)
            {
                case "product_id":
                    dgvSearch.DataSource = db.hang_hoa.Where(x => x.ma_hang_hoa == selectedValue).ToList();
                    break;
                case "supplier":
                    dgvSearch.DataSource = db.hang_hoa.Where(x => x.ma_nha_cung_cap == selectedValue).ToList();
                    break;
            }

        }



        public void loadStatistic()
        {
            List<ActionForm> listAction = new List<ActionForm>()
            {
                new ActionForm("default", "Chọn tiêu chí"),
                new ActionForm("coupon", "Hàng nhập"),
                new ActionForm("bill", "Hàng xuất")
            };
            cbStatisticType.DataSource = listAction;
            cbStatisticType.DisplayMember = "action";
            cbStatisticType.ValueMember = "key";
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            try
            {
                double sum = 0;
                DateTime start = dtFromDay.Value;
                DateTime end = dtToDay.Value;
                string selectedType = cbStatisticType.SelectedValue.ToString();
                switch (selectedType)
                {
                    case "coupon":
                        List<hang_nhap> listCoupon = new db_warehouse_managementEntities().hang_nhap.Where(x => x.ngay_nhap.CompareTo(start) == 1 && x.ngay_nhap.CompareTo(end) == -1).ToList();
                        dgvStatistic.Columns["statistic_ma"].HeaderText = "Mã nhập";
                        dgvStatistic.Columns["statistic_ma"].DataPropertyName = "ma_nhap";
                        dgvStatistic.Columns["ngay_lap"].DataPropertyName = "ngay_nhap";
                        dgvStatistic.Columns["statistic_don_gia"].DataPropertyName = "don_gia";
                        dgvStatistic.Columns["statistic_so_luong"].DataPropertyName = "so_luong";
                        dgvStatistic.Columns["statistic_ma_hang_hoa"].DataPropertyName = "ma_hang_hoa";
                        dgvStatistic.DataSource = listCoupon;
                        foreach (hang_nhap item in listCoupon)
                        {
                            sum += item.don_gia * item.so_luong;
                        }
                        lblTotalSales.Text = "Tổng doanh thu: " + String.Format("{0:0,0}", sum) + " VNĐ";
                        break;
                    case "bill":
                        List<hang_xuat> listBill = new db_warehouse_managementEntities().hang_xuat.Where(x => x.ngay_xuat.CompareTo(start) == 1 && x.ngay_xuat.CompareTo(end) == -1).ToList();
                        dgvStatistic.Columns["statistic_ma"].HeaderText = "Mã xuất";
                        dgvStatistic.Columns["statistic_ma"].DataPropertyName = "ma_xuat";
                        dgvStatistic.Columns["ngay_lap"].DataPropertyName = "ngay_xuat";
                        dgvStatistic.Columns["statistic_don_gia"].DataPropertyName = "don_gia";
                        dgvStatistic.Columns["statistic_so_luong"].DataPropertyName = "so_luong";
                        dgvStatistic.Columns["statistic_ma_hang_hoa"].DataPropertyName = "ma_hang_hoa";
                        dgvStatistic.DataSource = listBill;
                        foreach (hang_xuat item in listBill)
                        {
                            sum += item.don_gia * item.so_luong;
                        }
                        lblTotalSales.Text = "Tổng doanh thu: " + String.Format("{0:0,0}", sum) + " VNĐ";
                        break;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Yêu cầu nhập thời gian!", "Thông báo", MessageBoxButtons.OK);
            }

        }

        private void dgvStatistic_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvStatistic.Columns[e.ColumnIndex].Name == "tong_tien")
            {
                if (dgvStatistic.Rows[e.RowIndex].Cells["statistic_don_gia"].Value != null &&
                    dgvStatistic.Rows[e.RowIndex].Cells["statistic_so_luong"].Value != null)
                {
                    e.Value = double.Parse(dgvStatistic.Rows[e.RowIndex].Cells["statistic_don_gia"].Value.ToString()) * int.Parse(dgvStatistic.Rows[e.RowIndex].Cells["statistic_so_luong"].Value.ToString());
                    e.Value = String.Format("{0:0,0}", e.Value);
                }
            }
            if (this.dgvStatistic.Columns[e.ColumnIndex].Name == "statistic_ma_hang_hoa" && e.Value != null)
            {
                e.Value = db.hang_hoa.Find(e.Value).ten_hang_hoa;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtExPassword.Text = null;
            txtNewPassword.Text = null;
            txtConfirmPassword.Text = null;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtExPassword.Text.Length <= 0)
            {
                MessageBox.Show("Vui lòng nhập mật khẩu cũ!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (txtNewPassword.Text.Length <= 0)
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (!USER_LOGIN.mat_khau.Equals(txtExPassword.Text))
            {
                MessageBox.Show("Mật khẩu cũ không đúng!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (txtExPassword.Text.Equals(txtNewPassword.Text))
            {
                MessageBox.Show("Mật khẩu mới không thể trùng mật khẩu cũ!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (!txtNewPassword.Text.Equals(txtConfirmPassword.Text))
            {
                MessageBox.Show("Mật khẩu không trùng khớp!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            tai_khoan user = db.tai_khoan.Find(USER_LOGIN.tai_khoan1);
            user.mat_khau = txtNewPassword.Text;
            db.SaveChanges();
            MessageBox.Show("Thay đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK);
        }

    }
}
