namespace FIFA.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(FootballersDbContext context) 
        {
            //var res1 = context.Database.EnsureDeleted();
            var res2 = context.Database.EnsureCreated();
        }
    }
}
