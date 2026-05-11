using MegaTec_Task.Models;
using Microsoft.EntityFrameworkCore;

namespace MegaTec_Task.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Person> Persons => Set<Person>();
}
