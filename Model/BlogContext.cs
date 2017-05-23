using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using VSBlog_Backend.Biz;

namespace VSBlog_Backend.Model
{
    public class BlogContext : DbContext
    {
        public BlogContext() : base("VSBlog")
        {
            if (Helper.RebuildDb)
                Database.SetInitializer(new DropCreateDatabaseAlways<BlogContext>());
            else
                Database.SetInitializer(new CreateDatabaseIfNotExists<BlogContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("VSBLOG");
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("\nEntity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        public DbSet<User> Users { get; set; }
    }
}