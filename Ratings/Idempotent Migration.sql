IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230203081801_First')
BEGIN
    CREATE TABLE [Influencer] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [City] nvarchar(max) NULL,
        [Country] nvarchar(max) NULL,
        CONSTRAINT [PK_Influencer] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230203081801_First')
BEGIN
    CREATE TABLE [City] (
        [Id] int NOT NULL IDENTITY,
        [InfluencerId] int NOT NULL,
        [PlaceId] nvarchar(max) NULL,
        [BoundsNELat] float NULL,
        [BoundsNELong] float NULL,
        [BoundsSWLat] float NULL,
        [BoundSWLong] float NULL,
        [ViewPortNELat] float NULL,
        [ViewPortNELong] float NULL,
        [ViewPortSWLat] float NULL,
        [ViewPortSWLong] float NULL,
        [LocationLat] float NULL,
        [LocationLong] float NULL,
        CONSTRAINT [PK_City] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_City_Influencer_InfluencerId] FOREIGN KEY ([InfluencerId]) REFERENCES [Influencer] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230203081801_First')
BEGIN
    CREATE TABLE [Country] (
        [Id] int NOT NULL IDENTITY,
        [InfluencerId] int NOT NULL,
        [PlaceId] nvarchar(max) NULL,
        [BoundsNELat] float NULL,
        [BoundsNELong] float NULL,
        [BoundsSWLat] float NULL,
        [BoundSWLong] float NULL,
        [ViewPortNELat] float NULL,
        [ViewPortNELong] float NULL,
        [ViewPortSWLat] float NULL,
        [ViewPortSWLong] float NULL,
        [LocationLat] float NULL,
        [LocationLong] float NULL,
        CONSTRAINT [PK_Country] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Country_Influencer_InfluencerId] FOREIGN KEY ([InfluencerId]) REFERENCES [Influencer] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230203081801_First')
BEGIN
    CREATE TABLE [FaceBook] (
        [Id] int NOT NULL IDENTITY,
        [InfluencerId] int NOT NULL,
        [Likes] bigint NOT NULL,
        [TalkingAbout] bigint NOT NULL,
        CONSTRAINT [PK_FaceBook] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_FaceBook_Influencer_InfluencerId] FOREIGN KEY ([InfluencerId]) REFERENCES [Influencer] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230203081801_First')
BEGIN
    CREATE TABLE [Instagram] (
        [Id] int NOT NULL IDENTITY,
        [InfluencerId] int NOT NULL,
        [Followers] bigint NULL,
        [EngagementRate] float NULL,
        [AverageLikes] bigint NULL,
        [AverageComments] float NULL,
        CONSTRAINT [PK_Instagram] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Instagram_Influencer_InfluencerId] FOREIGN KEY ([InfluencerId]) REFERENCES [Influencer] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230203081801_First')
BEGIN
    CREATE TABLE [YouTube] (
        [Id] int NOT NULL IDENTITY,
        [InfluencerId] int NOT NULL,
        [Subscribers] bigint NOT NULL,
        [Views] bigint NOT NULL,
        CONSTRAINT [PK_YouTube] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_YouTube_Influencer_InfluencerId] FOREIGN KEY ([InfluencerId]) REFERENCES [Influencer] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230203081801_First')
BEGIN
    CREATE UNIQUE INDEX [IX_City_InfluencerId] ON [City] ([InfluencerId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230203081801_First')
BEGIN
    CREATE UNIQUE INDEX [IX_Country_InfluencerId] ON [Country] ([InfluencerId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230203081801_First')
BEGIN
    CREATE UNIQUE INDEX [IX_FaceBook_InfluencerId] ON [FaceBook] ([InfluencerId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230203081801_First')
BEGIN
    CREATE UNIQUE INDEX [IX_Instagram_InfluencerId] ON [Instagram] ([InfluencerId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230203081801_First')
BEGIN
    CREATE UNIQUE INDEX [IX_YouTube_InfluencerId] ON [YouTube] ([InfluencerId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230203081801_First')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230203081801_First', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230204161737_feb4')
BEGIN
    CREATE TABLE [Twitter] (
        [Id] int NOT NULL IDENTITY,
        [InfluencerId] int NOT NULL,
        [Followers] bigint NULL,
        CONSTRAINT [PK_Twitter] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230204161737_feb4')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230204161737_feb4', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230204164507_feb4-2')
BEGIN
    ALTER TABLE [Influencer] ADD [ISInstagram] bit NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230204164507_feb4-2')
BEGIN
    ALTER TABLE [Influencer] ADD [IsFaceBook] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230204164507_feb4-2')
BEGIN
    ALTER TABLE [Influencer] ADD [IsTwitter] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230204164507_feb4-2')
BEGIN
    ALTER TABLE [Influencer] ADD [IsYouTube] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230204164507_feb4-2')
BEGIN
    CREATE UNIQUE INDEX [IX_Twitter_InfluencerId] ON [Twitter] ([InfluencerId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230204164507_feb4-2')
BEGIN
    ALTER TABLE [Twitter] ADD CONSTRAINT [FK_Twitter_Influencer_InfluencerId] FOREIGN KEY ([InfluencerId]) REFERENCES [Influencer] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230204164507_feb4-2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230204164507_feb4-2', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230207232646_feb7')
BEGIN
    EXEC sp_rename N'[Influencer].[ISInstagram]', N'IsInstagram', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230207232646_feb7')
BEGIN
    ALTER TABLE [YouTube] ADD [IconImage] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230207232646_feb7')
BEGIN
    ALTER TABLE [Twitter] ADD [IconImage] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230207232646_feb7')
BEGIN
    ALTER TABLE [Instagram] ADD [IconImage] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230207232646_feb7')
BEGIN
    ALTER TABLE [Influencer] ADD [Image] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230207232646_feb7')
BEGIN
    ALTER TABLE [FaceBook] ADD [IconImage] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230207232646_feb7')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230207232646_feb7', N'7.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230207232829_feb7-2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230207232829_feb7-2', N'7.0.1');
END;
GO

COMMIT;
GO

