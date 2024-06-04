using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NomadLife.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false),
                    Slug = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Slug = table.Column<string>(type: "varchar(75)", unicode: false, maxLength: 75, nullable: false),
                    IsTop = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    NumStars = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "varchar(180)", unicode: false, maxLength: 180, nullable: false),
                    BuyLink = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hotels_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocationHotels",
                columns: table => new
                {
                    LocationId = table.Column<short>(type: "smallint", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationHotels", x => new { x.LocationId, x.HotelId });
                    table.ForeignKey(
                        name: "FK_LocationHotels_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocationHotels_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Name", "Slug" },
                values: new object[] { 1, "Paweł Syrowy", "pawel-syrowy" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "IsTop", "Name", "Slug" },
                values: new object[,]
                {
                    { (short)1, true, "United States", "united-states" },
                    { (short)2, true, "France", "france" },
                    { (short)3, true, "Italy", "italy" },
                    { (short)4, false, "Spain", "spain" },
                    { (short)5, true, "United Kingdom", "united-kingdom" },
                    { (short)6, false, "Mexico", "mexico" },
                    { (short)7, false, "Germany", "germany" },
                    { (short)8, false, "Thailand", "thailand" },
                    { (short)9, false, "China", "china" },
                    { (short)10, true, "Japan", "japan" },
                    { (short)11, false, "Turkey", "turkey" },
                    { (short)12, false, "Greece", "greece" },
                    { (short)13, false, "Canada", "canada" },
                    { (short)14, false, "Australia", "australia" },
                    { (short)15, false, "Brazil", "brazil" },
                    { (short)16, false, "Argentina", "argentina" },
                    { (short)17, false, "South Korea", "south-korea" },
                    { (short)18, false, "Egypt", "egypt" },
                    { (short)19, false, "South Africa", "south-africa" },
                    { (short)20, true, "India", "india" },
                    { (short)21, false, "Russia", "russia" },
                    { (short)22, false, "Indonesia", "indonesia" },
                    { (short)23, false, "Vietnam", "vietnam" },
                    { (short)24, false, "Netherlands", "netherlands" },
                    { (short)25, false, "Malaysia", "malaysia" },
                    { (short)26, false, "Switzerland", "switzerland" },
                    { (short)27, true, "Portugal", "portugal" },
                    { (short)28, false, "New Zealand", "new-zealand" },
                    { (short)29, false, "Austria", "austria" },
                    { (short)30, false, "Sweden", "sweden" },
                    { (short)31, false, "Norway", "norway" },
                    { (short)32, false, "Denmark", "denmark" },
                    { (short)33, false, "Finland", "finland" },
                    { (short)34, false, "Belgium", "belgium" },
                    { (short)35, false, "Ireland", "ireland" },
                    { (short)36, false, "Scotland", "scotland" },
                    { (short)37, false, "Iceland", "iceland" },
                    { (short)38, false, "Croatia", "croatia" },
                    { (short)39, false, "Czech Republic", "czech-republic" },
                    { (short)40, false, "Hungary", "hungary" },
                    { (short)41, false, "Poland", "poland" },
                    { (short)42, false, "Israel", "israel" },
                    { (short)43, false, "Chile", "chile" },
                    { (short)44, false, "Peru", "peru" },
                    { (short)45, false, "Colombia", "colombia" },
                    { (short)46, true, "Singapore", "singapore" },
                    { (short)47, false, "Philippines", "philippines" },
                    { (short)48, false, "Morocco", "morocco" },
                    { (short)49, false, "United Arab Emirates", "uae" },
                    { (short)50, false, "Saudi Arabia", "saudi-arabia" },
                    { (short)51, false, "Qatar", "qatar" },
                    { (short)52, false, "Kuwait", "kuwait" },
                    { (short)53, false, "Jordan", "jordan" },
                    { (short)54, false, "Lebanon", "lebanon" },
                    { (short)55, false, "Nepal", "nepal" },
                    { (short)56, false, "Sri Lanka", "sri-lanka" },
                    { (short)57, false, "Bangladesh", "bangladesh" },
                    { (short)58, false, "Pakistan", "pakistan" },
                    { (short)59, false, "Myanmar", "myanmar" },
                    { (short)60, false, "Laos", "laos" },
                    { (short)61, false, "Cambodia", "cambodia" },
                    { (short)62, false, "Mongolia", "mongolia" },
                    { (short)63, false, "Kazakhstan", "kazakhstan" },
                    { (short)64, false, "Uzbekistan", "uzbekistan" },
                    { (short)65, false, "Romania", "romania" },
                    { (short)66, false, "Bulgaria", "bulgaria" },
                    { (short)67, false, "Ukraine", "ukraine" },
                    { (short)68, false, "Belarus", "belarus" },
                    { (short)69, false, "Estonia", "estonia" },
                    { (short)70, false, "Latvia", "latvia" },
                    { (short)71, false, "Lithuania", "lithuania" },
                    { (short)72, false, "Slovenia", "slovenia" },
                    { (short)73, false, "Slovakia", "slovakia" },
                    { (short)74, false, "Serbia", "serbia" }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "AuthorId", "BuyLink", "Description", "Image", "NumStars", "Title", "Type" },
                values: new object[,]
                {
                    { 1, 1, null, "A serene retreat located on the shores of a pristine beach, offering breathtaking ocean views and luxurious amenities.", "https://raw.github.com/PawelSyrowy/NomadLifeImages/main/hotel1.jpg", 5, "Ocean Breeze Hotel", "Hotel" },
                    { 2, 1, null, "A cozy and affordable hostel nestled in the heart of the mountains, perfect for backpackers and nature lovers.", "https://raw.github.com/PawelSyrowy/NomadLifeImages/main/hotel2.jpg", 3, "Mountain View Hostel", "Hostel" },
                    { 3, 1, null, "A modern and stylish apartment located in the bustling city center, ideal for business travelers and tourists.", "https://raw.github.com/PawelSyrowy/NomadLifeImages/main/hotel3.jpg", 4, "City Central Apartment", "Apartment" },
                    { 4, 1, null, "A charming inn situated by the river, offering a peaceful and relaxing atmosphere with scenic views.", "https://raw.github.com/PawelSyrowy/NomadLifeImages/main/hotel4.jpg", 4, "Riverside Inn", "Hotel" },
                    { 5, 1, null, "An exotic resort located in the middle of the desert, providing luxurious accommodations and unique experiences.", "https://raw.github.com/PawelSyrowy/NomadLifeImages/main/hotel5.jpg", 5, "Desert Oasis Resort", "Resort" },
                    { 6, 1, null, "A quaint bed and breakfast in a historic downtown area, featuring cozy rooms and homemade breakfast.", "https://raw.github.com/PawelSyrowy/NomadLifeImages/main/hotel6.jpg", 3, "Historic Downtown Bed & Breakfast", "Bed & Breakfast" },
                    { 7, 1, null, "A rustic lodge located by the lake, offering a perfect getaway for fishing, boating, and relaxation.", "https://raw.github.com/PawelSyrowy/NomadLifeImages/main/hotel7.jpg", 4, "Lakeside Lodge", "Lodge" },
                    { 8, 1, null, "A trendy boutique hotel in the heart of the city, known for its stylish design and personalized service.", "https://raw.github.com/PawelSyrowy/NomadLifeImages/main/hotel8.jpg", 5, "Urban Chic Boutique Hotel", "Boutique Hotel" },
                    { 9, 1, null, "An environmentally friendly retreat offering sustainable accommodations and activities in nature.", "https://raw.github.com/PawelSyrowy/NomadLifeImages/main/hotel9.jpg", 4, "Eco-Friendly Retreat", "Retreat" },
                    { 10, 1, null, "A welcoming guesthouse located in the tranquil countryside, perfect for a peaceful escape from the city.", "https://raw.github.com/PawelSyrowy/NomadLifeImages/main/hotel10.jpg", 3, "Countryside Guesthouse", "Guesthouse" }
                });

            migrationBuilder.InsertData(
                table: "LocationHotels",
                columns: new[] { "HotelId", "LocationId" },
                values: new object[,]
                {
                    { 6, (short)1 },
                    { 4, (short)2 },
                    { 3, (short)7 },
                    { 8, (short)10 },
                    { 7, (short)13 },
                    { 10, (short)14 },
                    { 1, (short)15 },
                    { 2, (short)26 },
                    { 9, (short)28 },
                    { 5, (short)48 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_AuthorId",
                table: "Hotels",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationHotels_HotelId",
                table: "LocationHotels",
                column: "HotelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocationHotels");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
