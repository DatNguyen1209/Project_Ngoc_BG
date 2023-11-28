using DomainLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.StudentViolateRepository
{
    public interface IStatusViolateRepository
    {
        Task<FormatedResponse> GetAllViolateByStudentId(long id);
    }
}
