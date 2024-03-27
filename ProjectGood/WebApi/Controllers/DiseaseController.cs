using BLL.InterfacesBLL;
using DTO.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiseaseController : ControllerBase
    {
        IDiseaseBLL bLL;
        public DiseaseController(IDiseaseBLL disease) {
           bLL = disease;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<DiseaseDTO> GetDiseaseByCustId(int id) 
        { 
           return await bLL.GetDiseaseByCustId(id);
        }
        [HttpPost]
        public async Task<bool> addDisease(DiseaseDTO disease)
        {
            return await bLL.addDisease(disease);
        }
    }
}
