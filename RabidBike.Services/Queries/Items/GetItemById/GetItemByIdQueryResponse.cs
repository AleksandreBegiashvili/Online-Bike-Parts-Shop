using System;
using System.Collections.Generic;
using System.Text;

namespace RabidBike.Services.Queries.Items.GetItemById
{
    public class GetItemByIdQueryResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public string Description { get; set; }

        public DateTime ListDate { get; set; }

        public int CategoryId { get; set; }

        public int ConditionId { get; set; }

        public int LocationId { get; set; }

        public string SellerId { get; set; }
    }
}
