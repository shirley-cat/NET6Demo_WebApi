using NET6Demo.Interface.Dependency;
using NET6Demo.IRepository;


namespace NET6Demo.Repository
{
    public class ResultModel : IResultModel, IDependency
    {
        public int StatusCode { get; set; }

        public string? Message { get; set; } = String.Empty;

        public object? Result { get; set; } = null;
    }
}

