SET IDENTITY_INSERT [dbo].[geoLocations] ON
INSERT INTO [dbo].[geoLocations] ([Id], [InfluenceId], [Country], [CountryCode], [State], [Region], [City], [PostCode], [MetroArea]) VALUES (3, 1, N'Ghana', N'gh', N'Greater Accra', N'Greater Accra', N'Accra', NULL, N'Adenta')
INSERT INTO [dbo].[geoLocations] ([Id], [InfluenceId], [Country], [CountryCode], [State], [Region], [City], [PostCode], [MetroArea]) VALUES (4, 1, N'Ghana', N'gh', NULL, N'Ashanti Region', N'Kumasi', NULL, N'Adom')
INSERT INTO [dbo].[geoLocations] ([Id], [InfluenceId], [Country], [CountryCode], [State], [Region], [City], [PostCode], [MetroArea]) VALUES (5, 1, N'Nigeria', N'ng', N'Lagos State', NULL, N'Lagos', NULL, N'Banana Island')
SET IDENTITY_INSERT [dbo].[geoLocations] OFF
