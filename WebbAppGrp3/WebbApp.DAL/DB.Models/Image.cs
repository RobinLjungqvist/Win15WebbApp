using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebbApp.DAL.DB.Models
{
    [Table("Image")]
    public class Image
    {
        public Image()
        {
            this.Items = new HashSet<Item>();
        }

        [Key]
        public Guid ImageId { get; set; }
        [Required]
        public string Path { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
