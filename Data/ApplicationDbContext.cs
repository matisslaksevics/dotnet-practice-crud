using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DotnetPracticeCrud.Models;

namespace DotnetPracticeCrud.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<DotnetPracticeCrud.Models.BookModel> BookModel { get; set; } = default!;
        public DbSet<DotnetPracticeCrud.Models.ClientModel> ClientModel { get; set; } = default!;
    }
}
