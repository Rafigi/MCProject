﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace McWorld.Shared.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<Guid>(nullable: false),
                    Username = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Birthdate = table.Column<string>(nullable: false),
                    Created = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    RouteID = table.Column<Guid>(nullable: false),
                    Distance = table.Column<double>(nullable: false),
                    Motorway = table.Column<bool>(nullable: false),
                    Ferry = table.Column<bool>(nullable: false),
                    Toll = table.Column<bool>(nullable: false),
                    Created = table.Column<string>(nullable: false),
                    UserID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.RouteID);
                    table.ForeignKey(
                        name: "FK_Routes_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<Guid>(nullable: false),
                    StreetName = table.Column<string>(nullable: false),
                    StreetNumber = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    Zipcode = table.Column<int>(nullable: false),
                    Country = table.Column<string>(nullable: false),
                    Latitude = table.Column<string>(nullable: true),
                    Longitude = table.Column<string>(nullable: true),
                    RouteID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Address_Routes_RouteID",
                        column: x => x.RouteID,
                        principalTable: "Routes",
                        principalColumn: "RouteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventID = table.Column<Guid>(nullable: false),
                    Headline = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    StartDate = table.Column<string>(nullable: false),
                    StartTime = table.Column<string>(nullable: false),
                    EndDate = table.Column<string>(nullable: false),
                    EndTime = table.Column<string>(nullable: false),
                    RegistrationCount = table.Column<int>(nullable: false),
                    Created = table.Column<string>(nullable: false),
                    UserID = table.Column<Guid>(nullable: true),
                    RouteID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventID);
                    table.ForeignKey(
                        name: "FK_Events_Routes_RouteID",
                        column: x => x.RouteID,
                        principalTable: "Routes",
                        principalColumn: "RouteID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Registration",
                columns: table => new
                {
                    UserID = table.Column<Guid>(nullable: false),
                    EventID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registration", x => new { x.UserID, x.EventID });
                    table.ForeignKey(
                        name: "FK_Registration_Events_EventID",
                        column: x => x.EventID,
                        principalTable: "Events",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registration_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_RouteID",
                table: "Address",
                column: "RouteID");

            migrationBuilder.CreateIndex(
                name: "IX_Events_RouteID",
                table: "Events",
                column: "RouteID");

            migrationBuilder.CreateIndex(
                name: "IX_Events_UserID",
                table: "Events",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Registration_EventID",
                table: "Registration",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_UserID",
                table: "Routes",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Registration");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
