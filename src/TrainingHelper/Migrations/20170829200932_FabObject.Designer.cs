using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TrainingHelper.Models;

namespace TrainingHelper.Migrations
{
    [DbContext(typeof(TrainingHelperDbContext))]
    [Migration("20170829200932_FabObject")]
    partial class FabObject
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TrainingHelper.Models.Area", b =>
                {
                    b.Property<int>("AreaId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BayId");

                    b.Property<string>("Name");

                    b.HasKey("AreaId");

                    b.HasIndex("BayId");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("TrainingHelper.Models.Bay", b =>
                {
                    b.Property<int>("BayId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AreaId");

                    b.Property<string>("Name");

                    b.Property<int>("TargetTrained");

                    b.HasKey("BayId");

                    b.ToTable("Bays");
                });

            modelBuilder.Entity("TrainingHelper.Models.Certification", b =>
                {
                    b.Property<int>("CertificationId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("TargetTrained");

                    b.HasKey("CertificationId");

                    b.ToTable("Certifications");
                });

            modelBuilder.Entity("TrainingHelper.Models.Fab", b =>
                {
                    b.Property<int>("FabId")
                        .ValueGeneratedOnAdd();

                    b.HasKey("FabId");

                    b.ToTable("Fab");
                });

            modelBuilder.Entity("TrainingHelper.Models.Operator", b =>
                {
                    b.Property<int>("OperatorId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("ShiftId");

                    b.HasKey("OperatorId");

                    b.ToTable("Operators");
                });

            modelBuilder.Entity("TrainingHelper.Models.Shift", b =>
                {
                    b.Property<int>("ShiftId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ShiftId");

                    b.ToTable("Shifts");
                });

            modelBuilder.Entity("TrainingHelper.Models.Tool", b =>
                {
                    b.Property<int>("ToolId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BayId");

                    b.Property<string>("Name");

                    b.HasKey("ToolId");

                    b.ToTable("Tools");
                });

            modelBuilder.Entity("TrainingHelper.Models.Area", b =>
                {
                    b.HasOne("TrainingHelper.Models.Bay")
                        .WithMany("Area")
                        .HasForeignKey("BayId");
                });
        }
    }
}
