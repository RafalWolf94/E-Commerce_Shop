using System.Collections.Generic;

namespace API.Error
{
    public class ApiValidationErrorResponse :ApiResponse
    {
        public ApiValidationErrorResponse() : base(400)
        {
        }
        public IEnumerable<string> Erros { get; set; }
        
    }
}