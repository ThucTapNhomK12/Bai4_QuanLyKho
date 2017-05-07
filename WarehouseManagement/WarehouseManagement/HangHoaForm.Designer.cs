namespace WarehouseManagement
{
    partial class HangHoaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnExit = new DevComponents.DotNetBar.ButtonX();
            this.btnSubmit = new DevComponents.DotNetBar.ButtonX();
            this.cbNhaCungCap = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.txtSoLuong = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.txtGiaSP = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.txtTenSanPham = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExit.Location = new System.Drawing.Point(291, 245);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(87, 31);
            this.btnExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnExit.TabIndex = 29;
            this.btnExit.Text = "Thoát";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSubmit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSubmit.Location = new System.Drawing.Point(176, 245);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(87, 31);
            this.btnSubmit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSubmit.TabIndex = 28;
            this.btnSubmit.Text = "Xác nhận";
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // cbNhaCungCap
            // 
            this.cbNhaCungCap.DisplayMember = "Text";
            this.cbNhaCungCap.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbNhaCungCap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNhaCungCap.FormattingEnabled = true;
            this.cbNhaCungCap.ItemHeight = 16;
            this.cbNhaCungCap.Location = new System.Drawing.Point(176, 194);
            this.cbNhaCungCap.Name = "cbNhaCungCap";
            this.cbNhaCungCap.Size = new System.Drawing.Size(203, 22);
            this.cbNhaCungCap.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbNhaCungCap.TabIndex = 27;
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(74, 196);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(87, 20);
            this.labelX7.TabIndex = 26;
            this.labelX7.Text = "Nhà cung cấp";
            // 
            // txtSoLuong
            // 
            // 
            // 
            // 
            this.txtSoLuong.Border.Class = "TextBoxBorder";
            this.txtSoLuong.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSoLuong.Location = new System.Drawing.Point(176, 149);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.PreventEnterBeep = true;
            this.txtSoLuong.Size = new System.Drawing.Size(203, 22);
            this.txtSoLuong.TabIndex = 25;
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(74, 149);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(87, 22);
            this.labelX4.TabIndex = 24;
            this.labelX4.Text = "Số lượng";
            // 
            // txtGiaSP
            // 
            // 
            // 
            // 
            this.txtGiaSP.Border.Class = "TextBoxBorder";
            this.txtGiaSP.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtGiaSP.Location = new System.Drawing.Point(176, 106);
            this.txtGiaSP.Name = "txtGiaSP";
            this.txtGiaSP.PreventEnterBeep = true;
            this.txtGiaSP.Size = new System.Drawing.Size(203, 22);
            this.txtGiaSP.TabIndex = 23;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(74, 106);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(87, 22);
            this.labelX3.TabIndex = 22;
            this.labelX3.Text = "Giá bán";
            // 
            // txtTenSanPham
            // 
            // 
            // 
            // 
            this.txtTenSanPham.Border.Class = "TextBoxBorder";
            this.txtTenSanPham.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTenSanPham.Location = new System.Drawing.Point(176, 65);
            this.txtTenSanPham.Name = "txtTenSanPham";
            this.txtTenSanPham.PreventEnterBeep = true;
            this.txtTenSanPham.Size = new System.Drawing.Size(203, 22);
            this.txtTenSanPham.TabIndex = 21;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(74, 65);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(87, 22);
            this.labelX2.TabIndex = 20;
            this.labelX2.Text = "Tên sản phẩm";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(136, 15);
            this.labelX1.Margin = new System.Windows.Forms.Padding(4);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(198, 28);
            this.labelX1.TabIndex = 19;
            this.labelX1.Text = "Thông tin sản phẩm";
            // 
            // HangHoaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 318);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.cbNhaCungCap);
            this.Controls.Add(this.labelX7);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.txtGiaSP);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.txtTenSanPham);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "HangHoaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Hàng hóa";
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnExit;
        private DevComponents.DotNetBar.ButtonX btnSubmit;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbNhaCungCap;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSoLuong;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX txtGiaSP;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTenSanPham;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
    }
}