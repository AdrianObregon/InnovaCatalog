using InnovaCatalog.Models;
using InnovaCatalog.Models.Dto;

namespace InnovaCatalog.Repository
{
    public interface IUsuarioRepositorio
    {
        bool IsUsuarioUnico(string userName);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<Usuario> Registrar(RegistroRequestDTO registroRequestDTO);

    }
}
