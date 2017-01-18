using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebbApp.Mockup.Models
{
    public class MockupImage
    {
        public Guid ImageID { get; set; }
        public string Path { get; set; }
        public Guid ItemID { get; set; }
    }
}