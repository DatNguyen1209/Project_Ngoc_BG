using DomainLayer.DTO;
using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer;
using RepositoryLayer.ViolateRepository;

namespace BTL_N.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViolateController : ControllerBase
    {
        public IViolateRepository _violateRepository;
        public StudentDbContext _studentDbContext;

        public ViolateController(StudentDbContext studentDbContext, IViolateRepository violateRepository)
        {
            _studentDbContext = studentDbContext;
            _violateRepository = violateRepository;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _violateRepository.GetAll();
            return Ok(response);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(long id)
        {
            var response = await _violateRepository.GetById(id);
            return Ok(response);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(ViolateDTO dto)
        {
            var response = await _violateRepository.Create(dto);
            return Ok(response);
        }

        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> Update(ViolateDTO dto)
        {
            var response = await _violateRepository.Update(dto);
            return Ok(response);
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<IActionResult> DeleteById(long id)
        {
            var response = await _violateRepository.DeleteById(id);
            return Ok(response);
        }
    }
}
