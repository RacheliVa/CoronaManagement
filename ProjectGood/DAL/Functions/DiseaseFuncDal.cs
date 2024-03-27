using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions
{
    public class DiseaseFuncDal : IDisease
    {
        CoronaProjectContext db;
        public DiseaseFuncDal(CoronaProjectContext coronaProject)
        {
            this.db = coronaProject;
        }

        public async Task<bool> addDisease(Disease disease)
        {
            try
            {
                db.Diseases.AddAsync(disease);
                db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public async Task<Disease> GetDiseaseByCustId(int custId)
        {
            try
            {
                return await db.Diseases.FirstOrDefaultAsync(d => d.CustId == custId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
