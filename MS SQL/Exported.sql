USE [aslamb]
GO
/****** Object:  Table [dbo].[clientstb]    Script Date: 11/6/2016 1:59:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[clientstb](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[mobile] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[drivertb]    Script Date: 11/6/2016 1:59:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[drivertb](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[mobile] [nvarchar](50) NULL,
	[branch] [nvarchar](50) NOT NULL,
	[status] [nvarchar](50) NOT NULL,
	[taxi] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[restb]    Script Date: 11/6/2016 1:59:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[restb](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[client] [nvarchar](50) NOT NULL,
	[tourfrom] [nvarchar](50) NOT NULL,
	[tourto] [nvarchar](50) NOT NULL,
	[km] [nvarchar](50) NOT NULL,
	[amount] [money] NOT NULL,
	[taxi] [nvarchar](50) NOT NULL,
	[date] [date] NOT NULL,
	[comment] [nvarchar](150) NOT NULL,
	[status] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tourtb]    Script Date: 11/6/2016 1:59:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tourtb](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[tourfrom] [nvarchar](50) NOT NULL,
	[tourto] [nvarchar](50) NOT NULL,
	[tourkm] [nvarchar](50) NOT NULL,
	[touramount] [money] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[userstb]    Script Date: 11/6/2016 1:59:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[userstb](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[mobile] [nvarchar](50) NULL,
	[branch] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[clientstb] ON 

INSERT [dbo].[clientstb] ([ID], [name], [username], [password], [mobile]) VALUES (1, N'aslam', N'aslam', N'aslam', N'12345')
INSERT [dbo].[clientstb] ([ID], [name], [username], [password], [mobile]) VALUES (4, N'aslam', N'alik', N'aslaml', N'aslam')
INSERT [dbo].[clientstb] ([ID], [name], [username], [password], [mobile]) VALUES (6, N'akif', N'akif', N'akifk', N'456')
SET IDENTITY_INSERT [dbo].[clientstb] OFF
SET IDENTITY_INSERT [dbo].[drivertb] ON 

INSERT [dbo].[drivertb] ([ID], [name], [username], [password], [mobile], [branch], [status], [taxi]) VALUES (1, N'aslam', N'aslam', N'aslam', N'1234', N'colombo', N'available', N'45-l')
INSERT [dbo].[drivertb] ([ID], [name], [username], [password], [mobile], [branch], [status], [taxi]) VALUES (4, N'Farik', N'farik', N'farik', N'125', N'galle', N'available', N'12-o')
SET IDENTITY_INSERT [dbo].[drivertb] OFF
SET IDENTITY_INSERT [dbo].[restb] ON 

INSERT [dbo].[restb] ([ID], [client], [tourfrom], [tourto], [km], [amount], [taxi], [date], [comment], [status]) VALUES (7, N'akif', N'colombo', N'galle', N'300', 3000.0000, N'45-l', CAST(N'2016-10-26' AS Date), N'Cppa', N'completed')
INSERT [dbo].[restb] ([ID], [client], [tourfrom], [tourto], [km], [amount], [taxi], [date], [comment], [status]) VALUES (8, N'aslam', N'galle', N'kandy', N'', 0.0000, N'12-o', CAST(N'2016-10-26' AS Date), N'Nice', N'completed')
INSERT [dbo].[restb] ([ID], [client], [tourfrom], [tourto], [km], [amount], [taxi], [date], [comment], [status]) VALUES (9, N'akif', N'galle', N'colombo', N'300', 300.0000, N'12-o', CAST(N'2016-10-26' AS Date), N'Fjksdaskdbaskj', N'completed')
INSERT [dbo].[restb] ([ID], [client], [tourfrom], [tourto], [km], [amount], [taxi], [date], [comment], [status]) VALUES (1006, N'akif', N'colombo', N'galle', N'300', 3000.0000, N'45-l', CAST(N'2016-10-30' AS Date), N'Fone', N'completed')
INSERT [dbo].[restb] ([ID], [client], [tourfrom], [tourto], [km], [amount], [taxi], [date], [comment], [status]) VALUES (1007, N'akif', N'colombo', N'kandy', N'200', 2000.0000, N'45-l', CAST(N'2016-10-31' AS Date), N'as', N'failed')
INSERT [dbo].[restb] ([ID], [client], [tourfrom], [tourto], [km], [amount], [taxi], [date], [comment], [status]) VALUES (2006, N'alik', N'colombo', N'kandy', N'200', 2000.0000, N'45-l', CAST(N'2016-11-03' AS Date), N'Good Customer', N'completed')
SET IDENTITY_INSERT [dbo].[restb] OFF
SET IDENTITY_INSERT [dbo].[tourtb] ON 

INSERT [dbo].[tourtb] ([ID], [tourfrom], [tourto], [tourkm], [touramount]) VALUES (1, N'colombo', N'kandy', N'200', 2000.0000)
INSERT [dbo].[tourtb] ([ID], [tourfrom], [tourto], [tourkm], [touramount]) VALUES (2, N'colombo', N'galle', N'300', 3000.0000)
INSERT [dbo].[tourtb] ([ID], [tourfrom], [tourto], [tourkm], [touramount]) VALUES (7, N'kandy', N'colombo', N'200', 2000.0000)
INSERT [dbo].[tourtb] ([ID], [tourfrom], [tourto], [tourkm], [touramount]) VALUES (8, N'galle', N'colombo', N'300', 300.0000)
SET IDENTITY_INSERT [dbo].[tourtb] OFF
SET IDENTITY_INSERT [dbo].[userstb] ON 

INSERT [dbo].[userstb] ([ID], [name], [username], [password], [mobile], [branch]) VALUES (1, N'Aslam', N'aslam', N'1234', N'1234', N'colombo')
INSERT [dbo].[userstb] ([ID], [name], [username], [password], [mobile], [branch]) VALUES (2, N'Asiq', N'asiq', N'1234456', N'1234', N'kandy')
INSERT [dbo].[userstb] ([ID], [name], [username], [password], [mobile], [branch]) VALUES (1002, N'Riswa', N'ris', N'1125', N'12345', N'kandy')
INSERT [dbo].[userstb] ([ID], [name], [username], [password], [mobile], [branch]) VALUES (1004, N'Many', N'many', N'many', N'1234', N'kandy')
INSERT [dbo].[userstb] ([ID], [name], [username], [password], [mobile], [branch]) VALUES (1011, N'rah', N'jjj', N'jjj', N'526', N'head')
INSERT [dbo].[userstb] ([ID], [name], [username], [password], [mobile], [branch]) VALUES (1013, N'LK', N'uk', N'kk', N'5252', N'kandy')
INSERT [dbo].[userstb] ([ID], [name], [username], [password], [mobile], [branch]) VALUES (1014, N'Bash', N'bas', N'1234', N'075425263', N'head')
SET IDENTITY_INSERT [dbo].[userstb] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__clientst__F3DBC572EE460895]    Script Date: 11/6/2016 1:59:55 AM ******/
ALTER TABLE [dbo].[clientstb] ADD UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__drivertb__F3DBC5721DE04708]    Script Date: 11/6/2016 1:59:55 AM ******/
ALTER TABLE [dbo].[drivertb] ADD UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__userstb__F3DBC5726C073774]    Script Date: 11/6/2016 1:59:55 AM ******/
ALTER TABLE [dbo].[userstb] ADD UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
