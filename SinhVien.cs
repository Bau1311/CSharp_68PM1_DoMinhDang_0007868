namespace WinFormsApp
{
    /// <summary>Model sinh viên – dùng chung toàn project</summary>
    public class SinhVien
    {
        public string   MaSV     { get; set; } = string.Empty;
        public string   HoTen    { get; set; } = string.Empty;
        public string   GioiTinh { get; set; } = string.Empty;
        public DateTime NgaySinh { get; set; }
        public string   Lop      { get; set; } = string.Empty;
    }
}
