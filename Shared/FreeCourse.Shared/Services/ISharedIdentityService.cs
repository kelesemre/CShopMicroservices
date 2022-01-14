using System;
using System.Text;
using System.Collections.Generic;

namespace FreeCourse.Shared.Services
{
    public interface ISharedIdentityService
    {
        public string GetUserId { get; }
    }
}
