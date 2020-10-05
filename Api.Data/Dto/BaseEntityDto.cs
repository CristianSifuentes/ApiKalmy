using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Api.Data.Dto
{
    public abstract class BaseEntityDto
    {
        protected BaseEntityDto()
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
