using CSharpFunctionalExtensions;
using PetFamily.Application.FileProviders;
using PetFamily.Domain.Shared;
using PetFamily.Infrastructure.Models;

namespace PetFamily.Application.Test.AddFile;

public class AddFileHandler(
    IFileProvider provider)
{
    public async Task<Result<string, Error>> Handler(
        AddFileRequest request,
        CancellationToken cancellationToken = default)
    {
        var fileData = new FileData(
            request.Stream,
            request.BucketName,
            request.ObjectName);

        var result = await provider.UploadFile(fileData, cancellationToken);

        return result;
    }
}
