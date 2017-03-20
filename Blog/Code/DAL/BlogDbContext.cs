using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Code {

public partial class BlogDbContext : DbContext {

    public DbSet<Account> Account { get; set; }
    public DbSet<Post> Post { get; set; }
    public DbSet<Comment> Comment { get; set; }  
  
    public BlogDbContext() : base("BlogContext") {
        //Database.SetInitializer(new DropCreateDatabaseAlways<BlogDbContext>());
        Configuration.AutoDetectChangesEnabled = true;
        Configuration.LazyLoadingEnabled = false;		
	}

    protected override void OnModelCreating(DbModelBuilder aModelBuilder) {     
        aModelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        aModelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        //
        AddMappings(aModelBuilder);
    }
   
    public override int SaveChanges() {     
        return base.SaveChanges();
    }

}

}
