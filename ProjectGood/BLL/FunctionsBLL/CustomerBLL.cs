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
    public class CustomerBLL : ICustomerBLL
    {
        ICustomer CustomerDAL;
        IAddressDAL AddressDAL;
        IMapper mapper;
        public CustomerBLL(ICustomer customer,IMapper mapper,IAddressDAL addressDAL) { 
         this.CustomerDAL = customer;
            this.mapper = mapper;
            this.AddressDAL = addressDAL;   
        }
        public  async Task<CustomerDTO> addCustomer(CustomerDTO customerDTO)
        {         
            AddressDTO newAddress =new AddressDTO();
            newAddress.Street = customerDTO.Street;
            newAddress.City = customerDTO.City;
            newAddress.NumHouse = customerDTO.NumHouse;
           int addressId= await AddressDAL.addAddress(mapper.Map<DAL.Address>(newAddress));
            customerDTO.addressId = addressId;
            var newCust= await CustomerDAL.addCustoemr(mapper.Map<CustomerDTO,DAL.Customer>(customerDTO));
            return mapper.Map<CustomerDTO>(newCust);
        }
        public  async Task<List<CustomerDTO>> GetCustomers()
        {
            var list = await CustomerDAL.GetAll();
            return mapper.Map<List<CustomerDTO>>(list);
        }

        public async Task<CustomerDTO> GetCustomersById(int id)
        {
            var customer = await CustomerDAL.GetById(id);
            return mapper.Map<CustomerDTO>(customer);
        }

        public async Task<List<VaccinationDTO>> GetVaccinationsByCust(int id)
        {
            try
            {
                var VaccinationList = await CustomerDAL.GetVaccinationsByCust(id);
                return mapper.Map<List<DTO.Classes.VaccinationDTO>>(VaccinationList);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> removeCustomer(int id)
        {
            return await CustomerDAL.removeCustoemr(id);
        }

        public async Task<bool> updateCustomer(CustomerDTO customerDTO)
        {
          return await CustomerDAL.updateCustomer(mapper.Map<CustomerDTO,DAL.Customer>(customerDTO));    
        }
    }
}
