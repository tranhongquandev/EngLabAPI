create table Staff
(
    Id           int identity
        constraint PK_Staff
            primary key,
    StaffCode    nvarchar(50) default N'chqCpW',
    FullName     nvarchar(255) not null,
    Gender       nvarchar(20)  not null,
    Email        nvarchar(50)  not null,
    PasswordHash nvarchar(255) not null,
    PhoneNumber  nvarchar(20)  not null,
    Address      nvarchar(255),
    DateOfBirth  datetime2,
    HireDate     datetime2    default '2024-10-09T08:13:31.4206600Z',
    EndDate      datetime2,
    IsActive     bit          default CONVERT([bit], 1),
    RoleId       int           not null
        constraint FK_Staff_StaffRole_RoleId
            references StaffRole
            on delete cascade
)
go

create index IX_Staff_RoleId
    on Staff (RoleId)
go

INSERT INTO EngLabStore.dbo.Staff (Id, StaffCode, FullName, Gender, Email, PasswordHash, PhoneNumber, Address, DateOfBirth, HireDate, EndDate, IsActive, RoleId) VALUES (2, N'QTV01', N'Trần Hồng Quân', N'Nam', N'tranhongquan.dev@gmail.com', N'$2a$11$tOUt8xgZAgyP7j/7UQ7QzeBCUVTLRkiyjflVROW1hWh9XysVfFm0W', N'0378786847', N'123 Hà Nội', N'2024-11-28 09:31:49.7966667', N'2024-11-28 09:31:49.7966667', N'2024-11-28 09:31:49.7966667', 1, 1);
