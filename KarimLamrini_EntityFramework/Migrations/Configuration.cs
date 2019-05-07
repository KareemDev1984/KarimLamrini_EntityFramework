namespace KarimLamrini_EntityFramework.Migrations
{
    using KarimLamrini_EntityFramework.Data;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<KarimLamrini_EntityFramework.SchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(KarimLamrini_EntityFramework.SchoolContext context)
        {
            DummyData.AddData(context);
        }
    }
}
