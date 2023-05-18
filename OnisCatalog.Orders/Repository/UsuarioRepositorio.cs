using Microsoft.EntityFrameworkCore;
using OnisCatalog.Orders.Models;
using OnisCatalog.Orders.Models.Dto;

namespace OnisCatalog.Orders.Repository
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        
        public bool IsUsuarioUnico(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<LoginResponseDto> Login(LoginRequestDto loginRequestDTO)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> Registrar(RegistroRequestDto registroRequestDTO)
        {
            throw new NotImplementedException();
        }
    }
}
