
using System;
using System.Collections.Generic;
using System.Windows.Forms;

public partial class Form1 : Form
{
    SinhVienBUS bus = new SinhVienBUS();

    TextBox txtMa = new TextBox();
    TextBox txtHo = new TextBox();
    TextBox txtTen = new TextBox();
    TextBox txtTimKiem = new TextBox();

    DataGridView dgvSinhVien = new DataGridView();

    Button btnThem = new Button();
    Button btnSua = new Button();
    Button btnXoa = new Button();
    Button btnLamMoi = new Button();
    Button btnTimKiem = new Button();

    public Form1()
    {
        TaoGiaoDien();
        HienThiDanhSach();
    }

    void TaoGiaoDien()
    {
        this.Text = "QUẢN LÝ SINH VIÊN";
        this.Size = new System.Drawing.Size(850, 600);
        this.StartPosition = FormStartPosition.CenterScreen;

        Label lblTieuDe = new Label();
        lblTieuDe.Text = "QUẢN LÝ SINH VIÊN";
        lblTieuDe.Font = new System.Drawing.Font("Arial", 20,
            System.Drawing.FontStyle.Bold);
        lblTieuDe.AutoSize = true;
        lblTieuDe.Location = new System.Drawing.Point(270, 20);
        this.Controls.Add(lblTieuDe);

        TaoLabel("Mã sinh viên:", 50, 90);
        TaoLabel("Họ:", 50, 135);
        TaoLabel("Tên:", 50, 180);

        txtMa.SetBounds(160, 90, 200, 25);
        txtHo.SetBounds(160, 135, 200, 25);
        txtTen.SetBounds(160, 180, 200, 25);

        this.Controls.Add(txtMa);
        this.Controls.Add(txtHo);
        this.Controls.Add(txtTen);

        TaoButton(btnThem, "Thêm", 420, 90);
        TaoButton(btnSua, "Sửa", 540, 90);
        TaoButton(btnXoa, "Xóa", 660, 90);
        TaoButton(btnLamMoi, "Làm mới", 420, 140);

        TaoLabel("Tìm kiếm:", 50, 240);
        txtTimKiem.SetBounds(160, 235, 200, 25);
        this.Controls.Add(txtTimKiem);

        TaoButton(btnTimKiem, "Tìm", 380, 230);

        dgvSinhVien.SetBounds(50, 290, 730, 230);
        dgvSinhVien.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill;
        dgvSinhVien.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;
        dgvSinhVien.MultiSelect = false;
        dgvSinhVien.ReadOnly = true;
        dgvSinhVien.AllowUserToAddRows = false;

        dgvSinhVien.Columns.Add("Ma", "Mã sinh viên");
        dgvSinhVien.Columns.Add("Ho", "Họ");
        dgvSinhVien.Columns.Add("Ten", "Tên");

        this.Controls.Add(dgvSinhVien);

        btnThem.Click += btnThem_Click;
        btnSua.Click += btnSua_Click;
        btnXoa.Click += btnXoa_Click;
        btnLamMoi.Click += btnLamMoi_Click;
        btnTimKiem.Click += btnTimKiem_Click;
        dgvSinhVien.CellClick += dgvSinhVien_CellClick;
    }

    void TaoLabel(string text, int x, int y)
    {
        Label lbl = new Label();
        lbl.Text = text;
        lbl.SetBounds(x, y, 100, 25);
        this.Controls.Add(lbl);
    }

    void TaoButton(Button btn, string text, int x, int y)
    {
        btn.Text = text;
        btn.SetBounds(x, y, 100, 30);
        this.Controls.Add(btn);
    }

    void HienThiDanhSach()
    {
        dgvSinhVien.Rows.Clear();

        List<SinhVienDTO> ds = bus.DocDSSV();

        foreach (SinhVienDTO sv in ds)
        {
            dgvSinhVien.Rows.Add(sv.Ma, sv.Ho, sv.Ten);
        }
    }

    void btnThem_Click(object? sender, EventArgs e)
    {
        if (txtMa.Text == "" || txtHo.Text == "" || txtTen.Text == "")
        {
            MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            return;
        }

        SinhVienDTO sv = new SinhVienDTO(
            txtMa.Text, txtHo.Text, txtTen.Text);

        bus.Them(sv);

        HienThiDanhSach();
        XoaTrang();

        MessageBox.Show("Thêm sinh viên thành công!");
    }

    void btnSua_Click(object? sender, EventArgs e)
    {
        if (txtMa.Text == "")
        {
            MessageBox.Show("Vui lòng chọn sinh viên cần sửa!");
            return;
        }

        SinhVienDTO sv = new SinhVienDTO(
            txtMa.Text, txtHo.Text, txtTen.Text);

        bus.Sua(sv);

        HienThiDanhSach();
        XoaTrang();

        MessageBox.Show("Cập nhật thành công!");
    }

    void btnXoa_Click(object? sender, EventArgs e)
    {
        if (txtMa.Text == "")
        {
            MessageBox.Show("Vui lòng chọn sinh viên cần xóa!");
            return;
        }

        DialogResult kq = MessageBox.Show(
            "Bạn có chắc chắn muốn xóa sinh viên này?",
            "Xác nhận",
            MessageBoxButtons.YesNo);

        if (kq == DialogResult.Yes)
        {
            bus.Xoa(txtMa.Text);
            HienThiDanhSach();
            XoaTrang();

            MessageBox.Show("Xóa thành công!");
        }
    }

    void btnLamMoi_Click(object? sender, EventArgs e)
    {
        XoaTrang();
        HienThiDanhSach();
    }

    void btnTimKiem_Click(object? sender, EventArgs e)
    {
        dgvSinhVien.Rows.Clear();

        string tuKhoa = txtTimKiem.Text.Trim();

        if (tuKhoa == "")
        {
            HienThiDanhSach();
            return;
        }

        List<SinhVienDTO> ds = bus.DocDSSV();

        foreach (SinhVienDTO sv in ds)
        {
            if (sv.Ma.Contains(tuKhoa,
                    StringComparison.OrdinalIgnoreCase) ||
                sv.Ho.Contains(tuKhoa,
                    StringComparison.OrdinalIgnoreCase) ||
                sv.Ten.Contains(tuKhoa,
                    StringComparison.OrdinalIgnoreCase))
            {
                dgvSinhVien.Rows.Add(sv.Ma, sv.Ho, sv.Ten);
            }
        }
    }

    void dgvSinhVien_CellClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
        {
            DataGridViewRow row = dgvSinhVien.Rows[e.RowIndex];

            // Thêm dấu ? và ?? "" vào 3 dòng này:
            txtMa.Text = row.Cells[0].Value?.ToString() ?? "";
            txtHo.Text = row.Cells[1].Value?.ToString() ?? "";
            txtTen.Text = row.Cells[2].Value?.ToString() ?? "";
        }
    }

    void XoaTrang()
    {
        txtMa.Clear();
        txtHo.Clear();
        txtTen.Clear();
        txtTimKiem.Clear();
        txtMa.Focus();
    }
}
