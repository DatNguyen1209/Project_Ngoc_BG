using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Student_Violated
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long? Id { get; set; }
        public long? StudentId { get; set; }
        public long? ViolateId { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
