public class SinhVienDTO
{
    private string ma;
    private string ho;
    private string ten;

    public SinhVienDTO()
    {
        ma = "";
        ho = "";
        ten = "";
    }

    public SinhVienDTO(string ma, string ho, string ten)
    {
        this.ma = ma;
        this.ho = ho;
        this.ten = ten;
    }

    public string Ma { get { return ma; } set { ma = value; } }
    public string Ho { get { return ho; } set { ho = value; } }
    public string Ten { get { return ten; } set { ten = value; } }
}