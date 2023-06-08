using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: true),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "text", nullable: true),
                    LastUpdatedByUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Categories_AspNetUsers_LastUpdatedByUserId",
                        column: x => x.LastUpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CompanyTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "text", nullable: true),
                    LastUpdatedByUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyTypes_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompanyTypes_AspNetUsers_LastUpdatedByUserId",
                        column: x => x.LastUpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ContractAddendumStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "text", nullable: true),
                    LastUpdatedByUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractAddendumStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractAddendumStatus_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContractAddendumStatus_AspNetUsers_LastUpdatedByUserId",
                        column: x => x.LastUpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ContractDocumentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "text", nullable: true),
                    LastUpdatedByUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractDocumentTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractDocumentTypes_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContractDocumentTypes_AspNetUsers_LastUpdatedByUserId",
                        column: x => x.LastUpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ContractDraftStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "text", nullable: true),
                    LastUpdatedByUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractDraftStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractDraftStatus_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContractDraftStatus_AspNetUsers_LastUpdatedByUserId",
                        column: x => x.LastUpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ContractElaborationStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "text", nullable: true),
                    LastUpdatedByUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractElaborationStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractElaborationStatus_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContractElaborationStatus_AspNetUsers_LastUpdatedByUserId",
                        column: x => x.LastUpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ContractLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "text", nullable: true),
                    LastUpdatedByUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractLanguages_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContractLanguages_AspNetUsers_LastUpdatedByUserId",
                        column: x => x.LastUpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ContractRequisitionStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "text", nullable: true),
                    LastUpdatedByUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractRequisitionStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractRequisitionStatus_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContractRequisitionStatus_AspNetUsers_LastUpdatedByUserId",
                        column: x => x.LastUpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ContractStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "text", nullable: true),
                    LastUpdatedByUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractStatus_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContractStatus_AspNetUsers_LastUpdatedByUserId",
                        column: x => x.LastUpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ContractTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Template = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "text", nullable: true),
                    LastUpdatedByUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractTypes_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContractTypes_AspNetUsers_LastUpdatedByUserId",
                        column: x => x.LastUpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "text", nullable: true),
                    LastUpdatedByUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Countries_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Countries_AspNetUsers_LastUpdatedByUserId",
                        column: x => x.LastUpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "text", nullable: true),
                    LastUpdatedByUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Currency_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Currency_AspNetUsers_LastUpdatedByUserId",
                        column: x => x.LastUpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ManagerId = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "text", nullable: true),
                    LastUpdatedByUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Departments_AspNetUsers_LastUpdatedByUserId",
                        column: x => x.LastUpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Departments_AspNetUsers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Key = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "text", nullable: true),
                    LastUpdatedByUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Settings_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Settings_AspNetUsers_LastUpdatedByUserId",
                        column: x => x.LastUpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SupplierTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "text", nullable: true),
                    LastUpdatedByUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupplierTypes_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SupplierTypes_AspNetUsers_LastUpdatedByUserId",
                        column: x => x.LastUpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SystemLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "text", nullable: true),
                    LastUpdatedByUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemLanguages_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SystemLanguages_AspNetUsers_LastUpdatedByUserId",
                        column: x => x.LastUpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ContractRequisitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false),
                    RequisitionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RequestedById = table.Column<string>(type: "text", nullable: false),
                    ContractTypeId = table.Column<int>(type: "integer", nullable: false),
                    ContractTerms = table.Column<string>(type: "text", nullable: false),
                    DepartmentId = table.Column<int>(type: "integer", nullable: false),
                    ContractRequisitionStatusId = table.Column<int>(type: "integer", nullable: false),
                    CurrentApprovalLine = table.Column<int>(type: "integer", nullable: false),
                    AcknowlegedById = table.Column<string>(type: "text", nullable: false),
                    AcknowlegedByAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ContractLanguageId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "text", nullable: true),
                    LastUpdatedByUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractRequisitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractRequisitions_AspNetUsers_AcknowlegedById",
                        column: x => x.AcknowlegedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractRequisitions_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContractRequisitions_AspNetUsers_LastUpdatedByUserId",
                        column: x => x.LastUpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContractRequisitions_AspNetUsers_RequestedById",
                        column: x => x.RequestedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractRequisitions_ContractLanguages_ContractLanguageId",
                        column: x => x.ContractLanguageId,
                        principalTable: "ContractLanguages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractRequisitions_ContractRequisitionStatus_ContractRequ~",
                        column: x => x.ContractRequisitionStatusId,
                        principalTable: "ContractRequisitionStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractRequisitions_ContractTypes_ContractTypeId",
                        column: x => x.ContractTypeId,
                        principalTable: "ContractTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractRequisitions_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CountryId = table.Column<int>(type: "integer", nullable: false),
                    SupplierTypeId = table.Column<int>(type: "integer", nullable: false),
                    CompanyTypeId = table.Column<int>(type: "integer", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    RegistrationNumber = table.Column<string>(type: "text", nullable: false),
                    LegalName = table.Column<string>(type: "text", nullable: false),
                    TradeName = table.Column<string>(type: "text", nullable: false),
                    Domicillium = table.Column<string>(type: "text", nullable: false),
                    CurrencyId = table.Column<int>(type: "integer", nullable: false),
                    VatNumber = table.Column<string>(type: "text", nullable: false),
                    Telephone = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Mobile = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    PostalCode = table.Column<string>(type: "text", nullable: false),
                    ContactPerson = table.Column<string>(type: "text", nullable: false),
                    ContactPersonTelephone = table.Column<string>(type: "text", nullable: false),
                    ContactPersonEmail = table.Column<string>(type: "text", nullable: false),
                    ContactPersonMobile = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "text", nullable: true),
                    LastUpdatedByUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suppliers_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Suppliers_AspNetUsers_LastUpdatedByUserId",
                        column: x => x.LastUpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Suppliers_CompanyTypes_CompanyTypeId",
                        column: x => x.CompanyTypeId,
                        principalTable: "CompanyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Suppliers_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Suppliers_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Suppliers_SupplierTypes_SupplierTypeId",
                        column: x => x.SupplierTypeId,
                        principalTable: "SupplierTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractElaborations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ContractRequisitionId = table.Column<int>(type: "integer", nullable: false),
                    ElaborationStartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ElaborationEndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    StartedById = table.Column<string>(type: "text", nullable: false),
                    ContractElaborationStatusId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "text", nullable: true),
                    LastUpdatedByUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractElaborations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractElaborations_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContractElaborations_AspNetUsers_LastUpdatedByUserId",
                        column: x => x.LastUpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContractElaborations_AspNetUsers_StartedById",
                        column: x => x.StartedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractElaborations_ContractElaborationStatus_ContractElab~",
                        column: x => x.ContractElaborationStatusId,
                        principalTable: "ContractElaborationStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractElaborations_ContractRequisitions_ContractRequisiti~",
                        column: x => x.ContractRequisitionId,
                        principalTable: "ContractRequisitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractRequisitionApprovals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ContractRequisitionId = table.Column<int>(type: "integer", nullable: false),
                    ApprovalDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ApprovedById = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    ApprovalLine = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "text", nullable: true),
                    LastUpdatedByUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractRequisitionApprovals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractRequisitionApprovals_AspNetUsers_ApprovedById",
                        column: x => x.ApprovedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractRequisitionApprovals_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContractRequisitionApprovals_AspNetUsers_LastUpdatedByUserId",
                        column: x => x.LastUpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContractRequisitionApprovals_ContractRequisitions_ContractR~",
                        column: x => x.ContractRequisitionId,
                        principalTable: "ContractRequisitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractRequisitionDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ContractRequisitionId = table.Column<int>(type: "integer", nullable: false),
                    DocumentName = table.Column<string>(type: "text", nullable: false),
                    DocumentToken = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "text", nullable: true),
                    LastUpdatedByUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractRequisitionDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractRequisitionDocuments_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContractRequisitionDocuments_AspNetUsers_LastUpdatedByUserId",
                        column: x => x.LastUpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContractRequisitionDocuments_ContractRequisitions_ContractR~",
                        column: x => x.ContractRequisitionId,
                        principalTable: "ContractRequisitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractRequisitionQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ContractRequisitionId = table.Column<int>(type: "integer", nullable: false),
                    PostDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PostedById = table.Column<string>(type: "text", nullable: false),
                    Question = table.Column<string>(type: "text", nullable: false),
                    Answer = table.Column<string>(type: "text", nullable: false),
                    Document = table.Column<string>(type: "text", nullable: true),
                    AnsweredById = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "text", nullable: true),
                    LastUpdatedByUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractRequisitionQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractRequisitionQuestions_AspNetUsers_AnsweredById",
                        column: x => x.AnsweredById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractRequisitionQuestions_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContractRequisitionQuestions_AspNetUsers_LastUpdatedByUserId",
                        column: x => x.LastUpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContractRequisitionQuestions_AspNetUsers_PostedById",
                        column: x => x.PostedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractRequisitionQuestions_ContractRequisitions_ContractR~",
                        column: x => x.ContractRequisitionId,
                        principalTable: "ContractRequisitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SupplierId = table.Column<int>(type: "integer", nullable: false),
                    ContractTypeId = table.Column<int>(type: "integer", nullable: false),
                    CurrencyId = table.Column<int>(type: "integer", nullable: false),
                    ContractValue = table.Column<double>(type: "double precision", nullable: false),
                    ContractManagerId = table.Column<string>(type: "text", nullable: false),
                    ContractStatusId = table.Column<int>(type: "integer", nullable: false),
                    DepartmentId = table.Column<int>(type: "integer", nullable: false),
                    DateSigned = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ContractSignedDocument = table.Column<string>(type: "text", nullable: false),
                    ContractLanguageId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "text", nullable: true),
                    LastUpdatedByUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_AspNetUsers_ContractManagerId",
                        column: x => x.ContractManagerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contracts_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contracts_AspNetUsers_LastUpdatedByUserId",
                        column: x => x.LastUpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contracts_ContractLanguages_ContractLanguageId",
                        column: x => x.ContractLanguageId,
                        principalTable: "ContractLanguages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contracts_ContractStatus_ContractStatusId",
                        column: x => x.ContractStatusId,
                        principalTable: "ContractStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contracts_ContractTypes_ContractTypeId",
                        column: x => x.ContractTypeId,
                        principalTable: "ContractTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contracts_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contracts_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contracts_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractElaborationsDrafts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ContractElaborationId = table.Column<int>(type: "integer", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    CurrentVersion = table.Column<bool>(type: "boolean", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false),
                    VersionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Comments = table.Column<string>(type: "text", nullable: false),
                    CreatedById = table.Column<string>(type: "text", nullable: false),
                    ContractDraftStatusId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "text", nullable: true),
                    LastUpdatedByUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractElaborationsDrafts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractElaborationsDrafts_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractElaborationsDrafts_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContractElaborationsDrafts_AspNetUsers_LastUpdatedByUserId",
                        column: x => x.LastUpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContractElaborationsDrafts_ContractDraftStatus_ContractDraf~",
                        column: x => x.ContractDraftStatusId,
                        principalTable: "ContractDraftStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractElaborationsDrafts_ContractElaborations_ContractEla~",
                        column: x => x.ContractElaborationId,
                        principalTable: "ContractElaborations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractElaborationStatusHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ContractElaborationId = table.Column<int>(type: "integer", nullable: false),
                    ActionerId = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Comments = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "text", nullable: true),
                    LastUpdatedByUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractElaborationStatusHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractElaborationStatusHistories_AspNetUsers_ActionerId",
                        column: x => x.ActionerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractElaborationStatusHistories_AspNetUsers_CreatedByUse~",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContractElaborationStatusHistories_AspNetUsers_LastUpdatedB~",
                        column: x => x.LastUpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContractElaborationStatusHistories_ContractElaborations_Con~",
                        column: x => x.ContractElaborationId,
                        principalTable: "ContractElaborations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractAddenda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ContractId = table.Column<int>(type: "integer", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    LongDescription = table.Column<string>(type: "text", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AddendumValue = table.Column<double>(type: "double precision", nullable: false),
                    ContractAddendumStatusId = table.Column<int>(type: "integer", nullable: false),
                    AddendumDocument = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "text", nullable: true),
                    LastUpdatedByUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractAddenda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractAddenda_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContractAddenda_AspNetUsers_LastUpdatedByUserId",
                        column: x => x.LastUpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContractAddenda_ContractAddendumStatus_ContractAddendumStat~",
                        column: x => x.ContractAddendumStatusId,
                        principalTable: "ContractAddendumStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractAddenda_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractContactDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ContractId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Mobile = table.Column<string>(type: "text", nullable: false),
                    TelephoneCode = table.Column<string>(type: "text", nullable: false),
                    Telephone = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "text", nullable: true),
                    LastUpdatedByUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractContactDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractContactDetails_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContractContactDetails_AspNetUsers_LastUpdatedByUserId",
                        column: x => x.LastUpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContractContactDetails_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ContractId = table.Column<int>(type: "integer", nullable: false),
                    ContractDocumentTypeId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: false),
                    Validity = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "text", nullable: true),
                    LastUpdatedByUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractDocuments_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContractDocuments_AspNetUsers_LastUpdatedByUserId",
                        column: x => x.LastUpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContractDocuments_ContractDocumentTypes_ContractDocumentTyp~",
                        column: x => x.ContractDocumentTypeId,
                        principalTable: "ContractDocumentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractDocuments_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractMonitoring",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ContractId = table.Column<int>(type: "integer", nullable: false),
                    ContactPerson = table.Column<string>(type: "text", nullable: false),
                    ContactEmail = table.Column<string>(type: "text", nullable: false),
                    MonitoringDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Reason = table.Column<string>(type: "text", nullable: false),
                    FeedbackDocument = table.Column<string>(type: "text", nullable: false),
                    DueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ActualDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ActionTaken = table.Column<string>(type: "text", nullable: false),
                    WayFoward = table.Column<string>(type: "text", nullable: false),
                    AddressedById = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "text", nullable: true),
                    LastUpdatedByUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractMonitoring", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractMonitoring_AspNetUsers_AddressedById",
                        column: x => x.AddressedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractMonitoring_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContractMonitoring_AspNetUsers_LastUpdatedByUserId",
                        column: x => x.LastUpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContractMonitoring_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractPaymentSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ContractId = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Deliverables = table.Column<string>(type: "text", nullable: false),
                    QualityIndicators = table.Column<string>(type: "text", nullable: false),
                    DueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Amount = table.Column<double>(type: "double precision", nullable: false),
                    Completed = table.Column<bool>(type: "boolean", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ProofOfPaymentUrl = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "text", nullable: true),
                    LastUpdatedByUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractPaymentSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractPaymentSchedules_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContractPaymentSchedules_AspNetUsers_LastUpdatedByUserId",
                        column: x => x.LastUpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContractPaymentSchedules_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractStatusHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ContractId = table.Column<int>(type: "integer", nullable: false),
                    ApproverId = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    ApprovalDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Comments = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "text", nullable: true),
                    LastUpdatedByUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractStatusHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractStatusHistories_AspNetUsers_ApproverId",
                        column: x => x.ApproverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractStatusHistories_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContractStatusHistories_AspNetUsers_LastUpdatedByUserId",
                        column: x => x.LastUpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContractStatusHistories_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractTaxCertificateHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ContractId = table.Column<int>(type: "integer", nullable: false),
                    TaxStartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TaxEndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TaxCertificateDocument = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "text", nullable: true),
                    LastUpdatedByUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractTaxCertificateHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractTaxCertificateHistories_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContractTaxCertificateHistories_AspNetUsers_LastUpdatedByUs~",
                        column: x => x.LastUpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContractTaxCertificateHistories_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractTerminations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ContractId = table.Column<int>(type: "integer", nullable: false),
                    TerminationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TerminationReason = table.Column<string>(type: "text", nullable: false),
                    TerminatedById = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "text", nullable: true),
                    LastUpdatedByUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractTerminations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractTerminations_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContractTerminations_AspNetUsers_LastUpdatedByUserId",
                        column: x => x.LastUpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContractTerminations_AspNetUsers_TerminatedById",
                        column: x => x.TerminatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractTerminations_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractElaborationDraftComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ContractElaborationDraftId = table.Column<int>(type: "integer", nullable: false),
                    PostDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PostedById = table.Column<string>(type: "text", nullable: false),
                    Question = table.Column<string>(type: "text", nullable: false),
                    Answer = table.Column<string>(type: "text", nullable: true),
                    AnsweredById = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "text", nullable: true),
                    LastUpdatedByUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractElaborationDraftComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractElaborationDraftComments_AspNetUsers_AnsweredById",
                        column: x => x.AnsweredById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractElaborationDraftComments_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContractElaborationDraftComments_AspNetUsers_LastUpdatedByU~",
                        column: x => x.LastUpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContractElaborationDraftComments_AspNetUsers_PostedById",
                        column: x => x.PostedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractElaborationDraftComments_ContractElaborationsDrafts~",
                        column: x => x.ContractElaborationDraftId,
                        principalTable: "ContractElaborationsDrafts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractPaymentScheduledChecklists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ContractPaymentScheduleId = table.Column<int>(type: "integer", nullable: false),
                    Desciption = table.Column<string>(type: "text", nullable: false),
                    Done = table.Column<bool>(type: "boolean", nullable: false),
                    DueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "text", nullable: true),
                    LastUpdatedByUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractPaymentScheduledChecklists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractPaymentScheduledChecklists_AspNetUsers_CreatedByUse~",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContractPaymentScheduledChecklists_AspNetUsers_LastUpdatedB~",
                        column: x => x.LastUpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContractPaymentScheduledChecklists_ContractPaymentSchedules~",
                        column: x => x.ContractPaymentScheduleId,
                        principalTable: "ContractPaymentSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractPaymentScheduleSupplierDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ContractPaymentScheduleId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    DocumentUrl = table.Column<string>(type: "text", nullable: false),
                    SubmittedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "text", nullable: true),
                    LastUpdatedByUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractPaymentScheduleSupplierDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractPaymentScheduleSupplierDocuments_AspNetUsers_Create~",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContractPaymentScheduleSupplierDocuments_AspNetUsers_LastUp~",
                        column: x => x.LastUpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContractPaymentScheduleSupplierDocuments_ContractPaymentSch~",
                        column: x => x.ContractPaymentScheduleId,
                        principalTable: "ContractPaymentSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CreatedByUserId",
                table: "Categories",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_LastUpdatedByUserId",
                table: "Categories",
                column: "LastUpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyTypes_CreatedByUserId",
                table: "CompanyTypes",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyTypes_LastUpdatedByUserId",
                table: "CompanyTypes",
                column: "LastUpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractAddenda_ContractAddendumStatusId",
                table: "ContractAddenda",
                column: "ContractAddendumStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractAddenda_ContractId",
                table: "ContractAddenda",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractAddenda_CreatedByUserId",
                table: "ContractAddenda",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractAddenda_LastUpdatedByUserId",
                table: "ContractAddenda",
                column: "LastUpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractAddendumStatus_CreatedByUserId",
                table: "ContractAddendumStatus",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractAddendumStatus_LastUpdatedByUserId",
                table: "ContractAddendumStatus",
                column: "LastUpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractContactDetails_ContractId",
                table: "ContractContactDetails",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractContactDetails_CreatedByUserId",
                table: "ContractContactDetails",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractContactDetails_LastUpdatedByUserId",
                table: "ContractContactDetails",
                column: "LastUpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractDocuments_ContractDocumentTypeId",
                table: "ContractDocuments",
                column: "ContractDocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractDocuments_ContractId",
                table: "ContractDocuments",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractDocuments_CreatedByUserId",
                table: "ContractDocuments",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractDocuments_LastUpdatedByUserId",
                table: "ContractDocuments",
                column: "LastUpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractDocumentTypes_CreatedByUserId",
                table: "ContractDocumentTypes",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractDocumentTypes_LastUpdatedByUserId",
                table: "ContractDocumentTypes",
                column: "LastUpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractDraftStatus_CreatedByUserId",
                table: "ContractDraftStatus",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractDraftStatus_LastUpdatedByUserId",
                table: "ContractDraftStatus",
                column: "LastUpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractElaborationDraftComments_AnsweredById",
                table: "ContractElaborationDraftComments",
                column: "AnsweredById");

            migrationBuilder.CreateIndex(
                name: "IX_ContractElaborationDraftComments_ContractElaborationDraftId",
                table: "ContractElaborationDraftComments",
                column: "ContractElaborationDraftId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractElaborationDraftComments_CreatedByUserId",
                table: "ContractElaborationDraftComments",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractElaborationDraftComments_LastUpdatedByUserId",
                table: "ContractElaborationDraftComments",
                column: "LastUpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractElaborationDraftComments_PostedById",
                table: "ContractElaborationDraftComments",
                column: "PostedById");

            migrationBuilder.CreateIndex(
                name: "IX_ContractElaborations_ContractElaborationStatusId",
                table: "ContractElaborations",
                column: "ContractElaborationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractElaborations_ContractRequisitionId",
                table: "ContractElaborations",
                column: "ContractRequisitionId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractElaborations_CreatedByUserId",
                table: "ContractElaborations",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractElaborations_LastUpdatedByUserId",
                table: "ContractElaborations",
                column: "LastUpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractElaborations_StartedById",
                table: "ContractElaborations",
                column: "StartedById");

            migrationBuilder.CreateIndex(
                name: "IX_ContractElaborationsDrafts_ContractDraftStatusId",
                table: "ContractElaborationsDrafts",
                column: "ContractDraftStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractElaborationsDrafts_ContractElaborationId",
                table: "ContractElaborationsDrafts",
                column: "ContractElaborationId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractElaborationsDrafts_CreatedById",
                table: "ContractElaborationsDrafts",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ContractElaborationsDrafts_CreatedByUserId",
                table: "ContractElaborationsDrafts",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractElaborationsDrafts_LastUpdatedByUserId",
                table: "ContractElaborationsDrafts",
                column: "LastUpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractElaborationStatus_CreatedByUserId",
                table: "ContractElaborationStatus",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractElaborationStatus_LastUpdatedByUserId",
                table: "ContractElaborationStatus",
                column: "LastUpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractElaborationStatusHistories_ActionerId",
                table: "ContractElaborationStatusHistories",
                column: "ActionerId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractElaborationStatusHistories_ContractElaborationId",
                table: "ContractElaborationStatusHistories",
                column: "ContractElaborationId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractElaborationStatusHistories_CreatedByUserId",
                table: "ContractElaborationStatusHistories",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractElaborationStatusHistories_LastUpdatedByUserId",
                table: "ContractElaborationStatusHistories",
                column: "LastUpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractLanguages_CreatedByUserId",
                table: "ContractLanguages",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractLanguages_LastUpdatedByUserId",
                table: "ContractLanguages",
                column: "LastUpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractMonitoring_AddressedById",
                table: "ContractMonitoring",
                column: "AddressedById");

            migrationBuilder.CreateIndex(
                name: "IX_ContractMonitoring_ContractId",
                table: "ContractMonitoring",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractMonitoring_CreatedByUserId",
                table: "ContractMonitoring",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractMonitoring_LastUpdatedByUserId",
                table: "ContractMonitoring",
                column: "LastUpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractPaymentScheduledChecklists_ContractPaymentScheduleId",
                table: "ContractPaymentScheduledChecklists",
                column: "ContractPaymentScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractPaymentScheduledChecklists_CreatedByUserId",
                table: "ContractPaymentScheduledChecklists",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractPaymentScheduledChecklists_LastUpdatedByUserId",
                table: "ContractPaymentScheduledChecklists",
                column: "LastUpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractPaymentSchedules_ContractId",
                table: "ContractPaymentSchedules",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractPaymentSchedules_CreatedByUserId",
                table: "ContractPaymentSchedules",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractPaymentSchedules_LastUpdatedByUserId",
                table: "ContractPaymentSchedules",
                column: "LastUpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractPaymentScheduleSupplierDocuments_ContractPaymentSch~",
                table: "ContractPaymentScheduleSupplierDocuments",
                column: "ContractPaymentScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractPaymentScheduleSupplierDocuments_CreatedByUserId",
                table: "ContractPaymentScheduleSupplierDocuments",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractPaymentScheduleSupplierDocuments_LastUpdatedByUserId",
                table: "ContractPaymentScheduleSupplierDocuments",
                column: "LastUpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractRequisitionApprovals_ApprovedById",
                table: "ContractRequisitionApprovals",
                column: "ApprovedById");

            migrationBuilder.CreateIndex(
                name: "IX_ContractRequisitionApprovals_ContractRequisitionId",
                table: "ContractRequisitionApprovals",
                column: "ContractRequisitionId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractRequisitionApprovals_CreatedByUserId",
                table: "ContractRequisitionApprovals",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractRequisitionApprovals_LastUpdatedByUserId",
                table: "ContractRequisitionApprovals",
                column: "LastUpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractRequisitionDocuments_ContractRequisitionId",
                table: "ContractRequisitionDocuments",
                column: "ContractRequisitionId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractRequisitionDocuments_CreatedByUserId",
                table: "ContractRequisitionDocuments",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractRequisitionDocuments_LastUpdatedByUserId",
                table: "ContractRequisitionDocuments",
                column: "LastUpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractRequisitionQuestions_AnsweredById",
                table: "ContractRequisitionQuestions",
                column: "AnsweredById");

            migrationBuilder.CreateIndex(
                name: "IX_ContractRequisitionQuestions_ContractRequisitionId",
                table: "ContractRequisitionQuestions",
                column: "ContractRequisitionId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractRequisitionQuestions_CreatedByUserId",
                table: "ContractRequisitionQuestions",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractRequisitionQuestions_LastUpdatedByUserId",
                table: "ContractRequisitionQuestions",
                column: "LastUpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractRequisitionQuestions_PostedById",
                table: "ContractRequisitionQuestions",
                column: "PostedById");

            migrationBuilder.CreateIndex(
                name: "IX_ContractRequisitions_AcknowlegedById",
                table: "ContractRequisitions",
                column: "AcknowlegedById");

            migrationBuilder.CreateIndex(
                name: "IX_ContractRequisitions_ContractLanguageId",
                table: "ContractRequisitions",
                column: "ContractLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractRequisitions_ContractRequisitionStatusId",
                table: "ContractRequisitions",
                column: "ContractRequisitionStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractRequisitions_ContractTypeId",
                table: "ContractRequisitions",
                column: "ContractTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractRequisitions_CreatedByUserId",
                table: "ContractRequisitions",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractRequisitions_DepartmentId",
                table: "ContractRequisitions",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractRequisitions_LastUpdatedByUserId",
                table: "ContractRequisitions",
                column: "LastUpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractRequisitions_RequestedById",
                table: "ContractRequisitions",
                column: "RequestedById");

            migrationBuilder.CreateIndex(
                name: "IX_ContractRequisitionStatus_CreatedByUserId",
                table: "ContractRequisitionStatus",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractRequisitionStatus_LastUpdatedByUserId",
                table: "ContractRequisitionStatus",
                column: "LastUpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ContractLanguageId",
                table: "Contracts",
                column: "ContractLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ContractManagerId",
                table: "Contracts",
                column: "ContractManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ContractStatusId",
                table: "Contracts",
                column: "ContractStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ContractTypeId",
                table: "Contracts",
                column: "ContractTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_CreatedByUserId",
                table: "Contracts",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_CurrencyId",
                table: "Contracts",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_DepartmentId",
                table: "Contracts",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_LastUpdatedByUserId",
                table: "Contracts",
                column: "LastUpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_SupplierId",
                table: "Contracts",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractStatus_CreatedByUserId",
                table: "ContractStatus",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractStatus_LastUpdatedByUserId",
                table: "ContractStatus",
                column: "LastUpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractStatusHistories_ApproverId",
                table: "ContractStatusHistories",
                column: "ApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractStatusHistories_ContractId",
                table: "ContractStatusHistories",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractStatusHistories_CreatedByUserId",
                table: "ContractStatusHistories",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractStatusHistories_LastUpdatedByUserId",
                table: "ContractStatusHistories",
                column: "LastUpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractTaxCertificateHistories_ContractId",
                table: "ContractTaxCertificateHistories",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractTaxCertificateHistories_CreatedByUserId",
                table: "ContractTaxCertificateHistories",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractTaxCertificateHistories_LastUpdatedByUserId",
                table: "ContractTaxCertificateHistories",
                column: "LastUpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractTerminations_ContractId",
                table: "ContractTerminations",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractTerminations_CreatedByUserId",
                table: "ContractTerminations",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractTerminations_LastUpdatedByUserId",
                table: "ContractTerminations",
                column: "LastUpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractTerminations_TerminatedById",
                table: "ContractTerminations",
                column: "TerminatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ContractTypes_CreatedByUserId",
                table: "ContractTypes",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractTypes_LastUpdatedByUserId",
                table: "ContractTypes",
                column: "LastUpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CreatedByUserId",
                table: "Countries",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_LastUpdatedByUserId",
                table: "Countries",
                column: "LastUpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Currency_CreatedByUserId",
                table: "Currency",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Currency_LastUpdatedByUserId",
                table: "Currency",
                column: "LastUpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_CreatedByUserId",
                table: "Departments",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_LastUpdatedByUserId",
                table: "Departments",
                column: "LastUpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ManagerId",
                table: "Departments",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Settings_CreatedByUserId",
                table: "Settings",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Settings_LastUpdatedByUserId",
                table: "Settings",
                column: "LastUpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_CompanyTypeId",
                table: "Suppliers",
                column: "CompanyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_CountryId",
                table: "Suppliers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_CreatedByUserId",
                table: "Suppliers",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_CurrencyId",
                table: "Suppliers",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_LastUpdatedByUserId",
                table: "Suppliers",
                column: "LastUpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_SupplierTypeId",
                table: "Suppliers",
                column: "SupplierTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierTypes_CreatedByUserId",
                table: "SupplierTypes",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierTypes_LastUpdatedByUserId",
                table: "SupplierTypes",
                column: "LastUpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemLanguages_CreatedByUserId",
                table: "SystemLanguages",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemLanguages_LastUpdatedByUserId",
                table: "SystemLanguages",
                column: "LastUpdatedByUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "ContractAddenda");

            migrationBuilder.DropTable(
                name: "ContractContactDetails");

            migrationBuilder.DropTable(
                name: "ContractDocuments");

            migrationBuilder.DropTable(
                name: "ContractElaborationDraftComments");

            migrationBuilder.DropTable(
                name: "ContractElaborationStatusHistories");

            migrationBuilder.DropTable(
                name: "ContractMonitoring");

            migrationBuilder.DropTable(
                name: "ContractPaymentScheduledChecklists");

            migrationBuilder.DropTable(
                name: "ContractPaymentScheduleSupplierDocuments");

            migrationBuilder.DropTable(
                name: "ContractRequisitionApprovals");

            migrationBuilder.DropTable(
                name: "ContractRequisitionDocuments");

            migrationBuilder.DropTable(
                name: "ContractRequisitionQuestions");

            migrationBuilder.DropTable(
                name: "ContractStatusHistories");

            migrationBuilder.DropTable(
                name: "ContractTaxCertificateHistories");

            migrationBuilder.DropTable(
                name: "ContractTerminations");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "SystemLanguages");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "ContractAddendumStatus");

            migrationBuilder.DropTable(
                name: "ContractDocumentTypes");

            migrationBuilder.DropTable(
                name: "ContractElaborationsDrafts");

            migrationBuilder.DropTable(
                name: "ContractPaymentSchedules");

            migrationBuilder.DropTable(
                name: "ContractDraftStatus");

            migrationBuilder.DropTable(
                name: "ContractElaborations");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "ContractElaborationStatus");

            migrationBuilder.DropTable(
                name: "ContractRequisitions");

            migrationBuilder.DropTable(
                name: "ContractStatus");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "ContractLanguages");

            migrationBuilder.DropTable(
                name: "ContractRequisitionStatus");

            migrationBuilder.DropTable(
                name: "ContractTypes");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "CompanyTypes");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "SupplierTypes");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
