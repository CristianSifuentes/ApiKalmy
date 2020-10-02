using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Api.Data.Dto
{
    public class CarDto : BaseEntityDto
    {
        [Required]
        public long Id { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public int Model { get; set; }

    }

}




