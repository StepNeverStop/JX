namespace JX.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EntityDbContext : DbContext
    {
        public EntityDbContext()
            : base("name=EntityDbContext")
        {
        }

        public virtual DbSet<ContentTypes> ContentTypes { get; set; }
        public virtual DbSet<Projects> Projects { get; set; }
        public virtual DbSet<ProjectStates> ProjectStates { get; set; }
        public virtual DbSet<ProjectTypes> ProjectTypes { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Scenario> Scenario { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<WorldOutlooks> WorldOutlooks { get; set; }
        public virtual DbSet<WriteProject> WriteProject { get; set; }
        public virtual DbSet<WriteStates> WriteStates { get; set; }
        public virtual DbSet<UserScenarioComment> UserScenarioComment { get; set; }
        public virtual DbSet<UserWorldOutlookComment> UserWorldOutlookComment { get; set; }
        public virtual DbSet<WriteComment> WriteComment { get; set; }

        public virtual DbSet<UserAttentions> UserAttentions { get; set; }

        public virtual DbSet<UserCollectProjects> UserCollectProjects { get; set; }

        public virtual DbSet<UserHistory> UserHistory { get; set; }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<ContentTypes>()
        //        .HasMany(e => e.UserScenarioComment)
        //        .WithRequired(e => e.ContentTypes)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<ContentTypes>()
        //        .HasMany(e => e.UserWorldOutlookComment)
        //        .WithRequired(e => e.ContentTypes)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<ContentTypes>()
        //        .HasMany(e => e.WriteComment)
        //        .WithRequired(e => e.ContentTypes)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<Projects>()
        //        .Property(e => e.ProjectTypes)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Projects>()
        //        .HasMany(e => e.Scenario)
        //        .WithRequired(e => e.Projects)
        //        .HasForeignKey(e => e.ProjectID)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<Projects>()
        //        .HasMany(e => e.WorldOutlooks1)
        //        .WithRequired(e => e.Projects1)
        //        .HasForeignKey(e => e.ProjectID)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<Projects>()
        //        .HasMany(e => e.WriteProject)
        //        .WithRequired(e => e.Projects)
        //        .HasForeignKey(e => e.ProjectID)
        //        .WillCascadeOnDelete(false);



        //    modelBuilder.Entity<ProjectStates>()
        //        .HasMany(e => e.Projects)
        //        .WithRequired(e => e.ProjectStates)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<Roles>()
        //        .Property(e => e.RoleName)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Roles>()
        //        .HasMany(e => e.Users)
        //        .WithRequired(e => e.Roles)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<Scenario>()
        //        .HasMany(e => e.UserScenarioComment)
        //        .WithRequired(e => e.Scenario)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<Users>()
        //        .Property(e => e.MD5Password)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Users>()
        //        .HasMany(e => e.Scenario)
        //        .WithRequired(e => e.Users)
        //        .HasForeignKey(e => e.UserID)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<Users>()
        //        .HasMany(e => e.UserScenarioComment)
        //        .WithRequired(e => e.Users)
        //        .HasForeignKey(e => e.UserID)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<Users>()
        //        .HasMany(e => e.UserWorldOutlookComment)
        //        .WithRequired(e => e.Users)
        //        .HasForeignKey(e => e.UserID)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<Users>()
        //        .HasMany(e => e.WorldOutlooks)
        //        .WithRequired(e => e.Users)
        //        .HasForeignKey(e => e.UserID)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<Users>()
        //        .HasMany(e => e.WriteComment)
        //        .WithRequired(e => e.Users)
        //        .HasForeignKey(e => e.UserID)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<Users>()
        //        .HasMany(e => e.WriteProject)
        //        .WithRequired(e => e.Users)
        //        .HasForeignKey(e => e.UserID)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<WorldOutlooks>()
        //        .HasMany(e => e.Projects)
        //        .WithOptional(e => e.WorldOutlooks)
        //        .HasForeignKey(e => e.WorldOutlooksID);

        //    modelBuilder.Entity<WorldOutlooks>()
        //        .HasMany(e => e.UserWorldOutlookComment)
        //        .WithRequired(e => e.WorldOutlooks)
        //        .HasForeignKey(e => e.WorldOutlookID)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<WriteProject>()
        //        .HasMany(e => e.WriteComment)
        //        .WithRequired(e => e.WriteProject)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<WriteStates>()
        //        .HasMany(e => e.WriteProject)
        //        .WithRequired(e => e.WriteStates)
        //        .WillCascadeOnDelete(false);
        //}
    }
}
