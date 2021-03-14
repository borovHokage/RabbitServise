using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD
{
    [DbContext(typeof(TaskDbContext))]
    [Migration("20210311_InitialCreate")]
    public class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable("Films", table => new
            {
                Id = table.Column<Guid>(nullable: false),
                Name = table.Column<string>(nullable: false),
                Year = table.Column<int>(nullable: false),
                DirectorId = table.Column<int>(nullable: false)
            },
            constraints: table => { 
                table.PrimaryKey("PK_Film", a => a.Id);
                table.ForeignKey(
                        name: "FK_Film_Films",
                        column: x => x.DirectorId,
                        principalTable: "Directors",
                        principalColumn: "DirId",
                        onDelete: ReferentialAction.Cascade);
            });

            migrationBuilder.CreateTable("Directors", table => new
            {
               DirId = table.Column<Guid>(nullable: false),
               Name = table.Column<string>(nullable: false)
            },
            constraints: table => 
            {
                table.PrimaryKey("PK_Director", a => a.DirId);
            });
            migrationBuilder.CreateTable("Budgets", table => new
            {
                BudgetId = table.Column<Guid>(nullable: false),
                Sum = table.Column<int>(nullable: false)
            },
           constraints: table => { table.PrimaryKey("PK_Budget", a => a.BudgetId); });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Films");
            migrationBuilder.DropTable("Directors");
            migrationBuilder.DropTable("Budgets");
        }
    }
}
