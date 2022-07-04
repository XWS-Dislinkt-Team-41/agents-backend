﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Agents.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Agents.Migrations
{
    [DbContext(typeof(AgentDbContext))]
    partial class AgentDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Agents.Model.Comment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long?>("CompanyId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("JobPosition")
                        .HasColumnType("text");

                    b.Property<string>("NegativeImpression")
                        .HasColumnType("text");

                    b.Property<string>("PositiveImpression")
                        .HasColumnType("text");

                    b.Property<string>("ProjectsImpression")
                        .HasColumnType("text");

                    b.Property<long>("ReviewedCompanyId")
                        .HasColumnType("bigint");

                    b.Property<string>("UserEngagement")
                        .HasColumnType("text");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("Agents.Model.Company", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:IdentitySequenceOptions", "'4', '1', '', '', 'False', '1'")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ActivityDescription")
                        .HasColumnType("text");

                    b.Property<string>("ContactInformation")
                        .HasColumnType("text");

                    b.Property<float>("Grade")
                        .HasColumnType("real");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<List<int>>("UsersGrade")
                        .HasColumnType("integer[]");

                    b.HasKey("Id");

                    b.ToTable("Company");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Grade = 0f,
                            Image = "https://upload.wikimedia.org/wikipedia/commons/9/9d/Flag_of_Arkansas.svg",
                            Name = "Arkansas"
                        },
                        new
                        {
                            Id = 2L,
                            Grade = 0f,
                            Image = "https://upload.wikimedia.org/wikipedia/commons/f/f7/Flag_of_Florida.svg",
                            Name = "Florida"
                        },
                        new
                        {
                            Id = 3L,
                            Grade = 0f,
                            Image = "https://upload.wikimedia.org/wikipedia/commons/f/f7/Flag_of_Texas.svg",
                            Name = "Texas"
                        });
                });

            modelBuilder.Entity("Agents.Model.CompanyRegistrationRequest", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ActivityDescription")
                        .HasColumnType("text");

                    b.Property<string>("ContactInformation")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("CompanyRegistrationRequests");
                });

            modelBuilder.Entity("Agents.Model.Interview", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long?>("CompanyId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("HR")
                        .HasColumnType("text");

                    b.Property<int>("InterviewedCompanyId")
                        .HasColumnType("integer");

                    b.Property<string>("Technical")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Interview");
                });

            modelBuilder.Entity("Agents.Model.JobOffer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("CompanyId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Position")
                        .HasColumnType("text");

                    b.Property<bool>("Published")
                        .HasColumnType("boolean");

                    b.Property<string>("Seniority")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("JobOffers");
                });

            modelBuilder.Entity("Agents.Model.JobPositionPayment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("Average")
                        .HasColumnType("double precision");

                    b.Property<long>("CompanyId")
                        .HasColumnType("bigint");

                    b.Property<string>("JobPosition")
                        .HasColumnType("text");

                    b.Property<double>("Max")
                        .HasColumnType("double precision");

                    b.Property<double>("Min")
                        .HasColumnType("double precision");

                    b.Property<List<long>>("Reviewers")
                        .HasColumnType("bigint[]");

                    b.Property<int>("ReviewsNumber")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("JobPositionPayment");
                });

            modelBuilder.Entity("Agents.Model.Skill", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long?>("JobOfferId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("JobOfferId");

                    b.ToTable("Skills");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "C#"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "C"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "C++"
                        },
                        new
                        {
                            Id = 4L,
                            Name = "Java"
                        },
                        new
                        {
                            Id = 5L,
                            Name = ".NET"
                        },
                        new
                        {
                            Id = 6L,
                            Name = "SQL"
                        },
                        new
                        {
                            Id = 7L,
                            Name = "Python"
                        },
                        new
                        {
                            Id = 8L,
                            Name = "Go"
                        });
                });

            modelBuilder.Entity("Agents.Model.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:IdentitySequenceOptions", "'3', '1', '', '', 'False', '1'")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ApiToken")
                        .HasColumnType("text");

                    b.Property<bool>("Confirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Confirmed = false,
                            FirstName = "Aleksa",
                            LastName = "Papovic",
                            Password = "$2a$11$KUqQt7k3qJmVN.f5r/UL8uwz5btYkaZE/bxHEoEG3bPCQuz3EaHyG",
                            Role = 0,
                            Username = "pape"
                        },
                        new
                        {
                            Id = 2L,
                            Confirmed = false,
                            FirstName = "Darko",
                            LastName = "Vrbaski",
                            Password = "$2a$11$iddi/c4J.tutkBegt4uSZe9vcZ2Y4yJUVslTHL9FBgZzkqbpwL4dK",
                            Role = 2,
                            Username = "dare"
                        });
                });

            modelBuilder.Entity("Agents.Model.Comment", b =>
                {
                    b.HasOne("Agents.Model.Company", null)
                        .WithMany("Comments")
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("Agents.Model.Interview", b =>
                {
                    b.HasOne("Agents.Model.Company", null)
                        .WithMany("Interviews")
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("Agents.Model.JobPositionPayment", b =>
                {
                    b.HasOne("Agents.Model.Company", null)
                        .WithMany("JobPositionsPayments")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Agents.Model.Skill", b =>
                {
                    b.HasOne("Agents.Model.JobOffer", null)
                        .WithMany("Skills")
                        .HasForeignKey("JobOfferId");
                });
#pragma warning restore 612, 618
        }
    }
}
