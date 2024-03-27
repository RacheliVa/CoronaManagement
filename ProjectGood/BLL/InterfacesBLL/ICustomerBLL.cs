using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.InterfacesBLL
{
    public interface ICustomerBLL
    {
        Task<List<DTO.Classes.CustomerDTO>> GetCustomers();
        Task<DTO.Classes.CustomerDTO> GetCustomersById(int id);
        Task<DTO.Classes.CustomerDTO> addCustomer(DTO.Classes.CustomerDTO customerDTO);
        Task<List<DTO.Classes.VaccinationDTO>> GetVaccinationsByCust(int id);
        Task<bool> removeCustomer(int id);
        Task<bool> updateCustomer(DTO.Classes.CustomerDTO customerDTO);
    }
}
