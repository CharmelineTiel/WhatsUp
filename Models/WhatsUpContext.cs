using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WhatsUp.Models
{
    public class WhatsUpContext : DbContext
    {
        public WhatsUpContext()
            : base("name=WhatsUpConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasRequired<Account>(c => c.OwnerAccount).WithMany(a => a.Contacten).HasForeignKey(c => c.OwnerAccountID);
        }

        public DbSet<Contact> Contacten { get; set; }
        public DbSet<Bericht> Chats { get; set; }
        public DbSet<Account> Accounts { get; set; }


    }
}