using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Data.Dto
{
    public abstract class BaseEntityDto
    {
        protected BaseEntityDto()
        {

        }
        public DateTime CreatedAt { get; private set; }

        public DateTime? ModifiedAt { get; set; }
    }
}
