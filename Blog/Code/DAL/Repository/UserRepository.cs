using System.Linq;

namespace Code {

public class UserRepository : Repository<Account>, IAccountRepository {

    public UserRepository(BlogDbContext aContext) : base(aContext) {
        // void
    }

    public Account GetAccount(string aEmail, string aPassword) {
        var account = mEntity.FirstOrDefault(e => e.Email == aEmail && e.Password == aPassword);
        return account;
    }

}

}
