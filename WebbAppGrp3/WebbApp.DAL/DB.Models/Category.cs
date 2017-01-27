using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebbApp.DAL.DB.Models
{
    [Table("Category")]
    public class Category
    {
        public Category()
        {
            this.Items = new HashSet<Item>();
        }

        [Key]
        public Guid CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
