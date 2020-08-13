using AppAttendance.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AppAttendance.Services.Cokiess
{
    public class ClaimsTransformer : IClaimsTransformation
    {
        private readonly AppDbContext _context;

        public ClaimsTransformer(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            var existingClaimsIdentity = (ClaimsIdentity)principal.Identity;
            var currentUserName = existingClaimsIdentity.Name;

            // Initialize a new list of claims for the new identity
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, currentUserName),
                // Potentially add more from the existing claims here
            };

            // Find the user in the DB
            // Add as many role claims as they have roles in the DB
            //IdentityUser user = _context.Pengurus.SingleOrDefaultAsync(u => u.Username.Equals(currentUserName, StringComparison.CurrentCultureIgnoreCase));
            //if (user != null)
            //{
            //    var rolesNames = from ur in _context.Pengurus.Where(p => p.IdPengurus.ToString() == user.Id)
            //                     from r in _context.Pengurus
            //                     where ur.IdPengurus == r.IdPengurus
            //                     select r.Username;

            //    claims.AddRange(rolesNames.Select(x => new Claim(ClaimTypes.Role, x)));
            //}

            // Build and return the new principal
            var newClaimsIdentity = new ClaimsIdentity(claims, existingClaimsIdentity.AuthenticationType);
            return new ClaimsPrincipal(newClaimsIdentity);
        }
    }
}
