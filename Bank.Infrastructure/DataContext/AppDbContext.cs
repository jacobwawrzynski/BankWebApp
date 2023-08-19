using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Bank.Core.Models;

namespace Bank.Infrastructure.DataContext
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountHistory> AccountHistories { get; set; }
        public DbSet<LoanApplication> LoanApplications { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=../BankWebAppData.db");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Account>()
                .HasOne(a => a._Client)
                .WithMany(c => c.Accounts)
                .HasForeignKey(a => a.ClientFK)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<AccountHistory>()
                .HasOne(ah => ah._Account)
                .WithMany(a => a.AccountHistories)
                .HasForeignKey(ah => ah.AccountFK)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<LoanApplication>()
                .HasOne(la => la._Client)
                .WithMany(c => c.LoanApplications)
                .HasForeignKey(la => la.ClientFK)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(builder);
        }
    }
}
