create table Language
(
    Id           int identity
        constraint PK_Language
            primary key,
    LanguageName nvarchar(50) not null
)
go

INSERT INTO EngLabStore.dbo.Language (Id, LanguageName) VALUES (1, N'Tiếng Anh');
INSERT INTO EngLabStore.dbo.Language (Id, LanguageName) VALUES (2, N'Tiếng Pháp');
INSERT INTO EngLabStore.dbo.Language (Id, LanguageName) VALUES (3, N'Tiếng Tây Ban Nha');
INSERT INTO EngLabStore.dbo.Language (Id, LanguageName) VALUES (4, N'Tiếng Trung');
INSERT INTO EngLabStore.dbo.Language (Id, LanguageName) VALUES (5, N'Tiếng Nhật');
