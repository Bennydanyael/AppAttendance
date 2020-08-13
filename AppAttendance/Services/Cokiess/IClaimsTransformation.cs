using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AppAttendance.Services.Cokiess
{
    public interface IClaimsTransformation
    {
        Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal);
    }
}
