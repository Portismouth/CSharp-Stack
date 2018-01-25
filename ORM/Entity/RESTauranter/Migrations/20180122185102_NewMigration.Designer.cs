using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using RESTauranter.Models;

namespace RESTauranter.Migrations
{
    [DbContext(typeof(RESTContext))]
    [Migration("20180122185102_NewMigration")]
    partial class NewMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.5");

            modelBuilder.Entity("RESTauranter.Models.Review", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Rating");

                    b.Property<string>("RestName")
                        .IsRequired();

                    b.Property<string>("RestReview")
                        .IsRequired();

                    b.Property<string>("ReviewerName")
                        .IsRequired();

                    b.Property<DateTime>("VistDate");

                    b.HasKey("Id");

                    b.ToTable("Entries");
                });
        }
    }
}
