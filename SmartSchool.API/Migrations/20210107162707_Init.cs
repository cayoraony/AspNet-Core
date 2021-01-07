using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartSchool.API.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Matricula = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    DataNasc = table.Column<DateTime>(nullable: false),
                    DataIni = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Registro = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(nullable: true),
                    DataIni = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlunosCursos",
                columns: table => new
                {
                    AlunoId = table.Column<int>(nullable: false),
                    CursoId = table.Column<int>(nullable: false),
                    DataIni = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true),
                    Nota = table.Column<float>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosCursos", x => new { x.AlunoId, x.CursoId });
                    table.ForeignKey(
                        name: "FK_AlunosCursos_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosCursos_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Disciplinas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true),
                    cargaHoraria = table.Column<int>(nullable: false),
                    PreRequisitoId = table.Column<int>(nullable: true),
                    ProfessorId = table.Column<int>(nullable: false),
                    CursoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplinas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Disciplinas_PreRequisitoId",
                        column: x => x.PreRequisitoId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Professores_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlunosDisciplinas",
                columns: table => new
                {
                    AlunoId = table.Column<int>(nullable: false),
                    DisciplinaId = table.Column<int>(nullable: false),
                    DataIni = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true),
                    Nota = table.Column<float>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosDisciplinas", x => new { x.AlunoId, x.DisciplinaId });
                    table.ForeignKey(
                        name: "FK_AlunosDisciplinas_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosDisciplinas_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataFim", "DataIni", "DataNasc", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 1, true, null, new DateTime(2021, 1, 7, 13, 27, 6, 550, DateTimeKind.Local).AddTicks(1675), new DateTime(2005, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Marta", "Kent", "33225555" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataFim", "DataIni", "DataNasc", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 2, true, null, new DateTime(2021, 1, 7, 13, 27, 6, 550, DateTimeKind.Local).AddTicks(5634), new DateTime(2005, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Paula", "Isabela", "3354288" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataFim", "DataIni", "DataNasc", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 3, true, null, new DateTime(2021, 1, 7, 13, 27, 6, 550, DateTimeKind.Local).AddTicks(5730), new DateTime(2005, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Laura", "Antonia", "55668899" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataFim", "DataIni", "DataNasc", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 4, true, null, new DateTime(2021, 1, 7, 13, 27, 6, 550, DateTimeKind.Local).AddTicks(5741), new DateTime(2005, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Luiza", "Maria", "6565659" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataFim", "DataIni", "DataNasc", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 5, true, null, new DateTime(2021, 1, 7, 13, 27, 6, 550, DateTimeKind.Local).AddTicks(5746), new DateTime(2005, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Lucas", "Machado", "565685415" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataFim", "DataIni", "DataNasc", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 6, true, null, new DateTime(2021, 1, 7, 13, 27, 6, 550, DateTimeKind.Local).AddTicks(5756), new DateTime(2005, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Pedro", "Alvares", "456454545" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataFim", "DataIni", "DataNasc", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 7, true, null, new DateTime(2021, 1, 7, 13, 27, 6, 550, DateTimeKind.Local).AddTicks(5761), new DateTime(2005, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Paulo", "José", "9874512" });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 1, "Ciencia da computação" });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 2, "Sistemas para Internet" });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 3, "Redes de computadores" });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "DataFim", "DataIni", "Nome", "Registro", "Sobrenome" },
                values: new object[] { 1, true, null, new DateTime(2021, 1, 7, 13, 27, 6, 543, DateTimeKind.Local).AddTicks(8619), "Lauro", 0, "Lauro" });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "DataFim", "DataIni", "Nome", "Registro", "Sobrenome" },
                values: new object[] { 2, true, null, new DateTime(2021, 1, 7, 13, 27, 6, 545, DateTimeKind.Local).AddTicks(6456), "Roberto", 0, "Roberto" });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "DataFim", "DataIni", "Nome", "Registro", "Sobrenome" },
                values: new object[] { 3, true, null, new DateTime(2021, 1, 7, 13, 27, 6, 545, DateTimeKind.Local).AddTicks(6529), "Ronaldo", 0, "Ronaldo" });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "DataFim", "DataIni", "Nome", "Registro", "Sobrenome" },
                values: new object[] { 4, true, null, new DateTime(2021, 1, 7, 13, 27, 6, 545, DateTimeKind.Local).AddTicks(6532), "Rodrigo", 0, "Rodrigo" });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "DataFim", "DataIni", "Nome", "Registro", "Sobrenome" },
                values: new object[] { 5, true, null, new DateTime(2021, 1, 7, 13, 27, 6, 545, DateTimeKind.Local).AddTicks(6534), "Alexandre", 0, "Alexandre" });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CursoId", "Nome", "PreRequisitoId", "ProfessorId", "cargaHoraria" },
                values: new object[] { 1, 1, "Matemática", null, 1, 0 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CursoId", "Nome", "PreRequisitoId", "ProfessorId", "cargaHoraria" },
                values: new object[] { 2, 3, "Matemática", null, 1, 0 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CursoId", "Nome", "PreRequisitoId", "ProfessorId", "cargaHoraria" },
                values: new object[] { 3, 3, "Física", null, 2, 0 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CursoId", "Nome", "PreRequisitoId", "ProfessorId", "cargaHoraria" },
                values: new object[] { 4, 1, "Português", null, 3, 0 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CursoId", "Nome", "PreRequisitoId", "ProfessorId", "cargaHoraria" },
                values: new object[] { 5, 1, "Inglês", null, 4, 0 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CursoId", "Nome", "PreRequisitoId", "ProfessorId", "cargaHoraria" },
                values: new object[] { 6, 2, "Inglês", null, 4, 0 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CursoId", "Nome", "PreRequisitoId", "ProfessorId", "cargaHoraria" },
                values: new object[] { 7, 3, "Inglês", null, 4, 0 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CursoId", "Nome", "PreRequisitoId", "ProfessorId", "cargaHoraria" },
                values: new object[] { 8, 1, "Programação", null, 5, 0 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CursoId", "Nome", "PreRequisitoId", "ProfessorId", "cargaHoraria" },
                values: new object[] { 9, 2, "Programação", null, 5, 0 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CursoId", "Nome", "PreRequisitoId", "ProfessorId", "cargaHoraria" },
                values: new object[] { 10, 3, "Programação", null, 5, 0 });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 2, 1, null, new DateTime(2021, 1, 7, 13, 27, 6, 550, DateTimeKind.Local).AddTicks(8873), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 4, 5, null, new DateTime(2021, 1, 7, 13, 27, 6, 550, DateTimeKind.Local).AddTicks(8891), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 2, 5, null, new DateTime(2021, 1, 7, 13, 27, 6, 550, DateTimeKind.Local).AddTicks(8880), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 1, 5, null, new DateTime(2021, 1, 7, 13, 27, 6, 550, DateTimeKind.Local).AddTicks(8871), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 7, 4, null, new DateTime(2021, 1, 7, 13, 27, 6, 550, DateTimeKind.Local).AddTicks(8908), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 6, 4, null, new DateTime(2021, 1, 7, 13, 27, 6, 550, DateTimeKind.Local).AddTicks(8902), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 5, 4, null, new DateTime(2021, 1, 7, 13, 27, 6, 550, DateTimeKind.Local).AddTicks(8893), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 4, 4, null, new DateTime(2021, 1, 7, 13, 27, 6, 550, DateTimeKind.Local).AddTicks(8890), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 1, 4, null, new DateTime(2021, 1, 7, 13, 27, 6, 550, DateTimeKind.Local).AddTicks(8848), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 7, 3, null, new DateTime(2021, 1, 7, 13, 27, 6, 550, DateTimeKind.Local).AddTicks(8906), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 5, 5, null, new DateTime(2021, 1, 7, 13, 27, 6, 550, DateTimeKind.Local).AddTicks(8894), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 6, 3, null, new DateTime(2021, 1, 7, 13, 27, 6, 550, DateTimeKind.Local).AddTicks(8899), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 7, 2, null, new DateTime(2021, 1, 7, 13, 27, 6, 550, DateTimeKind.Local).AddTicks(8905), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 6, 2, null, new DateTime(2021, 1, 7, 13, 27, 6, 550, DateTimeKind.Local).AddTicks(8897), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 3, 2, null, new DateTime(2021, 1, 7, 13, 27, 6, 550, DateTimeKind.Local).AddTicks(8883), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 2, 2, null, new DateTime(2021, 1, 7, 13, 27, 6, 550, DateTimeKind.Local).AddTicks(8875), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 1, 2, null, new DateTime(2021, 1, 7, 13, 27, 6, 550, DateTimeKind.Local).AddTicks(7615), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 7, 1, null, new DateTime(2021, 1, 7, 13, 27, 6, 550, DateTimeKind.Local).AddTicks(8903), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 6, 1, null, new DateTime(2021, 1, 7, 13, 27, 6, 550, DateTimeKind.Local).AddTicks(8896), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 4, 1, null, new DateTime(2021, 1, 7, 13, 27, 6, 550, DateTimeKind.Local).AddTicks(8888), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 3, 1, null, new DateTime(2021, 1, 7, 13, 27, 6, 550, DateTimeKind.Local).AddTicks(8882), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 3, 3, null, new DateTime(2021, 1, 7, 13, 27, 6, 550, DateTimeKind.Local).AddTicks(8885), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 7, 5, null, new DateTime(2021, 1, 7, 13, 27, 6, 550, DateTimeKind.Local).AddTicks(8909), null });

            migrationBuilder.CreateIndex(
                name: "IX_AlunosCursos_CursoId",
                table: "AlunosCursos",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunosDisciplinas_DisciplinaId",
                table: "AlunosDisciplinas",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_CursoId",
                table: "Disciplinas",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_PreRequisitoId",
                table: "Disciplinas",
                column: "PreRequisitoId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_ProfessorId",
                table: "Disciplinas",
                column: "ProfessorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunosCursos");

            migrationBuilder.DropTable(
                name: "AlunosDisciplinas");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Disciplinas");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Professores");
        }
    }
}
