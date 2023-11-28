using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO
{
    public class StudentDTO:BaseDTO
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Image { get; set; }
        public string? Deffect { get; set; }
        public string? Prioritize { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public List<long>? Ids { get; set; }
    }

    public class StudentConverter
    {
        public Student DtoToEntity(StudentDTO dto)
        {
            Student entity = new Student();
            entity.Code = dto.Code;
            entity.Name = dto.Name;
            entity.BirthDate = dto.BirthDate;
            entity.Prioritize = dto.Prioritize;
            entity.Deffect = dto.Deffect;
            entity.Address = dto.Address;
            entity.Phone = dto.Phone;

            return entity;
        }
    }
}
