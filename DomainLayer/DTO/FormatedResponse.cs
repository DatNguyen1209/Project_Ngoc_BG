using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO
{
    public class FormatedResponse
    {
        public string MessageCode { get; set; } = string.Empty;
        public EnumErrorType ErrorType { get; set; }
        public EnumStatusCode EnumStatusCode { get; set; } = EnumStatusCode.StatusCode200;
        public object? InnerBody { get; set; }
    }
}
