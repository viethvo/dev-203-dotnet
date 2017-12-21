CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Adress] [nvarchar](250) NULL,
	[Age] [int] NULL,
	[Image] [nvarchar](150) NULL
) ON [PRIMARY]