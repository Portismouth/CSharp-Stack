using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RESTauranter.Migrations
{
    public partial class ChangingDBName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VistDate",
                table: "Entries",
                newName: "VisitDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VisitDate",
                table: "Entries",
                newName: "VistDate");
        }
    }
}
