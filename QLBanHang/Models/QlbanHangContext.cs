using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QLBanHang.Models;

public partial class QlbanHangContext : DbContext
{
    public QlbanHangContext()
    {
    }

    public QlbanHangContext(DbContextOptions<QlbanHangContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CtHoaDon> CtHoaDons { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<LoaiSanPham> LoaiSanPhams { get; set; }

    public virtual DbSet<QuanTri> QuanTris { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MSI;Database=QLBanHang;uid=sa;pwd=262005; MultipleActiveResultSets=True; TrustServerCertificate=True ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CtHoaDon>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CT_HOA_D__3214EC271A94D6BA");

            entity.ToTable("CT_HOA_DON");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DonGiaMua).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.HoaDonId).HasColumnName("HoaDonID");
            entity.Property(e => e.SanPhamId).HasColumnName("SanPhamID");
            entity.Property(e => e.ThanhTien)
                .HasComputedColumnSql("([SoLuongMua]*[DonGiaMua])", true)
                .HasColumnType("decimal(29, 2)");
            entity.Property(e => e.TrangThai).HasDefaultValue(true);

            entity.HasOne(d => d.HoaDon).WithMany(p => p.CtHoaDons)
                .HasForeignKey(d => d.HoaDonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CT_HOA_DO__HoaDo__4BAC3F29");

            entity.HasOne(d => d.SanPham).WithMany(p => p.CtHoaDons)
                .HasForeignKey(d => d.SanPhamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CT_HOA_DO__SanPh__4CA06362");
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__HOA_DON__3214EC273FED30A0");

            entity.ToTable("HOA_DON");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DiaChi).HasMaxLength(200);
            entity.Property(e => e.DienThoai).HasMaxLength(20);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.HoTenKhachHang).HasMaxLength(100);
            entity.Property(e => e.MaHoaDon).HasMaxLength(20);
            entity.Property(e => e.NgayHoaDon).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.TongTriGia).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TrangThai).HasDefaultValue(true);

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaKhachHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HOA_DON__MaKhach__47DBAE45");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__KHACH_HA__3214EC27E9C32659");

            entity.ToTable("KHACH_HANG");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DiaChi).HasMaxLength(200);
            entity.Property(e => e.DienThoai).HasMaxLength(20);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.HoTenKhachHang).HasMaxLength(100);
            entity.Property(e => e.MaKhachHang).HasMaxLength(20);
            entity.Property(e => e.MatKhau).HasMaxLength(100);
            entity.Property(e => e.NgayDangKy).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.TrangThai).HasDefaultValue(true);
        });

        modelBuilder.Entity<LoaiSanPham>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LOAI_SAN__3214EC27AA384E98");

            entity.ToTable("LOAI_SAN_PHAM");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.MaLoai).HasMaxLength(20);
            entity.Property(e => e.TenLoai).HasMaxLength(100);
            entity.Property(e => e.TrangThai).HasDefaultValue(true);
        });

        modelBuilder.Entity<QuanTri>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__QUAN_TRI__3214EC270F9E32DF");

            entity.ToTable("QUAN_TRI");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.MatKhau).HasMaxLength(100);
            entity.Property(e => e.TaiKhoan).HasMaxLength(50);
            entity.Property(e => e.TrangThai).HasDefaultValue(true);
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SAN_PHAM__3214EC2773E635D3");

            entity.ToTable("SAN_PHAM");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DonGia).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.HinhAnh).HasMaxLength(200);
            entity.Property(e => e.MaSanPham).HasMaxLength(20);
            entity.Property(e => e.SoLuong).HasDefaultValue(0);
            entity.Property(e => e.TenSanPham).HasMaxLength(100);
            entity.Property(e => e.TrangThai).HasDefaultValue(true);

            entity.HasOne(d => d.MaLoaiNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.MaLoai)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SAN_PHAM__MaLoai__4316F928");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
