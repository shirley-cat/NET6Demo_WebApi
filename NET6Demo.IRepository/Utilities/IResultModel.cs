

namespace NET6Demo.IRepository
{
    public interface IResultModel
    {
        int StatusCode { get; set; }

        string? Message { get; set; }

        object? Result { get; set; }
    }
}
