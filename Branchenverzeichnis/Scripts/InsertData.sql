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


SET IDENTITY_INSERT [dbo].[Company] ON 

INSERT [dbo].[Company] ([CompanyID], [Name], [Phonenumber], [Street], [PLZ], [Location], [CeoFirstName], [CeoLastName], [IndustryID]) 
	VALUES (1, N'SBB', N'041123123', N'Bernerstrasse 1', N'3000', N'Bern', N'Mike', N'Mueller', 1)
INSERT [dbo].[Company] ([CompanyID], [Name], [Phonenumber], [Street], [PLZ], [Location], [CeoFirstName], [CeoLastName], [IndustryID]) 
	VALUES (2, N'Post', N'041123123', N'Zuercherstrasse 5', N'8000', N'Zürich', N'Viktor', N'Giacobbo', 2)
INSERT [dbo].[Company] ([CompanyID], [Name], [Phonenumber], [Street], [PLZ], [Location], [CeoFirstName], [CeoLastName], [IndustryID]) 
	VALUES (3, N'K Kiosk', N'041123123', N'Baslerstrasse 12', N'5000', N'Basel', N'Markus', N'Meier', 3)

SET IDENTITY_INSERT [dbo].[Company] OFF


SET IDENTITY_INSERT [dbo].[CompanyProduct] ON 

INSERT [dbo].[CompanyProduct] ([CompanyProductID], [CompanyID], [ProductID]) VALUES (1, 1, 1)
INSERT [dbo].[CompanyProduct] ([CompanyProductID], [CompanyID], [ProductID]) VALUES (2, 1, 2)
INSERT [dbo].[CompanyProduct] ([CompanyProductID], [CompanyID], [ProductID]) VALUES (3, 1, 3)
INSERT [dbo].[CompanyProduct] ([CompanyProductID], [CompanyID], [ProductID]) VALUES (4, 2, 4)
INSERT [dbo].[CompanyProduct] ([CompanyProductID], [CompanyID], [ProductID]) VALUES (5, 2, 5)
INSERT [dbo].[CompanyProduct] ([CompanyProductID], [CompanyID], [ProductID]) VALUES (6, 2, 2)
INSERT [dbo].[CompanyProduct] ([CompanyProductID], [CompanyID], [ProductID]) VALUES (7, 3, 6)
INSERT [dbo].[CompanyProduct] ([CompanyProductID], [CompanyID], [ProductID]) VALUES (8, 3, 7)
INSERT [dbo].[CompanyProduct] ([CompanyProductID], [CompanyID], [ProductID]) VALUES (9, 3, 8)

SET IDENTITY_INSERT [dbo].[CompanyProduct] OFF