using DomainLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.ViolateRepository
{
    public interface IViolateRepository
    {
        Task<FormatedResponse> GetAll();
        Task<FormatedResponse> GetById(long id);
        Task<FormatedResponse> Create(ViolateDTO dto);
        Task<FormatedResponse> Update(ViolateDTO dto);
        Task<FormatedResponse> DeleteById(long id);
    }
}
