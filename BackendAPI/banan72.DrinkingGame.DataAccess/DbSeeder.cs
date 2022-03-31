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
            _ctx.Rule.Add(new RuleEntity
            {
                RuleName = "Pige skål",
                Category = "basic",
            });
            _ctx.Rule.Add(new RuleEntity
            {
                RuleName = "Drenge skål",
                Category = "basic",
            });
            _ctx.Rule.Add(new RuleEntity
            {
                RuleName = "Giv 3 slurk til højre",
                Category = "basic",
            });
            _ctx.Rule.Add(new RuleEntity
            {
                RuleName = "Giv 3 slurk til venstre",
                Category = "basic",
            });
            _ctx.Rule.Add(new RuleEntity
            {
                RuleName = "Take a brake",
                Category = "basic",
            });
            _ctx.Rule.Add(new RuleEntity
            {
                RuleName = "Vandfald",
                Category = "basic",
            });
            _ctx.Rule.Add(new RuleEntity
            {
                RuleName = "Fællesskål",
                Category = "basic",
            });
            _ctx.Rule.Add(new RuleEntity
            {
                RuleName = "Giv 2 slurk til alle andre",
                Category = "basic",
            });
            _ctx.Rule.Add(new RuleEntity
            {
                RuleName = "BUND en drink",
                Category = "basic",
            });
            _ctx.Rule.Add(new RuleEntity
            {
                RuleName = "Plat eller krone (plat = du drikker, krone = alle andre drikker)",
                Category = "basic",
            });
            _ctx.Rule.Add(new RuleEntity
            {
                RuleName = "Sandhed eller bund",
                Category = "Sandhed eller Konsekvens",
            });
            _ctx.Rule.Add(new RuleEntity
            {
                RuleName = "Sandhed eller shot",
                Category = "Sandhed eller Konsekvens",
            });
            _ctx.Rule.Add(new RuleEntity
            {
                RuleName = "Konsekvens eller bund",
                Category = "Sandhed eller Konsekvens",
            });
            _ctx.Rule.Add(new RuleEntity
            {
                RuleName = "Konsekvens eller shot",
                Category = "Sandhed eller Konsekvens",
            });
            _ctx.Rule.Add(new RuleEntity
            {
                RuleName = "Sandhed eller Konsekvens",
                Category = "Sandhed eller Konsekvens",
            });
            _ctx.Rule.Add(new RuleEntity
            {
                RuleName = "Læg noget op på din story eller drik 4",
                Category = "Social media",
            });
            _ctx.Rule.Add(new RuleEntity
            {
                RuleName = "Like 5 post fra din crush eller bund",
                Category = "Social media",
            });
            _ctx.Rule.Add(new RuleEntity
            {
                RuleName = "Pinligt Facebook opslag fra din sidemakker eller drik 5",
                Category = "Social media",
            });
            _ctx.Rule.Add(new RuleEntity
            {
                RuleName = "Slet en Snapchat ven eller drik 3",
                Category = "Social media",
            });




            _ctx.SaveChanges();
        }
    }
}