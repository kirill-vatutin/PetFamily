using CSharpFunctionalExtensions;
using PetFamily.Application.FileProviders;
using PetFamily.Domain.Shared;

namespace PetFamily.Application.Test.PresignedGetObject;

public class PresignedGetObjectHandler(
    IFileProvider provider)
{
    public async Task<Result<string, Error>> Handle(
        PresignedGetObjectRequest request,
        CancellationToken cancellationToken)
    {
        var result = await provider.GetFile(request.BucketName, request.ObjectName);

        return result;
    }
}
