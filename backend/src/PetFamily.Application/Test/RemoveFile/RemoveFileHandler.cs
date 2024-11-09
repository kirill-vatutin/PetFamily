using CSharpFunctionalExtensions;
using PetFamily.Application.FileProviders;
using PetFamily.Domain.Shared;

namespace PetFamily.Application.Test.RemoveFile;

public class RemoveFileHandler(
    IFileProvider provider)
{
    public async Task<Result<string, Error>> Handle(
        RemoveFileRequest request,
        CancellationToken cancellationToken = default)
    {
        var result = await provider.DeleteFile(request.BucketName, request.ObjectName, cancellationToken);

        return result;
    }
}
