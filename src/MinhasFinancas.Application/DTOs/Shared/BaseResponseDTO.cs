namespace MinhasFinancas.Application.DTOs.Shared
{
    public abstract class BaseResponseDTO
    {
        public bool Success { get; private set; }
        public List<string> Errors { get; private set; }

        public BaseResponseDTO() =>
            Errors = new List<string>();

        public BaseResponseDTO(bool success = true) : this() =>
            Success = success;

        public void AdicionarErro(string erro) =>
            Errors.Add(erro);

        public void AdicionarErros(IEnumerable<string> erros) =>
            Errors.AddRange(erros);
    }
}
