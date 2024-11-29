create table ClassStudents
(
    ClassId   int not null
        constraint FK_ClassStudents_Class_ClassId
            references Class
            on delete cascade,
    StudentId int not null
        constraint FK_ClassStudents_Student_StudentId
            references Student
            on delete cascade,
    constraint PK_ClassStudents
        primary key (StudentId, ClassId)
)
go

create index IX_ClassStudents_ClassId
    on ClassStudents (ClassId)
go

INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (2, 1);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (2, 2);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (2, 3);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (2, 4);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (2, 16);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (2, 17);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (2, 18);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (2, 19);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (2, 20);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (2, 21);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (2, 22);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (2, 23);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (2, 24);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (2, 25);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (3, 5);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (3, 6);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (3, 7);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (3, 8);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (3, 9);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (3, 10);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (3, 11);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (3, 12);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (3, 13);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (3, 14);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (3, 15);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (3, 16);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (3, 17);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (3, 18);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (4, 19);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (4, 20);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (4, 21);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (4, 22);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (4, 23);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (4, 24);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (4, 25);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (4, 26);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (4, 27);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (4, 28);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (4, 29);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (4, 30);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (4, 31);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (4, 32);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (6, 1);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (6, 2);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (6, 3);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (6, 4);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (6, 5);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (6, 6);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (6, 7);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (6, 8);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (6, 9);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (6, 10);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (6, 47);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (6, 48);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (6, 49);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (7, 11);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (7, 12);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (7, 13);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (7, 14);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (7, 15);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (7, 16);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (7, 17);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (7, 18);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (7, 19);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (7, 20);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (7, 21);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (7, 22);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (7, 23);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (7, 24);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (8, 25);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (8, 26);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (8, 27);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (8, 28);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (8, 29);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (8, 30);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (8, 31);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (8, 32);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (8, 33);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (8, 34);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (8, 35);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (8, 36);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (8, 37);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (8, 38);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (13, 1);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (13, 2);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (13, 3);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (13, 4);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (13, 5);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (13, 6);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (13, 7);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (13, 8);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (13, 45);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (13, 46);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (13, 47);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (13, 48);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (13, 49);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (14, 9);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (14, 10);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (14, 11);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (14, 12);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (14, 13);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (14, 14);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (14, 15);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (14, 16);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (14, 17);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (14, 18);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (14, 19);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (14, 20);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (14, 21);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (14, 22);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (15, 23);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (15, 24);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (15, 25);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (15, 26);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (15, 27);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (15, 28);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (15, 29);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (15, 30);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (15, 31);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (15, 32);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (15, 33);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (15, 34);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (15, 35);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (15, 36);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (16, 37);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (16, 38);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (16, 39);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (16, 40);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (16, 41);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (16, 42);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (16, 43);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (16, 44);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (16, 45);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (16, 46);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (16, 47);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (16, 48);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (16, 49);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (17, 1);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (17, 2);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (17, 3);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (17, 4);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (17, 5);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (17, 6);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (17, 7);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (17, 8);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (17, 9);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (17, 10);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (17, 11);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (17, 12);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (17, 13);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (17, 14);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (18, 15);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (18, 16);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (18, 17);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (18, 18);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (18, 19);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (18, 20);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (18, 21);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (18, 22);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (18, 23);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (18, 24);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (18, 25);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (18, 26);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (18, 27);
INSERT INTO EngLabStore.dbo.ClassStudents (ClassId, StudentId) VALUES (18, 28);
