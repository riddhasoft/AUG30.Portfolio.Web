using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AUG30.Portfolio.Data.Migrations
{
    public partial class client_message_model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientMessageModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientMessageModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientMessageModel_ClientModel_ClientId",
                        column: x => x.ClientId,
                        principalTable: "ClientModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientMessageModel_ClientId",
                table: "ClientMessageModel",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientMessageModel");
        }
    }
}
