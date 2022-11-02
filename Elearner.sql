Create database ElearnnerDB
go

use ElearnnerDB
go

/****** Object:  Table [dbo].[Accounts]    Script Date: 11/2/2022 1:45:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userName] [nvarchar](100) NOT NULL,
	[email] [varchar](100) NOT NULL,
	[password] [varchar](100) NOT NULL,
	[phoneNumber] [varchar](100) NULL,
	[address] [nvarchar](max) NULL,
	[topicID] [int] NULL,
	[role] [varchar](20) NULL,
	[status] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 11/2/2022 1:45:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[price] [float] NOT NULL,
	[kind] [nvarchar](10) NOT NULL,
	[discount] [float] NULL,
	[duration] [datetime] NULL,
	[status] [nvarchar](100) NULL,
	[name] [nvarchar](100) NULL,
	[time] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Topics]    Script Date: 11/2/2022 1:45:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Topics](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](100) NOT NULL,
	[subTitle] [nvarchar](100) NOT NULL,
	[imgURL] [nvarchar](max) NOT NULL,
	[kind] [nvarchar](10) NOT NULL,
	[meetURL] [nvarchar](max) NULL,
	[status] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vocabularies]    Script Date: 11/2/2022 1:45:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vocabularies](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userID] [int] NULL,
	[english] [nvarchar](500) NULL,
	[vietnamese] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Accounts] ON 
GO
INSERT [dbo].[Accounts] ([id], [userName], [email], [password], [phoneNumber], [address], [topicID], [role], [status]) VALUES (1, N'Nguyễn Văn Quyền', N'admin1@gmail.com', N'1234', N'332551241', N'Vũng Tàu', NULL, N'admin', NULL)
GO
INSERT [dbo].[Accounts] ([id], [userName], [email], [password], [phoneNumber], [address], [topicID], [role], [status]) VALUES (2, N'Nguyễn Văn A', N'customer1@gmail.com', N'1234', N'332763212', N'Hồ Chí Minh', 5, N'user', NULL)
GO
INSERT [dbo].[Accounts] ([id], [userName], [email], [password], [phoneNumber], [address], [topicID], [role], [status]) VALUES (3, N'Nguyễn Thị B', N'customer2@gmail.com', N'1234', N'942459831', N'Hà Nội', NULL, N'user', NULL)
GO
INSERT [dbo].[Accounts] ([id], [userName], [email], [password], [phoneNumber], [address], [topicID], [role], [status]) VALUES (4, N'Nguyễn Văn C', N'customer11@gmail.com', N'1234', N'332763212', N'Cần Thơ', NULL, NULL, NULL)
GO
INSERT [dbo].[Accounts] ([id], [userName], [email], [password], [phoneNumber], [address], [topicID], [role], [status]) VALUES (6, N'hello world', N'teacher1@gmail.com', N'1234', N'0123456789', N'usa', NULL, N'teacher', NULL)
GO
INSERT [dbo].[Accounts] ([id], [userName], [email], [password], [phoneNumber], [address], [topicID], [role], [status]) VALUES (7, N'Nguyễn Thị Ngọc rồng ', N'ngoctiu010104@gmail.com', N'12345678', N'12345678', N'1234', NULL, N'user', N'none')
GO
INSERT [dbo].[Accounts] ([id], [userName], [email], [password], [phoneNumber], [address], [topicID], [role], [status]) VALUES (8, N'Nguyễn Thị Ngọc rồng ', N'ngoctiu010104@gmail.com', N'12345678', N'12345678', N'1234', NULL, N'user', N'none')
GO
INSERT [dbo].[Accounts] ([id], [userName], [email], [password], [phoneNumber], [address], [topicID], [role], [status]) VALUES (9, N'Trần Uy Cường', N'tranuycuongc7@gmail.com', N'sskk', N'024932923', N'dsda', NULL, N'user', N'none')
GO
INSERT [dbo].[Accounts] ([id], [userName], [email], [password], [phoneNumber], [address], [topicID], [role], [status]) VALUES (10, N'a', N'a', N'a', N'a', N'a', NULL, N'user', N'none')
GO
SET IDENTITY_INSERT [dbo].[Accounts] OFF
GO
SET IDENTITY_INSERT [dbo].[Courses] ON 
GO
INSERT [dbo].[Courses] ([id], [price], [kind], [discount], [duration], [status], [name], [time]) VALUES (5, 1560000, N'1-1', 0, NULL, NULL, N'Khóa học 1-1 (1 tháng)', N'1 tháng')
GO
INSERT [dbo].[Courses] ([id], [price], [kind], [discount], [duration], [status], [name], [time]) VALUES (6, 4210000, N'1-1', 10, NULL, NULL, N'Khóa học 1-1 (3 tháng)', N'3 tháng')
GO
INSERT [dbo].[Courses] ([id], [price], [kind], [discount], [duration], [status], [name], [time]) VALUES (7, 9555000, N'1-1', 25, NULL, NULL, N'Khóa học 1-1 (12 tháng)', N'12 tháng')
GO
INSERT [dbo].[Courses] ([id], [price], [kind], [discount], [duration], [status], [name], [time]) VALUES (8, 1200000, N'1-2', 0, NULL, NULL, N'Khóa học 1-2 (1 tháng)', N'1 tháng')
GO
INSERT [dbo].[Courses] ([id], [price], [kind], [discount], [duration], [status], [name], [time]) VALUES (9, 3240000, N'1-2', 10, NULL, NULL, N'Khóa học 1-2 (3 tháng)', N'3 tháng')
GO
INSERT [dbo].[Courses] ([id], [price], [kind], [discount], [duration], [status], [name], [time]) VALUES (10, 7350000, N'1-2', 25, NULL, NULL, N'Khóa học 1-2 (12 tháng)', N'12 tháng')
GO
SET IDENTITY_INSERT [dbo].[Courses] OFF
GO
SET IDENTITY_INSERT [dbo].[Topics] ON 
GO
INSERT [dbo].[Topics] ([id], [title], [subTitle], [imgURL], [kind], [meetURL], [status]) VALUES (5, N'Do you have a close friend ?', N'Come here and join with us', N'https://cdnstepup.r.worldssl.net/wp-content/uploads/2019/03/learn-english1-vicook-6e068f469abc86e7b50da7d64c57c3d1-min.jpg', N'1-1', N'https://meet.google.com/ukg-mkfr-dxa', NULL)
GO
INSERT [dbo].[Topics] ([id], [title], [subTitle], [imgURL], [kind], [meetURL], [status]) VALUES (7, N'Do you play sport ?', N'Come here and play with us !!', N'https://thumbs.dreamstime.com/b/assorted-sports-equipment-black-11153245.jpg', N'1-2', N'https://meet.google.com/ejr-owxo-hbr', NULL)
GO
INSERT [dbo].[Topics] ([id], [title], [subTitle], [imgURL], [kind], [meetURL], [status]) VALUES (9, N'How is the weather?', N'Come here and play with us !!', N'https://lh3.googleusercontent.com/pw/AL9nZEVplgQMoVCSZoNUZhJWGM0mv0uu7fqPMWL5fBOEnEUc-IFLet8M7sQ-3C1ledP9gQWKBfSw1sUKaT1PoKWs8_OtD1fCeNpjQabCuqK8ZXd4NgVQc1FIBooMkAS3SB7jHm-GE3Xga1IGCUI3kiEOrt9q=w1090-h500-no?authuser=1', N'1-1', N'https://meet.google.com/pjd-ktrq-dho', NULL)
GO
INSERT [dbo].[Topics] ([id], [title], [subTitle], [imgURL], [kind], [meetURL], [status]) VALUES (11, N'How is the weather?', N'Come here and play with us !!', N'https://lh3.googleusercontent.com/pw/AL9nZEVplgQMoVCSZoNUZhJWGM0mv0uu7fqPMWL5fBOEnEUc-IFLet8M7sQ-3C1ledP9gQWKBfSw1sUKaT1PoKWs8_OtD1fCeNpjQabCuqK8ZXd4NgVQc1FIBooMkAS3SB7jHm-GE3Xga1IGCUI3kiEOrt9q=w1090-h500-no?authuser=1', N'1-2', N'https://meet.google.com/ukg-mkfr-dxa', NULL)
GO
INSERT [dbo].[Topics] ([id], [title], [subTitle], [imgURL], [kind], [meetURL], [status]) VALUES (12, N'Covid19', N'Talk about Covid pandemic', N'https://lh3.googleusercontent.com/pw/AL9nZEW6JwuPEnXDu2qR7u7ustEMwreDUjvZax1Vepj6zrX7pInBI8GWeUKSogalF-Sw-QQUTUkYIscSmsBYWIKiJBwxovGFoMhi4mdRDRxOvE3Ws8thD-P1h9gQvVSZd-1JmFIR5msFBP-qcXTYoUXTBAY=w700-h393-no?authuser=0', N'1-1', N'https://meet.google.com/mpd-zszu-tsz', NULL)
GO
SET IDENTITY_INSERT [dbo].[Topics] OFF
GO
SET IDENTITY_INSERT [dbo].[Vocabularies] ON 
GO
INSERT [dbo].[Vocabularies] ([id], [userID], [english], [vietnamese]) VALUES (2, 2, N'Apple', N'Trái táo')
GO
INSERT [dbo].[Vocabularies] ([id], [userID], [english], [vietnamese]) VALUES (3, 2, N'Pen', N'Cây bút mực')
GO
INSERT [dbo].[Vocabularies] ([id], [userID], [english], [vietnamese]) VALUES (9, 2, N'Car', N'O to')
GO
SET IDENTITY_INSERT [dbo].[Vocabularies] OFF
GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD FOREIGN KEY([topicID])
REFERENCES [dbo].[Topics] ([id])
GO
ALTER TABLE [dbo].[Vocabularies]  WITH CHECK ADD FOREIGN KEY([userID])
REFERENCES [dbo].[Accounts] ([id])
ON DELETE CASCADE
GO
