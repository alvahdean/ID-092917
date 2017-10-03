using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using IDSkills.Data;

namespace IDSkills.WebApp.Migrations
{
    [DbContext(typeof(FamousFolksContext))]
    partial class FamousFolksContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IDSkills.Data.Folk", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bio")
                        .HasMaxLength(4096);

                    b.Property<string>("BirthLocation")
                        .HasMaxLength(80);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<int?>("FolkFieldID");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("ID");

                    b.HasIndex("FolkFieldID");

                    b.ToTable("Folks");
                });

            modelBuilder.Entity("IDSkills.Data.FolkField", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasMaxLength(30);

                    b.HasKey("ID");

                    b.ToTable("FolkFields");
                });

            modelBuilder.Entity("IDSkills.Data.Folk", b =>
                {
                    b.HasOne("IDSkills.Data.FolkField", "FolkField")
                        .WithMany("Folks")
                        .HasForeignKey("FolkFieldID");
                });
        }
    }
}
