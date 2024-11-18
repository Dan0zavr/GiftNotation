﻿// <auto-generated />
using System;
using GiftNotation.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GiftNotation.Migrations
{
    [DbContext(typeof(GiftNotationDbContext))]
    [Migration("20241116194404_PriceToDouble")]
    partial class PriceToDouble
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("GiftNotation.Models.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Bday")
                        .HasColumnType("TEXT");

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("RelpTypeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ContactId");

                    b.HasIndex("RelpTypeId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("GiftNotation.Models.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("EventName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("EventTypeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("EventId");

                    b.HasIndex("EventTypeId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("GiftNotation.Models.EventContact", b =>
                {
                    b.Property<int>("EventId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ContactId")
                        .HasColumnType("INTEGER");

                    b.HasKey("EventId", "ContactId");

                    b.HasIndex("ContactId");

                    b.ToTable("EventContacts");
                });

            modelBuilder.Entity("GiftNotation.Models.EventType", b =>
                {
                    b.Property<int>("EventTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("EventTypeName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("EventTypeId");

                    b.ToTable("EventTypes");
                });

            modelBuilder.Entity("GiftNotation.Models.Gift", b =>
                {
                    b.Property<int>("GiftId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("GiftName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("GiftPic")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<int>("StatusId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("GiftId");

                    b.HasIndex("StatusId");

                    b.ToTable("Gifts");
                });

            modelBuilder.Entity("GiftNotation.Models.GiftContact", b =>
                {
                    b.Property<int>("GiftId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ContactId")
                        .HasColumnType("INTEGER");

                    b.HasKey("GiftId", "ContactId");

                    b.HasIndex("ContactId");

                    b.ToTable("GiftContacts");
                });

            modelBuilder.Entity("GiftNotation.Models.GiftEvent", b =>
                {
                    b.Property<int>("GiftId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EventId")
                        .HasColumnType("INTEGER");

                    b.HasKey("GiftId", "EventId");

                    b.HasIndex("EventId");

                    b.ToTable("GiftEvents");
                });

            modelBuilder.Entity("GiftNotation.Models.RelpType", b =>
                {
                    b.Property<int>("RelpTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("RelpTypeName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("RelpTypeId");

                    b.ToTable("RelpTypes");
                });

            modelBuilder.Entity("GiftNotation.Models.Status", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("StatusId");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("GiftNotation.Models.Contact", b =>
                {
                    b.HasOne("GiftNotation.Models.RelpType", "RelpType")
                        .WithMany("Contacts")
                        .HasForeignKey("RelpTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RelpType");
                });

            modelBuilder.Entity("GiftNotation.Models.Event", b =>
                {
                    b.HasOne("GiftNotation.Models.EventType", "EventType")
                        .WithMany("Events")
                        .HasForeignKey("EventTypeId");

                    b.Navigation("EventType");
                });

            modelBuilder.Entity("GiftNotation.Models.EventContact", b =>
                {
                    b.HasOne("GiftNotation.Models.Contact", "Contact")
                        .WithMany("EventContacts")
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GiftNotation.Models.Event", "Event")
                        .WithMany("EventContacts")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contact");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("GiftNotation.Models.Gift", b =>
                {
                    b.HasOne("GiftNotation.Models.Status", "Status")
                        .WithMany("Gifts")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("GiftNotation.Models.GiftContact", b =>
                {
                    b.HasOne("GiftNotation.Models.Contact", "Contact")
                        .WithMany("GiftContacts")
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GiftNotation.Models.Gift", "Gift")
                        .WithMany("GiftContacts")
                        .HasForeignKey("GiftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contact");

                    b.Navigation("Gift");
                });

            modelBuilder.Entity("GiftNotation.Models.GiftEvent", b =>
                {
                    b.HasOne("GiftNotation.Models.Event", "Event")
                        .WithMany("GiftEvents")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GiftNotation.Models.Gift", "Gift")
                        .WithMany("GiftEvents")
                        .HasForeignKey("GiftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Gift");
                });

            modelBuilder.Entity("GiftNotation.Models.Contact", b =>
                {
                    b.Navigation("EventContacts");

                    b.Navigation("GiftContacts");
                });

            modelBuilder.Entity("GiftNotation.Models.Event", b =>
                {
                    b.Navigation("EventContacts");

                    b.Navigation("GiftEvents");
                });

            modelBuilder.Entity("GiftNotation.Models.EventType", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("GiftNotation.Models.Gift", b =>
                {
                    b.Navigation("GiftContacts");

                    b.Navigation("GiftEvents");
                });

            modelBuilder.Entity("GiftNotation.Models.RelpType", b =>
                {
                    b.Navigation("Contacts");
                });

            modelBuilder.Entity("GiftNotation.Models.Status", b =>
                {
                    b.Navigation("Gifts");
                });
#pragma warning restore 612, 618
        }
    }
}
