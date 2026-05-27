using LinqToDB;
using LinqToDB.Data;

namespace WinFormsApp
{
    /// <summary>
    /// DataContext kết nối SQL Server bằng LINQ (linq2db).
    /// Thay thế hoàn toàn ADO.NET thuần (SqlConnection/SqlCommand).
    /// </summary>
    public class QLSinhVienDB : DataConnection
    {
        public QLSinhVienDB()
            : base(ProviderName.SqlServer,
                   Properties.Settings.Default.QLSinhVienConnectionString)
        {
        }

        // ── Các bảng (ITable) ──────────────────────────────────────────
        public ITable<LopHoc>   LopHocs   => this.GetTable<LopHoc>();
        public ITable<SinhVien> SinhViens => this.GetTable<SinhVien>();

        // ══════════════════════════════════════════════════════════════════
        //  LopHoc – CRUD bằng LINQ
        // ══════════════════════════════════════════════════════════════════

        /// <summary>Lấy toàn bộ danh sách lớp học</summary>
        public List<LopHoc> LayDanhSachLop()
        {
            return LopHocs.OrderBy(l => l.MaID).ToList();
        }

        /// <summary>Thêm lớp học mới</summary>
        public void ThemLopHoc(LopHoc lop)
        {
            this.Insert(lop);
        }

        /// <summary>Cập nhật lớp học</summary>
        public void SuaLopHoc(LopHoc lop)
        {
            this.Update(lop);
        }

        /// <summary>Xóa lớp học theo MaID</summary>
        public void XoaLopHoc(int maID)
        {
            LopHocs.Where(l => l.MaID == maID).Delete();
        }

        /// <summary>Kiểm tra trùng mã lớp</summary>
        public bool TonTaiMaLop(string maLop, int? excludeMaID = null)
        {
            if (excludeMaID.HasValue)
                return LopHocs.Any(l => l.MaLop == maLop && l.MaID != excludeMaID.Value);
            return LopHocs.Any(l => l.MaLop == maLop);
        }

        /// <summary>Tìm kiếm lớp học</summary>
        public List<LopHoc> TimLopHoc(string keyword)
        {
            string kw = $"%{keyword}%";
            return LopHocs
                .Where(l => Sql.Like(l.MaLop, kw)
                         || Sql.Like(l.TenLop, kw)
                         || Sql.Like(Sql.Convert<string, int>(l.MaID), kw))
                .OrderBy(l => l.MaID)
                .ToList();
        }

        // ══════════════════════════════════════════════════════════════════
        //  SinhVien – CRUD bằng LINQ
        // ══════════════════════════════════════════════════════════════════

        /// <summary>Lấy toàn bộ danh sách sinh viên</summary>
        public List<SinhVien> LayDanhSachSinhVien()
        {
            return SinhViens.OrderBy(sv => sv.MaSV).ToList();
        }

        /// <summary>Thêm sinh viên mới</summary>
        public void ThemSinhVien(SinhVien sv)
        {
            this.Insert(sv);
        }

        /// <summary>Cập nhật sinh viên</summary>
        public void SuaSinhVien(SinhVien sv)
        {
            this.Update(sv);
        }

        /// <summary>Xóa sinh viên theo MaSV</summary>
        public void XoaSinhVien(string maSV)
        {
            SinhViens.Where(sv => sv.MaSV == maSV).Delete();
        }

        /// <summary>Tìm kiếm sinh viên</summary>
        public List<SinhVien> TimSinhVien(string keyword)
        {
            string kw = $"%{keyword}%";
            return SinhViens
                .Where(sv => Sql.Like(sv.MaSV, kw)
                          || Sql.Like(sv.HoTen, kw)
                          || Sql.Like(sv.Lop, kw))
                .OrderBy(sv => sv.MaSV)
                .ToList();
        }
    }
}
