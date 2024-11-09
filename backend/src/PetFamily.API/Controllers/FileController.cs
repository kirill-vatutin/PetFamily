using Microsoft.AspNetCore.Mvc;
using Minio;
using PetFamily.API.Extensions;
using PetFamily.Application.Test.AddFile;
using PetFamily.Application.Test.PresignedGetObject;
using PetFamily.Application.Test.RemoveFile;

namespace PetFamily.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FileController : ControllerBase
{
    private readonly IMinioClient _minioClient;

    private const string PHOTOS_BUCKET_NAME = "photos";

    public FileController(IMinioClient minioClient)
    {
        _minioClient = minioClient;
    }

    [HttpGet("name:{objectName}")]
    public async Task<ActionResult> Get(
        [FromRoute] string objectName,
        [FromServices] PresignedGetObjectHandler handler,
        CancellationToken cancellationToken)
    {
        var request = new PresignedGetObjectRequest(PHOTOS_BUCKET_NAME, objectName);

        var result = await handler.Handle(request, cancellationToken);

        if (result.IsFailure)
            return result.Error.ToResponse();

        return Ok(result.Value);

    }

    [HttpPost]
    public async Task<ActionResult> Create(
        IFormFile file,
        [FromServices] AddFileHandler handler,
        CancellationToken cancellationToken = default
        )
    {
        var path = Guid.NewGuid().ToString();

        await using var stream = file.OpenReadStream();

        var request = new AddFileRequest(stream, PHOTOS_BUCKET_NAME, path);

        var result = await handler.Handler(request);

        if (result.IsFailure)
            return result.Error.ToResponse();

        return Ok(result.Value);
    }

    [HttpDelete("name:{objectName}")]
    public async Task<ActionResult> DeleteByName(
        [FromRoute] string objectName,
        [FromServices] RemoveFileHandler handler,
        CancellationToken cancellationToken = default)
    {
        var request = new RemoveFileRequest(PHOTOS_BUCKET_NAME, objectName);

        var result = await handler.Handle(request, cancellationToken);

        if (result.IsFailure)
            return result.Error.ToResponse();

        return Ok(result.Value);
    }
}
