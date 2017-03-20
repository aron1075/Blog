namespace Code {

public interface IUnitOfWork {

    IAccountRepository Account { get; set; }
    IPostRepository Post { get; set; }
    IRepository<Comment> Comment { get; set; }
    void Commit();
 
}

}
