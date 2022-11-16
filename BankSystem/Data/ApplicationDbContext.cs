using BankSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace BankSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<DollarAccount> DollarAccounts { get; set; }
        public DbSet<EuroAccount> EuroAccounts { get; set; }
        public DbSet<PoundAccount> PoundAccounts { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<HistoryOfTransaction> HistoryOfTransactions { get; set; }
        public DbSet<LoanApplication> LoanApplications { get; set; }
        public DbSet<Transfer> Transfers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Client>()
                .HasOne(da => da.DollarAcc)
                .WithOne(c => c._Client)
                .HasForeignKey<DollarAccount>(da => da.IDnumberFK);

            builder.Entity<Client>()
                .HasOne(ea => ea.EuroAcc)
                .WithOne(c => c._Client)
                .HasForeignKey<EuroAccount>(ea => ea.IDnumberFK);

            builder.Entity<Client>()
                .HasOne(pa => pa.PoundAcc)
                .WithOne(c => c._Client)
                .HasForeignKey<PoundAccount>(pa => pa.IDnumberFK);

            builder.Entity<Client>()
                .HasMany(la => la.LoanApplications)
                .WithOne(c => c._Client)
                .HasForeignKey(la => la.IDnumberFK);
            
            builder.Entity<DollarAccount>()
                .HasMany(hot => hot.Transaction)
                .WithOne(da => da.DollarAcc)
                .HasForeignKey(hot => hot.DollarAccountFK);

            builder.Entity<EuroAccount>()
                .HasMany(hot => hot.Transaction)
                .WithOne(ea => ea.EuroAcc)
                .HasForeignKey(hot => hot.EuroAccountFK);

            builder.Entity<PoundAccount>()
                .HasMany(hot => hot.Transaction)
                .WithOne(pa => pa.PoundAcc)
                .HasForeignKey(hot => hot.PoundAccountFK);

            builder.Entity<HistoryOfTransaction>()
                .Property(p => p.Currency)
                .HasConversion<string>()
                .HasMaxLength(6);

            builder.Entity<Transfer>()
                .HasOne(hot => hot.Transaction)
                .WithOne(t => t._Transfer)
                .HasForeignKey<HistoryOfTransaction>(hot => hot.TransferFK);

            builder.Entity<Transfer>()
                .HasOne(ea => ea.EuroAcc)
                .WithMany(t => t.Transfers)
                .HasForeignKey(ea => ea.EuroAccountFK);

            builder.Entity<Transfer>()
                .HasOne(da => da.DollarAcc)
                .WithMany(t => t.Transfers)
                .HasForeignKey(da => da.DollarAccountFK);

            builder.Entity<Transfer>()
                .HasOne(pa => pa.PoundAcc)
                .WithMany(t => t.Transfers)
                .HasForeignKey(pa => pa.PoundAccountFK);

            builder.Entity<Transfer>()
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