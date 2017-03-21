using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using System;
using System.IO;
using System.Web;

namespace Code {

public class AwsService : IAwsService {

    IUnitOfWork mUnitOfWork;

    const string mBucketName = "aron1075.project";

    AmazonS3Client mClient;

    public AwsService(IUnitOfWork aUnitOfWork) {
        mUnitOfWork = aUnitOfWork;
        mClient = new AmazonS3Client("AKIAIH4QAJZY2VMOJJ2Q", "sj2e4mp+RTQ20Ds3MCYckCbJ5sjikc7cA1KEK5rh", RegionEndpoint.USEast1);
    }

    public string UploadFile(HttpPostedFileBase aFile) {
        var utility = new TransferUtility(mClient);
        var request = new TransferUtilityUploadRequest();
        request.CannedACL = S3CannedACL.PublicRead;
        request.FilePath = aFile.FileName;
        var key = Guid.NewGuid().ToString();
        var fileStream = aFile.InputStream;
        utility.Upload(fileStream, mBucketName, key);

        return key;
    }

}

}

