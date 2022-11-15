using BankSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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

            base.OnModelCreating(builder);
        }

    }
}