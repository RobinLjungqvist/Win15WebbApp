using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebbApp.ViewModels
{
    public class ItemViewModel
    {

        public Guid ItemID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ExpirationDate { get; set; }

        public string City { get; set; }
        public string Condition { get; set; }
        public string Region { get; set; }
        public string Category { get; set; }
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