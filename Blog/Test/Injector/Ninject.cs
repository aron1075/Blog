using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Test {

public class NinjectResolver : IDependencyResolver {

    IKernel mKernel;

    // factory

    public NinjectResolver(Binding aBinding) {
        mKernel = new StandardKernel();
        aBinding.Add(mKernel);
    }

    // iface

    public object GetService(Type aServiceType) {
        return mKernel.TryGet(aServiceType);
    }

    public IEnumerable<object> GetServices(Type aServiceType) {
        return mKernel.GetAll(aServiceType);
    }

    public static T Resolve<T>() {
        T type = DependencyResolver.Current.GetService<T>();
        return type;
    }

}

}
