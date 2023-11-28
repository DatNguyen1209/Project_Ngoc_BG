using DomainLayer.DTO;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.ViolateRepository
{
    public class ViolateRepository : IViolateRepository
    {
        private readonly StudentDbContext _studentDbContext;
        public IViolateRepository _violateRepository;
        public ViolateRepository(StudentDbContext studentDbContext, IViolateRepository violateRepository)
        {
            _studentDbContext = studentDbContext;
            _violateRepository = violateRepository;
        }

        public async Task<FormatedResponse> GetAll()
        {
            try
            {
                var response = await _studentDbContext.Violates.ToListAsync();
                return new FormatedResponse() { InnerBody = response };
            }
            catch (Exception ex)
            {

                return new FormatedResponse() { MessageCode = ex.Message };
            }
        }
        public async Task<FormatedResponse> GetById(long id)
        {
            try
            {
                var response = await (from v in _studentDbContext.Violates.Where(x => x.Id == id)
                                      select new ViolateDTO()
                                      {
                                          Id = v.Id,
                                          Code = v.Code,
                                          Name = v.Name,
                                          Point = v.Point,
                                      }).SingleAsync();
                return new FormatedResponse() { InnerBody = response };
            }
            catch (Exception ex)
            {

                return new FormatedResponse() { MessageCode = ex.Message };
            }
        }

        public virtual async Task<FormatedResponse> Create(ViolateDTO dto)
        {
            try
            {
                Violate entity = new Violate();
                entity.Code = dto.Code;
                entity.Name = dto.Name;
                entity.Point = dto.Point;
                _studentDbContext.Violates.Add(entity);
                return new FormatedResponse() { InnerBody = entity, EnumStatusCode = EnumStatusCode.StatusCode200};
            }
            catch (Exception ex)
            {

                return new FormatedResponse() { MessageCode = ex.Message };
            }
        }

        public virtual async Task<FormatedResponse> Update(ViolateDTO dto)
        {
            try
            {
                var getDataUpdate = await _studentDbContext.Violates.Where(x => x.Id == dto.Id).SingleAsync();
                if (getDataUpdate != null)
                {
                    Violate entity = new Violate();
                    entity.Id = (long)dto.Id;
                    entity.Name = dto.Name;
                    entity.Point = dto.Point;
                    entity.Code = dto.Code;
                    _studentDbContext.Violates.Update(entity);
                    return new FormatedResponse() { InnerBody = entity };
                }
                else
                {
                    return new FormatedResponse() { EnumStatusCode = EnumStatusCode.StatusCode400, MessageCode = "Update Faild!!!" };
                }
            }
            catch (Exception ex)
            {

                return new FormatedResponse() { MessageCode = ex.Message };
            }
        }

        public async Task<FormatedResponse> DeleteById(long id)
        {
            try
            {
                var getDataToDelete = await _studentDbContext.Violates.Where(x => x.Id == id).SingleAsync();
                _studentDbContext.Violates.Remove(getDataToDelete);
                return new FormatedResponse() { EnumStatusCode = EnumStatusCode.StatusCode200, MessageCode = "Delete success!!!" };
            }
            catch (Exception ex)
            {

                return new FormatedResponse() { MessageCode = ex.Message };
            }
        }
    }
}
