USE [TestManagementDB]
GO
/****** Object:  Table [dbo].[TestContainers_Requirements]    Script Date: 14.01.2021 18:50:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestContainers_Requirements](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ContainerId] [int] NOT NULL,
	[RequirementId] [int] NOT NULL,
 CONSTRAINT [PK_TestContainer_Requirement] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TestContainers_Requirements]  WITH CHECK ADD  CONSTRAINT [FK_TestContainer_Requirement_TestContainer] FOREIGN KEY([ContainerId])
REFERENCES [dbo].[TestContainers] ([Id])
GO
ALTER TABLE [dbo].[TestContainers_Requirements] CHECK CONSTRAINT [FK_TestContainer_Requirement_TestContainer]
GO
