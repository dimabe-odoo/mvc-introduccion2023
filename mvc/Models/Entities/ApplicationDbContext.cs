using Microsoft.EntityFrameworkCore;

//  import Microsoft.EntityFrameworkCore

namespace mvc.Models.Entities;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Job> Jobs { get; set; }
}