/*
	DELETE Product
	DELETE Industry
*/


USE [IndustryDirectory]
GO

SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ProductID], [Name]) VALUES (1, N'Zug')
INSERT [dbo].[Product] ([ProductID], [Name]) VALUES (2, N'Bus')
INSERT [dbo].[Product] ([ProductID], [Name]) VALUES (3, N'Taxi')
INSERT [dbo].[Product] ([ProductID], [Name]) VALUES (4, N'Brieftransport')
INSERT [dbo].[Product] ([ProductID], [Name]) VALUES (5, N'Pakettransport')
INSERT [dbo].[Product] ([ProductID], [Name]) VALUES (6, N'Sandwich')
INSERT [dbo].[Product] ([ProductID], [Name]) VALUES (7, N'Zeitschriften')
INSERT [dbo].[Product] ([ProductID], [Name]) VALUES (8, N'Zeitungen')

SET IDENTITY_INSERT [dbo].[Product] OFF


SET IDENTITY_INSERT [dbo].[Industry] ON 

INSERT [dbo].[Industry] ([IndustryID], [Name]) VALUES (1, N'Transport')
INSERT [dbo].[Industry] ([IndustryID], [Name]) VALUES (2, N'Logistik')
INSERT [dbo].[Industry] ([IndustryID], [Name]) VALUES (3, N'Detailhandel')
INSERT [dbo].[Industry] ([IndustryID], [Name]) VALUES (4, N'ICT')

SET IDENTITY_INSERT [dbo].[Industry] OFF