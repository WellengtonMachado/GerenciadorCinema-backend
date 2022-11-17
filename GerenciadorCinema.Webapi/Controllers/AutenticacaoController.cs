using AutoMapper;
using GerenciadorCimena.Dominio.ModuloAutenticacao;
using GerenciadorCinema.Servico.ModuloAutenticacao;
using GerenciadorCinema.Webapi.Controllers.Compartilhado;
using GerenciadorCinema.Webapi.ViewModels.ModuloAutenticacao;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorCinema.Webapi.Controllers
{
    [Route("api/conta")]
    [ApiController]
    public class AutenticacaoController : GerenciadorCinemaControllerBase
    {
        private readonly ServicoAutenticacao servicoAutenticacao;
        private readonly IMapper mapeadorUsuario;

        public AutenticacaoController(ServicoAutenticacao servicoAutenticacao, IMapper mapeadorUsuario)
        {
            this.servicoAutenticacao = servicoAutenticacao;
            this.mapeadorUsuario = mapeadorUsuario;
        }

        [HttpPost("registrar")]
        public async Task<ActionResult> RegistrarUsuario(RegistrarUsuarioViewModel usuarioVM)
        {
            var usuario = mapeadorUsuario.Map<Usuario>(usuarioVM);

            var usuarioResult = await servicoAutenticacao.RegistrarUsuario(usuario, usuarioVM.Senha);

            if (usuarioResult.IsFailed)
                return InternalError(usuarioResult);

            return Ok(new
            {
                sucesso = true,
                dados = GerarJwt(usuarioResult.Value)
            });
        }


        [HttpPost("autenticar")]
        public async Task<ActionResult> AutenticarUsuario(AutenticarUsuarioViewModel usuarioVM)
        {
            var usuarioResult = await servicoAutenticacao.AutenticarUsuario(usuarioVM.Email, usuarioVM.Senha);

            if (usuarioResult.IsFailed)
                return BadRequest(usuarioResult);

            return Ok(new
            {
                sucesso = true,
                dados = GerarJwt(usuarioResult.Value)
            });
        }

        [HttpPost("sair")]
        public async Task<ActionResult> Sair()
        {
            await servicoAutenticacao.Sair(UsuarioLogado.Email);

            return Ok(new
            {
                sucesso = true,
                dados = $"Sessão do usuário {UsuarioLogado.Email} removida com sucesso"
            });
        }

        private TokenViewModel GerarJwt(Usuario usuario)
        {
            var identityClaims = new ClaimsIdentity();

            identityClaims.AddClaim(new Claim(JwtRegisteredClaimNames.Sub, usuario.Id.ToString()));
            identityClaims.AddClaim(new Claim(JwtRegisteredClaimNames.Email, usuario.Email));
            identityClaims.AddClaim(new Claim(JwtRegisteredClaimNames.GivenName, usuario.Nome));

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("SegredoGerenciadorCinema");
            DateTime dataExpiracao = DateTime.UtcNow.AddHours(8);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = "GerenciadorCinema",
                Audience = "http://localhost",
                Subject = identityClaims,
                Expires = dataExpiracao,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            var encodedToken = tokenHandler.WriteToken(token);

            var response = new TokenViewModel
            {
                Chave = encodedToken,
                DataExpiracacao = dataExpiracao,
                UsuarioToken = new UsuarioTokenViewModel
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    Email = usuario.Email
                }
            };

            return response;
        }

    }
}
