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

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009081332_InitDb'
)
BEGIN
    CREATE TABLE [Language] (
        [Id] int NOT NULL IDENTITY,
        [LanguageName] nvarchar(50) NOT NULL,
        CONSTRAINT [PK_Language] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009081332_InitDb'
)
BEGIN
    CREATE TABLE [PaymentMethod] (
        [Id] int NOT NULL IDENTITY,
        [MethodName] nvarchar(50) NOT NULL,
        CONSTRAINT [PK_PaymentMethod] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009081332_InitDb'
)
BEGIN
    CREATE TABLE [StaffRole] (
        [Id] int NOT NULL IDENTITY,
        [RoleName] nvarchar(50) NOT NULL,
        [Rank] int NOT NULL,
        CONSTRAINT [PK_StaffRole] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009081332_InitDb'
)
BEGIN
    CREATE TABLE [Student] (
        [Id] int NOT NULL IDENTITY,
        [StudentCode] nvarchar(max) NULL DEFAULT N'bJ34Ty',
        [FullName] nvarchar(255) NOT NULL,
        [Gender] nvarchar(20) NOT NULL,
        [Email] nvarchar(50) NOT NULL,
        [PhoneNumber] nvarchar(20) NOT NULL,
        [DateOfBirth] datetime2 NULL,
        [EnrollmentDate] datetime2 NOT NULL DEFAULT '2024-10-09T08:13:31.4216050Z',
        [Status] nvarchar(50) NULL DEFAULT N'Chưa có lớp',
        CONSTRAINT [PK_Student] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009081332_InitDb'
)
BEGIN
    CREATE TABLE [Teacher] (
        [Id] int NOT NULL IDENTITY,
        [TeacherCode] nvarchar(max) NULL DEFAULT N'U1fpaT',
        [ImgUrl] nvarchar(255) NULL,
        [FullName] nvarchar(255) NOT NULL,
        [Gender] nvarchar(20) NOT NULL,
        [Email] nvarchar(255) NOT NULL,
        [PhoneNumber] nvarchar(20) NOT NULL,
        [Address] nvarchar(255) NULL,
        [DateOfBirth] datetime2 NULL,
        [HireDate] datetime2 NULL DEFAULT '2024-10-09T08:13:31.4219680Z',
        [EndDate] datetime2 NULL,
        [IsActive] bit NULL DEFAULT CAST(1 AS bit),
        CONSTRAINT [PK_Teacher] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009081332_InitDb'
)
BEGIN
    CREATE TABLE [Weekday] (
        [Id] int NOT NULL IDENTITY,
        [DayName] nvarchar(50) NULL,
        CONSTRAINT [PK_Weekday] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009081332_InitDb'
)
BEGIN
    CREATE TABLE [Level] (
        [Id] int NOT NULL IDENTITY,
        [LevelCode] nvarchar(20) NOT NULL,
        [LevelName] nvarchar(50) NOT NULL,
        [LanguageId] int NOT NULL,
        CONSTRAINT [PK_Level] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Level_Language_LanguageId] FOREIGN KEY ([LanguageId]) REFERENCES [Language] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009081332_InitDb'
)
BEGIN
    CREATE TABLE [Staff] (
        [Id] int NOT NULL IDENTITY,
        [StaffCode] nvarchar(50) NULL DEFAULT N'chqCpW',
        [ImgUrl] nvarchar(255) NULL,
        [FullName] nvarchar(255) NOT NULL,
        [Gender] nvarchar(20) NOT NULL,
        [Email] nvarchar(50) NOT NULL,
        [PasswordHash] nvarchar(255) NOT NULL,
        [PhoneNumber] nvarchar(20) NOT NULL,
        [Address] nvarchar(255) NULL,
        [DateOfBirth] datetime2 NULL,
        [HireDate] datetime2 NULL DEFAULT '2024-10-09T08:13:31.4206600Z',
        [EndDate] datetime2 NULL,
        [IsActive] bit NULL DEFAULT CAST(1 AS bit),
        [RoleId] int NOT NULL,
        CONSTRAINT [PK_Staff] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Staff_StaffRole_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [StaffRole] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009081332_InitDb'
)
BEGIN
    CREATE TABLE [Course] (
        [Id] int NOT NULL IDENTITY,
        [CourseCode] nvarchar(max) NULL DEFAULT N'zUybyx',
        [CourseName] nvarchar(255) NOT NULL,
        [Description] nvarchar(255) NULL,
        [Duration] nvarchar(max) NOT NULL,
        [Fee] float NOT NULL DEFAULT 0.0E0,
        [Discount] float NOT NULL DEFAULT 0.0E0,
        [TotalFee] float NOT NULL DEFAULT 0.0E0,
        [IsActive] bit NOT NULL DEFAULT CAST(1 AS bit),
        [CreatedDate] datetime2 NOT NULL DEFAULT '2024-10-09T08:13:31.4186380Z',
        [UpdatedDate] datetime2 NOT NULL DEFAULT '2024-10-09T08:13:31.4186790Z',
        [LevelId] int NOT NULL,
        CONSTRAINT [PK_Course] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Course_Level_LevelId] FOREIGN KEY ([LevelId]) REFERENCES [Level] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009081332_InitDb'
)
BEGIN
    CREATE TABLE [Class] (
        [Id] int NOT NULL IDENTITY,
        [ClassCode] nvarchar(max) NULL DEFAULT N'hWwexE',
        [ClassName] nvarchar(max) NOT NULL,
        [StartDate] datetime2 NULL,
        [EndDate] datetime2 NULL,
        [CourseId] int NOT NULL,
        [TeacherId] int NOT NULL,
        CONSTRAINT [PK_Class] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Class_Course_CourseId] FOREIGN KEY ([CourseId]) REFERENCES [Course] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Class_Teacher_TeacherId] FOREIGN KEY ([TeacherId]) REFERENCES [Teacher] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009081332_InitDb'
)
BEGIN
    CREATE TABLE [Payment] (
        [Id] int NOT NULL IDENTITY,
        [PaymentCode] nvarchar(20) NULL DEFAULT N'576maP',
        [PaymentDate] datetime2 NOT NULL DEFAULT '2024-10-09T08:13:31.4196270Z',
        [PaymentStatus] nvarchar(20) NULL DEFAULT N'Created',
        [PaymentMethodId] int NULL,
        [StudentId] int NOT NULL,
        [CourseId] int NOT NULL,
        [Amount] float NOT NULL DEFAULT 0.0E0,
        CONSTRAINT [PK_Payment] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Payment_Course_CourseId] FOREIGN KEY ([CourseId]) REFERENCES [Course] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Payment_PaymentMethod_PaymentMethodId] FOREIGN KEY ([PaymentMethodId]) REFERENCES [PaymentMethod] ([Id]),
        CONSTRAINT [FK_Payment_Student_StudentId] FOREIGN KEY ([StudentId]) REFERENCES [Student] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009081332_InitDb'
)
BEGIN
    CREATE TABLE [ClassStudents] (
        [ClassId] int NOT NULL,
        [StudentId] int NOT NULL,
        CONSTRAINT [PK_ClassStudents] PRIMARY KEY ([StudentId], [ClassId]),
        CONSTRAINT [FK_ClassStudents_Class_ClassId] FOREIGN KEY ([ClassId]) REFERENCES [Class] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_ClassStudents_Student_StudentId] FOREIGN KEY ([StudentId]) REFERENCES [Student] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009081332_InitDb'
)
BEGIN
    CREATE TABLE [ClassWeekday] (
        [ClassId] int NOT NULL,
        [WeekdayId] int NOT NULL,
        [StartTime] datetime2 NOT NULL,
        [EndTime] datetime2 NOT NULL,
        CONSTRAINT [PK_ClassWeekday] PRIMARY KEY ([ClassId], [WeekdayId]),
        CONSTRAINT [FK_ClassWeekday_Class_ClassId] FOREIGN KEY ([ClassId]) REFERENCES [Class] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_ClassWeekday_Weekday_WeekdayId] FOREIGN KEY ([WeekdayId]) REFERENCES [Weekday] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009081332_InitDb'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'LanguageName') AND [object_id] = OBJECT_ID(N'[Language]'))
        SET IDENTITY_INSERT [Language] ON;
    EXEC(N'INSERT INTO [Language] ([Id], [LanguageName])
    VALUES (1, N''Tiếng Anh''),
    (2, N''Tiếng Pháp''),
    (3, N''Tiếng Tây Ban Nha''),
    (4, N''Tiếng Trung''),
    (5, N''Tiếng Nhật'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'LanguageName') AND [object_id] = OBJECT_ID(N'[Language]'))
        SET IDENTITY_INSERT [Language] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009081332_InitDb'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'MethodName') AND [object_id] = OBJECT_ID(N'[PaymentMethod]'))
        SET IDENTITY_INSERT [PaymentMethod] ON;
    EXEC(N'INSERT INTO [PaymentMethod] ([Id], [MethodName])
    VALUES (1, N''Tiền mặt''),
    (2, N''Thẻ ghi nợ''),
    (3, N''Thẻ tính dụng''),
    (4, N''Chuyển khoản ngân hàng''),
    (5, N''Ví điện tử'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'MethodName') AND [object_id] = OBJECT_ID(N'[PaymentMethod]'))
        SET IDENTITY_INSERT [PaymentMethod] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009081332_InitDb'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Rank', N'RoleName') AND [object_id] = OBJECT_ID(N'[StaffRole]'))
        SET IDENTITY_INSERT [StaffRole] ON;
    EXEC(N'INSERT INTO [StaffRole] ([Id], [Rank], [RoleName])
    VALUES (1, 1, N''Admin''),
    (2, 2, N''Center Manager''),
    (3, 3, N''Student Coordinator''),
    (4, 3, N''HR Manager'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Rank', N'RoleName') AND [object_id] = OBJECT_ID(N'[StaffRole]'))
        SET IDENTITY_INSERT [StaffRole] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009081332_InitDb'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DateOfBirth', N'Email', N'EnrollmentDate', N'FullName', N'Gender', N'PhoneNumber', N'Status', N'StudentCode') AND [object_id] = OBJECT_ID(N'[Student]'))
        SET IDENTITY_INSERT [Student] ON;
    EXEC(N'INSERT INTO [Student] ([Id], [DateOfBirth], [Email], [EnrollmentDate], [FullName], [Gender], [PhoneNumber], [Status], [StudentCode])
    VALUES (1, ''2000-05-15T00:00:00.0000000'', N''nguyenvana@example.com'', ''2024-09-01T00:00:00.0000000'', N''Nguyễn Văn A'', N''Nam'', N''0987654321'', N''Active'', N''HV001''),
    (2, ''1999-03-22T00:00:00.0000000'', N''tranthib@example.com'', ''2024-09-01T00:00:00.0000000'', N''Trần Thị B'', N''Nữ'', N''0912345678'', N''Active'', N''HV002''),
    (3, ''2001-12-01T00:00:00.0000000'', N''levanc@example.com'', ''2024-09-01T00:00:00.0000000'', N''Lê Văn C'', N''Nam'', N''0923456789'', N''Active'', N''HV003''),
    (4, ''1998-07-20T00:00:00.0000000'', N''phamthid@example.com'', ''2024-09-01T00:00:00.0000000'', N''Phạm Thị D'', N''Nữ'', N''0981234567'', N''Active'', N''HV004''),
    (5, ''1997-04-10T00:00:00.0000000'', N''dovane@example.com'', ''2024-09-01T00:00:00.0000000'', N''Đỗ Văn E'', N''Nam'', N''0976543210'', N''Inactive'', N''HV005''),
    (6, ''1999-02-05T00:00:00.0000000'', N''hoangminhf@example.com'', ''2024-09-01T00:00:00.0000000'', N''Hoàng Minh F'', N''Nam'', N''0912345678'', N''Active'', N''HV006''),
    (7, ''1998-08-18T00:00:00.0000000'', N''nguyenvang@example.com'', ''2024-09-01T00:00:00.0000000'', N''Nguyễn Văn G'', N''Nam'', N''0922345678'', N''Active'', N''HV007''),
    (8, ''2000-01-11T00:00:00.0000000'', N''vuthih@example.com'', ''2024-09-01T00:00:00.0000000'', N''Vũ Thị H'', N''Nữ'', N''0934567890'', N''Active'', N''HV008''),
    (9, ''1996-11-30T00:00:00.0000000'', N''buivani@example.com'', ''2024-09-01T00:00:00.0000000'', N''Bùi Văn I'', N''Nam'', N''0909876543'', N''Inactive'', N''HV009''),
    (10, ''2002-09-10T00:00:00.0000000'', N''phanthij@example.com'', ''2024-09-01T00:00:00.0000000'', N''Phan Thị J'', N''Nữ'', N''0987654321'', N''Active'', N''HV010''),
    (11, ''1999-02-21T00:00:00.0000000'', N''truongvank@example.com'', ''2024-09-01T00:00:00.0000000'', N''Trương Văn K'', N''Nam'', N''0981112233'', N''Active'', N''HV011''),
    (12, ''1997-04-01T00:00:00.0000000'', N''nguyenthil@example.com'', ''2024-09-01T00:00:00.0000000'', N''Nguyễn Thị L'', N''Nữ'', N''0992223344'', N''Active'', N''HV012''),
    (13, ''1995-07-15T00:00:00.0000000'', N''lyvanm@example.com'', ''2024-09-01T00:00:00.0000000'', N''Lý Văn M'', N''Nam'', N''0912345678'', N''Inactive'', N''HV013''),
    (14, ''1998-03-23T00:00:00.0000000'', N''ngothin@example.com'', ''2024-09-01T00:00:00.0000000'', N''Ngô Thị N'', N''Nữ'', N''0922345678'', N''Active'', N''HV014''),
    (15, ''1994-09-05T00:00:00.0000000'', N''tranvano@example.com'', ''2024-09-01T00:00:00.0000000'', N''Trần Văn O'', N''Nam'', N''0908765432'', N''Inactive'', N''HV015''),
    (16, ''2000-12-03T00:00:00.0000000'', N''phamminhp@example.com'', ''2024-09-01T00:00:00.0000000'', N''Phạm Minh P'', N''Nam'', N''0912345678'', N''Active'', N''HV016''),
    (17, ''1996-05-17T00:00:00.0000000'', N''trinhthiq@example.com'', ''2024-09-01T00:00:00.0000000'', N''Trịnh Thị Q'', N''Nữ'', N''0934456677'', N''Inactive'', N''HV017''),
    (18, ''1995-08-09T00:00:00.0000000'', N''dangvanr@example.com'', ''2024-09-01T00:00:00.0000000'', N''Đặng Văn R'', N''Nam'', N''0909871234'', N''Active'', N''HV018''),
    (19, ''1999-10-10T00:00:00.0000000'', N''luongthis@example.com'', ''2024-09-01T00:00:00.0000000'', N''Lương Thị S'', N''Nữ'', N''0977889900'', N''Active'', N''HV019''),
    (20, ''1997-06-28T00:00:00.0000000'', N''phanvant@example.com'', ''2024-09-01T00:00:00.0000000'', N''Phan Văn T'', N''Nam'', N''0923345678'', N''Inactive'', N''HV020''),
    (21, ''1998-11-12T00:00:00.0000000'', N''nguyenvanu@example.com'', ''2024-09-01T00:00:00.0000000'', N''Nguyễn Văn U'', N''Nam'', N''0911234567'', N''Active'', N''HV021''),
    (22, ''1997-02-10T00:00:00.0000000'', N''vuthiv@example.com'', ''2024-09-01T00:00:00.0000000'', N''Vũ Thị V'', N''Nữ'', N''0942345678'', N''Active'', N''HV022''),
    (23, ''2001-09-14T00:00:00.0000000'', N''truongthiww@example.com'', ''2024-09-01T00:00:00.0000000'', N''Trương Thị W'', N''Nữ'', N''0976456789'', N''Inactive'', N''HV023''),
    (24, ''1999-07-06T00:00:00.0000000'', N''levanx@example.com'', ''2024-09-01T00:00:00.0000000'', N''Lê Văn X'', N''Nam'', N''0923456789'', N''Active'', N''HV024''),
    (25, ''1998-12-25T00:00:00.0000000'', N''nguyenthiy@example.com'', ''2024-09-01T00:00:00.0000000'', N''Nguyễn Thị Y'', N''Nữ'', N''0908765432'', N''Active'', N''HV025''),
    (26, ''1995-04-30T00:00:00.0000000'', N''buivanz@example.com'', ''2024-09-01T00:00:00.0000000'', N''Bùi Văn Z'', N''Nam'', N''0912345678'', N''Inactive'', N''HV026''),
    (27, ''2000-11-14T00:00:00.0000000'', N''dothiaa@example.com'', ''2024-09-01T00:00:00.0000000'', N''Đỗ Thị AA'', N''Nữ'', N''0934567890'', N''Active'', N''HV027''),
    (28, ''1997-01-21T00:00:00.0000000'', N''nguyenvanbb@example.com'', ''2024-09-01T00:00:00.0000000'', N''Nguyễn Văn BB'', N''Nam'', N''0922334455'', N''Active'', N''HV028''),
    (29, ''1999-08-13T00:00:00.0000000'', N''lethicc@example.com'', ''2024-09-01T00:00:00.0000000'', N''Lê Thị CC'', N''Nữ'', N''0916543210'', N''Inactive'', N''HV029''),
    (30, ''1996-06-07T00:00:00.0000000'', N''tranvandd@example.com'', ''2024-09-01T00:00:00.0000000'', N''Trần Văn DD'', N''Nam'', N''0909876543'', N''Active'', N''HV030''),
    (31, ''2000-03-19T00:00:00.0000000'', N''vuthiee@example.com'', ''2024-09-01T00:00:00.0000000'', N''Vũ Thị EE'', N''Nữ'', N''0976543210'', N''Active'', N''HV031''),
    (32, ''1998-10-29T00:00:00.0000000'', N''buivanff@example.com'', ''2024-09-01T00:00:00.0000000'', N''Bùi Văn FF'', N''Nam'', N''0922334455'', N''Inactive'', N''HV032''),
    (33, ''1997-05-22T00:00:00.0000000'', N''nguyenthigg@example.com'', ''2024-09-01T00:00:00.0000000'', N''Nguyễn Thị GG'', N''Nữ'', N''0934567890'', N''Active'', N''HV033''),
    (34, ''1999-12-11T00:00:00.0000000'', N''levanhh@example.com'', ''2024-09-01T00:00:00.0000000'', N''Lê Văn HH'', N''Nam'', N''0945678901'', N''Active'', N''HV034''),
    (35, ''2000-04-04T00:00:00.0000000'', N''truongthii@example.com'', ''2024-09-01T00:00:00.0000000'', N''Trương Thị II'', N''Nữ'', N''0977654321'', N''Inactive'', N''HV035''),
    (36, ''1996-08-16T00:00:00.0000000'', N''dovanjj@example.com'', ''2024-09-01T00:00:00.0000000'', N''Đỗ Văn JJ'', N''Nam'', N''0909871234'', N''Active'', N''HV036''),
    (37, ''1998-01-03T00:00:00.0000000'', N''nguyenthikk@example.com'', ''2024-09-01T00:00:00.0000000'', N''Nguyễn Thị KK'', N''Nữ'', N''0912345678'', N''Active'', N''HV037''),
    (38, ''2001-07-29T00:00:00.0000000'', N''levanll@example.com'', ''2024-09-01T00:00:00.0000000'', N''Lê Văn LL'', N''Nam'', N''0923456789'', N''Inactive'', N''HV038''),
    (39, ''1999-06-17T00:00:00.0000000'', N''vuthimm@example.com'', ''2024-09-01T00:00:00.0000000'', N''Vũ Thị MM'', N''Nữ'', N''0934567890'', N''Active'', N''HV039''),
    (40, ''1995-03-12T00:00:00.0000000'', N''buivannn@example.com'', ''2024-09-01T00:00:00.0000000'', N''Bùi Văn NN'', N''Nam'', N''0912345678'', N''Inactive'', N''HV040''),
    (41, ''1997-11-04T00:00:00.0000000'', N''tranthioo@example.com'', ''2024-09-01T00:00:00.0000000'', N''Trần Thị OO'', N''Nữ'', N''0976543210'', N''Active'', N''HV041''),
    (42, ''1998-09-25T00:00:00.0000000'', N''nguyenvanpp@example.com'', ''2024-09-01T00:00:00.0000000'', N''Nguyễn Văn PP'', N''Nam'', N''0945678901'', N''Active'', N''HV042'');
    INSERT INTO [Student] ([Id], [DateOfBirth], [Email], [EnrollmentDate], [FullName], [Gender], [PhoneNumber], [Status], [StudentCode])
    VALUES (43, ''1996-02-08T00:00:00.0000000'', N''lethiqq@example.com'', ''2024-09-01T00:00:00.0000000'', N''Lê Thị QQ'', N''Nữ'', N''0934567890'', N''Inactive'', N''HV043''),
    (44, ''1999-12-20T00:00:00.0000000'', N''truongvanrr@example.com'', ''2024-09-01T00:00:00.0000000'', N''Trương Văn RR'', N''Nam'', N''0922334455'', N''Active'', N''HV044''),
    (45, ''2000-06-15T00:00:00.0000000'', N''dothiss@example.com'', ''2024-09-01T00:00:00.0000000'', N''Đỗ Thị SS'', N''Nữ'', N''0908765432'', N''Inactive'', N''HV045''),
    (46, ''1998-10-07T00:00:00.0000000'', N''nguyenthitt@example.com'', ''2024-09-01T00:00:00.0000000'', N''Nguyễn Thị TT'', N''Nữ'', N''0912345678'', N''Active'', N''HV046''),
    (47, ''1996-08-24T00:00:00.0000000'', N''levanuu@example.com'', ''2024-09-01T00:00:00.0000000'', N''Lê Văn UU'', N''Nam'', N''0923456789'', N''Active'', N''HV047''),
    (48, ''2000-05-05T00:00:00.0000000'', N''tranthivv@example.com'', ''2024-09-01T00:00:00.0000000'', N''Trần Thị VV'', N''Nữ'', N''0934567890'', N''Inactive'', N''HV048''),
    (49, ''1999-07-11T00:00:00.0000000'', N''buivanww@example.com'', ''2024-09-01T00:00:00.0000000'', N''Bùi Văn WW'', N''Nam'', N''0976543210'', N''Active'', N''HV049''),
    (50, ''2001-04-20T00:00:00.0000000'', N''nguyenthixx@example.com'', ''2024-09-01T00:00:00.0000000'', N''Nguyễn Thị XX'', N''Nữ'', N''0901234567'', N''Active'', N''HV050'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DateOfBirth', N'Email', N'EnrollmentDate', N'FullName', N'Gender', N'PhoneNumber', N'Status', N'StudentCode') AND [object_id] = OBJECT_ID(N'[Student]'))
        SET IDENTITY_INSERT [Student] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009081332_InitDb'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Address', N'DateOfBirth', N'Email', N'EndDate', N'FullName', N'Gender', N'HireDate', N'ImgUrl', N'IsActive', N'PhoneNumber', N'TeacherCode') AND [object_id] = OBJECT_ID(N'[Teacher]'))
        SET IDENTITY_INSERT [Teacher] ON;
    EXEC(N'INSERT INTO [Teacher] ([Id], [Address], [DateOfBirth], [Email], [EndDate], [FullName], [Gender], [HireDate], [ImgUrl], [IsActive], [PhoneNumber], [TeacherCode])
    VALUES (1, N''123 Đường ABC, Hà Nội'', ''1980-05-15T00:00:00.0000000'', N''nguyenvana@example.com'', NULL, N''Nguyễn Văn A'', N''Nam'', ''2010-01-10T00:00:00.0000000'', N''http://example.com/img1.jpg'', CAST(1 AS bit), N''0901234567'', N''GV001''),
    (2, N''456 Đường DEF, Hà Nội'', ''1985-08-22T00:00:00.0000000'', N''tranthib@example.com'', NULL, N''Trần Thị B'', N''Nữ'', ''2012-04-20T00:00:00.0000000'', N''http://example.com/img2.jpg'', CAST(1 AS bit), N''0912345678'', N''GV002''),
    (3, N''789 Đường GHI, Hà Nội'', ''1990-03-30T00:00:00.0000000'', N''levanc@example.com'', NULL, N''Lê Văn C'', N''Nam'', ''2015-06-15T00:00:00.0000000'', N''http://example.com/img3.jpg'', CAST(1 AS bit), N''0923456789'', N''GV003''),
    (4, N''101 Đường JKL, Hà Nội'', ''1988-07-10T00:00:00.0000000'', N''nguyenthid@example.com'', NULL, N''Nguyễn Thị D'', N''Nữ'', ''2018-03-25T00:00:00.0000000'', N''http://example.com/img4.jpg'', CAST(1 AS bit), N''0934567890'', N''GV004''),
    (5, N''202 Đường MNO, Hà Nội'', ''1979-11-05T00:00:00.0000000'', N''truongvane@example.com'', NULL, N''Trương Văn E'', N''Nam'', ''2010-07-30T00:00:00.0000000'', N''http://example.com/img5.jpg'', CAST(1 AS bit), N''0945678901'', N''GV005''),
    (6, N''303 Đường PQR, Hà Nội'', ''1983-09-14T00:00:00.0000000'', N''buithif@example.com'', NULL, N''Bùi Thị F'', N''Nữ'', ''2014-05-10T00:00:00.0000000'', N''http://example.com/img6.jpg'', CAST(1 AS bit), N''0956789012'', N''GV006''),
    (7, N''404 Đường STU, Hà Nội'', ''1991-12-21T00:00:00.0000000'', N''dovang@example.com'', NULL, N''Đỗ Văn G'', N''Nam'', ''2016-11-15T00:00:00.0000000'', N''http://example.com/img7.jpg'', CAST(1 AS bit), N''0967890123'', N''GV007''),
    (8, N''505 Đường VWX, Hà Nội'', ''1986-04-02T00:00:00.0000000'', N''nguyenthih@example.com'', NULL, N''Nguyễn Thị H'', N''Nữ'', ''2012-09-05T00:00:00.0000000'', N''http://example.com/img8.jpg'', CAST(1 AS bit), N''0978901234'', N''GV008''),
    (9, N''606 Đường YZA, Hà Nội'', ''1990-06-18T00:00:00.0000000'', N''levani@example.com'', NULL, N''Lê Văn I'', N''Nam'', ''2018-03-25T00:00:00.0000000'', N''http://example.com/img9.jpg'', CAST(1 AS bit), N''0989012345'', N''GV009''),
    (10, N''707 Đường BCD, Hà Nội'', ''1985-10-07T00:00:00.0000000'', N''tranthij@example.com'', NULL, N''Trần Thị J'', N''Nữ'', ''2015-04-12T00:00:00.0000000'', N''http://example.com/img10.jpg'', CAST(1 AS bit), N''0990123456'', N''GV010'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Address', N'DateOfBirth', N'Email', N'EndDate', N'FullName', N'Gender', N'HireDate', N'ImgUrl', N'IsActive', N'PhoneNumber', N'TeacherCode') AND [object_id] = OBJECT_ID(N'[Teacher]'))
        SET IDENTITY_INSERT [Teacher] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009081332_InitDb'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DayName') AND [object_id] = OBJECT_ID(N'[Weekday]'))
        SET IDENTITY_INSERT [Weekday] ON;
    EXEC(N'INSERT INTO [Weekday] ([Id], [DayName])
    VALUES (1, N''Monday''),
    (2, N''Tuesday''),
    (3, N''Wednesday''),
    (4, N''Thursday''),
    (5, N''Friday''),
    (6, N''Saturday''),
    (7, N''Sunday'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DayName') AND [object_id] = OBJECT_ID(N'[Weekday]'))
        SET IDENTITY_INSERT [Weekday] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009081332_InitDb'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'LanguageId', N'LevelCode', N'LevelName') AND [object_id] = OBJECT_ID(N'[Level]'))
        SET IDENTITY_INSERT [Level] ON;
    EXEC(N'INSERT INTO [Level] ([Id], [LanguageId], [LevelCode], [LevelName])
    VALUES (1, 1, N''A1'', N''Beginner''),
    (2, 1, N''A2'', N''Elementary''),
    (3, 1, N''B1'', N''Intermediate''),
    (4, 1, N''B2'', N''Upper Intermediate''),
    (5, 1, N''C1'', N''Advanced''),
    (6, 1, N''C2'', N''Proficient''),
    (7, 2, N''A1'', N''Débutant''),
    (8, 2, N''A2'', N''Élémentaire''),
    (9, 2, N''B1'', N''Intermédiaire''),
    (10, 2, N''B2'', N''Supérieur''),
    (11, 2, N''C1'', N''Avancé''),
    (12, 2, N''C2'', N''Maîtrise''),
    (13, 3, N''A1'', N''Principiante''),
    (14, 3, N''A2'', N''Elemental''),
    (15, 3, N''B1'', N''Intermedio''),
    (16, 3, N''B2'', N''Avanzado''),
    (17, 3, N''C1'', N''Superior''),
    (18, 3, N''C2'', N''Maestría''),
    (19, 4, N''HSK 1'', N''Beginner''),
    (20, 4, N''HSK 2'', N''Elementary''),
    (21, 4, N''HSK 3'', N''Intermediate''),
    (22, 4, N''HSK 4'', N''Upper Intermediate''),
    (23, 4, N''HSK 5'', N''Advanced''),
    (24, 4, N''HSK 6'', N''Proficient''),
    (25, 5, N''N5'', N''Beginner''),
    (26, 5, N''N4'', N''Elementary''),
    (27, 5, N''N3'', N''Intermediate''),
    (28, 5, N''N2'', N''Upper Intermediate''),
    (29, 5, N''N1'', N''Advanced'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'LanguageId', N'LevelCode', N'LevelName') AND [object_id] = OBJECT_ID(N'[Level]'))
        SET IDENTITY_INSERT [Level] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009081332_InitDb'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Address', N'DateOfBirth', N'Email', N'EndDate', N'FullName', N'Gender', N'HireDate', N'ImgUrl', N'IsActive', N'PasswordHash', N'PhoneNumber', N'RoleId') AND [object_id] = OBJECT_ID(N'[Staff]'))
        SET IDENTITY_INSERT [Staff] ON;
    EXEC(N'INSERT INTO [Staff] ([Id], [Address], [DateOfBirth], [Email], [EndDate], [FullName], [Gender], [HireDate], [ImgUrl], [IsActive], [PasswordHash], [PhoneNumber], [RoleId])
    VALUES (1, N''123 đường ABC, Hà Nội, VN'', ''2003-04-28T00:00:00.0000000'', N''tranhongquan.dev@gmail.com'', NULL, N''Quản trị viên'', N''Nam'', ''2024-09-12T00:00:00.0000000'', NULL, CAST(1 AS bit), N''$2a$11$mVOzIRFb71alNYrUvBcknOhWMJnnebsW4EDRz7/pjjBTiF0s9u4Ci'', N''123456789'', 1)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Address', N'DateOfBirth', N'Email', N'EndDate', N'FullName', N'Gender', N'HireDate', N'ImgUrl', N'IsActive', N'PasswordHash', N'PhoneNumber', N'RoleId') AND [object_id] = OBJECT_ID(N'[Staff]'))
        SET IDENTITY_INSERT [Staff] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009081332_InitDb'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CourseCode', N'CourseName', N'CreatedDate', N'Description', N'Discount', N'Duration', N'Fee', N'IsActive', N'LevelId', N'TotalFee', N'UpdatedDate') AND [object_id] = OBJECT_ID(N'[Course]'))
        SET IDENTITY_INSERT [Course] ON;
    EXEC(N'INSERT INTO [Course] ([Id], [CourseCode], [CourseName], [CreatedDate], [Description], [Discount], [Duration], [Fee], [IsActive], [LevelId], [TotalFee], [UpdatedDate])
    VALUES (1, N''EN001'', N''English for Beginners'', ''2024-01-01T00:00:00.0000000'', N''Introduction to English for complete beginners.'', 0.10000000000000001E0, N''3 months'', 3500000.0E0, CAST(1 AS bit), 1, 3150000.0E0, ''2024-01-10T00:00:00.0000000''),
    (2, N''EN002'', N''Elementary English'', ''2024-02-01T00:00:00.0000000'', N''Basic English skills for elementary level.'', 0.10000000000000001E0, N''3 months'', 4000000.0E0, CAST(1 AS bit), 2, 3600000.0E0, ''2024-02-10T00:00:00.0000000''),
    (3, N''EN003'', N''Intermediate English'', ''2024-03-01T00:00:00.0000000'', N''Improve your English skills with intermediate level courses.'', 0.14999999999999999E0, N''4 months'', 5000000.0E0, CAST(1 AS bit), 3, 4250000.0E0, ''2024-03-10T00:00:00.0000000''),
    (4, N''EN004'', N''Upper Intermediate English'', ''2024-04-01T00:00:00.0000000'', N''Enhance your English proficiency at an upper intermediate level.'', 0.20000000000000001E0, N''5 months'', 6500000.0E0, CAST(1 AS bit), 4, 5200000.0E0, ''2024-04-10T00:00:00.0000000''),
    (5, N''EN005'', N''Advanced English'', ''2024-05-01T00:00:00.0000000'', N''Master advanced English skills with specialized courses.'', 0.25E0, N''6 months'', 8000000.0E0, CAST(1 AS bit), 5, 6000000.0E0, ''2024-05-10T00:00:00.0000000''),
    (6, N''FR001'', N''Débutant en Français'', ''2024-06-01T00:00:00.0000000'', N''Introduction au français pour débutants.'', 0.10000000000000001E0, N''3 months'', 3200000.0E0, CAST(1 AS bit), 6, 2880000.0E0, ''2024-06-10T00:00:00.0000000''),
    (7, N''FR002'', N''Français Élémentaire'', ''2024-07-01T00:00:00.0000000'', N''Compétences de base en français à un niveau élémentaire.'', 0.10000000000000001E0, N''3 months'', 3600000.0E0, CAST(1 AS bit), 7, 3240000.0E0, ''2024-07-10T00:00:00.0000000''),
    (8, N''FR003'', N''Français Intermédiaire'', ''2024-08-01T00:00:00.0000000'', N''Améliorez vos compétences en français à un niveau intermédiaire.'', 0.14999999999999999E0, N''4 months'', 4500000.0E0, CAST(1 AS bit), 8, 3825000.0E0, ''2024-08-10T00:00:00.0000000''),
    (9, N''FR004'', N''Français Supérieur'', ''2024-09-01T00:00:00.0000000'', N''Perfectionnez votre français à un niveau supérieur.'', 0.20000000000000001E0, N''5 months'', 5800000.0E0, CAST(1 AS bit), 9, 4640000.0E0, ''2024-09-10T00:00:00.0000000''),
    (10, N''FR005'', N''Français Avancé'', ''2024-10-01T00:00:00.0000000'', N''Maîtrisez le français avec des cours avancés.'', 0.25E0, N''6 months'', 7200000.0E0, CAST(1 AS bit), 10, 5400000.0E0, ''2024-10-10T00:00:00.0000000''),
    (11, N''ES001'', N''Principiante en Español'', ''2024-11-01T00:00:00.0000000'', N''Introducción al español para principiantes.'', 0.10000000000000001E0, N''3 months'', 3500000.0E0, CAST(1 AS bit), 11, 3150000.0E0, ''2024-11-10T00:00:00.0000000''),
    (12, N''ES002'', N''Español Elemental'', ''2024-12-01T00:00:00.0000000'', N''Habilidades básicas en español a nivel elemental.'', 0.10000000000000001E0, N''3 months'', 4000000.0E0, CAST(1 AS bit), 12, 3600000.0E0, ''2024-12-10T00:00:00.0000000''),
    (13, N''ES003'', N''Español Intermedio'', ''2024-01-15T00:00:00.0000000'', N''Mejore sus habilidades en español con cursos intermedios.'', 0.14999999999999999E0, N''4 months'', 5000000.0E0, CAST(1 AS bit), 13, 4250000.0E0, ''2024-01-20T00:00:00.0000000''),
    (14, N''ES004'', N''Español Avanzado'', ''2024-02-15T00:00:00.0000000'', N''Perfeccione su español con cursos avanzados.'', 0.20000000000000001E0, N''5 months'', 6500000.0E0, CAST(1 AS bit), 14, 5200000.0E0, ''2024-02-20T00:00:00.0000000''),
    (15, N''ES005'', N''Maestría en Español'', ''2024-03-15T00:00:00.0000000'', N''Maestría en el uso del español con cursos de nivel superior.'', 0.25E0, N''6 months'', 8000000.0E0, CAST(1 AS bit), 15, 6000000.0E0, ''2024-03-20T00:00:00.0000000'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CourseCode', N'CourseName', N'CreatedDate', N'Description', N'Discount', N'Duration', N'Fee', N'IsActive', N'LevelId', N'TotalFee', N'UpdatedDate') AND [object_id] = OBJECT_ID(N'[Course]'))
        SET IDENTITY_INSERT [Course] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009081332_InitDb'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CourseCode', N'CourseName', N'CreatedDate', N'Description', N'Discount', N'Duration', N'IsActive', N'LevelId', N'TotalFee', N'UpdatedDate') AND [object_id] = OBJECT_ID(N'[Course]'))
        SET IDENTITY_INSERT [Course] ON;
    EXEC(N'INSERT INTO [Course] ([Id], [CourseCode], [CourseName], [CreatedDate], [Description], [Discount], [Duration], [IsActive], [LevelId], [TotalFee], [UpdatedDate])
    VALUES (16, N''ZH001'', N''HSK 1 Chinese'', ''2024-04-05T00:00:00.0000000'', N''Introduction to Chinese at HSK 1 level.'', 0.10000000000000001E0, N''3 months'', CAST(1 AS bit), 16, 2700000.0E0, ''2024-04-10T00:00:00.0000000'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CourseCode', N'CourseName', N'CreatedDate', N'Description', N'Discount', N'Duration', N'IsActive', N'LevelId', N'TotalFee', N'UpdatedDate') AND [object_id] = OBJECT_ID(N'[Course]'))
        SET IDENTITY_INSERT [Course] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009081332_InitDb'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CourseCode', N'CourseName', N'CreatedDate', N'Description', N'Discount', N'Duration', N'Fee', N'IsActive', N'LevelId', N'TotalFee', N'UpdatedDate') AND [object_id] = OBJECT_ID(N'[Course]'))
        SET IDENTITY_INSERT [Course] ON;
    EXEC(N'INSERT INTO [Course] ([Id], [CourseCode], [CourseName], [CreatedDate], [Description], [Discount], [Duration], [Fee], [IsActive], [LevelId], [TotalFee], [UpdatedDate])
    VALUES (17, N''ZH002'', N''HSK 2 Chinese'', ''2024-05-05T00:00:00.0000000'', N''Chinese course at HSK 2 level.'', 0.10000000000000001E0, N''3 months'', 3500000.0E0, CAST(1 AS bit), 17, 3150000.0E0, ''2024-05-10T00:00:00.0000000''),
    (18, N''ZH003'', N''HSK 3 Chinese'', ''2024-06-05T00:00:00.0000000'', N''Intermediate Chinese course at HSK 3 level.'', 0.14999999999999999E0, N''4 months'', 4500000.0E0, CAST(1 AS bit), 18, 3825000.0E0, ''2024-06-10T00:00:00.0000000''),
    (19, N''ZH004'', N''HSK 4 Chinese'', ''2024-07-05T00:00:00.0000000'', N''Advanced Chinese course at HSK 4 level.'', 0.20000000000000001E0, N''5 months'', 5800000.0E0, CAST(1 AS bit), 19, 4640000.0E0, ''2024-07-10T00:00:00.0000000''),
    (20, N''ZH005'', N''HSK 5 Chinese'', ''2024-08-05T00:00:00.0000000'', N''Master Chinese skills at HSK 5 level.'', 0.25E0, N''6 months'', 7200000.0E0, CAST(1 AS bit), 20, 5400000.0E0, ''2024-08-10T00:00:00.0000000'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CourseCode', N'CourseName', N'CreatedDate', N'Description', N'Discount', N'Duration', N'Fee', N'IsActive', N'LevelId', N'TotalFee', N'UpdatedDate') AND [object_id] = OBJECT_ID(N'[Course]'))
        SET IDENTITY_INSERT [Course] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009081332_InitDb'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ClassCode', N'ClassName', N'CourseId', N'EndDate', N'StartDate', N'TeacherId') AND [object_id] = OBJECT_ID(N'[Class]'))
        SET IDENTITY_INSERT [Class] ON;
    EXEC(N'INSERT INTO [Class] ([Id], [ClassCode], [ClassName], [CourseId], [EndDate], [StartDate], [TeacherId])
    VALUES (1, N''C001'', N''English Beginner A'', 1, ''2024-04-10T00:00:00.0000000'', ''2024-01-10T00:00:00.0000000'', 1),
    (2, N''C002'', N''English Beginner B'', 2, ''2024-05-10T00:00:00.0000000'', ''2024-02-10T00:00:00.0000000'', 2),
    (3, N''C003'', N''English Intermediate A'', 3, ''2024-06-10T00:00:00.0000000'', ''2024-03-10T00:00:00.0000000'', 3),
    (4, N''C004'', N''English Upper Intermediate A'', 4, ''2024-07-10T00:00:00.0000000'', ''2024-04-10T00:00:00.0000000'', 4),
    (5, N''C005'', N''English Advanced A'', 5, ''2024-08-10T00:00:00.0000000'', ''2024-05-10T00:00:00.0000000'', 5),
    (6, N''C006'', N''French Beginner A'', 6, ''2024-09-10T00:00:00.0000000'', ''2024-06-10T00:00:00.0000000'', 6),
    (7, N''C007'', N''French Beginner B'', 7, ''2024-10-10T00:00:00.0000000'', ''2024-07-10T00:00:00.0000000'', 7),
    (8, N''C008'', N''French Intermediate A'', 8, ''2024-11-10T00:00:00.0000000'', ''2024-08-10T00:00:00.0000000'', 8),
    (9, N''C009'', N''French Upper Intermediate A'', 9, ''2024-12-10T00:00:00.0000000'', ''2024-09-10T00:00:00.0000000'', 9),
    (10, N''C010'', N''French Advanced A'', 10, ''2025-01-10T00:00:00.0000000'', ''2024-10-10T00:00:00.0000000'', 10),
    (11, N''C011'', N''Spanish Beginner A'', 11, ''2025-02-10T00:00:00.0000000'', ''2024-11-10T00:00:00.0000000'', 1),
    (12, N''C012'', N''Spanish Beginner B'', 12, ''2025-03-10T00:00:00.0000000'', ''2024-12-10T00:00:00.0000000'', 2),
    (13, N''C013'', N''Spanish Intermediate A'', 13, ''2025-04-10T00:00:00.0000000'', ''2025-01-10T00:00:00.0000000'', 3),
    (14, N''C014'', N''Spanish Upper Intermediate A'', 14, ''2025-05-10T00:00:00.0000000'', ''2025-02-10T00:00:00.0000000'', 4),
    (15, N''C015'', N''Spanish Advanced A'', 15, ''2025-06-10T00:00:00.0000000'', ''2025-03-10T00:00:00.0000000'', 5),
    (16, N''C016'', N''Chinese HSK 1 A'', 16, ''2025-07-10T00:00:00.0000000'', ''2025-04-10T00:00:00.0000000'', 6),
    (17, N''C017'', N''Chinese HSK 2 A'', 17, ''2025-08-10T00:00:00.0000000'', ''2025-05-10T00:00:00.0000000'', 7),
    (18, N''C018'', N''Chinese HSK 3 A'', 18, ''2025-09-10T00:00:00.0000000'', ''2025-06-10T00:00:00.0000000'', 8),
    (19, N''C019'', N''Chinese HSK 4 A'', 19, ''2025-10-10T00:00:00.0000000'', ''2025-07-10T00:00:00.0000000'', 9),
    (20, N''C020'', N''Chinese HSK 5 A'', 20, ''2025-11-10T00:00:00.0000000'', ''2025-08-10T00:00:00.0000000'', 10)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ClassCode', N'ClassName', N'CourseId', N'EndDate', N'StartDate', N'TeacherId') AND [object_id] = OBJECT_ID(N'[Class]'))
        SET IDENTITY_INSERT [Class] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009081332_InitDb'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ClassId', N'StudentId') AND [object_id] = OBJECT_ID(N'[ClassStudents]'))
        SET IDENTITY_INSERT [ClassStudents] ON;
    EXEC(N'INSERT INTO [ClassStudents] ([ClassId], [StudentId])
    VALUES (1, 1),
    (2, 1),
    (6, 1),
    (9, 1),
    (13, 1),
    (17, 1),
    (1, 2),
    (2, 2),
    (6, 2),
    (9, 2),
    (13, 2),
    (17, 2),
    (1, 3),
    (2, 3),
    (6, 3),
    (10, 3),
    (13, 3),
    (17, 3),
    (1, 4),
    (2, 4),
    (6, 4),
    (10, 4),
    (13, 4),
    (17, 4),
    (1, 5),
    (3, 5),
    (6, 5),
    (10, 5),
    (13, 5),
    (17, 5),
    (1, 6),
    (3, 6),
    (6, 6),
    (10, 6),
    (13, 6),
    (17, 6),
    (1, 7),
    (3, 7),
    (6, 7),
    (10, 7),
    (13, 7),
    (17, 7);
    INSERT INTO [ClassStudents] ([ClassId], [StudentId])
    VALUES (1, 8),
    (3, 8),
    (6, 8),
    (10, 8),
    (13, 8),
    (17, 8),
    (1, 9),
    (3, 9),
    (6, 9),
    (10, 9),
    (14, 9),
    (17, 9),
    (1, 10),
    (3, 10),
    (6, 10),
    (10, 10),
    (14, 10),
    (17, 10),
    (1, 11),
    (3, 11),
    (7, 11),
    (10, 11),
    (14, 11),
    (17, 11),
    (1, 12),
    (3, 12),
    (7, 12),
    (10, 12),
    (14, 12),
    (17, 12),
    (1, 13),
    (3, 13),
    (7, 13),
    (10, 13),
    (14, 13),
    (17, 13),
    (1, 14),
    (3, 14),
    (7, 14),
    (10, 14),
    (14, 14),
    (17, 14);
    INSERT INTO [ClassStudents] ([ClassId], [StudentId])
    VALUES (1, 15),
    (3, 15),
    (7, 15),
    (10, 15),
    (14, 15),
    (18, 15),
    (2, 16),
    (3, 16),
    (7, 16),
    (10, 16),
    (14, 16),
    (18, 16),
    (2, 17),
    (3, 17),
    (7, 17),
    (11, 17),
    (14, 17),
    (18, 17),
    (2, 18),
    (3, 18),
    (7, 18),
    (11, 18),
    (14, 18),
    (18, 18),
    (2, 19),
    (4, 19),
    (7, 19),
    (11, 19),
    (14, 19),
    (18, 19),
    (2, 20),
    (4, 20),
    (7, 20),
    (11, 20),
    (14, 20),
    (18, 20),
    (2, 21),
    (4, 21),
    (7, 21),
    (11, 21),
    (14, 21),
    (18, 21);
    INSERT INTO [ClassStudents] ([ClassId], [StudentId])
    VALUES (2, 22),
    (4, 22),
    (7, 22),
    (11, 22),
    (14, 22),
    (18, 22),
    (2, 23),
    (4, 23),
    (7, 23),
    (11, 23),
    (15, 23),
    (18, 23),
    (2, 24),
    (4, 24),
    (7, 24),
    (11, 24),
    (15, 24),
    (18, 24),
    (2, 25),
    (4, 25),
    (8, 25),
    (11, 25),
    (15, 25),
    (18, 25),
    (4, 26),
    (8, 26),
    (11, 26),
    (15, 26),
    (18, 26),
    (4, 27),
    (8, 27),
    (11, 27),
    (15, 27),
    (18, 27),
    (4, 28),
    (8, 28),
    (11, 28),
    (15, 28),
    (18, 28),
    (4, 29),
    (8, 29),
    (11, 29);
    INSERT INTO [ClassStudents] ([ClassId], [StudentId])
    VALUES (15, 29),
    (4, 30),
    (8, 30),
    (11, 30),
    (15, 30),
    (4, 31),
    (8, 31),
    (12, 31),
    (15, 31),
    (4, 32),
    (8, 32),
    (12, 32),
    (15, 32),
    (5, 33),
    (8, 33),
    (12, 33),
    (15, 33),
    (5, 34),
    (8, 34),
    (12, 34),
    (15, 34),
    (5, 35),
    (8, 35),
    (12, 35),
    (15, 35),
    (5, 36),
    (8, 36),
    (12, 36),
    (15, 36),
    (5, 37),
    (8, 37),
    (12, 37),
    (16, 37),
    (5, 38),
    (8, 38),
    (12, 38),
    (16, 38),
    (5, 39),
    (9, 39),
    (12, 39),
    (16, 39),
    (5, 40);
    INSERT INTO [ClassStudents] ([ClassId], [StudentId])
    VALUES (9, 40),
    (12, 40),
    (16, 40),
    (5, 41),
    (9, 41),
    (12, 41),
    (16, 41),
    (5, 42),
    (9, 42),
    (12, 42),
    (16, 42),
    (5, 43),
    (9, 43),
    (12, 43),
    (16, 43),
    (5, 44),
    (9, 44),
    (12, 44),
    (16, 44),
    (5, 45),
    (9, 45),
    (13, 45),
    (16, 45),
    (5, 46),
    (9, 46),
    (13, 46),
    (16, 46),
    (6, 47),
    (9, 47),
    (13, 47),
    (16, 47),
    (6, 48),
    (9, 48),
    (13, 48),
    (16, 48),
    (6, 49),
    (9, 49),
    (13, 49),
    (16, 49),
    (6, 50),
    (9, 50),
    (13, 50);
    INSERT INTO [ClassStudents] ([ClassId], [StudentId])
    VALUES (16, 50)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ClassId', N'StudentId') AND [object_id] = OBJECT_ID(N'[ClassStudents]'))
        SET IDENTITY_INSERT [ClassStudents] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009081332_InitDb'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ClassId', N'WeekdayId', N'EndTime', N'StartTime') AND [object_id] = OBJECT_ID(N'[ClassWeekday]'))
        SET IDENTITY_INSERT [ClassWeekday] ON;
    EXEC(N'INSERT INTO [ClassWeekday] ([ClassId], [WeekdayId], [EndTime], [StartTime])
    VALUES (1, 1, ''2024-09-23T10:00:00.0000000'', ''2024-09-23T08:00:00.0000000''),
    (1, 3, ''2024-09-25T12:00:00.0000000'', ''2024-09-25T10:00:00.0000000''),
    (1, 5, ''2024-09-27T15:00:00.0000000'', ''2024-09-27T13:00:00.0000000''),
    (2, 2, ''2024-09-24T11:00:00.0000000'', ''2024-09-24T09:00:00.0000000''),
    (2, 4, ''2024-09-26T13:00:00.0000000'', ''2024-09-26T11:00:00.0000000''),
    (2, 6, ''2024-09-28T16:00:00.0000000'', ''2024-09-28T14:00:00.0000000''),
    (3, 1, ''2024-09-23T17:00:00.0000000'', ''2024-09-23T15:00:00.0000000''),
    (3, 4, ''2024-09-26T10:00:00.0000000'', ''2024-09-26T08:00:00.0000000''),
    (3, 6, ''2024-09-28T18:00:00.0000000'', ''2024-09-28T16:00:00.0000000''),
    (4, 2, ''2024-09-24T15:00:00.0000000'', ''2024-09-24T13:00:00.0000000''),
    (4, 3, ''2024-09-25T11:00:00.0000000'', ''2024-09-25T09:00:00.0000000''),
    (4, 5, ''2024-09-27T17:00:00.0000000'', ''2024-09-27T15:00:00.0000000''),
    (5, 1, ''2024-09-23T12:00:00.0000000'', ''2024-09-23T10:00:00.0000000''),
    (5, 2, ''2024-09-24T16:00:00.0000000'', ''2024-09-24T14:00:00.0000000''),
    (5, 4, ''2024-09-26T13:00:00.0000000'', ''2024-09-26T11:00:00.0000000''),
    (6, 3, ''2024-09-25T10:00:00.0000000'', ''2024-09-25T08:00:00.0000000''),
    (6, 4, ''2024-09-26T15:00:00.0000000'', ''2024-09-26T13:00:00.0000000''),
    (6, 6, ''2024-09-28T12:00:00.0000000'', ''2024-09-28T10:00:00.0000000''),
    (7, 2, ''2024-09-24T10:00:00.0000000'', ''2024-09-24T08:00:00.0000000''),
    (7, 3, ''2024-09-25T13:00:00.0000000'', ''2024-09-25T11:00:00.0000000''),
    (7, 5, ''2024-09-27T16:00:00.0000000'', ''2024-09-27T14:00:00.0000000''),
    (8, 1, ''2024-09-23T10:00:00.0000000'', ''2024-09-23T08:00:00.0000000''),
    (8, 4, ''2024-09-26T12:00:00.0000000'', ''2024-09-26T10:00:00.0000000''),
    (8, 6, ''2024-09-28T15:00:00.0000000'', ''2024-09-28T13:00:00.0000000''),
    (9, 2, ''2024-09-24T12:00:00.0000000'', ''2024-09-24T10:00:00.0000000''),
    (9, 3, ''2024-09-25T16:00:00.0000000'', ''2024-09-25T14:00:00.0000000''),
    (9, 6, ''2024-09-28T11:00:00.0000000'', ''2024-09-28T09:00:00.0000000''),
    (10, 1, ''2024-09-23T13:00:00.0000000'', ''2024-09-23T11:00:00.0000000''),
    (10, 3, ''2024-09-25T18:00:00.0000000'', ''2024-09-25T16:00:00.0000000''),
    (10, 5, ''2024-09-27T10:00:00.0000000'', ''2024-09-27T08:00:00.0000000''),
    (11, 2, ''2024-09-24T17:00:00.0000000'', ''2024-09-24T15:00:00.0000000''),
    (11, 4, ''2024-09-26T10:00:00.0000000'', ''2024-09-26T08:00:00.0000000''),
    (11, 6, ''2024-09-28T16:00:00.0000000'', ''2024-09-28T14:00:00.0000000''),
    (12, 1, ''2024-09-23T15:00:00.0000000'', ''2024-09-23T13:00:00.0000000''),
    (12, 3, ''2024-09-25T11:00:00.0000000'', ''2024-09-25T09:00:00.0000000''),
    (12, 5, ''2024-09-27T13:00:00.0000000'', ''2024-09-27T11:00:00.0000000''),
    (13, 2, ''2024-09-24T11:00:00.0000000'', ''2024-09-24T09:00:00.0000000''),
    (13, 4, ''2024-09-26T15:00:00.0000000'', ''2024-09-26T13:00:00.0000000''),
    (13, 6, ''2024-09-28T13:00:00.0000000'', ''2024-09-28T11:00:00.0000000''),
    (14, 1, ''2024-09-23T17:00:00.0000000'', ''2024-09-23T15:00:00.0000000''),
    (14, 3, ''2024-09-25T12:00:00.0000000'', ''2024-09-25T10:00:00.0000000''),
    (14, 5, ''2024-09-27T15:00:00.0000000'', ''2024-09-27T13:00:00.0000000'');
    INSERT INTO [ClassWeekday] ([ClassId], [WeekdayId], [EndTime], [StartTime])
    VALUES (15, 2, ''2024-09-24T12:00:00.0000000'', ''2024-09-24T10:00:00.0000000''),
    (15, 4, ''2024-09-26T16:00:00.0000000'', ''2024-09-26T14:00:00.0000000''),
    (15, 6, ''2024-09-28T17:00:00.0000000'', ''2024-09-28T15:00:00.0000000''),
    (16, 1, ''2024-09-23T11:00:00.0000000'', ''2024-09-23T09:00:00.0000000''),
    (16, 3, ''2024-09-25T15:00:00.0000000'', ''2024-09-25T13:00:00.0000000''),
    (16, 5, ''2024-09-27T10:00:00.0000000'', ''2024-09-27T08:00:00.0000000''),
    (17, 2, ''2024-09-24T13:00:00.0000000'', ''2024-09-24T11:00:00.0000000''),
    (17, 4, ''2024-09-26T11:00:00.0000000'', ''2024-09-26T09:00:00.0000000''),
    (17, 6, ''2024-09-28T16:00:00.0000000'', ''2024-09-28T14:00:00.0000000''),
    (18, 1, ''2024-09-23T12:00:00.0000000'', ''2024-09-23T10:00:00.0000000''),
    (18, 3, ''2024-09-25T17:00:00.0000000'', ''2024-09-25T15:00:00.0000000''),
    (18, 5, ''2024-09-27T13:00:00.0000000'', ''2024-09-27T11:00:00.0000000'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ClassId', N'WeekdayId', N'EndTime', N'StartTime') AND [object_id] = OBJECT_ID(N'[ClassWeekday]'))
        SET IDENTITY_INSERT [ClassWeekday] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009081332_InitDb'
)
BEGIN
    CREATE INDEX [IX_Class_CourseId] ON [Class] ([CourseId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009081332_InitDb'
)
BEGIN
    CREATE INDEX [IX_Class_TeacherId] ON [Class] ([TeacherId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009081332_InitDb'
)
BEGIN
    CREATE INDEX [IX_ClassStudents_ClassId] ON [ClassStudents] ([ClassId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009081332_InitDb'
)
BEGIN
    CREATE INDEX [IX_ClassWeekday_WeekdayId] ON [ClassWeekday] ([WeekdayId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009081332_InitDb'
)
BEGIN
    CREATE INDEX [IX_Course_LevelId] ON [Course] ([LevelId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009081332_InitDb'
)
BEGIN
    CREATE INDEX [IX_Level_LanguageId] ON [Level] ([LanguageId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009081332_InitDb'
)
BEGIN
    CREATE INDEX [IX_Payment_CourseId] ON [Payment] ([CourseId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009081332_InitDb'
)
BEGIN
    CREATE INDEX [IX_Payment_PaymentMethodId] ON [Payment] ([PaymentMethodId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009081332_InitDb'
)
BEGIN
    CREATE INDEX [IX_Payment_StudentId] ON [Payment] ([StudentId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009081332_InitDb'
)
BEGIN
    CREATE INDEX [IX_Staff_RoleId] ON [Staff] ([RoleId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009081332_InitDb'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241009081332_InitDb', N'8.0.10');
END;
GO

COMMIT;
GO

