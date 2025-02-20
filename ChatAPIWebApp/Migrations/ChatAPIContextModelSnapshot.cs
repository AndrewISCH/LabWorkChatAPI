﻿// <auto-generated />
using System;
using ChatAPIWebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ChatAPIWebApp.Migrations
{
    [DbContext(typeof(ChatAPIContext))]
    partial class ChatAPIContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ChatAPIWebApp.Models.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("CreationDate")
                        .HasColumnType("date");

                    b.Property<int>("User1Id")
                        .HasColumnType("int");

                    b.Property<int>("User2Id")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("User1Id");

                    b.HasIndex("User2Id");

                    b.HasIndex("UserId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("ChatAPIWebApp.Models.ContactRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ReceiverId")
                        .HasColumnType("int");

                    b.Property<int>("SenderId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("SendingDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("ContactRequests");
                });

            modelBuilder.Entity("ChatAPIWebApp.Models.Dialogue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("NumOfMessages")
                        .HasColumnType("int");

                    b.Property<int>("User1Id")
                        .HasColumnType("int");

                    b.Property<int>("User2Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("User1Id");

                    b.HasIndex("User2Id");

                    b.ToTable("Dialogues");
                });

            modelBuilder.Entity("ChatAPIWebApp.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("CreationDate")
                        .HasColumnType("date");

                    b.Property<int>("DialogueId")
                        .HasColumnType("int");

                    b.Property<int>("SenderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DialogueId");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("ChatAPIWebApp.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("CreationDate")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserConfigId")
                        .HasColumnType("int");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ChatAPIWebApp.Models.UserConfiguration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsHiddenActivity")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPrivate")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserConfigurations");
                });

            modelBuilder.Entity("ChatAPIWebApp.Models.Contact", b =>
                {
                    b.HasOne("ChatAPIWebApp.Models.User", "User1")
                        .WithMany()
                        .HasForeignKey("User1Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ChatAPIWebApp.Models.User", "User2")
                        .WithMany()
                        .HasForeignKey("User2Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ChatAPIWebApp.Models.User", null)
                        .WithMany("Contacts")
                        .HasForeignKey("UserId");

                    b.Navigation("User1");

                    b.Navigation("User2");
                });

            modelBuilder.Entity("ChatAPIWebApp.Models.ContactRequest", b =>
                {
                    b.HasOne("ChatAPIWebApp.Models.User", "Receiver")
                        .WithMany("ReceivedRequests")
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ChatAPIWebApp.Models.User", "Sender")
                        .WithMany("SentRequests")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("ChatAPIWebApp.Models.Dialogue", b =>
                {
                    b.HasOne("ChatAPIWebApp.Models.User", "User1")
                        .WithMany("Dialogues")
                        .HasForeignKey("User1Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ChatAPIWebApp.Models.User", "User2")
                        .WithMany()
                        .HasForeignKey("User2Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User1");

                    b.Navigation("User2");
                });

            modelBuilder.Entity("ChatAPIWebApp.Models.Message", b =>
                {
                    b.HasOne("ChatAPIWebApp.Models.Dialogue", "Dialogue")
                        .WithMany("Messages")
                        .HasForeignKey("DialogueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChatAPIWebApp.Models.User", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Dialogue");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("ChatAPIWebApp.Models.UserConfiguration", b =>
                {
                    b.HasOne("ChatAPIWebApp.Models.User", "User")
                        .WithOne("UserConfiguration")
                        .HasForeignKey("ChatAPIWebApp.Models.UserConfiguration", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ChatAPIWebApp.Models.Dialogue", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("ChatAPIWebApp.Models.User", b =>
                {
                    b.Navigation("Contacts");

                    b.Navigation("Dialogues");

                    b.Navigation("ReceivedRequests");

                    b.Navigation("SentRequests");

                    b.Navigation("UserConfiguration")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
