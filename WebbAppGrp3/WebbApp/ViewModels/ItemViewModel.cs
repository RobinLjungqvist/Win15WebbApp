using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebbApp.DAL.DB.Models;

namespace WebbApp.ViewModels
{
    public class ItemViewModel
    {
        public Guid ItemID { get; set; }

        [Required(ErrorMessage ="Must enter the title of the item")]
        [RegularExpression(@"^[a-öA-Ö''-'\s]{1,40}$", ErrorMessage = "Must be letters between a-ö or A-Ö")]
        public string Title { get; set; }

        [Required(ErrorMessage ="Must enter a description for the item")]
        //[RegularExpression(@"^[a-öA-Ö''-'\s]{1,40}$", ErrorMessage = "Must be letters between a-ö or A-Ö")]
        [StringLength(30, ErrorMessage="Must enter a description for the item", MinimumLength = 1)]
        public string Description { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        //public City City { get; set; }
        //public Region Region { get; set; }

        [Required(ErrorMessage ="Must enter the condition of the item")]
        public Condition Condition { get; set; }
        public int SelectedConditionId { get; set; }
        public List<Condition> Conditions { get; set; }

        [Required(ErrorMessage = "Must enter the city")]
        public City City { get; set; }
        public int SelectedCityId { get; set; }
        public List<City> Cities { get; set; }

        [Required(ErrorMessage = "Must enter the region")]
        public Region Region { get; set; }
        public int SelectedRegionId { get; set; }
        public List<Region> Regions { get; set; }

        [Required(ErrorMessage ="Must enter the category of the item")]
        public Category Category { get; set; }
        public int SelectedCategoryId { get; set; }
        public List<Category> Categories { get; set; }

        //[Required(ErrorMessage ="There is no image. Please select an image")]
        public ICollection<Image> Images { get; set; }
        
        public ItemViewModel() { }
        public ItemViewModel(Guid id, string title, string description, DateTime createdate, DateTime expirationdate,
            City city, Condition condition, Region region, Category category, ICollection<Image> images)
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
            this.Images = images;
        }
    }
}