using AutoMapper;
using BLL.InterfacesBLL;
using DAL.Interfaces;
using DTO;
using DTO.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.FunctionsBLL
{
    public class DiseaseBLL : IDiseaseBLL
    {
        IDisease disease;
        IMapper mapper;
        public DiseaseBLL(IDisease disease,IMapper mapper)
        {
            this.disease = disease;
            this.mapper = mapper;
        }
        public async Task<DiseaseDTO> GetDiseaseByCustId(int custId)
        {
            var foundDisease= await disease.GetDiseaseByCustId(custId);
            return mapper.Map<DTO.Classes.DiseaseDTO>(foundDisease);
        }
        public async Task<bool> addDisease(DiseaseDTO newDisease)
        {
             await disease.addDisease(mapper.Map<DAL.Disease>(newDisease));
            return true;
        }
    }
}
