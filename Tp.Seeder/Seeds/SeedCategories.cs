using Tp.Common.Constants;

namespace Tp.Seeder.Seeds
{
    public static class CategorySeeder
    {
        /// <summary>
        /// Seed
        /// </summary>
        public static bool Seed()
        {
            var service = new Service.Service();

            if (service.Category.Any())
            {

                return false;
            }

            SeedCategory(service, "History", CheeseColour.Yellow);
            SeedCategory(service, "Sport", CheeseColour.Orange);
            SeedCategory(service, "Art", CheeseColour.Red);
            SeedCategory(service, "Entertainment", CheeseColour.Pink);
            SeedCategory(service, "Geography", CheeseColour.Blue);
            SeedCategory(service, "Science", CheeseColour.Green);

            return true;
        }

        private static void SeedCategory(
            Service.Service service,
            string name, 
            CheeseColour cheeseColour)
        {
            service.Category.Create(name, cheeseColour);
        }
    }
}