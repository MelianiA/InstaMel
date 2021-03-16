using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InstaMel.Migrations
{
    public partial class modiDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Like_AspNetUsers_UserID",
                table: "Like");

            migrationBuilder.DropForeignKey(
                name: "FK_Like_Post_PostID",
                table: "Like");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_AspNetUsers_UserID",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Story_AspNetUsers_UserID",
                table: "Story");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Story",
                table: "Story");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Post",
                table: "Post");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Like",
                table: "Like");

            migrationBuilder.RenameTable(
                name: "Story",
                newName: "Stories");

            migrationBuilder.RenameTable(
                name: "Post",
                newName: "Posts");

            migrationBuilder.RenameTable(
                name: "Like",
                newName: "Likes");

            migrationBuilder.RenameIndex(
                name: "IX_Story_UserID",
                table: "Stories",
                newName: "IX_Stories_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Post_UserID",
                table: "Posts",
                newName: "IX_Posts_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Like_UserID",
                table: "Likes",
                newName: "IX_Likes_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Like_PostID",
                table: "Likes",
                newName: "IX_Likes_PostID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stories",
                table: "Stories",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posts",
                table: "Posts",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Likes",
                table: "Likes",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Chat",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chat", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Follow",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FollowingID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FollowerID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Follow", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Texte = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Href = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ischecked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Seen",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    storyID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seen", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Seen_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Seen_Stories_storyID",
                        column: x => x.storyID,
                        principalTable: "Stories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChatID = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Message_Chat_ChatID",
                        column: x => x.ChatID,
                        principalTable: "Chat",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Message_ChatID",
                table: "Message",
                column: "ChatID");

            migrationBuilder.CreateIndex(
                name: "IX_Seen_storyID",
                table: "Seen",
                column: "storyID");

            migrationBuilder.CreateIndex(
                name: "IX_Seen_UserID",
                table: "Seen",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_AspNetUsers_UserID",
                table: "Likes",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Posts_PostID",
                table: "Likes",
                column: "PostID",
                principalTable: "Posts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_UserID",
                table: "Posts",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stories_AspNetUsers_UserID",
                table: "Stories",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_AspNetUsers_UserID",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Posts_PostID",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_UserID",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Stories_AspNetUsers_UserID",
                table: "Stories");

            migrationBuilder.DropTable(
                name: "Follow");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Seen");

            migrationBuilder.DropTable(
                name: "Chat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stories",
                table: "Stories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Posts",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Likes",
                table: "Likes");

            migrationBuilder.RenameTable(
                name: "Stories",
                newName: "Story");

            migrationBuilder.RenameTable(
                name: "Posts",
                newName: "Post");

            migrationBuilder.RenameTable(
                name: "Likes",
                newName: "Like");

            migrationBuilder.RenameIndex(
                name: "IX_Stories_UserID",
                table: "Story",
                newName: "IX_Story_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_UserID",
                table: "Post",
                newName: "IX_Post_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_UserID",
                table: "Like",
                newName: "IX_Like_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_PostID",
                table: "Like",
                newName: "IX_Like_PostID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Story",
                table: "Story",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Post",
                table: "Post",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Like",
                table: "Like",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Like_AspNetUsers_UserID",
                table: "Like",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Like_Post_PostID",
                table: "Like",
                column: "PostID",
                principalTable: "Post",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_AspNetUsers_UserID",
                table: "Post",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Story_AspNetUsers_UserID",
                table: "Story",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
