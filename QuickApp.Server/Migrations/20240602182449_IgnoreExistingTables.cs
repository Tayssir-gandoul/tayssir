using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class IgnoreExistingTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Vérification de l'existence de la table AppCompteures
            migrationBuilder.Sql(@"
                IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AppCompteures]') AND type in (N'U'))
                BEGIN
                    CREATE TABLE [AppCompteures] (
                        [Id] int NOT NULL IDENTITY,
                        [Reference] int NOT NULL,
                        [NouveauIndex] int NOT NULL,
                        [AncienIndex] int NOT NULL,
                        [DateInstallation] datetime2 NOT NULL,
                        [Adresse] nvarchar(50) NOT NULL,
                        [District] nvarchar(50) NOT NULL,
                        [AncienIndexJour] int NOT NULL,
                        [AncienIndexNuit] int NOT NULL,
                        [AncienIndexPointe] int NOT NULL,
                        [CreatedBy] nvarchar(40) NULL,
                        [UpdatedBy] nvarchar(40) NULL,
                        [UpdatedDate] datetime2 NOT NULL,
                        [CreatedDate] datetime2 NOT NULL,
                        CONSTRAINT [PK_AppCompteures] PRIMARY KEY ([Id])
                    );
                END
            ");

            // Vérification de l'existence de la table AspNetRoles
            migrationBuilder.Sql(@"
                IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetRoles]') AND type in (N'U'))
                BEGIN
                    CREATE TABLE [AspNetRoles] (
                        [Id] nvarchar(450) NOT NULL,
                        [Description] nvarchar(max) NULL,
                        [CreatedBy] nvarchar(max) NULL,
                        [UpdatedBy] nvarchar(max) NULL,
                        [CreatedDate] datetime2 NOT NULL,
                        [UpdatedDate] datetime2 NOT NULL,
                        [Name] nvarchar(256) NULL,
                        [NormalizedName] nvarchar(256) NULL,
                        [ConcurrencyStamp] nvarchar(max) NULL,
                        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
                    );
                END
            ");

            // Vérification de l'existence de la table AspNetUsers
            migrationBuilder.Sql(@"
                IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUsers]') AND type in (N'U'))
                BEGIN
                    CREATE TABLE [AspNetUsers] (
                        [Id] nvarchar(450) NOT NULL,
                        [JobTitle] nvarchar(max) NULL,
                        [FullName] nvarchar(max) NULL,
                        [Configuration] nvarchar(max) NULL,
                        [IsEnabled] bit NOT NULL,
                        [CreatedBy] nvarchar(max) NULL,
                        [UpdatedBy] nvarchar(max) NULL,
                        [CreatedDate] datetime2 NOT NULL,
                        [UpdatedDate] datetime2 NOT NULL,
                        [UserName] nvarchar(256) NULL,
                        [NormalizedUserName] nvarchar(256) NULL,
                        [Email] nvarchar(256) NULL,
                        [NormalizedEmail] nvarchar(256) NULL,
                        [EmailConfirmed] bit NOT NULL,
                        [PasswordHash] nvarchar(max) NULL,
                        [SecurityStamp] nvarchar(max) NULL,
                        [ConcurrencyStamp] nvarchar(max) NULL,
                        [PhoneNumber] nvarchar(max) NULL,
                        [PhoneNumberConfirmed] bit NOT NULL,
                        [TwoFactorEnabled] bit NOT NULL,
                        [LockoutEnd] datetimeoffset NULL,
                        [LockoutEnabled] bit NOT NULL,
                        [AccessFailedCount] int NOT NULL,
                        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
                    );
                END
            ");

            // Vérification de l'existence de la table OpenIddictApplications
            migrationBuilder.Sql(@"
                IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OpenIddictApplications]') AND type in (N'U'))
                BEGIN
                    CREATE TABLE [OpenIddictApplications] (
                        [Id] nvarchar(450) NOT NULL,
                        [ApplicationType] nvarchar(50) NULL,
                        [ClientId] nvarchar(100) NULL,
                        [ClientSecret] nvarchar(max) NULL,
                        [ClientType] nvarchar(50) NULL,
                        [ConcurrencyToken] nvarchar(50) NULL,
                        [ConsentType] nvarchar(50) NULL,
                        [DisplayName] nvarchar(max) NULL,
                        [DisplayNames] nvarchar(max) NULL,
                        [JsonWebKeySet] nvarchar(max) NULL,
                        [Permissions] nvarchar(max) NULL,
                        [PostLogoutRedirectUris] nvarchar(max) NULL,
                        [Properties] nvarchar(max) NULL,
                        [RedirectUris] nvarchar(max) NULL,
                        [Requirements] nvarchar(max) NULL,
                        [Settings] nvarchar(max) NULL,
                        CONSTRAINT [PK_OpenIddictApplications] PRIMARY KEY ([Id])
                    );
                END
            ");

            // Vérification de l'existence de la table OpenIddictScopes
            migrationBuilder.Sql(@"
                IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OpenIddictScopes]') AND type in (N'U'))
                BEGIN
                    CREATE TABLE [OpenIddictScopes] (
                        [Id] nvarchar(450) NOT NULL,
                        [ConcurrencyToken] nvarchar(50) NULL,
                        [Description] nvarchar(max) NULL,
                        [Descriptions] nvarchar(max) NULL,
                        [DisplayName] nvarchar(max) NULL,
                        [DisplayNames] nvarchar(max) NULL,
                        [Name] nvarchar(200) NULL,
                        [Properties] nvarchar(max) NULL,
                        [Resources] nvarchar(max) NULL,
                        CONSTRAINT [PK_OpenIddictScopes] PRIMARY KEY ([Id])
                    );
                END
            ");

            // Vérification de l'existence de la table BillCalculations
            migrationBuilder.Sql(@"
                IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BillCalculations]') AND type in (N'U'))
                BEGIN
                    CREATE TABLE [BillCalculations] (
                        [Id] int NOT NULL IDENTITY,
                        [NumeroFacture] int NOT NULL,
                        [Reference] nvarchar(max) NOT NULL,
                        [Periode] nvarchar(max) NOT NULL,
                        [AncienIndexJour] int NOT NULL,
                        [NouveauIndexJour] int NOT NULL,
                        [PerteVideJour] int NOT NULL,
                        [PerteChargeJour] int NOT NULL,
                        [CoefficientMultiplicateurJour] int NOT NULL,
                        [AncienIndexNuit] int NOT NULL,
                        [NouveauIndexNuit] int NOT NULL,
                        [PerteVideNuit] int NOT NULL,
                        [PerteChargeNuit] int NOT NULL,
                        [CoefficientMultiplicateurNuit] int NOT NULL,
                        [AncienIndexPointe] int NOT NULL,
                        [NouveauIndexPointe] int NOT NULL,
                        [PerteVidePointe] int NOT NULL,
                        [PerteChargePointe] int NOT NULL,
                        [CoefficientMultiplicateurPointe] int NOT NULL,
                        [PrixUnitaireJour] decimal(18, 2) NOT NULL,
                        [PrixUnitaireNuit] decimal(18, 2) NOT NULL,
                        [PrixUnitairePointe] decimal(18, 2) NOT NULL,
                        [Bonification] decimal(18, 2) NOT NULL,
                        [Penalite] decimal(18, 2) NOT NULL,
                        [PrimePuissance] decimal(18, 2) NOT NULL,
                        [LocationMateriel] decimal(18, 2) NOT NULL,
                        [FraisIntervention] decimal(18, 2) NOT NULL,
                        [FraisRelance] decimal(18, 2) NOT NULL,
                        [FraisRetard] decimal(18, 2) NOT NULL,
                        [TvaConsommation] decimal(18, 2) NOT NULL,
                        [TvaRedevance] decimal(18, 2) NOT NULL,
                        [ContributionRTT] decimal(18, 2) NOT NULL,
                        [SurtaxeMunicipale] decimal(18, 2) NOT NULL,
                        [ContributionGMG] decimal(18, 2) NOT NULL,
                        [CompteurId] int NOT NULL,
                        CONSTRAINT [PK_BillCalculations] PRIMARY KEY ([Id]),
                        CONSTRAINT [FK_BillCalculations_AppCompteures_CompteurId] FOREIGN KEY ([CompteurId]) REFERENCES [AppCompteures] ([Id]) ON DELETE CASCADE
                    );
                END
            ");

            // Vérification de l'existence de la table AspNetRoleClaims
            migrationBuilder.Sql(@"
                IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetRoleClaims]') AND type in (N'U'))
                BEGIN
                    CREATE TABLE [AspNetRoleClaims] (
                        [Id] int NOT NULL IDENTITY,
                        [RoleId] nvarchar(450) NOT NULL,
                        [ClaimType] nvarchar(max) NULL,
                        [ClaimValue] nvarchar(max) NULL,
                        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
                        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
                    );
                END
            ");

            // Vérification de l'existence de la table AppOrders
            migrationBuilder.Sql(@"
                IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AppOrders]') AND type in (N'U'))
                BEGIN
                    CREATE TABLE [AppOrders] (
                        [Id] int NOT NULL IDENTITY,
                        [Discount] decimal(18, 2) NOT NULL,
                        [Comments] nvarchar(500) NULL,
                        [CashierId] nvarchar(450) NULL,
                        [CompteurId] int NOT NULL,
                        [CreatedBy] nvarchar(40) NULL,
                        [UpdatedBy] nvarchar(40) NULL,
                        [UpdatedDate] datetime2 NOT NULL,
                        [CreatedDate] datetime2 NOT NULL,
                        CONSTRAINT [PK_AppOrders] PRIMARY KEY ([Id]),
                        CONSTRAINT [FK_AppOrders_AppCompteures_CompteurId] FOREIGN KEY ([CompteurId]) REFERENCES [AppCompteures] ([Id]) ON DELETE CASCADE,
                        CONSTRAINT [FK_AppOrders_AspNetUsers_CashierId] FOREIGN KEY ([CashierId]) REFERENCES [AspNetUsers] ([Id])
                    );
                END
            ");

            // Vérification de l'existence de la table AspNetUserClaims
            migrationBuilder.Sql(@"
                IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUserClaims]') AND type in (N'U'))
                BEGIN
                    CREATE TABLE [AspNetUserClaims] (
                        [Id] int NOT NULL IDENTITY,
                        [UserId] nvarchar(450) NOT NULL,
                        [ClaimType] nvarchar(max) NULL,
                        [ClaimValue] nvarchar(max) NULL,
                        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
                        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
                    );
                END
            ");

            // Vérification de l'existence de la table AspNetUserLogins
            migrationBuilder.Sql(@"
                IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUserLogins]') AND type in (N'U'))
                BEGIN
                    CREATE TABLE [AspNetUserLogins] (
                        [LoginProvider] nvarchar(450) NOT NULL,
                        [ProviderKey] nvarchar(450) NOT NULL,
                        [ProviderDisplayName] nvarchar(max) NULL,
                        [UserId] nvarchar(450) NOT NULL,
                        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
                        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
                    );
                END
            ");

            // Vérification de l'existence de la table AspNetUserRoles
            migrationBuilder.Sql(@"
                IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUserRoles]') AND type in (N'U'))
                BEGIN
                    CREATE TABLE [AspNetUserRoles] (
                        [UserId] nvarchar(450) NOT NULL,
                        [RoleId] nvarchar(450) NOT NULL,
                        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
                        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
                        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
                    );
                END
            ");

            // Vérification de l'existence de la table AspNetUserTokens
            migrationBuilder.Sql(@"
                IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUserTokens]') AND type in (N'U'))
                BEGIN
                    CREATE TABLE [AspNetUserTokens] (
                        [UserId] nvarchar(450) NOT NULL,
                        [LoginProvider] nvarchar(450) NOT NULL,
                        [Name] nvarchar(450) NOT NULL,
                        [Value] nvarchar(max) NULL,
                        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
                        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
                    );
                END
            ");

            // Vérification de l'existence de la table OpenIddictAuthorizations
            migrationBuilder.Sql(@"
                IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OpenIddictAuthorizations]') AND type in (N'U'))
                BEGIN
                    CREATE TABLE [OpenIddictAuthorizations] (
                        [Id] nvarchar(450) NOT NULL,
                        [ApplicationId] nvarchar(450) NULL,
                        [ConcurrencyToken] nvarchar(50) NULL,
                        [CreationDate] datetime2 NULL,
                        [Properties] nvarchar(max) NULL,
                        [Scopes] nvarchar(max) NULL,
                        [Status] nvarchar(50) NULL,
                        [Subject] nvarchar(400) NULL,
                        [Type] nvarchar(50) NULL,
                        CONSTRAINT [PK_OpenIddictAuthorizations] PRIMARY KEY ([Id]),
                        CONSTRAINT [FK_OpenIddictAuthorizations_OpenIddictApplications_ApplicationId] FOREIGN KEY ([ApplicationId]) REFERENCES [OpenIddictApplications] ([Id])
                    );
                END
            ");

            // Vérification de l'existence de la table AppOrderDetails
            migrationBuilder.Sql(@"
                IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AppOrderDetails]') AND type in (N'U'))
                BEGIN
                    CREATE TABLE [AppOrderDetails] (
                        [Id] int NOT NULL IDENTITY,
                        [UnitPrice] decimal(18, 2) NOT NULL,
                        [Quantity] int NOT NULL,
                        [Discount] decimal(18, 2) NOT NULL,
                        [OrderId] int NOT NULL,
                        [CreatedBy] nvarchar(40) NULL,
                        [UpdatedBy] nvarchar(40) NULL,
                        [UpdatedDate] datetime2 NOT NULL,
                        [CreatedDate] datetime2 NOT NULL,
                        CONSTRAINT [PK_AppOrderDetails] PRIMARY KEY ([Id]),
                        CONSTRAINT [FK_AppOrderDetails_AppOrders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [AppOrders] ([Id]) ON DELETE CASCADE
                    );
                END
            ");

            // Vérification de l'existence de la table OpenIddictTokens
            migrationBuilder.Sql(@"
                IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OpenIddictTokens]') AND type in (N'U'))
                BEGIN
                    CREATE TABLE [OpenIddictTokens] (
                        [Id] nvarchar(450) NOT NULL,
                        [ApplicationId] nvarchar(450) NULL,
                        [AuthorizationId] nvarchar(450) NULL,
                        [ConcurrencyToken] nvarchar(50) NULL,
                        [CreationDate] datetime2 NULL,
                        [ExpirationDate] datetime2 NULL,
                        [Payload] nvarchar(max) NULL,
                        [Properties] nvarchar(max) NULL,
                        [RedemptionDate] datetime2 NULL,
                        [ReferenceId] nvarchar(100) NULL,
                        [Status] nvarchar(50) NULL,
                        [Subject] nvarchar(400) NULL,
                        [Type] nvarchar(50) NULL,
                        CONSTRAINT [PK_OpenIddictTokens] PRIMARY KEY ([Id]),
                        CONSTRAINT [FK_OpenIddictTokens_OpenIddictApplications_ApplicationId] FOREIGN KEY ([ApplicationId]) REFERENCES [OpenIddictApplications] ([Id]),
                        CONSTRAINT [FK_OpenIddictTokens_OpenIddictAuthorizations_AuthorizationId] FOREIGN KEY ([AuthorizationId]) REFERENCES [OpenIddictAuthorizations] ([Id])
                    );
                END
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Suppression des tables seulement si elles existent
            migrationBuilder.Sql(@"
                IF OBJECT_ID(N'[dbo].[AppOrderDetails]', N'U') IS NOT NULL
                BEGIN
                    DROP TABLE [AppOrderDetails];
                END
            ");

            migrationBuilder.Sql(@"
                IF OBJECT_ID(N'[dbo].[AspNetRoleClaims]', N'U') IS NOT NULL
                BEGIN
                    DROP TABLE [AspNetRoleClaims];
                END
            ");

            migrationBuilder.Sql(@"
                IF OBJECT_ID(N'[dbo].[AspNetUserClaims]', N'U') IS NOT NULL
                BEGIN
                    DROP TABLE [AspNetUserClaims];
                END
            ");

            migrationBuilder.Sql(@"
                IF OBJECT_ID(N'[dbo].[AspNetUserLogins]', N'U') IS NOT NULL
                BEGIN
                    DROP TABLE [AspNetUserLogins];
                END
            ");

            migrationBuilder.Sql(@"
                IF OBJECT_ID(N'[dbo].[AspNetUserRoles]', N'U') IS NOT NULL
                BEGIN
                    DROP TABLE [AspNetUserRoles];
                END
            ");

            migrationBuilder.Sql(@"
                IF OBJECT_ID(N'[dbo].[AspNetUserTokens]', N'U') IS NOT NULL
                BEGIN
                    DROP TABLE [AspNetUserTokens];
                END
            ");

            migrationBuilder.Sql(@"
                IF OBJECT_ID(N'[dbo].[BillCalculations]', N'U') IS NOT NULL
                BEGIN
                    DROP TABLE [BillCalculations];
                END
            ");

            migrationBuilder.Sql(@"
                IF OBJECT_ID(N'[dbo].[OpenIddictScopes]', N'U') IS NOT NULL
                BEGIN
                    DROP TABLE [OpenIddictScopes];
                END
            ");

            migrationBuilder.Sql(@"
                IF OBJECT_ID(N'[dbo].[OpenIddictTokens]', N'U') IS NOT NULL
                BEGIN
                    DROP TABLE [OpenIddictTokens];
                END
            ");

            migrationBuilder.Sql(@"
                IF OBJECT_ID(N'[dbo].[AppOrders]', N'U') IS NOT NULL
                BEGIN
                    DROP TABLE [AppOrders];
                END
            ");

            migrationBuilder.Sql(@"
                IF OBJECT_ID(N'[dbo].[AspNetRoles]', N'U') IS NOT NULL
                BEGIN
                    DROP TABLE [AspNetRoles];
                END
            ");

            migrationBuilder.Sql(@"
                IF OBJECT_ID(N'[dbo].[OpenIddictAuthorizations]', N'U') IS NOT NULL
                BEGIN
                    DROP TABLE [OpenIddictAuthorizations];
                END
            ");

            migrationBuilder.Sql(@"
                IF OBJECT_ID(N'[dbo].[AppCompteures]', N'U') IS NOT NULL
                BEGIN
                    DROP TABLE [AppCompteures];
                END
            ");

            migrationBuilder.Sql(@"
                IF OBJECT_ID(N'[dbo].[AspNetUsers]', N'U') IS NOT NULL
                BEGIN
                    DROP TABLE [AspNetUsers];
                END
            ");

            migrationBuilder.Sql(@"
                IF OBJECT_ID(N'[dbo].[OpenIddictApplications]', N'U') IS NOT NULL
                BEGIN
                    DROP TABLE [OpenIddictApplications];
                END
            ");
        }
    }
}
