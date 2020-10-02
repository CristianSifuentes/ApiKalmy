using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Api.Data.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            CreatedAt = DateTime.Now;
            ModifiedAt = DateTime.Now;
        }
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; private set; }

        [DataType(DataType.DateTime)]
        public DateTime? ModifiedAt { get; set; }
    }
}
