using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RazorWeb.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="{0} Phải nhập")]
        [Column(TypeName="nvarchar")]
        [StringLength(255, MinimumLength =5,ErrorMessage ="{0} phải dài từ {2} tới {1} ký tự")]
        [DisplayName("Tieu de")]
        public string Title { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Nhập {0}")]
        [DisplayName("Ngay dang")]
        public DateTime  Created { get; set; }
        [Column(TypeName = "ntext")]
        public string Content { get; set; }
    }
}
