using Code;
using Ninject;

namespace Blog {

public class Binding {

    public void Add(IKernel aKernel) {
        //-------------------------------------------------| DAL
        aKernel.Bind(typeof(IRepository<>)).To(typeof(Repository<>));
        aKernel.Bind<IAccountRepository>().To<UserRepository>();
        aKernel.Bind<IUnitOfWork>().To<UnitOfWork>();

        aKernel.Bind<BlogDbContext>().ToSelf();
        //-------------------------------------------------| BLL  		
        aKernel.Bind<IAccountService>().To<AccountService>();
        aKernel.Bind<IPostService>().To<PostService>();
        aKernel.Bind<IAwsService>().To<AwsService>();
    }

}

}