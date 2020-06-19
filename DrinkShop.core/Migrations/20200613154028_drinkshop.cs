using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DrinkShop.core.Migrations
{
    public partial class drinkshop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ice",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(20)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_unicode_520_ci"),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime", nullable: true),
                    Remarks = table.Column<string>(type: "varchar(50)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_unicode_520_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ice", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(20)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_unicode_520_ci"),
                    CanIce = table.Column<bool>(nullable: false),
                    CanSize = table.Column<bool>(nullable: false),
                    CanSweetness = table.Column<bool>(nullable: false),
                    BasePrice = table.Column<int>(type: "int(11)", nullable: false),
                    AddPrice = table.Column<int>(type: "int(11)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime", nullable: true),
                    Remarks = table.Column<string>(type: "varchar(50)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_unicode_520_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Phone = table.Column<string>(type: "varchar(20)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_unicode_520_ci"),
                    ClientID = table.Column<string>(type: "varchar(250)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_unicode_520_ci"),
                    Price = table.Column<int>(type: "int(11)", nullable: false),
                    Payment = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime", nullable: true),
                    Remarks = table.Column<string>(type: "varchar(50)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_unicode_520_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(20)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_unicode_520_ci"),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime", nullable: true),
                    Remarks = table.Column<string>(type: "varchar(50)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_unicode_520_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Sweetness",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(20)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_unicode_520_ci"),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime", nullable: true),
                    Remarks = table.Column<string>(type: "varchar(50)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_unicode_520_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sweetness", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint(20)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ID_Order = table.Column<int>(type: "int(11)", nullable: false),
                    ID_Item = table.Column<int>(type: "int(11)", nullable: false),
                    Count = table.Column<int>(type: "int(11)", nullable: false),
                    ID_Ice = table.Column<int>(type: "int(11)", nullable: false),
                    ID_Size = table.Column<int>(type: "int(11)", nullable: false),
                    ID_Sweetness = table.Column<int>(type: "int(11)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime", nullable: true),
                    Remarks = table.Column<string>(type: "varchar(50)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_unicode_520_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.ID);
                    table.ForeignKey(
                        name: "orderitems_ibfk_1",
                        column: x => x.ID_Ice,
                        principalTable: "Ice",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "orderitems_ibfk_2",
                        column: x => x.ID_Item,
                        principalTable: "Items",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "orderitems_ibfk_3",
                        column: x => x.ID_Order,
                        principalTable: "Orders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "orderitems_ibfk_4",
                        column: x => x.ID_Size,
                        principalTable: "Size",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "orderitems_ibfk_5",
                        column: x => x.ID_Sweetness,
                        principalTable: "Sweetness",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ID_Ice",
                table: "OrderItems",
                column: "ID_Ice");

            migrationBuilder.CreateIndex(
                name: "ID_Item",
                table: "OrderItems",
                column: "ID_Item");

            migrationBuilder.CreateIndex(
                name: "ID_Order",
                table: "OrderItems",
                column: "ID_Order");

            migrationBuilder.CreateIndex(
                name: "ID_Size",
                table: "OrderItems",
                column: "ID_Size");

            migrationBuilder.CreateIndex(
                name: "ID_Sweetness",
                table: "OrderItems",
                column: "ID_Sweetness");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Ice");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Size");

            migrationBuilder.DropTable(
                name: "Sweetness");
        }
    }
}
