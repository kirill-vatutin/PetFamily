namespace PetFamily.Application.Test.AddFile;

public record AddFileRequest(
     Stream Stream,
     string BucketName,
     string ObjectName
    );