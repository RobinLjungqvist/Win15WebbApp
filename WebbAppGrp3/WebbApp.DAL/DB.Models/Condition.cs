using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebbApp.DAL.DB.Models
{
    [Table("Condition")]
    public class Condition
    {
        public Condition()
        {
            this.Items = new HashSet<Item>();
        }

        [Key]
        public Guid ConditionId { get; set; }
        [Required]
        public string Status { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
