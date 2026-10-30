using System;
using System.Collections.Generic;

internal class SinhVienBUS
{
    List<SinhVienDTO> dssv = new List<SinhVienDTO>();

    public SinhVienBUS() { }

    public void ResetDssv()
    {
        dssv = new List<SinhVienDTO>();
    }

    public List<SinhVienDTO> DocDSSV()
    {
        SinhVienDAO dao = new SinhVienDAO();
        if (dssv == null || dssv.Count == 0)
        {
            dssv = new List<SinhVienDTO>();
            dssv = dao.DocDSSV();
        }
        return dssv;
    }

    public void Them(SinhVienDTO sv)
    {
        SinhVienDAO dao = new SinhVienDAO();
        dao.Them(sv);
        if (dssv != null)
        {
            dssv.Add(sv);
        }
    }

    public void Xoa(string ma)
    {
        SinhVienDAO dao = new SinhVienDAO();
        dao.Xoa(ma);
        if (dssv != null)
        {
            SinhVienDTO? svXoa = timKiem(ma); // Đã thêm dấu ? ở đây
            if (svXoa != null) dssv.Remove(svXoa);
        }
    }

    public void Sua(SinhVienDTO svMoi)
    {
        SinhVienDAO dao = new SinhVienDAO();
        dao.Sua(svMoi);
        if (dssv != null)
        {
            SinhVienDTO? svCu = timKiem(svMoi.Ma); // Đã thêm dấu ? ở đây
            if (svCu != null)
            {
                svCu.Ho = svMoi.Ho;
                svCu.Ten = svMoi.Ten;
            }
        }
    }

    public SinhVienDTO? timKiem(String ma)
    {
        foreach (SinhVienDTO sv in dssv)
        {
            if (sv.Ma.CompareTo(ma) == 0)
            {
                return sv;
            }
        }
        return null;
    }

    public List<SinhVienDTO> timKiemTheoHo(String ho)
    {
        List<SinhVienDTO> kq = new List<SinhVienDTO>();
        foreach (SinhVienDTO sv in dssv)
        {
            if (sv.Ho.IndexOf(ho) >= 0)
            {
                kq.Add(sv);
            }
        }
        return kq;
    }
}