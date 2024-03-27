using AutoMapper;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class mapper:Profile
    {
        public mapper()
        {
            CreateMap<DAL.Customer, DTO.Classes.CustomerDTO>().
                ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City)).
                ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Address.Street)).
                ForMember(dest => dest.NumHouse, opt => opt.MapFrom(src => src.Address.NumHouse));
            CreateMap<DTO.Classes.CustomerDTO, DAL.Customer>();

            CreateMap<DAL.Address,DTO.Classes.AddressDTO>();
            CreateMap<DTO.Classes.AddressDTO, DAL.Address>();

            CreateMap<DTO.Classes.VaccinationDTO, DAL.Vaccination>();
            CreateMap<DAL.Vaccination,DTO.Classes.VaccinationDTO>();

            CreateMap<DAL.Disease, DTO.Classes.DiseaseDTO>();
                //.ForMember(dest=> dest.diseaseDays,opt=>opt.MapFrom(src=>src.DateIn - src.Dat);   
            CreateMap<DTO.Classes.DiseaseDTO, DAL.Disease>();   
        }
    }
}
