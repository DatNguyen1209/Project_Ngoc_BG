using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO
{
    public class ViolateDTO:BaseDTO
    {
        public long? Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public int? Point { get; set; }
    }

    //public class ViolateConverter
    //{
    //    public Violate DtoToEntity(ViolateDTO dto)
    //    {

    //    }
    //}
}
