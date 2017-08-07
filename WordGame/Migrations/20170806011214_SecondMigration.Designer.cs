using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WordGame.Persistence;

namespace WordGame.Migrations
{
    [DbContext(typeof(GameDbContext))]
    [Migration("20170806011214_SecondMigration")]
    partial class SecondMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WordGame.Models.GameResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateTime");

                    b.Property<string>("GameId")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("IncorrectAnswers");

                    b.Property<int>("Score");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("GameResults");
                });

            modelBuilder.Entity("WordGame.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WordGame.Models.GameResult", b =>
                {
                    b.HasOne("WordGame.Models.User", "User")
                        .WithMany("GameResults")
                        .HasForeignKey("UserId");
                });
        }
    }
}
