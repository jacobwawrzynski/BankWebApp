using BankSystem.Models;
using BankSystem.Models.Interfaces;
using BankSystem.Models.RelationModels;
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

        public DbSet<DollarAccount> DollarAccounts { get; set; }
        public DbSet<EuroAccount> EuroAccounts { get; set; }
        public DbSet<PoundAccount> PoundAccounts { get; set; }
        public DbSet<TransferHistory> TransferHistory { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<LoanApplication> LoanApplications { get; set; }
        public DbSet<Deposit> Deposits { get; set; }
        public DbSet<Client_Accounts> Client_Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Deposit>()
                .HasNoKey();

            // Client_Accounts realationships
            builder.Entity<Client_Accounts>()
                .HasKey(k => new { k.ClientID, k.AccountID });

            builder.Entity<Client_Accounts>()
                .HasOne(da => da.Account as DollarAccount)
                .WithMany(c => c.Client_Accounts)
                .HasForeignKey(da => da.AccountID);

            builder.Entity<Client_Accounts>()
                .HasOne(da => da.Account as EuroAccount)
                .WithMany(c => c.Client_Accounts)
                .HasForeignKey(da => da.AccountID);

            builder.Entity<Client_Accounts>()
                .HasOne(da => da.Account as PoundAccount)
                .WithMany(c => c.Client_Accounts)
                .HasForeignKey(da => da.AccountID);

            // Client-accounts relationships

            //builder.Entity<Client>()
            //    .HasOne(da => da.DollarAcc)
            //    .WithOne(c => c._Client)
            //    .HasForeignKey<DollarAccount>(da => da.IDnumberFK);

            //builder.Entity<Client>()
            //    .HasOne(ea => ea.EuroAcc)
            //    .WithOne(c => c._Client)
            //    .HasForeignKey<EuroAccount>(ea => ea.IDnumberFK);

            //builder.Entity<Client>()
            //    .HasOne(pa => pa.PoundAcc)
            //    .WithOne(c => c._Client)
            //    .HasForeignKey<PoundAccount>(pa => pa.IDnumberFK);

            // Client-LoanApplications relationship
            builder.Entity<Client>()
                .HasMany(la => la.LoanApplications)
                .WithOne(c => c._Client)
                .HasForeignKey(la => la.IDnumberFK);

            //Accounts - AccountHistory relationships

            //builder.Entity<DollarTransactionHistory>()
            //    .HasOne(da => da.DollarAcc)
            //    .WithMany(dah => dah.DollarAH)
            //    .HasForeignKey(da => da.DollarAccountFK);

            //builder.Entity<EuroAccountHistory>()
            //    .HasOne(ea => ea.EuroAcc)
            //    .WithMany(eah => eah.EuroAH)
            //    .HasForeignKey(ea => ea.EuroAccountFK);

            //builder.Entity<PoundAccountHistory>()
            //    .HasOne(pa => pa.PoundAcc)
            //    .WithMany(pah => pah.PoundAH)
            //    .HasForeignKey(pa => pa.PoundAccountFK);

            // Currency Enum config

            //builder.Entity<DollarTransactionHistory>()
            //    .Property(p => p.Currency)
            //    .HasConversion<string>()
            //    .HasMaxLength(6);

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