USE [TestManagementDB]
GO
/****** Object:  Table [dbo].[AccessRules]    Script Date: 14.01.2021 18:50:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccessRules](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PermissionId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_AccessRules] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AccessRules]  WITH CHECK ADD  CONSTRAINT [FK_AccessRules_Permission] FOREIGN KEY([PermissionId])
REFERENCES [dbo].[Permissions] ([Id])
GO
ALTER TABLE [dbo].[AccessRules] CHECK CONSTRAINT [FK_AccessRules_Permission]
GO
ALTER TABLE [dbo].[AccessRules]  WITH CHECK ADD  CONSTRAINT [FK_AccessRules_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[AccessRules] CHECK CONSTRAINT [FK_AccessRules_Role]
GO
