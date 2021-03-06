USE [master]
GO
/****** Object:  Database [QAGames]    Script Date: 05/01/2012 14:18:39 ******/
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'QAGames')

CREATE DATABASE [QAGames] 
GO

USE [QAGames]
GO
/****** Object:  Table [dbo].[Games]    Script Date: 01/18/2013 13:14:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Games](
	[GameID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](40) NOT NULL,
	[Description] [nvarchar](300) NULL,
	[UnitPrice] [money] NOT NULL,
	[UnitsInStock] [int] NOT NULL,
	[Position] [int] NULL,
 CONSTRAINT [PK_Games] PRIMARY KEY CLUSTERED 
(
	[GameID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Games] ( [Name], [Description], [UnitPrice], [UnitsInStock], [Position]) VALUES ( N'Mario Miner', N'Mario''s Mining game! The title says it all', 40.0000, 10, 3)
INSERT [dbo].[Games] ( [Name], [Description], [UnitPrice], [UnitsInStock], [Position]) VALUES ( N'Mortal Moaning Combat', N'Mortal combat but with genuine moaning sounds', 2.0000, 15, 6)
INSERT [dbo].[Games] ( [Name], [Description], [UnitPrice], [UnitsInStock], [Position]) VALUES ( N'Formula 1 Racer', N'F1 racing game', 40.0000, 5, 7)
INSERT [dbo].[Games] ( [Name], [Description], [UnitPrice], [UnitsInStock], [Position]) VALUES ( N'Pac Man', N'Classic Pac Man but with extension kit', 7.9800, 50, 2)
INSERT [dbo].[Games] ( [Name], [Description], [UnitPrice], [UnitsInStock], [Position]) VALUES ( N'The Sims 2', N'The Sims 2 Deluxe is nightlife and the sims 2 in one and they are the best out of all the sims games so far look out for The Sims 3 in 2009 10/10 MUST BUY!', 7.9800, 50, 8)
INSERT [dbo].[Games] ( [Name], [Description], [UnitPrice], [UnitsInStock], [Position]) VALUES ( N'Solitaire', N'A wide range of solitaire games to keep you busy for hours. Instructions for each solitaire variation are given within individual games. Have fun!', 12.4900, 61, 14)
INSERT [dbo].[Games] ( [Name], [Description], [UnitPrice], [UnitsInStock], [Position]) VALUES ( N'Fifa World Cup', N'Win the 2010 FIFA World Cup: Compete as one of 199 teams from qualification right through to a virtual reproduction of the 2010 FIFA World Cup Final.', 24.7500, 30, 4)
INSERT [dbo].[Games] ( [Name], [Description], [UnitPrice], [UnitsInStock], [Position]) VALUES ( N'Bejewelled', N'is the biggest, brightest version of the world''s #1 puzzle game with 8 breathtaking game modes', 29.9900, 13, 11)
INSERT [dbo].[Games] ( [Name], [Description], [UnitPrice], [UnitsInStock], [Position]) VALUES ( N'Spore', N'Are you ready to challenge yourself and play as an expert safecracker? Experience a unique adventure and find a hidden testament locked somewhere in a multitude of safes.', 11.6000, 11, 5)
INSERT [dbo].[Games] ( [Name], [Description], [UnitPrice], [UnitsInStock], [Position]) VALUES ( N'Asteroids', N'Puzzle Quest: Challenge of the Warlords is a brand new, genre-bending title that ups the ante on traditional puzzle games by incorporating strategy, role-playing elements and a persistent storyline.', 16.9900, 4, 13)
INSERT [dbo].[Games] ( [Name], [Description], [UnitPrice], [UnitsInStock], [Position]) VALUES ( N'Puzzle League', N'With no complicated rules to master, Puzzle League DS can be enjoyed by anyone just wanting to pick up and play, but it also provides challenges for even the most practised of players.', 15.8100, 7, 11)
INSERT [dbo].[Games] ( [Name], [Description], [UnitPrice], [UnitsInStock], [Position]) VALUES ( N'Carmen Sandiego: The Secret of the Stole', N'The last descendant of an African King reveals an ancient secret with his dying words: Deep in the jungles of Rwanda lies a hidden temple containing a great diamond which possesses the knowledge of all nations.', 2.5000, 10, 10)
INSERT [dbo].[Games] ( [Name], [Description], [UnitPrice], [UnitsInStock], [Position]) VALUES ( N'Winter Sports', N'Winter Sports 2008 - The Ultimate Challenge is the comprehensively improved sequel to last year''s winter hit RTL Winter Games 2007. The arcade-oriented winter sports compilation comprises the 15 most popular disciplines spanning 9 exciting sports.', 14.9800, 15, 14)
INSERT [dbo].[Games] ( [Name], [Description], [UnitPrice], [UnitsInStock], [Position]) VALUES ( N'Guitar Hero 3: Legends Of Rock (with Wir', N'Crank it up to 11 and get ready to rock - Featuring over 70 percent master recordings over 40 years of music.', 39.9600, 13, 1)
INSERT [dbo].[Games] ( [Name], [Description], [UnitPrice], [UnitsInStock], [Position]) VALUES ( N'Guitar Hero 3: SingStar', N'Multiplayer karaoke fun on your PS2', 17.4800, 9, 9)
INSERT [dbo].[Games] ( [Name], [Description], [UnitPrice], [UnitsInStock], [Position]) VALUES ( N'Suduko', N'a logic-based number placement puzzle. The objective is to fill a 9×9 grid so that each column, each row, and each of the nine 3×3 boxes (also called blocks or regions) contains the digits from 1 to 9 only one time each. The puzzle setter provides a partially completed grid.', 9.9900, 99, 16)
