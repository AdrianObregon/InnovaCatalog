using OnisCatalog.Orders.Models;
using OnisCatalog.Orders.Models.Dto;

namespace OnisCatalog.Orders.Repository
{
    public interface IUsuarioRepositorio
    {
        bool IsUsuarioUnico(string userName);
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDTO);
        Task<Usuario> Registrar(RegistroRequestDto registroRequestDTO);
    }
}
