using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppUserRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}