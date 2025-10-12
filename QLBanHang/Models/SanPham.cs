using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLBanHang.Models;

public partial class SanPham
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage ="mã sản phẩm không để trống")]
    public string MaSanPham { get; set; } = null!;

    public string TenSanPham { get; set; } = null!;

    public string? HinhAnh { get; set; }

    public int? SoLuong { get; set; }

    public decimal? DonGia { get; set; }
    [Display(Name ="Mã loại")]
    [Required(ErrorMessage ="ma loai khong duoc de trong")]
    public int MaLoai { get; set; }

    public bool? TrangThai { get; set; }

    public virtual ICollection<CtHoaDon> CtHoaDons { get; set; } = new List<CtHoaDon>();

    public virtual LoaiSanPham MaLoaiNavigation { get; set; } = null!;
}
