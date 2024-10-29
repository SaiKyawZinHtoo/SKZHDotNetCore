using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKZHDotNetCore.ConsoleApp.Models
{
    public class BlogDataModel
    {
        public int BlogId { get; set; }

        public String BlogTitle { get; set; }
               
        public String BlogAuthor {  get; set; }
               
        public String BlogContent { get; set; }
    }
}
