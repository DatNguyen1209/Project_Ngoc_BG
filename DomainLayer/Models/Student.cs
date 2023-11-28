using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Image { get; set; }
        public string? Deffect { get; set; }
        public string? Prioritize { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
    }
}
