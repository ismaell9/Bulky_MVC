using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulkyWeb.Models
{
    public class Category
    {
        public int Id{ get; set; }
        [Required]
        public string Name { get; set; }
        public string DisplayOrder { get; set; }
        
    }
}
