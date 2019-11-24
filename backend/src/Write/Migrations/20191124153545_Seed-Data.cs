using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Write.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Participant",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("cfadef58-7e49-48a3-a5d9-3908ea697485"), "João ¯\\_(ツ)_/¯" },
                    { new Guid("6da09535-93ee-42cf-96f7-25413b1e6eef"), "Ruan" },
                    { new Guid("e1f4f4c7-d90b-4bab-8574-a5bf8ff55ea4"), "Roberta" },
                    { new Guid("55b27271-9cfd-424e-a25e-8d602202f1c1"), "Ralf" },
                    { new Guid("b38f6363-8ede-4cff-8b77-7bfa5283dcab"), "Rafael S." },
                    { new Guid("9d378fd2-40b7-401a-bae6-70da9a838d6c"), "Paulo" },
                    { new Guid("d76a955f-e147-4315-8420-9542afc0f836"), "Michele" },
                    { new Guid("db23fc9f-d7ad-4e9f-a158-86aec07da5f0"), "Marcus J." },
                    { new Guid("3b6a288b-42db-4703-b45d-ed61b7e2821c"), "Leonardo" },
                    { new Guid("8853e2af-055c-41d1-98e1-7d575ac349dc"), "Gabriel" },
                    { new Guid("ab2ac39e-81a3-4a7f-ba9b-f549d1260103"), "Fernando" },
                    { new Guid("665003e4-a2f4-414e-a8bf-f7fbaab7899c"), "Diego P." },
                    { new Guid("4ac5b952-7410-48d9-bed0-16a0abc58a9d"), "Diego B." },
                    { new Guid("cec8d6af-ee1c-4af5-bfac-eb9bafa71af8"), "Beto" },
                    { new Guid("c793f46a-d193-4135-9a0c-416c1969fb9d"), "Alexandre M." },
                    { new Guid("48c92f90-9e4a-4a9d-8e45-b18b7466538b"), "Alice" },
                    { new Guid("1788833b-35b0-4d06-8df7-6d7549a42c47"), "Thales" },
                    { new Guid("87da9f96-5c8b-47da-b549-ddf948040efc"), "Wait" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Participant",
                keyColumn: "Id",
                keyValue: new Guid("1788833b-35b0-4d06-8df7-6d7549a42c47"));

            migrationBuilder.DeleteData(
                table: "Participant",
                keyColumn: "Id",
                keyValue: new Guid("3b6a288b-42db-4703-b45d-ed61b7e2821c"));

            migrationBuilder.DeleteData(
                table: "Participant",
                keyColumn: "Id",
                keyValue: new Guid("48c92f90-9e4a-4a9d-8e45-b18b7466538b"));

            migrationBuilder.DeleteData(
                table: "Participant",
                keyColumn: "Id",
                keyValue: new Guid("4ac5b952-7410-48d9-bed0-16a0abc58a9d"));

            migrationBuilder.DeleteData(
                table: "Participant",
                keyColumn: "Id",
                keyValue: new Guid("55b27271-9cfd-424e-a25e-8d602202f1c1"));

            migrationBuilder.DeleteData(
                table: "Participant",
                keyColumn: "Id",
                keyValue: new Guid("665003e4-a2f4-414e-a8bf-f7fbaab7899c"));

            migrationBuilder.DeleteData(
                table: "Participant",
                keyColumn: "Id",
                keyValue: new Guid("6da09535-93ee-42cf-96f7-25413b1e6eef"));

            migrationBuilder.DeleteData(
                table: "Participant",
                keyColumn: "Id",
                keyValue: new Guid("87da9f96-5c8b-47da-b549-ddf948040efc"));

            migrationBuilder.DeleteData(
                table: "Participant",
                keyColumn: "Id",
                keyValue: new Guid("8853e2af-055c-41d1-98e1-7d575ac349dc"));

            migrationBuilder.DeleteData(
                table: "Participant",
                keyColumn: "Id",
                keyValue: new Guid("9d378fd2-40b7-401a-bae6-70da9a838d6c"));

            migrationBuilder.DeleteData(
                table: "Participant",
                keyColumn: "Id",
                keyValue: new Guid("ab2ac39e-81a3-4a7f-ba9b-f549d1260103"));

            migrationBuilder.DeleteData(
                table: "Participant",
                keyColumn: "Id",
                keyValue: new Guid("b38f6363-8ede-4cff-8b77-7bfa5283dcab"));

            migrationBuilder.DeleteData(
                table: "Participant",
                keyColumn: "Id",
                keyValue: new Guid("c793f46a-d193-4135-9a0c-416c1969fb9d"));

            migrationBuilder.DeleteData(
                table: "Participant",
                keyColumn: "Id",
                keyValue: new Guid("cec8d6af-ee1c-4af5-bfac-eb9bafa71af8"));

            migrationBuilder.DeleteData(
                table: "Participant",
                keyColumn: "Id",
                keyValue: new Guid("cfadef58-7e49-48a3-a5d9-3908ea697485"));

            migrationBuilder.DeleteData(
                table: "Participant",
                keyColumn: "Id",
                keyValue: new Guid("d76a955f-e147-4315-8420-9542afc0f836"));

            migrationBuilder.DeleteData(
                table: "Participant",
                keyColumn: "Id",
                keyValue: new Guid("db23fc9f-d7ad-4e9f-a158-86aec07da5f0"));

            migrationBuilder.DeleteData(
                table: "Participant",
                keyColumn: "Id",
                keyValue: new Guid("e1f4f4c7-d90b-4bab-8574-a5bf8ff55ea4"));
        }
    }
}
