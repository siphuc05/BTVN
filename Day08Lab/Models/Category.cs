using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day08Lab.Models
{
    [Table("Category")]
    public partial class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Ten danh muc khong duoc de trong")]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        public byte Status { get; set; }

        public DateTime CreateDate { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
