using DomainLayer.DTO;
using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer;
using RepositoryLayer.StudentRepository;

namespace BTL_N.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class StudentController : ControllerBase
    {
        public IStudentRepository _studentRepository;
        public StudentDbContext _studentDbContext;
        public ILogger<StudentController> _logger;
        public StudentController(StudentDbContext dbContext , ILogger<StudentController> logger)
        {
            _studentDbContext = dbContext;
            _studentRepository = new StudentRepository(dbContext); ;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            var response = await _studentRepository.GetAll();
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(long id) 
        {
            var response = await _studentRepository.GetById(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentDTO dto)
        {
            var response = await _studentRepository.Create(dto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Update(StudentDTO dto)
        {
            var response = await _studentRepository.Update(dto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(long id)
        {
            var response = await _studentRepository.DeleteById(id);
            return Ok(response);
        }
    }
}
