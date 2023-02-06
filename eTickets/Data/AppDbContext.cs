using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Actor> Actors { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Actor_Movie> Actors_Movies { get; set; }

        public DbSet<Cinema> Cinemas { get; set; }

        public DbSet<Producer> Producers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Actor_Movie>()
                .HasKey(x => new {x.MovieId , x.ActorId});
            builder.Entity<Actor_Movie>()
                .HasOne(x => x.Movie)
                .WithMany(x => x.Actors_Movies)
                .HasForeignKey(x => x.MovieId);
            builder.Entity<Actor_Movie>()
                .HasOne(x => x.Actor)
                .WithMany(x => x.Actors_Movies)
                .HasForeignKey(x => x.ActorId);
            base.OnModelCreating(builder);
        }
    }
}
