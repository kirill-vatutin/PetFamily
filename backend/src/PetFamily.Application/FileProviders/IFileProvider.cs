
using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;
using PetFamily.Infrastructure.Models;

namespace PetFamily.Application.FileProviders;

public interface IFileProvider
{
    public Task<Result<string, Error>> UploadFile(
       FileData fileContent,
       CancellationToken cancellationToken = default);

    public Task<Result<string,Error>> DeleteFile(
        string bucketName,
        string objectName,
        CancellationToken cancellationToken = default);
    Task<Result<string, Error>> GetFile(string bucketName, string objectName, CancellationToken cancellationToken = default);
}
