using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using ForumProject.Models.ForumModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ForumProject.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DiscussionsCount { get; set; }
        public int PostsCount { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public DbSet<UserPostLike> UsersPostLikes { get; set; }
        public DbSet<UserPostDislike> UsersPostDislikes { get; set; }
        public DbSet<UserDiscussionLike> UsersDiscussionLikes { get; set; }
        public DbSet<UserDiscussionDislike> UsersDiscussionDislikes { get; set; }
     

        public DbSet<Category> Categories { get; set; }
        public DbSet<Discussion> Discussions { get; set; }
        public DbSet<Post> Posts { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}