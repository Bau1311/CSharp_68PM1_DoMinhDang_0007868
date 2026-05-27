namespace WinFormsApp
{
    /// <summary>Model lớp học – dùng chung toàn project</summary>
    public class LopHoc
    {
        public int    MaID   { get; set; }
        public string MaLop  { get; set; } = string.Empty;
        public string TenLop { get; set; } = string.Empty;
        public string GhiChu { get; set; } = string.Empty;
    }
}