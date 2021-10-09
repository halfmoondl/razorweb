using System;
using System.Collections.Generic;
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
        [Required]
        [Column(TypeName="nvarchar")]
        [StringLength(255)]
        public string Title { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime  Created { get; set; }
        [Column(TypeName = "ntext")]
        public string Content { get; set; }
    }
}
