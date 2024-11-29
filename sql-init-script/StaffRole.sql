create table StaffRole
(
    Id       int identity
        constraint PK_StaffRole
            primary key,
    RoleName nvarchar(50) not null,
    Rank     int          not null
)
go

INSERT INTO EngLabStore.dbo.StaffRole (Id, RoleName, Rank) VALUES (1, N'Admin', 1);
INSERT INTO EngLabStore.dbo.StaffRole (Id, RoleName, Rank) VALUES (2, N'Center Manager', 2);
INSERT INTO EngLabStore.dbo.StaffRole (Id, RoleName, Rank) VALUES (3, N'Student Coordinator', 3);
INSERT INTO EngLabStore.dbo.StaffRole (Id, RoleName, Rank) VALUES (4, N'HR Manager', 3);
