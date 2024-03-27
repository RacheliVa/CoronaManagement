using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICustomer
    {
        Task<List<Customer>> GetAll();
        Task<Customer> GetById(int id);
        Task<Customer> addCustoemr(Customer customer);
        Task<bool> removeCustoemr(int id);
        Task<bool> updateCustomer(Customer customer);
        Task<List<Vaccination>> GetVaccinationsByCust(int id);
    }
}
