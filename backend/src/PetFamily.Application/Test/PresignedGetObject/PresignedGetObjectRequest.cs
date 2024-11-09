namespace PetFamily.Application.Test.PresignedGetObject;

public record PresignedGetObjectRequest(
    string BucketName,
    string ObjectName);

