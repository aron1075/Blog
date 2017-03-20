namespace Code {

public interface IAccountRepository : IRepository<Account> {
       
    Account GetAccount(string aEmail, string aPassword);

}

}
