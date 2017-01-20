namespace LinqProject.Migrations
{
    using System.Data.Entity.Migrations;
    using Utils;

    internal sealed class Configuration : DbMigrationsConfiguration<LinqProject.Database.PersonDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(LinqProject.Database.PersonDb context)
        {
            IGenarator generator = new DataGenerator();
            context.Persons.AddRange(generator.CreatePersonsWithRandomStrings(150));

        }
    }
}
