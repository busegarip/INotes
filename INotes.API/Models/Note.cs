using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INotes.API.Models
{
    [Table("Notes")]
    public class Note
    {
        public int Id { get; set; }

        [Required]
        [ForeignKey("Author")]
        public string AuthorId { get; set; }//bunu yazmazsak kendisi bir foreign key oluşturur ama bunu biz yönetemeyiz. Default bir isimle arkada oluşturur. int olduğunda zorunlu

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        public string Content { get; set; }

        [Required]
        public DateTime? CreatedTime { get; set; }//oluşturulduğu zaman 

        public DateTime? ModifiedTime { get; set; }//güncellendiği zaman

        public ApplicationUser Author { get; set; }
    }
}