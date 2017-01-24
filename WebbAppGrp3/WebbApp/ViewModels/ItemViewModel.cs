using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebbApp.ViewModels
{
    public class ItemViewModel
    {

        public Guid ItemID { get; set; }

        [Required(ErrorMessage ="Must enter the title of the item")]
        public string Title { get; set; }

        [Required(ErrorMessage ="Must enter a description for the item")]
        public string Description { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime ExpirationDate { get; set; }

        [Required(ErrorMessage ="Must enter the city")]
        public string City { get; set; }

        [Required(ErrorMessage ="Must enter the condition of the item")]
        public string Condition { get; set; }

        [Required(ErrorMessage ="Must enter the region")]
        public string Region { get; set; }

        [Required(ErrorMessage ="Must enter the category of the item")]
        public string Category { get; set; }

        [Required(ErrorMessage ="There is no image. Please select an image")]
        public string Image { get; set; }
        
        public ItemViewModel() { }
        public ItemViewModel(Guid id, string title, string description, DateTime createdate, DateTime expirationdate,
            string city, string condition, string region, string category, string image)
        {
            this.ItemID = id;
            this.Title = title;
            this.Description = description;
            this.CreateDate = createdate;
            this.ExpirationDate = expirationdate;
            this.City = city;
            this.Condition = condition;
            this.Region = region;
            this.Category = category;
            this.Image = image;
        }
    }
}