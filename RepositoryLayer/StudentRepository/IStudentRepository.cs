using DomainLayer.DTO;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.StudentRepository
{
    public interface IStudentRepository
    {
        Task<FormatedResponse> GetAll();
        Task<FormatedResponse> GetById(long id);
        Task<FormatedResponse> Create(StudentDTO dto);
        Task<FormatedResponse> Update(StudentDTO dto);
        Task<FormatedResponse> DeleteById(long id);
    }
}
