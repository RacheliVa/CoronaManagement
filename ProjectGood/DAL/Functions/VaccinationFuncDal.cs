using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions
{
    public class VaccinationFuncDal : IVaccinationDAL
    {
        CoronaProjectContext db;
        public VaccinationFuncDal(CoronaProjectContext coronaProject)
        {
            db = coronaProject;
        }
        public  async Task<bool> addVaccination(Vaccination vaccination)
        {
            try
            {
                db.Vaccinations.AddAsync(vaccination);
              await  db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            throw new NotImplementedException();
        }

    }
}
