﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DomainModel.DTO.ProductFeatureValues
{
    public class ProductFeatureSearchJoin
    {
        public int ProductFeatureValueID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string FeatureName { get; set; }
        public string FeatureValue { get; set; }
    }
}
