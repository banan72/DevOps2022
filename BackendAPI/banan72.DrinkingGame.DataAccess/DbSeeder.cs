namespace banan72.DrinkingGame.DataAccess
{
    public class DbSeeder
    {
        private readonly MainDBContext _ctx;
        public DbSeeder(MainDBContext ctx)
        {
            _ctx = ctx;
        }

        public void SeedDevelopment()
        {
            _ctx.Database.EnsureDeleted();
            _ctx.Database.EnsureCreated();
            _ctx.Player.Add(new PlayerEntity
            {
                name = "emil",
                isAdmin = false,
                totalSips = 4
            });
            _ctx.Player.Add(new PlayerEntity
            {
                name = "mike",
                isAdmin = false,
                totalSips = 8
            });
            _ctx.Player.Add(new PlayerEntity
            {
                name = "anna",
                isAdmin = false,
                totalSips = 1
            });
            _ctx.Player.Add(new PlayerEntity
            {
                name = "cecilie",
                isAdmin = false,
                totalSips = 6
            });
            _ctx.Player.Add(new PlayerEntity
            {
                name = "peter",
                isAdmin = true,
                totalSips = 2
            });
            _ctx.Player.Add(new PlayerEntity
            {
                name = "harald",
                isAdmin = false,
                totalSips = 200
            });


            _ctx.Rule.Add(new RuleEntity
            {
                RuleName = "Drik 2",
                Category = "basic",
            });
            
            _ctx.Rule.Add(new RuleEntity
            {
                RuleName = "Drik 5",
                Category = "basic",
            });
            _ctx.Rule.Add(new RuleEntity
            {
                RuleName = "Del 3 ud",
                Category = "basic",
            });
            _ctx.SaveChanges();
        }
    }
}