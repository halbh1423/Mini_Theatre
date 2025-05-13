using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mini_Theatre.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cinemas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinemas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: true),
                    PosterUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrailerUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SeatTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CinemaId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Row = table.Column<int>(type: "int", nullable: false),
                    Col = table.Column<int>(type: "int", nullable: false),
                    ScreenType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Cinemas_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Cinemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieActors",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    ActorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieActors", x => new { x.ActorId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_MovieActors_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieActors_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieDirectors",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    DirectorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieDirectors", x => new { x.DirectorId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_MovieDirectors_Directors_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Directors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieDirectors_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieGenres",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGenres", x => new { x.GenreId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_MovieGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieGenres_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HashedPassword = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    HasUsername = table.Column<bool>(type: "bit", nullable: false),
                    IsEmailVerified = table.Column<bool>(type: "bit", nullable: false),
                    VerificationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerificationCodeExpiration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    ShowDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShowTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CinemaId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedules_Cinemas_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Cinemas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Schedules_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Schedules_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SeatTypeId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seats_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Seats_SeatTypes_SeatTypeId",
                        column: x => x.SeatTypeId,
                        principalTable: "SeatTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PaymentStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OrderTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ScheduleId = table.Column<int>(type: "int", nullable: false),
                    SeatId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SeatId1 = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Seats_SeatId",
                        column: x => x.SeatId,
                        principalTable: "Seats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_Seats_SeatId1",
                        column: x => x.SeatId1,
                        principalTable: "Seats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bookings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "CreateTime", "DeleteTime", "IsActive", "Name", "UpdateTime" },
                values: new object[,]
                {
                    { 1, null, null, null, "Robert Downey Jr.", null },
                    { 2, null, null, null, "Scarlett Johansson", null },
                    { 3, null, null, null, "Chris Hemsworth", null },
                    { 4, null, null, null, "Jennifer Lawrence", null },
                    { 5, null, null, null, "Leonardo DiCaprio", null },
                    { 6, null, null, null, "Natalie Portman", null },
                    { 7, null, null, null, "Tom Hanks", null },
                    { 8, null, null, null, "Emma Watson", null },
                    { 9, null, null, null, "Johnny Depp", null },
                    { 10, null, null, null, "Meryl Streep", null },
                    { 11, null, null, null, "Denzel Washington", null },
                    { 12, null, null, null, "Sandra Bullock", null },
                    { 13, null, null, null, "Brad Pitt", null },
                    { 14, null, null, null, "Angelina Jolie", null },
                    { 15, null, null, null, "Morgan Freeman", null }
                });

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "Address", "CreateTime", "DeleteTime", "IsActive", "Name", "UpdateTime" },
                values: new object[,]
                {
                    { 1, "Toa nha Victoria 1, Van Phu, Ha Dong, Ha Noi", null, null, null, "Cinema Ha Dong", null },
                    { 2, "San van dong My Dinh, Nam Tu Liem, Ha Noi", null, null, null, "Cinema My Dinh", null }
                });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "CreateTime", "DeleteTime", "IsActive", "Name", "UpdateTime" },
                values: new object[,]
                {
                    { 1, null, null, null, "Steven Spielberg", null },
                    { 2, null, null, null, "Christopher Nolan", null },
                    { 3, null, null, null, "Quentin Tarantino", null },
                    { 4, null, null, null, "Martin Scorsese", null },
                    { 5, null, null, null, "James Cameron", null },
                    { 6, null, null, null, "Ridley Scott", null },
                    { 7, null, null, null, "Peter Jackson", null },
                    { 8, null, null, null, "Francis Ford Coppola", null },
                    { 9, null, null, null, "Stanley Kubrick", null },
                    { 10, null, null, null, "Tim Burton", null }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CreateTime", "DeleteTime", "IsActive", "Name", "UpdateTime" },
                values: new object[,]
                {
                    { 1, null, null, null, "Action", null },
                    { 2, null, null, null, "Adventure", null },
                    { 3, null, null, null, "Comedy", null },
                    { 4, null, null, null, "Drama", null },
                    { 5, null, null, null, "Fantasy", null },
                    { 6, null, null, null, "Horror", null },
                    { 7, null, null, null, "Mystery", null },
                    { 8, null, null, null, "Romance", null },
                    { 9, null, null, null, "Sci-Fi", null },
                    { 10, null, null, null, "Thriller", null },
                    { 11, null, null, null, "Documentary", null },
                    { 12, null, null, null, "Animation", null },
                    { 13, null, null, null, "Crime", null },
                    { 14, null, null, null, "Family", null },
                    { 15, null, null, null, "Musical", null }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CreateTime", "DeleteTime", "IsActive", "Name", "UpdateTime" },
                values: new object[] { 16, null, null, null, "Anime", null });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "CreateTime", "DeleteTime", "Description", "Duration", "IsActive", "PosterUrl", "Rating", "ReleaseDate", "Title", "TrailerUrl", "UpdateTime" },
                values: new object[,]
                {
                    { 1, null, null, "A thief who enters the dreams of others to steal secrets from their subconscious.", 148, null, "https://m.media-amazon.com/images/M/MV5BMjExMjkwNTQ0Nl5BMl5BanBnXkFtZTcwNTY0OTk1Mw@@._V1_.jpg", 10.0, new DateTime(2010, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inception", "https://youtube.com/watch?v=YoHD9XEInc0", null },
                    { 2, null, null, "When the menace known as The Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham.", 152, null, "https://m.media-amazon.com/images/I/81CLFQwU-WL.jpg", 9.6999999999999993, new DateTime(2008, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Dark Knight", "https://youtube.com/watch?v=EXeTwQWrcwY", null },
                    { 3, null, null, "A paraplegic Marine dispatched to the moon Pandora on a unique mission becomes torn between following his orders and protecting the world he feels is his home.", 162, null, "https://ae01.alicdn.com/kf/S8ebb069d5ad74d36a4112dd7f53de3134/Movie-Poster-Avatar-The-Way-of-Water-2022-Disney-Movie-Art-Prints-Home-Decor-Poster-Wall.jpg", 7.5, new DateTime(2009, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avatar", "https://youtube.com/watch?v=5PSNL1qE6VY", null },
                    { 4, null, null, "A seventeen-year-old aristocrat falls in love with a kind but poor artist aboard the luxurious, ill-fated R.M.S. Titanic.", 195, null, "https://m.media-amazon.com/images/I/71ZJ8am0mKL._AC_SL1340_.jpg", 9.0999999999999996, new DateTime(1997, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Titanic", "https://youtube.com/watch?v=kVrqfYjkTdQ", null },
                    { 5, null, null, "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.", 136, null, "https://ae01.alicdn.com/kf/S9e87199b1b3a4955a31575d8c3f79df1h.jpg_640x640Q90.jpg_.webp", 9.1999999999999993, new DateTime(1999, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Matrix", "https://youtube.com/watch?v=vKQi3bBA1y8", null },
                    { 6, null, null, "A team of explorers travel through a wormhole in space in an attempt to ensure humanity's survival.", 169, null, "https://i.etsystatic.com/23402008/r/il/b658b2/2327469308/il_570xN.2327469308_492n.jpg", 9.0999999999999996, new DateTime(2014, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Interstellar", "https://youtube.com/watch?v=zSWdZVtXT7E", null },
                    { 7, null, null, "A meek Hobbit from the Shire and eight companions set out on a journey to destroy the powerful One Ring and save Middle-earth from the Dark Lord Sauron.", 178, null, "https://m.media-amazon.com/images/I/81EBp0vOZZL._AC_UF894,1000_QL80_.jpg", 9.3000000000000007, new DateTime(2001, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Lord of the Rings: The Fellowship of the Ring", "https://youtube.com/watch?v=V75dMMIW2B4", null },
                    { 8, null, null, "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.", 142, null, "https://m.media-amazon.com/images/I/51WYsbIa7TS._AC_UF1000,1000_QL80_.jpg", 9.8000000000000007, new DateTime(1994, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Shawshank Redemption", "https://youtube.com/watch?v=6hB3S9bIaco", null },
                    { 9, null, null, "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.", 154, null, "https://cdn.europosters.eu/image/750/posters/pulp-fiction-cover-i1288.jpg", 9.4000000000000004, new DateTime(1994, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pulp Fiction", "https://youtube.com/watch?v=s7EdQ4FqbhY", null },
                    { 10, null, null, "An insomniac office worker and a devil-may-care soapmaker form an underground fight club that evolves into something much, much more.", 139, null, "https://m.media-amazon.com/images/I/612Jvvyl3iL._AC_SL1500_.jpg", 9.6999999999999993, new DateTime(1999, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fight Club", "https://youtube.com/watch?v=SUXWAEX2jlg", null },
                    { 11, null, null, "The presidencies of Kennedy and Johnson, the events of Vietnam, Watergate, and other historical events unfold from the perspective of an Alabama man with an IQ of 75.", 142, null, "https://m.media-amazon.com/images/I/61-F9rv7RvL._AC_UF1000,1000_QL80_.jpg", 9.5, new DateTime(1994, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Forrest Gump", "https://youtube.com/watch?v=bLvqoHBptjg", null },
                    { 12, null, null, "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.", 175, null, "https://petersbilliards.com//assets/uploads/the-godfather-movie-poster.jpg", 9.1999999999999993, new DateTime(1972, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Godfather", "https://youtube.com/watch?v=sY1S34973zA", null },
                    { 13, null, null, "The early life and career of Vito Corleone in 1920s New York is portrayed while his son, Michael, expands and tightens his grip on his crime syndicate stretching from Lake Tahoe, Nevada to pre-revolution 1958 Cuba.", 202, null, "https://m.media-amazon.com/images/M/MV5BMWMwMGQzZTItY2JlNC00OWZiLWIyMDctNDk2ZDQ2YjRjMWQ0XkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_.jpg", 9.0999999999999996, new DateTime(1974, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Godfather: Part II", "https://youtube.com/watch?v=qJr92K_hKl0", null },
                    { 14, null, null, "Eight years after the Joker's reign of anarchy, Batman, with the help of the enigmatic Selina, is forced from his exile to save Gotham City, now on the edge of total annihilation, from the brutal guerrilla terrorist Bane.", 164, null, "https://m.media-amazon.com/images/M/MV5BMTk4ODQzNDY3Ml5BMl5BanBnXkFtZTcwODA0NTM4Nw@@._V1_.jpg", 9.3000000000000007, new DateTime(2012, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Dark Knight Rises", "https://youtube.com/watch?v=g8evyE9TuYk", null },
                    { 15, null, null, "A former Roman General sets out to exact vengeance against the corrupt emperor who murdered his family and sent him into slavery.", 155, null, "https://m.media-amazon.com/images/I/71n1XZ+bj4L._AC_SL1500_.jpg", 8.9000000000000004, new DateTime(2000, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gladiator", "https://youtube.com/watch?v=owK1qxDselE", null },
                    { 16, null, null, "During a preview tour, a theme park suffers a major power breakdown that allows its cloned dinosaur exhibits to run amok.", 127, null, "https://m.media-amazon.com/images/I/61fExTEY7dL._AC_UF894,1000_QL80_.jpg", 7.7999999999999998, new DateTime(1993, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jurassic Park", "https://youtube.com/watch?v=lc0UehYemQA", null },
                    { 17, null, null, "Luke Skywalker joins forces with a Jedi Knight, a cocky pilot, a Wookiee, and two droids to save the galaxy from the Empire's world-destroying battle station, while also attempting to rescue Princess Leia from the mysterious Darth Vader.", 121, null, "https://m.media-amazon.com/images/I/A1wnJQFI82L.jpg", 8.5, new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Star Wars: Episode IV - A New Hope", "https://youtube.com/watch?v=1g3_CFmnU7k", null },
                    { 18, null, null, "Lion prince Simba and his father are targeted by his bitter uncle, who wants to ascend the throne himself.", 88, null, "https://m.media-amazon.com/images/I/81S36TZzg9L._AC_SL1500_.jpg", 8.3000000000000007, new DateTime(1994, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Lion King", "https://youtube.com/watch?v=4sj1MT05lAA", null },
                    { 19, null, null, "Marty McFly, a 17-year-old high school student, is accidentally sent 30 years into the past in a time-traveling DeLorean invented by his close friend, the eccentric scientist Doc Brown.", 116, null, "https://cdn.europosters.eu/image/750/posters/back-to-the-future-i2795.jpg", 9.0, new DateTime(1985, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Back to the Future", "https://youtube.com/watch?v=qvsgGtivCgs", null },
                    { 20, null, null, "Following the Normandy Landings, a group of U.S. soldiers go behind enemy lines to retrieve a paratrooper whose brothers have been killed in action.", 169, null, "https://m.media-amazon.com/images/I/61OK2PdNjKL._AC_UF894,1000_QL80_.jpg", 7.5999999999999996, new DateTime(1998, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saving Private Ryan", "https://youtube.com/watch?v=RYID71hYHzg", null },
                    { 21, null, null, "After being held captive in an Afghan cave, billionaire engineer Tony Stark creates a unique weaponized suit of armor to fight evil.", 126, null, "https://m.media-amazon.com/images/I/61cSBq+psoL._AC_UF1000,1000_QL80_.jpg", 7.9000000000000004, new DateTime(2008, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Iron Man", "https://youtube.com/watch?v=8ugaeA-nMTc", null },
                    { 22, null, null, "Earth's mightiest heroes must come together and learn to fight as a team if they are going to stop the mischievous Loki and his alien army from enslaving humanity.", 143, null, "https://i.ebayimg.com/images/g/OBoAAOSw2vBfbDFb/s-l1600.jpg", 8.0, new DateTime(2012, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Avengers", "https://youtube.com/watch?v=eOrNdBpGMv8", null },
                    { 23, null, null, "A group of intergalactic criminals must pull together to stop a fanatical warrior with plans to purge the universe.", 121, null, "https://m.media-amazon.com/images/I/71lbFfxfMtL._AC_UF894,1000_QL80_.jpg", 8.0, new DateTime(2014, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guardians of the Galaxy", "https://youtube.com/watch?v=d96cjJhvlMA", null },
                    { 24, null, null, "T'Challa, heir to the hidden but advanced kingdom of Wakanda, must step forward to lead his people into a new future and must confront a challenger from his country's past.", 134, null, "https://m.media-amazon.com/images/M/MV5BMTg1MTY2MjYzNV5BMl5BanBnXkFtZTgwMTc4NTMwNDI@._V1_.jpg", 7.2999999999999998, new DateTime(2018, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Black Panther", "https://youtube.com/watch?v=xjDjIWPwcPU", null },
                    { 25, null, null, "With Spider-Man's identity now revealed, Peter asks Doctor Strange for help. When a spell goes wrong, dangerous foes from other worlds start to appear, forcing Peter to discover what it truly means to be Spider-Man.", 148, null, "https://i5.walmartimages.com/seo/Spider-Man-No-Way-Home-Movie-Poster-Glossy-Print-Photo-Wall-Art-Zendaya-Cumberbatch-Tom-Holland-Size-24x36-Inches_d021664d-76bd-4e56-a2b0-f7bd75427d2c.8a3872b27a9ea9a62afe2d860a1d42bb.jpeg", 8.3000000000000007, new DateTime(2021, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spider-Man: No Way Home", "https://youtube.com/watch?v=JfVOs4VSpmA", null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Manager" },
                    { 3, "Staff" },
                    { 4, "Customer" }
                });

            migrationBuilder.InsertData(
                table: "SeatTypes",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Vip", 90000m },
                    { 2, "Normal", 60000m }
                });

            migrationBuilder.InsertData(
                table: "MovieActors",
                columns: new[] { "ActorId", "MovieId" },
                values: new object[,]
                {
                    { 1, 21 },
                    { 2, 22 },
                    { 3, 5 },
                    { 3, 17 },
                    { 3, 23 },
                    { 4, 24 },
                    { 5, 1 },
                    { 5, 3 },
                    { 5, 4 },
                    { 5, 6 },
                    { 5, 25 },
                    { 6, 7 },
                    { 7, 8 },
                    { 7, 11 },
                    { 7, 19 },
                    { 7, 20 },
                    { 8, 18 },
                    { 9, 2 },
                    { 9, 14 },
                    { 9, 16 },
                    { 13, 9 },
                    { 13, 10 },
                    { 13, 12 },
                    { 13, 13 },
                    { 13, 15 }
                });

            migrationBuilder.InsertData(
                table: "MovieDirectors",
                columns: new[] { "DirectorId", "MovieId" },
                values: new object[,]
                {
                    { 1, 11 },
                    { 1, 16 },
                    { 1, 18 },
                    { 1, 20 },
                    { 1, 21 },
                    { 1, 22 },
                    { 1, 23 },
                    { 1, 24 },
                    { 1, 25 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 6 },
                    { 2, 14 },
                    { 3, 9 },
                    { 3, 10 },
                    { 5, 3 },
                    { 5, 4 }
                });

            migrationBuilder.InsertData(
                table: "MovieDirectors",
                columns: new[] { "DirectorId", "MovieId" },
                values: new object[,]
                {
                    { 6, 5 },
                    { 6, 15 },
                    { 7, 7 },
                    { 8, 12 },
                    { 8, 13 },
                    { 9, 8 },
                    { 9, 17 },
                    { 10, 19 }
                });

            migrationBuilder.InsertData(
                table: "MovieGenres",
                columns: new[] { "GenreId", "MovieId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 10 },
                    { 1, 14 },
                    { 1, 15 },
                    { 1, 20 },
                    { 1, 21 },
                    { 1, 22 },
                    { 1, 23 },
                    { 1, 24 },
                    { 1, 25 },
                    { 2, 3 },
                    { 2, 6 },
                    { 2, 7 },
                    { 2, 16 },
                    { 2, 17 },
                    { 3, 19 },
                    { 4, 4 },
                    { 4, 8 },
                    { 4, 9 },
                    { 4, 11 },
                    { 4, 12 },
                    { 4, 13 },
                    { 4, 15 },
                    { 4, 20 },
                    { 5, 7 },
                    { 5, 17 },
                    { 8, 4 },
                    { 9, 1 },
                    { 9, 3 },
                    { 9, 5 },
                    { 9, 6 },
                    { 9, 16 },
                    { 9, 19 },
                    { 10, 1 }
                });

            migrationBuilder.InsertData(
                table: "MovieGenres",
                columns: new[] { "GenreId", "MovieId" },
                values: new object[,]
                {
                    { 10, 5 },
                    { 10, 10 },
                    { 10, 14 },
                    { 12, 18 },
                    { 13, 2 },
                    { 13, 9 },
                    { 13, 12 },
                    { 13, 13 },
                    { 14, 18 }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "CinemaId", "Col", "CreateTime", "DeleteTime", "IsActive", "Name", "Row", "ScreenType", "UpdateTime" },
                values: new object[,]
                {
                    { 1, 1, 10, null, null, null, "Room 1", 10, "IMAX", null },
                    { 2, 1, 10, null, null, null, "Room 2", 10, "4D", null },
                    { 3, 1, 10, null, null, null, "Room 3", 12, "2D", null },
                    { 4, 1, 10, null, null, null, "Room 4", 12, "3D", null },
                    { 5, 1, 10, null, null, null, "Room 5", 12, "IMAX", null },
                    { 6, 1, 10, null, null, null, "Room 6", 12, "4D", null },
                    { 7, 1, 10, null, null, null, "Room 7", 12, "2D", null },
                    { 8, 1, 10, null, null, null, "Room 8", 12, "3D", null },
                    { 9, 1, 10, null, null, null, "Room 9", 12, "IMAX", null },
                    { 10, 1, 10, null, null, null, "Room 10", 8, "4D", null },
                    { 11, 1, 10, null, null, null, "Room 11", 8, "2D", null },
                    { 12, 1, 10, null, null, null, "Room 12", 8, "3D", null },
                    { 13, 1, 10, null, null, null, "Room 13", 8, "IMAX", null },
                    { 14, 1, 8, null, null, null, "Room 14", 8, "4D", null },
                    { 15, 1, 8, null, null, null, "Room 15", 8, "2D", null },
                    { 16, 2, 8, null, null, null, "Room 16", 8, "3D", null },
                    { 17, 2, 8, null, null, null, "Room 17", 8, "IMAX", null },
                    { 18, 2, 8, null, null, null, "Room 18", 8, "4D", null },
                    { 19, 2, 10, null, null, null, "Room 19", 10, "2D", null },
                    { 20, 2, 10, null, null, null, "Room 20", 10, "3D", null }
                });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "CinemaId", "CreateTime", "DeleteTime", "EndTime", "IsActive", "MovieId", "RoomId", "ShowDate", "ShowTime", "UpdateTime" },
                values: new object[,]
                {
                    { 1, null, null, null, new DateTime(2024, 7, 9, 10, 30, 0, 0, DateTimeKind.Local), null, 2, 1, new DateTime(2024, 7, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 9, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 2, null, null, null, new DateTime(2024, 7, 9, 14, 0, 0, 0, DateTimeKind.Local), null, 2, 1, new DateTime(2024, 7, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 9, 10, 30, 0, 0, DateTimeKind.Local), null },
                    { 3, null, null, null, new DateTime(2024, 7, 9, 17, 30, 0, 0, DateTimeKind.Local), null, 2, 1, new DateTime(2024, 7, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 9, 14, 0, 0, 0, DateTimeKind.Local), null },
                    { 4, null, null, null, new DateTime(2024, 7, 10, 10, 30, 0, 0, DateTimeKind.Local), null, 2, 1, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 10, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 5, null, null, null, new DateTime(2024, 7, 10, 14, 0, 0, 0, DateTimeKind.Local), null, 2, 1, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 10, 10, 30, 0, 0, DateTimeKind.Local), null },
                    { 6, null, null, null, new DateTime(2024, 7, 10, 17, 30, 0, 0, DateTimeKind.Local), null, 2, 1, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 10, 14, 0, 0, 0, DateTimeKind.Local), null },
                    { 7, null, null, null, new DateTime(2024, 7, 6, 10, 30, 0, 0, DateTimeKind.Local), null, 3, 2, new DateTime(2024, 7, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 6, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 8, null, null, null, new DateTime(2024, 7, 6, 14, 0, 0, 0, DateTimeKind.Local), null, 3, 2, new DateTime(2024, 7, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 6, 10, 30, 0, 0, DateTimeKind.Local), null },
                    { 9, null, null, null, new DateTime(2024, 7, 6, 17, 30, 0, 0, DateTimeKind.Local), null, 3, 2, new DateTime(2024, 7, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 6, 14, 0, 0, 0, DateTimeKind.Local), null },
                    { 10, null, null, null, new DateTime(2024, 7, 6, 21, 0, 0, 0, DateTimeKind.Local), null, 3, 2, new DateTime(2024, 7, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 6, 17, 30, 0, 0, DateTimeKind.Local), null },
                    { 11, null, null, null, new DateTime(2024, 7, 7, 10, 30, 0, 0, DateTimeKind.Local), null, 3, 2, new DateTime(2024, 7, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 7, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 12, null, null, null, new DateTime(2024, 7, 7, 14, 0, 0, 0, DateTimeKind.Local), null, 3, 2, new DateTime(2024, 7, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 7, 10, 30, 0, 0, DateTimeKind.Local), null },
                    { 13, null, null, null, new DateTime(2024, 7, 8, 10, 30, 0, 0, DateTimeKind.Local), null, 3, 2, new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 8, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 14, null, null, null, new DateTime(2024, 7, 8, 14, 0, 0, 0, DateTimeKind.Local), null, 3, 2, new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 8, 10, 30, 0, 0, DateTimeKind.Local), null },
                    { 15, null, null, null, new DateTime(2024, 7, 8, 17, 30, 0, 0, DateTimeKind.Local), null, 3, 2, new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 8, 14, 0, 0, 0, DateTimeKind.Local), null },
                    { 16, null, null, null, new DateTime(2024, 7, 9, 10, 30, 0, 0, DateTimeKind.Local), null, 3, 2, new DateTime(2024, 7, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 9, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 17, null, null, null, new DateTime(2024, 7, 9, 14, 0, 0, 0, DateTimeKind.Local), null, 3, 2, new DateTime(2024, 7, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 9, 10, 30, 0, 0, DateTimeKind.Local), null },
                    { 18, null, null, null, new DateTime(2024, 7, 10, 10, 30, 0, 0, DateTimeKind.Local), null, 3, 2, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 10, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 19, null, null, null, new DateTime(2024, 7, 10, 14, 0, 0, 0, DateTimeKind.Local), null, 3, 2, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 10, 10, 30, 0, 0, DateTimeKind.Local), null },
                    { 20, null, null, null, new DateTime(2024, 7, 10, 17, 30, 0, 0, DateTimeKind.Local), null, 3, 2, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 10, 14, 0, 0, 0, DateTimeKind.Local), null },
                    { 21, null, null, null, new DateTime(2024, 7, 10, 21, 0, 0, 0, DateTimeKind.Local), null, 3, 2, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 10, 17, 30, 0, 0, DateTimeKind.Local), null },
                    { 22, null, null, null, new DateTime(2024, 7, 7, 11, 0, 0, 0, DateTimeKind.Local), null, 4, 3, new DateTime(2024, 7, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 7, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 23, null, null, null, new DateTime(2024, 7, 7, 15, 0, 0, 0, DateTimeKind.Local), null, 4, 3, new DateTime(2024, 7, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 7, 11, 0, 0, 0, DateTimeKind.Local), null },
                    { 24, null, null, null, new DateTime(2024, 7, 8, 11, 0, 0, 0, DateTimeKind.Local), null, 4, 3, new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 8, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 25, null, null, null, new DateTime(2024, 7, 8, 15, 0, 0, 0, DateTimeKind.Local), null, 4, 3, new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 8, 11, 0, 0, 0, DateTimeKind.Local), null },
                    { 26, null, null, null, new DateTime(2024, 7, 8, 19, 0, 0, 0, DateTimeKind.Local), null, 4, 3, new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 8, 15, 0, 0, 0, DateTimeKind.Local), null },
                    { 27, null, null, null, new DateTime(2024, 7, 5, 10, 0, 0, 0, DateTimeKind.Local), null, 5, 4, new DateTime(2024, 7, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 5, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 28, null, null, null, new DateTime(2024, 7, 5, 13, 0, 0, 0, DateTimeKind.Local), null, 5, 4, new DateTime(2024, 7, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 5, 10, 0, 0, 0, DateTimeKind.Local), null },
                    { 29, null, null, null, new DateTime(2024, 7, 5, 16, 0, 0, 0, DateTimeKind.Local), null, 5, 4, new DateTime(2024, 7, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 5, 13, 0, 0, 0, DateTimeKind.Local), null },
                    { 30, null, null, null, new DateTime(2024, 7, 5, 19, 0, 0, 0, DateTimeKind.Local), null, 5, 4, new DateTime(2024, 7, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 5, 16, 0, 0, 0, DateTimeKind.Local), null },
                    { 31, null, null, null, new DateTime(2024, 7, 6, 10, 0, 0, 0, DateTimeKind.Local), null, 5, 4, new DateTime(2024, 7, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 6, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 32, null, null, null, new DateTime(2024, 7, 6, 13, 0, 0, 0, DateTimeKind.Local), null, 5, 4, new DateTime(2024, 7, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 6, 10, 0, 0, 0, DateTimeKind.Local), null },
                    { 33, null, null, null, new DateTime(2024, 7, 6, 16, 0, 0, 0, DateTimeKind.Local), null, 5, 4, new DateTime(2024, 7, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 6, 13, 0, 0, 0, DateTimeKind.Local), null },
                    { 34, null, null, null, new DateTime(2024, 7, 7, 10, 0, 0, 0, DateTimeKind.Local), null, 5, 4, new DateTime(2024, 7, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 7, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 35, null, null, null, new DateTime(2024, 7, 7, 13, 0, 0, 0, DateTimeKind.Local), null, 5, 4, new DateTime(2024, 7, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 7, 10, 0, 0, 0, DateTimeKind.Local), null },
                    { 36, null, null, null, new DateTime(2024, 7, 8, 10, 0, 0, 0, DateTimeKind.Local), null, 5, 4, new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 8, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 37, null, null, null, new DateTime(2024, 7, 8, 13, 0, 0, 0, DateTimeKind.Local), null, 5, 4, new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 8, 10, 0, 0, 0, DateTimeKind.Local), null },
                    { 38, null, null, null, new DateTime(2024, 7, 8, 16, 0, 0, 0, DateTimeKind.Local), null, 5, 4, new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 8, 13, 0, 0, 0, DateTimeKind.Local), null },
                    { 39, null, null, null, new DateTime(2024, 7, 8, 19, 0, 0, 0, DateTimeKind.Local), null, 5, 4, new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 8, 16, 0, 0, 0, DateTimeKind.Local), null },
                    { 40, null, null, null, new DateTime(2024, 7, 9, 10, 0, 0, 0, DateTimeKind.Local), null, 5, 4, new DateTime(2024, 7, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 9, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 41, null, null, null, new DateTime(2024, 7, 9, 13, 0, 0, 0, DateTimeKind.Local), null, 5, 4, new DateTime(2024, 7, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 9, 10, 0, 0, 0, DateTimeKind.Local), null },
                    { 42, null, null, null, new DateTime(2024, 7, 9, 16, 0, 0, 0, DateTimeKind.Local), null, 5, 4, new DateTime(2024, 7, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 9, 13, 0, 0, 0, DateTimeKind.Local), null }
                });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "CinemaId", "CreateTime", "DeleteTime", "EndTime", "IsActive", "MovieId", "RoomId", "ShowDate", "ShowTime", "UpdateTime" },
                values: new object[,]
                {
                    { 43, null, null, null, new DateTime(2024, 7, 10, 10, 0, 0, 0, DateTimeKind.Local), null, 5, 4, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 10, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 44, null, null, null, new DateTime(2024, 7, 10, 13, 0, 0, 0, DateTimeKind.Local), null, 5, 4, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 10, 10, 0, 0, 0, DateTimeKind.Local), null },
                    { 45, null, null, null, new DateTime(2024, 7, 11, 10, 0, 0, 0, DateTimeKind.Local), null, 5, 4, new DateTime(2024, 7, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 11, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 46, null, null, null, new DateTime(2024, 7, 11, 13, 0, 0, 0, DateTimeKind.Local), null, 5, 4, new DateTime(2024, 7, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 11, 10, 0, 0, 0, DateTimeKind.Local), null },
                    { 47, null, null, null, new DateTime(2024, 7, 11, 16, 0, 0, 0, DateTimeKind.Local), null, 5, 4, new DateTime(2024, 7, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 11, 13, 0, 0, 0, DateTimeKind.Local), null },
                    { 48, null, null, null, new DateTime(2024, 7, 12, 10, 0, 0, 0, DateTimeKind.Local), null, 5, 4, new DateTime(2024, 7, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 12, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 49, null, null, null, new DateTime(2024, 7, 12, 13, 0, 0, 0, DateTimeKind.Local), null, 5, 4, new DateTime(2024, 7, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 12, 10, 0, 0, 0, DateTimeKind.Local), null },
                    { 50, null, null, null, new DateTime(2024, 7, 12, 16, 0, 0, 0, DateTimeKind.Local), null, 5, 4, new DateTime(2024, 7, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 12, 13, 0, 0, 0, DateTimeKind.Local), null },
                    { 51, null, null, null, new DateTime(2024, 7, 12, 19, 0, 0, 0, DateTimeKind.Local), null, 5, 4, new DateTime(2024, 7, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 12, 16, 0, 0, 0, DateTimeKind.Local), null },
                    { 52, null, null, null, new DateTime(2024, 7, 13, 10, 0, 0, 0, DateTimeKind.Local), null, 5, 4, new DateTime(2024, 7, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 13, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 53, null, null, null, new DateTime(2024, 7, 13, 13, 0, 0, 0, DateTimeKind.Local), null, 5, 4, new DateTime(2024, 7, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 13, 10, 0, 0, 0, DateTimeKind.Local), null },
                    { 54, null, null, null, new DateTime(2024, 7, 13, 16, 0, 0, 0, DateTimeKind.Local), null, 5, 4, new DateTime(2024, 7, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 13, 13, 0, 0, 0, DateTimeKind.Local), null },
                    { 55, null, null, null, new DateTime(2024, 7, 6, 10, 30, 0, 0, DateTimeKind.Local), null, 6, 5, new DateTime(2024, 7, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 6, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 56, null, null, null, new DateTime(2024, 7, 6, 14, 0, 0, 0, DateTimeKind.Local), null, 6, 5, new DateTime(2024, 7, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 6, 10, 30, 0, 0, DateTimeKind.Local), null },
                    { 57, null, null, null, new DateTime(2024, 7, 6, 17, 30, 0, 0, DateTimeKind.Local), null, 6, 5, new DateTime(2024, 7, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 6, 14, 0, 0, 0, DateTimeKind.Local), null },
                    { 58, null, null, null, new DateTime(2024, 7, 7, 10, 30, 0, 0, DateTimeKind.Local), null, 6, 5, new DateTime(2024, 7, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 7, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 59, null, null, null, new DateTime(2024, 7, 7, 14, 0, 0, 0, DateTimeKind.Local), null, 6, 5, new DateTime(2024, 7, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 7, 10, 30, 0, 0, DateTimeKind.Local), null },
                    { 60, null, null, null, new DateTime(2024, 7, 7, 17, 30, 0, 0, DateTimeKind.Local), null, 6, 5, new DateTime(2024, 7, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 7, 14, 0, 0, 0, DateTimeKind.Local), null },
                    { 61, null, null, null, new DateTime(2024, 7, 8, 10, 30, 0, 0, DateTimeKind.Local), null, 6, 5, new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 8, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 62, null, null, null, new DateTime(2024, 7, 8, 14, 0, 0, 0, DateTimeKind.Local), null, 6, 5, new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 8, 10, 30, 0, 0, DateTimeKind.Local), null },
                    { 63, null, null, null, new DateTime(2024, 7, 9, 10, 30, 0, 0, DateTimeKind.Local), null, 6, 5, new DateTime(2024, 7, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 9, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 64, null, null, null, new DateTime(2024, 7, 9, 14, 0, 0, 0, DateTimeKind.Local), null, 6, 5, new DateTime(2024, 7, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 9, 10, 30, 0, 0, DateTimeKind.Local), null },
                    { 65, null, null, null, new DateTime(2024, 7, 10, 10, 30, 0, 0, DateTimeKind.Local), null, 6, 5, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 10, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 66, null, null, null, new DateTime(2024, 7, 10, 14, 0, 0, 0, DateTimeKind.Local), null, 6, 5, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 10, 10, 30, 0, 0, DateTimeKind.Local), null },
                    { 67, null, null, null, new DateTime(2024, 7, 11, 10, 30, 0, 0, DateTimeKind.Local), null, 7, 6, new DateTime(2024, 7, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 11, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 68, null, null, null, new DateTime(2024, 7, 11, 14, 0, 0, 0, DateTimeKind.Local), null, 7, 6, new DateTime(2024, 7, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 11, 10, 30, 0, 0, DateTimeKind.Local), null },
                    { 69, null, null, null, new DateTime(2024, 7, 11, 17, 30, 0, 0, DateTimeKind.Local), null, 7, 6, new DateTime(2024, 7, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 11, 14, 0, 0, 0, DateTimeKind.Local), null },
                    { 70, null, null, null, new DateTime(2024, 7, 11, 21, 0, 0, 0, DateTimeKind.Local), null, 7, 6, new DateTime(2024, 7, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 11, 17, 30, 0, 0, DateTimeKind.Local), null },
                    { 71, null, null, null, new DateTime(2024, 7, 12, 10, 30, 0, 0, DateTimeKind.Local), null, 7, 6, new DateTime(2024, 7, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 12, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 72, null, null, null, new DateTime(2024, 7, 12, 14, 0, 0, 0, DateTimeKind.Local), null, 7, 6, new DateTime(2024, 7, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 12, 10, 30, 0, 0, DateTimeKind.Local), null },
                    { 73, null, null, null, new DateTime(2024, 7, 12, 17, 30, 0, 0, DateTimeKind.Local), null, 7, 6, new DateTime(2024, 7, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 12, 14, 0, 0, 0, DateTimeKind.Local), null },
                    { 74, null, null, null, new DateTime(2024, 7, 6, 10, 0, 0, 0, DateTimeKind.Local), null, 8, 7, new DateTime(2024, 7, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 6, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 75, null, null, null, new DateTime(2024, 7, 6, 13, 0, 0, 0, DateTimeKind.Local), null, 8, 7, new DateTime(2024, 7, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 6, 10, 0, 0, 0, DateTimeKind.Local), null },
                    { 76, null, null, null, new DateTime(2024, 7, 7, 10, 0, 0, 0, DateTimeKind.Local), null, 8, 7, new DateTime(2024, 7, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 7, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 77, null, null, null, new DateTime(2024, 7, 7, 13, 0, 0, 0, DateTimeKind.Local), null, 8, 7, new DateTime(2024, 7, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 7, 10, 0, 0, 0, DateTimeKind.Local), null },
                    { 78, null, null, null, new DateTime(2024, 7, 7, 16, 0, 0, 0, DateTimeKind.Local), null, 8, 7, new DateTime(2024, 7, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 7, 13, 0, 0, 0, DateTimeKind.Local), null },
                    { 79, null, null, null, new DateTime(2024, 7, 8, 10, 0, 0, 0, DateTimeKind.Local), null, 8, 7, new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 8, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 80, null, null, null, new DateTime(2024, 7, 8, 13, 0, 0, 0, DateTimeKind.Local), null, 8, 7, new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 8, 10, 0, 0, 0, DateTimeKind.Local), null },
                    { 81, null, null, null, new DateTime(2024, 7, 8, 16, 0, 0, 0, DateTimeKind.Local), null, 8, 7, new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 8, 13, 0, 0, 0, DateTimeKind.Local), null },
                    { 82, null, null, null, new DateTime(2024, 7, 9, 10, 0, 0, 0, DateTimeKind.Local), null, 8, 7, new DateTime(2024, 7, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 9, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 83, null, null, null, new DateTime(2024, 7, 9, 13, 0, 0, 0, DateTimeKind.Local), null, 8, 7, new DateTime(2024, 7, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 9, 10, 0, 0, 0, DateTimeKind.Local), null },
                    { 84, null, null, null, new DateTime(2024, 7, 10, 10, 0, 0, 0, DateTimeKind.Local), null, 8, 7, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 10, 7, 0, 0, 0, DateTimeKind.Local), null }
                });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "CinemaId", "CreateTime", "DeleteTime", "EndTime", "IsActive", "MovieId", "RoomId", "ShowDate", "ShowTime", "UpdateTime" },
                values: new object[,]
                {
                    { 85, null, null, null, new DateTime(2024, 7, 10, 13, 0, 0, 0, DateTimeKind.Local), null, 8, 7, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 10, 10, 0, 0, 0, DateTimeKind.Local), null },
                    { 86, null, null, null, new DateTime(2024, 7, 10, 16, 0, 0, 0, DateTimeKind.Local), null, 8, 7, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 10, 13, 0, 0, 0, DateTimeKind.Local), null },
                    { 87, null, null, null, new DateTime(2024, 7, 11, 10, 0, 0, 0, DateTimeKind.Local), null, 8, 7, new DateTime(2024, 7, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 11, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 88, null, null, null, new DateTime(2024, 7, 11, 13, 0, 0, 0, DateTimeKind.Local), null, 8, 7, new DateTime(2024, 7, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 11, 10, 0, 0, 0, DateTimeKind.Local), null },
                    { 89, null, null, null, new DateTime(2024, 7, 11, 16, 0, 0, 0, DateTimeKind.Local), null, 8, 7, new DateTime(2024, 7, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 11, 13, 0, 0, 0, DateTimeKind.Local), null },
                    { 90, null, null, null, new DateTime(2024, 7, 12, 10, 0, 0, 0, DateTimeKind.Local), null, 8, 7, new DateTime(2024, 7, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 12, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 91, null, null, null, new DateTime(2024, 7, 12, 13, 0, 0, 0, DateTimeKind.Local), null, 8, 7, new DateTime(2024, 7, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 12, 10, 0, 0, 0, DateTimeKind.Local), null },
                    { 92, null, null, null, new DateTime(2024, 7, 12, 16, 0, 0, 0, DateTimeKind.Local), null, 8, 7, new DateTime(2024, 7, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 12, 13, 0, 0, 0, DateTimeKind.Local), null },
                    { 93, null, null, null, new DateTime(2024, 7, 12, 19, 0, 0, 0, DateTimeKind.Local), null, 8, 7, new DateTime(2024, 7, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 12, 16, 0, 0, 0, DateTimeKind.Local), null },
                    { 94, null, null, null, new DateTime(2024, 7, 13, 10, 0, 0, 0, DateTimeKind.Local), null, 8, 7, new DateTime(2024, 7, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 13, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 95, null, null, null, new DateTime(2024, 7, 13, 13, 0, 0, 0, DateTimeKind.Local), null, 8, 7, new DateTime(2024, 7, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 13, 10, 0, 0, 0, DateTimeKind.Local), null },
                    { 96, null, null, null, new DateTime(2024, 7, 13, 16, 0, 0, 0, DateTimeKind.Local), null, 8, 7, new DateTime(2024, 7, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 13, 13, 0, 0, 0, DateTimeKind.Local), null },
                    { 97, null, null, null, new DateTime(2024, 7, 13, 19, 0, 0, 0, DateTimeKind.Local), null, 8, 7, new DateTime(2024, 7, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 13, 16, 0, 0, 0, DateTimeKind.Local), null },
                    { 98, null, null, null, new DateTime(2024, 7, 8, 10, 30, 0, 0, DateTimeKind.Local), null, 9, 8, new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 8, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 99, null, null, null, new DateTime(2024, 7, 8, 14, 0, 0, 0, DateTimeKind.Local), null, 9, 8, new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 8, 10, 30, 0, 0, DateTimeKind.Local), null },
                    { 100, null, null, null, new DateTime(2024, 7, 8, 17, 30, 0, 0, DateTimeKind.Local), null, 9, 8, new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 8, 14, 0, 0, 0, DateTimeKind.Local), null },
                    { 101, null, null, null, new DateTime(2024, 7, 9, 10, 30, 0, 0, DateTimeKind.Local), null, 9, 8, new DateTime(2024, 7, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 9, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 102, null, null, null, new DateTime(2024, 7, 9, 14, 0, 0, 0, DateTimeKind.Local), null, 9, 8, new DateTime(2024, 7, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 9, 10, 30, 0, 0, DateTimeKind.Local), null },
                    { 103, null, null, null, new DateTime(2024, 7, 9, 17, 30, 0, 0, DateTimeKind.Local), null, 9, 8, new DateTime(2024, 7, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 9, 14, 0, 0, 0, DateTimeKind.Local), null },
                    { 104, null, null, null, new DateTime(2024, 7, 10, 10, 30, 0, 0, DateTimeKind.Local), null, 9, 8, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 10, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 105, null, null, null, new DateTime(2024, 7, 10, 14, 0, 0, 0, DateTimeKind.Local), null, 9, 8, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 10, 10, 30, 0, 0, DateTimeKind.Local), null },
                    { 106, null, null, null, new DateTime(2024, 7, 10, 17, 30, 0, 0, DateTimeKind.Local), null, 9, 8, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 10, 14, 0, 0, 0, DateTimeKind.Local), null },
                    { 107, null, null, null, new DateTime(2024, 7, 10, 21, 0, 0, 0, DateTimeKind.Local), null, 9, 8, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 10, 17, 30, 0, 0, DateTimeKind.Local), null },
                    { 108, null, null, null, new DateTime(2024, 7, 11, 10, 30, 0, 0, DateTimeKind.Local), null, 9, 8, new DateTime(2024, 7, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 11, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 109, null, null, null, new DateTime(2024, 7, 11, 14, 0, 0, 0, DateTimeKind.Local), null, 9, 8, new DateTime(2024, 7, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 11, 10, 30, 0, 0, DateTimeKind.Local), null },
                    { 110, null, null, null, new DateTime(2024, 7, 12, 10, 30, 0, 0, DateTimeKind.Local), null, 9, 8, new DateTime(2024, 7, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 12, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 111, null, null, null, new DateTime(2024, 7, 12, 14, 0, 0, 0, DateTimeKind.Local), null, 9, 8, new DateTime(2024, 7, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 12, 10, 30, 0, 0, DateTimeKind.Local), null },
                    { 112, null, null, null, new DateTime(2024, 7, 13, 10, 30, 0, 0, DateTimeKind.Local), null, 9, 8, new DateTime(2024, 7, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 13, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 113, null, null, null, new DateTime(2024, 7, 13, 14, 0, 0, 0, DateTimeKind.Local), null, 9, 8, new DateTime(2024, 7, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 13, 10, 30, 0, 0, DateTimeKind.Local), null },
                    { 114, null, null, null, new DateTime(2024, 7, 13, 17, 30, 0, 0, DateTimeKind.Local), null, 9, 8, new DateTime(2024, 7, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 13, 14, 0, 0, 0, DateTimeKind.Local), null },
                    { 115, null, null, null, new DateTime(2024, 7, 5, 10, 0, 0, 0, DateTimeKind.Local), null, 10, 9, new DateTime(2024, 7, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 5, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 116, null, null, null, new DateTime(2024, 7, 5, 13, 0, 0, 0, DateTimeKind.Local), null, 10, 9, new DateTime(2024, 7, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 5, 10, 0, 0, 0, DateTimeKind.Local), null },
                    { 117, null, null, null, new DateTime(2024, 7, 6, 10, 0, 0, 0, DateTimeKind.Local), null, 10, 9, new DateTime(2024, 7, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 6, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 118, null, null, null, new DateTime(2024, 7, 6, 13, 0, 0, 0, DateTimeKind.Local), null, 10, 9, new DateTime(2024, 7, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 6, 10, 0, 0, 0, DateTimeKind.Local), null },
                    { 119, null, null, null, new DateTime(2024, 7, 6, 16, 0, 0, 0, DateTimeKind.Local), null, 10, 9, new DateTime(2024, 7, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 6, 13, 0, 0, 0, DateTimeKind.Local), null },
                    { 120, null, null, null, new DateTime(2024, 7, 6, 19, 0, 0, 0, DateTimeKind.Local), null, 10, 9, new DateTime(2024, 7, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 6, 16, 0, 0, 0, DateTimeKind.Local), null },
                    { 121, null, null, null, new DateTime(2024, 7, 7, 10, 0, 0, 0, DateTimeKind.Local), null, 10, 9, new DateTime(2024, 7, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 7, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 122, null, null, null, new DateTime(2024, 7, 7, 13, 0, 0, 0, DateTimeKind.Local), null, 10, 9, new DateTime(2024, 7, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 7, 10, 0, 0, 0, DateTimeKind.Local), null },
                    { 123, null, null, null, new DateTime(2024, 7, 7, 16, 0, 0, 0, DateTimeKind.Local), null, 10, 9, new DateTime(2024, 7, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 7, 13, 0, 0, 0, DateTimeKind.Local), null },
                    { 124, null, null, null, new DateTime(2024, 7, 8, 10, 0, 0, 0, DateTimeKind.Local), null, 10, 9, new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 8, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 125, null, null, null, new DateTime(2024, 7, 8, 13, 0, 0, 0, DateTimeKind.Local), null, 10, 9, new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 8, 10, 0, 0, 0, DateTimeKind.Local), null },
                    { 126, null, null, null, new DateTime(2024, 7, 9, 10, 0, 0, 0, DateTimeKind.Local), null, 10, 9, new DateTime(2024, 7, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 9, 7, 0, 0, 0, DateTimeKind.Local), null }
                });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "CinemaId", "CreateTime", "DeleteTime", "EndTime", "IsActive", "MovieId", "RoomId", "ShowDate", "ShowTime", "UpdateTime" },
                values: new object[,]
                {
                    { 127, null, null, null, new DateTime(2024, 7, 9, 13, 0, 0, 0, DateTimeKind.Local), null, 10, 9, new DateTime(2024, 7, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 9, 10, 0, 0, 0, DateTimeKind.Local), null },
                    { 128, null, null, null, new DateTime(2024, 7, 9, 16, 0, 0, 0, DateTimeKind.Local), null, 10, 9, new DateTime(2024, 7, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 9, 13, 0, 0, 0, DateTimeKind.Local), null },
                    { 129, null, null, null, new DateTime(2024, 7, 9, 19, 0, 0, 0, DateTimeKind.Local), null, 10, 9, new DateTime(2024, 7, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 9, 16, 0, 0, 0, DateTimeKind.Local), null },
                    { 130, null, null, null, new DateTime(2024, 7, 10, 10, 0, 0, 0, DateTimeKind.Local), null, 10, 9, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 10, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 131, null, null, null, new DateTime(2024, 7, 10, 13, 0, 0, 0, DateTimeKind.Local), null, 10, 9, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 10, 10, 0, 0, 0, DateTimeKind.Local), null },
                    { 132, null, null, null, new DateTime(2024, 7, 11, 10, 0, 0, 0, DateTimeKind.Local), null, 10, 9, new DateTime(2024, 7, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 11, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 133, null, null, null, new DateTime(2024, 7, 11, 13, 0, 0, 0, DateTimeKind.Local), null, 10, 9, new DateTime(2024, 7, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 11, 10, 0, 0, 0, DateTimeKind.Local), null },
                    { 134, null, null, null, new DateTime(2024, 7, 11, 16, 0, 0, 0, DateTimeKind.Local), null, 10, 9, new DateTime(2024, 7, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 11, 13, 0, 0, 0, DateTimeKind.Local), null },
                    { 135, null, null, null, new DateTime(2024, 7, 5, 10, 0, 0, 0, DateTimeKind.Local), null, 11, 10, new DateTime(2024, 7, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 5, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 136, null, null, null, new DateTime(2024, 7, 5, 13, 0, 0, 0, DateTimeKind.Local), null, 11, 10, new DateTime(2024, 7, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 5, 10, 0, 0, 0, DateTimeKind.Local), null },
                    { 137, null, null, null, new DateTime(2024, 7, 5, 16, 0, 0, 0, DateTimeKind.Local), null, 11, 10, new DateTime(2024, 7, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 5, 13, 0, 0, 0, DateTimeKind.Local), null },
                    { 138, null, null, null, new DateTime(2024, 7, 5, 19, 0, 0, 0, DateTimeKind.Local), null, 11, 10, new DateTime(2024, 7, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 5, 16, 0, 0, 0, DateTimeKind.Local), null },
                    { 139, null, null, null, new DateTime(2024, 7, 6, 10, 0, 0, 0, DateTimeKind.Local), null, 11, 10, new DateTime(2024, 7, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 6, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 140, null, null, null, new DateTime(2024, 7, 6, 13, 0, 0, 0, DateTimeKind.Local), null, 11, 10, new DateTime(2024, 7, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 6, 10, 0, 0, 0, DateTimeKind.Local), null },
                    { 141, null, null, null, new DateTime(2024, 7, 6, 16, 0, 0, 0, DateTimeKind.Local), null, 11, 10, new DateTime(2024, 7, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 6, 13, 0, 0, 0, DateTimeKind.Local), null },
                    { 142, null, null, null, new DateTime(2024, 7, 6, 19, 0, 0, 0, DateTimeKind.Local), null, 11, 10, new DateTime(2024, 7, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 6, 16, 0, 0, 0, DateTimeKind.Local), null },
                    { 143, null, null, null, new DateTime(2024, 7, 7, 10, 0, 0, 0, DateTimeKind.Local), null, 11, 10, new DateTime(2024, 7, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 7, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 144, null, null, null, new DateTime(2024, 7, 7, 13, 0, 0, 0, DateTimeKind.Local), null, 11, 10, new DateTime(2024, 7, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 7, 10, 0, 0, 0, DateTimeKind.Local), null },
                    { 145, null, null, null, new DateTime(2024, 7, 8, 10, 0, 0, 0, DateTimeKind.Local), null, 11, 10, new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 8, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 146, null, null, null, new DateTime(2024, 7, 8, 13, 0, 0, 0, DateTimeKind.Local), null, 11, 10, new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 8, 10, 0, 0, 0, DateTimeKind.Local), null },
                    { 147, null, null, null, new DateTime(2024, 7, 8, 16, 0, 0, 0, DateTimeKind.Local), null, 11, 10, new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 8, 13, 0, 0, 0, DateTimeKind.Local), null },
                    { 148, null, null, null, new DateTime(2024, 7, 9, 10, 0, 0, 0, DateTimeKind.Local), null, 11, 10, new DateTime(2024, 7, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 9, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 149, null, null, null, new DateTime(2024, 7, 9, 13, 0, 0, 0, DateTimeKind.Local), null, 11, 10, new DateTime(2024, 7, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 9, 10, 0, 0, 0, DateTimeKind.Local), null },
                    { 150, null, null, null, new DateTime(2024, 7, 9, 16, 0, 0, 0, DateTimeKind.Local), null, 11, 10, new DateTime(2024, 7, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 9, 13, 0, 0, 0, DateTimeKind.Local), null },
                    { 151, null, null, null, new DateTime(2024, 7, 10, 10, 30, 0, 0, DateTimeKind.Local), null, 12, 11, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 10, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 152, null, null, null, new DateTime(2024, 7, 10, 14, 0, 0, 0, DateTimeKind.Local), null, 12, 11, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 10, 10, 30, 0, 0, DateTimeKind.Local), null },
                    { 153, null, null, null, new DateTime(2024, 7, 10, 17, 30, 0, 0, DateTimeKind.Local), null, 12, 11, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 10, 14, 0, 0, 0, DateTimeKind.Local), null },
                    { 154, null, null, null, new DateTime(2024, 7, 11, 10, 30, 0, 0, DateTimeKind.Local), null, 12, 11, new DateTime(2024, 7, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 11, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 155, null, null, null, new DateTime(2024, 7, 11, 14, 0, 0, 0, DateTimeKind.Local), null, 12, 11, new DateTime(2024, 7, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 11, 10, 30, 0, 0, DateTimeKind.Local), null },
                    { 156, null, null, null, new DateTime(2024, 7, 11, 17, 30, 0, 0, DateTimeKind.Local), null, 12, 11, new DateTime(2024, 7, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 11, 14, 0, 0, 0, DateTimeKind.Local), null },
                    { 157, null, null, null, new DateTime(2024, 7, 11, 21, 0, 0, 0, DateTimeKind.Local), null, 12, 11, new DateTime(2024, 7, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 11, 17, 30, 0, 0, DateTimeKind.Local), null },
                    { 158, null, null, null, new DateTime(2024, 7, 12, 10, 30, 0, 0, DateTimeKind.Local), null, 12, 11, new DateTime(2024, 7, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 12, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 159, null, null, null, new DateTime(2024, 7, 12, 14, 0, 0, 0, DateTimeKind.Local), null, 12, 11, new DateTime(2024, 7, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 12, 10, 30, 0, 0, DateTimeKind.Local), null },
                    { 160, null, null, null, new DateTime(2024, 7, 12, 17, 30, 0, 0, DateTimeKind.Local), null, 12, 11, new DateTime(2024, 7, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 12, 14, 0, 0, 0, DateTimeKind.Local), null },
                    { 161, null, null, null, new DateTime(2024, 7, 13, 10, 30, 0, 0, DateTimeKind.Local), null, 12, 11, new DateTime(2024, 7, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 13, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 162, null, null, null, new DateTime(2024, 7, 13, 14, 0, 0, 0, DateTimeKind.Local), null, 12, 11, new DateTime(2024, 7, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 13, 10, 30, 0, 0, DateTimeKind.Local), null },
                    { 163, null, null, null, new DateTime(2024, 7, 9, 11, 0, 0, 0, DateTimeKind.Local), null, 13, 12, new DateTime(2024, 7, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 9, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 164, null, null, null, new DateTime(2024, 7, 9, 15, 0, 0, 0, DateTimeKind.Local), null, 13, 12, new DateTime(2024, 7, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 9, 11, 0, 0, 0, DateTimeKind.Local), null },
                    { 165, null, null, null, new DateTime(2024, 7, 9, 19, 0, 0, 0, DateTimeKind.Local), null, 13, 12, new DateTime(2024, 7, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 9, 15, 0, 0, 0, DateTimeKind.Local), null },
                    { 166, null, null, null, new DateTime(2024, 7, 10, 11, 0, 0, 0, DateTimeKind.Local), null, 13, 12, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 10, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 167, null, null, null, new DateTime(2024, 7, 10, 15, 0, 0, 0, DateTimeKind.Local), null, 13, 12, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 10, 11, 0, 0, 0, DateTimeKind.Local), null },
                    { 168, null, null, null, new DateTime(2024, 7, 10, 19, 0, 0, 0, DateTimeKind.Local), null, 13, 12, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 10, 15, 0, 0, 0, DateTimeKind.Local), null }
                });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "CinemaId", "CreateTime", "DeleteTime", "EndTime", "IsActive", "MovieId", "RoomId", "ShowDate", "ShowTime", "UpdateTime" },
                values: new object[,]
                {
                    { 169, null, null, null, new DateTime(2024, 7, 10, 23, 0, 0, 0, DateTimeKind.Local), null, 13, 12, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 10, 19, 0, 0, 0, DateTimeKind.Local), null },
                    { 170, null, null, null, new DateTime(2024, 7, 11, 11, 0, 0, 0, DateTimeKind.Local), null, 13, 12, new DateTime(2024, 7, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 11, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 171, null, null, null, new DateTime(2024, 7, 11, 15, 0, 0, 0, DateTimeKind.Local), null, 13, 12, new DateTime(2024, 7, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 11, 11, 0, 0, 0, DateTimeKind.Local), null },
                    { 172, null, null, null, new DateTime(2024, 7, 11, 19, 0, 0, 0, DateTimeKind.Local), null, 13, 12, new DateTime(2024, 7, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 11, 15, 0, 0, 0, DateTimeKind.Local), null },
                    { 173, null, null, null, new DateTime(2024, 7, 11, 23, 0, 0, 0, DateTimeKind.Local), null, 13, 12, new DateTime(2024, 7, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 11, 19, 0, 0, 0, DateTimeKind.Local), null },
                    { 174, null, null, null, new DateTime(2024, 7, 10, 10, 30, 0, 0, DateTimeKind.Local), null, 14, 13, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 10, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 175, null, null, null, new DateTime(2024, 7, 10, 14, 0, 0, 0, DateTimeKind.Local), null, 14, 13, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 10, 10, 30, 0, 0, DateTimeKind.Local), null },
                    { 176, null, null, null, new DateTime(2024, 7, 12, 10, 30, 0, 0, DateTimeKind.Local), null, 15, 14, new DateTime(2024, 7, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 12, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 177, null, null, null, new DateTime(2024, 7, 12, 14, 0, 0, 0, DateTimeKind.Local), null, 15, 14, new DateTime(2024, 7, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 12, 10, 30, 0, 0, DateTimeKind.Local), null },
                    { 178, null, null, null, new DateTime(2024, 7, 12, 17, 30, 0, 0, DateTimeKind.Local), null, 15, 14, new DateTime(2024, 7, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 12, 14, 0, 0, 0, DateTimeKind.Local), null },
                    { 179, null, null, null, new DateTime(2024, 7, 12, 21, 0, 0, 0, DateTimeKind.Local), null, 15, 14, new DateTime(2024, 7, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 12, 17, 30, 0, 0, DateTimeKind.Local), null },
                    { 180, null, null, null, new DateTime(2024, 7, 8, 10, 0, 0, 0, DateTimeKind.Local), null, 16, 15, new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 8, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 181, null, null, null, new DateTime(2024, 7, 8, 13, 0, 0, 0, DateTimeKind.Local), null, 16, 15, new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 8, 10, 0, 0, 0, DateTimeKind.Local), null },
                    { 182, null, null, null, new DateTime(2024, 7, 8, 16, 0, 0, 0, DateTimeKind.Local), null, 16, 15, new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 8, 13, 0, 0, 0, DateTimeKind.Local), null },
                    { 183, null, null, null, new DateTime(2024, 7, 8, 19, 0, 0, 0, DateTimeKind.Local), null, 16, 15, new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 8, 16, 0, 0, 0, DateTimeKind.Local), null },
                    { 184, null, null, null, new DateTime(2024, 7, 9, 10, 0, 0, 0, DateTimeKind.Local), null, 16, 15, new DateTime(2024, 7, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 9, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 185, null, null, null, new DateTime(2024, 7, 9, 13, 0, 0, 0, DateTimeKind.Local), null, 16, 15, new DateTime(2024, 7, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 9, 10, 0, 0, 0, DateTimeKind.Local), null },
                    { 186, null, null, null, new DateTime(2024, 7, 9, 16, 0, 0, 0, DateTimeKind.Local), null, 16, 15, new DateTime(2024, 7, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 9, 13, 0, 0, 0, DateTimeKind.Local), null },
                    { 187, null, null, null, new DateTime(2024, 7, 9, 19, 0, 0, 0, DateTimeKind.Local), null, 16, 15, new DateTime(2024, 7, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 9, 16, 0, 0, 0, DateTimeKind.Local), null },
                    { 188, null, null, null, new DateTime(2024, 7, 10, 10, 0, 0, 0, DateTimeKind.Local), null, 16, 15, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 10, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 189, null, null, null, new DateTime(2024, 7, 10, 13, 0, 0, 0, DateTimeKind.Local), null, 16, 15, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 10, 10, 0, 0, 0, DateTimeKind.Local), null },
                    { 190, null, null, null, new DateTime(2024, 7, 10, 16, 0, 0, 0, DateTimeKind.Local), null, 16, 15, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 10, 13, 0, 0, 0, DateTimeKind.Local), null },
                    { 191, null, null, null, new DateTime(2024, 7, 10, 19, 0, 0, 0, DateTimeKind.Local), null, 16, 15, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 10, 16, 0, 0, 0, DateTimeKind.Local), null },
                    { 192, null, null, null, new DateTime(2024, 7, 11, 10, 0, 0, 0, DateTimeKind.Local), null, 16, 15, new DateTime(2024, 7, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 11, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 193, null, null, null, new DateTime(2024, 7, 11, 13, 0, 0, 0, DateTimeKind.Local), null, 16, 15, new DateTime(2024, 7, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 11, 10, 0, 0, 0, DateTimeKind.Local), null },
                    { 194, null, null, null, new DateTime(2024, 7, 11, 16, 0, 0, 0, DateTimeKind.Local), null, 16, 15, new DateTime(2024, 7, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 11, 13, 0, 0, 0, DateTimeKind.Local), null },
                    { 195, null, null, null, new DateTime(2024, 7, 11, 19, 0, 0, 0, DateTimeKind.Local), null, 16, 15, new DateTime(2024, 7, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 11, 16, 0, 0, 0, DateTimeKind.Local), null },
                    { 196, null, null, null, new DateTime(2024, 7, 12, 10, 0, 0, 0, DateTimeKind.Local), null, 16, 15, new DateTime(2024, 7, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 12, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 197, null, null, null, new DateTime(2024, 7, 12, 13, 0, 0, 0, DateTimeKind.Local), null, 16, 15, new DateTime(2024, 7, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 12, 10, 0, 0, 0, DateTimeKind.Local), null },
                    { 198, null, null, null, new DateTime(2024, 7, 12, 16, 0, 0, 0, DateTimeKind.Local), null, 16, 15, new DateTime(2024, 7, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 12, 13, 0, 0, 0, DateTimeKind.Local), null },
                    { 199, null, null, null, new DateTime(2024, 7, 12, 19, 0, 0, 0, DateTimeKind.Local), null, 16, 15, new DateTime(2024, 7, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 12, 16, 0, 0, 0, DateTimeKind.Local), null },
                    { 200, null, null, null, new DateTime(2024, 7, 13, 10, 0, 0, 0, DateTimeKind.Local), null, 16, 15, new DateTime(2024, 7, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 13, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 201, null, null, null, new DateTime(2024, 7, 13, 13, 0, 0, 0, DateTimeKind.Local), null, 16, 15, new DateTime(2024, 7, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 13, 10, 0, 0, 0, DateTimeKind.Local), null },
                    { 202, null, null, null, new DateTime(2024, 7, 10, 10, 0, 0, 0, DateTimeKind.Local), null, 17, 16, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 10, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 203, null, null, null, new DateTime(2024, 7, 10, 13, 0, 0, 0, DateTimeKind.Local), null, 17, 16, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 10, 10, 0, 0, 0, DateTimeKind.Local), null },
                    { 204, null, null, null, new DateTime(2024, 7, 10, 16, 0, 0, 0, DateTimeKind.Local), null, 17, 16, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 10, 13, 0, 0, 0, DateTimeKind.Local), null },
                    { 205, null, null, null, new DateTime(2024, 7, 11, 10, 0, 0, 0, DateTimeKind.Local), null, 17, 16, new DateTime(2024, 7, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 11, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 206, null, null, null, new DateTime(2024, 7, 11, 13, 0, 0, 0, DateTimeKind.Local), null, 17, 16, new DateTime(2024, 7, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 11, 10, 0, 0, 0, DateTimeKind.Local), null },
                    { 207, null, null, null, new DateTime(2024, 7, 12, 10, 0, 0, 0, DateTimeKind.Local), null, 17, 16, new DateTime(2024, 7, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 12, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 208, null, null, null, new DateTime(2024, 7, 12, 13, 0, 0, 0, DateTimeKind.Local), null, 17, 16, new DateTime(2024, 7, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 12, 10, 0, 0, 0, DateTimeKind.Local), null },
                    { 209, null, null, null, new DateTime(2024, 7, 12, 16, 0, 0, 0, DateTimeKind.Local), null, 17, 16, new DateTime(2024, 7, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 12, 13, 0, 0, 0, DateTimeKind.Local), null },
                    { 210, null, null, null, new DateTime(2024, 7, 12, 19, 0, 0, 0, DateTimeKind.Local), null, 17, 16, new DateTime(2024, 7, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 12, 16, 0, 0, 0, DateTimeKind.Local), null }
                });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "CinemaId", "CreateTime", "DeleteTime", "EndTime", "IsActive", "MovieId", "RoomId", "ShowDate", "ShowTime", "UpdateTime" },
                values: new object[,]
                {
                    { 211, null, null, null, new DateTime(2024, 7, 8, 9, 0, 0, 0, DateTimeKind.Local), null, 18, 17, new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 8, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 212, null, null, null, new DateTime(2024, 7, 8, 11, 0, 0, 0, DateTimeKind.Local), null, 18, 17, new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 8, 9, 0, 0, 0, DateTimeKind.Local), null },
                    { 213, null, null, null, new DateTime(2024, 7, 8, 13, 0, 0, 0, DateTimeKind.Local), null, 18, 17, new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 8, 11, 0, 0, 0, DateTimeKind.Local), null },
                    { 214, null, null, null, new DateTime(2024, 7, 9, 9, 0, 0, 0, DateTimeKind.Local), null, 18, 17, new DateTime(2024, 7, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 9, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 215, null, null, null, new DateTime(2024, 7, 9, 11, 0, 0, 0, DateTimeKind.Local), null, 18, 17, new DateTime(2024, 7, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 9, 9, 0, 0, 0, DateTimeKind.Local), null },
                    { 216, null, null, null, new DateTime(2024, 7, 10, 9, 0, 0, 0, DateTimeKind.Local), null, 18, 17, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 10, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 217, null, null, null, new DateTime(2024, 7, 10, 11, 0, 0, 0, DateTimeKind.Local), null, 18, 17, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 10, 9, 0, 0, 0, DateTimeKind.Local), null },
                    { 218, null, null, null, new DateTime(2024, 7, 11, 9, 0, 0, 0, DateTimeKind.Local), null, 18, 17, new DateTime(2024, 7, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 11, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 219, null, null, null, new DateTime(2024, 7, 11, 11, 0, 0, 0, DateTimeKind.Local), null, 18, 17, new DateTime(2024, 7, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 11, 9, 0, 0, 0, DateTimeKind.Local), null },
                    { 220, null, null, null, new DateTime(2024, 7, 10, 9, 30, 0, 0, DateTimeKind.Local), null, 19, 18, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 10, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 221, null, null, null, new DateTime(2024, 7, 10, 12, 0, 0, 0, DateTimeKind.Local), null, 19, 18, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 10, 9, 30, 0, 0, DateTimeKind.Local), null },
                    { 222, null, null, null, new DateTime(2024, 7, 10, 14, 30, 0, 0, DateTimeKind.Local), null, 19, 18, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 10, 12, 0, 0, 0, DateTimeKind.Local), null },
                    { 223, null, null, null, new DateTime(2024, 7, 10, 17, 0, 0, 0, DateTimeKind.Local), null, 19, 18, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 10, 14, 30, 0, 0, DateTimeKind.Local), null },
                    { 224, null, null, null, new DateTime(2024, 7, 11, 9, 30, 0, 0, DateTimeKind.Local), null, 19, 18, new DateTime(2024, 7, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 11, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 225, null, null, null, new DateTime(2024, 7, 11, 12, 0, 0, 0, DateTimeKind.Local), null, 19, 18, new DateTime(2024, 7, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 11, 9, 30, 0, 0, DateTimeKind.Local), null },
                    { 226, null, null, null, new DateTime(2024, 7, 7, 10, 30, 0, 0, DateTimeKind.Local), null, 20, 19, new DateTime(2024, 7, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 7, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 227, null, null, null, new DateTime(2024, 7, 7, 14, 0, 0, 0, DateTimeKind.Local), null, 20, 19, new DateTime(2024, 7, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 7, 10, 30, 0, 0, DateTimeKind.Local), null },
                    { 228, null, null, null, new DateTime(2024, 7, 8, 10, 30, 0, 0, DateTimeKind.Local), null, 20, 19, new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 8, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 229, null, null, null, new DateTime(2024, 7, 8, 14, 0, 0, 0, DateTimeKind.Local), null, 20, 19, new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 8, 10, 30, 0, 0, DateTimeKind.Local), null },
                    { 230, null, null, null, new DateTime(2024, 7, 8, 17, 30, 0, 0, DateTimeKind.Local), null, 20, 19, new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 8, 14, 0, 0, 0, DateTimeKind.Local), null },
                    { 231, null, null, null, new DateTime(2024, 7, 8, 21, 0, 0, 0, DateTimeKind.Local), null, 20, 19, new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 8, 17, 30, 0, 0, DateTimeKind.Local), null },
                    { 232, null, null, null, new DateTime(2024, 7, 9, 10, 30, 0, 0, DateTimeKind.Local), null, 20, 19, new DateTime(2024, 7, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 9, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 233, null, null, null, new DateTime(2024, 7, 9, 14, 0, 0, 0, DateTimeKind.Local), null, 20, 19, new DateTime(2024, 7, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 9, 10, 30, 0, 0, DateTimeKind.Local), null },
                    { 234, null, null, null, new DateTime(2024, 7, 9, 17, 30, 0, 0, DateTimeKind.Local), null, 20, 19, new DateTime(2024, 7, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 9, 14, 0, 0, 0, DateTimeKind.Local), null },
                    { 235, null, null, null, new DateTime(2024, 7, 10, 10, 30, 0, 0, DateTimeKind.Local), null, 20, 19, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 10, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 236, null, null, null, new DateTime(2024, 7, 10, 14, 0, 0, 0, DateTimeKind.Local), null, 20, 19, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 10, 10, 30, 0, 0, DateTimeKind.Local), null },
                    { 237, null, null, null, new DateTime(2024, 7, 11, 10, 30, 0, 0, DateTimeKind.Local), null, 20, 19, new DateTime(2024, 7, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 11, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 238, null, null, null, new DateTime(2024, 7, 11, 14, 0, 0, 0, DateTimeKind.Local), null, 20, 19, new DateTime(2024, 7, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 11, 10, 30, 0, 0, DateTimeKind.Local), null },
                    { 239, null, null, null, new DateTime(2024, 7, 11, 17, 30, 0, 0, DateTimeKind.Local), null, 20, 19, new DateTime(2024, 7, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 11, 14, 0, 0, 0, DateTimeKind.Local), null },
                    { 240, null, null, null, new DateTime(2024, 7, 12, 10, 30, 0, 0, DateTimeKind.Local), null, 20, 19, new DateTime(2024, 7, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 12, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 241, null, null, null, new DateTime(2024, 7, 12, 14, 0, 0, 0, DateTimeKind.Local), null, 20, 19, new DateTime(2024, 7, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 12, 10, 30, 0, 0, DateTimeKind.Local), null },
                    { 242, null, null, null, new DateTime(2024, 7, 12, 17, 30, 0, 0, DateTimeKind.Local), null, 20, 19, new DateTime(2024, 7, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 12, 14, 0, 0, 0, DateTimeKind.Local), null },
                    { 243, null, null, null, new DateTime(2024, 7, 12, 21, 0, 0, 0, DateTimeKind.Local), null, 20, 19, new DateTime(2024, 7, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 12, 17, 30, 0, 0, DateTimeKind.Local), null },
                    { 244, null, null, null, new DateTime(2024, 7, 13, 10, 30, 0, 0, DateTimeKind.Local), null, 20, 19, new DateTime(2024, 7, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 13, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 245, null, null, null, new DateTime(2024, 7, 13, 14, 0, 0, 0, DateTimeKind.Local), null, 20, 19, new DateTime(2024, 7, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 13, 10, 30, 0, 0, DateTimeKind.Local), null },
                    { 246, null, null, null, new DateTime(2024, 7, 13, 17, 30, 0, 0, DateTimeKind.Local), null, 20, 19, new DateTime(2024, 7, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 13, 14, 0, 0, 0, DateTimeKind.Local), null },
                    { 247, null, null, null, new DateTime(2024, 7, 7, 10, 0, 0, 0, DateTimeKind.Local), null, 21, 20, new DateTime(2024, 7, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 7, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 248, null, null, null, new DateTime(2024, 7, 7, 13, 0, 0, 0, DateTimeKind.Local), null, 21, 20, new DateTime(2024, 7, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 7, 10, 0, 0, 0, DateTimeKind.Local), null },
                    { 249, null, null, null, new DateTime(2024, 7, 7, 16, 0, 0, 0, DateTimeKind.Local), null, 21, 20, new DateTime(2024, 7, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 7, 13, 0, 0, 0, DateTimeKind.Local), null },
                    { 250, null, null, null, new DateTime(2024, 7, 7, 19, 0, 0, 0, DateTimeKind.Local), null, 21, 20, new DateTime(2024, 7, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 7, 16, 0, 0, 0, DateTimeKind.Local), null },
                    { 251, null, null, null, new DateTime(2024, 7, 8, 10, 0, 0, 0, DateTimeKind.Local), null, 21, 20, new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 8, 7, 0, 0, 0, DateTimeKind.Local), null },
                    { 252, null, null, null, new DateTime(2024, 7, 8, 13, 0, 0, 0, DateTimeKind.Local), null, 21, 20, new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 8, 10, 0, 0, 0, DateTimeKind.Local), null }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CreateTime", "DeleteTime", "IsActive", "Name", "RoomId", "SeatTypeId", "UpdateTime" },
                values: new object[,]
                {
                    { 1, null, null, null, "A1", 1, 1, null },
                    { 2, null, null, null, "A2", 1, 1, null },
                    { 3, null, null, null, "A3", 1, 1, null },
                    { 4, null, null, null, "A4", 1, 1, null },
                    { 5, null, null, null, "A5", 1, 1, null },
                    { 6, null, null, null, "A6", 1, 1, null },
                    { 7, null, null, null, "A7", 1, 1, null },
                    { 8, null, null, null, "A8", 1, 1, null },
                    { 9, null, null, null, "A9", 1, 1, null },
                    { 10, null, null, null, "A10", 1, 1, null },
                    { 11, null, null, null, "B1", 1, 1, null },
                    { 12, null, null, null, "B2", 1, 1, null },
                    { 13, null, null, null, "B3", 1, 1, null },
                    { 14, null, null, null, "B4", 1, 1, null },
                    { 15, null, null, null, "B5", 1, 1, null },
                    { 16, null, null, null, "B6", 1, 1, null },
                    { 17, null, null, null, "B7", 1, 1, null },
                    { 18, null, null, null, "B8", 1, 1, null },
                    { 19, null, null, null, "B9", 1, 1, null },
                    { 20, null, null, null, "B10", 1, 1, null },
                    { 21, null, null, null, "C1", 1, 2, null },
                    { 22, null, null, null, "C2", 1, 2, null },
                    { 23, null, null, null, "C3", 1, 2, null },
                    { 24, null, null, null, "C4", 1, 2, null },
                    { 25, null, null, null, "C5", 1, 2, null },
                    { 26, null, null, null, "C6", 1, 2, null },
                    { 27, null, null, null, "C7", 1, 2, null },
                    { 28, null, null, null, "C8", 1, 2, null },
                    { 29, null, null, null, "C9", 1, 2, null },
                    { 30, null, null, null, "C10", 1, 2, null },
                    { 31, null, null, null, "D1", 1, 2, null },
                    { 32, null, null, null, "D2", 1, 2, null },
                    { 33, null, null, null, "D3", 1, 2, null },
                    { 34, null, null, null, "D4", 1, 2, null },
                    { 35, null, null, null, "D5", 1, 2, null },
                    { 36, null, null, null, "D6", 1, 2, null },
                    { 37, null, null, null, "D7", 1, 2, null },
                    { 38, null, null, null, "D8", 1, 2, null },
                    { 39, null, null, null, "D9", 1, 2, null },
                    { 40, null, null, null, "D10", 1, 2, null },
                    { 41, null, null, null, "E1", 1, 2, null },
                    { 42, null, null, null, "E2", 1, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CreateTime", "DeleteTime", "IsActive", "Name", "RoomId", "SeatTypeId", "UpdateTime" },
                values: new object[,]
                {
                    { 43, null, null, null, "E3", 1, 2, null },
                    { 44, null, null, null, "E4", 1, 2, null },
                    { 45, null, null, null, "E5", 1, 2, null },
                    { 46, null, null, null, "E6", 1, 2, null },
                    { 47, null, null, null, "E7", 1, 2, null },
                    { 48, null, null, null, "E8", 1, 2, null },
                    { 49, null, null, null, "E9", 1, 2, null },
                    { 50, null, null, null, "E10", 1, 2, null },
                    { 51, null, null, null, "F1", 1, 2, null },
                    { 52, null, null, null, "F2", 1, 2, null },
                    { 53, null, null, null, "F3", 1, 2, null },
                    { 54, null, null, null, "F4", 1, 2, null },
                    { 55, null, null, null, "F5", 1, 2, null },
                    { 56, null, null, null, "F6", 1, 2, null },
                    { 57, null, null, null, "F7", 1, 2, null },
                    { 58, null, null, null, "F8", 1, 2, null },
                    { 59, null, null, null, "F9", 1, 2, null },
                    { 60, null, null, null, "F10", 1, 2, null },
                    { 61, null, null, null, "G1", 1, 2, null },
                    { 62, null, null, null, "G2", 1, 2, null },
                    { 63, null, null, null, "G3", 1, 2, null },
                    { 64, null, null, null, "G4", 1, 2, null },
                    { 65, null, null, null, "G5", 1, 2, null },
                    { 66, null, null, null, "G6", 1, 2, null },
                    { 67, null, null, null, "G7", 1, 2, null },
                    { 68, null, null, null, "G8", 1, 2, null },
                    { 69, null, null, null, "G9", 1, 2, null },
                    { 70, null, null, null, "G10", 1, 2, null },
                    { 71, null, null, null, "H1", 1, 2, null },
                    { 72, null, null, null, "H2", 1, 2, null },
                    { 73, null, null, null, "H3", 1, 2, null },
                    { 74, null, null, null, "H4", 1, 2, null },
                    { 75, null, null, null, "H5", 1, 2, null },
                    { 76, null, null, null, "H6", 1, 2, null },
                    { 77, null, null, null, "H7", 1, 2, null },
                    { 78, null, null, null, "H8", 1, 2, null },
                    { 79, null, null, null, "H9", 1, 2, null },
                    { 80, null, null, null, "H10", 1, 2, null },
                    { 81, null, null, null, "I1", 1, 2, null },
                    { 82, null, null, null, "I2", 1, 2, null },
                    { 83, null, null, null, "I3", 1, 2, null },
                    { 84, null, null, null, "I4", 1, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CreateTime", "DeleteTime", "IsActive", "Name", "RoomId", "SeatTypeId", "UpdateTime" },
                values: new object[,]
                {
                    { 85, null, null, null, "I5", 1, 2, null },
                    { 86, null, null, null, "I6", 1, 2, null },
                    { 87, null, null, null, "I7", 1, 2, null },
                    { 88, null, null, null, "I8", 1, 2, null },
                    { 89, null, null, null, "I9", 1, 2, null },
                    { 90, null, null, null, "I10", 1, 2, null },
                    { 91, null, null, null, "J1", 1, 2, null },
                    { 92, null, null, null, "J2", 1, 2, null },
                    { 93, null, null, null, "J3", 1, 2, null },
                    { 94, null, null, null, "J4", 1, 2, null },
                    { 95, null, null, null, "J5", 1, 2, null },
                    { 96, null, null, null, "J6", 1, 2, null },
                    { 97, null, null, null, "J7", 1, 2, null },
                    { 98, null, null, null, "J8", 1, 2, null },
                    { 99, null, null, null, "J9", 1, 2, null },
                    { 100, null, null, null, "J10", 1, 2, null },
                    { 101, null, null, null, "A1", 2, 1, null },
                    { 102, null, null, null, "A2", 2, 1, null },
                    { 103, null, null, null, "A3", 2, 1, null },
                    { 104, null, null, null, "A4", 2, 1, null },
                    { 105, null, null, null, "A5", 2, 1, null },
                    { 106, null, null, null, "A6", 2, 1, null },
                    { 107, null, null, null, "A7", 2, 1, null },
                    { 108, null, null, null, "A8", 2, 1, null },
                    { 109, null, null, null, "A9", 2, 1, null },
                    { 110, null, null, null, "A10", 2, 1, null },
                    { 111, null, null, null, "B1", 2, 1, null },
                    { 112, null, null, null, "B2", 2, 1, null },
                    { 113, null, null, null, "B3", 2, 1, null },
                    { 114, null, null, null, "B4", 2, 1, null },
                    { 115, null, null, null, "B5", 2, 1, null },
                    { 116, null, null, null, "B6", 2, 1, null },
                    { 117, null, null, null, "B7", 2, 1, null },
                    { 118, null, null, null, "B8", 2, 1, null },
                    { 119, null, null, null, "B9", 2, 1, null },
                    { 120, null, null, null, "B10", 2, 1, null },
                    { 121, null, null, null, "C1", 2, 2, null },
                    { 122, null, null, null, "C2", 2, 2, null },
                    { 123, null, null, null, "C3", 2, 2, null },
                    { 124, null, null, null, "C4", 2, 2, null },
                    { 125, null, null, null, "C5", 2, 2, null },
                    { 126, null, null, null, "C6", 2, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CreateTime", "DeleteTime", "IsActive", "Name", "RoomId", "SeatTypeId", "UpdateTime" },
                values: new object[,]
                {
                    { 127, null, null, null, "C7", 2, 2, null },
                    { 128, null, null, null, "C8", 2, 2, null },
                    { 129, null, null, null, "C9", 2, 2, null },
                    { 130, null, null, null, "C10", 2, 2, null },
                    { 131, null, null, null, "D1", 2, 2, null },
                    { 132, null, null, null, "D2", 2, 2, null },
                    { 133, null, null, null, "D3", 2, 2, null },
                    { 134, null, null, null, "D4", 2, 2, null },
                    { 135, null, null, null, "D5", 2, 2, null },
                    { 136, null, null, null, "D6", 2, 2, null },
                    { 137, null, null, null, "D7", 2, 2, null },
                    { 138, null, null, null, "D8", 2, 2, null },
                    { 139, null, null, null, "D9", 2, 2, null },
                    { 140, null, null, null, "D10", 2, 2, null },
                    { 141, null, null, null, "E1", 2, 2, null },
                    { 142, null, null, null, "E2", 2, 2, null },
                    { 143, null, null, null, "E3", 2, 2, null },
                    { 144, null, null, null, "E4", 2, 2, null },
                    { 145, null, null, null, "E5", 2, 2, null },
                    { 146, null, null, null, "E6", 2, 2, null },
                    { 147, null, null, null, "E7", 2, 2, null },
                    { 148, null, null, null, "E8", 2, 2, null },
                    { 149, null, null, null, "E9", 2, 2, null },
                    { 150, null, null, null, "E10", 2, 2, null },
                    { 151, null, null, null, "F1", 2, 2, null },
                    { 152, null, null, null, "F2", 2, 2, null },
                    { 153, null, null, null, "F3", 2, 2, null },
                    { 154, null, null, null, "F4", 2, 2, null },
                    { 155, null, null, null, "F5", 2, 2, null },
                    { 156, null, null, null, "F6", 2, 2, null },
                    { 157, null, null, null, "F7", 2, 2, null },
                    { 158, null, null, null, "F8", 2, 2, null },
                    { 159, null, null, null, "F9", 2, 2, null },
                    { 160, null, null, null, "F10", 2, 2, null },
                    { 161, null, null, null, "G1", 2, 2, null },
                    { 162, null, null, null, "G2", 2, 2, null },
                    { 163, null, null, null, "G3", 2, 2, null },
                    { 164, null, null, null, "G4", 2, 2, null },
                    { 165, null, null, null, "G5", 2, 2, null },
                    { 166, null, null, null, "G6", 2, 2, null },
                    { 167, null, null, null, "G7", 2, 2, null },
                    { 168, null, null, null, "G8", 2, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CreateTime", "DeleteTime", "IsActive", "Name", "RoomId", "SeatTypeId", "UpdateTime" },
                values: new object[,]
                {
                    { 169, null, null, null, "G9", 2, 2, null },
                    { 170, null, null, null, "G10", 2, 2, null },
                    { 171, null, null, null, "H1", 2, 2, null },
                    { 172, null, null, null, "H2", 2, 2, null },
                    { 173, null, null, null, "H3", 2, 2, null },
                    { 174, null, null, null, "H4", 2, 2, null },
                    { 175, null, null, null, "H5", 2, 2, null },
                    { 176, null, null, null, "H6", 2, 2, null },
                    { 177, null, null, null, "H7", 2, 2, null },
                    { 178, null, null, null, "H8", 2, 2, null },
                    { 179, null, null, null, "H9", 2, 2, null },
                    { 180, null, null, null, "H10", 2, 2, null },
                    { 181, null, null, null, "I1", 2, 2, null },
                    { 182, null, null, null, "I2", 2, 2, null },
                    { 183, null, null, null, "I3", 2, 2, null },
                    { 184, null, null, null, "I4", 2, 2, null },
                    { 185, null, null, null, "I5", 2, 2, null },
                    { 186, null, null, null, "I6", 2, 2, null },
                    { 187, null, null, null, "I7", 2, 2, null },
                    { 188, null, null, null, "I8", 2, 2, null },
                    { 189, null, null, null, "I9", 2, 2, null },
                    { 190, null, null, null, "I10", 2, 2, null },
                    { 191, null, null, null, "J1", 2, 2, null },
                    { 192, null, null, null, "J2", 2, 2, null },
                    { 193, null, null, null, "J3", 2, 2, null },
                    { 194, null, null, null, "J4", 2, 2, null },
                    { 195, null, null, null, "J5", 2, 2, null },
                    { 196, null, null, null, "J6", 2, 2, null },
                    { 197, null, null, null, "J7", 2, 2, null },
                    { 198, null, null, null, "J8", 2, 2, null },
                    { 199, null, null, null, "J9", 2, 2, null },
                    { 200, null, null, null, "J10", 2, 2, null },
                    { 201, null, null, null, "A1", 3, 1, null },
                    { 202, null, null, null, "A2", 3, 1, null },
                    { 203, null, null, null, "A3", 3, 1, null },
                    { 204, null, null, null, "A4", 3, 1, null },
                    { 205, null, null, null, "A5", 3, 1, null },
                    { 206, null, null, null, "A6", 3, 1, null },
                    { 207, null, null, null, "A7", 3, 1, null },
                    { 208, null, null, null, "A8", 3, 1, null },
                    { 209, null, null, null, "A9", 3, 1, null },
                    { 210, null, null, null, "A10", 3, 1, null }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CreateTime", "DeleteTime", "IsActive", "Name", "RoomId", "SeatTypeId", "UpdateTime" },
                values: new object[,]
                {
                    { 211, null, null, null, "B1", 3, 1, null },
                    { 212, null, null, null, "B2", 3, 1, null },
                    { 213, null, null, null, "B3", 3, 1, null },
                    { 214, null, null, null, "B4", 3, 1, null },
                    { 215, null, null, null, "B5", 3, 1, null },
                    { 216, null, null, null, "B6", 3, 1, null },
                    { 217, null, null, null, "B7", 3, 1, null },
                    { 218, null, null, null, "B8", 3, 1, null },
                    { 219, null, null, null, "B9", 3, 1, null },
                    { 220, null, null, null, "B10", 3, 1, null },
                    { 221, null, null, null, "C1", 3, 2, null },
                    { 222, null, null, null, "C2", 3, 2, null },
                    { 223, null, null, null, "C3", 3, 2, null },
                    { 224, null, null, null, "C4", 3, 2, null },
                    { 225, null, null, null, "C5", 3, 2, null },
                    { 226, null, null, null, "C6", 3, 2, null },
                    { 227, null, null, null, "C7", 3, 2, null },
                    { 228, null, null, null, "C8", 3, 2, null },
                    { 229, null, null, null, "C9", 3, 2, null },
                    { 230, null, null, null, "C10", 3, 2, null },
                    { 231, null, null, null, "D1", 3, 2, null },
                    { 232, null, null, null, "D2", 3, 2, null },
                    { 233, null, null, null, "D3", 3, 2, null },
                    { 234, null, null, null, "D4", 3, 2, null },
                    { 235, null, null, null, "D5", 3, 2, null },
                    { 236, null, null, null, "D6", 3, 2, null },
                    { 237, null, null, null, "D7", 3, 2, null },
                    { 238, null, null, null, "D8", 3, 2, null },
                    { 239, null, null, null, "D9", 3, 2, null },
                    { 240, null, null, null, "D10", 3, 2, null },
                    { 241, null, null, null, "E1", 3, 2, null },
                    { 242, null, null, null, "E2", 3, 2, null },
                    { 243, null, null, null, "E3", 3, 2, null },
                    { 244, null, null, null, "E4", 3, 2, null },
                    { 245, null, null, null, "E5", 3, 2, null },
                    { 246, null, null, null, "E6", 3, 2, null },
                    { 247, null, null, null, "E7", 3, 2, null },
                    { 248, null, null, null, "E8", 3, 2, null },
                    { 249, null, null, null, "E9", 3, 2, null },
                    { 250, null, null, null, "E10", 3, 2, null },
                    { 251, null, null, null, "F1", 3, 2, null },
                    { 252, null, null, null, "F2", 3, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CreateTime", "DeleteTime", "IsActive", "Name", "RoomId", "SeatTypeId", "UpdateTime" },
                values: new object[,]
                {
                    { 253, null, null, null, "F3", 3, 2, null },
                    { 254, null, null, null, "F4", 3, 2, null },
                    { 255, null, null, null, "F5", 3, 2, null },
                    { 256, null, null, null, "F6", 3, 2, null },
                    { 257, null, null, null, "F7", 3, 2, null },
                    { 258, null, null, null, "F8", 3, 2, null },
                    { 259, null, null, null, "F9", 3, 2, null },
                    { 260, null, null, null, "F10", 3, 2, null },
                    { 261, null, null, null, "G1", 3, 2, null },
                    { 262, null, null, null, "G2", 3, 2, null },
                    { 263, null, null, null, "G3", 3, 2, null },
                    { 264, null, null, null, "G4", 3, 2, null },
                    { 265, null, null, null, "G5", 3, 2, null },
                    { 266, null, null, null, "G6", 3, 2, null },
                    { 267, null, null, null, "G7", 3, 2, null },
                    { 268, null, null, null, "G8", 3, 2, null },
                    { 269, null, null, null, "G9", 3, 2, null },
                    { 270, null, null, null, "G10", 3, 2, null },
                    { 271, null, null, null, "H1", 3, 2, null },
                    { 272, null, null, null, "H2", 3, 2, null },
                    { 273, null, null, null, "H3", 3, 2, null },
                    { 274, null, null, null, "H4", 3, 2, null },
                    { 275, null, null, null, "H5", 3, 2, null },
                    { 276, null, null, null, "H6", 3, 2, null },
                    { 277, null, null, null, "H7", 3, 2, null },
                    { 278, null, null, null, "H8", 3, 2, null },
                    { 279, null, null, null, "H9", 3, 2, null },
                    { 280, null, null, null, "H10", 3, 2, null },
                    { 281, null, null, null, "I1", 3, 2, null },
                    { 282, null, null, null, "I2", 3, 2, null },
                    { 283, null, null, null, "I3", 3, 2, null },
                    { 284, null, null, null, "I4", 3, 2, null },
                    { 285, null, null, null, "I5", 3, 2, null },
                    { 286, null, null, null, "I6", 3, 2, null },
                    { 287, null, null, null, "I7", 3, 2, null },
                    { 288, null, null, null, "I8", 3, 2, null },
                    { 289, null, null, null, "I9", 3, 2, null },
                    { 290, null, null, null, "I10", 3, 2, null },
                    { 291, null, null, null, "J1", 3, 2, null },
                    { 292, null, null, null, "J2", 3, 2, null },
                    { 293, null, null, null, "J3", 3, 2, null },
                    { 294, null, null, null, "J4", 3, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CreateTime", "DeleteTime", "IsActive", "Name", "RoomId", "SeatTypeId", "UpdateTime" },
                values: new object[,]
                {
                    { 295, null, null, null, "J5", 3, 2, null },
                    { 296, null, null, null, "J6", 3, 2, null },
                    { 297, null, null, null, "J7", 3, 2, null },
                    { 298, null, null, null, "J8", 3, 2, null },
                    { 299, null, null, null, "J9", 3, 2, null },
                    { 300, null, null, null, "J10", 3, 2, null },
                    { 301, null, null, null, "K1", 3, 2, null },
                    { 302, null, null, null, "K2", 3, 2, null },
                    { 303, null, null, null, "K3", 3, 2, null },
                    { 304, null, null, null, "K4", 3, 2, null },
                    { 305, null, null, null, "K5", 3, 2, null },
                    { 306, null, null, null, "K6", 3, 2, null },
                    { 307, null, null, null, "K7", 3, 2, null },
                    { 308, null, null, null, "K8", 3, 2, null },
                    { 309, null, null, null, "K9", 3, 2, null },
                    { 310, null, null, null, "K10", 3, 2, null },
                    { 311, null, null, null, "L1", 3, 2, null },
                    { 312, null, null, null, "L2", 3, 2, null },
                    { 313, null, null, null, "L3", 3, 2, null },
                    { 314, null, null, null, "L4", 3, 2, null },
                    { 315, null, null, null, "L5", 3, 2, null },
                    { 316, null, null, null, "L6", 3, 2, null },
                    { 317, null, null, null, "L7", 3, 2, null },
                    { 318, null, null, null, "L8", 3, 2, null },
                    { 319, null, null, null, "L9", 3, 2, null },
                    { 320, null, null, null, "L10", 3, 2, null },
                    { 321, null, null, null, "A1", 4, 1, null },
                    { 322, null, null, null, "A2", 4, 1, null },
                    { 323, null, null, null, "A3", 4, 1, null },
                    { 324, null, null, null, "A4", 4, 1, null },
                    { 325, null, null, null, "A5", 4, 1, null },
                    { 326, null, null, null, "A6", 4, 1, null },
                    { 327, null, null, null, "A7", 4, 1, null },
                    { 328, null, null, null, "A8", 4, 1, null },
                    { 329, null, null, null, "A9", 4, 1, null },
                    { 330, null, null, null, "A10", 4, 1, null },
                    { 331, null, null, null, "B1", 4, 1, null },
                    { 332, null, null, null, "B2", 4, 1, null },
                    { 333, null, null, null, "B3", 4, 1, null },
                    { 334, null, null, null, "B4", 4, 1, null },
                    { 335, null, null, null, "B5", 4, 1, null },
                    { 336, null, null, null, "B6", 4, 1, null }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CreateTime", "DeleteTime", "IsActive", "Name", "RoomId", "SeatTypeId", "UpdateTime" },
                values: new object[,]
                {
                    { 337, null, null, null, "B7", 4, 1, null },
                    { 338, null, null, null, "B8", 4, 1, null },
                    { 339, null, null, null, "B9", 4, 1, null },
                    { 340, null, null, null, "B10", 4, 1, null },
                    { 341, null, null, null, "C1", 4, 2, null },
                    { 342, null, null, null, "C2", 4, 2, null },
                    { 343, null, null, null, "C3", 4, 2, null },
                    { 344, null, null, null, "C4", 4, 2, null },
                    { 345, null, null, null, "C5", 4, 2, null },
                    { 346, null, null, null, "C6", 4, 2, null },
                    { 347, null, null, null, "C7", 4, 2, null },
                    { 348, null, null, null, "C8", 4, 2, null },
                    { 349, null, null, null, "C9", 4, 2, null },
                    { 350, null, null, null, "C10", 4, 2, null },
                    { 351, null, null, null, "D1", 4, 2, null },
                    { 352, null, null, null, "D2", 4, 2, null },
                    { 353, null, null, null, "D3", 4, 2, null },
                    { 354, null, null, null, "D4", 4, 2, null },
                    { 355, null, null, null, "D5", 4, 2, null },
                    { 356, null, null, null, "D6", 4, 2, null },
                    { 357, null, null, null, "D7", 4, 2, null },
                    { 358, null, null, null, "D8", 4, 2, null },
                    { 359, null, null, null, "D9", 4, 2, null },
                    { 360, null, null, null, "D10", 4, 2, null },
                    { 361, null, null, null, "E1", 4, 2, null },
                    { 362, null, null, null, "E2", 4, 2, null },
                    { 363, null, null, null, "E3", 4, 2, null },
                    { 364, null, null, null, "E4", 4, 2, null },
                    { 365, null, null, null, "E5", 4, 2, null },
                    { 366, null, null, null, "E6", 4, 2, null },
                    { 367, null, null, null, "E7", 4, 2, null },
                    { 368, null, null, null, "E8", 4, 2, null },
                    { 369, null, null, null, "E9", 4, 2, null },
                    { 370, null, null, null, "E10", 4, 2, null },
                    { 371, null, null, null, "F1", 4, 2, null },
                    { 372, null, null, null, "F2", 4, 2, null },
                    { 373, null, null, null, "F3", 4, 2, null },
                    { 374, null, null, null, "F4", 4, 2, null },
                    { 375, null, null, null, "F5", 4, 2, null },
                    { 376, null, null, null, "F6", 4, 2, null },
                    { 377, null, null, null, "F7", 4, 2, null },
                    { 378, null, null, null, "F8", 4, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CreateTime", "DeleteTime", "IsActive", "Name", "RoomId", "SeatTypeId", "UpdateTime" },
                values: new object[,]
                {
                    { 379, null, null, null, "F9", 4, 2, null },
                    { 380, null, null, null, "F10", 4, 2, null },
                    { 381, null, null, null, "G1", 4, 2, null },
                    { 382, null, null, null, "G2", 4, 2, null },
                    { 383, null, null, null, "G3", 4, 2, null },
                    { 384, null, null, null, "G4", 4, 2, null },
                    { 385, null, null, null, "G5", 4, 2, null },
                    { 386, null, null, null, "G6", 4, 2, null },
                    { 387, null, null, null, "G7", 4, 2, null },
                    { 388, null, null, null, "G8", 4, 2, null },
                    { 389, null, null, null, "G9", 4, 2, null },
                    { 390, null, null, null, "G10", 4, 2, null },
                    { 391, null, null, null, "H1", 4, 2, null },
                    { 392, null, null, null, "H2", 4, 2, null },
                    { 393, null, null, null, "H3", 4, 2, null },
                    { 394, null, null, null, "H4", 4, 2, null },
                    { 395, null, null, null, "H5", 4, 2, null },
                    { 396, null, null, null, "H6", 4, 2, null },
                    { 397, null, null, null, "H7", 4, 2, null },
                    { 398, null, null, null, "H8", 4, 2, null },
                    { 399, null, null, null, "H9", 4, 2, null },
                    { 400, null, null, null, "H10", 4, 2, null },
                    { 401, null, null, null, "I1", 4, 2, null },
                    { 402, null, null, null, "I2", 4, 2, null },
                    { 403, null, null, null, "I3", 4, 2, null },
                    { 404, null, null, null, "I4", 4, 2, null },
                    { 405, null, null, null, "I5", 4, 2, null },
                    { 406, null, null, null, "I6", 4, 2, null },
                    { 407, null, null, null, "I7", 4, 2, null },
                    { 408, null, null, null, "I8", 4, 2, null },
                    { 409, null, null, null, "I9", 4, 2, null },
                    { 410, null, null, null, "I10", 4, 2, null },
                    { 411, null, null, null, "J1", 4, 2, null },
                    { 412, null, null, null, "J2", 4, 2, null },
                    { 413, null, null, null, "J3", 4, 2, null },
                    { 414, null, null, null, "J4", 4, 2, null },
                    { 415, null, null, null, "J5", 4, 2, null },
                    { 416, null, null, null, "J6", 4, 2, null },
                    { 417, null, null, null, "J7", 4, 2, null },
                    { 418, null, null, null, "J8", 4, 2, null },
                    { 419, null, null, null, "J9", 4, 2, null },
                    { 420, null, null, null, "J10", 4, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CreateTime", "DeleteTime", "IsActive", "Name", "RoomId", "SeatTypeId", "UpdateTime" },
                values: new object[,]
                {
                    { 421, null, null, null, "K1", 4, 2, null },
                    { 422, null, null, null, "K2", 4, 2, null },
                    { 423, null, null, null, "K3", 4, 2, null },
                    { 424, null, null, null, "K4", 4, 2, null },
                    { 425, null, null, null, "K5", 4, 2, null },
                    { 426, null, null, null, "K6", 4, 2, null },
                    { 427, null, null, null, "K7", 4, 2, null },
                    { 428, null, null, null, "K8", 4, 2, null },
                    { 429, null, null, null, "K9", 4, 2, null },
                    { 430, null, null, null, "K10", 4, 2, null },
                    { 431, null, null, null, "L1", 4, 2, null },
                    { 432, null, null, null, "L2", 4, 2, null },
                    { 433, null, null, null, "L3", 4, 2, null },
                    { 434, null, null, null, "L4", 4, 2, null },
                    { 435, null, null, null, "L5", 4, 2, null },
                    { 436, null, null, null, "L6", 4, 2, null },
                    { 437, null, null, null, "L7", 4, 2, null },
                    { 438, null, null, null, "L8", 4, 2, null },
                    { 439, null, null, null, "L9", 4, 2, null },
                    { 440, null, null, null, "L10", 4, 2, null },
                    { 441, null, null, null, "A1", 5, 1, null },
                    { 442, null, null, null, "A2", 5, 1, null },
                    { 443, null, null, null, "A3", 5, 1, null },
                    { 444, null, null, null, "A4", 5, 1, null },
                    { 445, null, null, null, "A5", 5, 1, null },
                    { 446, null, null, null, "A6", 5, 1, null },
                    { 447, null, null, null, "A7", 5, 1, null },
                    { 448, null, null, null, "A8", 5, 1, null },
                    { 449, null, null, null, "A9", 5, 1, null },
                    { 450, null, null, null, "A10", 5, 1, null },
                    { 451, null, null, null, "B1", 5, 1, null },
                    { 452, null, null, null, "B2", 5, 1, null },
                    { 453, null, null, null, "B3", 5, 1, null },
                    { 454, null, null, null, "B4", 5, 1, null },
                    { 455, null, null, null, "B5", 5, 1, null },
                    { 456, null, null, null, "B6", 5, 1, null },
                    { 457, null, null, null, "B7", 5, 1, null },
                    { 458, null, null, null, "B8", 5, 1, null },
                    { 459, null, null, null, "B9", 5, 1, null },
                    { 460, null, null, null, "B10", 5, 1, null },
                    { 461, null, null, null, "C1", 5, 2, null },
                    { 462, null, null, null, "C2", 5, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CreateTime", "DeleteTime", "IsActive", "Name", "RoomId", "SeatTypeId", "UpdateTime" },
                values: new object[,]
                {
                    { 463, null, null, null, "C3", 5, 2, null },
                    { 464, null, null, null, "C4", 5, 2, null },
                    { 465, null, null, null, "C5", 5, 2, null },
                    { 466, null, null, null, "C6", 5, 2, null },
                    { 467, null, null, null, "C7", 5, 2, null },
                    { 468, null, null, null, "C8", 5, 2, null },
                    { 469, null, null, null, "C9", 5, 2, null },
                    { 470, null, null, null, "C10", 5, 2, null },
                    { 471, null, null, null, "D1", 5, 2, null },
                    { 472, null, null, null, "D2", 5, 2, null },
                    { 473, null, null, null, "D3", 5, 2, null },
                    { 474, null, null, null, "D4", 5, 2, null },
                    { 475, null, null, null, "D5", 5, 2, null },
                    { 476, null, null, null, "D6", 5, 2, null },
                    { 477, null, null, null, "D7", 5, 2, null },
                    { 478, null, null, null, "D8", 5, 2, null },
                    { 479, null, null, null, "D9", 5, 2, null },
                    { 480, null, null, null, "D10", 5, 2, null },
                    { 481, null, null, null, "E1", 5, 2, null },
                    { 482, null, null, null, "E2", 5, 2, null },
                    { 483, null, null, null, "E3", 5, 2, null },
                    { 484, null, null, null, "E4", 5, 2, null },
                    { 485, null, null, null, "E5", 5, 2, null },
                    { 486, null, null, null, "E6", 5, 2, null },
                    { 487, null, null, null, "E7", 5, 2, null },
                    { 488, null, null, null, "E8", 5, 2, null },
                    { 489, null, null, null, "E9", 5, 2, null },
                    { 490, null, null, null, "E10", 5, 2, null },
                    { 491, null, null, null, "F1", 5, 2, null },
                    { 492, null, null, null, "F2", 5, 2, null },
                    { 493, null, null, null, "F3", 5, 2, null },
                    { 494, null, null, null, "F4", 5, 2, null },
                    { 495, null, null, null, "F5", 5, 2, null },
                    { 496, null, null, null, "F6", 5, 2, null },
                    { 497, null, null, null, "F7", 5, 2, null },
                    { 498, null, null, null, "F8", 5, 2, null },
                    { 499, null, null, null, "F9", 5, 2, null },
                    { 500, null, null, null, "F10", 5, 2, null },
                    { 501, null, null, null, "G1", 5, 2, null },
                    { 502, null, null, null, "G2", 5, 2, null },
                    { 503, null, null, null, "G3", 5, 2, null },
                    { 504, null, null, null, "G4", 5, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CreateTime", "DeleteTime", "IsActive", "Name", "RoomId", "SeatTypeId", "UpdateTime" },
                values: new object[,]
                {
                    { 505, null, null, null, "G5", 5, 2, null },
                    { 506, null, null, null, "G6", 5, 2, null },
                    { 507, null, null, null, "G7", 5, 2, null },
                    { 508, null, null, null, "G8", 5, 2, null },
                    { 509, null, null, null, "G9", 5, 2, null },
                    { 510, null, null, null, "G10", 5, 2, null },
                    { 511, null, null, null, "H1", 5, 2, null },
                    { 512, null, null, null, "H2", 5, 2, null },
                    { 513, null, null, null, "H3", 5, 2, null },
                    { 514, null, null, null, "H4", 5, 2, null },
                    { 515, null, null, null, "H5", 5, 2, null },
                    { 516, null, null, null, "H6", 5, 2, null },
                    { 517, null, null, null, "H7", 5, 2, null },
                    { 518, null, null, null, "H8", 5, 2, null },
                    { 519, null, null, null, "H9", 5, 2, null },
                    { 520, null, null, null, "H10", 5, 2, null },
                    { 521, null, null, null, "I1", 5, 2, null },
                    { 522, null, null, null, "I2", 5, 2, null },
                    { 523, null, null, null, "I3", 5, 2, null },
                    { 524, null, null, null, "I4", 5, 2, null },
                    { 525, null, null, null, "I5", 5, 2, null },
                    { 526, null, null, null, "I6", 5, 2, null },
                    { 527, null, null, null, "I7", 5, 2, null },
                    { 528, null, null, null, "I8", 5, 2, null },
                    { 529, null, null, null, "I9", 5, 2, null },
                    { 530, null, null, null, "I10", 5, 2, null },
                    { 531, null, null, null, "J1", 5, 2, null },
                    { 532, null, null, null, "J2", 5, 2, null },
                    { 533, null, null, null, "J3", 5, 2, null },
                    { 534, null, null, null, "J4", 5, 2, null },
                    { 535, null, null, null, "J5", 5, 2, null },
                    { 536, null, null, null, "J6", 5, 2, null },
                    { 537, null, null, null, "J7", 5, 2, null },
                    { 538, null, null, null, "J8", 5, 2, null },
                    { 539, null, null, null, "J9", 5, 2, null },
                    { 540, null, null, null, "J10", 5, 2, null },
                    { 541, null, null, null, "K1", 5, 2, null },
                    { 542, null, null, null, "K2", 5, 2, null },
                    { 543, null, null, null, "K3", 5, 2, null },
                    { 544, null, null, null, "K4", 5, 2, null },
                    { 545, null, null, null, "K5", 5, 2, null },
                    { 546, null, null, null, "K6", 5, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CreateTime", "DeleteTime", "IsActive", "Name", "RoomId", "SeatTypeId", "UpdateTime" },
                values: new object[,]
                {
                    { 547, null, null, null, "K7", 5, 2, null },
                    { 548, null, null, null, "K8", 5, 2, null },
                    { 549, null, null, null, "K9", 5, 2, null },
                    { 550, null, null, null, "K10", 5, 2, null },
                    { 551, null, null, null, "L1", 5, 2, null },
                    { 552, null, null, null, "L2", 5, 2, null },
                    { 553, null, null, null, "L3", 5, 2, null },
                    { 554, null, null, null, "L4", 5, 2, null },
                    { 555, null, null, null, "L5", 5, 2, null },
                    { 556, null, null, null, "L6", 5, 2, null },
                    { 557, null, null, null, "L7", 5, 2, null },
                    { 558, null, null, null, "L8", 5, 2, null },
                    { 559, null, null, null, "L9", 5, 2, null },
                    { 560, null, null, null, "L10", 5, 2, null },
                    { 561, null, null, null, "A1", 6, 1, null },
                    { 562, null, null, null, "A2", 6, 1, null },
                    { 563, null, null, null, "A3", 6, 1, null },
                    { 564, null, null, null, "A4", 6, 1, null },
                    { 565, null, null, null, "A5", 6, 1, null },
                    { 566, null, null, null, "A6", 6, 1, null },
                    { 567, null, null, null, "A7", 6, 1, null },
                    { 568, null, null, null, "A8", 6, 1, null },
                    { 569, null, null, null, "A9", 6, 1, null },
                    { 570, null, null, null, "A10", 6, 1, null },
                    { 571, null, null, null, "B1", 6, 1, null },
                    { 572, null, null, null, "B2", 6, 1, null },
                    { 573, null, null, null, "B3", 6, 1, null },
                    { 574, null, null, null, "B4", 6, 1, null },
                    { 575, null, null, null, "B5", 6, 1, null },
                    { 576, null, null, null, "B6", 6, 1, null },
                    { 577, null, null, null, "B7", 6, 1, null },
                    { 578, null, null, null, "B8", 6, 1, null },
                    { 579, null, null, null, "B9", 6, 1, null },
                    { 580, null, null, null, "B10", 6, 1, null },
                    { 581, null, null, null, "C1", 6, 2, null },
                    { 582, null, null, null, "C2", 6, 2, null },
                    { 583, null, null, null, "C3", 6, 2, null },
                    { 584, null, null, null, "C4", 6, 2, null },
                    { 585, null, null, null, "C5", 6, 2, null },
                    { 586, null, null, null, "C6", 6, 2, null },
                    { 587, null, null, null, "C7", 6, 2, null },
                    { 588, null, null, null, "C8", 6, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CreateTime", "DeleteTime", "IsActive", "Name", "RoomId", "SeatTypeId", "UpdateTime" },
                values: new object[,]
                {
                    { 589, null, null, null, "C9", 6, 2, null },
                    { 590, null, null, null, "C10", 6, 2, null },
                    { 591, null, null, null, "D1", 6, 2, null },
                    { 592, null, null, null, "D2", 6, 2, null },
                    { 593, null, null, null, "D3", 6, 2, null },
                    { 594, null, null, null, "D4", 6, 2, null },
                    { 595, null, null, null, "D5", 6, 2, null },
                    { 596, null, null, null, "D6", 6, 2, null },
                    { 597, null, null, null, "D7", 6, 2, null },
                    { 598, null, null, null, "D8", 6, 2, null },
                    { 599, null, null, null, "D9", 6, 2, null },
                    { 600, null, null, null, "D10", 6, 2, null },
                    { 601, null, null, null, "E1", 6, 2, null },
                    { 602, null, null, null, "E2", 6, 2, null },
                    { 603, null, null, null, "E3", 6, 2, null },
                    { 604, null, null, null, "E4", 6, 2, null },
                    { 605, null, null, null, "E5", 6, 2, null },
                    { 606, null, null, null, "E6", 6, 2, null },
                    { 607, null, null, null, "E7", 6, 2, null },
                    { 608, null, null, null, "E8", 6, 2, null },
                    { 609, null, null, null, "E9", 6, 2, null },
                    { 610, null, null, null, "E10", 6, 2, null },
                    { 611, null, null, null, "F1", 6, 2, null },
                    { 612, null, null, null, "F2", 6, 2, null },
                    { 613, null, null, null, "F3", 6, 2, null },
                    { 614, null, null, null, "F4", 6, 2, null },
                    { 615, null, null, null, "F5", 6, 2, null },
                    { 616, null, null, null, "F6", 6, 2, null },
                    { 617, null, null, null, "F7", 6, 2, null },
                    { 618, null, null, null, "F8", 6, 2, null },
                    { 619, null, null, null, "F9", 6, 2, null },
                    { 620, null, null, null, "F10", 6, 2, null },
                    { 621, null, null, null, "G1", 6, 2, null },
                    { 622, null, null, null, "G2", 6, 2, null },
                    { 623, null, null, null, "G3", 6, 2, null },
                    { 624, null, null, null, "G4", 6, 2, null },
                    { 625, null, null, null, "G5", 6, 2, null },
                    { 626, null, null, null, "G6", 6, 2, null },
                    { 627, null, null, null, "G7", 6, 2, null },
                    { 628, null, null, null, "G8", 6, 2, null },
                    { 629, null, null, null, "G9", 6, 2, null },
                    { 630, null, null, null, "G10", 6, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CreateTime", "DeleteTime", "IsActive", "Name", "RoomId", "SeatTypeId", "UpdateTime" },
                values: new object[,]
                {
                    { 631, null, null, null, "H1", 6, 2, null },
                    { 632, null, null, null, "H2", 6, 2, null },
                    { 633, null, null, null, "H3", 6, 2, null },
                    { 634, null, null, null, "H4", 6, 2, null },
                    { 635, null, null, null, "H5", 6, 2, null },
                    { 636, null, null, null, "H6", 6, 2, null },
                    { 637, null, null, null, "H7", 6, 2, null },
                    { 638, null, null, null, "H8", 6, 2, null },
                    { 639, null, null, null, "H9", 6, 2, null },
                    { 640, null, null, null, "H10", 6, 2, null },
                    { 641, null, null, null, "I1", 6, 2, null },
                    { 642, null, null, null, "I2", 6, 2, null },
                    { 643, null, null, null, "I3", 6, 2, null },
                    { 644, null, null, null, "I4", 6, 2, null },
                    { 645, null, null, null, "I5", 6, 2, null },
                    { 646, null, null, null, "I6", 6, 2, null },
                    { 647, null, null, null, "I7", 6, 2, null },
                    { 648, null, null, null, "I8", 6, 2, null },
                    { 649, null, null, null, "I9", 6, 2, null },
                    { 650, null, null, null, "I10", 6, 2, null },
                    { 651, null, null, null, "J1", 6, 2, null },
                    { 652, null, null, null, "J2", 6, 2, null },
                    { 653, null, null, null, "J3", 6, 2, null },
                    { 654, null, null, null, "J4", 6, 2, null },
                    { 655, null, null, null, "J5", 6, 2, null },
                    { 656, null, null, null, "J6", 6, 2, null },
                    { 657, null, null, null, "J7", 6, 2, null },
                    { 658, null, null, null, "J8", 6, 2, null },
                    { 659, null, null, null, "J9", 6, 2, null },
                    { 660, null, null, null, "J10", 6, 2, null },
                    { 661, null, null, null, "K1", 6, 2, null },
                    { 662, null, null, null, "K2", 6, 2, null },
                    { 663, null, null, null, "K3", 6, 2, null },
                    { 664, null, null, null, "K4", 6, 2, null },
                    { 665, null, null, null, "K5", 6, 2, null },
                    { 666, null, null, null, "K6", 6, 2, null },
                    { 667, null, null, null, "K7", 6, 2, null },
                    { 668, null, null, null, "K8", 6, 2, null },
                    { 669, null, null, null, "K9", 6, 2, null },
                    { 670, null, null, null, "K10", 6, 2, null },
                    { 671, null, null, null, "L1", 6, 2, null },
                    { 672, null, null, null, "L2", 6, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CreateTime", "DeleteTime", "IsActive", "Name", "RoomId", "SeatTypeId", "UpdateTime" },
                values: new object[,]
                {
                    { 673, null, null, null, "L3", 6, 2, null },
                    { 674, null, null, null, "L4", 6, 2, null },
                    { 675, null, null, null, "L5", 6, 2, null },
                    { 676, null, null, null, "L6", 6, 2, null },
                    { 677, null, null, null, "L7", 6, 2, null },
                    { 678, null, null, null, "L8", 6, 2, null },
                    { 679, null, null, null, "L9", 6, 2, null },
                    { 680, null, null, null, "L10", 6, 2, null },
                    { 681, null, null, null, "A1", 7, 1, null },
                    { 682, null, null, null, "A2", 7, 1, null },
                    { 683, null, null, null, "A3", 7, 1, null },
                    { 684, null, null, null, "A4", 7, 1, null },
                    { 685, null, null, null, "A5", 7, 1, null },
                    { 686, null, null, null, "A6", 7, 1, null },
                    { 687, null, null, null, "A7", 7, 1, null },
                    { 688, null, null, null, "A8", 7, 1, null },
                    { 689, null, null, null, "A9", 7, 1, null },
                    { 690, null, null, null, "A10", 7, 1, null },
                    { 691, null, null, null, "B1", 7, 1, null },
                    { 692, null, null, null, "B2", 7, 1, null },
                    { 693, null, null, null, "B3", 7, 1, null },
                    { 694, null, null, null, "B4", 7, 1, null },
                    { 695, null, null, null, "B5", 7, 1, null },
                    { 696, null, null, null, "B6", 7, 1, null },
                    { 697, null, null, null, "B7", 7, 1, null },
                    { 698, null, null, null, "B8", 7, 1, null },
                    { 699, null, null, null, "B9", 7, 1, null },
                    { 700, null, null, null, "B10", 7, 1, null },
                    { 701, null, null, null, "C1", 7, 2, null },
                    { 702, null, null, null, "C2", 7, 2, null },
                    { 703, null, null, null, "C3", 7, 2, null },
                    { 704, null, null, null, "C4", 7, 2, null },
                    { 705, null, null, null, "C5", 7, 2, null },
                    { 706, null, null, null, "C6", 7, 2, null },
                    { 707, null, null, null, "C7", 7, 2, null },
                    { 708, null, null, null, "C8", 7, 2, null },
                    { 709, null, null, null, "C9", 7, 2, null },
                    { 710, null, null, null, "C10", 7, 2, null },
                    { 711, null, null, null, "D1", 7, 2, null },
                    { 712, null, null, null, "D2", 7, 2, null },
                    { 713, null, null, null, "D3", 7, 2, null },
                    { 714, null, null, null, "D4", 7, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CreateTime", "DeleteTime", "IsActive", "Name", "RoomId", "SeatTypeId", "UpdateTime" },
                values: new object[,]
                {
                    { 715, null, null, null, "D5", 7, 2, null },
                    { 716, null, null, null, "D6", 7, 2, null },
                    { 717, null, null, null, "D7", 7, 2, null },
                    { 718, null, null, null, "D8", 7, 2, null },
                    { 719, null, null, null, "D9", 7, 2, null },
                    { 720, null, null, null, "D10", 7, 2, null },
                    { 721, null, null, null, "E1", 7, 2, null },
                    { 722, null, null, null, "E2", 7, 2, null },
                    { 723, null, null, null, "E3", 7, 2, null },
                    { 724, null, null, null, "E4", 7, 2, null },
                    { 725, null, null, null, "E5", 7, 2, null },
                    { 726, null, null, null, "E6", 7, 2, null },
                    { 727, null, null, null, "E7", 7, 2, null },
                    { 728, null, null, null, "E8", 7, 2, null },
                    { 729, null, null, null, "E9", 7, 2, null },
                    { 730, null, null, null, "E10", 7, 2, null },
                    { 731, null, null, null, "F1", 7, 2, null },
                    { 732, null, null, null, "F2", 7, 2, null },
                    { 733, null, null, null, "F3", 7, 2, null },
                    { 734, null, null, null, "F4", 7, 2, null },
                    { 735, null, null, null, "F5", 7, 2, null },
                    { 736, null, null, null, "F6", 7, 2, null },
                    { 737, null, null, null, "F7", 7, 2, null },
                    { 738, null, null, null, "F8", 7, 2, null },
                    { 739, null, null, null, "F9", 7, 2, null },
                    { 740, null, null, null, "F10", 7, 2, null },
                    { 741, null, null, null, "G1", 7, 2, null },
                    { 742, null, null, null, "G2", 7, 2, null },
                    { 743, null, null, null, "G3", 7, 2, null },
                    { 744, null, null, null, "G4", 7, 2, null },
                    { 745, null, null, null, "G5", 7, 2, null },
                    { 746, null, null, null, "G6", 7, 2, null },
                    { 747, null, null, null, "G7", 7, 2, null },
                    { 748, null, null, null, "G8", 7, 2, null },
                    { 749, null, null, null, "G9", 7, 2, null },
                    { 750, null, null, null, "G10", 7, 2, null },
                    { 751, null, null, null, "H1", 7, 2, null },
                    { 752, null, null, null, "H2", 7, 2, null },
                    { 753, null, null, null, "H3", 7, 2, null },
                    { 754, null, null, null, "H4", 7, 2, null },
                    { 755, null, null, null, "H5", 7, 2, null },
                    { 756, null, null, null, "H6", 7, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CreateTime", "DeleteTime", "IsActive", "Name", "RoomId", "SeatTypeId", "UpdateTime" },
                values: new object[,]
                {
                    { 757, null, null, null, "H7", 7, 2, null },
                    { 758, null, null, null, "H8", 7, 2, null },
                    { 759, null, null, null, "H9", 7, 2, null },
                    { 760, null, null, null, "H10", 7, 2, null },
                    { 761, null, null, null, "I1", 7, 2, null },
                    { 762, null, null, null, "I2", 7, 2, null },
                    { 763, null, null, null, "I3", 7, 2, null },
                    { 764, null, null, null, "I4", 7, 2, null },
                    { 765, null, null, null, "I5", 7, 2, null },
                    { 766, null, null, null, "I6", 7, 2, null },
                    { 767, null, null, null, "I7", 7, 2, null },
                    { 768, null, null, null, "I8", 7, 2, null },
                    { 769, null, null, null, "I9", 7, 2, null },
                    { 770, null, null, null, "I10", 7, 2, null },
                    { 771, null, null, null, "J1", 7, 2, null },
                    { 772, null, null, null, "J2", 7, 2, null },
                    { 773, null, null, null, "J3", 7, 2, null },
                    { 774, null, null, null, "J4", 7, 2, null },
                    { 775, null, null, null, "J5", 7, 2, null },
                    { 776, null, null, null, "J6", 7, 2, null },
                    { 777, null, null, null, "J7", 7, 2, null },
                    { 778, null, null, null, "J8", 7, 2, null },
                    { 779, null, null, null, "J9", 7, 2, null },
                    { 780, null, null, null, "J10", 7, 2, null },
                    { 781, null, null, null, "K1", 7, 2, null },
                    { 782, null, null, null, "K2", 7, 2, null },
                    { 783, null, null, null, "K3", 7, 2, null },
                    { 784, null, null, null, "K4", 7, 2, null },
                    { 785, null, null, null, "K5", 7, 2, null },
                    { 786, null, null, null, "K6", 7, 2, null },
                    { 787, null, null, null, "K7", 7, 2, null },
                    { 788, null, null, null, "K8", 7, 2, null },
                    { 789, null, null, null, "K9", 7, 2, null },
                    { 790, null, null, null, "K10", 7, 2, null },
                    { 791, null, null, null, "L1", 7, 2, null },
                    { 792, null, null, null, "L2", 7, 2, null },
                    { 793, null, null, null, "L3", 7, 2, null },
                    { 794, null, null, null, "L4", 7, 2, null },
                    { 795, null, null, null, "L5", 7, 2, null },
                    { 796, null, null, null, "L6", 7, 2, null },
                    { 797, null, null, null, "L7", 7, 2, null },
                    { 798, null, null, null, "L8", 7, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CreateTime", "DeleteTime", "IsActive", "Name", "RoomId", "SeatTypeId", "UpdateTime" },
                values: new object[,]
                {
                    { 799, null, null, null, "L9", 7, 2, null },
                    { 800, null, null, null, "L10", 7, 2, null },
                    { 801, null, null, null, "A1", 8, 1, null },
                    { 802, null, null, null, "A2", 8, 1, null },
                    { 803, null, null, null, "A3", 8, 1, null },
                    { 804, null, null, null, "A4", 8, 1, null },
                    { 805, null, null, null, "A5", 8, 1, null },
                    { 806, null, null, null, "A6", 8, 1, null },
                    { 807, null, null, null, "A7", 8, 1, null },
                    { 808, null, null, null, "A8", 8, 1, null },
                    { 809, null, null, null, "A9", 8, 1, null },
                    { 810, null, null, null, "A10", 8, 1, null },
                    { 811, null, null, null, "B1", 8, 1, null },
                    { 812, null, null, null, "B2", 8, 1, null },
                    { 813, null, null, null, "B3", 8, 1, null },
                    { 814, null, null, null, "B4", 8, 1, null },
                    { 815, null, null, null, "B5", 8, 1, null },
                    { 816, null, null, null, "B6", 8, 1, null },
                    { 817, null, null, null, "B7", 8, 1, null },
                    { 818, null, null, null, "B8", 8, 1, null },
                    { 819, null, null, null, "B9", 8, 1, null },
                    { 820, null, null, null, "B10", 8, 1, null },
                    { 821, null, null, null, "C1", 8, 2, null },
                    { 822, null, null, null, "C2", 8, 2, null },
                    { 823, null, null, null, "C3", 8, 2, null },
                    { 824, null, null, null, "C4", 8, 2, null },
                    { 825, null, null, null, "C5", 8, 2, null },
                    { 826, null, null, null, "C6", 8, 2, null },
                    { 827, null, null, null, "C7", 8, 2, null },
                    { 828, null, null, null, "C8", 8, 2, null },
                    { 829, null, null, null, "C9", 8, 2, null },
                    { 830, null, null, null, "C10", 8, 2, null },
                    { 831, null, null, null, "D1", 8, 2, null },
                    { 832, null, null, null, "D2", 8, 2, null },
                    { 833, null, null, null, "D3", 8, 2, null },
                    { 834, null, null, null, "D4", 8, 2, null },
                    { 835, null, null, null, "D5", 8, 2, null },
                    { 836, null, null, null, "D6", 8, 2, null },
                    { 837, null, null, null, "D7", 8, 2, null },
                    { 838, null, null, null, "D8", 8, 2, null },
                    { 839, null, null, null, "D9", 8, 2, null },
                    { 840, null, null, null, "D10", 8, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CreateTime", "DeleteTime", "IsActive", "Name", "RoomId", "SeatTypeId", "UpdateTime" },
                values: new object[,]
                {
                    { 841, null, null, null, "E1", 8, 2, null },
                    { 842, null, null, null, "E2", 8, 2, null },
                    { 843, null, null, null, "E3", 8, 2, null },
                    { 844, null, null, null, "E4", 8, 2, null },
                    { 845, null, null, null, "E5", 8, 2, null },
                    { 846, null, null, null, "E6", 8, 2, null },
                    { 847, null, null, null, "E7", 8, 2, null },
                    { 848, null, null, null, "E8", 8, 2, null },
                    { 849, null, null, null, "E9", 8, 2, null },
                    { 850, null, null, null, "E10", 8, 2, null },
                    { 851, null, null, null, "F1", 8, 2, null },
                    { 852, null, null, null, "F2", 8, 2, null },
                    { 853, null, null, null, "F3", 8, 2, null },
                    { 854, null, null, null, "F4", 8, 2, null },
                    { 855, null, null, null, "F5", 8, 2, null },
                    { 856, null, null, null, "F6", 8, 2, null },
                    { 857, null, null, null, "F7", 8, 2, null },
                    { 858, null, null, null, "F8", 8, 2, null },
                    { 859, null, null, null, "F9", 8, 2, null },
                    { 860, null, null, null, "F10", 8, 2, null },
                    { 861, null, null, null, "G1", 8, 2, null },
                    { 862, null, null, null, "G2", 8, 2, null },
                    { 863, null, null, null, "G3", 8, 2, null },
                    { 864, null, null, null, "G4", 8, 2, null },
                    { 865, null, null, null, "G5", 8, 2, null },
                    { 866, null, null, null, "G6", 8, 2, null },
                    { 867, null, null, null, "G7", 8, 2, null },
                    { 868, null, null, null, "G8", 8, 2, null },
                    { 869, null, null, null, "G9", 8, 2, null },
                    { 870, null, null, null, "G10", 8, 2, null },
                    { 871, null, null, null, "H1", 8, 2, null },
                    { 872, null, null, null, "H2", 8, 2, null },
                    { 873, null, null, null, "H3", 8, 2, null },
                    { 874, null, null, null, "H4", 8, 2, null },
                    { 875, null, null, null, "H5", 8, 2, null },
                    { 876, null, null, null, "H6", 8, 2, null },
                    { 877, null, null, null, "H7", 8, 2, null },
                    { 878, null, null, null, "H8", 8, 2, null },
                    { 879, null, null, null, "H9", 8, 2, null },
                    { 880, null, null, null, "H10", 8, 2, null },
                    { 881, null, null, null, "I1", 8, 2, null },
                    { 882, null, null, null, "I2", 8, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CreateTime", "DeleteTime", "IsActive", "Name", "RoomId", "SeatTypeId", "UpdateTime" },
                values: new object[,]
                {
                    { 883, null, null, null, "I3", 8, 2, null },
                    { 884, null, null, null, "I4", 8, 2, null },
                    { 885, null, null, null, "I5", 8, 2, null },
                    { 886, null, null, null, "I6", 8, 2, null },
                    { 887, null, null, null, "I7", 8, 2, null },
                    { 888, null, null, null, "I8", 8, 2, null },
                    { 889, null, null, null, "I9", 8, 2, null },
                    { 890, null, null, null, "I10", 8, 2, null },
                    { 891, null, null, null, "J1", 8, 2, null },
                    { 892, null, null, null, "J2", 8, 2, null },
                    { 893, null, null, null, "J3", 8, 2, null },
                    { 894, null, null, null, "J4", 8, 2, null },
                    { 895, null, null, null, "J5", 8, 2, null },
                    { 896, null, null, null, "J6", 8, 2, null },
                    { 897, null, null, null, "J7", 8, 2, null },
                    { 898, null, null, null, "J8", 8, 2, null },
                    { 899, null, null, null, "J9", 8, 2, null },
                    { 900, null, null, null, "J10", 8, 2, null },
                    { 901, null, null, null, "K1", 8, 2, null },
                    { 902, null, null, null, "K2", 8, 2, null },
                    { 903, null, null, null, "K3", 8, 2, null },
                    { 904, null, null, null, "K4", 8, 2, null },
                    { 905, null, null, null, "K5", 8, 2, null },
                    { 906, null, null, null, "K6", 8, 2, null },
                    { 907, null, null, null, "K7", 8, 2, null },
                    { 908, null, null, null, "K8", 8, 2, null },
                    { 909, null, null, null, "K9", 8, 2, null },
                    { 910, null, null, null, "K10", 8, 2, null },
                    { 911, null, null, null, "L1", 8, 2, null },
                    { 912, null, null, null, "L2", 8, 2, null },
                    { 913, null, null, null, "L3", 8, 2, null },
                    { 914, null, null, null, "L4", 8, 2, null },
                    { 915, null, null, null, "L5", 8, 2, null },
                    { 916, null, null, null, "L6", 8, 2, null },
                    { 917, null, null, null, "L7", 8, 2, null },
                    { 918, null, null, null, "L8", 8, 2, null },
                    { 919, null, null, null, "L9", 8, 2, null },
                    { 920, null, null, null, "L10", 8, 2, null },
                    { 921, null, null, null, "A1", 9, 1, null },
                    { 922, null, null, null, "A2", 9, 1, null },
                    { 923, null, null, null, "A3", 9, 1, null },
                    { 924, null, null, null, "A4", 9, 1, null }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CreateTime", "DeleteTime", "IsActive", "Name", "RoomId", "SeatTypeId", "UpdateTime" },
                values: new object[,]
                {
                    { 925, null, null, null, "A5", 9, 1, null },
                    { 926, null, null, null, "A6", 9, 1, null },
                    { 927, null, null, null, "A7", 9, 1, null },
                    { 928, null, null, null, "A8", 9, 1, null },
                    { 929, null, null, null, "A9", 9, 1, null },
                    { 930, null, null, null, "A10", 9, 1, null },
                    { 931, null, null, null, "B1", 9, 1, null },
                    { 932, null, null, null, "B2", 9, 1, null },
                    { 933, null, null, null, "B3", 9, 1, null },
                    { 934, null, null, null, "B4", 9, 1, null },
                    { 935, null, null, null, "B5", 9, 1, null },
                    { 936, null, null, null, "B6", 9, 1, null },
                    { 937, null, null, null, "B7", 9, 1, null },
                    { 938, null, null, null, "B8", 9, 1, null },
                    { 939, null, null, null, "B9", 9, 1, null },
                    { 940, null, null, null, "B10", 9, 1, null },
                    { 941, null, null, null, "C1", 9, 2, null },
                    { 942, null, null, null, "C2", 9, 2, null },
                    { 943, null, null, null, "C3", 9, 2, null },
                    { 944, null, null, null, "C4", 9, 2, null },
                    { 945, null, null, null, "C5", 9, 2, null },
                    { 946, null, null, null, "C6", 9, 2, null },
                    { 947, null, null, null, "C7", 9, 2, null },
                    { 948, null, null, null, "C8", 9, 2, null },
                    { 949, null, null, null, "C9", 9, 2, null },
                    { 950, null, null, null, "C10", 9, 2, null },
                    { 951, null, null, null, "D1", 9, 2, null },
                    { 952, null, null, null, "D2", 9, 2, null },
                    { 953, null, null, null, "D3", 9, 2, null },
                    { 954, null, null, null, "D4", 9, 2, null },
                    { 955, null, null, null, "D5", 9, 2, null },
                    { 956, null, null, null, "D6", 9, 2, null },
                    { 957, null, null, null, "D7", 9, 2, null },
                    { 958, null, null, null, "D8", 9, 2, null },
                    { 959, null, null, null, "D9", 9, 2, null },
                    { 960, null, null, null, "D10", 9, 2, null },
                    { 961, null, null, null, "E1", 9, 2, null },
                    { 962, null, null, null, "E2", 9, 2, null },
                    { 963, null, null, null, "E3", 9, 2, null },
                    { 964, null, null, null, "E4", 9, 2, null },
                    { 965, null, null, null, "E5", 9, 2, null },
                    { 966, null, null, null, "E6", 9, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CreateTime", "DeleteTime", "IsActive", "Name", "RoomId", "SeatTypeId", "UpdateTime" },
                values: new object[,]
                {
                    { 967, null, null, null, "E7", 9, 2, null },
                    { 968, null, null, null, "E8", 9, 2, null },
                    { 969, null, null, null, "E9", 9, 2, null },
                    { 970, null, null, null, "E10", 9, 2, null },
                    { 971, null, null, null, "F1", 9, 2, null },
                    { 972, null, null, null, "F2", 9, 2, null },
                    { 973, null, null, null, "F3", 9, 2, null },
                    { 974, null, null, null, "F4", 9, 2, null },
                    { 975, null, null, null, "F5", 9, 2, null },
                    { 976, null, null, null, "F6", 9, 2, null },
                    { 977, null, null, null, "F7", 9, 2, null },
                    { 978, null, null, null, "F8", 9, 2, null },
                    { 979, null, null, null, "F9", 9, 2, null },
                    { 980, null, null, null, "F10", 9, 2, null },
                    { 981, null, null, null, "G1", 9, 2, null },
                    { 982, null, null, null, "G2", 9, 2, null },
                    { 983, null, null, null, "G3", 9, 2, null },
                    { 984, null, null, null, "G4", 9, 2, null },
                    { 985, null, null, null, "G5", 9, 2, null },
                    { 986, null, null, null, "G6", 9, 2, null },
                    { 987, null, null, null, "G7", 9, 2, null },
                    { 988, null, null, null, "G8", 9, 2, null },
                    { 989, null, null, null, "G9", 9, 2, null },
                    { 990, null, null, null, "G10", 9, 2, null },
                    { 991, null, null, null, "H1", 9, 2, null },
                    { 992, null, null, null, "H2", 9, 2, null },
                    { 993, null, null, null, "H3", 9, 2, null },
                    { 994, null, null, null, "H4", 9, 2, null },
                    { 995, null, null, null, "H5", 9, 2, null },
                    { 996, null, null, null, "H6", 9, 2, null },
                    { 997, null, null, null, "H7", 9, 2, null },
                    { 998, null, null, null, "H8", 9, 2, null },
                    { 999, null, null, null, "H9", 9, 2, null },
                    { 1000, null, null, null, "H10", 9, 2, null },
                    { 1001, null, null, null, "I1", 9, 2, null },
                    { 1002, null, null, null, "I2", 9, 2, null },
                    { 1003, null, null, null, "I3", 9, 2, null },
                    { 1004, null, null, null, "I4", 9, 2, null },
                    { 1005, null, null, null, "I5", 9, 2, null },
                    { 1006, null, null, null, "I6", 9, 2, null },
                    { 1007, null, null, null, "I7", 9, 2, null },
                    { 1008, null, null, null, "I8", 9, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CreateTime", "DeleteTime", "IsActive", "Name", "RoomId", "SeatTypeId", "UpdateTime" },
                values: new object[,]
                {
                    { 1009, null, null, null, "I9", 9, 2, null },
                    { 1010, null, null, null, "I10", 9, 2, null },
                    { 1011, null, null, null, "J1", 9, 2, null },
                    { 1012, null, null, null, "J2", 9, 2, null },
                    { 1013, null, null, null, "J3", 9, 2, null },
                    { 1014, null, null, null, "J4", 9, 2, null },
                    { 1015, null, null, null, "J5", 9, 2, null },
                    { 1016, null, null, null, "J6", 9, 2, null },
                    { 1017, null, null, null, "J7", 9, 2, null },
                    { 1018, null, null, null, "J8", 9, 2, null },
                    { 1019, null, null, null, "J9", 9, 2, null },
                    { 1020, null, null, null, "J10", 9, 2, null },
                    { 1021, null, null, null, "K1", 9, 2, null },
                    { 1022, null, null, null, "K2", 9, 2, null },
                    { 1023, null, null, null, "K3", 9, 2, null },
                    { 1024, null, null, null, "K4", 9, 2, null },
                    { 1025, null, null, null, "K5", 9, 2, null },
                    { 1026, null, null, null, "K6", 9, 2, null },
                    { 1027, null, null, null, "K7", 9, 2, null },
                    { 1028, null, null, null, "K8", 9, 2, null },
                    { 1029, null, null, null, "K9", 9, 2, null },
                    { 1030, null, null, null, "K10", 9, 2, null },
                    { 1031, null, null, null, "L1", 9, 2, null },
                    { 1032, null, null, null, "L2", 9, 2, null },
                    { 1033, null, null, null, "L3", 9, 2, null },
                    { 1034, null, null, null, "L4", 9, 2, null },
                    { 1035, null, null, null, "L5", 9, 2, null },
                    { 1036, null, null, null, "L6", 9, 2, null },
                    { 1037, null, null, null, "L7", 9, 2, null },
                    { 1038, null, null, null, "L8", 9, 2, null },
                    { 1039, null, null, null, "L9", 9, 2, null },
                    { 1040, null, null, null, "L10", 9, 2, null },
                    { 1041, null, null, null, "A1", 10, 1, null },
                    { 1042, null, null, null, "A2", 10, 1, null },
                    { 1043, null, null, null, "A3", 10, 1, null },
                    { 1044, null, null, null, "A4", 10, 1, null },
                    { 1045, null, null, null, "A5", 10, 1, null },
                    { 1046, null, null, null, "A6", 10, 1, null },
                    { 1047, null, null, null, "A7", 10, 1, null },
                    { 1048, null, null, null, "A8", 10, 1, null },
                    { 1049, null, null, null, "A9", 10, 1, null },
                    { 1050, null, null, null, "A10", 10, 1, null }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CreateTime", "DeleteTime", "IsActive", "Name", "RoomId", "SeatTypeId", "UpdateTime" },
                values: new object[,]
                {
                    { 1051, null, null, null, "B1", 10, 1, null },
                    { 1052, null, null, null, "B2", 10, 1, null },
                    { 1053, null, null, null, "B3", 10, 1, null },
                    { 1054, null, null, null, "B4", 10, 1, null },
                    { 1055, null, null, null, "B5", 10, 1, null },
                    { 1056, null, null, null, "B6", 10, 1, null },
                    { 1057, null, null, null, "B7", 10, 1, null },
                    { 1058, null, null, null, "B8", 10, 1, null },
                    { 1059, null, null, null, "B9", 10, 1, null },
                    { 1060, null, null, null, "B10", 10, 1, null },
                    { 1061, null, null, null, "C1", 10, 2, null },
                    { 1062, null, null, null, "C2", 10, 2, null },
                    { 1063, null, null, null, "C3", 10, 2, null },
                    { 1064, null, null, null, "C4", 10, 2, null },
                    { 1065, null, null, null, "C5", 10, 2, null },
                    { 1066, null, null, null, "C6", 10, 2, null },
                    { 1067, null, null, null, "C7", 10, 2, null },
                    { 1068, null, null, null, "C8", 10, 2, null },
                    { 1069, null, null, null, "C9", 10, 2, null },
                    { 1070, null, null, null, "C10", 10, 2, null },
                    { 1071, null, null, null, "D1", 10, 2, null },
                    { 1072, null, null, null, "D2", 10, 2, null },
                    { 1073, null, null, null, "D3", 10, 2, null },
                    { 1074, null, null, null, "D4", 10, 2, null },
                    { 1075, null, null, null, "D5", 10, 2, null },
                    { 1076, null, null, null, "D6", 10, 2, null },
                    { 1077, null, null, null, "D7", 10, 2, null },
                    { 1078, null, null, null, "D8", 10, 2, null },
                    { 1079, null, null, null, "D9", 10, 2, null },
                    { 1080, null, null, null, "D10", 10, 2, null },
                    { 1081, null, null, null, "E1", 10, 2, null },
                    { 1082, null, null, null, "E2", 10, 2, null },
                    { 1083, null, null, null, "E3", 10, 2, null },
                    { 1084, null, null, null, "E4", 10, 2, null },
                    { 1085, null, null, null, "E5", 10, 2, null },
                    { 1086, null, null, null, "E6", 10, 2, null },
                    { 1087, null, null, null, "E7", 10, 2, null },
                    { 1088, null, null, null, "E8", 10, 2, null },
                    { 1089, null, null, null, "E9", 10, 2, null },
                    { 1090, null, null, null, "E10", 10, 2, null },
                    { 1091, null, null, null, "F1", 10, 2, null },
                    { 1092, null, null, null, "F2", 10, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CreateTime", "DeleteTime", "IsActive", "Name", "RoomId", "SeatTypeId", "UpdateTime" },
                values: new object[,]
                {
                    { 1093, null, null, null, "F3", 10, 2, null },
                    { 1094, null, null, null, "F4", 10, 2, null },
                    { 1095, null, null, null, "F5", 10, 2, null },
                    { 1096, null, null, null, "F6", 10, 2, null },
                    { 1097, null, null, null, "F7", 10, 2, null },
                    { 1098, null, null, null, "F8", 10, 2, null },
                    { 1099, null, null, null, "F9", 10, 2, null },
                    { 1100, null, null, null, "F10", 10, 2, null },
                    { 1101, null, null, null, "G1", 10, 2, null },
                    { 1102, null, null, null, "G2", 10, 2, null },
                    { 1103, null, null, null, "G3", 10, 2, null },
                    { 1104, null, null, null, "G4", 10, 2, null },
                    { 1105, null, null, null, "G5", 10, 2, null },
                    { 1106, null, null, null, "G6", 10, 2, null },
                    { 1107, null, null, null, "G7", 10, 2, null },
                    { 1108, null, null, null, "G8", 10, 2, null },
                    { 1109, null, null, null, "G9", 10, 2, null },
                    { 1110, null, null, null, "G10", 10, 2, null },
                    { 1111, null, null, null, "H1", 10, 2, null },
                    { 1112, null, null, null, "H2", 10, 2, null },
                    { 1113, null, null, null, "H3", 10, 2, null },
                    { 1114, null, null, null, "H4", 10, 2, null },
                    { 1115, null, null, null, "H5", 10, 2, null },
                    { 1116, null, null, null, "H6", 10, 2, null },
                    { 1117, null, null, null, "H7", 10, 2, null },
                    { 1118, null, null, null, "H8", 10, 2, null },
                    { 1119, null, null, null, "H9", 10, 2, null },
                    { 1120, null, null, null, "H10", 10, 2, null },
                    { 1121, null, null, null, "A1", 11, 1, null },
                    { 1122, null, null, null, "A2", 11, 1, null },
                    { 1123, null, null, null, "A3", 11, 1, null },
                    { 1124, null, null, null, "A4", 11, 1, null },
                    { 1125, null, null, null, "A5", 11, 1, null },
                    { 1126, null, null, null, "A6", 11, 1, null },
                    { 1127, null, null, null, "A7", 11, 1, null },
                    { 1128, null, null, null, "A8", 11, 1, null },
                    { 1129, null, null, null, "A9", 11, 1, null },
                    { 1130, null, null, null, "A10", 11, 1, null },
                    { 1131, null, null, null, "B1", 11, 1, null },
                    { 1132, null, null, null, "B2", 11, 1, null },
                    { 1133, null, null, null, "B3", 11, 1, null },
                    { 1134, null, null, null, "B4", 11, 1, null }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CreateTime", "DeleteTime", "IsActive", "Name", "RoomId", "SeatTypeId", "UpdateTime" },
                values: new object[,]
                {
                    { 1135, null, null, null, "B5", 11, 1, null },
                    { 1136, null, null, null, "B6", 11, 1, null },
                    { 1137, null, null, null, "B7", 11, 1, null },
                    { 1138, null, null, null, "B8", 11, 1, null },
                    { 1139, null, null, null, "B9", 11, 1, null },
                    { 1140, null, null, null, "B10", 11, 1, null },
                    { 1141, null, null, null, "C1", 11, 2, null },
                    { 1142, null, null, null, "C2", 11, 2, null },
                    { 1143, null, null, null, "C3", 11, 2, null },
                    { 1144, null, null, null, "C4", 11, 2, null },
                    { 1145, null, null, null, "C5", 11, 2, null },
                    { 1146, null, null, null, "C6", 11, 2, null },
                    { 1147, null, null, null, "C7", 11, 2, null },
                    { 1148, null, null, null, "C8", 11, 2, null },
                    { 1149, null, null, null, "C9", 11, 2, null },
                    { 1150, null, null, null, "C10", 11, 2, null },
                    { 1151, null, null, null, "D1", 11, 2, null },
                    { 1152, null, null, null, "D2", 11, 2, null },
                    { 1153, null, null, null, "D3", 11, 2, null },
                    { 1154, null, null, null, "D4", 11, 2, null },
                    { 1155, null, null, null, "D5", 11, 2, null },
                    { 1156, null, null, null, "D6", 11, 2, null },
                    { 1157, null, null, null, "D7", 11, 2, null },
                    { 1158, null, null, null, "D8", 11, 2, null },
                    { 1159, null, null, null, "D9", 11, 2, null },
                    { 1160, null, null, null, "D10", 11, 2, null },
                    { 1161, null, null, null, "E1", 11, 2, null },
                    { 1162, null, null, null, "E2", 11, 2, null },
                    { 1163, null, null, null, "E3", 11, 2, null },
                    { 1164, null, null, null, "E4", 11, 2, null },
                    { 1165, null, null, null, "E5", 11, 2, null },
                    { 1166, null, null, null, "E6", 11, 2, null },
                    { 1167, null, null, null, "E7", 11, 2, null },
                    { 1168, null, null, null, "E8", 11, 2, null },
                    { 1169, null, null, null, "E9", 11, 2, null },
                    { 1170, null, null, null, "E10", 11, 2, null },
                    { 1171, null, null, null, "F1", 11, 2, null },
                    { 1172, null, null, null, "F2", 11, 2, null },
                    { 1173, null, null, null, "F3", 11, 2, null },
                    { 1174, null, null, null, "F4", 11, 2, null },
                    { 1175, null, null, null, "F5", 11, 2, null },
                    { 1176, null, null, null, "F6", 11, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CreateTime", "DeleteTime", "IsActive", "Name", "RoomId", "SeatTypeId", "UpdateTime" },
                values: new object[,]
                {
                    { 1177, null, null, null, "F7", 11, 2, null },
                    { 1178, null, null, null, "F8", 11, 2, null },
                    { 1179, null, null, null, "F9", 11, 2, null },
                    { 1180, null, null, null, "F10", 11, 2, null },
                    { 1181, null, null, null, "G1", 11, 2, null },
                    { 1182, null, null, null, "G2", 11, 2, null },
                    { 1183, null, null, null, "G3", 11, 2, null },
                    { 1184, null, null, null, "G4", 11, 2, null },
                    { 1185, null, null, null, "G5", 11, 2, null },
                    { 1186, null, null, null, "G6", 11, 2, null },
                    { 1187, null, null, null, "G7", 11, 2, null },
                    { 1188, null, null, null, "G8", 11, 2, null },
                    { 1189, null, null, null, "G9", 11, 2, null },
                    { 1190, null, null, null, "G10", 11, 2, null },
                    { 1191, null, null, null, "H1", 11, 2, null },
                    { 1192, null, null, null, "H2", 11, 2, null },
                    { 1193, null, null, null, "H3", 11, 2, null },
                    { 1194, null, null, null, "H4", 11, 2, null },
                    { 1195, null, null, null, "H5", 11, 2, null },
                    { 1196, null, null, null, "H6", 11, 2, null },
                    { 1197, null, null, null, "H7", 11, 2, null },
                    { 1198, null, null, null, "H8", 11, 2, null },
                    { 1199, null, null, null, "H9", 11, 2, null },
                    { 1200, null, null, null, "H10", 11, 2, null },
                    { 1201, null, null, null, "A1", 12, 1, null },
                    { 1202, null, null, null, "A2", 12, 1, null },
                    { 1203, null, null, null, "A3", 12, 1, null },
                    { 1204, null, null, null, "A4", 12, 1, null },
                    { 1205, null, null, null, "A5", 12, 1, null },
                    { 1206, null, null, null, "A6", 12, 1, null },
                    { 1207, null, null, null, "A7", 12, 1, null },
                    { 1208, null, null, null, "A8", 12, 1, null },
                    { 1209, null, null, null, "A9", 12, 1, null },
                    { 1210, null, null, null, "A10", 12, 1, null },
                    { 1211, null, null, null, "B1", 12, 1, null },
                    { 1212, null, null, null, "B2", 12, 1, null },
                    { 1213, null, null, null, "B3", 12, 1, null },
                    { 1214, null, null, null, "B4", 12, 1, null },
                    { 1215, null, null, null, "B5", 12, 1, null },
                    { 1216, null, null, null, "B6", 12, 1, null },
                    { 1217, null, null, null, "B7", 12, 1, null },
                    { 1218, null, null, null, "B8", 12, 1, null }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CreateTime", "DeleteTime", "IsActive", "Name", "RoomId", "SeatTypeId", "UpdateTime" },
                values: new object[,]
                {
                    { 1219, null, null, null, "B9", 12, 1, null },
                    { 1220, null, null, null, "B10", 12, 1, null },
                    { 1221, null, null, null, "C1", 12, 2, null },
                    { 1222, null, null, null, "C2", 12, 2, null },
                    { 1223, null, null, null, "C3", 12, 2, null },
                    { 1224, null, null, null, "C4", 12, 2, null },
                    { 1225, null, null, null, "C5", 12, 2, null },
                    { 1226, null, null, null, "C6", 12, 2, null },
                    { 1227, null, null, null, "C7", 12, 2, null },
                    { 1228, null, null, null, "C8", 12, 2, null },
                    { 1229, null, null, null, "C9", 12, 2, null },
                    { 1230, null, null, null, "C10", 12, 2, null },
                    { 1231, null, null, null, "D1", 12, 2, null },
                    { 1232, null, null, null, "D2", 12, 2, null },
                    { 1233, null, null, null, "D3", 12, 2, null },
                    { 1234, null, null, null, "D4", 12, 2, null },
                    { 1235, null, null, null, "D5", 12, 2, null },
                    { 1236, null, null, null, "D6", 12, 2, null },
                    { 1237, null, null, null, "D7", 12, 2, null },
                    { 1238, null, null, null, "D8", 12, 2, null },
                    { 1239, null, null, null, "D9", 12, 2, null },
                    { 1240, null, null, null, "D10", 12, 2, null },
                    { 1241, null, null, null, "E1", 12, 2, null },
                    { 1242, null, null, null, "E2", 12, 2, null },
                    { 1243, null, null, null, "E3", 12, 2, null },
                    { 1244, null, null, null, "E4", 12, 2, null },
                    { 1245, null, null, null, "E5", 12, 2, null },
                    { 1246, null, null, null, "E6", 12, 2, null },
                    { 1247, null, null, null, "E7", 12, 2, null },
                    { 1248, null, null, null, "E8", 12, 2, null },
                    { 1249, null, null, null, "E9", 12, 2, null },
                    { 1250, null, null, null, "E10", 12, 2, null },
                    { 1251, null, null, null, "F1", 12, 2, null },
                    { 1252, null, null, null, "F2", 12, 2, null },
                    { 1253, null, null, null, "F3", 12, 2, null },
                    { 1254, null, null, null, "F4", 12, 2, null },
                    { 1255, null, null, null, "F5", 12, 2, null },
                    { 1256, null, null, null, "F6", 12, 2, null },
                    { 1257, null, null, null, "F7", 12, 2, null },
                    { 1258, null, null, null, "F8", 12, 2, null },
                    { 1259, null, null, null, "F9", 12, 2, null },
                    { 1260, null, null, null, "F10", 12, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CreateTime", "DeleteTime", "IsActive", "Name", "RoomId", "SeatTypeId", "UpdateTime" },
                values: new object[,]
                {
                    { 1261, null, null, null, "G1", 12, 2, null },
                    { 1262, null, null, null, "G2", 12, 2, null },
                    { 1263, null, null, null, "G3", 12, 2, null },
                    { 1264, null, null, null, "G4", 12, 2, null },
                    { 1265, null, null, null, "G5", 12, 2, null },
                    { 1266, null, null, null, "G6", 12, 2, null },
                    { 1267, null, null, null, "G7", 12, 2, null },
                    { 1268, null, null, null, "G8", 12, 2, null },
                    { 1269, null, null, null, "G9", 12, 2, null },
                    { 1270, null, null, null, "G10", 12, 2, null },
                    { 1271, null, null, null, "H1", 12, 2, null },
                    { 1272, null, null, null, "H2", 12, 2, null },
                    { 1273, null, null, null, "H3", 12, 2, null },
                    { 1274, null, null, null, "H4", 12, 2, null },
                    { 1275, null, null, null, "H5", 12, 2, null },
                    { 1276, null, null, null, "H6", 12, 2, null },
                    { 1277, null, null, null, "H7", 12, 2, null },
                    { 1278, null, null, null, "H8", 12, 2, null },
                    { 1279, null, null, null, "H9", 12, 2, null },
                    { 1280, null, null, null, "H10", 12, 2, null },
                    { 1281, null, null, null, "A1", 13, 1, null },
                    { 1282, null, null, null, "A2", 13, 1, null },
                    { 1283, null, null, null, "A3", 13, 1, null },
                    { 1284, null, null, null, "A4", 13, 1, null },
                    { 1285, null, null, null, "A5", 13, 1, null },
                    { 1286, null, null, null, "A6", 13, 1, null },
                    { 1287, null, null, null, "A7", 13, 1, null },
                    { 1288, null, null, null, "A8", 13, 1, null },
                    { 1289, null, null, null, "A9", 13, 1, null },
                    { 1290, null, null, null, "A10", 13, 1, null },
                    { 1291, null, null, null, "B1", 13, 1, null },
                    { 1292, null, null, null, "B2", 13, 1, null },
                    { 1293, null, null, null, "B3", 13, 1, null },
                    { 1294, null, null, null, "B4", 13, 1, null },
                    { 1295, null, null, null, "B5", 13, 1, null },
                    { 1296, null, null, null, "B6", 13, 1, null },
                    { 1297, null, null, null, "B7", 13, 1, null },
                    { 1298, null, null, null, "B8", 13, 1, null },
                    { 1299, null, null, null, "B9", 13, 1, null },
                    { 1300, null, null, null, "B10", 13, 1, null },
                    { 1301, null, null, null, "C1", 13, 2, null },
                    { 1302, null, null, null, "C2", 13, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CreateTime", "DeleteTime", "IsActive", "Name", "RoomId", "SeatTypeId", "UpdateTime" },
                values: new object[,]
                {
                    { 1303, null, null, null, "C3", 13, 2, null },
                    { 1304, null, null, null, "C4", 13, 2, null },
                    { 1305, null, null, null, "C5", 13, 2, null },
                    { 1306, null, null, null, "C6", 13, 2, null },
                    { 1307, null, null, null, "C7", 13, 2, null },
                    { 1308, null, null, null, "C8", 13, 2, null },
                    { 1309, null, null, null, "C9", 13, 2, null },
                    { 1310, null, null, null, "C10", 13, 2, null },
                    { 1311, null, null, null, "D1", 13, 2, null },
                    { 1312, null, null, null, "D2", 13, 2, null },
                    { 1313, null, null, null, "D3", 13, 2, null },
                    { 1314, null, null, null, "D4", 13, 2, null },
                    { 1315, null, null, null, "D5", 13, 2, null },
                    { 1316, null, null, null, "D6", 13, 2, null },
                    { 1317, null, null, null, "D7", 13, 2, null },
                    { 1318, null, null, null, "D8", 13, 2, null },
                    { 1319, null, null, null, "D9", 13, 2, null },
                    { 1320, null, null, null, "D10", 13, 2, null },
                    { 1321, null, null, null, "E1", 13, 2, null },
                    { 1322, null, null, null, "E2", 13, 2, null },
                    { 1323, null, null, null, "E3", 13, 2, null },
                    { 1324, null, null, null, "E4", 13, 2, null },
                    { 1325, null, null, null, "E5", 13, 2, null },
                    { 1326, null, null, null, "E6", 13, 2, null },
                    { 1327, null, null, null, "E7", 13, 2, null },
                    { 1328, null, null, null, "E8", 13, 2, null },
                    { 1329, null, null, null, "E9", 13, 2, null },
                    { 1330, null, null, null, "E10", 13, 2, null },
                    { 1331, null, null, null, "F1", 13, 2, null },
                    { 1332, null, null, null, "F2", 13, 2, null },
                    { 1333, null, null, null, "F3", 13, 2, null },
                    { 1334, null, null, null, "F4", 13, 2, null },
                    { 1335, null, null, null, "F5", 13, 2, null },
                    { 1336, null, null, null, "F6", 13, 2, null },
                    { 1337, null, null, null, "F7", 13, 2, null },
                    { 1338, null, null, null, "F8", 13, 2, null },
                    { 1339, null, null, null, "F9", 13, 2, null },
                    { 1340, null, null, null, "F10", 13, 2, null },
                    { 1341, null, null, null, "G1", 13, 2, null },
                    { 1342, null, null, null, "G2", 13, 2, null },
                    { 1343, null, null, null, "G3", 13, 2, null },
                    { 1344, null, null, null, "G4", 13, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CreateTime", "DeleteTime", "IsActive", "Name", "RoomId", "SeatTypeId", "UpdateTime" },
                values: new object[,]
                {
                    { 1345, null, null, null, "G5", 13, 2, null },
                    { 1346, null, null, null, "G6", 13, 2, null },
                    { 1347, null, null, null, "G7", 13, 2, null },
                    { 1348, null, null, null, "G8", 13, 2, null },
                    { 1349, null, null, null, "G9", 13, 2, null },
                    { 1350, null, null, null, "G10", 13, 2, null },
                    { 1351, null, null, null, "H1", 13, 2, null },
                    { 1352, null, null, null, "H2", 13, 2, null },
                    { 1353, null, null, null, "H3", 13, 2, null },
                    { 1354, null, null, null, "H4", 13, 2, null },
                    { 1355, null, null, null, "H5", 13, 2, null },
                    { 1356, null, null, null, "H6", 13, 2, null },
                    { 1357, null, null, null, "H7", 13, 2, null },
                    { 1358, null, null, null, "H8", 13, 2, null },
                    { 1359, null, null, null, "H9", 13, 2, null },
                    { 1360, null, null, null, "H10", 13, 2, null },
                    { 1361, null, null, null, "A1", 14, 1, null },
                    { 1362, null, null, null, "A2", 14, 1, null },
                    { 1363, null, null, null, "A3", 14, 1, null },
                    { 1364, null, null, null, "A4", 14, 1, null },
                    { 1365, null, null, null, "A5", 14, 1, null },
                    { 1366, null, null, null, "A6", 14, 1, null },
                    { 1367, null, null, null, "A7", 14, 1, null },
                    { 1368, null, null, null, "A8", 14, 1, null },
                    { 1369, null, null, null, "B1", 14, 1, null },
                    { 1370, null, null, null, "B2", 14, 1, null },
                    { 1371, null, null, null, "B3", 14, 1, null },
                    { 1372, null, null, null, "B4", 14, 1, null },
                    { 1373, null, null, null, "B5", 14, 1, null },
                    { 1374, null, null, null, "B6", 14, 1, null },
                    { 1375, null, null, null, "B7", 14, 1, null },
                    { 1376, null, null, null, "B8", 14, 1, null },
                    { 1377, null, null, null, "C1", 14, 2, null },
                    { 1378, null, null, null, "C2", 14, 2, null },
                    { 1379, null, null, null, "C3", 14, 2, null },
                    { 1380, null, null, null, "C4", 14, 2, null },
                    { 1381, null, null, null, "C5", 14, 2, null },
                    { 1382, null, null, null, "C6", 14, 2, null },
                    { 1383, null, null, null, "C7", 14, 2, null },
                    { 1384, null, null, null, "C8", 14, 2, null },
                    { 1385, null, null, null, "D1", 14, 2, null },
                    { 1386, null, null, null, "D2", 14, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CreateTime", "DeleteTime", "IsActive", "Name", "RoomId", "SeatTypeId", "UpdateTime" },
                values: new object[,]
                {
                    { 1387, null, null, null, "D3", 14, 2, null },
                    { 1388, null, null, null, "D4", 14, 2, null },
                    { 1389, null, null, null, "D5", 14, 2, null },
                    { 1390, null, null, null, "D6", 14, 2, null },
                    { 1391, null, null, null, "D7", 14, 2, null },
                    { 1392, null, null, null, "D8", 14, 2, null },
                    { 1393, null, null, null, "E1", 14, 2, null },
                    { 1394, null, null, null, "E2", 14, 2, null },
                    { 1395, null, null, null, "E3", 14, 2, null },
                    { 1396, null, null, null, "E4", 14, 2, null },
                    { 1397, null, null, null, "E5", 14, 2, null },
                    { 1398, null, null, null, "E6", 14, 2, null },
                    { 1399, null, null, null, "E7", 14, 2, null },
                    { 1400, null, null, null, "E8", 14, 2, null },
                    { 1401, null, null, null, "F1", 14, 2, null },
                    { 1402, null, null, null, "F2", 14, 2, null },
                    { 1403, null, null, null, "F3", 14, 2, null },
                    { 1404, null, null, null, "F4", 14, 2, null },
                    { 1405, null, null, null, "F5", 14, 2, null },
                    { 1406, null, null, null, "F6", 14, 2, null },
                    { 1407, null, null, null, "F7", 14, 2, null },
                    { 1408, null, null, null, "F8", 14, 2, null },
                    { 1409, null, null, null, "G1", 14, 2, null },
                    { 1410, null, null, null, "G2", 14, 2, null },
                    { 1411, null, null, null, "G3", 14, 2, null },
                    { 1412, null, null, null, "G4", 14, 2, null },
                    { 1413, null, null, null, "G5", 14, 2, null },
                    { 1414, null, null, null, "G6", 14, 2, null },
                    { 1415, null, null, null, "G7", 14, 2, null },
                    { 1416, null, null, null, "G8", 14, 2, null },
                    { 1417, null, null, null, "H1", 14, 2, null },
                    { 1418, null, null, null, "H2", 14, 2, null },
                    { 1419, null, null, null, "H3", 14, 2, null },
                    { 1420, null, null, null, "H4", 14, 2, null },
                    { 1421, null, null, null, "H5", 14, 2, null },
                    { 1422, null, null, null, "H6", 14, 2, null },
                    { 1423, null, null, null, "H7", 14, 2, null },
                    { 1424, null, null, null, "H8", 14, 2, null },
                    { 1425, null, null, null, "A1", 15, 1, null },
                    { 1426, null, null, null, "A2", 15, 1, null },
                    { 1427, null, null, null, "A3", 15, 1, null },
                    { 1428, null, null, null, "A4", 15, 1, null }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CreateTime", "DeleteTime", "IsActive", "Name", "RoomId", "SeatTypeId", "UpdateTime" },
                values: new object[,]
                {
                    { 1429, null, null, null, "A5", 15, 1, null },
                    { 1430, null, null, null, "A6", 15, 1, null },
                    { 1431, null, null, null, "A7", 15, 1, null },
                    { 1432, null, null, null, "A8", 15, 1, null },
                    { 1433, null, null, null, "B1", 15, 1, null },
                    { 1434, null, null, null, "B2", 15, 1, null },
                    { 1435, null, null, null, "B3", 15, 1, null },
                    { 1436, null, null, null, "B4", 15, 1, null },
                    { 1437, null, null, null, "B5", 15, 1, null },
                    { 1438, null, null, null, "B6", 15, 1, null },
                    { 1439, null, null, null, "B7", 15, 1, null },
                    { 1440, null, null, null, "B8", 15, 1, null },
                    { 1441, null, null, null, "C1", 15, 2, null },
                    { 1442, null, null, null, "C2", 15, 2, null },
                    { 1443, null, null, null, "C3", 15, 2, null },
                    { 1444, null, null, null, "C4", 15, 2, null },
                    { 1445, null, null, null, "C5", 15, 2, null },
                    { 1446, null, null, null, "C6", 15, 2, null },
                    { 1447, null, null, null, "C7", 15, 2, null },
                    { 1448, null, null, null, "C8", 15, 2, null },
                    { 1449, null, null, null, "D1", 15, 2, null },
                    { 1450, null, null, null, "D2", 15, 2, null },
                    { 1451, null, null, null, "D3", 15, 2, null },
                    { 1452, null, null, null, "D4", 15, 2, null },
                    { 1453, null, null, null, "D5", 15, 2, null },
                    { 1454, null, null, null, "D6", 15, 2, null },
                    { 1455, null, null, null, "D7", 15, 2, null },
                    { 1456, null, null, null, "D8", 15, 2, null },
                    { 1457, null, null, null, "E1", 15, 2, null },
                    { 1458, null, null, null, "E2", 15, 2, null },
                    { 1459, null, null, null, "E3", 15, 2, null },
                    { 1460, null, null, null, "E4", 15, 2, null },
                    { 1461, null, null, null, "E5", 15, 2, null },
                    { 1462, null, null, null, "E6", 15, 2, null },
                    { 1463, null, null, null, "E7", 15, 2, null },
                    { 1464, null, null, null, "E8", 15, 2, null },
                    { 1465, null, null, null, "F1", 15, 2, null },
                    { 1466, null, null, null, "F2", 15, 2, null },
                    { 1467, null, null, null, "F3", 15, 2, null },
                    { 1468, null, null, null, "F4", 15, 2, null },
                    { 1469, null, null, null, "F5", 15, 2, null },
                    { 1470, null, null, null, "F6", 15, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CreateTime", "DeleteTime", "IsActive", "Name", "RoomId", "SeatTypeId", "UpdateTime" },
                values: new object[,]
                {
                    { 1471, null, null, null, "F7", 15, 2, null },
                    { 1472, null, null, null, "F8", 15, 2, null },
                    { 1473, null, null, null, "G1", 15, 2, null },
                    { 1474, null, null, null, "G2", 15, 2, null },
                    { 1475, null, null, null, "G3", 15, 2, null },
                    { 1476, null, null, null, "G4", 15, 2, null },
                    { 1477, null, null, null, "G5", 15, 2, null },
                    { 1478, null, null, null, "G6", 15, 2, null },
                    { 1479, null, null, null, "G7", 15, 2, null },
                    { 1480, null, null, null, "G8", 15, 2, null },
                    { 1481, null, null, null, "H1", 15, 2, null },
                    { 1482, null, null, null, "H2", 15, 2, null },
                    { 1483, null, null, null, "H3", 15, 2, null },
                    { 1484, null, null, null, "H4", 15, 2, null },
                    { 1485, null, null, null, "H5", 15, 2, null },
                    { 1486, null, null, null, "H6", 15, 2, null },
                    { 1487, null, null, null, "H7", 15, 2, null },
                    { 1488, null, null, null, "H8", 15, 2, null },
                    { 1489, null, null, null, "A1", 16, 1, null },
                    { 1490, null, null, null, "A2", 16, 1, null },
                    { 1491, null, null, null, "A3", 16, 1, null },
                    { 1492, null, null, null, "A4", 16, 1, null },
                    { 1493, null, null, null, "A5", 16, 1, null },
                    { 1494, null, null, null, "A6", 16, 1, null },
                    { 1495, null, null, null, "A7", 16, 1, null },
                    { 1496, null, null, null, "A8", 16, 1, null },
                    { 1497, null, null, null, "B1", 16, 1, null },
                    { 1498, null, null, null, "B2", 16, 1, null },
                    { 1499, null, null, null, "B3", 16, 1, null },
                    { 1500, null, null, null, "B4", 16, 1, null },
                    { 1501, null, null, null, "B5", 16, 1, null },
                    { 1502, null, null, null, "B6", 16, 1, null },
                    { 1503, null, null, null, "B7", 16, 1, null },
                    { 1504, null, null, null, "B8", 16, 1, null },
                    { 1505, null, null, null, "C1", 16, 2, null },
                    { 1506, null, null, null, "C2", 16, 2, null },
                    { 1507, null, null, null, "C3", 16, 2, null },
                    { 1508, null, null, null, "C4", 16, 2, null },
                    { 1509, null, null, null, "C5", 16, 2, null },
                    { 1510, null, null, null, "C6", 16, 2, null },
                    { 1511, null, null, null, "C7", 16, 2, null },
                    { 1512, null, null, null, "C8", 16, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CreateTime", "DeleteTime", "IsActive", "Name", "RoomId", "SeatTypeId", "UpdateTime" },
                values: new object[,]
                {
                    { 1513, null, null, null, "D1", 16, 2, null },
                    { 1514, null, null, null, "D2", 16, 2, null },
                    { 1515, null, null, null, "D3", 16, 2, null },
                    { 1516, null, null, null, "D4", 16, 2, null },
                    { 1517, null, null, null, "D5", 16, 2, null },
                    { 1518, null, null, null, "D6", 16, 2, null },
                    { 1519, null, null, null, "D7", 16, 2, null },
                    { 1520, null, null, null, "D8", 16, 2, null },
                    { 1521, null, null, null, "E1", 16, 2, null },
                    { 1522, null, null, null, "E2", 16, 2, null },
                    { 1523, null, null, null, "E3", 16, 2, null },
                    { 1524, null, null, null, "E4", 16, 2, null },
                    { 1525, null, null, null, "E5", 16, 2, null },
                    { 1526, null, null, null, "E6", 16, 2, null },
                    { 1527, null, null, null, "E7", 16, 2, null },
                    { 1528, null, null, null, "E8", 16, 2, null },
                    { 1529, null, null, null, "F1", 16, 2, null },
                    { 1530, null, null, null, "F2", 16, 2, null },
                    { 1531, null, null, null, "F3", 16, 2, null },
                    { 1532, null, null, null, "F4", 16, 2, null },
                    { 1533, null, null, null, "F5", 16, 2, null },
                    { 1534, null, null, null, "F6", 16, 2, null },
                    { 1535, null, null, null, "F7", 16, 2, null },
                    { 1536, null, null, null, "F8", 16, 2, null },
                    { 1537, null, null, null, "G1", 16, 2, null },
                    { 1538, null, null, null, "G2", 16, 2, null },
                    { 1539, null, null, null, "G3", 16, 2, null },
                    { 1540, null, null, null, "G4", 16, 2, null },
                    { 1541, null, null, null, "G5", 16, 2, null },
                    { 1542, null, null, null, "G6", 16, 2, null },
                    { 1543, null, null, null, "G7", 16, 2, null },
                    { 1544, null, null, null, "G8", 16, 2, null },
                    { 1545, null, null, null, "H1", 16, 2, null },
                    { 1546, null, null, null, "H2", 16, 2, null },
                    { 1547, null, null, null, "H3", 16, 2, null },
                    { 1548, null, null, null, "H4", 16, 2, null },
                    { 1549, null, null, null, "H5", 16, 2, null },
                    { 1550, null, null, null, "H6", 16, 2, null },
                    { 1551, null, null, null, "H7", 16, 2, null },
                    { 1552, null, null, null, "H8", 16, 2, null },
                    { 1553, null, null, null, "A1", 17, 1, null },
                    { 1554, null, null, null, "A2", 17, 1, null }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CreateTime", "DeleteTime", "IsActive", "Name", "RoomId", "SeatTypeId", "UpdateTime" },
                values: new object[,]
                {
                    { 1555, null, null, null, "A3", 17, 1, null },
                    { 1556, null, null, null, "A4", 17, 1, null },
                    { 1557, null, null, null, "A5", 17, 1, null },
                    { 1558, null, null, null, "A6", 17, 1, null },
                    { 1559, null, null, null, "A7", 17, 1, null },
                    { 1560, null, null, null, "A8", 17, 1, null },
                    { 1561, null, null, null, "B1", 17, 1, null },
                    { 1562, null, null, null, "B2", 17, 1, null },
                    { 1563, null, null, null, "B3", 17, 1, null },
                    { 1564, null, null, null, "B4", 17, 1, null },
                    { 1565, null, null, null, "B5", 17, 1, null },
                    { 1566, null, null, null, "B6", 17, 1, null },
                    { 1567, null, null, null, "B7", 17, 1, null },
                    { 1568, null, null, null, "B8", 17, 1, null },
                    { 1569, null, null, null, "C1", 17, 2, null },
                    { 1570, null, null, null, "C2", 17, 2, null },
                    { 1571, null, null, null, "C3", 17, 2, null },
                    { 1572, null, null, null, "C4", 17, 2, null },
                    { 1573, null, null, null, "C5", 17, 2, null },
                    { 1574, null, null, null, "C6", 17, 2, null },
                    { 1575, null, null, null, "C7", 17, 2, null },
                    { 1576, null, null, null, "C8", 17, 2, null },
                    { 1577, null, null, null, "D1", 17, 2, null },
                    { 1578, null, null, null, "D2", 17, 2, null },
                    { 1579, null, null, null, "D3", 17, 2, null },
                    { 1580, null, null, null, "D4", 17, 2, null },
                    { 1581, null, null, null, "D5", 17, 2, null },
                    { 1582, null, null, null, "D6", 17, 2, null },
                    { 1583, null, null, null, "D7", 17, 2, null },
                    { 1584, null, null, null, "D8", 17, 2, null },
                    { 1585, null, null, null, "E1", 17, 2, null },
                    { 1586, null, null, null, "E2", 17, 2, null },
                    { 1587, null, null, null, "E3", 17, 2, null },
                    { 1588, null, null, null, "E4", 17, 2, null },
                    { 1589, null, null, null, "E5", 17, 2, null },
                    { 1590, null, null, null, "E6", 17, 2, null },
                    { 1591, null, null, null, "E7", 17, 2, null },
                    { 1592, null, null, null, "E8", 17, 2, null },
                    { 1593, null, null, null, "F1", 17, 2, null },
                    { 1594, null, null, null, "F2", 17, 2, null },
                    { 1595, null, null, null, "F3", 17, 2, null },
                    { 1596, null, null, null, "F4", 17, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CreateTime", "DeleteTime", "IsActive", "Name", "RoomId", "SeatTypeId", "UpdateTime" },
                values: new object[,]
                {
                    { 1597, null, null, null, "F5", 17, 2, null },
                    { 1598, null, null, null, "F6", 17, 2, null },
                    { 1599, null, null, null, "F7", 17, 2, null },
                    { 1600, null, null, null, "F8", 17, 2, null },
                    { 1601, null, null, null, "G1", 17, 2, null },
                    { 1602, null, null, null, "G2", 17, 2, null },
                    { 1603, null, null, null, "G3", 17, 2, null },
                    { 1604, null, null, null, "G4", 17, 2, null },
                    { 1605, null, null, null, "G5", 17, 2, null },
                    { 1606, null, null, null, "G6", 17, 2, null },
                    { 1607, null, null, null, "G7", 17, 2, null },
                    { 1608, null, null, null, "G8", 17, 2, null },
                    { 1609, null, null, null, "H1", 17, 2, null },
                    { 1610, null, null, null, "H2", 17, 2, null },
                    { 1611, null, null, null, "H3", 17, 2, null },
                    { 1612, null, null, null, "H4", 17, 2, null },
                    { 1613, null, null, null, "H5", 17, 2, null },
                    { 1614, null, null, null, "H6", 17, 2, null },
                    { 1615, null, null, null, "H7", 17, 2, null },
                    { 1616, null, null, null, "H8", 17, 2, null },
                    { 1617, null, null, null, "A1", 18, 1, null },
                    { 1618, null, null, null, "A2", 18, 1, null },
                    { 1619, null, null, null, "A3", 18, 1, null },
                    { 1620, null, null, null, "A4", 18, 1, null },
                    { 1621, null, null, null, "A5", 18, 1, null },
                    { 1622, null, null, null, "A6", 18, 1, null },
                    { 1623, null, null, null, "A7", 18, 1, null },
                    { 1624, null, null, null, "A8", 18, 1, null },
                    { 1625, null, null, null, "B1", 18, 1, null },
                    { 1626, null, null, null, "B2", 18, 1, null },
                    { 1627, null, null, null, "B3", 18, 1, null },
                    { 1628, null, null, null, "B4", 18, 1, null },
                    { 1629, null, null, null, "B5", 18, 1, null },
                    { 1630, null, null, null, "B6", 18, 1, null },
                    { 1631, null, null, null, "B7", 18, 1, null },
                    { 1632, null, null, null, "B8", 18, 1, null },
                    { 1633, null, null, null, "C1", 18, 2, null },
                    { 1634, null, null, null, "C2", 18, 2, null },
                    { 1635, null, null, null, "C3", 18, 2, null },
                    { 1636, null, null, null, "C4", 18, 2, null },
                    { 1637, null, null, null, "C5", 18, 2, null },
                    { 1638, null, null, null, "C6", 18, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CreateTime", "DeleteTime", "IsActive", "Name", "RoomId", "SeatTypeId", "UpdateTime" },
                values: new object[,]
                {
                    { 1639, null, null, null, "C7", 18, 2, null },
                    { 1640, null, null, null, "C8", 18, 2, null },
                    { 1641, null, null, null, "D1", 18, 2, null },
                    { 1642, null, null, null, "D2", 18, 2, null },
                    { 1643, null, null, null, "D3", 18, 2, null },
                    { 1644, null, null, null, "D4", 18, 2, null },
                    { 1645, null, null, null, "D5", 18, 2, null },
                    { 1646, null, null, null, "D6", 18, 2, null },
                    { 1647, null, null, null, "D7", 18, 2, null },
                    { 1648, null, null, null, "D8", 18, 2, null },
                    { 1649, null, null, null, "E1", 18, 2, null },
                    { 1650, null, null, null, "E2", 18, 2, null },
                    { 1651, null, null, null, "E3", 18, 2, null },
                    { 1652, null, null, null, "E4", 18, 2, null },
                    { 1653, null, null, null, "E5", 18, 2, null },
                    { 1654, null, null, null, "E6", 18, 2, null },
                    { 1655, null, null, null, "E7", 18, 2, null },
                    { 1656, null, null, null, "E8", 18, 2, null },
                    { 1657, null, null, null, "F1", 18, 2, null },
                    { 1658, null, null, null, "F2", 18, 2, null },
                    { 1659, null, null, null, "F3", 18, 2, null },
                    { 1660, null, null, null, "F4", 18, 2, null },
                    { 1661, null, null, null, "F5", 18, 2, null },
                    { 1662, null, null, null, "F6", 18, 2, null },
                    { 1663, null, null, null, "F7", 18, 2, null },
                    { 1664, null, null, null, "F8", 18, 2, null },
                    { 1665, null, null, null, "G1", 18, 2, null },
                    { 1666, null, null, null, "G2", 18, 2, null },
                    { 1667, null, null, null, "G3", 18, 2, null },
                    { 1668, null, null, null, "G4", 18, 2, null },
                    { 1669, null, null, null, "G5", 18, 2, null },
                    { 1670, null, null, null, "G6", 18, 2, null },
                    { 1671, null, null, null, "G7", 18, 2, null },
                    { 1672, null, null, null, "G8", 18, 2, null },
                    { 1673, null, null, null, "H1", 18, 2, null },
                    { 1674, null, null, null, "H2", 18, 2, null },
                    { 1675, null, null, null, "H3", 18, 2, null },
                    { 1676, null, null, null, "H4", 18, 2, null },
                    { 1677, null, null, null, "H5", 18, 2, null },
                    { 1678, null, null, null, "H6", 18, 2, null },
                    { 1679, null, null, null, "H7", 18, 2, null },
                    { 1680, null, null, null, "H8", 18, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CreateTime", "DeleteTime", "IsActive", "Name", "RoomId", "SeatTypeId", "UpdateTime" },
                values: new object[,]
                {
                    { 1681, null, null, null, "A1", 19, 1, null },
                    { 1682, null, null, null, "A2", 19, 1, null },
                    { 1683, null, null, null, "A3", 19, 1, null },
                    { 1684, null, null, null, "A4", 19, 1, null },
                    { 1685, null, null, null, "A5", 19, 1, null },
                    { 1686, null, null, null, "A6", 19, 1, null },
                    { 1687, null, null, null, "A7", 19, 1, null },
                    { 1688, null, null, null, "A8", 19, 1, null },
                    { 1689, null, null, null, "A9", 19, 1, null },
                    { 1690, null, null, null, "A10", 19, 1, null },
                    { 1691, null, null, null, "B1", 19, 1, null },
                    { 1692, null, null, null, "B2", 19, 1, null },
                    { 1693, null, null, null, "B3", 19, 1, null },
                    { 1694, null, null, null, "B4", 19, 1, null },
                    { 1695, null, null, null, "B5", 19, 1, null },
                    { 1696, null, null, null, "B6", 19, 1, null },
                    { 1697, null, null, null, "B7", 19, 1, null },
                    { 1698, null, null, null, "B8", 19, 1, null },
                    { 1699, null, null, null, "B9", 19, 1, null },
                    { 1700, null, null, null, "B10", 19, 1, null },
                    { 1701, null, null, null, "C1", 19, 2, null },
                    { 1702, null, null, null, "C2", 19, 2, null },
                    { 1703, null, null, null, "C3", 19, 2, null },
                    { 1704, null, null, null, "C4", 19, 2, null },
                    { 1705, null, null, null, "C5", 19, 2, null },
                    { 1706, null, null, null, "C6", 19, 2, null },
                    { 1707, null, null, null, "C7", 19, 2, null },
                    { 1708, null, null, null, "C8", 19, 2, null },
                    { 1709, null, null, null, "C9", 19, 2, null },
                    { 1710, null, null, null, "C10", 19, 2, null },
                    { 1711, null, null, null, "D1", 19, 2, null },
                    { 1712, null, null, null, "D2", 19, 2, null },
                    { 1713, null, null, null, "D3", 19, 2, null },
                    { 1714, null, null, null, "D4", 19, 2, null },
                    { 1715, null, null, null, "D5", 19, 2, null },
                    { 1716, null, null, null, "D6", 19, 2, null },
                    { 1717, null, null, null, "D7", 19, 2, null },
                    { 1718, null, null, null, "D8", 19, 2, null },
                    { 1719, null, null, null, "D9", 19, 2, null },
                    { 1720, null, null, null, "D10", 19, 2, null },
                    { 1721, null, null, null, "E1", 19, 2, null },
                    { 1722, null, null, null, "E2", 19, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CreateTime", "DeleteTime", "IsActive", "Name", "RoomId", "SeatTypeId", "UpdateTime" },
                values: new object[,]
                {
                    { 1723, null, null, null, "E3", 19, 2, null },
                    { 1724, null, null, null, "E4", 19, 2, null },
                    { 1725, null, null, null, "E5", 19, 2, null },
                    { 1726, null, null, null, "E6", 19, 2, null },
                    { 1727, null, null, null, "E7", 19, 2, null },
                    { 1728, null, null, null, "E8", 19, 2, null },
                    { 1729, null, null, null, "E9", 19, 2, null },
                    { 1730, null, null, null, "E10", 19, 2, null },
                    { 1731, null, null, null, "F1", 19, 2, null },
                    { 1732, null, null, null, "F2", 19, 2, null },
                    { 1733, null, null, null, "F3", 19, 2, null },
                    { 1734, null, null, null, "F4", 19, 2, null },
                    { 1735, null, null, null, "F5", 19, 2, null },
                    { 1736, null, null, null, "F6", 19, 2, null },
                    { 1737, null, null, null, "F7", 19, 2, null },
                    { 1738, null, null, null, "F8", 19, 2, null },
                    { 1739, null, null, null, "F9", 19, 2, null },
                    { 1740, null, null, null, "F10", 19, 2, null },
                    { 1741, null, null, null, "G1", 19, 2, null },
                    { 1742, null, null, null, "G2", 19, 2, null },
                    { 1743, null, null, null, "G3", 19, 2, null },
                    { 1744, null, null, null, "G4", 19, 2, null },
                    { 1745, null, null, null, "G5", 19, 2, null },
                    { 1746, null, null, null, "G6", 19, 2, null },
                    { 1747, null, null, null, "G7", 19, 2, null },
                    { 1748, null, null, null, "G8", 19, 2, null },
                    { 1749, null, null, null, "G9", 19, 2, null },
                    { 1750, null, null, null, "G10", 19, 2, null },
                    { 1751, null, null, null, "H1", 19, 2, null },
                    { 1752, null, null, null, "H2", 19, 2, null },
                    { 1753, null, null, null, "H3", 19, 2, null },
                    { 1754, null, null, null, "H4", 19, 2, null },
                    { 1755, null, null, null, "H5", 19, 2, null },
                    { 1756, null, null, null, "H6", 19, 2, null },
                    { 1757, null, null, null, "H7", 19, 2, null },
                    { 1758, null, null, null, "H8", 19, 2, null },
                    { 1759, null, null, null, "H9", 19, 2, null },
                    { 1760, null, null, null, "H10", 19, 2, null },
                    { 1761, null, null, null, "I1", 19, 2, null },
                    { 1762, null, null, null, "I2", 19, 2, null },
                    { 1763, null, null, null, "I3", 19, 2, null },
                    { 1764, null, null, null, "I4", 19, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CreateTime", "DeleteTime", "IsActive", "Name", "RoomId", "SeatTypeId", "UpdateTime" },
                values: new object[,]
                {
                    { 1765, null, null, null, "I5", 19, 2, null },
                    { 1766, null, null, null, "I6", 19, 2, null },
                    { 1767, null, null, null, "I7", 19, 2, null },
                    { 1768, null, null, null, "I8", 19, 2, null },
                    { 1769, null, null, null, "I9", 19, 2, null },
                    { 1770, null, null, null, "I10", 19, 2, null },
                    { 1771, null, null, null, "J1", 19, 2, null },
                    { 1772, null, null, null, "J2", 19, 2, null },
                    { 1773, null, null, null, "J3", 19, 2, null },
                    { 1774, null, null, null, "J4", 19, 2, null },
                    { 1775, null, null, null, "J5", 19, 2, null },
                    { 1776, null, null, null, "J6", 19, 2, null },
                    { 1777, null, null, null, "J7", 19, 2, null },
                    { 1778, null, null, null, "J8", 19, 2, null },
                    { 1779, null, null, null, "J9", 19, 2, null },
                    { 1780, null, null, null, "J10", 19, 2, null },
                    { 1781, null, null, null, "A1", 20, 1, null },
                    { 1782, null, null, null, "A2", 20, 1, null },
                    { 1783, null, null, null, "A3", 20, 1, null },
                    { 1784, null, null, null, "A4", 20, 1, null },
                    { 1785, null, null, null, "A5", 20, 1, null },
                    { 1786, null, null, null, "A6", 20, 1, null },
                    { 1787, null, null, null, "A7", 20, 1, null },
                    { 1788, null, null, null, "A8", 20, 1, null },
                    { 1789, null, null, null, "A9", 20, 1, null },
                    { 1790, null, null, null, "A10", 20, 1, null },
                    { 1791, null, null, null, "B1", 20, 1, null },
                    { 1792, null, null, null, "B2", 20, 1, null },
                    { 1793, null, null, null, "B3", 20, 1, null },
                    { 1794, null, null, null, "B4", 20, 1, null },
                    { 1795, null, null, null, "B5", 20, 1, null },
                    { 1796, null, null, null, "B6", 20, 1, null },
                    { 1797, null, null, null, "B7", 20, 1, null },
                    { 1798, null, null, null, "B8", 20, 1, null },
                    { 1799, null, null, null, "B9", 20, 1, null },
                    { 1800, null, null, null, "B10", 20, 1, null },
                    { 1801, null, null, null, "C1", 20, 2, null },
                    { 1802, null, null, null, "C2", 20, 2, null },
                    { 1803, null, null, null, "C3", 20, 2, null },
                    { 1804, null, null, null, "C4", 20, 2, null },
                    { 1805, null, null, null, "C5", 20, 2, null },
                    { 1806, null, null, null, "C6", 20, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CreateTime", "DeleteTime", "IsActive", "Name", "RoomId", "SeatTypeId", "UpdateTime" },
                values: new object[,]
                {
                    { 1807, null, null, null, "C7", 20, 2, null },
                    { 1808, null, null, null, "C8", 20, 2, null },
                    { 1809, null, null, null, "C9", 20, 2, null },
                    { 1810, null, null, null, "C10", 20, 2, null },
                    { 1811, null, null, null, "D1", 20, 2, null },
                    { 1812, null, null, null, "D2", 20, 2, null },
                    { 1813, null, null, null, "D3", 20, 2, null },
                    { 1814, null, null, null, "D4", 20, 2, null },
                    { 1815, null, null, null, "D5", 20, 2, null },
                    { 1816, null, null, null, "D6", 20, 2, null },
                    { 1817, null, null, null, "D7", 20, 2, null },
                    { 1818, null, null, null, "D8", 20, 2, null },
                    { 1819, null, null, null, "D9", 20, 2, null },
                    { 1820, null, null, null, "D10", 20, 2, null },
                    { 1821, null, null, null, "E1", 20, 2, null },
                    { 1822, null, null, null, "E2", 20, 2, null },
                    { 1823, null, null, null, "E3", 20, 2, null },
                    { 1824, null, null, null, "E4", 20, 2, null },
                    { 1825, null, null, null, "E5", 20, 2, null },
                    { 1826, null, null, null, "E6", 20, 2, null },
                    { 1827, null, null, null, "E7", 20, 2, null },
                    { 1828, null, null, null, "E8", 20, 2, null },
                    { 1829, null, null, null, "E9", 20, 2, null },
                    { 1830, null, null, null, "E10", 20, 2, null },
                    { 1831, null, null, null, "F1", 20, 2, null },
                    { 1832, null, null, null, "F2", 20, 2, null },
                    { 1833, null, null, null, "F3", 20, 2, null },
                    { 1834, null, null, null, "F4", 20, 2, null },
                    { 1835, null, null, null, "F5", 20, 2, null },
                    { 1836, null, null, null, "F6", 20, 2, null },
                    { 1837, null, null, null, "F7", 20, 2, null },
                    { 1838, null, null, null, "F8", 20, 2, null },
                    { 1839, null, null, null, "F9", 20, 2, null },
                    { 1840, null, null, null, "F10", 20, 2, null },
                    { 1841, null, null, null, "G1", 20, 2, null },
                    { 1842, null, null, null, "G2", 20, 2, null },
                    { 1843, null, null, null, "G3", 20, 2, null },
                    { 1844, null, null, null, "G4", 20, 2, null },
                    { 1845, null, null, null, "G5", 20, 2, null },
                    { 1846, null, null, null, "G6", 20, 2, null },
                    { 1847, null, null, null, "G7", 20, 2, null },
                    { 1848, null, null, null, "G8", 20, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CreateTime", "DeleteTime", "IsActive", "Name", "RoomId", "SeatTypeId", "UpdateTime" },
                values: new object[,]
                {
                    { 1849, null, null, null, "G9", 20, 2, null },
                    { 1850, null, null, null, "G10", 20, 2, null },
                    { 1851, null, null, null, "H1", 20, 2, null },
                    { 1852, null, null, null, "H2", 20, 2, null },
                    { 1853, null, null, null, "H3", 20, 2, null },
                    { 1854, null, null, null, "H4", 20, 2, null },
                    { 1855, null, null, null, "H5", 20, 2, null },
                    { 1856, null, null, null, "H6", 20, 2, null },
                    { 1857, null, null, null, "H7", 20, 2, null },
                    { 1858, null, null, null, "H8", 20, 2, null },
                    { 1859, null, null, null, "H9", 20, 2, null },
                    { 1860, null, null, null, "H10", 20, 2, null },
                    { 1861, null, null, null, "I1", 20, 2, null },
                    { 1862, null, null, null, "I2", 20, 2, null },
                    { 1863, null, null, null, "I3", 20, 2, null },
                    { 1864, null, null, null, "I4", 20, 2, null },
                    { 1865, null, null, null, "I5", 20, 2, null },
                    { 1866, null, null, null, "I6", 20, 2, null },
                    { 1867, null, null, null, "I7", 20, 2, null },
                    { 1868, null, null, null, "I8", 20, 2, null },
                    { 1869, null, null, null, "I9", 20, 2, null },
                    { 1870, null, null, null, "I10", 20, 2, null },
                    { 1871, null, null, null, "J1", 20, 2, null },
                    { 1872, null, null, null, "J2", 20, 2, null },
                    { 1873, null, null, null, "J3", 20, 2, null },
                    { 1874, null, null, null, "J4", 20, 2, null },
                    { 1875, null, null, null, "J5", 20, 2, null },
                    { 1876, null, null, null, "J6", 20, 2, null },
                    { 1877, null, null, null, "J7", 20, 2, null },
                    { 1878, null, null, null, "J8", 20, 2, null },
                    { 1879, null, null, null, "J9", 20, 2, null },
                    { 1880, null, null, null, "J10", 20, 2, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_OrderId",
                table: "Bookings",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ScheduleId",
                table: "Bookings",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_SeatId",
                table: "Bookings",
                column: "SeatId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_SeatId1",
                table: "Bookings",
                column: "SeatId1");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieActors_MovieId",
                table: "MovieActors",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieDirectors_MovieId",
                table: "MovieDirectors",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenres_MovieId",
                table: "MovieGenres",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_CinemaId",
                table: "Rooms",
                column: "CinemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_CinemaId",
                table: "Schedules",
                column: "CinemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_MovieId",
                table: "Schedules",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_RoomId",
                table: "Schedules",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_RoomId",
                table: "Seats",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_SeatTypeId",
                table: "Seats",
                column: "SeatTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "MovieActors");

            migrationBuilder.DropTable(
                name: "MovieDirectors");

            migrationBuilder.DropTable(
                name: "MovieGenres");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Directors");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "SeatTypes");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Cinemas");
        }
    }
}
