using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;

namespace RecipeSuggestion.Models
{
	public class RecipeSuggestionDbContext : IdentityDbContext<User>
    {
		public RecipeSuggestionDbContext(DbContextOptions options) : base(options) { }

        // informations is not a grammar error, just to keep class name and property name distinct
        public DbSet<UserInformation> UserInformations { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// call base class version to setup Indentity relations:
			base.OnModelCreating(modelBuilder);
		}


        /*
        public static async Task CreateAdminUser(IServiceProvider serviceProvider)
        {
            UserManager<User> userManager =
                serviceProvider.GetRequiredService<UserManager<User>>();
            RoleManager<IdentityRole> roleManager =
                serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string username = "admin";
            string password = "Sesame";
            string roleName = "Admin";

            // if role doesn't exist, create it
            if (await roleManager.FindByNameAsync(roleName) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }

            // if username doesn't exist, create it and add to role
            if (await userManager.FindByNameAsync(username) == null)
            {
                User user = new User { UserName = username };
                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, roleName);
                }
            }
        }
        */
    }
}
