using System;
using System.Collections.Generic;
using System.Text;

namespace RabidBike.Domain.Entities
{
    public class BaseEntity<T> where T : struct
    {
        public virtual T Id { get; set; }
    }
}
