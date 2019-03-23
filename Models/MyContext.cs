using Microsoft.EntityFrameworkCore;

namespace DojoActivity.Models {
    public class MyContext : DbContext {
        // base() calls the parent class' constructor passing the "options" parameter along
        public MyContext (DbContextOptions options) : base (options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Participation> Participations { get; set; }
    }
}