using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AUG30.Portfolio.Web.Models;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public DbSet<AUG30.Portfolio.Web.Models.ProfileModel> ProfileModel { get; set; } = default!;
    public DbSet<UserModel> UserModel { get; set; }
    public DbSet<ServiceModel> ServiceModel { get; set; }
}
