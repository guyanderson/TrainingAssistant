using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TrainingHelper.Models;

namespace TrainingHelper.Migrations
{
    [DbContext(typeof(TrainingHelperDbContext))]
    [Migration("20170830180614_initial")]
    partial class initial
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

                    b.Property<int>("FabId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("AreaId");

                    b.HasIndex("FabId")
                        .IsUnique();

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("TrainingHelper.Models.Bay", b =>
                {
                    b.Property<int>("BayId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AreaId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("TargetTrained");

                    b.HasKey("BayId");

                    b.HasIndex("AreaId");

                    b.ToTable("Bays");
                });

            modelBuilder.Entity("TrainingHelper.Models.Certification", b =>
                {
                    b.Property<int>("CertificationId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("TargetTrained");

                    b.HasKey("CertificationId");

                    b.ToTable("Certifications");
                });

            modelBuilder.Entity("TrainingHelper.Models.Fab", b =>
                {
                    b.Property<int>("FabId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BayId");

                    b.Property<int?>("CertificationId");

                    b.Property<int?>("OperatorId");

                    b.Property<int?>("ToolId");

                    b.HasKey("FabId");

                    b.HasIndex("BayId");

                    b.HasIndex("CertificationId");

                    b.HasIndex("OperatorId");

                    b.HasIndex("ToolId");

                    b.ToTable("Fab");
                });

            modelBuilder.Entity("TrainingHelper.Models.Operator", b =>
                {
                    b.Property<int>("OperatorId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("ShiftId");

                    b.HasKey("OperatorId");

                    b.HasIndex("ShiftId");

                    b.ToTable("Operators");
                });

            modelBuilder.Entity("TrainingHelper.Models.OperatorCertification", b =>
                {
                    b.Property<int>("OperatorCertificationId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CertificationId");

                    b.Property<int?>("OperatorId");

                    b.HasKey("OperatorCertificationId");

                    b.HasIndex("CertificationId");

                    b.HasIndex("OperatorId");

                    b.ToTable("OperatorsCertification");
                });

            modelBuilder.Entity("TrainingHelper.Models.Shift", b =>
                {
                    b.Property<int>("ShiftId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FabId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ShiftId");

                    b.HasIndex("FabId")
                        .IsUnique();

                    b.ToTable("Shifts");
                });

            modelBuilder.Entity("TrainingHelper.Models.Tool", b =>
                {
                    b.Property<int>("ToolId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BayId");

                    b.Property<int>("CertificationId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ToolId");

                    b.HasIndex("BayId");

                    b.HasIndex("CertificationId");

                    b.ToTable("Tools");
                });

            modelBuilder.Entity("TrainingHelper.Models.Area", b =>
                {
                    b.HasOne("TrainingHelper.Models.Fab", "Fab")
                        .WithOne("Area")
                        .HasForeignKey("TrainingHelper.Models.Area", "FabId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TrainingHelper.Models.Bay", b =>
                {
                    b.HasOne("TrainingHelper.Models.Area", "Area")
                        .WithMany("Bay")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TrainingHelper.Models.Fab", b =>
                {
                    b.HasOne("TrainingHelper.Models.Bay", "Bay")
                        .WithMany()
                        .HasForeignKey("BayId");

                    b.HasOne("TrainingHelper.Models.Certification", "Certification")
                        .WithMany()
                        .HasForeignKey("CertificationId");

                    b.HasOne("TrainingHelper.Models.Operator", "Operator")
                        .WithMany()
                        .HasForeignKey("OperatorId");

                    b.HasOne("TrainingHelper.Models.Tool", "Tool")
                        .WithMany()
                        .HasForeignKey("ToolId");
                });

            modelBuilder.Entity("TrainingHelper.Models.Operator", b =>
                {
                    b.HasOne("TrainingHelper.Models.Shift", "Shift")
                        .WithMany("Operator")
                        .HasForeignKey("ShiftId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TrainingHelper.Models.OperatorCertification", b =>
                {
                    b.HasOne("TrainingHelper.Models.Certification", "Certification")
                        .WithMany("OperatorCertification")
                        .HasForeignKey("CertificationId");

                    b.HasOne("TrainingHelper.Models.Operator", "Operator")
                        .WithMany("OperatorCertification")
                        .HasForeignKey("OperatorId");
                });

            modelBuilder.Entity("TrainingHelper.Models.Shift", b =>
                {
                    b.HasOne("TrainingHelper.Models.Fab", "Fab")
                        .WithOne("Shift")
                        .HasForeignKey("TrainingHelper.Models.Shift", "FabId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TrainingHelper.Models.Tool", b =>
                {
                    b.HasOne("TrainingHelper.Models.Bay", "Bay")
                        .WithMany("Tool")
                        .HasForeignKey("BayId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TrainingHelper.Models.Certification", "Certification")
                        .WithMany("Tool")
                        .HasForeignKey("CertificationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
