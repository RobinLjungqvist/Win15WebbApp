using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebbApp.DAL.DB.Models
{
    [Table("Item")]
    public class Item
    {
        public Item()
        {
            this.Images = new HashSet<Image>();
        }

        [Key]
        public Guid ItemID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ExpirationDate { get; set; }

        [ForeignKey("City")]
        public Guid CityId { get; set; }

        [ForeignKey("Condition")]
        public Guid ConditionId { get; set; }

        [ForeignKey("Region")]
        public Guid RegionId { get; set; }

        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }

        public virtual City City { get; set; }

        public virtual Condition Condition { get; set; }

        public virtual Region Region { get; set; }

        public virtual Category Category { get; set; }

        public Guid ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

       public virtual ICollection<Image> Images { get; set; }
    }
}
