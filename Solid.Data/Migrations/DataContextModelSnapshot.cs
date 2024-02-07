﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Solid.Data;

#nullable disable

namespace Solid.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Gifts.Gift", b =>
                {
                    b.Property<int>("GiftId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GiftId"));

                    b.Property<int>("Categry")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfEntry")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("EndingAge")
                        .HasColumnType("float");

                    b.Property<double>("EstimatedPrice")
                        .HasColumnType("float");

                    b.Property<int>("Events")
                        .HasColumnType("int");

                    b.Property<bool>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfViews")
                        .HasColumnType("int");

                    b.Property<double>("StartingAge")
                        .HasColumnType("float");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("GiftId");

                    b.HasIndex("UserId");

                    b.ToTable("Gifts");
                });

            modelBuilder.Entity("Gifts.Opinion", b =>
                {
                    b.Property<int>("OpinionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OpinionId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GiftId")
                        .HasColumnType("int");

                    b.Property<bool>("PositiveOpinion")
                        .HasColumnType("bit");

                    b.HasKey("OpinionId");

                    b.HasIndex("GiftId");

                    b.ToTable("Opinions");
                });

            modelBuilder.Entity("Gifts.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<DateTime>("DateOfStatusChange")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Gifts.Gift", b =>
                {
                    b.HasOne("Gifts.User", "User")
                        .WithMany("GiftsList")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Gifts.Opinion", b =>
                {
                    b.HasOne("Gifts.Gift", "Gift")
                        .WithMany("OpinionsList")
                        .HasForeignKey("GiftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gift");
                });

            modelBuilder.Entity("Gifts.Gift", b =>
                {
                    b.Navigation("OpinionsList");
                });

            modelBuilder.Entity("Gifts.User", b =>
                {
                    b.Navigation("GiftsList");
                });
#pragma warning restore 612, 618
        }
    }
}
