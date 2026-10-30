using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

public class MyConnect
{
    private string connString =
        "Server=localhost;Database=SinhVien;Integrated Security=True;TrustServerCertificate=True;";

    public SqlConnection? connection = null;

    public SqlConnection? getConnection()
    {
        try
        {
            if (connection == null)
                connection = new SqlConnection(connString);

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
                Console.WriteLine("Connection successful!");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message);
            return null;
        }

        return connection;
    }

    public void dongKetNoi()
    {
        if (connection != null &&
            connection.State == ConnectionState.Open)
        {
            connection.Close();
        }
    }
}