using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GiftNotation.Models;

namespace GiftNotation.Data
{
    public class GiftNotationDbContext : DbContext
    {
        public GiftNotationDbContext(DbContextOptions<GiftNotationDbContext> options) : base(options) { }

        public DbSet<Contact> contact { get; set; }
        public DbSet<Event> events { get; set; }
        public DbSet<EventType> eventType { get; set; }
        public DbSet<Gift> gift { get; set; }
        public DbSet<GiftContact> giftContact { get; set; }
        public DbSet<GiftEvent> giftEvent { get; set; }
        public DbSet<RelationshipType> relationshipType { get; set; }
        public DbSet<Status> status { get; set; }
        public DbSet<MyFriends> friends { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string connectionString = "Data Source=C:\\Users\\Haier\\source\\repos\\GiftNotation\\notes.db";

            modelBuilder.Entity<GiftContact>().HasNoKey();
            modelBuilder.Entity<GiftEvent>().HasNoKey();
            modelBuilder.Entity<MyFriends>().HasNoKey();


            base.OnModelCreating(modelBuilder);
        }

    }
}
