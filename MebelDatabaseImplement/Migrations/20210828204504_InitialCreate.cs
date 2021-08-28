using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MebelDatabaseImplement.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Garniture",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garniture", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mebel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mebel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Supply",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supply", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GarnitureMaterials",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GarnitureId = table.Column<int>(nullable: false),
                    MaterialId = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GarnitureMaterials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GarnitureMaterials_Garniture_GarnitureId",
                        column: x => x.GarnitureId,
                        principalTable: "Garniture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GarnitureMaterials_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GarnitureMebels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GarnitureId = table.Column<int>(nullable: false),
                    MebelId = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GarnitureMebels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GarnitureMebels_Garniture_GarnitureId",
                        column: x => x.GarnitureId,
                        principalTable: "Garniture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GarnitureMebels_Mebel_MebelId",
                        column: x => x.MebelId,
                        principalTable: "Mebel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModuleMaterials",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuleId = table.Column<int>(nullable: false),
                    MaterialId = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleMaterials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModuleMaterials_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuleMaterials_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModuleMebels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuleId = table.Column<int>(nullable: false),
                    MebelId = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleMebels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModuleMebels_Mebel_MebelId",
                        column: x => x.MebelId,
                        principalTable: "Mebel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuleMebels_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplyMaterials",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialId = table.Column<int>(nullable: false),
                    SupplyId = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplyMaterials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupplyMaterials_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplyMaterials_Supply_SupplyId",
                        column: x => x.SupplyId,
                        principalTable: "Supply",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GarnitureMaterials_GarnitureId",
                table: "GarnitureMaterials",
                column: "GarnitureId");

            migrationBuilder.CreateIndex(
                name: "IX_GarnitureMaterials_MaterialId",
                table: "GarnitureMaterials",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_GarnitureMebels_GarnitureId",
                table: "GarnitureMebels",
                column: "GarnitureId");

            migrationBuilder.CreateIndex(
                name: "IX_GarnitureMebels_MebelId",
                table: "GarnitureMebels",
                column: "MebelId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleMaterials_MaterialId",
                table: "ModuleMaterials",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleMaterials_ModuleId",
                table: "ModuleMaterials",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleMebels_MebelId",
                table: "ModuleMebels",
                column: "MebelId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleMebels_ModuleId",
                table: "ModuleMebels",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplyMaterials_MaterialId",
                table: "SupplyMaterials",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplyMaterials_SupplyId",
                table: "SupplyMaterials",
                column: "SupplyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "GarnitureMaterials");

            migrationBuilder.DropTable(
                name: "GarnitureMebels");

            migrationBuilder.DropTable(
                name: "ModuleMaterials");

            migrationBuilder.DropTable(
                name: "ModuleMebels");

            migrationBuilder.DropTable(
                name: "Providers");

            migrationBuilder.DropTable(
                name: "SupplyMaterials");

            migrationBuilder.DropTable(
                name: "Garniture");

            migrationBuilder.DropTable(
                name: "Mebel");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Supply");
        }
    }
}
