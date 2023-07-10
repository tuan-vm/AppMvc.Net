using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppMVC01.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName ="nvarchar")]
        [StringLength(50)]
        [Required(ErrorMessage ="Phai nhap {0}")]
        [Display(Name ="HoTen")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Phai nhap {0}")]
        [StringLength(100)]
        [EmailAddress(ErrorMessage ="Phai la dia chi Email")]
        [Display(Name ="Dia Chi Email")]
        public string Email { get; set; }   


        public DateTime DateSent { get; set; }

        [Display(Name ="Noi Dung")]
        public string Message { get; set; }

        [StringLength(50)]
        [Phone(ErrorMessage ="Phai la {0}")]
        [Display(Name = "So dien thoai")]
        public string Phone { get; set; }   
    }
}
