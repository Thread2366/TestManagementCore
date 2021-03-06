USE [TestManagementDB]
GO
/****** Object:  Table [dbo].[TestCases]    Script Date: 14.01.2021 18:50:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestCases](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](2000) NULL,
	[Precondition] [nvarchar](2000) NULL,
	[Postcondition] [nvarchar](2000) NULL,
	[Action] [nvarchar](2000) NOT NULL,
	[Expected] [nvarchar](2000) NOT NULL,
	[ExecutionOrder] [int] NOT NULL,
	[ContainerId] [int] NOT NULL,
	[AuthorLogin] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TestCase] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TestCases]  WITH CHECK ADD  CONSTRAINT [FK_TestCase_TestContainer] FOREIGN KEY([ContainerId])
REFERENCES [dbo].[TestContainers] ([Id])
GO
ALTER TABLE [dbo].[TestCases] CHECK CONSTRAINT [FK_TestCase_TestContainer]
GO
