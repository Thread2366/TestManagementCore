USE [TestManagementDB]
GO
/****** Object:  Table [dbo].[TestContainers]    Script Date: 14.01.2021 18:50:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestContainers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](2000) NULL,
	[ExecutionOrder] [int] NOT NULL,
	[ParentId] [int] NULL,
	[TestPlanId] [int] NULL,
 CONSTRAINT [PK_TestContainer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TestContainers]  WITH CHECK ADD  CONSTRAINT [FK_TestContainer_TestPlan] FOREIGN KEY([TestPlanId])
REFERENCES [dbo].[TestPlans] ([Id])
GO
ALTER TABLE [dbo].[TestContainers] CHECK CONSTRAINT [FK_TestContainer_TestPlan]
GO
