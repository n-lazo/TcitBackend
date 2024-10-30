using Microsoft.EntityFrameworkCore;
using TcitBackend.Models;

namespace TcitBackend.Data;
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Post> Posts { get; set; }
}