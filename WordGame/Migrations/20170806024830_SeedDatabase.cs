using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WordGame.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql("INSERT INTO Users (Username, Email) VALUES ('zeus999', 'zeus999@gmail.com')");
			migrationBuilder.Sql("INSERT INTO Users (Username, Email) VALUES ('lotus989', 'lotus989@yahoo.com')");
			migrationBuilder.Sql("INSERT INTO Users (Username, Email) VALUES ('betatester', 'betatester@afrika.com')");

            migrationBuilder.Sql("INSERT INTO GameResults (GameId, Score, IncorrectAnswers, DateTime, UserId) VALUES ('3da06893-303d-415c-95e0-953edd479cec', 22, 3, CONVERT(datetime,'Feb 07 13:02:52 2017'), (SELECT ID FROM Users WHERE Username = 'lotus989'))");
			migrationBuilder.Sql("INSERT INTO GameResults (GameId, Score, IncorrectAnswers, DateTime, UserId) VALUES ('84fce400-21c7-4627-8ed1-44ed3f69c6ad', 32, 9, CONVERT(datetime,'Jan 02 16:58:22 2017'), (SELECT ID FROM Users WHERE Username = 'lotus989'))");
			migrationBuilder.Sql("INSERT INTO GameResults (GameId, Score, IncorrectAnswers, DateTime, UserId) VALUES ('95b2fb8a-6db3-4696-9763-faf584628798', 15, 0, CONVERT(datetime,'Mar 26 17:17:32 2016'), (SELECT ID FROM Users WHERE Username = 'zeus999'))");
			migrationBuilder.Sql("INSERT INTO GameResults (GameId, Score, IncorrectAnswers, DateTime, UserId) VALUES ('9120f81e-260b-4292-aaa0-a749246544a0', 21, 4, CONVERT(datetime,'Apr 12 05:05:42 2017'), (SELECT ID FROM Users WHERE Username = 'zeus999'))");
			migrationBuilder.Sql("INSERT INTO GameResults (GameId, Score, IncorrectAnswers, DateTime, UserId) VALUES ('1fe095d7-3057-4c4a-82d0-c0dff7666f84', 26, 1, CONVERT(datetime,'May 19 14:14:12 2017'), (SELECT ID FROM Users WHERE Username = 'lotus989'))");
			migrationBuilder.Sql("INSERT INTO GameResults (GameId, Score, IncorrectAnswers, DateTime, UserId) VALUES ('b48167cd-4265-4c9a-b134-18142e9e9016', 19, 2, CONVERT(datetime,'Jun 09 22:22:13 2017'), (SELECT ID FROM Users WHERE Username = 'zeus999'))");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Users WHERE Username IN ('zeus999', 'lotus989', 'betatester')");
        }
    }
}
