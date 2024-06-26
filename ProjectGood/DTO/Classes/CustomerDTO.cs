﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Classes
{
    public class CustomerDTO
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Phone { get; set; }

        public DateOnly? BirthDate { get; set; }
        public int? addressId { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public int? NumHouse { get; set; }


    }
}
