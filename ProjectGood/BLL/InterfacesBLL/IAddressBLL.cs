using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.InterfacesBLL
{
    public interface IAddressBLL
    {
        Task<int> Add(DTO.Classes.AddressDTO address);
    }
}
