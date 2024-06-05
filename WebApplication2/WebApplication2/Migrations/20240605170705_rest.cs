using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class rest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    PK_account = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_role = table.Column<int>(type: "int", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.PK_account);
                    table.ForeignKey(
                        name: "FK_Accounts_Roles_FK_role",
                        column: x => x.FK_role,
                        principalTable: "Roles",
                        principalColumn: "PK_role",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    PK_category = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.PK_category);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    PK_product = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    weight = table.Column<double>(type: "float(5)", precision: 5, scale: 2, nullable: false),
                    width = table.Column<double>(type: "float(5)", precision: 5, scale: 2, nullable: false),
                    height = table.Column<double>(type: "float(5)", precision: 5, scale: 2, nullable: false),
                    depth = table.Column<double>(type: "float(5)", precision: 5, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.PK_product);
                });

            migrationBuilder.CreateTable(
                name: "Products_categories",
                columns: table => new
                {
                    FK_product = table.Column<int>(type: "int", nullable: false),
                    FK_category = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products_categories", x => new { x.FK_product, x.FK_category });
                    table.ForeignKey(
                        name: "FK_Products_categories_Categories_FK_category",
                        column: x => x.FK_category,
                        principalTable: "Categories",
                        principalColumn: "PK_category",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_categories_Products_FK_product",
                        column: x => x.FK_product,
                        principalTable: "Products",
                        principalColumn: "PK_product",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shopping_Carts",
                columns: table => new
                {
                    FK_account = table.Column<int>(type: "int", nullable: false),
                    FK_product = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shopping_Carts", x => new { x.FK_product, x.FK_account });
                    table.ForeignKey(
                        name: "FK_Shopping_Carts_Accounts_FK_account",
                        column: x => x.FK_account,
                        principalTable: "Accounts",
                        principalColumn: "PK_account",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shopping_Carts_Products_FK_product",
                        column: x => x.FK_product,
                        principalTable: "Products",
                        principalColumn: "PK_product",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "PK_category", "name" },
                values: new object[] { 1, "222" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "PK_product", "depth", "height", "name", "weight", "width" },
                values: new object[] { 1, 22.0, 23.0, "dfs", 21.0, 11.0 });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "PK_role", "name" },
                values: new object[,]
                {
                    { 1, "created" },
                    { 2, "finished" },
                    { 3, "removed" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "PK_account", "email", "first_name", "last_name", "phone", "FK_role" },
                values: new object[,]
                {
                    { 1, "lllla", "ll", "zz", "999999999", 1 },
                    { 2, "lllla", "ll", "zz", "999999999", 1 }
                });

            migrationBuilder.InsertData(
                table: "Products_categories",
                columns: new[] { "FK_category", "FK_product" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Shopping_Carts",
                columns: new[] { "FK_account", "FK_product", "amount" },
                values: new object[] { 1, 1, 20 });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_FK_role",
                table: "Accounts",
                column: "FK_role");

            migrationBuilder.CreateIndex(
                name: "IX_Products_categories_FK_category",
                table: "Products_categories",
                column: "FK_category");

            migrationBuilder.CreateIndex(
                name: "IX_Shopping_Carts_FK_account",
                table: "Shopping_Carts",
                column: "FK_account");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products_categories");

            migrationBuilder.DropTable(
                name: "Shopping_Carts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "PK_role",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "PK_role",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "PK_role",
                keyValue: 3);
        }
    }
}
