using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ODataComplexType.Entities;

namespace ODataComplexType
{
    public class ODataContext(DbContextOptions<ODataContext> options) : DbContext(options)
    {
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
        }
    }
}

internal sealed class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.HasKey(t => t.Id);

        builder.ComplexProperty(
            x => x.Price,
            y =>
            {
                y.Property(m => m.Amount).HasColumnName("Amount").HasPrecision(18,4);
                y.Property(m => m.Currency).HasColumnName("Currency");

                y.IsRequired();
            });
    }
}
