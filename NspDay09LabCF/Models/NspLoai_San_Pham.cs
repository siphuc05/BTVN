using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace NspDay09LabCF.Models
{
    [Table("NspLoai_San_Pham")]
    [Index(nameof(nspMaLoai), IsUnique =true)]
    public class NspLoai_San_Pham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long nspId { get; set; }

        [Display(Name = "Mã loại")]
        [StringLength(10)]
        public string nspMaLoai { get; set; }

        [Display(Name = "Tên loại")]
        [StringLength(50)]
        public string nspTenLoai { get; set; }

        [Display(Name = "Trạng thái")]
        public bool nspTrangThai { get; set; }

        public ICollection<NspSan_Pham> nspSan_Phams { get; set; } = new HashSet<NspSan_Pham>();
    }
}
