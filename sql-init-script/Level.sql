create table Level
(
    Id         int identity
        constraint PK_Level
            primary key,
    LevelCode  nvarchar(20) not null,
    LevelName  nvarchar(50) not null,
    LanguageId int          not null
        constraint FK_Level_Language_LanguageId
            references Language
            on delete cascade
)
go

create index IX_Level_LanguageId
    on Level (LanguageId)
go

INSERT INTO EngLabStore.dbo.Level (Id, LevelCode, LevelName, LanguageId) VALUES (1, N'A1', N'Beginner', 1);
INSERT INTO EngLabStore.dbo.Level (Id, LevelCode, LevelName, LanguageId) VALUES (2, N'A2', N'Elementary', 1);
INSERT INTO EngLabStore.dbo.Level (Id, LevelCode, LevelName, LanguageId) VALUES (3, N'B1', N'Intermediate', 1);
INSERT INTO EngLabStore.dbo.Level (Id, LevelCode, LevelName, LanguageId) VALUES (4, N'B2', N'Upper Intermediate', 1);
INSERT INTO EngLabStore.dbo.Level (Id, LevelCode, LevelName, LanguageId) VALUES (5, N'C1', N'Advanced', 1);
INSERT INTO EngLabStore.dbo.Level (Id, LevelCode, LevelName, LanguageId) VALUES (6, N'C2', N'Proficient', 1);
INSERT INTO EngLabStore.dbo.Level (Id, LevelCode, LevelName, LanguageId) VALUES (7, N'A1', N'Débutant', 2);
INSERT INTO EngLabStore.dbo.Level (Id, LevelCode, LevelName, LanguageId) VALUES (8, N'A2', N'Élémentaire', 2);
INSERT INTO EngLabStore.dbo.Level (Id, LevelCode, LevelName, LanguageId) VALUES (9, N'B1', N'Intermédiaire', 2);
INSERT INTO EngLabStore.dbo.Level (Id, LevelCode, LevelName, LanguageId) VALUES (10, N'B2', N'Supérieur', 2);
INSERT INTO EngLabStore.dbo.Level (Id, LevelCode, LevelName, LanguageId) VALUES (11, N'C1', N'Avancé', 2);
INSERT INTO EngLabStore.dbo.Level (Id, LevelCode, LevelName, LanguageId) VALUES (12, N'C2', N'Maîtrise', 2);
INSERT INTO EngLabStore.dbo.Level (Id, LevelCode, LevelName, LanguageId) VALUES (13, N'A1', N'Principiante', 3);
INSERT INTO EngLabStore.dbo.Level (Id, LevelCode, LevelName, LanguageId) VALUES (14, N'A2', N'Elemental', 3);
INSERT INTO EngLabStore.dbo.Level (Id, LevelCode, LevelName, LanguageId) VALUES (15, N'B1', N'Intermedio', 3);
INSERT INTO EngLabStore.dbo.Level (Id, LevelCode, LevelName, LanguageId) VALUES (16, N'B2', N'Avanzado', 3);
INSERT INTO EngLabStore.dbo.Level (Id, LevelCode, LevelName, LanguageId) VALUES (17, N'C1', N'Superior', 3);
INSERT INTO EngLabStore.dbo.Level (Id, LevelCode, LevelName, LanguageId) VALUES (18, N'C2', N'Maestría', 3);
INSERT INTO EngLabStore.dbo.Level (Id, LevelCode, LevelName, LanguageId) VALUES (19, N'HSK 1', N'Beginner', 4);
INSERT INTO EngLabStore.dbo.Level (Id, LevelCode, LevelName, LanguageId) VALUES (20, N'HSK 2', N'Elementary', 4);
INSERT INTO EngLabStore.dbo.Level (Id, LevelCode, LevelName, LanguageId) VALUES (21, N'HSK 3', N'Intermediate', 4);
INSERT INTO EngLabStore.dbo.Level (Id, LevelCode, LevelName, LanguageId) VALUES (22, N'HSK 4', N'Upper Intermediate', 4);
INSERT INTO EngLabStore.dbo.Level (Id, LevelCode, LevelName, LanguageId) VALUES (23, N'HSK 5', N'Advanced', 4);
INSERT INTO EngLabStore.dbo.Level (Id, LevelCode, LevelName, LanguageId) VALUES (24, N'HSK 6', N'Proficient', 4);
INSERT INTO EngLabStore.dbo.Level (Id, LevelCode, LevelName, LanguageId) VALUES (25, N'N5', N'Beginner', 5);
INSERT INTO EngLabStore.dbo.Level (Id, LevelCode, LevelName, LanguageId) VALUES (26, N'N4', N'Elementary', 5);
INSERT INTO EngLabStore.dbo.Level (Id, LevelCode, LevelName, LanguageId) VALUES (27, N'N3', N'Intermediate', 5);
INSERT INTO EngLabStore.dbo.Level (Id, LevelCode, LevelName, LanguageId) VALUES (28, N'N2', N'Upper Intermediate', 5);
INSERT INTO EngLabStore.dbo.Level (Id, LevelCode, LevelName, LanguageId) VALUES (29, N'N1', N'Advanced', 5);
