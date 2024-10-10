using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EngLabAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MethodName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethod", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StaffRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentCode = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "bJ34Ty"),
                    FullName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 10, 9, 8, 13, 31, 421, DateTimeKind.Utc).AddTicks(6050)),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "Chưa có lớp")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherCode = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "U1fpaT"),
                    ImgUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2024, 10, 9, 8, 13, 31, 421, DateTimeKind.Utc).AddTicks(9680)),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Weekday",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weekday", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Level",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LevelCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LevelName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Level", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Level_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "chqCpW"),
                    ImgUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2024, 10, 9, 8, 13, 31, 420, DateTimeKind.Utc).AddTicks(6600)),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Staff_StaffRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "StaffRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseCode = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "zUybyx"),
                    CourseName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fee = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    Discount = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    TotalFee = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 10, 9, 8, 13, 31, 418, DateTimeKind.Utc).AddTicks(6380)),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 10, 9, 8, 13, 31, 418, DateTimeKind.Utc).AddTicks(6790)),
                    LevelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Course_Level_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Level",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassCode = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "hWwexE"),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Class_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Class_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValue: "576maP"),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 10, 9, 8, 13, 31, 419, DateTimeKind.Utc).AddTicks(6270)),
                    PaymentStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValue: "Created"),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payment_PaymentMethod_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethod",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Payment_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassStudents",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassStudents", x => new { x.StudentId, x.ClassId });
                    table.ForeignKey(
                        name: "FK_ClassStudents_Class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassStudents_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassWeekday",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    WeekdayId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassWeekday", x => new { x.ClassId, x.WeekdayId });
                    table.ForeignKey(
                        name: "FK_ClassWeekday_Class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassWeekday_Weekday_WeekdayId",
                        column: x => x.WeekdayId,
                        principalTable: "Weekday",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Language",
                columns: new[] { "Id", "LanguageName" },
                values: new object[,]
                {
                    { 1, "Tiếng Anh" },
                    { 2, "Tiếng Pháp" },
                    { 3, "Tiếng Tây Ban Nha" },
                    { 4, "Tiếng Trung" },
                    { 5, "Tiếng Nhật" }
                });

            migrationBuilder.InsertData(
                table: "PaymentMethod",
                columns: new[] { "Id", "MethodName" },
                values: new object[,]
                {
                    { 1, "Tiền mặt" },
                    { 2, "Thẻ ghi nợ" },
                    { 3, "Thẻ tính dụng" },
                    { 4, "Chuyển khoản ngân hàng" },
                    { 5, "Ví điện tử" }
                });

            migrationBuilder.InsertData(
                table: "StaffRole",
                columns: new[] { "Id", "Rank", "RoleName" },
                values: new object[,]
                {
                    { 1, 1, "Admin" },
                    { 2, 2, "Center Manager" },
                    { 3, 3, "Student Coordinator" },
                    { 4, 3, "HR Manager" }
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "DateOfBirth", "Email", "EnrollmentDate", "FullName", "Gender", "PhoneNumber", "Status", "StudentCode" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "nguyenvana@example.com", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyễn Văn A", "Nam", "0987654321", "Active", "HV001" },
                    { 2, new DateTime(1999, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "tranthib@example.com", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trần Thị B", "Nữ", "0912345678", "Active", "HV002" },
                    { 3, new DateTime(2001, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "levanc@example.com", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lê Văn C", "Nam", "0923456789", "Active", "HV003" },
                    { 4, new DateTime(1998, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "phamthid@example.com", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phạm Thị D", "Nữ", "0981234567", "Active", "HV004" },
                    { 5, new DateTime(1997, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "dovane@example.com", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đỗ Văn E", "Nam", "0976543210", "Inactive", "HV005" },
                    { 6, new DateTime(1999, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "hoangminhf@example.com", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hoàng Minh F", "Nam", "0912345678", "Active", "HV006" },
                    { 7, new DateTime(1998, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "nguyenvang@example.com", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyễn Văn G", "Nam", "0922345678", "Active", "HV007" },
                    { 8, new DateTime(2000, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "vuthih@example.com", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vũ Thị H", "Nữ", "0934567890", "Active", "HV008" },
                    { 9, new DateTime(1996, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "buivani@example.com", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bùi Văn I", "Nam", "0909876543", "Inactive", "HV009" },
                    { 10, new DateTime(2002, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "phanthij@example.com", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phan Thị J", "Nữ", "0987654321", "Active", "HV010" },
                    { 11, new DateTime(1999, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "truongvank@example.com", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trương Văn K", "Nam", "0981112233", "Active", "HV011" },
                    { 12, new DateTime(1997, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "nguyenthil@example.com", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyễn Thị L", "Nữ", "0992223344", "Active", "HV012" },
                    { 13, new DateTime(1995, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "lyvanm@example.com", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lý Văn M", "Nam", "0912345678", "Inactive", "HV013" },
                    { 14, new DateTime(1998, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "ngothin@example.com", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ngô Thị N", "Nữ", "0922345678", "Active", "HV014" },
                    { 15, new DateTime(1994, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "tranvano@example.com", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trần Văn O", "Nam", "0908765432", "Inactive", "HV015" },
                    { 16, new DateTime(2000, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "phamminhp@example.com", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phạm Minh P", "Nam", "0912345678", "Active", "HV016" },
                    { 17, new DateTime(1996, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "trinhthiq@example.com", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trịnh Thị Q", "Nữ", "0934456677", "Inactive", "HV017" },
                    { 18, new DateTime(1995, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "dangvanr@example.com", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đặng Văn R", "Nam", "0909871234", "Active", "HV018" },
                    { 19, new DateTime(1999, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "luongthis@example.com", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lương Thị S", "Nữ", "0977889900", "Active", "HV019" },
                    { 20, new DateTime(1997, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "phanvant@example.com", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phan Văn T", "Nam", "0923345678", "Inactive", "HV020" },
                    { 21, new DateTime(1998, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "nguyenvanu@example.com", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyễn Văn U", "Nam", "0911234567", "Active", "HV021" },
                    { 22, new DateTime(1997, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "vuthiv@example.com", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vũ Thị V", "Nữ", "0942345678", "Active", "HV022" },
                    { 23, new DateTime(2001, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "truongthiww@example.com", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trương Thị W", "Nữ", "0976456789", "Inactive", "HV023" },
                    { 24, new DateTime(1999, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "levanx@example.com", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lê Văn X", "Nam", "0923456789", "Active", "HV024" },
                    { 25, new DateTime(1998, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "nguyenthiy@example.com", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyễn Thị Y", "Nữ", "0908765432", "Active", "HV025" },
                    { 26, new DateTime(1995, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "buivanz@example.com", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bùi Văn Z", "Nam", "0912345678", "Inactive", "HV026" },
                    { 27, new DateTime(2000, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "dothiaa@example.com", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đỗ Thị AA", "Nữ", "0934567890", "Active", "HV027" },
                    { 28, new DateTime(1997, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "nguyenvanbb@example.com", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyễn Văn BB", "Nam", "0922334455", "Active", "HV028" },
                    { 29, new DateTime(1999, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "lethicc@example.com", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lê Thị CC", "Nữ", "0916543210", "Inactive", "HV029" },
                    { 30, new DateTime(1996, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "tranvandd@example.com", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trần Văn DD", "Nam", "0909876543", "Active", "HV030" },
                    { 31, new DateTime(2000, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "vuthiee@example.com", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vũ Thị EE", "Nữ", "0976543210", "Active", "HV031" },
                    { 32, new DateTime(1998, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "buivanff@example.com", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bùi Văn FF", "Nam", "0922334455", "Inactive", "HV032" },
                    { 33, new DateTime(1997, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "nguyenthigg@example.com", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyễn Thị GG", "Nữ", "0934567890", "Active", "HV033" },
                    { 34, new DateTime(1999, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "levanhh@example.com", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lê Văn HH", "Nam", "0945678901", "Active", "HV034" },
                    { 35, new DateTime(2000, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "truongthii@example.com", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trương Thị II", "Nữ", "0977654321", "Inactive", "HV035" },
                    { 36, new DateTime(1996, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "dovanjj@example.com", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đỗ Văn JJ", "Nam", "0909871234", "Active", "HV036" },
                    { 37, new DateTime(1998, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "nguyenthikk@example.com", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyễn Thị KK", "Nữ", "0912345678", "Active", "HV037" },
                    { 38, new DateTime(2001, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "levanll@example.com", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lê Văn LL", "Nam", "0923456789", "Inactive", "HV038" },
                    { 39, new DateTime(1999, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "vuthimm@example.com", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vũ Thị MM", "Nữ", "0934567890", "Active", "HV039" },
                    { 40, new DateTime(1995, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "buivannn@example.com", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bùi Văn NN", "Nam", "0912345678", "Inactive", "HV040" },
                    { 41, new DateTime(1997, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "tranthioo@example.com", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trần Thị OO", "Nữ", "0976543210", "Active", "HV041" },
                    { 42, new DateTime(1998, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "nguyenvanpp@example.com", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyễn Văn PP", "Nam", "0945678901", "Active", "HV042" },
                    { 43, new DateTime(1996, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "lethiqq@example.com", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lê Thị QQ", "Nữ", "0934567890", "Inactive", "HV043" },
                    { 44, new DateTime(1999, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "truongvanrr@example.com", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trương Văn RR", "Nam", "0922334455", "Active", "HV044" },
                    { 45, new DateTime(2000, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "dothiss@example.com", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đỗ Thị SS", "Nữ", "0908765432", "Inactive", "HV045" },
                    { 46, new DateTime(1998, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "nguyenthitt@example.com", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyễn Thị TT", "Nữ", "0912345678", "Active", "HV046" },
                    { 47, new DateTime(1996, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "levanuu@example.com", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lê Văn UU", "Nam", "0923456789", "Active", "HV047" },
                    { 48, new DateTime(2000, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "tranthivv@example.com", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trần Thị VV", "Nữ", "0934567890", "Inactive", "HV048" },
                    { 49, new DateTime(1999, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "buivanww@example.com", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bùi Văn WW", "Nam", "0976543210", "Active", "HV049" },
                    { 50, new DateTime(2001, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "nguyenthixx@example.com", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyễn Thị XX", "Nữ", "0901234567", "Active", "HV050" }
                });

            migrationBuilder.InsertData(
                table: "Teacher",
                columns: new[] { "Id", "Address", "DateOfBirth", "Email", "EndDate", "FullName", "Gender", "HireDate", "ImgUrl", "IsActive", "PhoneNumber", "TeacherCode" },
                values: new object[,]
                {
                    { 1, "123 Đường ABC, Hà Nội", new DateTime(1980, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "nguyenvana@example.com", null, "Nguyễn Văn A", "Nam", new DateTime(2010, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "http://example.com/img1.jpg", true, "0901234567", "GV001" },
                    { 2, "456 Đường DEF, Hà Nội", new DateTime(1985, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "tranthib@example.com", null, "Trần Thị B", "Nữ", new DateTime(2012, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "http://example.com/img2.jpg", true, "0912345678", "GV002" },
                    { 3, "789 Đường GHI, Hà Nội", new DateTime(1990, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "levanc@example.com", null, "Lê Văn C", "Nam", new DateTime(2015, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "http://example.com/img3.jpg", true, "0923456789", "GV003" },
                    { 4, "101 Đường JKL, Hà Nội", new DateTime(1988, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "nguyenthid@example.com", null, "Nguyễn Thị D", "Nữ", new DateTime(2018, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "http://example.com/img4.jpg", true, "0934567890", "GV004" },
                    { 5, "202 Đường MNO, Hà Nội", new DateTime(1979, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "truongvane@example.com", null, "Trương Văn E", "Nam", new DateTime(2010, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "http://example.com/img5.jpg", true, "0945678901", "GV005" },
                    { 6, "303 Đường PQR, Hà Nội", new DateTime(1983, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "buithif@example.com", null, "Bùi Thị F", "Nữ", new DateTime(2014, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "http://example.com/img6.jpg", true, "0956789012", "GV006" },
                    { 7, "404 Đường STU, Hà Nội", new DateTime(1991, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "dovang@example.com", null, "Đỗ Văn G", "Nam", new DateTime(2016, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "http://example.com/img7.jpg", true, "0967890123", "GV007" },
                    { 8, "505 Đường VWX, Hà Nội", new DateTime(1986, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "nguyenthih@example.com", null, "Nguyễn Thị H", "Nữ", new DateTime(2012, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "http://example.com/img8.jpg", true, "0978901234", "GV008" },
                    { 9, "606 Đường YZA, Hà Nội", new DateTime(1990, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "levani@example.com", null, "Lê Văn I", "Nam", new DateTime(2018, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "http://example.com/img9.jpg", true, "0989012345", "GV009" },
                    { 10, "707 Đường BCD, Hà Nội", new DateTime(1985, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "tranthij@example.com", null, "Trần Thị J", "Nữ", new DateTime(2015, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "http://example.com/img10.jpg", true, "0990123456", "GV010" }
                });

            migrationBuilder.InsertData(
                table: "Weekday",
                columns: new[] { "Id", "DayName" },
                values: new object[,]
                {
                    { 1, "Monday" },
                    { 2, "Tuesday" },
                    { 3, "Wednesday" },
                    { 4, "Thursday" },
                    { 5, "Friday" },
                    { 6, "Saturday" },
                    { 7, "Sunday" }
                });

            migrationBuilder.InsertData(
                table: "Level",
                columns: new[] { "Id", "LanguageId", "LevelCode", "LevelName" },
                values: new object[,]
                {
                    { 1, 1, "A1", "Beginner" },
                    { 2, 1, "A2", "Elementary" },
                    { 3, 1, "B1", "Intermediate" },
                    { 4, 1, "B2", "Upper Intermediate" },
                    { 5, 1, "C1", "Advanced" },
                    { 6, 1, "C2", "Proficient" },
                    { 7, 2, "A1", "Débutant" },
                    { 8, 2, "A2", "Élémentaire" },
                    { 9, 2, "B1", "Intermédiaire" },
                    { 10, 2, "B2", "Supérieur" },
                    { 11, 2, "C1", "Avancé" },
                    { 12, 2, "C2", "Maîtrise" },
                    { 13, 3, "A1", "Principiante" },
                    { 14, 3, "A2", "Elemental" },
                    { 15, 3, "B1", "Intermedio" },
                    { 16, 3, "B2", "Avanzado" },
                    { 17, 3, "C1", "Superior" },
                    { 18, 3, "C2", "Maestría" },
                    { 19, 4, "HSK 1", "Beginner" },
                    { 20, 4, "HSK 2", "Elementary" },
                    { 21, 4, "HSK 3", "Intermediate" },
                    { 22, 4, "HSK 4", "Upper Intermediate" },
                    { 23, 4, "HSK 5", "Advanced" },
                    { 24, 4, "HSK 6", "Proficient" },
                    { 25, 5, "N5", "Beginner" },
                    { 26, 5, "N4", "Elementary" },
                    { 27, 5, "N3", "Intermediate" },
                    { 28, 5, "N2", "Upper Intermediate" },
                    { 29, 5, "N1", "Advanced" }
                });

            migrationBuilder.InsertData(
                table: "Staff",
                columns: new[] { "Id", "Address", "DateOfBirth", "Email", "EndDate", "FullName", "Gender", "HireDate", "ImgUrl", "IsActive", "PasswordHash", "PhoneNumber", "RoleId" },
                values: new object[] { 1, "123 đường ABC, Hà Nội, VN", new DateTime(2003, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "tranhongquan.dev@gmail.com", null, "Quản trị viên", "Nam", new DateTime(2024, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "$2a$11$mVOzIRFb71alNYrUvBcknOhWMJnnebsW4EDRz7/pjjBTiF0s9u4Ci", "123456789", 1 });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "Id", "CourseCode", "CourseName", "CreatedDate", "Description", "Discount", "Duration", "Fee", "IsActive", "LevelId", "TotalFee", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "EN001", "English for Beginners", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Introduction to English for complete beginners.", 0.10000000000000001, "3 months", 3500000.0, true, 1, 3150000.0, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "EN002", "Elementary English", new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Basic English skills for elementary level.", 0.10000000000000001, "3 months", 4000000.0, true, 2, 3600000.0, new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "EN003", "Intermediate English", new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Improve your English skills with intermediate level courses.", 0.14999999999999999, "4 months", 5000000.0, true, 3, 4250000.0, new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "EN004", "Upper Intermediate English", new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Enhance your English proficiency at an upper intermediate level.", 0.20000000000000001, "5 months", 6500000.0, true, 4, 5200000.0, new DateTime(2024, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "EN005", "Advanced English", new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Master advanced English skills with specialized courses.", 0.25, "6 months", 8000000.0, true, 5, 6000000.0, new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "FR001", "Débutant en Français", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Introduction au français pour débutants.", 0.10000000000000001, "3 months", 3200000.0, true, 6, 2880000.0, new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "FR002", "Français Élémentaire", new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Compétences de base en français à un niveau élémentaire.", 0.10000000000000001, "3 months", 3600000.0, true, 7, 3240000.0, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "FR003", "Français Intermédiaire", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Améliorez vos compétences en français à un niveau intermédiaire.", 0.14999999999999999, "4 months", 4500000.0, true, 8, 3825000.0, new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "FR004", "Français Supérieur", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Perfectionnez votre français à un niveau supérieur.", 0.20000000000000001, "5 months", 5800000.0, true, 9, 4640000.0, new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "FR005", "Français Avancé", new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maîtrisez le français avec des cours avancés.", 0.25, "6 months", 7200000.0, true, 10, 5400000.0, new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, "ES001", "Principiante en Español", new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Introducción al español para principiantes.", 0.10000000000000001, "3 months", 3500000.0, true, 11, 3150000.0, new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, "ES002", "Español Elemental", new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Habilidades básicas en español a nivel elemental.", 0.10000000000000001, "3 months", 4000000.0, true, 12, 3600000.0, new DateTime(2024, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, "ES003", "Español Intermedio", new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mejore sus habilidades en español con cursos intermedios.", 0.14999999999999999, "4 months", 5000000.0, true, 13, 4250000.0, new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, "ES004", "Español Avanzado", new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Perfeccione su español con cursos avanzados.", 0.20000000000000001, "5 months", 6500000.0, true, 14, 5200000.0, new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, "ES005", "Maestría en Español", new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maestría en el uso del español con cursos de nivel superior.", 0.25, "6 months", 8000000.0, true, 15, 6000000.0, new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "Id", "CourseCode", "CourseName", "CreatedDate", "Description", "Discount", "Duration", "IsActive", "LevelId", "TotalFee", "UpdatedDate" },
                values: new object[] { 16, "ZH001", "HSK 1 Chinese", new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Introduction to Chinese at HSK 1 level.", 0.10000000000000001, "3 months", true, 16, 2700000.0, new DateTime(2024, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "Id", "CourseCode", "CourseName", "CreatedDate", "Description", "Discount", "Duration", "Fee", "IsActive", "LevelId", "TotalFee", "UpdatedDate" },
                values: new object[,]
                {
                    { 17, "ZH002", "HSK 2 Chinese", new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chinese course at HSK 2 level.", 0.10000000000000001, "3 months", 3500000.0, true, 17, 3150000.0, new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, "ZH003", "HSK 3 Chinese", new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Intermediate Chinese course at HSK 3 level.", 0.14999999999999999, "4 months", 4500000.0, true, 18, 3825000.0, new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, "ZH004", "HSK 4 Chinese", new DateTime(2024, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Advanced Chinese course at HSK 4 level.", 0.20000000000000001, "5 months", 5800000.0, true, 19, 4640000.0, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, "ZH005", "HSK 5 Chinese", new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Master Chinese skills at HSK 5 level.", 0.25, "6 months", 7200000.0, true, 20, 5400000.0, new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Class",
                columns: new[] { "Id", "ClassCode", "ClassName", "CourseId", "EndDate", "StartDate", "TeacherId" },
                values: new object[,]
                {
                    { 1, "C001", "English Beginner A", 1, new DateTime(2024, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, "C002", "English Beginner B", 2, new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, "C003", "English Intermediate A", 3, new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, "C004", "English Upper Intermediate A", 4, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 5, "C005", "English Advanced A", 5, new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 6, "C006", "French Beginner A", 6, new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 7, "C007", "French Beginner B", 7, new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 8, "C008", "French Intermediate A", 8, new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 9, "C009", "French Upper Intermediate A", 9, new DateTime(2024, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 10, "C010", "French Advanced A", 10, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 11, "C011", "Spanish Beginner A", 11, new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 12, "C012", "Spanish Beginner B", 12, new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 13, "C013", "Spanish Intermediate A", 13, new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 14, "C014", "Spanish Upper Intermediate A", 14, new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 15, "C015", "Spanish Advanced A", 15, new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 16, "C016", "Chinese HSK 1 A", 16, new DateTime(2025, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 17, "C017", "Chinese HSK 2 A", 17, new DateTime(2025, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 18, "C018", "Chinese HSK 3 A", 18, new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 19, "C019", "Chinese HSK 4 A", 19, new DateTime(2025, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 20, "C020", "Chinese HSK 5 A", 20, new DateTime(2025, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 }
                });

            migrationBuilder.InsertData(
                table: "ClassStudents",
                columns: new[] { "ClassId", "StudentId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 6, 1 },
                    { 9, 1 },
                    { 13, 1 },
                    { 17, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 6, 2 },
                    { 9, 2 },
                    { 13, 2 },
                    { 17, 2 },
                    { 1, 3 },
                    { 2, 3 },
                    { 6, 3 },
                    { 10, 3 },
                    { 13, 3 },
                    { 17, 3 },
                    { 1, 4 },
                    { 2, 4 },
                    { 6, 4 },
                    { 10, 4 },
                    { 13, 4 },
                    { 17, 4 },
                    { 1, 5 },
                    { 3, 5 },
                    { 6, 5 },
                    { 10, 5 },
                    { 13, 5 },
                    { 17, 5 },
                    { 1, 6 },
                    { 3, 6 },
                    { 6, 6 },
                    { 10, 6 },
                    { 13, 6 },
                    { 17, 6 },
                    { 1, 7 },
                    { 3, 7 },
                    { 6, 7 },
                    { 10, 7 },
                    { 13, 7 },
                    { 17, 7 },
                    { 1, 8 },
                    { 3, 8 },
                    { 6, 8 },
                    { 10, 8 },
                    { 13, 8 },
                    { 17, 8 },
                    { 1, 9 },
                    { 3, 9 },
                    { 6, 9 },
                    { 10, 9 },
                    { 14, 9 },
                    { 17, 9 },
                    { 1, 10 },
                    { 3, 10 },
                    { 6, 10 },
                    { 10, 10 },
                    { 14, 10 },
                    { 17, 10 },
                    { 1, 11 },
                    { 3, 11 },
                    { 7, 11 },
                    { 10, 11 },
                    { 14, 11 },
                    { 17, 11 },
                    { 1, 12 },
                    { 3, 12 },
                    { 7, 12 },
                    { 10, 12 },
                    { 14, 12 },
                    { 17, 12 },
                    { 1, 13 },
                    { 3, 13 },
                    { 7, 13 },
                    { 10, 13 },
                    { 14, 13 },
                    { 17, 13 },
                    { 1, 14 },
                    { 3, 14 },
                    { 7, 14 },
                    { 10, 14 },
                    { 14, 14 },
                    { 17, 14 },
                    { 1, 15 },
                    { 3, 15 },
                    { 7, 15 },
                    { 10, 15 },
                    { 14, 15 },
                    { 18, 15 },
                    { 2, 16 },
                    { 3, 16 },
                    { 7, 16 },
                    { 10, 16 },
                    { 14, 16 },
                    { 18, 16 },
                    { 2, 17 },
                    { 3, 17 },
                    { 7, 17 },
                    { 11, 17 },
                    { 14, 17 },
                    { 18, 17 },
                    { 2, 18 },
                    { 3, 18 },
                    { 7, 18 },
                    { 11, 18 },
                    { 14, 18 },
                    { 18, 18 },
                    { 2, 19 },
                    { 4, 19 },
                    { 7, 19 },
                    { 11, 19 },
                    { 14, 19 },
                    { 18, 19 },
                    { 2, 20 },
                    { 4, 20 },
                    { 7, 20 },
                    { 11, 20 },
                    { 14, 20 },
                    { 18, 20 },
                    { 2, 21 },
                    { 4, 21 },
                    { 7, 21 },
                    { 11, 21 },
                    { 14, 21 },
                    { 18, 21 },
                    { 2, 22 },
                    { 4, 22 },
                    { 7, 22 },
                    { 11, 22 },
                    { 14, 22 },
                    { 18, 22 },
                    { 2, 23 },
                    { 4, 23 },
                    { 7, 23 },
                    { 11, 23 },
                    { 15, 23 },
                    { 18, 23 },
                    { 2, 24 },
                    { 4, 24 },
                    { 7, 24 },
                    { 11, 24 },
                    { 15, 24 },
                    { 18, 24 },
                    { 2, 25 },
                    { 4, 25 },
                    { 8, 25 },
                    { 11, 25 },
                    { 15, 25 },
                    { 18, 25 },
                    { 4, 26 },
                    { 8, 26 },
                    { 11, 26 },
                    { 15, 26 },
                    { 18, 26 },
                    { 4, 27 },
                    { 8, 27 },
                    { 11, 27 },
                    { 15, 27 },
                    { 18, 27 },
                    { 4, 28 },
                    { 8, 28 },
                    { 11, 28 },
                    { 15, 28 },
                    { 18, 28 },
                    { 4, 29 },
                    { 8, 29 },
                    { 11, 29 },
                    { 15, 29 },
                    { 4, 30 },
                    { 8, 30 },
                    { 11, 30 },
                    { 15, 30 },
                    { 4, 31 },
                    { 8, 31 },
                    { 12, 31 },
                    { 15, 31 },
                    { 4, 32 },
                    { 8, 32 },
                    { 12, 32 },
                    { 15, 32 },
                    { 5, 33 },
                    { 8, 33 },
                    { 12, 33 },
                    { 15, 33 },
                    { 5, 34 },
                    { 8, 34 },
                    { 12, 34 },
                    { 15, 34 },
                    { 5, 35 },
                    { 8, 35 },
                    { 12, 35 },
                    { 15, 35 },
                    { 5, 36 },
                    { 8, 36 },
                    { 12, 36 },
                    { 15, 36 },
                    { 5, 37 },
                    { 8, 37 },
                    { 12, 37 },
                    { 16, 37 },
                    { 5, 38 },
                    { 8, 38 },
                    { 12, 38 },
                    { 16, 38 },
                    { 5, 39 },
                    { 9, 39 },
                    { 12, 39 },
                    { 16, 39 },
                    { 5, 40 },
                    { 9, 40 },
                    { 12, 40 },
                    { 16, 40 },
                    { 5, 41 },
                    { 9, 41 },
                    { 12, 41 },
                    { 16, 41 },
                    { 5, 42 },
                    { 9, 42 },
                    { 12, 42 },
                    { 16, 42 },
                    { 5, 43 },
                    { 9, 43 },
                    { 12, 43 },
                    { 16, 43 },
                    { 5, 44 },
                    { 9, 44 },
                    { 12, 44 },
                    { 16, 44 },
                    { 5, 45 },
                    { 9, 45 },
                    { 13, 45 },
                    { 16, 45 },
                    { 5, 46 },
                    { 9, 46 },
                    { 13, 46 },
                    { 16, 46 },
                    { 6, 47 },
                    { 9, 47 },
                    { 13, 47 },
                    { 16, 47 },
                    { 6, 48 },
                    { 9, 48 },
                    { 13, 48 },
                    { 16, 48 },
                    { 6, 49 },
                    { 9, 49 },
                    { 13, 49 },
                    { 16, 49 },
                    { 6, 50 },
                    { 9, 50 },
                    { 13, 50 },
                    { 16, 50 }
                });

            migrationBuilder.InsertData(
                table: "ClassWeekday",
                columns: new[] { "ClassId", "WeekdayId", "EndTime", "StartTime" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 9, 23, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 3, new DateTime(2024, 9, 25, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 25, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 5, new DateTime(2024, 9, 27, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 27, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(2024, 9, 24, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 24, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 4, new DateTime(2024, 9, 26, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 26, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 6, new DateTime(2024, 9, 28, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 28, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 1, new DateTime(2024, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 23, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 4, new DateTime(2024, 9, 26, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 6, new DateTime(2024, 9, 28, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 28, 16, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 2, new DateTime(2024, 9, 24, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 24, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 3, new DateTime(2024, 9, 25, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 25, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 5, new DateTime(2024, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 27, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 1, new DateTime(2024, 9, 23, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 23, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 2, new DateTime(2024, 9, 24, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 24, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 4, new DateTime(2024, 9, 26, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 26, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 3, new DateTime(2024, 9, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 25, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 4, new DateTime(2024, 9, 26, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 26, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 6, new DateTime(2024, 9, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 28, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 2, new DateTime(2024, 9, 24, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 24, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 3, new DateTime(2024, 9, 25, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 25, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 5, new DateTime(2024, 9, 27, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 27, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 1, new DateTime(2024, 9, 23, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 23, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 4, new DateTime(2024, 9, 26, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 26, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 6, new DateTime(2024, 9, 28, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 28, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 2, new DateTime(2024, 9, 24, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 24, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 3, new DateTime(2024, 9, 25, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 25, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 6, new DateTime(2024, 9, 28, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 28, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 1, new DateTime(2024, 9, 23, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 23, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 3, new DateTime(2024, 9, 25, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 25, 16, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 5, new DateTime(2024, 9, 27, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 2, new DateTime(2024, 9, 24, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 24, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 4, new DateTime(2024, 9, 26, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 26, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 6, new DateTime(2024, 9, 28, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 28, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 1, new DateTime(2024, 9, 23, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 23, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 3, new DateTime(2024, 9, 25, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 25, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 5, new DateTime(2024, 9, 27, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 27, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 2, new DateTime(2024, 9, 24, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 24, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 4, new DateTime(2024, 9, 26, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 26, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 6, new DateTime(2024, 9, 28, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 28, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 1, new DateTime(2024, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 23, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 3, new DateTime(2024, 9, 25, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 25, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 5, new DateTime(2024, 9, 27, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 27, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 2, new DateTime(2024, 9, 24, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 24, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 4, new DateTime(2024, 9, 26, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 26, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 6, new DateTime(2024, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 28, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 1, new DateTime(2024, 9, 23, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 23, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 3, new DateTime(2024, 9, 25, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 25, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 5, new DateTime(2024, 9, 27, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 27, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 2, new DateTime(2024, 9, 24, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 24, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 4, new DateTime(2024, 9, 26, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 26, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 6, new DateTime(2024, 9, 28, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 28, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 1, new DateTime(2024, 9, 23, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 23, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 3, new DateTime(2024, 9, 25, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 25, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 5, new DateTime(2024, 9, 27, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 27, 11, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Class_CourseId",
                table: "Class",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Class_TeacherId",
                table: "Class",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassStudents_ClassId",
                table: "ClassStudents",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassWeekday_WeekdayId",
                table: "ClassWeekday",
                column: "WeekdayId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_LevelId",
                table: "Course",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Level_LanguageId",
                table: "Level",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_CourseId",
                table: "Payment",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_PaymentMethodId",
                table: "Payment",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_StudentId",
                table: "Payment",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_RoleId",
                table: "Staff",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassStudents");

            migrationBuilder.DropTable(
                name: "ClassWeekday");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "Weekday");

            migrationBuilder.DropTable(
                name: "PaymentMethod");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "StaffRole");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "Level");

            migrationBuilder.DropTable(
                name: "Language");
        }
    }
}
