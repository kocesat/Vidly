namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStoreManagerRoles : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'0092e729-4669-4b67-925e-e114eb96db52', N'StoreManager')

INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [DrivingLicense], [Phone]) VALUES (N'4de00e0f-8e52-4164-b411-d9e2c7636c7f', N'manager@vidly.com', 0, N'ACeD0f5cj5Z2RvRZz8SQTqBWks6woZXcyw28Cf2SSHFfSKoWNmBwrgD6BRQwC36sqw==', N'ecc9f654-be4e-4e89-adf4-a77ee0e6e5be', NULL, 0, 0, NULL, 1, 0, N'manager@vidly.com', N'NoLicense', N'777888999')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'443ff01d-2996-4e6c-91c1-286dbb4854fb', N'74998061-3d68-46dd-ba02-5f4beeca113c')

");
        }
        
        public override void Down()
        {
        }
    }
}
