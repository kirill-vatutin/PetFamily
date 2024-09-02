using PetFamily.Domain.Shared;

namespace PetFamily.API.Response
{
    public record Envelope
    {
        public object? Result { get; set; }
        public string? ErrorCode { get; set; }
        public string? ErrorMessage { get; set; }
        public DateTime? TimeGenerated { get; set; }

        private Envelope(object? result,Error? error)
        {
            Result = result;
            ErrorCode = error?.Code;
            ErrorMessage = error?.Message;
            TimeGenerated = DateTime.Now;
        }

        public static Envelope Ok(object? result=null) =>
            new Envelope(result, null);

        public static Envelope Error(Error error) =>
            new Envelope(null, error);



    }
}
