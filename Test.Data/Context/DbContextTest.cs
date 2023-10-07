using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Test.Entities.Core;

namespace Test.Data.Context
{
    public class DbContextTest : DbContext
    {
        public DbContextTest(DbContextOptions<DbContextTest> opt)
            : base(opt)
        {

        }

        public virtual DbSet<Players> Players { get; set; }
        public virtual DbSet<Duels> Duels { get; set; }
        public virtual DbSet<Plays> Plays { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Duels>(entity =>
            {
                entity.HasOne(d => d.Player1)
                    .WithMany(p => p.Duels_Player1)
                    .HasForeignKey(d => d.IdPlayer1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .IsRequired(false);

                entity.HasOne(d => d.Player2)
                    .WithMany(p => p.Duels_Player2)
                    .HasForeignKey(d => d.IdPlayer2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .IsRequired(false);
            });

            modelBuilder.Entity<Plays>(entity =>
            {
                entity.HasOne(d => d.Duels)
                    .WithMany(p => p.Plays)
                    .HasForeignKey(d => d.IdDuel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .IsRequired(false);

                entity.HasOne(d => d.Players)
                    .WithMany(p => p.Plays)
                    .HasForeignKey(d => d.IdPlayer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .IsRequired(false);
            });

            modelBuilder.Entity<Players>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

        }
    }
}
