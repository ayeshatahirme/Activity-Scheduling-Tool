
/* DATABASE FOR TIMETABLE GENERATOR TOLL PROJECT */
/*************** COURSES TABLE ***********/
USE [AutoTimeTable]
GO

/****** Object:  Table [dbo].[COURSE]    Script Date: 8/5/2020 2:55:03 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[COURSE](
	[ID] [varchar](25) NOT NULL,
	[COUESECODE] [varchar](50) NOT NULL,
	[SEMESTER] [varchar](25) NOT NULL,
	[ROOM] [varchar](25) NOT NULL,
 CONSTRAINT [PK_COURSE] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/*************** SUBJECT1 TABLE ***********/
USE [AutoTimeTable]
GO

/****** Object:  Table [dbo].[SUBJECT1]    Script Date: 8/5/2020 2:57:00 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SUBJECT1](
	[SUBJ1] [varchar](25) NULL,
	[CHRS1] [varchar](30) NULL,
	[SUBTYPE1] [varchar](50) NULL,
	[S_ID1] [varchar](25) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/*************** SUBJECT2 TABLE ***********/
USE [AutoTimeTable]
GO

/****** Object:  Table [dbo].[SUBJECT2]    Script Date: 8/5/2020 2:57:13 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SUBJECT2](
	[SUBJ2] [varchar](25) NULL,
	[CHRS2] [varchar](30) NULL,
	[SUBTYPE2] [varchar](50) NULL,
	[S_ID2] [varchar](25) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/*************** SUBJECT3 TABLE ***********/
USE [AutoTimeTable]
GO

/****** Object:  Table [dbo].[SUBJECT3]    Script Date: 8/5/2020 2:57:27 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SUBJECT3](
	[SUBJ3] [varchar](25) NULL,
	[CHRS3] [varchar](30) NULL,
	[SUBTYPE3] [varchar](50) NULL,
	[S_ID3] [varchar](25) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/*************** SUBJECT4 TABLE ***********/
USE [AutoTimeTable]
GO

/****** Object:  Table [dbo].[SUBJECT4]    Script Date: 8/5/2020 2:57:45 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SUBJECT4](
	[SUBJ4] [varchar](25) NULL,
	[CHRS4] [varchar](30) NULL,
	[SUBTYPE4] [varchar](50) NULL,
	[S_ID4] [varchar](25) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/*************** SUBJECT5 TABLE ***********/
USE [AutoTimeTable]
GO

/****** Object:  Table [dbo].[SUBJECT5]    Script Date: 8/5/2020 2:57:56 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SUBJECT5](
	[SUBJ5] [varchar](25) NULL,
	[CHRS5] [varchar](30) NULL,
	[SUBTYPE5] [varchar](50) NULL,
	[S_ID5] [varchar](25) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/*************** SUBJECT6 TABLE ***********/
USE [AutoTimeTable]
GO

/****** Object:  Table [dbo].[SUBJECT6]    Script Date: 8/5/2020 2:58:22 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SUBJECT6](
	[SUBJ6] [varchar](25) NULL,
	[CHRS6] [varchar](30) NULL,
	[SUBTYPE6] [varchar](50) NULL,
	[S_ID6] [varchar](25) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/*************** SUBJECT7 TABLE ***********/
USE [AutoTimeTable]
GO

/****** Object:  Table [dbo].[SUBJECT7]    Script Date: 8/5/2020 2:58:36 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SUBJECT7](
	[SUBJ7] [varchar](25) NULL,
	[CHRS7] [varchar](30) NULL,
	[SUBTYPE7] [varchar](50) NULL,
	[S_ID7] [varchar](25) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/*************** SUBJECT8 TABLE ***********/
USE [AutoTimeTable]
GO

/****** Object:  Table [dbo].[SUBJECT8]    Script Date: 8/5/2020 2:58:47 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SUBJECT8](
	[SUBJ8] [varchar](25) NULL,
	[CHRS8] [varchar](30) NULL,
	[SUBTYPE8] [varchar](50) NULL,
	[S_ID8] [varchar](25) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/*************** USER TABLE ***********/
USE [AutoTimeTable]
GO

/****** Object:  Table [dbo].[UserTable]    Script Date: 8/5/2020 2:52:55 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[UserTable](
	[UserID] [varchar](50) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
 CONSTRAINT [PK_UserTable] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

USE [AutoTimeTable]
GO

/*************** GENERATED TIMETABLE ***********/
/****** Object:  Table [dbo].[TIMETABLE]    Script Date: 8/5/2020 2:54:48 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TIMETABLE](
	[T_ID] [bigint] NOT NULL,
	[LEC1] [nvarchar](max) NULL,
	[LEC2] [nvarchar](max) NULL,
	[LEC3] [nvarchar](max) NULL,
	[LEC4] [nvarchar](max) NULL,
	[TBREAK] [nvarchar](max) NULL,
	[LEC5] [nvarchar](max) NULL,
	[LEC6] [nvarchar](max) NULL,
	[LEC7] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

