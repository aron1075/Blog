using Microsoft.VisualStudio.TestTools.UnitTesting;
using Code;
using System.IO;

namespace Test {

[TestClass]
public class TestAwsService {

    IAwsService mAwsService;
    string mKey;

    public TestAwsService(IAwsService aAwsService) {
        mAwsService = aAwsService;
    }     

    [TestMethod]
    public void TestUpload() {
        var file = File.OpenRead(@"C:\Project\Blog\Website\App_Data\image.jpg");
        mKey = mAwsService.UploadFile(file);
    }

    [TestMethod]
    public void TestDownload() {
        var file = mAwsService.GetFile(mKey);
    }
}

}
