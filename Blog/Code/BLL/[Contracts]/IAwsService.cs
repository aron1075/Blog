using System.IO;
using System.Web;

namespace Code {

public interface IAwsService {

    string UploadFile(HttpPostedFileBase aFile);

}

}
