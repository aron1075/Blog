using System.Web.Mvc;

namespace Blog {

public class DependencyConfig {

    public static void RegisterDependency(Binding aBinding) {
        DependencyResolver.SetResolver(new NinjectResolver(aBinding));
    }

}

}