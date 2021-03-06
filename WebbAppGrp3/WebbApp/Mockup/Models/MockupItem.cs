﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebbApp.Mockup.Models
{
    public class MockupItem
    {
        public Guid ItemID { get; set; }

        [Required(ErrorMessage = "Must enter the title of the item")]
        [RegularExpression(@"^[a-öA-Ö''-'\s]{1,40}$", ErrorMessage = "Must be letters between a-ö or A-Ö")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Must enter a description for the item")]
        [RegularExpression(@"^[a-öA-Ö''-'\s]{1,40}$", ErrorMessage = "Must be letters between a-ö or A-Ö")]
        [StringLength(30, ErrorMessage = "Must enter a description for the item", MinimumLength = 1)]
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ExpirationDate { get; set; }

        [Required(ErrorMessage = "Must enter the city")]
        [RegularExpression(@"^[a-öA-Ö''-'\s]{1,40}$", ErrorMessage = "Must be letters between a-ö or A-Ö")]
        public string City { get; set; }

        [Required(ErrorMessage = "Must enter the condition of the item")]
        [RegularExpression(@"^[a-öA-Ö''-'\s]{1,40}$", ErrorMessage = "Must be letters between a-ö or A-Ö")]
        public string Condition { get; set; }

        [Required(ErrorMessage = "Must enter the region")]
        [RegularExpression(@"^[a-öA-Ö''-'\s]{1,40}$", ErrorMessage = "Must be letters between a-ö or A-Ö")]
        public string Region { get; set; }

        [Required(ErrorMessage = "Must enter the category of the item")]
        [RegularExpression(@"^[a-öA-Ö''-'\s]{1,40}$", ErrorMessage = "Must be letters between a-ö or A-Ö")]
        public string Category { get; set; }
        public string Image { get; set; }

        public MockupItem() { }

        public MockupItem(Guid id,string title, string description, DateTime createdate,DateTime expirationdate,
            string city, string condition, string region, string category,string image)
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