USE [TestManagementDB]
GO
/****** Object:  Table [dbo].[TestExecutions]    Script Date: 14.01.2021 18:50:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestExecutions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Success] [bit] NOT NULL,
	[Result] [nvarchar](2000) NOT NULL,
	[Comment] [nvarchar](2000) NULL,
	[ExecutionDate] [datetime2](0) NOT NULL,
	[TestCaseId] [int] NOT NULL,
	[ExecutorLogin] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TestExecution] PRIMARY KEY NONCLUSTERED 
(
	[Id] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_TestExecutions]    Script Date: 14.01.2021 18:50:48 ******/
CREATE CLUSTERED INDEX [IX_TestExecutions] ON [dbo].[TestExecutions]
(
	[ExecutionDate] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TestExecutions]  WITH CHECK ADD  CONSTRAINT [FK_TestExecution_TestExecution] FOREIGN KEY([TestCaseId])
REFERENCES [dbo].[TestCases] ([Id])
GO
ALTER TABLE [dbo].[TestExecutions] CHECK CONSTRAINT [FK_TestExecution_TestExecution]
GO
