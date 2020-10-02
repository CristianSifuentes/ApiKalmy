using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Api.Data.Entities
{
    public class Car : BaseEntity , IUserAudit, IEntity<long>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public int Model { get; set; }
        public long CreationUser { get; set; }
        public long? ModificationUser { get; set; }
    }
}
