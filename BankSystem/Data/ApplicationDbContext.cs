using BankSystem.Models;
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
        public DbSet<Client> Clients { get; set; }
        public DbSet<HistoryOfTransaction> HistoryOfTransactions { get; set; }
        public DbSet<LoanApplication> LoanApplications { get; set; }
        public DbSet<Transfer> Transfers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data source = E:\\WSEI-resources\\BankWebApp\\BankDB.db");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Client-accounts relationships
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

            // Client-LoanApplications relationship
            builder.Entity<Client>()
                .HasMany(la => la.LoanApplications)
                .WithOne(c => c._Client)
                .HasForeignKey(la => la.IDnumberFK);
            
            // Accounts - HistoryOfTransaction relationships
            builder.Entity<DollarAccount>()
                .HasMany(hot => hot.Transaction)
                .WithOne(da => da.DollarAcc)
                .HasForeignKey(hot => hot.DollarAccountFK)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<EuroAccount>()
                .HasMany(hot => hot.Transaction)
                .WithOne(ea => ea.EuroAcc)
                .HasForeignKey(hot => hot.EuroAccountFK)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<PoundAccount>()
                .HasMany(hot => hot.Transaction)
                .WithOne(pa => pa.PoundAcc)
                .HasForeignKey(hot => hot.PoundAccountFK)
                .OnDelete(DeleteBehavior.NoAction);

            //Transfer - HistoryOfTransaction relationship
            builder.Entity<Transfer>()
                .HasOne(hot => hot.Transaction)
                .WithOne(t => t._Transfer)
                .HasForeignKey<HistoryOfTransaction>(hot => hot.TransferFK);

            //Transfer - Accounts relationships
            builder.Entity<Transfer>()
                .HasOne(ea => ea.EuroAcc)
                .WithMany(t => t.Transfers)
                .HasForeignKey(ea => ea.EuroAccountFK)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Transfer>()
                .HasOne(da => da.DollarAcc)
                .WithMany(t => t.Transfers)
                .HasForeignKey(da => da.DollarAccountFK)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Transfer>()
                .HasOne(pa => pa.PoundAcc)
                .WithMany(t => t.Transfers)
                .HasForeignKey(pa => pa.PoundAccountFK)
                .OnDelete(DeleteBehavior.NoAction);

            // Currency Enum config
            builder.Entity<HistoryOfTransaction>()
                .Property(p => p.Currency)
                .HasConversion<string>()
                .HasMaxLength(6);

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