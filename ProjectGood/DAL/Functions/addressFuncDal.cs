using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions
{
    public class addressFuncDal : IAddressDAL
    {
        CoronaProjectContext db;
        public addressFuncDal(CoronaProjectContext coronaProject)
        {
            db = coronaProject;
        }
        public  async Task<int> addAddress(Address address)
        {
            try
            {
                db.Addresses.AddAsync(address);
                db.SaveChanges();
                var newAdress = await db.Addresses.FirstOrDefaultAsync(o => o.City == address.City && o.Street == address.Street && o.NumHouse == address.NumHouse);
                return newAdress.Id;
                    }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
