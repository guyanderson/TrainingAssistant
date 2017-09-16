using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TrainingHelper.Models;

namespace TrainingHelper.Migrations
{
    [DbContext(typeof(TrainingHelperDbContext))]
    [Migration("20170916003357_initial")]
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

                    b.HasIndex("FabId");

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

                    b.HasKey("FabId");

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

            modelBuilder.Entity("TrainingHelper.Models.OperatorCertifications", b =>
                {
                    b.Property<int>("OperatorCertificationsId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CertificationId");

                    b.Property<int?>("OperatorCertificationsId1");

                    b.Property<int?>("OperatorId");

                    b.Property<int?>("ShiftId");

                    b.HasKey("OperatorCertificationsId");

                    b.HasIndex("CertificationId");

                    b.HasIndex("OperatorCertificationsId1");

                    b.HasIndex("OperatorId");

                    b.HasIndex("ShiftId");

                    b.ToTable("OperatorCertifications");
                });

            modelBuilder.Entity("TrainingHelper.Models.Shift", b =>
                {
                    b.Property<int>("ShiftId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FabId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ShiftId");

                    b.HasIndex("FabId");

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
                        .WithMany("Area")
                        .HasForeignKey("FabId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TrainingHelper.Models.Bay", b =>
                {
                    b.HasOne("TrainingHelper.Models.Area", "Area")
                        .WithMany("Bay")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TrainingHelper.Models.Operator", b =>
                {
                    b.HasOne("TrainingHelper.Models.Shift", "Shift")
                        .WithMany()
                        .HasForeignKey("ShiftId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TrainingHelper.Models.OperatorCertifications", b =>
                {
                    b.HasOne("TrainingHelper.Models.Certification", "Certification")
                        .WithMany("OperatorCertifications")
                        .HasForeignKey("CertificationId");

                    b.HasOne("TrainingHelper.Models.OperatorCertifications", "Operator")
                        .WithMany()
                        .HasForeignKey("OperatorCertificationsId1");

                    b.HasOne("TrainingHelper.Models.Operator")
                        .WithMany("OperatorCertifications")
                        .HasForeignKey("OperatorId");

                    b.HasOne("TrainingHelper.Models.Shift")
                        .WithMany("Operator")
                        .HasForeignKey("ShiftId");
                });

            modelBuilder.Entity("TrainingHelper.Models.Shift", b =>
                {
                    b.HasOne("TrainingHelper.Models.Fab", "Fab")
                        .WithMany("Shift")
                        .HasForeignKey("FabId")
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
