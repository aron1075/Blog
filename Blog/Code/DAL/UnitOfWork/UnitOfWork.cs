using System;

namespace Code {

public class UnitOfWork : IUnitOfWork, IDisposable {

    BlogDbContext mContext;

    public IAccountRepository Account { get; set; }
    public IPostRepository Post { get; set; }
    public IRepository<Comment> Comment { get; set; }
    
    public UnitOfWork(BlogDbContext aDbContext) {
        mContext = aDbContext;
        //
        Account = new UserRepository(mContext);
        Post = new PostRepository(mContext);
        Comment = new Repository<Comment>(mContext);
    }

    public void Commit() {
        mContext.SaveChanges();
    }

    protected virtual void Dispose(bool aDisposing) {
        if (aDisposing) mContext.Dispose();     
    }

    public void Dispose() {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

}

}
