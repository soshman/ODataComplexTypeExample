CREATE TABLE [dbo].[Transactions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Amount] [numeric](18, 4) NOT NULL,
	[Currency] [nvarchar](3) NOT NULL,
 CONSTRAINT [PK_Transaction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Transactions] ON 
GO
INSERT [dbo].[Transactions] ([Id], [Amount], [Currency]) VALUES (1, CAST(123.0000 AS Numeric(18, 4)), N'CHN')
GO
INSERT [dbo].[Transactions] ([Id], [Amount], [Currency]) VALUES (2, CAST(2.0000 AS Numeric(18, 4)), N'USD')
GO
INSERT [dbo].[Transactions] ([Id], [Amount], [Currency]) VALUES (3, CAST(45.1234 AS Numeric(18, 4)), N'PLN')
GO
INSERT [dbo].[Transactions] ([Id], [Amount], [Currency]) VALUES (4, CAST(1000000000.0000 AS Numeric(18, 4)), N'EUR')
GO
SET IDENTITY_INSERT [dbo].[Transactions] OFF
GO