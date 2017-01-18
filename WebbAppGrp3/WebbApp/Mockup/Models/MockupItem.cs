using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebbApp.Mockup.Models
{
    public class MockupItem
    {
        public Guid ItemID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ExpirationDate { get; set; }
       
        public Guid CityID { get; set; }
        public Guid ConditionID { get; set; }
        public Guid RegionID { get; set; }
        public Guid CategoryID { get; set; }



    }
}