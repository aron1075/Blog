using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Code {

public class Repository<T> : IRepository<T> where T : class {

    protected BlogDbContext mContext;
    protected DbSet<T> mEntity;
    
    public Repository(BlogDbContext aContext) {
        mContext = aContext;
        mEntity = aContext.Set<T>();
    }

    //

    public T Add(T aEntity) {
        T entity = mEntity.Add(aEntity);   
        return entity;
    }

    public void Update(T aEntity) {    
        var state = mContext.Entry(aEntity).State;
        if (state == EntityState.Detached) state = EntityState.Modified;
    }

    public T Delete(T aEntity) {
        var entity = mEntity.Remove(aEntity);
        return entity;
    }

    public int Count { get {
        return mEntity.Count();
    } }

    public int Commit() {
        var recordCount = mContext.SaveChanges();
        return recordCount;
    }

    //

    public List<T> Get() {
        return mEntity.ToList();
    }

    public T Get(int aId) {
        return mEntity.Find(aId);
    }
   
}

}
