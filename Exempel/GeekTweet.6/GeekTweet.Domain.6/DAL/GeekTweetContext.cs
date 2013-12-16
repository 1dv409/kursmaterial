using System.Data.Entity;
using GeekTweet.Domain.Abstract;
using GeekTweet.Domain.Entities;

namespace GeekTweet.Domain.DAL
{
    /// <summary>
    /// 
    /// </summary>
    internal class GeekTweetContext : DbContext, IGeekTweetContext
    {
        /// <summary>
        /// 
        /// </summary>
        public IDbSet<User> Users { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IDbSet<Tweet> Tweets { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public GeekTweetContext()
            : base("name=GeekTweetConnectionString")
        {
            // Empty!
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Map entity types to tables.
            modelBuilder.Entity<User>().ToTable("User", "app");
            modelBuilder.Entity<Tweet>().ToTable("Tweet", "app");

            //// Configure a one to many relationship.
            //modelBuilder.Entity<User>()
            //    .HasMany(u => u.Tweets).WithRequired(t => t.User)
            //    .Map(t => t.MapKey("UserId"));

        }
    }
}
