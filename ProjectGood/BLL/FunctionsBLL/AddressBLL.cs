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
    public class AddressBLL : IAddressBLL
    {
        IAddressDAL addressDAL;
        IMapper mapper;
        public AddressBLL(IAddressDAL addressDAL, IMapper mapper) {
            this.addressDAL = addressDAL;
            this.mapper = mapper;
        }
        public  Task<int> Add(AddressDTO address)
        {
           return  addressDAL.addAddress(mapper.Map<DAL.Address>(address));
        }
    }
}
