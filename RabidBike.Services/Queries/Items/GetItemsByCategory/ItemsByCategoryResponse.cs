﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RabidBike.Services.Queries.Items.GetItemsByCategory
{
    public class ItemsByCategoryResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public DateTime ListDate { get; set; }

        public int CategoryId { get; set; }
        public string Category { get; set; }

        public string Condition { get; set; }

        public string Location { get; set; }

        public string Seller { get; set; }
    }
}
