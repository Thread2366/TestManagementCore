USE [TestManagementDB]
GO
/****** Object:  Table [dbo].[TestContainers_TestPlans]    Script Date: 14.01.2021 18:50:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestContainers_TestPlans](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TestContainerId] [int] NOT NULL,
	[TestPlanId] [int] NOT NULL,
 CONSTRAINT [PK_TestContainerTestPlan] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TestContainers_TestPlans]  WITH CHECK ADD  CONSTRAINT [FK_TestContainers_TestPlans_TestContainers_TestPlans] FOREIGN KEY([TestPlanId])
REFERENCES [dbo].[TestPlans] ([Id])
GO
ALTER TABLE [dbo].[TestContainers_TestPlans] CHECK CONSTRAINT [FK_TestContainers_TestPlans_TestContainers_TestPlans]
GO
