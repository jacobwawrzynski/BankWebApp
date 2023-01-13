﻿using BankSystem.Models;
using BankSystem.Models.ViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<DollarAccount> DollarAccounts { get; set; }
        public DbSet<EuroAccount> EuroAccounts { get; set; }
        public DbSet<PoundAccount> PoundAccounts { get; set; }
        
        public DbSet<EuroAccountHistory> EuroAccountHistory { get; set; }
        public DbSet<PoundAccountHistory> PoundAccountHistory { get; set; }
        public DbSet<DollarAccountHistory> DollarAccountHistory { get; set; }

        public DbSet<LoanApplication> LoanApplications { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=BankApplication;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DepositViewModel>()
                .HasNoKey();

            // Client-accounts relationships
            builder.Entity<Client>()
                .HasOne(da => da.DollarAcc)
                .WithOne(c => c._Client)
                .HasForeignKey<DollarAccount>(da => da.ClientFK);

            builder.Entity<Client>()
                .HasOne(ea => ea.EuroAcc)
                .WithOne(c => c._Client)
                .HasForeignKey<EuroAccount>(ea => ea.ClientFK);

            builder.Entity<Client>()
                .HasOne(pa => pa.PoundAcc)
                .WithOne(c => c._Client)
                .HasForeignKey<PoundAccount>(pa => pa.ClientFK);

            // Client-LoanApplications relationship
            builder.Entity<Client>()
                .HasMany(la => la.LoanApplications)
                .WithOne(c => c._Client)
                .HasForeignKey(la => la.ClientFK);

            //Accounts - AccountHistory relationships
            builder.Entity<DollarAccountHistory>()
                .HasOne(da => da.DollarAcc)
                .WithMany(dah => dah.DollarAH)
                .HasForeignKey(da => da.DollarAccountFK);

            builder.Entity<EuroAccountHistory>()
                .HasOne(ea => ea.EuroAcc)
                .WithMany(eah => eah.EuroAH)
                .HasForeignKey(ea => ea.EuroAccountFK);

            builder.Entity<PoundAccountHistory>()
                .HasOne(pa => pa.PoundAcc)
                .WithMany(pah => pah.PoundAH)
                .HasForeignKey(pa => pa.PoundAccountFK);

            // Currency Enum config
            builder.Entity<DollarAccountHistory>()
                .Property(p => p.Currency)
                .HasConversion<string>()
                .HasMaxLength(6);

            builder.Entity<EuroAccountHistory>()
                .Property(p => p.Currency)
                .HasConversion<string>()
                .HasMaxLength(6);

            builder.Entity<PoundAccountHistory>()
                .Property(p => p.Currency)
                .HasConversion<string>()
                .HasMaxLength(6);

            builder.Entity<PoundAccount>()
                .Property(p => p.Currency)
                .HasConversion<string>()
                .HasMaxLength(6);

            builder.Entity<EuroAccount>()
                .Property(p => p.Currency)
                .HasConversion<string>()
                .HasMaxLength(6);

            builder.Entity<DollarAccount>()
                .Property(p => p.Currency)
                .HasConversion<string>()
                .HasMaxLength(6);

            builder.Entity<LoanApplication>()
               .Property(p => p.Currency)
               .HasConversion<string>()
               .HasMaxLength(6);

            base.OnModelCreating(builder);
        }

    }
}