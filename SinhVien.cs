using LinqToDB.Mapping;

namespace WinFormsApp
{
    /// <summary>Model sinh viên – dùng chung toàn project</summary>
    [Table(Name = "SinhVien")]
    public class SinhVien
    {
        [Column(Name = "MaSV"), PrimaryKey]
        public string   MaSV     { get; set; } = string.Empty;

        [Column(Name = "HoTen")]
        public string   HoTen    { get; set; } = string.Empty;

        [Column(Name = "GioiTinh")]
        public string   GioiTinh { get; set; } = string.Empty;

        [Column(Name = "NgaySinh")]
        public DateTime NgaySinh { get; set; }

        [Column(Name = "MaLop")]
        public string   Lop      { get; set; } = string.Empty;
    }
}
