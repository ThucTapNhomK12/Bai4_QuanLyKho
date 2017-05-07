using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WarehouseManagement
{
    public partial class HangHoaForm : Form
    {
        db_warehouse_managementEntities db = new db_warehouse_managementEntities();

        public hang_hoa selectedProduct = QuanLy.selectedProduct;

        public HangHoaForm()
        {
            InitializeComponent();
            loadForm();
        }

        public void loadForm()
        {
            txtSoLuong.Enabled = false;
            List<nha_cung_cap> list = db.nha_cung_cap.ToList();
            cbNhaCungCap.DataSource = list;
            cbNhaCungCap.DisplayMember = "ten_nha_cung_cap";
            cbNhaCungCap.ValueMember = "ma_nha_cung_cap";

            selectedProduct = (selectedProduct != null) ? new db_warehouse_managementEntities().hang_hoa.Find(selectedProduct.ma_hang_hoa) : null;
            if (selectedProduct != null)
            {
                txtTenSanPham.Text = selectedProduct.ten_hang_hoa;
                txtGiaSP.Text = selectedProduct.don_gia.ToString();
                txtSoLuong.Text = selectedProduct.so_luong.ToString();
                cbNhaCungCap.SelectedValue = selectedProduct.ma_nha_cung_cap;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtTenSanPham.Text.Length <= 0)
            {
                MessageBox.Show("Yêu cầu nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            try
            {
                double price = double.Parse(txtGiaSP.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Giá bán phải là số!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (selectedProduct == null)
            {
                hang_hoa entity = new hang_hoa();
                entity.ten_hang_hoa = txtTenSanPham.Text;
                entity.don_gia = double.Parse(txtGiaSP.Text);
                entity.so_luong = 0;
                entity.ma_nha_cung_cap = int.Parse(cbNhaCungCap.SelectedValue.ToString());
                db.hang_hoa.Add(entity);
                db.SaveChanges();
                MessageBox.Show("Thêm dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                hang_hoa entity = db.hang_hoa.Find(selectedProduct.ma_hang_hoa);
                entity.ten_hang_hoa = txtTenSanPham.Text;
                entity.don_gia = double.Parse(txtGiaSP.Text);
                entity.ma_nha_cung_cap = int.Parse(cbNhaCungCap.SelectedValue.ToString());
                db.SaveChanges();
                MessageBox.Show("Chỉnh sửa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK);
            }
            this.Hide();
        }
    }
}
