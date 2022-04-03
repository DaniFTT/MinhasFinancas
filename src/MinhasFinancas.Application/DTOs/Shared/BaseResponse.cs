using System.Text.Json.Serialization;

namespace MinhasFinancas.Application.DTOs.Shared
{
    public abstract class BaseResponse
    {
        public bool Success { get; private set; }
        public string? Message { get; private set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public List<string> Errors { get; private set; }

        public BaseResponse() =>
            Errors = new List<string>();

        public BaseResponse(bool success = true) : this() =>
            Success = success;

        public BaseResponse(string message, bool success = true) : this()
        {
            Success = success;
            Message = message;
        }

        public void AdicionarErro(string erro) =>
            Errors.Add(erro);

        public void AdicionarErros(IEnumerable<string> erros) =>
            Errors.AddRange(erros);

        public bool IsInvalidResponse() => Errors.Any() || (!Success && !string.IsNullOrEmpty(Message));     
    }
}
