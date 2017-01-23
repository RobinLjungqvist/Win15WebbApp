﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebbApp.DAL.DB.Models
{
    [Table("Category")]
    class Category
    {
        [Key]
        public Guid CategoryId { get; set; }
        [Required, StringLength(25, ErrorMessage = "Max length is 25, min is 3.", MinimumLength = 3)]
        public string CategoryName { get; set; }
    }
}
