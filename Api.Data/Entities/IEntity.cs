using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Data.Entities
{
    public interface IEntity<K> where K : struct
    {
        K Id { get; set; }
    }
}
