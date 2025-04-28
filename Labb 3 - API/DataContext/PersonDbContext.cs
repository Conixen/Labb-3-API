namespace Labb_3___API.DataContext
{
    public class PersonDbContext : DbContext
    {
        public BdSet<Person> Persons { get; set; }
        public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<Person>().HasKey(p => p.Id);
            modelBuilder.Entity<Person>().Property(p => p.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Person>().Property(p => p.Age).IsRequired();
        }
    }
    
  
}
