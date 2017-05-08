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

        private void cbProductAction_SelectedValueChanged(object sender, EventArgs e)
        {
            string selectedAction = cbProductAction.SelectedValue.ToString();
            switch (selectedAction)
            {
                case "create":
                    selectedProduct = null;
                    HangHoaForm form = new HangHoaForm();
                    form.ShowDialog(this);
                    refresh();
                    break;
                case "update":
                    if (selectedProduct == null)
                    {
                        MessageBox.Show("Chọn bản ghi cần sửa!", "Thông báo", MessageBoxButtons.OK);
                        refresh();
                        return;
                    }
                    else
                    {
                        HangHoaForm x = new HangHoaForm();
                        x.ShowDialog(this);
                        refresh();
                    }
                    break;
                case "delete":
                    try
                    {
                        if (selectedProduct == null)
                        {
                            MessageBox.Show("Chọn bản ghi cần xóa!", "Thông báo", MessageBoxButtons.OK);
                            refresh();
                            return;
                        }
                        else
                        {
                            if (db.hang_nhap.Where(x => x.ma_hang_hoa == selectedProduct.ma_hang_hoa).ToList().Count > 0 ||
                                db.hang_xuat.Where(x => x.ma_hang_hoa == selectedProduct.ma_hang_hoa).ToList().Count > 0)
                            {
                                MessageBox.Show("Hàng hóa này liên quan đến nhiều dữ liệu khác, không thể xóa!", "Chúc mừng", MessageBoxButtons.OK);
                                return;
                            }
                            if (MessageBox.Show(null, "Bạn có chắc chắn muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                            {
                                db.hang_hoa.Remove(selectedProduct);
                                db.SaveChanges();
                                refresh();
                                MessageBox.Show("Xóa dữ liệu thành công!", "Chúc mừng", MessageBoxButtons.OK);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Xóa thất bại", "Lỗi", MessageBoxButtons.OK);
                    }
                    break;
            }
        }

        private void dgvHangHoa_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvHangHoa.Columns[e.ColumnIndex].Name == "nha_cung_cap")
            {
                if (e.Value != null)
                {
                    nha_cung_cap supplier = db.nha_cung_cap.Find(e.Value);
                    e.Value = supplier.ten_nha_cung_cap;
                }
            }
            if (this.dgvHangHoa.Columns[e.ColumnIndex].Name == "don_gia")
            {
                if (e.Value != null)
                {
                    e.Value = String.Format("{0:0,0}", e.Value);
                }
            }
        }

        private void dgvHangHoa_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                selectedProduct = db.hang_hoa.Find(dgvHangHoa.Rows[e.RowIndex].Cells[0].Value);
            }
            catch (Exception)
            {
                MessageBox.Show("Click chuột sai vị trí", "Lỗi", MessageBoxButtons.OK);
            }
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
        #region Long
        public void loadHangNhap()
        {
            dgvNhapHang.DataSource = db.hang_nhap.ToList();
            btnThemHangNhap.Enabled = true;
            btnSuaHangNhap.Enabled = false;
            btnXoaHangNhap.Enabled = false;
            btnLuuHangNhap.Enabled = false;
            btnHuyHangNhap.Enabled = false;

            cbHangHoaNhap.Enabled = false;
            txtSoLuongNhap.Enabled = false;
            txtSoLuongNhap.Text = null;
            cbHangHoaNhap.DataSource = db.hang_hoa.ToList();
            cbHangHoaNhap.DisplayMember = "ten_hang_hoa";
            cbHangHoaNhap.ValueMember = "ma_hang_hoa";
        }

        public void loadHangXuat()
        {
            dgvXuatHang.DataSource = db.hang_xuat.ToList();
            btnThemHangXuat.Enabled = true;
            btnSuaHangXuat.Enabled = false;
            btnXoaHangXuat.Enabled = false;
            btnLuuHangXuat.Enabled = false;
            btnHuyHangXuat.Enabled = false;

            cbHangHoaXuat.Enabled = false;
            txtSoLuongXuat.Enabled = false;
            txtSoLuongXuat.Text = null;
            cbHangHoaXuat.DataSource = db.hang_hoa.ToList();
            cbHangHoaXuat.DisplayMember = "ten_hang_hoa";
            cbHangHoaXuat.ValueMember = "ma_hang_hoa";
        }

        private void btnThemHangNhap_Click(object sender, EventArgs e)
        {
            btnThemHangNhap.Enabled = true;
            btnSuaHangNhap.Enabled = false;
            btnXoaHangNhap.Enabled = false;
            btnLuuHangNhap.Enabled = true;
            btnHuyHangNhap.Enabled = true;

            cbHangHoaNhap.Enabled = true;
            txtSoLuongNhap.Enabled = true;
            txtSoLuongNhap.Text = null;

            selectedCoupon = null;
        }

        private void btnHuyHangNhap_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void dgvNhapHang_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                btnThemHangNhap.Enabled = true;
                btnSuaHangNhap.Enabled = true;
                btnXoaHangNhap.Enabled = true;
                btnLuuHangNhap.Enabled = false;
                btnHuyHangNhap.Enabled = false;

                selectedCoupon = db.hang_nhap.Find(int.Parse(dgvNhapHang.CurrentRow.Cells["ma_nhap"].Value.ToString()));
                cbHangHoaNhap.SelectedValue = selectedCoupon.ma_hang_hoa;
                txtSoLuongNhap.Text = selectedCoupon.so_luong.ToString();

            }
            catch (Exception)
            {
                MessageBox.Show("Click chuột sai vị trí", "Lỗi", MessageBoxButtons.OK);
            }
        }

        private void btnSuaHangNhap_Click(object sender, EventArgs e)
        {
            btnThemHangNhap.Enabled = false;
            btnSuaHangNhap.Enabled = true;
            btnXoaHangNhap.Enabled = false;
            btnLuuHangNhap.Enabled = true;
            btnHuyHangNhap.Enabled = true;

            cbHangHoaNhap.Enabled = true;
            txtSoLuongNhap.Enabled = true;
        }

        private void btnXoaHangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(null, "Bạn có chắc chắn muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    db.hang_nhap.Remove(selectedCoupon);
                    db.SaveChanges();
                    MessageBox.Show("Xóa dữ liệu thành công!", "Chúc mừng", MessageBoxButtons.OK);
                    refresh();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Xóa thất bại", "Lỗi", MessageBoxButtons.OK);
            }
        }

        private void btnLuuHangNhap_Click(object sender, EventArgs e)
        {
            if (txtSoLuongNhap.Value <= 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên dương!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (selectedCoupon == null)
            {
                hang_hoa product = db.hang_hoa.Find(int.Parse(cbHangHoaNhap.SelectedValue.ToString()));
                hang_nhap entity = new hang_nhap();
                entity.ngay_nhap = DateTime.Now;
                entity.don_gia = product.don_gia;
                entity.so_luong = txtSoLuongNhap.Value;
                entity.ma_hang_hoa = product.ma_hang_hoa;
                db.hang_nhap.Add(entity);
                db.SaveChanges();
                //Cập nhật số lượng hàng hóa
                product.so_luong += entity.so_luong;
                db.SaveChanges();
                MessageBox.Show("Thêm dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                hang_hoa product = db.hang_hoa.Find(int.Parse(cbHangHoaNhap.SelectedValue.ToString()));
                //Cập nhật số lượng hàng hóa
                product.so_luong = product.so_luong - selectedCoupon.so_luong + txtSoLuongNhap.Value;
                db.SaveChanges();
                selectedCoupon.ngay_nhap = DateTime.Now;
                selectedCoupon.don_gia = product.don_gia;
                selectedCoupon.so_luong = txtSoLuongNhap.Value;
                db.SaveChanges();
                MessageBox.Show("Sửa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK);
            }
            refresh();
        }

        private void dgvNhapHang_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvNhapHang.Columns[e.ColumnIndex].Name == "tong_tien_nhap")
            {
                e.Value = double.Parse(dgvNhapHang.Rows[e.RowIndex].Cells["gia_nhap"].Value.ToString()) * int.Parse(dgvNhapHang.Rows[e.RowIndex].Cells["so_luong_nhap"].Value.ToString());
                e.Value = String.Format("{0:0,0}", e.Value);
            }
            if (this.dgvNhapHang.Columns[e.ColumnIndex].Name == "gia_nhap")
            {
                e.Value = String.Format("{0:0,0}", e.Value);
            }
            if (this.dgvNhapHang.Columns[e.ColumnIndex].Name == "ma_hang_hoa_nhap")
            {
                e.Value = db.hang_hoa.Find(e.Value).ten_hang_hoa;
            }
        }


        #endregion
    }
}
