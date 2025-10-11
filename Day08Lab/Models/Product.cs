using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day08Lab.Models
{
    [Table("Product")]
    public partial class Product
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Ten san pham khong duoc de trong")]
        [StringLength(150,ErrorMessage ="Ten san pham gioi han 150 ki tu")]
        public string Name { get; set; } = null!;
        public string? Image { get; set; } 
        [Required(ErrorMessage ="Gia san pham khong duoc de trong")]
        public float Price { get; set; }

        public float SalePrice { get; set; }

        public byte Status { get; set; }
        [StringLength(1000,ErrorMessage ="Noi dung mo ta gioi han 1000 ki tu")]
        public string? Description { get; set; }
        [Display(Name = "Category")]
        [Required(ErrorMessage = "Danh mục sản phẩm không được để trống")]
        public int CategoryId { get; set; }

        public DateTime CreateDate { get; set; }

        public virtual Category? Category { get; set; }
    }

}
