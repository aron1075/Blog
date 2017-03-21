using System.Data.Entity;

namespace Code {

public partial class BlogDbContext {

    void AddMappings(DbModelBuilder aModel) {
        #region Account

        aModel.Entity<Account>()
            .ToTable("Account", "dbo")
            .HasKey(e => e.AccountId);

        aModel.Entity<Account>().Property(e => e.Email).HasMaxLength(50).IsRequired();
        aModel.Entity<Account>().Property(e => e.Password).HasMaxLength(10).IsRequired();

        #endregion

        #region Post

        aModel.Entity<Post>()
            .ToTable("Post", "dbo")
            .HasKey(e => e.PostId);

        aModel.Entity<Post>().Property(e => e.Title).HasMaxLength(50).IsRequired();
        aModel.Entity<Post>().Property(e => e.Content).IsRequired();
        aModel.Entity<Post>().Property(e => e.FileKey).HasMaxLength(50);

        #endregion

        #region Comment

        aModel.Entity<Comment>()
            .ToTable("Comment", "dbo")
            .HasKey(e => e.CommentId);

        aModel.Entity<Comment>().Property(e => e.Content).HasMaxLength(1000).IsRequired();

        #endregion
    }

}

} // namespace
