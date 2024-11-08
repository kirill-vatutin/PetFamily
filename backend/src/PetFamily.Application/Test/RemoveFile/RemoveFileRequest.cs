namespace PetFamily.Application.Test.RemoveFile;

public record RemoveFileRequest(
    string BucketName,
    string ObjectName);
