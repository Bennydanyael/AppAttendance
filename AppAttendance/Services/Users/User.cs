using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppAttendance.Services.Users
{
    public class User : IUsers
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public User(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void LogCurrentUser()
        {
            var username = _httpContextAccessor.HttpContext.User.Identity.Name;
            //service.LogAccessRequest(username);
        }
    }
}
