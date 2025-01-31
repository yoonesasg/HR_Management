using HR_Management.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace HR_Management.Identity
{
    internal class HR_ManagementIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
    }
}
