using DTO.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.InterfacesBLL
{
    public interface IDiseaseBLL
    {
        Task<DTO.Classes.DiseaseDTO> GetDiseaseByCustId(int custId);
        Task<bool> addDisease(DiseaseDTO disease);

    }
}
