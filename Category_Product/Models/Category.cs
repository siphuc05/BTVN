using System.ComponentModel.DataAnnotations;

namespace Category_Product.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [
            Display(Name = "Tên danh mục"),
            Required(ErrorMessage = "Tên sản phẩm không được để trống"),
            StringLength(150, MinimumLength = 6, ErrorMessage = "Độ dài ký tự phải từ 6 đến 150 ký tự")
        ]
        public string Name { get; set; }
    }
}
