using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabidBike.API.Models.Response
{
    public class ItemsListByCategoryResponse
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public DateTime ListDate { get; set; }

        public int CategoryId { get; set; }
        public string Category { get; set; }

        //public int ConditionId { get; set; }
        public string Condition { get; set; }

        //public int LocationId { get; set; }
        public string Location { get; set; }

        //public string SellerId { get; set; }
        public string Seller { get; set; }
    }
}
