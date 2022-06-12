using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace Store.Models
{
    public class IdentityUserDbContext : IdentityDbContext<IdentityUser>
    { 
        public IdentityUserDbContext(DbContextOptions<IdentityUserDbContext> options):base(options)
        {

        }
    }
}
