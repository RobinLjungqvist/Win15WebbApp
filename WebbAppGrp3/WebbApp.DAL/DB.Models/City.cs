using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebbApp.DAL.DB.Models
{
    [Table("City")]
    public class City
    {
        public City()
        {
            this.Items = new HashSet<Item>();
        }

        [Key]
        public Guid CityId { get; set; }
        [Required]
        public string CityName { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
