create table Class
(
    Id        int identity
        constraint PK_Class
            primary key,
    ClassCode nvarchar(max) default N'hWwexE',
    ClassName nvarchar(max) collate SQL_Latin1_General_CP1_CI_AI,
    StartDate datetime2,
    EndDate   datetime2,
    CourseId  int not null
        constraint FK_Class_Course_CourseId
            references Course
            on delete cascade,
    TeacherId int not null
        constraint FK_Class_Teacher_TeacherId
            references Teacher
            on delete cascade
)
go

create index IX_Class_CourseId
    on Class (CourseId)
go

create index IX_Class_TeacherId
    on Class (TeacherId)
go

INSERT INTO EngLabStore.dbo.Class (Id, ClassCode, ClassName, StartDate, EndDate, CourseId, TeacherId) VALUES (2, N'LV001', N'Lớp học LV', N'2024-11-28 14:15:28.8633333', N'2024-11-28 14:15:28.8633333', 2, 5);
INSERT INTO EngLabStore.dbo.Class (Id, ClassCode, ClassName, StartDate, EndDate, CourseId, TeacherId) VALUES (3, N'C003', N'English Intermediate A', N'2024-03-10 00:00:00.0000000', N'2024-06-10 00:00:00.0000000', 3, 3);
INSERT INTO EngLabStore.dbo.Class (Id, ClassCode, ClassName, StartDate, EndDate, CourseId, TeacherId) VALUES (4, N'C004', N'English Upper Intermediate A', N'2024-04-10 00:00:00.0000000', N'2024-07-10 00:00:00.0000000', 4, 4);
INSERT INTO EngLabStore.dbo.Class (Id, ClassCode, ClassName, StartDate, EndDate, CourseId, TeacherId) VALUES (6, N'C006', N'French Beginner A', N'2024-06-10 00:00:00.0000000', N'2024-09-10 00:00:00.0000000', 6, 6);
INSERT INTO EngLabStore.dbo.Class (Id, ClassCode, ClassName, StartDate, EndDate, CourseId, TeacherId) VALUES (7, N'C007', N'French Beginner B', N'2024-07-10 00:00:00.0000000', N'2024-10-10 00:00:00.0000000', 7, 7);
INSERT INTO EngLabStore.dbo.Class (Id, ClassCode, ClassName, StartDate, EndDate, CourseId, TeacherId) VALUES (8, N'C008', N'French Intermediate A', N'2024-08-10 00:00:00.0000000', N'2024-11-10 00:00:00.0000000', 8, 8);
INSERT INTO EngLabStore.dbo.Class (Id, ClassCode, ClassName, StartDate, EndDate, CourseId, TeacherId) VALUES (13, N'C013', N'Spanish Intermediate A', N'2025-01-10 00:00:00.0000000', N'2025-04-10 00:00:00.0000000', 13, 3);
INSERT INTO EngLabStore.dbo.Class (Id, ClassCode, ClassName, StartDate, EndDate, CourseId, TeacherId) VALUES (14, N'C014', N'Spanish Upper Intermediate A', N'2025-02-10 00:00:00.0000000', N'2025-05-10 00:00:00.0000000', 14, 4);
INSERT INTO EngLabStore.dbo.Class (Id, ClassCode, ClassName, StartDate, EndDate, CourseId, TeacherId) VALUES (15, N'C015', N'Spanish Advanced A', N'2025-03-10 00:00:00.0000000', N'2025-06-10 00:00:00.0000000', 15, 5);
INSERT INTO EngLabStore.dbo.Class (Id, ClassCode, ClassName, StartDate, EndDate, CourseId, TeacherId) VALUES (16, N'C016', N'Chinese HSK 1 A', N'2025-04-10 00:00:00.0000000', N'2025-07-10 00:00:00.0000000', 16, 6);
INSERT INTO EngLabStore.dbo.Class (Id, ClassCode, ClassName, StartDate, EndDate, CourseId, TeacherId) VALUES (17, N'C017', N'Chinese HSK 2 A', N'2025-05-10 00:00:00.0000000', N'2025-08-10 00:00:00.0000000', 17, 7);
INSERT INTO EngLabStore.dbo.Class (Id, ClassCode, ClassName, StartDate, EndDate, CourseId, TeacherId) VALUES (18, N'C018', N'Chinese HSK 3 A', N'2025-06-10 00:00:00.0000000', N'2025-09-10 00:00:00.0000000', 18, 8);
INSERT INTO EngLabStore.dbo.Class (Id, ClassCode, ClassName, StartDate, EndDate, CourseId, TeacherId) VALUES (23, N'TV001', N'Lớp học tiếng việt', N'2024-11-28 14:00:20.5966667', N'2024-11-28 14:00:20.5966667', 2, 2);
INSERT INTO EngLabStore.dbo.Class (Id, ClassCode, ClassName, StartDate, EndDate, CourseId, TeacherId) VALUES (25, N'LV001', N'Lớp học LV', N'2024-11-28 14:15:28.8633333', N'2024-11-28 14:15:28.8633333', 2, 5);
