using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebbApp.DAL.DB.Models
{
    [Table("Region")]
    public class Region
    {
        public Region()
        {
            this.Items = new HashSet<Item>();
        }

        [Key]
        public Guid RegionId { get; set; }
        [Required]
        public string RegionName { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
