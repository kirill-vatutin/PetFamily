using CSharpFunctionalExtensions;
using Microsoft.Extensions.Logging;
using Minio;
using Minio.DataModel.Args;
using PetFamily.Application.FileProviders;
using PetFamily.Domain.Shared;
using PetFamily.Infrastructure.Models;

namespace PetFamily.Infrastructure.Providers;

public class MinioProviders : IFileProvider
{
    private readonly IMinioClient _minioClient;
    private readonly ILogger<MinioProviders> _logger;

    public MinioProviders(
        IMinioClient minioClient,
        ILogger<MinioProviders> logger)
    {
        _minioClient = minioClient;
        _logger = logger;

    }

    public async Task<Result<string, Error>> GetFile(string bucketName, string objectName, CancellationToken cancellationToken = default)
    {
        try
        {
            var bucketExistArgs = new BucketExistsArgs()
               .WithBucket(bucketName);

            var bucketExist = await _minioClient.BucketExistsAsync(bucketExistArgs, cancellationToken);

            if (bucketExist is false)
            {
                return Error.Failure("get.file", $"File with bucket name:{bucketName} is not exist"); ;
            }

            var statObjectArgs = new StatObjectArgs()
                .WithBucket(bucketName)
                .WithObject(objectName);

            var fileExist = await _minioClient.StatObjectAsync(statObjectArgs, cancellationToken);

            var presignedObjectArgs = new PresignedGetObjectArgs()
                .WithBucket(bucketName)
                .WithObject(objectName)
                .WithExpiry(60 * 10);

            var url = await _minioClient.PresignedGetObjectAsync(presignedObjectArgs);

            return url;
        }
        catch (Minio.Exceptions.ObjectNotFoundException)
        {
            _logger.LogInformation("File with name:{objectName} is not exist", objectName);
            return Error.Failure("get.file", $"File with name:{objectName} is not exist");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Fail to get file in minio");
            return Error.Failure("get.file", "Fail to get file in minio");
        }
    }

    public async Task<Result<string, Error>> DeleteFile(string bucketName, string objectName, CancellationToken cancellationToken = default)
    {
        try
        {
            var bucketExistArgs = new BucketExistsArgs()
                .WithBucket(bucketName);

            var bucketExist = await _minioClient.BucketExistsAsync(bucketExistArgs, cancellationToken);

            if (bucketExist is false)
            {
                return Error.Failure("remove.file", $"File with bucket name:{bucketName} is not exist"); ;
            }

            var statObjectArgs = new StatObjectArgs()
                .WithBucket(bucketName)
                .WithObject(objectName);

            var fileExist = await _minioClient.StatObjectAsync(statObjectArgs, cancellationToken);

            var removeObjectArgs = new RemoveObjectArgs()
                .WithBucket(bucketName)
                .WithObject(objectName);

            await _minioClient.RemoveObjectAsync(removeObjectArgs);

            _logger.LogInformation("Remove file in minio with name:{objectName}", objectName);

            return objectName;
        }
        catch (Minio.Exceptions.ObjectNotFoundException ex)
        {
            _logger.LogInformation("File with name:{objectName} is not exist", objectName);
            return Error.Failure("remove.file", $"File with name:{objectName} is not exist");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Fail to remove file in minio");
            return Error.Failure("remove.file", "Fail to remove file in minio");
        }
    }

    public async Task<Result<string, Error>> UploadFile(
        FileData fileContent,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var bucketExistArgs = new BucketExistsArgs()
                        .WithBucket(fileContent.BucketName);

            var bucketExist = await _minioClient.BucketExistsAsync(bucketExistArgs, cancellationToken);

            if (bucketExist is false)
            {
                var makeBucketArgs = new MakeBucketArgs()
                .WithBucket(fileContent.BucketName);

                await _minioClient.MakeBucketAsync(makeBucketArgs, cancellationToken);
            }

            var putObjectArgs = new PutObjectArgs()
                .WithBucket(fileContent.BucketName)
                .WithStreamData(fileContent.Stream)
                .WithObjectSize(fileContent.Stream.Length)
            .WithObject(fileContent.ObjectName);

            var result = await _minioClient.PutObjectAsync(putObjectArgs, cancellationToken);

            _logger.LogInformation("Success to upload file in minio with object name:{id}", fileContent.ObjectName);

            return result.ObjectName;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Fail to upload file in minio");
            return Error.Failure("file.upload", "Fail to upload file in minio");
        }
    }
}
