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
        [Key]
        public Guid ImageId { get; set; }

        public string Path { get; set; }

        [ForeignKey("Item"), ScaffoldColumn(false)]
        public Guid ItemID { get; set; }

        public virtual Item Item { get; set; }
    }
}
