﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BargainHunterAPI.Models
{
    public class Products
    {
        public int ID { get; set; }
        public string Retailer { get; set; }
        public string BrandName { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string DetailsUrl { get; set; }
        public string ImageUrl { get; set; }
    }
}