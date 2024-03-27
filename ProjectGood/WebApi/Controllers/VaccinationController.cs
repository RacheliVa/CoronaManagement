using BLL.InterfacesBLL;
using DTO.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccinationController : ControllerBase
    {
        IVaccinationBLL vaccinationBLL;
        public VaccinationController(IVaccinationBLL vaccination)
        {
            vaccinationBLL = vaccination;
        }
        [HttpPost]
        public async Task<bool> addVaccination(VaccinationDTO vaccination)
        {
            return  await vaccinationBLL.addVaccination(vaccination);
        }
    }
}
