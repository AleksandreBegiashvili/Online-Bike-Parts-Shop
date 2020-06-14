using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RabidBike.Domain.Entities
{
    public class Item : BaseEntity<int>
    {
        //public int ItemNumber { get; set; }
        public string Name { get; set; }

        public int Price { get; set; }

        public string Description { get; set; }

        public DateTime ListDate { get; set; }

        public DateTime ExpireDate { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public int ConditionId { get; set; }
        [ForeignKey("ConditionId")]
        public Condition Condition { get; set; }

        public int LocationId { get; set; }
        [ForeignKey("LocationId")]
        public Location Location { get; set; }

        public string SellerId { get; set; }
        [ForeignKey("SellerId")]
        public ApplicationUser Seller { get; set; }
    }
}
