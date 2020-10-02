using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Data.Entities
{
    public interface IUserAudit
    {
        long CreationUser { get; set; }
        long? ModificationUser { get; set; }
    }
}
