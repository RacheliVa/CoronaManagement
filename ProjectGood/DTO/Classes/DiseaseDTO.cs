using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Classes
{
    public class DiseaseDTO
    {
        public short Id { get; set; }

        public int? CustId { get; set; }

        public DateOnly? DateIn { get; set; }

        public DateOnly? DateOut { get; set; }
        public int diseaseDays {  get; set; }
    }
}
