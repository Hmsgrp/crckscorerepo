USE [CricketScoreCardDB]
GO
/****** Object:  UserDefinedFunction [dbo].[getMatchName]    Script Date: 3/29/2021 8:15:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[getMatchName](@MatchID int)  
RETURNS nvarchar(max)   
AS   
-- Returns the stock level for the product.  
BEGIN  
    DECLARE @MatchName nvarchar(50);  
    SELECT @MatchName = MatchName 
   from [dbo].[Matches] M
    WHERE M.MatchID = @MatchID and M.[Status]=1
       
     IF (@MatchName IS NULL)   
        SET @MatchName = '--'; 
		
    RETURN @MatchName;  
END; 
GO
/****** Object:  Table [dbo].[Matches]    Script Date: 3/29/2021 8:15:13 PM ******/
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
/****** Object:  Table [dbo].[Players]    Script Date: 3/29/2021 8:15:13 PM ******/
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
/****** Object:  Table [dbo].[Roles]    Script Date: 3/29/2021 8:15:13 PM ******/
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
/****** Object:  Table [dbo].[Scores]    Script Date: 3/29/2021 8:15:13 PM ******/
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
/****** Object:  Table [dbo].[TeamMatchMapping]    Script Date: 3/29/2021 8:15:13 PM ******/
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
/****** Object:  Table [dbo].[Teams]    Script Date: 3/29/2021 8:15:13 PM ******/
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
/****** Object:  Table [dbo].[Users]    Script Date: 3/29/2021 8:15:13 PM ******/
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
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_RoleUser] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([RoleID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_RoleUser]
GO
/****** Object:  StoredProcedure [dbo].[GetPlayer]    Script Date: 3/29/2021 8:15:13 PM ******/
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
/****** Object:  StoredProcedure [dbo].[GetScores]    Script Date: 3/29/2021 8:15:13 PM ******/
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
/****** Object:  StoredProcedure [dbo].[GetSummary]    Script Date: 3/29/2021 8:15:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetSummary]

as begin

select
isnull(PlayerName,'--')as PlayerName,
isnull(S.Score,0) as Score,
isnull(T.TeamName,'--') as TeamName,
dbo.getMatchName(S.MatchID) as MatchName

from [dbo].[Players] p
Left join Teams T on P.PlayerID = T.TeamID and T.[status]=1
Left join Scores S on S.PlayerID = P.PlayerID  and P.[status]=1
order by S.Score desc

end
GO
/****** Object:  StoredProcedure [dbo].[GetSummaryInfo]    Script Date: 3/29/2021 8:15:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetSummaryInfo]

as begin

declare @PlayerID int =0;
declare @MatchID int = 0;
declare @TeamID int = 0;


select @PlayerID = count(PlayerID) from  [dbo].[Players] where [status] =1 
select @MatchID = count(MatchID) from  [dbo].[Matches] where [status] =1 
select @TeamID = count(TeamID) from  [dbo].[Teams] where [status] =1 

select @PlayerID as Players,@MatchID as [Matches], @TeamID as Teams

end
GO
