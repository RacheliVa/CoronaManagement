using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Classes
{
    public class VaccinationDTO
    {
        public short Id { get; set; }

        public int? CustId { get; set; }

        [DataType(DataType.Date)]
        public DateOnly? Date { get; set; }

        public string? Manufacturer { get; set; }
    }
}
