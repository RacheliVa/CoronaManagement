using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.functions
{
    public class customerFuncDal : ICustomer
    {
        CoronaProjectContext db;
        public customerFuncDal(CoronaProjectContext coronaContext)
        {
            this.db = coronaContext;
        }
        public async Task<Customer> addCustoemr(Customer customer)
        {
            try
            {
                db.Customers.AddAsync(customer);
                 await  db.SaveChangesAsync();
                var newCustomer =  await db.Customers.FirstOrDefaultAsync(c => c.Id == customer.Id);
                return newCustomer;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<List<Customer>> GetAll()
        {
            return db.Customers.Include(c=>c.Address).ToListAsync();
        }

        public async Task<Customer> GetById(int id)
        {
            try
            {
                Customer customer = await db.Customers.Include(c=>c.Address).FirstOrDefaultAsync(c => c.Id == id);
                if (customer != null)
                {
                    return customer;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        public async Task<List<Vaccination>> GetVaccinationsByCust(int id)
        {
            try
            {
                Customer customer = await db.Customers.Include(c=>c.Vaccinations).FirstOrDefaultAsync(c => c.Id == id);
             var l= customer.Vaccinations.ToList();
                return l;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> removeCustoemr(int id)
        {
            try
            {
                db.Customers.Remove(db.Customers.FirstOrDefault(u => u.Id == id));
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
       
        public async Task<bool> updateCustomer(Customer customer)
        {
            try
            {
                var customerToUpdate = await db.Customers.FirstOrDefaultAsync(c => c.Id == customer.Id);
                if (customerToUpdate == null)
                {
                    return false;
                }
                customerToUpdate.Name = customer.Name;
                customerToUpdate.BirthDate = customer.BirthDate;
                customerToUpdate.Address = customer.Address;
                customerToUpdate.Phone = customer.Phone;
                customerToUpdate.Vaccinations = customer.Vaccinations;
                customerToUpdate.Diseases = customer.Diseases;
                db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
