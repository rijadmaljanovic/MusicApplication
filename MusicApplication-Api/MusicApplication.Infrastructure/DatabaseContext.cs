using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using MusicApp.Core.Entities;

namespace MusicApp.Infrastructure
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> dbContextOptions)
            :base(dbContextOptions)
        {
        }
        public DbSet<Song> Song { get; set; }
        public DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Song>().HasOne(x => x.Category).WithMany(d => d.Songs).HasForeignKey(x => x.CategoryId);

            OnModelCreatingPartial(modelBuilder);
        }
        private void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    Name = "Hip Hop"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Blues"
                },
                          new Category()
                          {
                              Id = 3,
                              Name = "Rock"
                          },
                               new Category()
                               {
                                   Id = 4,
                                   Name = "Dance"
                               }
                );
            modelBuilder.Entity<Song>().HasData(
                new Song
                {
                    Id = 1,
                    SongName = "Lose Urself",
                    SongUrl = "https://www.youtube.com/watch?v=_Yhyp-_hX2s",
                    ArtistName = "Eminem",
                    CategoryId = 1,
                    ModifiedAt = new DateTime(2021 - 11 - 20),
                    CreatedAt = new DateTime(2021 - 11 - 20),
                    IsFavourite = true,
                    Rating = 5
                },

            new Song
            {
                Id = 2,
                SongName = "In Da Club",
                SongUrl = "https://www.youtube.com/watch?v=5qm8PH4xAss",
                ArtistName = "50 Cent",
                CategoryId = 1,
                ModifiedAt = new DateTime(2021, 8, 2, 9, 30, 52),
                CreatedAt = new DateTime(2021, 5, 1, 8, 30, 52),
                IsFavourite = true,
                Rating = 3
            },
                new Song
                {
                    Id = 3,
                    SongName = "Paint It, Black",
                    SongUrl = "https://www.youtube.com/watch?v=O4irXQhgMqg",
                    ArtistName = "The Rolling Stones",
                    CategoryId = 3,
                    ModifiedAt = new DateTime(2008, 5, 1, 8, 30, 52),
                    CreatedAt = new DateTime(2008, 5, 1, 8, 30, 52),
                    IsFavourite = false,
                    Rating = 5
                },
                    new Song
                    {
                        Id = 4,
                        SongName = "Miss You",
                        SongUrl = "https://www.youtube.com/watch?v=KuRxXRuAz-I",
                        ArtistName = "The Rolling Stones",
                        CategoryId = 3,
                        ModifiedAt = new DateTime(2008, 5, 1, 8, 30, 52),
                        CreatedAt = new DateTime(2008, 5, 1, 8, 30, 52),
                        IsFavourite = false,
                        Rating = 5
                    },
                        new Song
                        {
                            Id = 5,
                            SongName = "Alors On Danse",
                            SongUrl = "https://www.youtube.com/watch?v=VHoT4N43jK8",
                            ArtistName = "Stromae",
                            CategoryId = 4,
                            ModifiedAt = new DateTime(2020, 1, 3, 5, 30, 52),
                            CreatedAt = new DateTime(2012, 2, 2, 1, 30, 52),
                            IsFavourite = true,
                            Rating = 3
                        }
            );
        }
    }
}
