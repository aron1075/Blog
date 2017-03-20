using System.Collections.Generic;

namespace Code {

public interface IRepository<T> where T : class {

    int Count { get; }
    List<T> Get();
    T Get(int aId);
    T Add(T aEntity);
    void Update(T aEntity);
    T Delete(T aEntity);
    int Commit();

}

}
