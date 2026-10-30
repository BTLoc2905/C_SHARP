using System;
using System.Windows.Forms;

static class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        // Dòng này sẽ kích hoạt và bật Form1 của ông lên
        Application.Run(new Form1()); 
    }
}