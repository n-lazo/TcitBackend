﻿using Microsoft.EntityFrameworkCore;
using TcitBackend.Models;

namespace TcitBackend.Data;
public class AppDbContext : DbContext
{
    public DbSet<Post> Posts { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}