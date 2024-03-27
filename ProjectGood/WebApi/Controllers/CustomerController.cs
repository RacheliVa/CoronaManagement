using BLL.InterfacesBLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerBLL customerBLL;
        public CustomerController(ICustomerBLL customerBLL)
        {
           this. customerBLL=customerBLL;
        }
        [HttpGet]
        public async Task<List<DTO.Classes.CustomerDTO>> GetAll()
        {
            return await customerBLL.GetCustomers();
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<DTO.Classes.CustomerDTO> getById(int id)
        {
            return await customerBLL.GetCustomersById(id);
        }
        [HttpGet]
        [Route("getVaccination/{id}")]
        public async Task<List<DTO.Classes.VaccinationDTO>> GetVaccination(int id)
        {
            return await  customerBLL.GetVaccinationsByCust(id);
        }
        [HttpPost]
        public async Task<DTO.Classes.CustomerDTO> addCustomer(DTO.Classes.CustomerDTO customer)
        {
            return await customerBLL.addCustomer(customer);
        }
        [HttpPut]
        [Route("updateCustomer")]
        public Task<bool>updateCustomer(DTO.Classes.CustomerDTO customer)
        {
            return customerBLL.updateCustomer(customer);
        }
        [HttpDelete]
        [Route("{id}")]
        public Task<bool> deleteCustomer(int id)
        {
            return customerBLL.removeCustomer(id);
        }
    }
}
