using AutoMapper;
using BLL.InterfacesBLL;
using DAL.Interfaces;
using DTO.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.FunctionsBLL
{
    public class VaccinationBLL : IVaccinationBLL
    {
        IMapper mapper;
        IVaccinationDAL VaccinationDAL;
        public VaccinationBLL(IMapper mapper,IVaccinationDAL vaccination) 
        {
             this.mapper = mapper;
             this.VaccinationDAL = vaccination;
        }
        public Task<bool> addVaccination(VaccinationDTO vaccinationDTO)
        {
          return VaccinationDAL.addVaccination(mapper.Map<DAL.Vaccination>(vaccinationDTO));
        }
    }
}
