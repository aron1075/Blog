using System.IO;

namespace Code {

public interface IAwsService {

    string UploadFile(Stream aFileStream);

    Stream GetFile(string aKey);

}

}
