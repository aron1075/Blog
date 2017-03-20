namespace Code {

 public class AccountService : IAccountService {

    IUnitOfWork mUnitOfWork;

    public AccountService(IUnitOfWork aUnitOfWork) {
        mUnitOfWork = aUnitOfWork;
    }

    public Account AddAccount(Account aUser) {
        var user = mUnitOfWork.Account.Add(aUser);
            mUnitOfWork.Commit();
        return user;
    }

    public Account GetAccount(string aEmail, string aPassword) {
        var account = mUnitOfWork.Account.GetAccount(aEmail, aPassword);
        return account;
    }

    public Account GetAccount(int aAccountId) {
        var account = mUnitOfWork.Account.Get(aAccountId);
        return account;
    }

}

}
