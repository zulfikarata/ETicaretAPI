using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Exceptions
{
    public class AuthentationErrorException : Exception
    {
        public AuthentationErrorException(): base("Kimlik doğrulama hatası!")
        {
        }

        public AuthentationErrorException(string? message) : base(message)
        {
        }

        public AuthentationErrorException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
