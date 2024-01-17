using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AUG30.Portfolio.Model;
using Microsoft.EntityFrameworkCore;


public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public DbSet<ProfileModel> ProfileModel { get; set; } = default!;
    public DbSet<UserModel> UserModel { get; set; }
    public DbSet<ServiceModel> ServiceModel { get; set; }
    public DbSet<CLientModel> ClientModel { get; set; }
    public DbSet<ClientMessageModel> ClientMessageModel { get; set; }

   
}
