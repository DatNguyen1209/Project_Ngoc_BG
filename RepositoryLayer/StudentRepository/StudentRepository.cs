using DomainLayer.DTO;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.StudentRepository
{
    public class StudentRepository: IStudentRepository
    {
        private readonly StudentDbContext _context;
        public StudentRepository(StudentDbContext context)
        {
            _context = context;
        }
        public async Task<FormatedResponse> GetAll()
        {
            try
            {
                var response = await _context.Students.AsNoTracking().AsQueryable().ToListAsync();
                return new FormatedResponse() { InnerBody = response }; 
            }
            catch (Exception ex)
            {
                return new FormatedResponse() { MessageCode = ex.Message};
            }
        }

        public async Task<FormatedResponse> GetById(long id)
        {
            try
            {
                var response = await (from s in _context.Students.Where(x => x.Id == id)
                                      select new StudentDTO()
                                      {
                                          Id = s.Id,
                                          Code = s.Code,
                                          Name = s.Name,
                                          BirthDate = s.BirthDate,
                                          Prioritize = s.Prioritize,
                                          Deffect = s.Deffect,
                                          Address = s.Address,
                                          Phone = s.Phone,
                                      }).SingleAsync();
                return new FormatedResponse() { InnerBody = response };
            }
            catch (Exception ex)
            {

                return new FormatedResponse() { MessageCode = ex.Message };
            }
        }

        public virtual async Task<FormatedResponse> Create(StudentDTO dto)
        {
            try
            {
                Student entity = new Student();
                List<Student_Violated> list = new List<Student_Violated>();
                entity.Code = dto.Code;
                entity.Name = dto.Name;
                entity.BirthDate = dto.BirthDate;
                entity.Deffect = dto.Deffect;
                entity.Prioritize = dto.Prioritize;
                entity.Address = dto.Address;
                entity.Phone = dto.Phone;
                _context.Students.Add(entity);

                var addParentResponse = new FormatedResponse() { InnerBody = entity};
                var newObject = addParentResponse.InnerBody as Student;
                if(dto.Ids.Count() > 0)
                {
                    dto.Ids.ForEach(item =>
                    {
                        list.Add(new Student_Violated()
                        {
                            StudentId = newObject.Id,
                            ViolateId = item,
                            CreatedDate = DateTime.Now,
                        });
                    });
                    _context.StudentViolations.AddRange(list);
                }
                
                return new FormatedResponse() { InnerBody = entity };   
            }
            catch (Exception ex)
            {

                return new FormatedResponse() { MessageCode = ex.Message };
            }
        }
        public async Task<FormatedResponse> Update(StudentDTO dto)
        {
            try
            {
                var checkData = await _context.Students.Where(x => x.Id == dto.Id).SingleAsync();
                if (checkData != null)
                {
                    Student entity = new Student();
                    entity.Id = (long)dto.Id;
                    entity.Code = dto.Code;
                    entity.Name = dto.Name;
                    entity.BirthDate = dto.BirthDate;
                    entity.Deffect = dto.Deffect;
                    entity.Prioritize = dto.Prioritize;
                    entity.Address = dto.Address;
                    entity.Phone = dto.Phone;
                    _context.Students.Update(entity);
                    return new FormatedResponse() { InnerBody = entity };
                }
                else
                {
                    return new FormatedResponse() { MessageCode = "Error when update to entity" };
                }
            }
            catch (Exception ex)
            {

                return new FormatedResponse() { MessageCode = ex.Message };
            }
        }

        public virtual async Task<FormatedResponse> DeleteById(long id)
        {
            try
            {
                var getDataToDelete = await _context.Students.FindAsync(id);
                if (getDataToDelete != null)
                {
                    _context.Students.Remove(getDataToDelete);
                    return new FormatedResponse { InnerBody = getDataToDelete, EnumStatusCode = EnumStatusCode.StatusCode200 };
                }
                else
                {
                    return new FormatedResponse() { MessageCode = "Entity not found!!!" };
                }
            }
            catch (Exception ex)
            {

                return  new FormatedResponse() { MessageCode = ex.Message };
            }
        }
    }
}
