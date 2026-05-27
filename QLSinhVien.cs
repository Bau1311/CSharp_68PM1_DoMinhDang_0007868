using Microsoft.Data.SqlClient;
using System.Data;

namespace WinFormsApp
{
    /// <summary>
    /// Lớp truy xuất dữ liệu – thay thế cho QLSinhVien.dbml (LINQ to SQL).
    /// Kết nối SQL Server qua ADO.NET (Microsoft.Data.SqlClient).
    /// </summary>
    public class QLSinhVienDB
    {
        private readonly string _connectionString;

        public QLSinhVienDB()
        {
            _connectionString = Properties.Settings.Default.QLSinhVienConnectionString;
        }

        // ══════════════════════════════════════════════════════════════════
        //  LopHoc
        // ══════════════════════════════════════════════════════════════════

        /// <summary>Lấy toàn bộ danh sách lớp học</summary>
        public List<LopHoc> LayDanhSachLop()
        {
            var list = new List<LopHoc>();
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var cmd = new SqlCommand("SELECT MaID, MaLop, TenLop, GhiChu FROM LopHoc ORDER BY MaID", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new LopHoc
                {
                    MaID   = reader.GetInt32(0),
                    MaLop  = reader.GetString(1),
                    TenLop = reader.GetString(2),
                    GhiChu = reader.IsDBNull(3) ? "" : reader.GetString(3)
                });
            }
            return list;
        }

