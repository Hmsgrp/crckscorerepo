USE [CricketScoreCardDB]
GO
/****** Object:  StoredProcedure [dbo].[GetSummaryInfo]    Script Date: 3/29/2021 11:57:38 AM ******/
DROP PROCEDURE [dbo].[GetSummaryInfo]
GO
/****** Object:  StoredProcedure [dbo].[GetScores]    Script Date: 3/29/2021 11:57:38 AM ******/
DROP PROCEDURE [dbo].[GetScores]
GO
/****** Object:  StoredProcedure [dbo].[GetPlayer]    Script Date: 3/29/2021 11:57:38 AM ******/
DROP PROCEDURE [dbo].[GetPlayer]
GO
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_RoleUser]
GO
ALTER TABLE [dbo].[TeamMatchMapping] DROP CONSTRAINT [FK_TeamMatchMapping_Matches]
GO
ALTER TABLE [dbo].[Scores] DROP CONSTRAINT [FK_pltm]
GO
ALTER TABLE [dbo].[Players] DROP CONSTRAINT [FK_PlayerTeam]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 3/29/2021 11:57:38 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
DROP TABLE [dbo].[Users]
GO
/****** Object:  Table [dbo].[Teams]    Script Date: 3/29/2021 11:57:38 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Teams]') AND type in (N'U'))
DROP TABLE [dbo].[Teams]
GO
/****** Object:  Table [dbo].[TeamMatchMapping]    Script Date: 3/29/2021 11:57:38 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TeamMatchMapping]') AND type in (N'U'))
DROP TABLE [dbo].[TeamMatchMapping]
GO
/****** Object:  Table [dbo].[Scores]    Script Date: 3/29/2021 11:57:38 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Scores]') AND type in (N'U'))
DROP TABLE [dbo].[Scores]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 3/29/2021 11:57:38 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Roles]') AND type in (N'U'))
DROP TABLE [dbo].[Roles]
GO
/****** Object:  Table [dbo].[Players]    Script Date: 3/29/2021 11:57:38 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Players]') AND type in (N'U'))
DROP TABLE [dbo].[Players]
GO
/****** Object:  Table [dbo].[Matches]    Script Date: 3/29/2021 11:57:38 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Matches]') AND type in (N'U'))
DROP TABLE [dbo].[Matches]
GO
/****** Object:  Table [dbo].[Matches]    Script Date: 3/29/2021 11:57:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Matches](
	[MatchID] [int] IDENTITY(1,1) NOT NULL,
	[MatchName] [nvarchar](50) NULL,
	[CreatedDate] [date] NULL,
	[UpdatedDate] [date] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Matches_1] PRIMARY KEY CLUSTERED 
(
	[MatchID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Players]    Script Date: 3/29/2021 11:57:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Players](
	[PlayerID] [int] IDENTITY(1,1) NOT NULL,
	[PlayerName] [nvarchar](50) NULL,
	[TeamID] [int] NULL,
	[CreatedDate] [date] NULL,
	[UpdatedDate] [date] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Players] PRIMARY KEY CLUSTERED 
(
	[PlayerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[PlayerName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 3/29/2021 11:57:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[RoleName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Scores]    Script Date: 3/29/2021 11:57:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Scores](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PlayerID] [int] NULL,
	[MatchID] [int] NULL,
	[Balls] [int] NULL,
	[Score] [int] NULL,
 CONSTRAINT [PK_Scores] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TeamMatchMapping]    Script Date: 3/29/2021 11:57:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeamMatchMapping](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MatchID] [int] NULL,
	[TeamID] [int] NULL,
	[CreatedDate] [date] NULL,
	[UpdatedDate] [date] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_TeamMatchMapping] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teams]    Script Date: 3/29/2021 11:57:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teams](
	[TeamID] [int] IDENTITY(1,1) NOT NULL,
	[TeamName] [nvarchar](50) NULL,
	[CreatedDate] [date] NULL,
	[UpdatedDate] [date] NULL,
	[status] [bit] NULL,
 CONSTRAINT [PK_Team] PRIMARY KEY CLUSTERED 
(
	[TeamID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[TeamName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 3/29/2021 11:57:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](max) NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[RoleID] [int] NULL,
	[CreatedDate] [date] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Players]  WITH CHECK ADD  CONSTRAINT [FK_PlayerTeam] FOREIGN KEY([TeamID])
REFERENCES [dbo].[Teams] ([TeamID])
GO
ALTER TABLE [dbo].[Players] CHECK CONSTRAINT [FK_PlayerTeam]
GO
ALTER TABLE [dbo].[Scores]  WITH CHECK ADD  CONSTRAINT [FK_pltm] FOREIGN KEY([PlayerID])
REFERENCES [dbo].[Players] ([PlayerID])
GO
ALTER TABLE [dbo].[Scores] CHECK CONSTRAINT [FK_pltm]
GO
ALTER TABLE [dbo].[TeamMatchMapping]  WITH CHECK ADD  CONSTRAINT [FK_TeamMatchMapping_Matches] FOREIGN KEY([MatchID])
REFERENCES [dbo].[Matches] ([MatchID])
GO
ALTER TABLE [dbo].[TeamMatchMapping] CHECK CONSTRAINT [FK_TeamMatchMapping_Matches]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_RoleUser] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([RoleID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_RoleUser]
GO
/****** Object:  StoredProcedure [dbo].[GetPlayer]    Script Date: 3/29/2021 11:57:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetPlayer]

as begin
select P.PlayerID,T.TeamID,P.PlayerName,T.TeamName from [dbo].[Players] P join 
[dbo].[Teams] T on T.TeamID = P.TeamID where P.[status]=1 and T.[Status]=1
end

--exec dbo.GetPlayer






GO
/****** Object:  StoredProcedure [dbo].[GetScores]    Script Date: 3/29/2021 11:57:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetScores]

as begin

select P.PlayerID,T.TeamID,M.MatchID,S.ID,P.PlayerName,T.TeamName,M.MatchName,S.Balls,S.Score
from  [dbo].[Scores] S join [dbo].[Players] P on S.PlayerID=P.PlayerID
join [dbo].[Teams] T on T.TeamID = P.TeamID
join [dbo].[Matches] M on M.MatchID = S.MatchID
where P.[status]=1 and T.[Status]=1 and M.[Status]=1

end

--exec dbo.GetPlayer


GO
/****** Object:  StoredProcedure [dbo].[GetSummaryInfo]    Script Date: 3/29/2021 11:57:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetSummaryInfo]

as begin

select COUNT(P.PlayerID) as Players,COUNT(m.MatchID) as [Matches],COUNT(T.TeamID) as Teams
from  [dbo].[Scores] S join [dbo].[Players] P on S.PlayerID=P.PlayerID
join [dbo].[Teams] T on T.TeamID = P.TeamID
join [dbo].[Matches] M on M.MatchID = S.MatchID
where P.[status]=1 and T.[Status]=1 and M.[Status]=1

end
GO
