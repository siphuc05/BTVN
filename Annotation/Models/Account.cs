﻿using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
namespace Annotation.Models
{
    public class Account
    {
        [Key] //khoa chinh
        public int Id { get; set; }
        
            [Display(Name = "Họ và tên")]
            [Required(ErrorMessage = "Họ tên không được để trống")]
            [MinLength(6, ErrorMessage = "Họ tên ít nhất 6 kí tự")]
            [MaxLength(20, ErrorMessage = "Họ tên tối đa 20 kí tự")]
        
        public string FullName { get; set; }
        
            [Display(Name = "Địa chỉ Email")]
            [Required(ErrorMessage = "Email không được để trống")]
            [EmailAddress(ErrorMessage = "Địa chỉ email không đúng định dạng")]
        
        public string Email { get; set; }
            [Display(Name = "Số điện thoại")]
            [DataType(DataType.PhoneNumber)]
            [Remote(action: "VerifyPhone", controller:"Account")]
            [Required(ErrorMessage = "Số điện thoại không được để trống")]
        public string Phone { get; set; }
        
            [Display(Name = "Địa chỉ")]
            [Required(ErrorMessage = "Địa chỉ không được để trống")]
            [StringLength(35, ErrorMessage = "Địa chỉ tối đa 35 kí tự")]
            
        public string Address { get; set; }
        [Display(Name = "Ảnh đại diện")]
        public string Avatar { get; set; }
        
            [Display(Name = "Ngày sinh")]
            [Required(ErrorMessage = "Ngay sinh không được để trống")]
            [DataType(DataType.Date)]
            
        public DateTime Birthday { get; set; }
        [Display(Name = "Giới tính")]
        public string Gender { get; set; }
        
            [Display(Name = "Mật khẩu")]
            [Required(ErrorMessage = "Mật khẩu không được để trống")]
            [DataType(DataType.Password)]
            
        public string Password { get; set; }
        
            [Display(Name = "Link facebook cá nhân")]
            [Required(ErrorMessage = "Facebook không được để trống")]
            [Url(ErrorMessage = "Url phải đúng định dạng http hoặc https")]
            
        public string Facebook { get; set; }

    }
}
