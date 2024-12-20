﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CafeMenuProject.Models
{
    public class ProductCategoryViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ImagePath { get; set; }
        public decimal Price { get; set; }
        public bool IsDeleted { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<string> PropertyName { get; set; }
    }
}