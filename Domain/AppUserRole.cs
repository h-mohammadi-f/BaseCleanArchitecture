using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class AppUserRole : IdentityRole<Guid>
    {

        public AppUserRole(string name) : base(name)
        {
            
        }

    }
}