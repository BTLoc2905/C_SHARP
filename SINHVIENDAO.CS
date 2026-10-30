using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

internal class SinhVienDAO
{
    MyConnect db = new MyConnect();
    SqlConnection? connection;

    public SinhVienDAO()
    {
        connection = db.getConnection();
    }

    public List<SinhVienDTO> DocDSSV()
    {
        List<SinhVienDTO> dssv = new List<SinhVienDTO>();
        try
        {
            if (connection == null) return dssv;

            string query = "SELECT MA, HO, TEN FROM SINHVIEN";
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string ma = reader.GetString(0);
                    string ho = reader.GetString(1);
                    string ten = reader.GetString(2);
                    dssv.Add(new SinhVienDTO(ma, ho, ten));
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi đọc thông tin Sinh viên: " + ex.Message);
        }
        return dssv;
    }

    public void Them(SinhVienDTO sv)
    {
        try
        {
            if (connection == null) return;
            string query = "INSERT INTO SINHVIEN (MA, HO, TEN) VALUES (@MA, @HO, @TEN)";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@MA", sv.Ma);
                command.Parameters.AddWithValue("@HO", sv.Ho);
                command.Parameters.AddWithValue("@TEN", sv.Ten);
                command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi ghi thông tin Sinh viên: " + ex.Message);
        }
    }

    public void Xoa(string ma)
    {
        try
        {
            if (connection == null) return;
            string query = "DELETE FROM SINHVIEN WHERE MA = @MA";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@MA", ma);
                command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi xóa Sinh viên: " + ex.Message);
        }
    }

    public void Sua(SinhVienDTO sv)
    {
        try
        {
            if (connection == null) return;
            string query = "UPDATE SINHVIEN SET HO = @HO, TEN = @TEN WHERE MA = @MA";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@HO", sv.Ho);
                command.Parameters.AddWithValue("@TEN", sv.Ten);
                command.Parameters.AddWithValue("@MA", sv.Ma);
                command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi cập nhật Sinh viên: " + ex.Message);
        }
    }
}