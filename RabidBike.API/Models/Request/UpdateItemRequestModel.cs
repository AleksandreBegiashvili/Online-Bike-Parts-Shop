using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RabidBike.API.Models.Request
{
    public class UpdateItemRequestModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int ConditionId { get; set; }

        [Required]
        public int LocationId { get; set; }

    }
}
