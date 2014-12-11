using GeekTweet.Domain.Entities;
using GeekTweet.Domain.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;

namespace GeekTweet.Domain.DAL
{
    internal class GeekTweetContext : DbContext
    {
        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<User> Users { get; set; }

        public GeekTweetContext()
            : base("GeekTweetConnectionString")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.HasDefaultSchema("app");

            // One-to-many with Fluent API.
            //modelBuilder.Entity<User>().HasMany<Tweet>(t => t.Tweets).WithRequired(t => t.User).HasForeignKey(t => t.UserId);

            base.OnModelCreating(modelBuilder);
        }

        protected override DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items)
        {
            var result = base.ValidateEntity(entityEntry, items);

            // Validate the entity object with data annotations.
            var dataAnnotationsValidator = new DataAnnotationsValidator();
            ICollection<ValidationResult> validationResults;
            if (!dataAnnotationsValidator.TryValidate(entityEntry.Entity, out validationResults))
            {
                foreach (var validationResult in validationResults)
                {
                    foreach (var memberName in validationResult.MemberNames)
                    {
                        result.ValidationErrors.Add(new DbValidationError(memberName, validationResult.ErrorMessage));
                    }
                }
            }

            return result;
        }
    }
}
