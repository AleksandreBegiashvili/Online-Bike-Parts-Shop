using System;
using System.Collections.Generic;
using System.Text;

namespace RabidBike.Services.Queries.Items.GetItemsByCategory
{
    public class ItemsByCategoryResponse
    {
        public string Name { get; set; }

        public int Price { get; set; }

        public string Description { get; set; }

        public DateTime ListDate { get; set; }

        public int CategoryId { get; set; }
    }
}
