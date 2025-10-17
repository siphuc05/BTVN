using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
namespace NspDay09LabCF.Models
{
    [Table("NspSan_Pham")]
    public class NspSan_Pham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long nspId { get; set; }

        [Display(Name = "Mã sản phẩm")]
        [Required]
        [StringLength(10)]
        public string nspMaSanPham { get; set; }

        [Display(Name = "Tên sản phẩm")]
        public string nspTenSanPham { get; set; }

        [Display(Name = "Hình ảnh")]
        public string nspHinhAnh { get; set; }

        [Display(Name = "Số lượng")]
        public int nspSoLuong { get; set; }

        [Display(Name = "Đơn giá")]
        public decimal nspDonGia { get; set; }


        public long nspLoaiSanPhamId { get; set; }

        public NspLoai_San_Pham nspLoai_San_Pham { get; set; }

    }
}
