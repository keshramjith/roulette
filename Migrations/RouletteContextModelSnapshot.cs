// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using roulette.Models;

#nullable disable

namespace roulette.Migrations
{
    [DbContext(typeof(RouletteContext))]
    partial class RouletteContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("roulette.Entities.PayoutEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("SpinId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Wager")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Payouts");
                });

            modelBuilder.Entity("roulette.Entities.SpinEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("SpinResultNumber")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Spins");
                });

            modelBuilder.Entity("roulette.Entities.StraightBetEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlacedBet")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("SpinEntityId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("SpinId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Wager")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SpinEntityId");

                    b.ToTable("StraightBets");
                });

            modelBuilder.Entity("roulette.Entities.StraightBetEntity", b =>
                {
                    b.HasOne("roulette.Entities.SpinEntity", null)
                        .WithMany("StraightBets")
                        .HasForeignKey("SpinEntityId");
                });

            modelBuilder.Entity("roulette.Entities.SpinEntity", b =>
                {
                    b.Navigation("StraightBets");
                });
#pragma warning restore 612, 618
        }
    }
}
