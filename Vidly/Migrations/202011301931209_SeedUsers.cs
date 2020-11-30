namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO[dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'443ff01d-2996-4e6c-91c1-286dbb4854fb', N'admin@vidly.com', 0, N'AOGwYfKtuN50Xta7WhrJixWDTwd4i0BCyHPXED7JwYyQrdPBoRVCa+v+wiYQIj4FGg==', N'd484f62f-415e-4fe3-b654-c81ba97857cd', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO[dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'9ddaa716-1e44-426a-9c0c-da15fdce130e', N'kocesat@gmail.com', 0, N'AFzFzSjdWrf3rbcd7QJTzt5ECEC72xe0PxZzCKtLBOgcPBXtrlytyIVX4YuKTeGDlQ==', N'5a25d915-5cf2-4764-bdb5-3a1ba7d8a4d3', NULL, 0, 0, NULL, 1, 0, N'kocesat@gmail.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'74998061-3d68-46dd-ba02-5f4beeca113c', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'443ff01d-2996-4e6c-91c1-286dbb4854fb', N'74998061-3d68-46dd-ba02-5f4beeca113c')");
        }

        public override void Down()
        {
        }
    }
}
