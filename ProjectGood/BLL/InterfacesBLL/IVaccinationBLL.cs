using DTO.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.InterfacesBLL
{
    public interface IVaccinationBLL
    {
        Task<bool>addVaccination(VaccinationDTO vaccinationDTO);
    }
}
