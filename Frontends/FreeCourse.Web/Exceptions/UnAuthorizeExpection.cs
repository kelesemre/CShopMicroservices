using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace FreeCourse.Web.Exceptions
{
    public class UnAuthorizeExpection : Exception
    {
        public UnAuthorizeExpection() : base()
        {
        }

        public UnAuthorizeExpection(string message) : base(message)
        {
        }

        public UnAuthorizeExpection(string message, Exception innerException) : base(message, innerException)
        {
        }

    }
}
