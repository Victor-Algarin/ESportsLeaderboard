IF EXISTS (SELECT 1 FROM master.dbo.sysdatabases WHERE name = 'ESportsLeaderboardDB')
BEGIN
	DROP DATABASE ESportsLeaderboardDB
	print '' print '*** dropping database ESportsLeaderboardDB ***'
END
GO

CREATE DATABASE ESportsLeaderboardDB
GO

print '' print '*** using database ESportsLeaderboardDB ***' 
GO
USE [ESportsLeaderboardDB]
GO

print '' print '*** Creating Player Table ***'
GO
/* ***Object: Table[dbo].[Player]*** */
CREATE TABLE [dbo].[Player](
	[PlayerID]			[int]IDENTITY(10000,1)	NOT NULL,
	[FirstName]			[varchar](50)			NOT NULL,
	[LastName]			[varchar](100)			NOT NULL,
	[Handle]			[varchar](50)			NOT NULL,
	[TotalSubscribers] 	[int]					NOT NULL DEFAULT 0,
	[TotalViewers]		[int]					NOT NULL DEFAULT 0,
	[TotalTimeViewed] 	[time]					NULL,
	[TotalTimeStreamed]	[time]					NULL,
	[CurrentRank]		[int]					NOT NULL DEFAULT -1,
	[HighestRank]		[int]					NOT NULL DEFAULT -1
	CONSTRAINT [pk_PlayerID] PRIMARY KEY ([PlayerID] ASC)
)
GO
print '' print '*** Inserting Player Sample Records ***'
GO
INSERT INTO [dbo].[Player]
		([FirstName], [LastName], [Handle], [TotalSubscribers], [TotalViewers], [TotalTimeViewed], [TotalTimeStreamed])
	VALUES
		('Iben', 'Cheatin', 'CheatSlayer69LOLZ', 2, 0, NULL, NULL),
		('Fake', 'McFakington', 'BoatsNFlows', 15, 0, NULL, NULL),
		('Schwifty', 'AlphaBeetree', 'LetsGetSchwiftyInHere', 7, 0, NULL, NULL)
GO

print '' print '*** Creating StreamSession Table ***'
GO
/* ***Object: Table[dbo].[StreamSession]*** */
CREATE TABLE [dbo].[StreamSession](
	[SessionID]		[int]IDENTITY(100000,1) NOT NULL,
	[PlayerID]	 	[int]					NOT NULL,
	[SessionDate]	[DATE]					NOT NULL,
	[CurrentViewerCount] [int]				NOT NULL DEFAULT 0,
	[TotalSessionViews]	[int]				NOT NULL DEFAULT 0, 
	[SessionTime]		[time]				NOT NULL,
	[SessionTotalTimeViewed] [time]			NULL
	CONSTRAINT [pk_SessionID] PRIMARY KEY ([SessionID] ASC)
)
GO

print '' print '*** Creating StreamSession PlayerID foreign key ***'
GO
ALTER TABLE [dbo].[StreamSession]  WITH NOCHECK 
	ADD CONSTRAINT [FK_PlayerID] FOREIGN KEY([PlayerID])
	REFERENCES [dbo].[Player] ([PlayerID])
	ON UPDATE CASCADE
GO
