create table Teacher
(
    Id          int identity
        constraint PK_Teacher
            primary key,
    TeacherCode nvarchar(max) default N'U1fpaT',
    FullName    nvarchar(255) collate SQL_Latin1_General_CP1_CI_AI,
    Gender      nvarchar(20)  not null,
    Email       nvarchar(255) not null,
    PhoneNumber nvarchar(20)  not null,
    Address     nvarchar(255),
    DateOfBirth datetime2,
    HireDate    datetime2     default '2024-10-09T08:13:31.4219680Z',
    EndDate     datetime2,
    IsActive    bit           default CONVERT([bit], 1)
)
go

INSERT INTO EngLabStore.dbo.Teacher (Id, TeacherCode, FullName, Gender, Email, PhoneNumber, Address, DateOfBirth, HireDate, EndDate, IsActive) VALUES (1, N'GV001', N'Nguyễn Văn A', N'Nam', N'nguyenvana@example.com', N'0901234567', N'123 Đường ABC, Hà Nội', N'1980-05-15 00:00:00.0000000', N'2010-01-10 00:00:00.0000000', null, 1);
INSERT INTO EngLabStore.dbo.Teacher (Id, TeacherCode, FullName, Gender, Email, PhoneNumber, Address, DateOfBirth, HireDate, EndDate, IsActive) VALUES (2, N'GV002', N'Trần Thị B', N'Nữ', N'tranthib@example.com', N'0912345678', N'456 Đường DEF, Hà Nội', N'1985-08-22 00:00:00.0000000', N'2012-04-20 00:00:00.0000000', null, 1);
INSERT INTO EngLabStore.dbo.Teacher (Id, TeacherCode, FullName, Gender, Email, PhoneNumber, Address, DateOfBirth, HireDate, EndDate, IsActive) VALUES (3, N'GV003', N'Lê Văn C', N'Nam', N'levanc@example.com', N'0923456789', N'789 Đường GHI, Hà Nội', N'1990-03-30 00:00:00.0000000', N'2015-06-15 00:00:00.0000000', null, 1);
INSERT INTO EngLabStore.dbo.Teacher (Id, TeacherCode, FullName, Gender, Email, PhoneNumber, Address, DateOfBirth, HireDate, EndDate, IsActive) VALUES (4, N'GV004', N'Nguyễn Thị D', N'Nữ', N'nguyenthid@example.com', N'0934567890', N'101 Đường JKL, Hà Nội', N'1988-07-10 00:00:00.0000000', N'2018-03-25 00:00:00.0000000', null, 1);
INSERT INTO EngLabStore.dbo.Teacher (Id, TeacherCode, FullName, Gender, Email, PhoneNumber, Address, DateOfBirth, HireDate, EndDate, IsActive) VALUES (5, N'GV005', N'Trương Văn E', N'Nam', N'truongvane@example.com', N'0945678901', N'202 Đường MNO, Hà Nội', N'1979-11-05 00:00:00.0000000', N'2010-07-30 00:00:00.0000000', null, 1);
INSERT INTO EngLabStore.dbo.Teacher (Id, TeacherCode, FullName, Gender, Email, PhoneNumber, Address, DateOfBirth, HireDate, EndDate, IsActive) VALUES (6, N'GV006', N'Bùi Thị F', N'Nữ', N'buithif@example.com', N'0956789012', N'303 Đường PQR, Hà Nội', N'1983-09-14 00:00:00.0000000', N'2014-05-10 00:00:00.0000000', null, 1);
INSERT INTO EngLabStore.dbo.Teacher (Id, TeacherCode, FullName, Gender, Email, PhoneNumber, Address, DateOfBirth, HireDate, EndDate, IsActive) VALUES (7, N'GV007', N'Đỗ Văn G', N'Nam', N'dovang@example.com', N'0967890123', N'404 Đường STU, Hà Nội', N'1991-12-21 00:00:00.0000000', N'2016-11-15 00:00:00.0000000', null, 1);
INSERT INTO EngLabStore.dbo.Teacher (Id, TeacherCode, FullName, Gender, Email, PhoneNumber, Address, DateOfBirth, HireDate, EndDate, IsActive) VALUES (8, N'GV008', N'Nguyễn Thị H', N'Nữ', N'nguyenthih@example.com', N'0978901234', N'505 Đường VWX, Hà Nội', N'1986-04-02 00:00:00.0000000', N'2012-09-05 00:00:00.0000000', null, 1);
INSERT INTO EngLabStore.dbo.Teacher (Id, TeacherCode, FullName, Gender, Email, PhoneNumber, Address, DateOfBirth, HireDate, EndDate, IsActive) VALUES (11, N'GV059', N'Trần Hồng Quân', N'Nam', N'tranhongquan.dev02@gmail.com', N'037876847', N'123 Hà Nội', N'2024-11-28 14:13:49.3600000', N'2024-11-28 14:13:49.3600000', N'2024-11-28 14:13:49.3600000', 1);
INSERT INTO EngLabStore.dbo.Teacher (Id, TeacherCode, FullName, Gender, Email, PhoneNumber, Address, DateOfBirth, HireDate, EndDate, IsActive) VALUES (12, N'string', N'string', N'string', N'string', N'string', N'string', N'2024-11-28 23:56:54.5933333', N'2024-11-28 23:56:54.5933333', N'2024-11-28 23:56:54.5933333', 1);
