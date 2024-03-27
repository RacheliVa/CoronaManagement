using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDisease
    {
        Task<Disease> GetDiseaseByCustId(int custId);
        Task<bool> addDisease(Disease disease);
    }
}
