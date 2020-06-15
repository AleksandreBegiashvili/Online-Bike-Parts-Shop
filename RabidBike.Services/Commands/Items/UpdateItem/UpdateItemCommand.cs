using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabidBike.Services.Commands.Items.UpdateItem
{
    public class UpdateItemCommand : IRequest<UpdateItemCommandResponse>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public int ConditionId { get; set; }

        public int LocationId { get; set; }

    }
}
