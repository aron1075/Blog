using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using System;
using System.IO;

namespace Code {

public class AwsService : IAwsService {

    IUnitOfWork mUnitOfWork;

    const string mBucketName = "aron1075.project";

    AmazonS3Client mClient;

    public AwsService(IUnitOfWork aUnitOfWork) {
        mUnitOfWork = aUnitOfWork;
        mClient = new AmazonS3Client("mAccessKey", "mSecretKey", RegionEndpoint.APNortheast1);
    }

    public string UploadFile(Stream aFileStream) {
        var utility = new TransferUtility(mClient);
        var request = new TransferUtilityUploadRequest();
            //request.BucketName = mBucketName;
            //request.Key = "";
            //request.InputStream = localFilePath;
            //request.FilePath = localFilePath;
            //request.CannedACL = S3CannedACL.PublicReadWrite;
        var key = Guid.NewGuid().ToString();
        var fileStream = aFileStream;
        utility.Upload(fileStream, mBucketName, key);

        return key;
    }

    public Stream GetFile(string aKey) {
        var utility = new TransferUtility(mClient);          
        var fileStream = utility.OpenStream(mBucketName, aKey);

        return fileStream;
    }

}

}

