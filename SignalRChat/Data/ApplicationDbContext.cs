using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SignalRChat.Models;

namespace SignalRChat.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Connection> Connections { get; set; }
        public DbSet<ConversationRoom> Rooms { get; set; }
    }
}
