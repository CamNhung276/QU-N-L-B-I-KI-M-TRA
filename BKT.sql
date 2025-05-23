USE [BKT]
GO
/****** Object:  Table [dbo].[Answer]    Script Date: 5/14/2025 5:35:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](200) NOT NULL,
	[IsCorrect] [bit] NOT NULL,
	[QuestionId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 5/14/2025 5:35:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mark]    Script Date: 5/14/2025 5:35:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mark](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[QuizId] [int] NOT NULL,
	[Score] [decimal](5, 2) NOT NULL,
	[DateTaken] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NotificationReads]    Script Date: 5/14/2025 5:35:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NotificationReads](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NotificationId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[ReadDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notifications]    Script Date: 5/14/2025 5:35:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notifications](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](200) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ExpireDate] [datetime] NULL,
	[CreatedBy] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Question]    Script Date: 5/14/2025 5:35:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](500) NOT NULL,
	[CorrectAnswerId] [int] NULL,
	[QuizId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quiz]    Script Date: 5/14/2025 5:35:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quiz](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](200) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[CreatedByUserId] [int] NULL,
	[TimeToBeWorked] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 5/14/2025 5:35:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[UserId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 5/14/2025 5:35:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](255) NOT NULL,
	[Role] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Answer] ON 

INSERT [dbo].[Answer] ([Id], [Text], [IsCorrect], [QuestionId]) VALUES (186, N'1', 1, 25)
INSERT [dbo].[Answer] ([Id], [Text], [IsCorrect], [QuestionId]) VALUES (187, N'2', 0, 25)
INSERT [dbo].[Answer] ([Id], [Text], [IsCorrect], [QuestionId]) VALUES (188, N'3', 0, 25)
INSERT [dbo].[Answer] ([Id], [Text], [IsCorrect], [QuestionId]) VALUES (189, N'4', 0, 25)
INSERT [dbo].[Answer] ([Id], [Text], [IsCorrect], [QuestionId]) VALUES (190, N'2', 0, 26)
INSERT [dbo].[Answer] ([Id], [Text], [IsCorrect], [QuestionId]) VALUES (191, N'4', 0, 26)
INSERT [dbo].[Answer] ([Id], [Text], [IsCorrect], [QuestionId]) VALUES (192, N'12', 1, 26)
INSERT [dbo].[Answer] ([Id], [Text], [IsCorrect], [QuestionId]) VALUES (193, N'1', 0, 26)
INSERT [dbo].[Answer] ([Id], [Text], [IsCorrect], [QuestionId]) VALUES (194, N'10', 1, 27)
INSERT [dbo].[Answer] ([Id], [Text], [IsCorrect], [QuestionId]) VALUES (195, N'2', 0, 27)
INSERT [dbo].[Answer] ([Id], [Text], [IsCorrect], [QuestionId]) VALUES (196, N'6', 0, 27)
INSERT [dbo].[Answer] ([Id], [Text], [IsCorrect], [QuestionId]) VALUES (197, N'0', 0, 27)
INSERT [dbo].[Answer] ([Id], [Text], [IsCorrect], [QuestionId]) VALUES (202, N'3', 1, 29)
INSERT [dbo].[Answer] ([Id], [Text], [IsCorrect], [QuestionId]) VALUES (203, N'1', 0, 29)
INSERT [dbo].[Answer] ([Id], [Text], [IsCorrect], [QuestionId]) VALUES (204, N'0', 0, 29)
INSERT [dbo].[Answer] ([Id], [Text], [IsCorrect], [QuestionId]) VALUES (205, N'2', 0, 29)
INSERT [dbo].[Answer] ([Id], [Text], [IsCorrect], [QuestionId]) VALUES (206, N'0', 0, 30)
INSERT [dbo].[Answer] ([Id], [Text], [IsCorrect], [QuestionId]) VALUES (207, N'4', 1, 30)
INSERT [dbo].[Answer] ([Id], [Text], [IsCorrect], [QuestionId]) VALUES (208, N'0', 0, 30)
INSERT [dbo].[Answer] ([Id], [Text], [IsCorrect], [QuestionId]) VALUES (209, N'3', 0, 30)
INSERT [dbo].[Answer] ([Id], [Text], [IsCorrect], [QuestionId]) VALUES (218, N'5', 1, 31)
INSERT [dbo].[Answer] ([Id], [Text], [IsCorrect], [QuestionId]) VALUES (219, N'8', 0, 31)
INSERT [dbo].[Answer] ([Id], [Text], [IsCorrect], [QuestionId]) VALUES (220, N'7', 0, 31)
INSERT [dbo].[Answer] ([Id], [Text], [IsCorrect], [QuestionId]) VALUES (221, N'2', 0, 31)
INSERT [dbo].[Answer] ([Id], [Text], [IsCorrect], [QuestionId]) VALUES (222, N'3', 0, 32)
INSERT [dbo].[Answer] ([Id], [Text], [IsCorrect], [QuestionId]) VALUES (223, N'2', 0, 32)
INSERT [dbo].[Answer] ([Id], [Text], [IsCorrect], [QuestionId]) VALUES (224, N'3', 0, 32)
INSERT [dbo].[Answer] ([Id], [Text], [IsCorrect], [QuestionId]) VALUES (225, N'5', 1, 32)
INSERT [dbo].[Answer] ([Id], [Text], [IsCorrect], [QuestionId]) VALUES (226, N'2', 1, 33)
INSERT [dbo].[Answer] ([Id], [Text], [IsCorrect], [QuestionId]) VALUES (227, N'3', 0, 33)
INSERT [dbo].[Answer] ([Id], [Text], [IsCorrect], [QuestionId]) VALUES (228, N'1', 0, 33)
INSERT [dbo].[Answer] ([Id], [Text], [IsCorrect], [QuestionId]) VALUES (229, N'5', 0, 33)
INSERT [dbo].[Answer] ([Id], [Text], [IsCorrect], [QuestionId]) VALUES (230, N'15', 1, 34)
INSERT [dbo].[Answer] ([Id], [Text], [IsCorrect], [QuestionId]) VALUES (231, N'3', 0, 34)
INSERT [dbo].[Answer] ([Id], [Text], [IsCorrect], [QuestionId]) VALUES (232, N'3', 0, 34)
INSERT [dbo].[Answer] ([Id], [Text], [IsCorrect], [QuestionId]) VALUES (233, N'0', 0, 34)
INSERT [dbo].[Answer] ([Id], [Text], [IsCorrect], [QuestionId]) VALUES (238, N'7', 1, 36)
INSERT [dbo].[Answer] ([Id], [Text], [IsCorrect], [QuestionId]) VALUES (239, N'0', 0, 36)
INSERT [dbo].[Answer] ([Id], [Text], [IsCorrect], [QuestionId]) VALUES (240, N'3', 0, 36)
INSERT [dbo].[Answer] ([Id], [Text], [IsCorrect], [QuestionId]) VALUES (241, N'6', 0, 36)
INSERT [dbo].[Answer] ([Id], [Text], [IsCorrect], [QuestionId]) VALUES (242, N'2', 1, 37)
INSERT [dbo].[Answer] ([Id], [Text], [IsCorrect], [QuestionId]) VALUES (243, N'3', 0, 37)
INSERT [dbo].[Answer] ([Id], [Text], [IsCorrect], [QuestionId]) VALUES (244, N'0', 0, 37)
INSERT [dbo].[Answer] ([Id], [Text], [IsCorrect], [QuestionId]) VALUES (245, N'5', 0, 37)
SET IDENTITY_INSERT [dbo].[Answer] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [Name]) VALUES (2, N'Anh')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (8, N'PTDL')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (9, N'Toán')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (10, N'Tiếng Anh')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Mark] ON 

INSERT [dbo].[Mark] ([Id], [StudentId], [QuizId], [Score], [DateTaken]) VALUES (11, 4, 32, CAST(5.00 AS Decimal(5, 2)), CAST(N'2025-04-14T09:52:14.893' AS DateTime))
INSERT [dbo].[Mark] ([Id], [StudentId], [QuizId], [Score], [DateTaken]) VALUES (13, 4, 32, CAST(5.00 AS Decimal(5, 2)), CAST(N'2025-04-14T10:47:23.237' AS DateTime))
INSERT [dbo].[Mark] ([Id], [StudentId], [QuizId], [Score], [DateTaken]) VALUES (14, 4, 32, CAST(0.00 AS Decimal(5, 2)), CAST(N'2025-04-14T21:37:13.633' AS DateTime))
INSERT [dbo].[Mark] ([Id], [StudentId], [QuizId], [Score], [DateTaken]) VALUES (15, 6, 32, CAST(0.00 AS Decimal(5, 2)), CAST(N'2025-04-14T21:52:10.247' AS DateTime))
INSERT [dbo].[Mark] ([Id], [StudentId], [QuizId], [Score], [DateTaken]) VALUES (16, 6, 32, CAST(6.67 AS Decimal(5, 2)), CAST(N'2025-04-17T11:53:06.680' AS DateTime))
INSERT [dbo].[Mark] ([Id], [StudentId], [QuizId], [Score], [DateTaken]) VALUES (17, 6, 32, CAST(10.00 AS Decimal(5, 2)), CAST(N'2025-04-17T11:54:00.727' AS DateTime))
INSERT [dbo].[Mark] ([Id], [StudentId], [QuizId], [Score], [DateTaken]) VALUES (18, 6, 32, CAST(6.67 AS Decimal(5, 2)), CAST(N'2025-04-17T12:55:54.580' AS DateTime))
INSERT [dbo].[Mark] ([Id], [StudentId], [QuizId], [Score], [DateTaken]) VALUES (19, 6, 32, CAST(10.00 AS Decimal(5, 2)), CAST(N'2025-04-17T12:56:00.570' AS DateTime))
INSERT [dbo].[Mark] ([Id], [StudentId], [QuizId], [Score], [DateTaken]) VALUES (20, 6, 32, CAST(10.00 AS Decimal(5, 2)), CAST(N'2025-04-17T12:56:35.450' AS DateTime))
INSERT [dbo].[Mark] ([Id], [StudentId], [QuizId], [Score], [DateTaken]) VALUES (31, 6, 33, CAST(10.00 AS Decimal(5, 2)), CAST(N'2025-04-23T20:41:20.530' AS DateTime))
INSERT [dbo].[Mark] ([Id], [StudentId], [QuizId], [Score], [DateTaken]) VALUES (32, 6, 33, CAST(5.00 AS Decimal(5, 2)), CAST(N'2025-04-23T21:04:33.867' AS DateTime))
INSERT [dbo].[Mark] ([Id], [StudentId], [QuizId], [Score], [DateTaken]) VALUES (33, 6, 33, CAST(0.00 AS Decimal(5, 2)), CAST(N'2025-04-23T21:05:49.103' AS DateTime))
INSERT [dbo].[Mark] ([Id], [StudentId], [QuizId], [Score], [DateTaken]) VALUES (34, 6, 35, CAST(5.00 AS Decimal(5, 2)), CAST(N'2025-05-04T20:19:23.620' AS DateTime))
INSERT [dbo].[Mark] ([Id], [StudentId], [QuizId], [Score], [DateTaken]) VALUES (35, 6, 33, CAST(10.00 AS Decimal(5, 2)), CAST(N'2025-05-05T11:43:30.127' AS DateTime))
INSERT [dbo].[Mark] ([Id], [StudentId], [QuizId], [Score], [DateTaken]) VALUES (36, 6, 33, CAST(10.00 AS Decimal(5, 2)), CAST(N'2025-05-05T11:54:39.327' AS DateTime))
INSERT [dbo].[Mark] ([Id], [StudentId], [QuizId], [Score], [DateTaken]) VALUES (37, 6, 33, CAST(0.00 AS Decimal(5, 2)), CAST(N'2025-05-05T11:56:49.107' AS DateTime))
INSERT [dbo].[Mark] ([Id], [StudentId], [QuizId], [Score], [DateTaken]) VALUES (38, 6, 32, CAST(10.00 AS Decimal(5, 2)), CAST(N'2025-05-11T23:08:07.207' AS DateTime))
INSERT [dbo].[Mark] ([Id], [StudentId], [QuizId], [Score], [DateTaken]) VALUES (39, 6, 33, CAST(10.00 AS Decimal(5, 2)), CAST(N'2025-05-11T23:08:34.323' AS DateTime))
INSERT [dbo].[Mark] ([Id], [StudentId], [QuizId], [Score], [DateTaken]) VALUES (40, 6, 35, CAST(7.50 AS Decimal(5, 2)), CAST(N'2025-05-11T23:19:21.030' AS DateTime))
INSERT [dbo].[Mark] ([Id], [StudentId], [QuizId], [Score], [DateTaken]) VALUES (42, 6, 35, CAST(0.00 AS Decimal(5, 2)), CAST(N'2025-05-11T23:50:13.540' AS DateTime))
INSERT [dbo].[Mark] ([Id], [StudentId], [QuizId], [Score], [DateTaken]) VALUES (45, 6, 35, CAST(7.50 AS Decimal(5, 2)), CAST(N'2025-05-12T00:09:36.423' AS DateTime))
INSERT [dbo].[Mark] ([Id], [StudentId], [QuizId], [Score], [DateTaken]) VALUES (47, 6, 32, CAST(3.33 AS Decimal(5, 2)), CAST(N'2025-05-12T00:11:09.147' AS DateTime))
INSERT [dbo].[Mark] ([Id], [StudentId], [QuizId], [Score], [DateTaken]) VALUES (48, 4, 35, CAST(7.50 AS Decimal(5, 2)), CAST(N'2025-05-12T00:12:44.240' AS DateTime))
INSERT [dbo].[Mark] ([Id], [StudentId], [QuizId], [Score], [DateTaken]) VALUES (51, 6, 32, CAST(6.67 AS Decimal(5, 2)), CAST(N'2025-05-12T14:17:54.623' AS DateTime))
INSERT [dbo].[Mark] ([Id], [StudentId], [QuizId], [Score], [DateTaken]) VALUES (52, 6, 32, CAST(6.67 AS Decimal(5, 2)), CAST(N'2025-05-12T14:20:42.780' AS DateTime))
INSERT [dbo].[Mark] ([Id], [StudentId], [QuizId], [Score], [DateTaken]) VALUES (53, 6, 32, CAST(0.00 AS Decimal(5, 2)), CAST(N'2025-05-12T14:21:42.590' AS DateTime))
INSERT [dbo].[Mark] ([Id], [StudentId], [QuizId], [Score], [DateTaken]) VALUES (54, 6, 35, CAST(5.00 AS Decimal(5, 2)), CAST(N'2025-05-12T14:26:38.497' AS DateTime))
INSERT [dbo].[Mark] ([Id], [StudentId], [QuizId], [Score], [DateTaken]) VALUES (56, 6, 32, CAST(10.00 AS Decimal(5, 2)), CAST(N'2025-05-12T23:30:41.673' AS DateTime))
INSERT [dbo].[Mark] ([Id], [StudentId], [QuizId], [Score], [DateTaken]) VALUES (57, 6, 33, CAST(0.00 AS Decimal(5, 2)), CAST(N'2025-05-12T23:42:08.087' AS DateTime))
INSERT [dbo].[Mark] ([Id], [StudentId], [QuizId], [Score], [DateTaken]) VALUES (58, 6, 32, CAST(6.67 AS Decimal(5, 2)), CAST(N'2025-05-13T22:28:22.623' AS DateTime))
INSERT [dbo].[Mark] ([Id], [StudentId], [QuizId], [Score], [DateTaken]) VALUES (59, 6, 32, CAST(10.00 AS Decimal(5, 2)), CAST(N'2025-05-13T22:39:51.220' AS DateTime))
INSERT [dbo].[Mark] ([Id], [StudentId], [QuizId], [Score], [DateTaken]) VALUES (61, 4, 32, CAST(0.00 AS Decimal(5, 2)), CAST(N'2025-05-14T00:39:27.910' AS DateTime))
INSERT [dbo].[Mark] ([Id], [StudentId], [QuizId], [Score], [DateTaken]) VALUES (62, 6, 33, CAST(0.00 AS Decimal(5, 2)), CAST(N'2025-05-14T00:50:41.590' AS DateTime))
INSERT [dbo].[Mark] ([Id], [StudentId], [QuizId], [Score], [DateTaken]) VALUES (63, 6, 32, CAST(10.00 AS Decimal(5, 2)), CAST(N'2025-05-14T15:50:57.060' AS DateTime))
INSERT [dbo].[Mark] ([Id], [StudentId], [QuizId], [Score], [DateTaken]) VALUES (64, 6, 33, CAST(0.00 AS Decimal(5, 2)), CAST(N'2025-05-14T15:56:02.877' AS DateTime))
SET IDENTITY_INSERT [dbo].[Mark] OFF
GO
SET IDENTITY_INSERT [dbo].[NotificationReads] ON 

INSERT [dbo].[NotificationReads] ([Id], [NotificationId], [UserId], [ReadDate]) VALUES (32, 16, 21, CAST(N'2025-05-14T15:45:42.307' AS DateTime))
SET IDENTITY_INSERT [dbo].[NotificationReads] OFF
GO
SET IDENTITY_INSERT [dbo].[Notifications] ON 

INSERT [dbo].[Notifications] ([Id], [Title], [Content], [CreatedDate], [ExpireDate], [CreatedBy]) VALUES (16, N'nnn', N'sss', CAST(N'2025-05-13T18:35:00.133' AS DateTime), CAST(N'2025-05-14T18:34:36.000' AS DateTime), 26)
INSERT [dbo].[Notifications] ([Id], [Title], [Content], [CreatedDate], [ExpireDate], [CreatedBy]) VALUES (17, N'Nhớ học bài', N'Nhớ học bài Chương 1', CAST(N'2025-05-14T00:10:17.770' AS DateTime), CAST(N'2025-05-15T00:06:48.000' AS DateTime), 28)
INSERT [dbo].[Notifications] ([Id], [Title], [Content], [CreatedDate], [ExpireDate], [CreatedBy]) VALUES (18, N'Thông báo mới', N'Nhớ nộp bài', CAST(N'2025-05-14T15:45:07.810' AS DateTime), CAST(N'2025-05-15T15:35:11.000' AS DateTime), 26)
SET IDENTITY_INSERT [dbo].[Notifications] OFF
GO
SET IDENTITY_INSERT [dbo].[Question] ON 

INSERT [dbo].[Question] ([Id], [Text], [CorrectAnswerId], [QuizId]) VALUES (25, N'1111', 186, 32)
INSERT [dbo].[Question] ([Id], [Text], [CorrectAnswerId], [QuizId]) VALUES (26, N'6+6', 192, 32)
INSERT [dbo].[Question] ([Id], [Text], [CorrectAnswerId], [QuizId]) VALUES (27, N'12-2', 194, 32)
INSERT [dbo].[Question] ([Id], [Text], [CorrectAnswerId], [QuizId]) VALUES (29, N'1+2', 202, 35)
INSERT [dbo].[Question] ([Id], [Text], [CorrectAnswerId], [QuizId]) VALUES (30, N'1+3', 207, 35)
INSERT [dbo].[Question] ([Id], [Text], [CorrectAnswerId], [QuizId]) VALUES (31, N'3+2', 218, 35)
INSERT [dbo].[Question] ([Id], [Text], [CorrectAnswerId], [QuizId]) VALUES (32, N'10-5', 225, 35)
INSERT [dbo].[Question] ([Id], [Text], [CorrectAnswerId], [QuizId]) VALUES (33, N'1+1', 226, 33)
INSERT [dbo].[Question] ([Id], [Text], [CorrectAnswerId], [QuizId]) VALUES (34, N'6+9', 230, 33)
INSERT [dbo].[Question] ([Id], [Text], [CorrectAnswerId], [QuizId]) VALUES (36, N'5+2', 238, 37)
INSERT [dbo].[Question] ([Id], [Text], [CorrectAnswerId], [QuizId]) VALUES (37, N'1+1', 242, 37)
SET IDENTITY_INSERT [dbo].[Question] OFF
GO
SET IDENTITY_INSERT [dbo].[Quiz] ON 

INSERT [dbo].[Quiz] ([Id], [Title], [CategoryId], [CreatedByUserId], [TimeToBeWorked]) VALUES (32, N'Đề của GV2', 2, 16, 5)
INSERT [dbo].[Quiz] ([Id], [Title], [CategoryId], [CreatedByUserId], [TimeToBeWorked]) VALUES (33, N'HỎI', 2, 16, 1)
INSERT [dbo].[Quiz] ([Id], [Title], [CategoryId], [CreatedByUserId], [TimeToBeWorked]) VALUES (35, N'Đề của GV1', 9, 2, 1)
INSERT [dbo].[Quiz] ([Id], [Title], [CategoryId], [CreatedByUserId], [TimeToBeWorked]) VALUES (37, N'Đề 1', 2, 27, NULL)
INSERT [dbo].[Quiz] ([Id], [Title], [CategoryId], [CreatedByUserId], [TimeToBeWorked]) VALUES (38, N'Đề của GV2', 9, 28, 1)
SET IDENTITY_INSERT [dbo].[Quiz] OFF
GO
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([Id], [Name], [Email], [UserId]) VALUES (4, N'Cẩm Nhung', N'19_HS2@edu.ou.vn', 19)
INSERT [dbo].[Student] ([Id], [Name], [Email], [UserId]) VALUES (6, N'HS1BS', N'21_HS1@edu.ou.vn', 21)
SET IDENTITY_INSERT [dbo].[Student] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Username], [Password], [Role], [Name]) VALUES (19, N'HS2', N'123', N'Student', N'Cẩm Nhung')
INSERT [dbo].[User] ([Id], [Username], [Password], [Role], [Name]) VALUES (21, N'HS1', N'123', N'Student', N'HS1BS')
INSERT [dbo].[User] ([Id], [Username], [Password], [Role], [Name]) VALUES (25, N'Duy', N'123', N'Admin', N'DuyLE')
INSERT [dbo].[User] ([Id], [Username], [Password], [Role], [Name]) VALUES (26, N'Nhung', N'123', N'Admin', N'Cẩm Nhung')
INSERT [dbo].[User] ([Id], [Username], [Password], [Role], [Name]) VALUES (27, N'GV1', N'123', N'Teacher', N'Nhung')
INSERT [dbo].[User] ([Id], [Username], [Password], [Role], [Name]) VALUES (28, N'GV2', N'123', N'Teacher', N'Duy')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
/****** Object:  Index [UQ_NotificationReads]    Script Date: 5/14/2025 5:35:32 PM ******/
ALTER TABLE [dbo].[NotificationReads] ADD  CONSTRAINT [UQ_NotificationReads] UNIQUE NONCLUSTERED 
(
	[NotificationId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Answer]  WITH CHECK ADD  CONSTRAINT [FK_Answer_Question] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Question] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Answer] CHECK CONSTRAINT [FK_Answer_Question]
