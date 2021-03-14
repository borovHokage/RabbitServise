using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD
{
    public class DbBudget
    {
        public Guid BudgetId { get; set; }
        public int Sum { get; set; }
    }
    public class DbBudgetConfig : IEntityTypeConfiguration<DbBudget>
    {
        public void Configure(EntityTypeBuilder<DbBudget> builder)
        {
            builder.ToTable("Budget");
            builder.HasKey(k => k.BudgetId);
            builder
                .Property(n => n.Sum)
                .HasColumnName("Sum")
                .IsRequired();
        }
    }
}
