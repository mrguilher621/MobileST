using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileStore.Models
{
    public class Product
    {
        public long ProductId { get; set; }
        public string  Brand { get; set; }
        public string Models { get; set; }
        public string Price { get; set; }
    }
}