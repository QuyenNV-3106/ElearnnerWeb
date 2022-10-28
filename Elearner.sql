use master
go

create database [ElearnnerDB]
go

use [ElearnnerDB]
go

/****** Object:  Table [dbo].[Accounts]    Script Date: 10/13/2022 11:18:27 PM ******/
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
	[status] [varchar](100) null
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 10/13/2022 11:18:27 PM ******/
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
	[status] [nvarchar](100) null,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Receipts]    Script Date: 10/13/2022 11:18:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Receipts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[numberCard] [int] NOT NULL,
	[userID] [int] NULL,
	[dayBilling] [datetime] NULL,
	[courseID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Topics]    Script Date: 10/13/2022 11:18:27 PM ******/
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
	[status] [nvarchar](100) null,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vocabularies]    Script Date: 10/13/2022 11:18:27 PM ******/
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
INSERT [dbo].[Accounts] ([id], [userName], [email], [password], [phoneNumber], [address], [topicID], [role]) VALUES (1, N'Nguyễn Văn Quyền', N'admin1@gmail.com', N'1234', N'332551241', N'Vũng Tàu', NULL, N'admin')
GO
INSERT [dbo].[Accounts] ([id], [userName], [email], [password], [phoneNumber], [address], [topicID], [role]) VALUES (2, N'Nguyễn Văn A', N'customer1@gmail.com', N'1234', N'332763212', N'Hồ Chí Minh', 5, N'user')
GO
INSERT [dbo].[Accounts] ([id], [userName], [email], [password], [phoneNumber], [address], [topicID], [role]) VALUES (3, N'Nguyễn Thị B', N'customer2@gmail.com', N'1234', N'942459831', N'Hà Nội', NULL, N'user')
GO
INSERT [dbo].[Accounts] ([id], [userName], [email], [password], [phoneNumber], [address], [topicID], [role]) VALUES (4, N'Nguyễn Văn C', N'customer11@gmail.com', N'1234', N'332763212', N'Cần Thơ', NULL, N'user')
GO
SET IDENTITY_INSERT [dbo].[Accounts] OFF
GO
SET IDENTITY_INSERT [dbo].[Topics] ON 
GO
INSERT [dbo].[Topics] ([id], [title], [subTitle], [imgURL], [kind], [meetURL]) VALUES (5, N'Do you have a close friend ?', N'Come here and join with us', N'https://cdnstepup.r.worldssl.net/wp-content/uploads/2019/03/learn-english1-vicook-6e068f469abc86e7b50da7d64c57c3d1-min.jpg', N'1-1', N'https://meet.google.com/ukg-mkfr-dxa')
GO
INSERT [dbo].[Topics] ([id], [title], [subTitle], [imgURL], [kind], [meetURL]) VALUES (7, N'Do you play sport ?', N'Come here and play with us !!', N'https://thumbs.dreamstime.com/b/assorted-sports-equipment-black-11153245.jpg', N'1-2', NULL)
GO
INSERT [dbo].[Topics] ([id], [title], [subTitle], [imgURL], [kind], [meetURL]) VALUES (9, N'How is the weather?', N'Come here and play with us !!', N'https://lh3.googleusercontent.com/pw/AL9nZEVplgQMoVCSZoNUZhJWGM0mv0uu7fqPMWL5fBOEnEUc-IFLet8M7sQ-3C1ledP9gQWKBfSw1sUKaT1PoKWs8_OtD1fCeNpjQabCuqK8ZXd4NgVQc1FIBooMkAS3SB7jHm-GE3Xga1IGCUI3kiEOrt9q=w1090-h500-no?authuser=1', N'1-1', NULL)
GO
INSERT [dbo].[Topics] ([id], [title], [subTitle], [imgURL], [kind], [meetURL]) VALUES (11, N'How is the weather?', N'Come here and play with us !!', N'https://lh3.googleusercontent.com/pw/AL9nZEVplgQMoVCSZoNUZhJWGM0mv0uu7fqPMWL5fBOEnEUc-IFLet8M7sQ-3C1ledP9gQWKBfSw1sUKaT1PoKWs8_OtD1fCeNpjQabCuqK8ZXd4NgVQc1FIBooMkAS3SB7jHm-GE3Xga1IGCUI3kiEOrt9q=w1090-h500-no?authuser=1', N'1-2', N'https://meet.google.com/ukg-mkfr-dxa')
GO
SET IDENTITY_INSERT [dbo].[Topics] OFF
GO
SET IDENTITY_INSERT [dbo].[Vocabularies] ON 
GO
INSERT [dbo].[Vocabularies] ([id], [userID], [english], [vietnamese]) VALUES (2, 2, N'Apple', N'Trái táo')
GO
INSERT [dbo].[Vocabularies] ([id], [userID], [english], [vietnamese]) VALUES (3, 2, N'Pen', N'Cây bút mực')
GO
INSERT [dbo].[Vocabularies] ([id], [userID], [english], [vietnamese]) VALUES (4, 2, N'Garbage', N'Rác')
GO
INSERT [dbo].[Vocabularies] ([id], [userID], [english], [vietnamese]) VALUES (5, 2, N'Car', N'Ô tô')
GO
SET IDENTITY_INSERT [dbo].[Vocabularies] OFF
GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD FOREIGN KEY([topicID])
REFERENCES [dbo].[Topics] ([id])
GO
ALTER TABLE [dbo].[Receipts]  WITH CHECK ADD FOREIGN KEY([courseID])
REFERENCES [dbo].[Courses] ([id])
GO
ALTER TABLE [dbo].[Receipts]  WITH CHECK ADD FOREIGN KEY([userID])
REFERENCES [dbo].[Accounts] ([id])
GO
ALTER TABLE [dbo].[Vocabularies]  WITH CHECK ADD FOREIGN KEY([userID])
REFERENCES [dbo].[Accounts] ([id]) ON DELETE CASCADE

GO
