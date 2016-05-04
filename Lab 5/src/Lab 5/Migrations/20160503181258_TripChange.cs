using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace Lab5.Migrations
{
    public partial class TripChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "CreatedDate", table: "Trip");
            migrationBuilder.DropColumn(name: "LongLat", table: "Stop");
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Trip",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Stop",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Stop",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "DateCreated", table: "Trip");
            migrationBuilder.DropColumn(name: "Latitude", table: "Stop");
            migrationBuilder.DropColumn(name: "Longitude", table: "Stop");
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Trip",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
            migrationBuilder.AddColumn<double>(
                name: "LongLat",
                table: "Stop",
                nullable: false,
                defaultValue: 0);
        }
    }
}
