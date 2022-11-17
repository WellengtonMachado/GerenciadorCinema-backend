using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;

namespace GerenciadorCinema.Webapi.Config.AutoMapperConfig
{
    public class UsuarioResolver : IValueResolver<object, object, Guid>
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public UsuarioResolver(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public Guid Resolve(object source, object destination,
           Guid destMember, ResolutionContext context)
        {
            var id = httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(id))
                throw new InvalidOperationException("O id do usuário não foi encontrado no token");

            return Guid.Parse(id);
        }

    }
}
