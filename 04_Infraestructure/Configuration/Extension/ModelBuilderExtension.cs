using Infraestructure.Configuration.Sedd;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Configuration.Extension
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            DirectDistanceDialingSeed.Seed(modelBuilder);
        }
    }
}
