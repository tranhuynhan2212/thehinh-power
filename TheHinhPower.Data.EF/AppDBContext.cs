using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TheHinhPower.Data.EF.Configurations;
using TheHinhPower.Data.EF.Extensions;
using TheHinhPower.Data.Entities;
using TheHinhPower.Infrastructure.SharedKernel;

namespace TheHinhPower.Data.EF
{
    public class AppDBContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public AppDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<AppRole> AppRoles { set; get; }
        public DbSet<AppUser> AppUsers { set; get; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region Identity Config

            builder.Entity<IdentityUserClaim<string>>().ToTable("AppUserClaims").HasKey(x => x.Id);
            builder.Entity<IdentityRoleClaim<string>>().ToTable("AppRoleClaims").HasKey(x => x.Id);
            builder.Entity<IdentityUserLogin<string>>().ToTable("AppUserLogins").HasKey(x => x.UserId);
            builder.Entity<IdentityUserRole<string>>().ToTable("AppUserRoles").HasKey(x => new { x.RoleId, x.UserId });
            builder.Entity<IdentityUserToken<string>>().ToTable("AppUserTokens").HasKey(x => new { x.UserId });

            #endregion Identity Config

            builder.AddConfiguration(new FunctionConfiguration());
            builder.ApplyGlobalFilters<IDelete>(e => e.IsDeleted == false);
            base.OnModelCreating(builder);
        }
    }
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDBContext>
    {
        public AppDBContext CreateDbContext(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<AppDBContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);
            return new AppDBContext(builder.Options);
        }
    }
}
