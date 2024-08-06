using PromoMashTest.Server.Core.Entities;

namespace PromoMashTest.Server.Infrastructure.Data
{
    public static class DataSeeder
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            using (var context = serviceProvider.GetRequiredService<ApplicationDbContext>())
            {
                context.Database.EnsureCreated();

                if (!context.Countries.Any())
                {
                    var countries = new List<Country>
                    {
                        new Country
                        {
                            Name = "Country 1",
                            Provinces = new List<Province>
                            {
                                new Province { Name = "Province 1.1" },
                                new Province { Name = "Province 1.2" }
                            }
                        },
                        new Country
                        {
                            Name = "Country 2",
                            Provinces = new List<Province>
                            {
                                new Province { Name = "Province 2.1" },
                                new Province { Name = "Province 2.2" }
                            }
                        }
                    };

                    context.Countries.AddRange(countries);
                    context.SaveChanges();
                }
            }
        }
    }
}
