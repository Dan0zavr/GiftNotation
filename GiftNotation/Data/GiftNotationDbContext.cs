using System;
using System.Collections.Generic;
using GiftNotation.Models;
using Microsoft.EntityFrameworkCore;

namespace GiftNotation.Data;

public partial class GiftNotationDbContext : DbContext
{
    public GiftNotationDbContext(DbContextOptions<GiftNotationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<EventType> EventTypes { get; set; }
    public DbSet<Gift> Gifts { get; set; }
    public DbSet<RelpType> RelpTypes { get; set; }
    public DbSet<Status> Statuses { get; set; }
    public DbSet<GiftContact> GiftContacts { get; set; }
    public DbSet<GiftEvent> GiftEvents { get; set; }
    public DbSet<EventContact> EventContacts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Конфигурация таблицы-связи `event_contact`
        modelBuilder.Entity<EventContact>()
            .HasKey(ec => new { ec.EventId, ec.ContactId });

        modelBuilder.Entity<EventContact>()
            .HasOne(ec => ec.Event)
            .WithMany(e => e.EventContacts)
            .HasForeignKey(ec => ec.EventId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<EventContact>()
            .HasOne(ec => ec.Contact)
            .WithMany(c => c.EventContacts)
            .HasForeignKey(ec => ec.ContactId)
            .OnDelete(DeleteBehavior.Cascade);

        // Конфигурация таблицы-связи `gift_contact`
        modelBuilder.Entity<GiftContact>()
            .HasKey(gc => new { gc.GiftId, gc.ContactId });

        modelBuilder.Entity<GiftContact>()
            .HasOne(gc => gc.Gift)
            .WithMany(g => g.GiftContacts)
            .HasForeignKey(gc => gc.GiftId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<GiftContact>()
            .HasOne(gc => gc.Contact)
            .WithMany(c => c.GiftContacts)
            .HasForeignKey(gc => gc.ContactId)
            .OnDelete(DeleteBehavior.Cascade);

        // Конфигурация таблицы-связи `gift_event`
        modelBuilder.Entity<GiftEvent>()
            .HasKey(ge => new { ge.GiftId, ge.EventId });

        modelBuilder.Entity<GiftEvent>()
            .HasOne(ge => ge.Gift)
            .WithMany(g => g.GiftEvents)
            .HasForeignKey(ge => ge.GiftId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<GiftEvent>()
            .HasOne(ge => ge.Event)
            .WithMany(e => e.GiftEvents)
            .HasForeignKey(ge => ge.EventId)
            .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);
    }
}


