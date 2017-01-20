using System.Data.Entity;

namespace LinqProject.Database
{
    public class PersonDb : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public PersonDb() : base("DefaultConnection")
        {

        }

    }
}
