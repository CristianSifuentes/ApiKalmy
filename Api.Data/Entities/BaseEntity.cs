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
            FechaCreacion = DateTime.Now;
            FechaModificacion = DateTime.Now;
        }
        [DataType(DataType.DateTime)]
        public DateTime FechaCreacion { get; private set; }
        [DataType(DataType.DateTime)]
        public DateTime? FechaModificacion { get; set; }
    }
}
