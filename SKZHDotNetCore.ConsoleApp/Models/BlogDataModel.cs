using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKZHDotNetCore.ConsoleApp.Models
{
    public class BlogDapperDataModel
    {
        public int BlogId { get; set; }

        public String BlogTitle { get; set; }
               
        public String BlogAuthor {  get; set; }
               
        public String BlogContent { get; set; }
    }
    [Table("Tbl_Blog")]
    public class BlogDataModel
    {
        [Key]
        [Column("BlogId")]
        public int BlogId { get; set; }

        [Column("BlogTitle")]
        public String BlogTitle { get; set; }

        [Column("BlogAuthor")]
        public String BlogAuthor { get; set; }

        [Column("BlogContent")]
        public String BlogContent { get; set; }

        [Column("DeleteFlag")]
        public bool DeleteFlag { get; set; }
    }
}
