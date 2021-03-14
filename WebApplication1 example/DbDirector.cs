using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CRUD
{
    public class DbDirector
    {
        public Guid DirId { get; set; }
        public string Name { get; set; }
    }
    public class DbDirectorConfig : IEntityTypeConfiguration<DbDirector>
    {
        public void Configure(EntityTypeBuilder<DbDirector> builder)
        {
            builder.ToTable("Directors");
            builder.HasKey(k => k.DirId);
            builder
                .Property(n => n.Name)
                .HasColumnName("Name")
                .IsRequired();
        }
    }
}
