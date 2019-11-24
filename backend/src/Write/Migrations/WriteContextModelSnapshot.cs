﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Write;

namespace Write.Migrations
{
    [DbContext(typeof(WriteContext))]
    partial class WriteContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Write.Pocos.Barbecue", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("Date");

                    b.Property<string>("Description");

                    b.Property<string>("Observation");

                    b.Property<decimal>("TotalAmount");

                    b.Property<int>("TotalParticipants");

                    b.Property<decimal>("TotalRaised");

                    b.Property<DateTime?>("UpdateDate");

                    b.HasKey("Id");

                    b.ToTable("Barbecues");
                });

            modelBuilder.Entity("Write.Pocos.Participant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Participant");
                });

            modelBuilder.Entity("Write.Pocos.Presence", b =>
                {
                    b.Property<Guid>("BarbecueId");

                    b.Property<Guid>("ParticipantId");

                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Paid");

                    b.Property<decimal>("Value");

                    b.HasKey("BarbecueId", "ParticipantId");

                    b.HasIndex("ParticipantId");

                    b.ToTable("Presence");
                });

            modelBuilder.Entity("Write.Pocos.Presence", b =>
                {
                    b.HasOne("Write.Pocos.Barbecue", "Barbecue")
                        .WithMany("Presences")
                        .HasForeignKey("BarbecueId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Write.Pocos.Participant", "Participant")
                        .WithMany("Presences")
                        .HasForeignKey("ParticipantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
