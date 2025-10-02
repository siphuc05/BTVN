using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace Category_Product.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Display(Name = "Tên sản phẩm")]
        [MinLength(6, ErrorMessage = "Ít nhất 6 kí tự")]
        [MaxLength(150, ErrorMessage = "Tối đa 150 kí tự")]
        [Required(ErrorMessage = "Tên sản phẩm không để trống")]
        public string Name { get; set; }

        [Display(Name = "Ảnh sản phẩm")]
        public string Image { get; set; }
        [NotMapped] 
        [Display(Name = "Ảnh đại diện")]
        [Required(ErrorMessage = "Không được để trống ảnh đại diện")]
        public IFormFile FileUpload { get; set; }

        [Display(Name = "Giá")]
        [Range(100000, double.MaxValue, ErrorMessage = "Giá phải lớn hơn 100000")]
        public float Price { get; set; }

        [Display(Name = "Giá sau giảm")]
        [Required(ErrorMessage = "Giá sale không để trống")]
        public float SalePrice { get; set; }

        [Display(Name = "Mô tả sản phẩm")]
        [Required(ErrorMessage = "Mô tả sản phẩm không để trống")]
        [MaxLength(1500, ErrorMessage = "Mô tả không vượt quá 1500 kí tự")]
        public string Description { get; set; }
        [
           Display(Name = "Id thư mục"),
           Required(ErrorMessage = "Id thư mục không được để trống")
       ]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (SalePrice < 0)
            {
                yield return new ValidationResult("Giá giảm không được âm.", new[] { nameof(SalePrice) });
            }

            if (SalePrice > Price * 0.9f)
            {
                yield return new ValidationResult($"Giá giảm phải nhỏ hơn hoặc bằng 90% giá gốc ({Price * 0.9f}).", new[] { nameof(SalePrice) });
            }

            string[] badwords = { "die", "admin", "fuck" };
            foreach (var word in badwords)
            {
                if (!string.IsNullOrEmpty(Description) && Regex.IsMatch(Description, word, RegexOptions.IgnoreCase))
                {
                    yield return new ValidationResult("Mô tả chứa ngôn ngữ không phù hợp", new[] { "Description" });
                }
            }
        }
    }
}