GO
ALTER TABLE [dbo].[Mark]  WITH CHECK ADD  CONSTRAINT [FK_Mark_QuizId] FOREIGN KEY([QuizId])
REFERENCES [dbo].[Quiz] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Mark] CHECK CONSTRAINT [FK_Mark_QuizId]
GO
ALTER TABLE [dbo].[Mark]  WITH CHECK ADD  CONSTRAINT [FK_Mark_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Mark] CHECK CONSTRAINT [FK_Mark_Student]
GO
ALTER TABLE [dbo].[NotificationReads]  WITH CHECK ADD  CONSTRAINT [FK_NotificationReads_Notifications] FOREIGN KEY([NotificationId])
REFERENCES [dbo].[Notifications] ([Id])
GO
ALTER TABLE [dbo].[NotificationReads] CHECK CONSTRAINT [FK_NotificationReads_Notifications]
GO
ALTER TABLE [dbo].[Question]  WITH CHECK ADD  CONSTRAINT [FK_Question_QuizId] FOREIGN KEY([QuizId])
REFERENCES [dbo].[Quiz] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Question] CHECK CONSTRAINT [FK_Question_QuizId]
GO
ALTER TABLE [dbo].[Quiz]  WITH CHECK ADD  CONSTRAINT [FK_Quiz_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Quiz] CHECK CONSTRAINT [FK_Quiz_Category]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_User]
GO
