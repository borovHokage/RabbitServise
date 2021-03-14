using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CRUD
{
    public class DbFilm
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }

        public int DirectorId {get; set;}
        public DbDirector Director { get; set; }
    }
    public class DbFilmConfig : IEntityTypeConfiguration<DbFilm>
    {
        public void Configure(EntityTypeBuilder<DbFilm> builder)
        {
            builder.ToTable("Films");
            builder.HasKey(k => k.Id);
            builder
                .Property(n => n.Name)
                .HasColumnName("Name")
                .IsRequired();
     /*       builder
                .Property(n => n.Ganre)
                .HasColumnName("Ganre")
                .IsRequired(false);*/
            builder
                .Property(n => n.Year)
                .HasColumnName("Year")
                .IsRequired();
            builder
              .Property(n => n.DirectorId)
              .HasColumnName("DirectorId")
              .IsRequired();
        }
    }
}
