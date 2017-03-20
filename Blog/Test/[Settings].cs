using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test {

[TestClass]
public class Settings {

    [AssemblyInitialize]
    public static void Init(TestContext aTestContext) {
        DependencyConfig.RegisterDependency(new Binding());
    }

}

}