        /// <summary>Thêm lớp học mới</summary>
        public void ThemLopHoc(LopHoc lop)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var cmd = new SqlCommand(
                "INSERT INTO LopHoc (MaLop, TenLop, GhiChu) VALUES (@MaLop, @TenLop, @GhiChu)", conn);
            cmd.Parameters.AddWithValue("@MaLop",  lop.MaLop);
            cmd.Parameters.AddWithValue("@TenLop", lop.TenLop);
            cmd.Parameters.AddWithValue("@GhiChu", (object?)lop.GhiChu ?? DBNull.Value);
            cmd.ExecuteNonQuery();
        }

        /// <summary>Cập nhật lớp học</summary>
        public void SuaLopHoc(LopHoc lop)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var cmd = new SqlCommand(
                "UPDATE LopHoc SET MaLop=@MaLop, TenLop=@TenLop, GhiChu=@GhiChu WHERE MaID=@MaID", conn);
            cmd.Parameters.AddWithValue("@MaID",   lop.MaID);
            cmd.Parameters.AddWithValue("@MaLop",  lop.MaLop);
            cmd.Parameters.AddWithValue("@TenLop", lop.TenLop);
            cmd.Parameters.AddWithValue("@GhiChu", (object?)lop.GhiChu ?? DBNull.Value);
            cmd.ExecuteNonQuery();
        }

        /// <summary>Xóa lớp học theo MaID</summary>
        public void XoaLopHoc(int maID)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var cmd = new SqlCommand("DELETE FROM LopHoc WHERE MaID=@MaID", conn);
            cmd.Parameters.AddWithValue("@MaID", maID);
            cmd.ExecuteNonQuery();
        }

        /// <summary>Kiểm tra trùng mã lớp</summary>
        public bool TonTaiMaLop(string maLop, int? excludeMaID = null)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            string sql = excludeMaID.HasValue
                ? "SELECT COUNT(*) FROM LopHoc WHERE MaLop=@MaLop AND MaID<>@ExID"
                : "SELECT COUNT(*) FROM LopHoc WHERE MaLop=@MaLop";
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaLop", maLop);
            if (excludeMaID.HasValue)
                cmd.Parameters.AddWithValue("@ExID", excludeMaID.Value);
            return (int)cmd.ExecuteScalar() > 0;
        }

        // ══════════════════════════════════════════════════════════════════
        //  SinhVien
        // ══════════════════════════════════════════════════════════════════

        /// <summary>Lấy toàn bộ danh sách sinh viên</summary>
        public List<SinhVien> LayDanhSachSinhVien()
        {
            var list = new List<SinhVien>();
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var cmd = new SqlCommand(
                "SELECT MaSV, HoTen, GioiTinh, NgaySinh, MaLop FROM SinhVien ORDER BY MaSV", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new SinhVien
                {
                    MaSV     = reader.GetString(0),
                    HoTen    = reader.GetString(1),
                    GioiTinh = reader.GetString(2),
                    NgaySinh = reader.GetDateTime(3),
                    Lop      = reader.GetString(4)
                });
            }
            return list;
        }

        /// <summary>Thêm sinh viên mới</summary>
        public void ThemSinhVien(SinhVien sv)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var cmd = new SqlCommand(
                "INSERT INTO SinhVien (MaSV, HoTen, GioiTinh, NgaySinh, MaLop) " +
                "VALUES (@MaSV, @HoTen, @GioiTinh, @NgaySinh, @MaLop)", conn);
            cmd.Parameters.AddWithValue("@MaSV",     sv.MaSV);
            cmd.Parameters.AddWithValue("@HoTen",    sv.HoTen);
            cmd.Parameters.AddWithValue("@GioiTinh", sv.GioiTinh);
            cmd.Parameters.AddWithValue("@NgaySinh", sv.NgaySinh);
            cmd.Parameters.AddWithValue("@MaLop",    sv.Lop);
            cmd.ExecuteNonQuery();
        }

        /// <summary>Cập nhật sinh viên</summary>
        public void SuaSinhVien(SinhVien sv)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var cmd = new SqlCommand(
                "UPDATE SinhVien SET HoTen=@HoTen, GioiTinh=@GioiTinh, NgaySinh=@NgaySinh, MaLop=@MaLop " +
                "WHERE MaSV=@MaSV", conn);
            cmd.Parameters.AddWithValue("@MaSV",     sv.MaSV);
            cmd.Parameters.AddWithValue("@HoTen",    sv.HoTen);
            cmd.Parameters.AddWithValue("@GioiTinh", sv.GioiTinh);
            cmd.Parameters.AddWithValue("@NgaySinh", sv.NgaySinh);
            cmd.Parameters.AddWithValue("@MaLop",    sv.Lop);
            cmd.ExecuteNonQuery();
        }

        /// <summary>Xóa sinh viên theo MaSV</summary>
        public void XoaSinhVien(string maSV)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var cmd = new SqlCommand("DELETE FROM SinhVien WHERE MaSV=@MaSV", conn);
            cmd.Parameters.AddWithValue("@MaSV", maSV);
            cmd.ExecuteNonQuery();
        }

        /// <summary>Tìm kiếm sinh viên</summary>
        public List<SinhVien> TimSinhVien(string keyword)
        {
            var list = new List<SinhVien>();
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var cmd = new SqlCommand(
                "SELECT MaSV, HoTen, GioiTinh, NgaySinh, MaLop FROM SinhVien " +
                "WHERE MaSV LIKE @kw OR HoTen LIKE @kw OR MaLop LIKE @kw ORDER BY MaSV", conn);
            cmd.Parameters.AddWithValue("@kw", $"%{keyword}%");
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new SinhVien
                {
                    MaSV     = reader.GetString(0),
                    HoTen    = reader.GetString(1),
                    GioiTinh = reader.GetString(2),
                    NgaySinh = reader.GetDateTime(3),
                    Lop      = reader.GetString(4)
                });
            }
            return list;
        }

        /// <summary>Tìm kiếm lớp học</summary>
        public List<LopHoc> TimLopHoc(string keyword)
        {
            var list = new List<LopHoc>();
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var cmd = new SqlCommand(
                "SELECT MaID, MaLop, TenLop, GhiChu FROM LopHoc " +
                "WHERE CAST(MaID AS NVARCHAR) LIKE @kw OR MaLop LIKE @kw OR TenLop LIKE @kw ORDER BY MaID", conn);
            cmd.Parameters.AddWithValue("@kw", $"%{keyword}%");
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new LopHoc
                {
                    MaID   = reader.GetInt32(0),
                    MaLop  = reader.GetString(1),
                    TenLop = reader.GetString(2),
                    GhiChu = reader.IsDBNull(3) ? "" : reader.GetString(3)
                });
            }
            return list;
        }
    }
}
