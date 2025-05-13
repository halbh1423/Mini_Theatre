using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Mini_Theatre.Models;

namespace Mini_Theatre.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Role> Roles { get; set; } = default!;
        public DbSet<Order> Orders { get; set; } = default!;
        public DbSet<Booking> Bookings { get; set; } = default!;
        public DbSet<Schedule> Schedules { get; set; } = default!;
        public DbSet<Actor> Actors { get; set; } = default!;
        public DbSet<Director> Directors { get; set; } = default!;
        public DbSet<Genre> Genres { get; set; } = default!;
        public DbSet<Movie> Movies { get; set; } = default!;
        public DbSet<Seat> Seats { get; set; } = default!;
        public DbSet<SeatType> SeatTypes { get; set; } = default!;
        public DbSet<Room> Rooms { get; set; } = default!;
        public DbSet<Cinema> Cinemas { get; set; } = default!;
        public DbSet<MovieActor> MovieActors { get; set; } = default!;
        public DbSet<MovieDirector> MovieDirectors { get; set; } = default!;
        public DbSet<MovieGenre> MovieGenres { get; set; } = default!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ManyToManyTableCreating(modelBuilder);
            OnDeleteCreating(modelBuilder);

            SeedData(modelBuilder);
        }

        private void ManyToManyTableCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .HasMany(e => e.Actors)
                .WithMany(e => e.Movies)
                .UsingEntity<MovieActor>();
            modelBuilder.Entity<Movie>()
                .HasMany(e => e.Directors)
                .WithMany(e => e.Movies)
                .UsingEntity<MovieDirector>();
            modelBuilder.Entity<Movie>()
                .HasMany(e => e.Genres)
                .WithMany(e => e.Movies)
                .UsingEntity<MovieGenre>();
        }

        private void OnDeleteCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Seat)
                .WithMany()
                .HasForeignKey(b => b.SeatId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            Console.WriteLine("Start Seeding Data...");
            int idIndex = 1;
            Random random = new Random();

            List<Role> roles = new()
            {
                new Role { Id = 1, Name = "Admin" },
                new Role { Id = 2, Name = "Manager" },
                new Role { Id = 3, Name = "Staff" },
                new Role { Id = 4, Name = "Customer" }
            };
            List<User> users = new()
            {
                new User
                {
                    Id = 1,
                    FullName = "Administrator",
                    Email = "admin@mini.com",
                    Username = "admin",
                    HashedPassword = "vNQfvx2vLtkoG076eBUrSnnOmikQNeuIx70xyW/8pvQ=", //admin
                    PasswordSalt = "iD4HglZj0hsxbcASYzccAQ==",
                    PhoneNumber = "123-456-7890",
                    RoleId = 1,
                    HasUsername = true,
                    IsEmailVerified = true,
                },
                new User
                {
                    Id = 2,
                    FullName = "Manager",
                    Email = "manager@mini.com",
                    Username = "manager",
                    HashedPassword = "YAyRu+dR19kJ/JRsg9RDZ1vppwZpyIgXTn8f/TC2dgE=", //manager
                    PasswordSalt = "8H8xKkPl8FWVGeVIUWM5Jw==",
                    PhoneNumber = "987-654-3210",
                    RoleId = 2,
                    HasUsername = true,
                    IsEmailVerified = false,
                },
                new User
                {
                    Id = 3,
                    FullName = "Staff",
                    Email = "staff@mini.com",
                    Username = "staff",
                    HashedPassword = "Lxb95uHt9kxcCSU2N8LUnWyHsPr33cLWNlAYElRk8tE=",
                    PasswordSalt = "Mu82VH+QQ/7IwBhYzGt2Aw==",
                    PhoneNumber = "456-789-0123",
                    RoleId = 3,
                    HasUsername = true,
                    IsEmailVerified = true,
                },
                new User
                {
                    Id = 4,
                    FullName = "Lê Toàn",
                    Email = "988letoangt@gmail.com",
                    Username = "letoangt",
                    HashedPassword = "s0oa7ukW8AEEieAaEZ0gN6lfjXS5WwC1O3Kzwr72nl0=",
                    PasswordSalt = "fNTIWYngNGTp4+QdH2dwcw==",
                    PhoneNumber = "0987654321",
                    RoleId = 4,
                    HasUsername = true,
                    IsEmailVerified = false,
                }
            };

            List<Actor> actors = new()
            {
                new Actor { Id = 1, Name = "Robert Downey Jr." },
                new Actor { Id = 2, Name = "Scarlett Johansson" },
                new Actor { Id = 3, Name = "Chris Hemsworth" },
                new Actor { Id = 4, Name = "Jennifer Lawrence" },
                new Actor { Id = 5, Name = "Leonardo DiCaprio" },
                new Actor { Id = 6, Name = "Natalie Portman" },
                new Actor { Id = 7, Name = "Tom Hanks" },
                new Actor { Id = 8, Name = "Emma Watson" },
                new Actor { Id = 9, Name = "Johnny Depp" },
                new Actor { Id = 10, Name = "Meryl Streep" },
                new Actor { Id = 11, Name = "Denzel Washington" },
                new Actor { Id = 12, Name = "Sandra Bullock" },
                new Actor { Id = 13, Name = "Brad Pitt" },
                new Actor { Id = 14, Name = "Angelina Jolie" },
                new Actor { Id = 15, Name = "Morgan Freeman" }
            };
            List<Director> directors = new()
            {
                new Director { Id = 1, Name = "Steven Spielberg" },
                new Director { Id = 2, Name = "Christopher Nolan" },
                new Director { Id = 3, Name = "Quentin Tarantino" },
                new Director { Id = 4, Name = "Martin Scorsese" },
                new Director { Id = 5, Name = "James Cameron" },
                new Director { Id = 6, Name = "Ridley Scott" },
                new Director { Id = 7, Name = "Peter Jackson" },
                new Director { Id = 8, Name = "Francis Ford Coppola" },
                new Director { Id = 9, Name = "Stanley Kubrick" },
                new Director { Id = 10, Name = "Tim Burton" }
            };
            List<Genre> genres = new()
            {
                new Genre { Id = 1, Name = "Action" },
                new Genre { Id = 2, Name = "Adventure" },
                new Genre { Id = 3, Name = "Comedy" },
                new Genre { Id = 4, Name = "Drama" },
                new Genre { Id = 5, Name = "Fantasy" },
                new Genre { Id = 6, Name = "Horror" },
                new Genre { Id = 7, Name = "Mystery" },
                new Genre { Id = 8, Name = "Romance" },
                new Genre { Id = 9, Name = "Sci-Fi" },
                new Genre { Id = 10, Name = "Thriller" },
                new Genre { Id = 11, Name = "Documentary" },
                new Genre { Id = 12, Name = "Animation" },
                new Genre { Id = 13, Name = "Crime" },
                new Genre { Id = 14, Name = "Family" },
                new Genre { Id = 15, Name = "Musical" },
                new Genre { Id = 16, Name = "Anime" }
            };
            List<Cinema> cinemas = new()
            {
                new Cinema { Id = 1, Name = "Cinema Ha Dong", Address = "Toa nha Victoria 1, Van Phu, Ha Dong, Ha Noi" },
                new Cinema { Id = 2, Name = "Cinema My Dinh", Address = "San van dong My Dinh, Nam Tu Liem, Ha Noi" }
            };
            List<SeatType> seatTypes = new()
            {
                new SeatType { Id = 1, Name = "Vip", Price = 90000 },
                new SeatType { Id = 2, Name = "Normal", Price = 60000 }
            };
            // Seeding both rooms and seats
            idIndex = 1;
            List<Room> rooms = new()
            {
                new Room { Id = 1, CinemaId = 1, Name = "Room 1", Row = 10, Col = 10, ScreenType = "IMAX" },
                new Room { Id = 2, CinemaId = 1, Name = "Room 2", Row = 10, Col = 10, ScreenType = "4D" },
                new Room { Id = 3, CinemaId = 1, Name = "Room 3", Row = 12, Col = 10, ScreenType = "2D" },
                new Room { Id = 4, CinemaId = 1, Name = "Room 4", Row = 12, Col = 10, ScreenType = "3D" },
                new Room { Id = 5, CinemaId = 1, Name = "Room 5", Row = 12, Col = 10, ScreenType = "IMAX" },
                new Room { Id = 6, CinemaId = 1, Name = "Room 6", Row = 12, Col = 10, ScreenType = "4D" },
                new Room { Id = 7, CinemaId = 1, Name = "Room 7", Row = 12, Col = 10, ScreenType = "2D" },
                new Room { Id = 8, CinemaId = 1, Name = "Room 8", Row = 12, Col = 10, ScreenType = "3D" },
                new Room { Id = 9, CinemaId = 1, Name = "Room 9", Row = 12, Col = 10, ScreenType = "IMAX" },
                new Room { Id = 10, CinemaId = 1, Name = "Room 10", Row = 8, Col = 10, ScreenType = "4D" },
                new Room { Id = 11, CinemaId = 1, Name = "Room 11", Row = 8, Col = 10, ScreenType = "2D" },
                new Room { Id = 12, CinemaId = 1, Name = "Room 12", Row = 8, Col = 10, ScreenType = "3D" },
                new Room { Id = 13, CinemaId = 1, Name = "Room 13", Row = 8, Col = 10, ScreenType = "IMAX" },
                new Room { Id = 14, CinemaId = 1, Name = "Room 14", Row = 8, Col = 8, ScreenType = "4D" },
                new Room { Id = 15, CinemaId = 1, Name = "Room 15", Row = 8, Col = 8, ScreenType = "2D" },
                new Room { Id = 16, CinemaId = 2, Name = "Room 16", Row = 8, Col = 8, ScreenType = "3D" },
                new Room { Id = 17, CinemaId = 2, Name = "Room 17", Row = 8, Col = 8, ScreenType = "IMAX" },
                new Room { Id = 18, CinemaId = 2, Name = "Room 18", Row = 8, Col = 8, ScreenType = "4D" },
                new Room { Id = 19, CinemaId = 2, Name = "Room 19", Row = 10, Col = 10, ScreenType = "2D" },
                new Room { Id = 20, CinemaId = 2, Name = "Room 20", Row = 10, Col = 10, ScreenType = "3D" }
            };
            List<Seat> seats = new();
            foreach (Room room in rooms)
            {
                int roomId = room.Id;
                for (int i = 1; i <= room.Row; i++)
                {
                    for (int j = 1; j <= room.Col; j++)
                    {
                        seats.Add(new Seat
                        {
                            Id = idIndex++,
                            RoomId = roomId,
                            Name = (char)('A' + i - 1) + j.ToString(),
                            SeatTypeId = (i < 3 ? 1 : 2)
                        });
                    }
                }
            }
            List<Movie> movies = new()
            {
                new Movie
                {
                    Id = 1,
                    Title = "Inception",
                    Description = "A thief who enters the dreams of others to steal secrets from their subconscious.",
                    Duration = 148,
                    Rating = 10,
                    PosterUrl = "https://m.media-amazon.com/images/M/MV5BMjExMjkwNTQ0Nl5BMl5BanBnXkFtZTcwNTY0OTk1Mw@@._V1_.jpg",
                    TrailerUrl = "https://youtube.com/watch?v=YoHD9XEInc0",
                    ReleaseDate = new DateTime(2010, 7, 16),
                },
                new Movie
                {
                    Id = 2,
                    Title = "The Dark Knight",
                    Description = "When the menace known as The Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham.",
                    Duration = 152,
                    Rating = 9.7,
                    PosterUrl = "https://m.media-amazon.com/images/I/81CLFQwU-WL.jpg",
                    TrailerUrl = "https://youtube.com/watch?v=EXeTwQWrcwY",
                    ReleaseDate = new DateTime(2008, 7, 18),
                },
                new Movie
                {
                    Id = 3,
                    Title = "Avatar",
                    Description = "A paraplegic Marine dispatched to the moon Pandora on a unique mission becomes torn between following his orders and protecting the world he feels is his home.",
                    Duration = 162,
                    Rating = 7.5,
                    PosterUrl = "https://ae01.alicdn.com/kf/S8ebb069d5ad74d36a4112dd7f53de3134/Movie-Poster-Avatar-The-Way-of-Water-2022-Disney-Movie-Art-Prints-Home-Decor-Poster-Wall.jpg",
                    TrailerUrl = "https://youtube.com/watch?v=5PSNL1qE6VY",
                    ReleaseDate = new DateTime(2009, 12, 18),
                },
                new Movie
                {
                    Id = 4,
                    Title = "Titanic",
                    Description = "A seventeen-year-old aristocrat falls in love with a kind but poor artist aboard the luxurious, ill-fated R.M.S. Titanic.",
                    Duration = 195,
                    Rating = 9.1,
                    PosterUrl = "https://m.media-amazon.com/images/I/71ZJ8am0mKL._AC_SL1340_.jpg",
                    TrailerUrl = "https://youtube.com/watch?v=kVrqfYjkTdQ",
                    ReleaseDate = new DateTime(1997, 12, 19),
                },
                new Movie
                {
                    Id = 5,
                    Title = "The Matrix",
                    Description = "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.",
                    Duration = 136,
                    Rating = 9.2,
                    PosterUrl = "https://ae01.alicdn.com/kf/S9e87199b1b3a4955a31575d8c3f79df1h.jpg_640x640Q90.jpg_.webp",
                    TrailerUrl = "https://youtube.com/watch?v=vKQi3bBA1y8",
                    ReleaseDate = new DateTime(1999, 3, 31),
                },
                new Movie
                {
                    Id = 6,
                    Title = "Interstellar",
                    Description = "A team of explorers travel through a wormhole in space in an attempt to ensure humanity's survival.",
                    Duration = 169,
                    Rating = 9.1,
                    PosterUrl = "https://i.etsystatic.com/23402008/r/il/b658b2/2327469308/il_570xN.2327469308_492n.jpg",
                    TrailerUrl = "https://youtube.com/watch?v=zSWdZVtXT7E",
                    ReleaseDate = new DateTime(2014, 11, 7),
                },
                new Movie
                {
                    Id = 7,
                    Title = "The Lord of the Rings: The Fellowship of the Ring",
                    Description = "A meek Hobbit from the Shire and eight companions set out on a journey to destroy the powerful One Ring and save Middle-earth from the Dark Lord Sauron.",
                    Duration = 178,
                    Rating = 9.3,
                    PosterUrl = "https://m.media-amazon.com/images/I/81EBp0vOZZL._AC_UF894,1000_QL80_.jpg",
                    TrailerUrl = "https://youtube.com/watch?v=V75dMMIW2B4",
                    ReleaseDate = new DateTime(2001, 12, 19),
                },
                new Movie
                {
                    Id = 8,
                    Title = "The Shawshank Redemption",
                    Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                    Duration = 142,
                    Rating = 9.8,
                    PosterUrl = "https://m.media-amazon.com/images/I/51WYsbIa7TS._AC_UF1000,1000_QL80_.jpg",
                    TrailerUrl = "https://youtube.com/watch?v=6hB3S9bIaco",
                    ReleaseDate = new DateTime(1994, 9, 23),
                },
                new Movie
                {
                    Id = 9,
                    Title = "Pulp Fiction",
                    Description = "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.",
                    Duration = 154,
                    Rating = 9.4,
                    PosterUrl = "https://cdn.europosters.eu/image/750/posters/pulp-fiction-cover-i1288.jpg",
                    TrailerUrl = "https://youtube.com/watch?v=s7EdQ4FqbhY",
                    ReleaseDate = new DateTime(1994, 10, 14),
                },
                new Movie
                {
                    Id = 10,
                    Title = "Fight Club",
                    Description = "An insomniac office worker and a devil-may-care soapmaker form an underground fight club that evolves into something much, much more.",
                    Duration = 139,
                    Rating = 9.7,
                    PosterUrl = "https://m.media-amazon.com/images/I/612Jvvyl3iL._AC_SL1500_.jpg",
                    TrailerUrl = "https://youtube.com/watch?v=SUXWAEX2jlg",
                    ReleaseDate = new DateTime(1999, 10, 15),
                },
                new Movie
                {
                    Id = 11,
                    Title = "Forrest Gump",
                    Description = "The presidencies of Kennedy and Johnson, the events of Vietnam, Watergate, and other historical events unfold from the perspective of an Alabama man with an IQ of 75.",
                    Duration = 142,
                    Rating = 9.5,
                    PosterUrl = "https://m.media-amazon.com/images/I/61-F9rv7RvL._AC_UF1000,1000_QL80_.jpg",
                    TrailerUrl = "https://youtube.com/watch?v=bLvqoHBptjg",
                    ReleaseDate = new DateTime(1994, 7, 6),
                },
                new Movie
                {
                    Id = 12,
                    Title = "The Godfather",
                    Description = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.",
                    Duration = 175,
                    Rating = 9.2,
                    PosterUrl = "https://petersbilliards.com//assets/uploads/the-godfather-movie-poster.jpg",
                    TrailerUrl = "https://youtube.com/watch?v=sY1S34973zA",
                    ReleaseDate = new DateTime(1972, 3, 24),
                },
                new Movie
                {
                    Id = 13,
                    Title = "The Godfather: Part II",
                    Description = "The early life and career of Vito Corleone in 1920s New York is portrayed while his son, Michael, expands and tightens his grip on his crime syndicate stretching from Lake Tahoe, Nevada to pre-revolution 1958 Cuba.",
                    Duration = 202,
                    Rating = 9.1,
                    PosterUrl = "https://m.media-amazon.com/images/M/MV5BMWMwMGQzZTItY2JlNC00OWZiLWIyMDctNDk2ZDQ2YjRjMWQ0XkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_.jpg",
                    TrailerUrl = "https://youtube.com/watch?v=qJr92K_hKl0",
                    ReleaseDate = new DateTime(1974, 12, 20),
                },
                new Movie
                {
                    Id = 14,
                    Title = "The Dark Knight Rises",
                    Description = "Eight years after the Joker's reign of anarchy, Batman, with the help of the enigmatic Selina, is forced from his exile to save Gotham City, now on the edge of total annihilation, from the brutal guerrilla terrorist Bane.",
                    Duration = 164,
                    Rating = 9.3,
                    PosterUrl = "https://m.media-amazon.com/images/M/MV5BMTk4ODQzNDY3Ml5BMl5BanBnXkFtZTcwODA0NTM4Nw@@._V1_.jpg",
                    TrailerUrl = "https://youtube.com/watch?v=g8evyE9TuYk",
                    ReleaseDate = new DateTime(2012, 7, 20),
                },
                new Movie
                {
                    Id = 15,
                    Title = "Gladiator",
                    Description = "A former Roman General sets out to exact vengeance against the corrupt emperor who murdered his family and sent him into slavery.",
                    Duration = 155,
                    Rating = 8.9,
                    PosterUrl = "https://m.media-amazon.com/images/I/71n1XZ+bj4L._AC_SL1500_.jpg",
                    TrailerUrl = "https://youtube.com/watch?v=owK1qxDselE",
                    ReleaseDate = new DateTime(2000, 5, 5),
                },
                new Movie
                {
                    Id = 16,
                    Title = "Jurassic Park",
                    Description = "During a preview tour, a theme park suffers a major power breakdown that allows its cloned dinosaur exhibits to run amok.",
                    Duration = 127,
                    Rating = 7.8,
                    PosterUrl = "https://m.media-amazon.com/images/I/61fExTEY7dL._AC_UF894,1000_QL80_.jpg",
                    TrailerUrl = "https://youtube.com/watch?v=lc0UehYemQA",
                    ReleaseDate = new DateTime(1993, 6, 11),
                },
                new Movie
                {
                    Id = 17,
                    Title = "Star Wars: Episode IV - A New Hope",
                    Description = "Luke Skywalker joins forces with a Jedi Knight, a cocky pilot, a Wookiee, and two droids to save the galaxy from the Empire's world-destroying battle station, while also attempting to rescue Princess Leia from the mysterious Darth Vader.",
                    Duration = 121,
                    Rating = 8.5,
                    PosterUrl = "https://m.media-amazon.com/images/I/A1wnJQFI82L.jpg",
                    TrailerUrl = "https://youtube.com/watch?v=1g3_CFmnU7k",
                    ReleaseDate = new DateTime(1977, 5, 25),
                },
                new Movie
                {
                    Id = 18,
                    Title = "The Lion King",
                    Description = "Lion prince Simba and his father are targeted by his bitter uncle, who wants to ascend the throne himself.",
                    Duration = 88,
                    Rating = 8.3,
                    PosterUrl = "https://m.media-amazon.com/images/I/81S36TZzg9L._AC_SL1500_.jpg",
                    TrailerUrl = "https://youtube.com/watch?v=4sj1MT05lAA",
                    ReleaseDate = new DateTime(1994, 6, 24),
                },
                new Movie
                {
                    Id = 19,
                    Title = "Back to the Future",
                    Description = "Marty McFly, a 17-year-old high school student, is accidentally sent 30 years into the past in a time-traveling DeLorean invented by his close friend, the eccentric scientist Doc Brown.",
                    Duration = 116,
                    Rating = 9.0,
                    PosterUrl = "https://cdn.europosters.eu/image/750/posters/back-to-the-future-i2795.jpg",
                    TrailerUrl = "https://youtube.com/watch?v=qvsgGtivCgs",
                    ReleaseDate = new DateTime(1985, 7, 3),
                },
                new Movie
                {
                    Id = 20,
                    Title = "Saving Private Ryan",
                    Description = "Following the Normandy Landings, a group of U.S. soldiers go behind enemy lines to retrieve a paratrooper whose brothers have been killed in action.",
                    Duration = 169,
                    Rating = 7.6,
                    PosterUrl = "https://m.media-amazon.com/images/I/61OK2PdNjKL._AC_UF894,1000_QL80_.jpg",
                    TrailerUrl = "https://youtube.com/watch?v=RYID71hYHzg",
                    ReleaseDate = new DateTime(1998, 7, 24),
                },
                new Movie
                {
                    Id = 21,
                    Title = "Iron Man",
                    Description = "After being held captive in an Afghan cave, billionaire engineer Tony Stark creates a unique weaponized suit of armor to fight evil.",
                    Duration = 126,
                    Rating = 7.9,
                    PosterUrl = "https://m.media-amazon.com/images/I/61cSBq+psoL._AC_UF1000,1000_QL80_.jpg",
                    TrailerUrl = "https://youtube.com/watch?v=8ugaeA-nMTc",
                    ReleaseDate = new DateTime(2008, 5, 2),
                },
                new Movie
                {
                    Id = 22,
                    Title = "The Avengers",
                    Description = "Earth's mightiest heroes must come together and learn to fight as a team if they are going to stop the mischievous Loki and his alien army from enslaving humanity.",
                    Duration = 143,
                    Rating = 8.0,
                    PosterUrl = "https://i.ebayimg.com/images/g/OBoAAOSw2vBfbDFb/s-l1600.jpg",
                    TrailerUrl = "https://youtube.com/watch?v=eOrNdBpGMv8",
                    ReleaseDate = new DateTime(2012, 5, 4),
                },
                new Movie
                {
                    Id = 23,
                    Title = "Guardians of the Galaxy",
                    Description = "A group of intergalactic criminals must pull together to stop a fanatical warrior with plans to purge the universe.",
                    Duration = 121,
                    Rating = 8.0,
                    PosterUrl = "https://m.media-amazon.com/images/I/71lbFfxfMtL._AC_UF894,1000_QL80_.jpg",
                    TrailerUrl = "https://youtube.com/watch?v=d96cjJhvlMA",
                    ReleaseDate = new DateTime(2014, 8, 1),
                },
                new Movie
                {
                    Id = 24,
                    Title = "Black Panther",
                    Description = "T'Challa, heir to the hidden but advanced kingdom of Wakanda, must step forward to lead his people into a new future and must confront a challenger from his country's past.",
                    Duration = 134,
                    Rating = 7.3,
                    PosterUrl = "https://m.media-amazon.com/images/M/MV5BMTg1MTY2MjYzNV5BMl5BanBnXkFtZTgwMTc4NTMwNDI@._V1_.jpg",
                    TrailerUrl = "https://youtube.com/watch?v=xjDjIWPwcPU",
                    ReleaseDate = new DateTime(2018, 2, 16),
                },
                new Movie
                {
                    Id = 25,
                    Title = "Spider-Man: No Way Home",
                    Description = "With Spider-Man's identity now revealed, Peter asks Doctor Strange for help. When a spell goes wrong, dangerous foes from other worlds start to appear, forcing Peter to discover what it truly means to be Spider-Man.",
                    Duration = 148,
                    Rating = 8.3,
                    PosterUrl = "https://i5.walmartimages.com/seo/Spider-Man-No-Way-Home-Movie-Poster-Glossy-Print-Photo-Wall-Art-Zendaya-Cumberbatch-Tom-Holland-Size-24x36-Inches_d021664d-76bd-4e56-a2b0-f7bd75427d2c.8a3872b27a9ea9a62afe2d860a1d42bb.jpeg",
                    TrailerUrl = "https://youtube.com/watch?v=JfVOs4VSpmA",
                    ReleaseDate = new DateTime(2021, 12, 17),
                }
            };
            List<MovieActor> movieActors = new()
            {
                new MovieActor { MovieId = 1, ActorId = 5 }, // Inception, Leonardo DiCaprio
                new MovieActor { MovieId = 2, ActorId = 9 }, // The Dark Knight, Johnny Depp
                new MovieActor { MovieId = 3, ActorId = 5 }, // Avatar, Leonardo DiCaprio
                new MovieActor { MovieId = 4, ActorId = 5 }, // Titanic, Leonardo DiCaprio
                new MovieActor { MovieId = 5, ActorId = 3 }, // The Matrix, Chris Hemsworth
                new MovieActor { MovieId = 6, ActorId = 5 }, // Interstellar, Leonardo DiCaprio
                new MovieActor { MovieId = 7, ActorId = 6 }, // The Lord of the Rings, Natalie Portman
                new MovieActor { MovieId = 8, ActorId = 7 }, // The Shawshank Redemption, Tom Hanks
                new MovieActor { MovieId = 9, ActorId = 13 }, // Pulp Fiction, Brad Pitt
                new MovieActor { MovieId = 10, ActorId = 13 }, // Fight Club, Brad Pitt
                new MovieActor { MovieId = 11, ActorId = 7 }, // Forrest Gump, Tom Hanks
                new MovieActor { MovieId = 12, ActorId = 13 }, // The Godfather, Brad Pitt
                new MovieActor { MovieId = 13, ActorId = 13 }, // The Godfather: Part II, Brad Pitt
                new MovieActor { MovieId = 14, ActorId = 9 }, // The Dark Knight Rises, Johnny Depp
                new MovieActor { MovieId = 15, ActorId = 13 }, // Gladiator, Brad Pitt
                new MovieActor { MovieId = 16, ActorId = 9 }, // Jurassic Park, Johnny Depp
                new MovieActor { MovieId = 17, ActorId = 3 }, // Star Wars: A New Hope, Chris Hemsworth
                new MovieActor { MovieId = 18, ActorId = 8 }, // The Lion King, Emma Watson
                new MovieActor { MovieId = 19, ActorId = 7 }, // Back to the Future, Tom Hanks
                new MovieActor { MovieId = 20, ActorId = 7 },  // Saving Private Ryan, Tom Hanks
                new MovieActor { MovieId = 21, ActorId = 1 },
                new MovieActor { MovieId = 22, ActorId = 2 },
                new MovieActor { MovieId = 23, ActorId = 3 },
                new MovieActor { MovieId = 24, ActorId = 4 },
                new MovieActor { MovieId = 25, ActorId = 5 },
            };
            List<MovieDirector> movieDirectors = new()
            {
                new MovieDirector { MovieId = 1, DirectorId = 2 }, // Inception, Christopher Nolan
                new MovieDirector { MovieId = 2, DirectorId = 2 }, // The Dark Knight, Christopher Nolan
                new MovieDirector { MovieId = 3, DirectorId = 5 }, // Avatar, James Cameron
                new MovieDirector { MovieId = 4, DirectorId = 5 }, // Titanic, James Cameron
                new MovieDirector { MovieId = 5, DirectorId = 6 }, // The Matrix, Ridley Scott
                new MovieDirector { MovieId = 6, DirectorId = 2 }, // Interstellar, Christopher Nolan
                new MovieDirector { MovieId = 7, DirectorId = 7 }, // The Lord of the Rings, Peter Jackson
                new MovieDirector { MovieId = 8, DirectorId = 9 }, // The Shawshank Redemption, Stanley Kubrick
                new MovieDirector { MovieId = 9, DirectorId = 3 }, // Pulp Fiction, Quentin Tarantino
                new MovieDirector { MovieId = 10, DirectorId = 3 }, // Fight Club, Quentin Tarantino
                new MovieDirector { MovieId = 11, DirectorId = 1 }, // Forrest Gump, Steven Spielberg
                new MovieDirector { MovieId = 12, DirectorId = 8 }, // The Godfather, Francis Ford Coppola
                new MovieDirector { MovieId = 13, DirectorId = 8 }, // The Godfather: Part II, Francis Ford Coppola
                new MovieDirector { MovieId = 14, DirectorId = 2 }, // The Dark Knight Rises, Christopher Nolan
                new MovieDirector { MovieId = 15, DirectorId = 6 }, // Gladiator, Ridley Scott
                new MovieDirector { MovieId = 16, DirectorId = 1 }, // Jurassic Park, Steven Spielberg
                new MovieDirector { MovieId = 17, DirectorId = 9 }, // Star Wars: A New Hope, Stanley Kubrick
                new MovieDirector { MovieId = 18, DirectorId = 1 }, // The Lion King, Steven Spielberg
                new MovieDirector { MovieId = 19, DirectorId = 10 }, // Back to the Future, Tim Burton
                new MovieDirector { MovieId = 20, DirectorId = 1 },  // Saving Private Ryan, Steven Spielberg
                new MovieDirector { MovieId = 21, DirectorId = 1 },  
                new MovieDirector { MovieId = 22, DirectorId = 1 },  
                new MovieDirector { MovieId = 23, DirectorId = 1 },  
                new MovieDirector { MovieId = 24, DirectorId = 1 },  
                new MovieDirector { MovieId = 25, DirectorId = 1 },
            };
            List<MovieGenre> movieGenres = new()
            {
                new MovieGenre { MovieId = 1, GenreId = 9 }, // Inception, Sci-Fi
                new MovieGenre { MovieId = 1, GenreId = 10 }, // Inception, Thriller
                new MovieGenre { MovieId = 2, GenreId = 1 }, // The Dark Knight, Action
                new MovieGenre { MovieId = 2, GenreId = 13 }, // The Dark Knight, Crime
                new MovieGenre { MovieId = 3, GenreId = 9 }, // Avatar, Sci-Fi
                new MovieGenre { MovieId = 3, GenreId = 2 }, // Avatar, Adventure
                new MovieGenre { MovieId = 4, GenreId = 4 }, // Titanic, Drama
                new MovieGenre { MovieId = 4, GenreId = 8 }, // Titanic, Romance
                new MovieGenre { MovieId = 5, GenreId = 9 }, // The Matrix, Sci-Fi
                new MovieGenre { MovieId = 5, GenreId = 10 }, // The Matrix, Thriller
                new MovieGenre { MovieId = 6, GenreId = 9 }, // Interstellar, Sci-Fi
                new MovieGenre { MovieId = 6, GenreId = 2 }, // Interstellar, Adventure
                new MovieGenre { MovieId = 7, GenreId = 5 }, // The Lord of the Rings, Fantasy
                new MovieGenre { MovieId = 7, GenreId = 2 }, // The Lord of the Rings, Adventure
                new MovieGenre { MovieId = 8, GenreId = 4 }, // The Shawshank Redemption, Drama
                new MovieGenre { MovieId = 9, GenreId = 13 }, // Pulp Fiction, Crime
                new MovieGenre { MovieId = 9, GenreId = 4 }, // Pulp Fiction, Drama
                new MovieGenre { MovieId = 10, GenreId = 1 }, // Fight Club, Action
                new MovieGenre { MovieId = 10, GenreId = 10 }, // Fight Club, Thriller
                new MovieGenre { MovieId = 11, GenreId = 4 }, // Forrest Gump, Drama
                new MovieGenre { MovieId = 12, GenreId = 13 }, // The Godfather, Crime
                new MovieGenre { MovieId = 12, GenreId = 4 }, // The Godfather, Drama
                new MovieGenre { MovieId = 13, GenreId = 13 }, // The Godfather: Part II, Crime
                new MovieGenre { MovieId = 13, GenreId = 4 }, // The Godfather: Part II, Drama
                new MovieGenre { MovieId = 14, GenreId = 1 }, // The Dark Knight Rises, Action
                new MovieGenre { MovieId = 14, GenreId = 10 }, // The Dark Knight Rises, Thriller
                new MovieGenre { MovieId = 15, GenreId = 1 }, // Gladiator, Action
                new MovieGenre { MovieId = 15, GenreId = 4 }, // Gladiator, Drama
                new MovieGenre { MovieId = 16, GenreId = 9 }, // Jurassic Park, Sci-Fi
                new MovieGenre { MovieId = 16, GenreId = 2 }, // Jurassic Park, Adventure
                new MovieGenre { MovieId = 17, GenreId = 5 }, // Star Wars: A New Hope, Fantasy
                new MovieGenre { MovieId = 17, GenreId = 2 }, // Star Wars: A New Hope, Adventure
                new MovieGenre { MovieId = 18, GenreId = 14 }, // The Lion King, Family
                new MovieGenre { MovieId = 18, GenreId = 12 }, // The Lion King, Animation
                new MovieGenre { MovieId = 19, GenreId = 9 }, // Back to the Future, Sci-Fi
                new MovieGenre { MovieId = 19, GenreId = 3 }, // Back to the Future, Comedy
                new MovieGenre { MovieId = 20, GenreId = 1 }, // Saving Private Ryan, Action
                new MovieGenre { MovieId = 20, GenreId = 4 },  // Saving Private Ryan, Drama
                new MovieGenre { MovieId = 21, GenreId = 1 },
                new MovieGenre { MovieId = 22, GenreId = 1 },
                new MovieGenre { MovieId = 23, GenreId = 1 },
                new MovieGenre { MovieId = 24, GenreId = 1 },
                new MovieGenre { MovieId = 25, GenreId = 1 },
            };
            idIndex = 1;
            List<Schedule> schedules = new List<Schedule>();
            foreach (Room room in rooms)
            {
                Movie movie = movies[room.Id];
                int daysToAdd = random.Next(3, 10);

                for (int day = random.Next(0, daysToAdd); day < daysToAdd; day++)
                {
                    int slotsToAdd = random.Next(2, 5);
                    int minuteToNextSlot = (movie.Duration / 30 + 2) * 30;
                    DateTime showDate = DateTime.Today.AddDays(day);
                    DateTime showTime = showDate.AddHours(7);
                    DateTime endTime = showTime.AddMinutes(minuteToNextSlot);

                    for (int i = 0; i < slotsToAdd; i++)
                    {
                        schedules.Add(new Schedule
                        {
                            Id = idIndex++,
                            MovieId = movie.Id,
                            RoomId = room.Id,
                            ShowDate = showDate,
                            ShowTime = showTime,
                            EndTime = endTime
                        });

                        showTime = showTime.AddMinutes(minuteToNextSlot);
                        endTime = showTime.AddMinutes(minuteToNextSlot);
                    }
                }
            }

            modelBuilder.Entity<Role>().HasData(roles);
            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<Actor>().HasData(actors);
            modelBuilder.Entity<Director>().HasData(directors);
            modelBuilder.Entity<Genre>().HasData(genres);
            modelBuilder.Entity<Cinema>().HasData(cinemas);
            modelBuilder.Entity<SeatType>().HasData(seatTypes);
            modelBuilder.Entity<Room>().HasData(rooms);
            modelBuilder.Entity<Seat>().HasData(seats);
            modelBuilder.Entity<Movie>().HasData(movies);
            modelBuilder.Entity<MovieActor>().HasData(movieActors);
            modelBuilder.Entity<MovieDirector>().HasData(movieDirectors);
            modelBuilder.Entity<MovieGenre>().HasData(movieGenres);
            modelBuilder.Entity<Schedule>().HasData(schedules);

            Console.WriteLine("Finish Seeding Data...");
        }
    }
}
