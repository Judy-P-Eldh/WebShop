using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebShop.Models.Enteties;

namespace WebShop.Data
{
    public class SeedData
    {
        private static List<PlantCategory> categories = new List<PlantCategory>();
        private static List<PlantSize> size;
        private static RoleManager<IdentityRole> roleManager = default!;
        private static UserManager<AppUser> userManager = default!;

        public static async Task InitAsync(ApplicationDbContext db, IServiceProvider service, RoleManager<IdentityRole> rolemanager, UserManager<AppUser> userManager)
        {
            if (await db.Products.AnyAsync()) return;

            roleManager = rolemanager;
            var res = await userManager.CreateAsync(new AppUser 
            {
                RegisterDate = DateTime.Now,
                Name = "P",
                Email = "admin@admin.se"
            });

           // var rm = service.GetRequiredService<RoleManager<IdentityRole>>();

            var plants = GetPlantCategory();
            await db.AddRangeAsync(plants);
            size = GetPlantSize();
            await db.AddRangeAsync(size);
            var prod = GetProducts();
            await db.AddRangeAsync(prod);
            var roleNames = new[] { "Staff", "Customer" };
            await AddRolesAsync(roleNames);

            await db.SaveChangesAsync();
        }

        private static List<Product> GetProducts()
        {
            var products = new List<Product>()
            {
                new Product
                {
                    Title = "Madagascar Jewel",
                    Description = "E. leuconeura is a succulent shrub, even a small tree, reaching to 1.8 m (6 ft) in height. " +
                                  "Although commonly mistaken for a cactus, it’s actually a member of the euphorbia family (Euphorbiaceae).",
                    Category = categories[0],
                    Image = "https://laidbackgardener.blog/wp-content/uploads/2020/01/202017a-plantsam.com_.jpg",
                    Size = size[0],
                    Price = 100
                },

                new Product
                {
                    Title = "Sansevieria",
                    Description = "Sansevieria is a historically recognized genus of flowering plants, native to Africa, notably Madagascar, " +
                                  "and southern Asia, now included in the genus Dracaena on the basis of molecular phylogenetic studies.",
                    Category = categories[5],
                    Image = "https://bloomscape.com/wp-content/uploads/2020/08/bloomscape_sansevieria_charcoal-e1633460982733.jpg?ver=279439",
                    Size = size[1],
                    Price = 100
                },

                 new Product
                 {
                    Title = "Tamarind",
                    Description = "The tamarind tree produces brown, pod-like fruits that contain a sweet, tangy pulp, " +
                                  "which is used in cuisines around the world.",
                    Category = categories[2],
                    Image = "https://balconygardenweb-lhnfx0beomqvnhspx.netdna-ssl.com/wp-content/uploads/2015/10/how-to-grow-Tamarind-tree_mini.jpg.webp",
                    Size = size[2],
                    Price = 100
                 },

                 new Product
                 {
                    Title = "Rose",
                    Description = "The rose is a type of flowering shrub. Its name comes from the Latin word Rosa.",
                    Category = categories[2],
                    Image = "https://tse2.mm.bing.net/th?id=OIP.RerYXKlvslELISSwblixHgHaHa&pid=Api",
                    Size = size[1],
                    Price = 100
                 },

                 new Product
                 {
                    Title = "Rosemary",
                    Description = "It is a member of the sage family Lamiaceae, which includes many other medicinal and culinary herbs.",
                    Category = categories[3],
                    Image = "https://www.thespruce.com/thmb/HH9a36S-PKSuGZ0YLVJLwBbt2kc=/700x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/grow-and-care-for-rosemary-plants-1403406-varieties-f2839b636d194f2790e08cd90f9c8598.jpg",
                    Size = size[0],
                    Price = 100
                 },

                 new Product
                 {
                    Title = "Orchid",
                    Description = "Orchids are one of the two largest families of flowering plants. The Orchidaceae have about 28,000 currently accepted species.",
                    Category = categories[5],
                    Image = "https://www.thespruce.com/thmb/Ic-RKE1GwLI7mK3p_eVmXY8kYI0=/700x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/basic-indoor-orchid-care-1902822-08-d562b7be935b4354ab9c30dddad7a3d5.jpg",
                    Size = size[0],
                    Price = 100
                 },

                 new Product
                 {
                    Title = "Pothos",
                    Description = "Pothos is often used as hanging plants in the home, but is a large climbing vine in its natural environment.",
                    Category = categories[1],
                    Image = "https://images.immediate.co.uk/production/volatile/sites/10/2021/05/2048x1365-Pothos_epipremnum-SEO-GettyImages-1249996690-6148620.jpg?webp=true&quality=90&resize=620%2C413",
                    Size = size[1],
                    Price = 100
                 },

                 new Product
                 {
                    Title = "Swiss Cheese Plant",
                    Description = "The name directly translates to ‘Monstrous Delicious’ in reference to its large growth potential " +
                                  "in the wild and the edible fruit the plant produces.",
                    Category = categories[2],
                    Image = "https://www.thespruce.com/thmb/ypX0-gl6Dn1EqjK8DSrdSzf8584=/700x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/grow-monstera-adansonii-swiss-cheese-plant-1902774-09-70c06de77fe143f69061c7ea01a40eb1.jpg",
                    Size = size[2],
                    Price = 100
                 }
            };

            return products;
        }

        private static List<PlantSize> GetPlantSize()
        {
            var size = new List<PlantSize>();
            size.Add(new PlantSize { Size = 1 });
            size.Add(new PlantSize { Size = 2 });
            size.Add(new PlantSize { Size = 3 });

            return size;
        }

        private static List<PlantCategory> GetPlantCategory()
        {
            categories = new List<PlantCategory>()
            {
                 new PlantCategory{ Name = "Houseplant"},
                 new PlantCategory{ Name = "Perennial"},
                 new PlantCategory{ Name = "Tree/Shrub"},
                 new PlantCategory{ Name = "Edible"},
                 new PlantCategory{ Name = "Climber"},
                 new PlantCategory{ Name = "Flowering"}
            };
            return categories;
        }

        private static async Task AddRolesAsync(string[] roleNames)
        {
            if (roleManager is null) throw new NullReferenceException(nameof(RoleManager<IdentityRole>));

            foreach (var roleName in roleNames)
            {
                if (await roleManager.RoleExistsAsync(roleName)) continue;
                var role = new IdentityRole { Name = roleName };
                var result = await roleManager.CreateAsync(role);

                if (!result.Succeeded) throw new Exception(string.Join("\n", result.Errors));
            }
        }
    }
}
