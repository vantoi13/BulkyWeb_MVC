using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Data
{
    public class DbInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly string AdminRoleName = "Admin";
        private readonly string UserRoleName = "Member";

        public DbInitializer(ApplicationDbContext context,
          UserManager<User> userManager,
          RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Seed()
        {
            // Seeding role
            if (!_roleManager.Roles.Any())
            {
                await _roleManager.CreateAsync(new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = AdminRoleName,
                    NormalizedName = AdminRoleName.ToUpper(),
                });
                await _roleManager.CreateAsync(new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = UserRoleName,
                    NormalizedName = UserRoleName.ToUpper(),
                });
            }

            // Seeding user
            if (!_userManager.Users.Any())
            {
                var result = await _userManager.CreateAsync(new User
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "example@gmail.com",
                    FullName = "Example",
                    Email = "example@gmail.com",
                    LockoutEnabled = false,
                    PhoneNumber = "0987654321",
                    Dob = new DateTime(2000, 01, 01)
                }, "Admin@123");
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync("example@gmail.com");
                    if (user != null)
                        await _userManager.AddToRoleAsync(user, AdminRoleName);
                }
            }


           
           


          


         

         

          

          
        }
    }
    // public static class DbInitializer
    // {   
    //     public static void Seed(IServiceProvider serviceProvider)
    //     {
    //         using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
    //         {
    //             Console.WriteLine("Seeding database...");
    //             // Look for any categories
    //             if (context.Category.Any())
    //             {
    //                 Console.WriteLine("Database has been seeded.");
    //                 return;   // DB has been seeded
    //             }

    //             Console.WriteLine("Seeding database with new data...");
    //             context.Category.AddRange(
    //                 new Category
    //                 {
    //                     Name = "Books",
    //                     DisplayOrder = 1
    //                 }
    //             );

    //             // Look for any products
    //             if (context.Products.Any())
    //             {
    //                 return;   // DB has been seeded
    //             }

    //             context.Products.AddRange(
    //                 new Product
    //                 {
    //                     Title = "ASP.NET Core MVC",
    //                     Description = "Learn how to build web applications using ASP.NET Core MVC.",
    //                     ISBN = "978-0-1234-5678",
    //                     Author = "vnLab",
    //                     ListPrice = 50.00,
    //                     Price = 45.00,
    //                     Price50 = 40.00,
    //                     Price100 = 35.00,
    //                     CategoryId = 1, // Books
    //                     ImagePath = "/images/aspnetcoremvc.jpg"
    //                 },
    //                 new Product
    //                 {
    //                     Title = "ASP.NET Core API",
    //                     Description = "Learn how to build APIs with ASP.NET Core.",
    //                     ISBN = "978-0-2345-6789",
    //                     Author = "vnLab",
    //                     ListPrice = 60.00,
    //                     Price = 55.00,
    //                     Price50 = 50.00,
    //                     Price100 = 45.00,
    //                     CategoryId = 1, // Books
    //                     ImagePath = "/images/aspnetcoreapi.jpg"
    //                 },
    //                 new Product
    //                 {
    //                     Title = "C# Programming",
    //                     Description = "Comprehensive guide to mastering C# programming.",
    //                     ISBN = "978-1-2345-6789",
    //                     Author = "John Doe",
    //                     ListPrice = 40.00,
    //                     Price = 35.00,
    //                     Price50 = 30.00,
    //                     Price100 = 25.00,
    //                     CategoryId = 1, // Books
    //                     ImagePath = "/images/csharp.jpg"
    //                 },
    //                 new Product
    //                 {
    //                     Title = "JavaScript Essentials",
    //                     Description = "Master the basics of JavaScript and web development.",
    //                     ISBN = "978-2-3456-7890",
    //                     Author = "Jane Smith",
    //                     ListPrice = 45.00,
    //                     Price = 40.00,
    //                     Price50 = 35.00,
    //                     Price100 = 30.00,
    //                     CategoryId = 1, // Books
    //                     ImagePath = "/images/javascript.jpg"
    //                 },
    //                 new Product
    //                 {
    //                     Title = "Learning Python",
    //                     Description = "An introduction to Python programming.",
    //                     ISBN = "978-3-4567-8901",
    //                     Author = "Mark Lee",
    //                     ListPrice = 55.00,
    //                     Price = 50.00,
    //                     Price50 = 45.00,
    //                     Price100 = 40.00,
    //                     CategoryId = 1, // Books
    //                     ImagePath = "/images/learningpython.jpg"
    //                 },
    //                 new Product
    //                 {
    //                     Title = "Mastering SQL",
    //                     Description = "Learn how to write efficient SQL queries.",
    //                     ISBN = "978-4-5678-9012",
    //                     Author = "Sarah Brown",
    //                     ListPrice = 50.00,
    //                     Price = 45.00,
    //                     Price50 = 40.00,
    //                     Price100 = 35.00,
    //                     CategoryId = 1, // Books
    //                     ImagePath = "/images/masteringsql.jpg"
    //                 },
    //                 new Product
    //                 {
    //                     Title = "HTML and CSS Fundamentals",
    //                     Description = "The complete guide to web design with HTML and CSS.",
    //                     ISBN = "978-5-6789-0123",
    //                     Author = "Emily White",
    //                     ListPrice = 35.00,
    //                     Price = 30.00,
    //                     Price50 = 25.00,
    //                     Price100 = 20.00,
    //                     CategoryId = 1, // Books
    //                     ImagePath = "/images/htmlcss.jpg"
    //                 },
    //                 new Product
    //                 {
    //                     Title = "Web Development with React",
    //                     Description = "Learn how to build web apps with React.",
    //                     ISBN = "978-6-7890-1234",
    //                     Author = "Chris Green",
    //                     ListPrice = 60.00,
    //                     Price = 55.00,
    //                     Price50 = 50.00,
    //                     Price100 = 45.00,
    //                     CategoryId = 1, // Books
    //                     ImagePath = "/images/react.jpg"
    //                 },
    //                 new Product
    //                 {
    //                     Title = "Node.js for Beginners",
    //                     Description = "A beginner's guide to Node.js and server-side JavaScript.",
    //                     ISBN = "978-7-8901-2345",
    //                     Author = "Alice Miller",
    //                     ListPrice = 40.00,
    //                     Price = 35.00,
    //                     Price50 = 30.00,
    //                     Price100 = 25.00,
    //                     CategoryId = 1, // Books
    //                     ImagePath = "/images/nodejs.jpg"
    //                 },
    //                 new Product
    //                 {
    //                     Title = "Angular in Action",
    //                     Description = "A practical guide to mastering Angular.",
    //                     ISBN = "978-8-9012-3456",
    //                     Author = "David King",
    //                     ListPrice = 65.00,
    //                     Price = 60.00,
    //                     Price50 = 55.00,
    //                     Price100 = 50.00,
    //                     CategoryId = 1, // Books
    //                     ImagePath = "/images/angular.jpg"
    //                 }
    //             );

    //             context.SaveChanges();
    //         }
    //     }
    // }
}
