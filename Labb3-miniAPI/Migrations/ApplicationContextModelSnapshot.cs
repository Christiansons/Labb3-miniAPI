﻿// <auto-generated />
using Labb3_miniAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Labb3_miniAPI.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("InterestPerson", b =>
                {
                    b.Property<int>("InterestsId")
                        .HasColumnType("int");

                    b.Property<int>("PersonsId")
                        .HasColumnType("int");

                    b.HasKey("InterestsId", "PersonsId");

                    b.HasIndex("PersonsId");

                    b.ToTable("InterestPerson");
                });

            modelBuilder.Entity("Labb3_miniAPI.Models.Interest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("InterestDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InterestName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "title");

                    b.HasKey("Id");

                    b.ToTable("Interests");
                });

            modelBuilder.Entity("Labb3_miniAPI.Models.InterestLink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("InterestId")
                        .HasColumnType("int");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InterestId");

                    b.HasIndex("PersonId");

                    b.ToTable("InterestLinks");
                });

            modelBuilder.Entity("Labb3_miniAPI.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "name");

                    b.Property<int>("PhoneNr")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "phoneNr");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("InterestPerson", b =>
                {
                    b.HasOne("Labb3_miniAPI.Models.Interest", null)
                        .WithMany()
                        .HasForeignKey("InterestsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Labb3_miniAPI.Models.Person", null)
                        .WithMany()
                        .HasForeignKey("PersonsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Labb3_miniAPI.Models.InterestLink", b =>
                {
                    b.HasOne("Labb3_miniAPI.Models.Interest", "Interest")
                        .WithMany("InterestLinks")
                        .HasForeignKey("InterestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Labb3_miniAPI.Models.Person", "Person")
                        .WithMany("InterestLinks")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Interest");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Labb3_miniAPI.Models.Interest", b =>
                {
                    b.Navigation("InterestLinks");
                });

            modelBuilder.Entity("Labb3_miniAPI.Models.Person", b =>
                {
                    b.Navigation("InterestLinks");
                });
#pragma warning restore 612, 618
        }
    }
}
