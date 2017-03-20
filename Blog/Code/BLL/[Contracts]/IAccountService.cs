namespace Code {

public interface IAccountService {

    Account AddAccount(Account aUser);

    Account GetAccount(string aEmail, string aPassword);

    Account GetAccount(int aAccountId);

}

}
