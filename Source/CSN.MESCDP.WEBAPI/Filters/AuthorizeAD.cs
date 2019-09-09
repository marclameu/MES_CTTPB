using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Autofac;
using CTTPB.MESCDP.Domain.Entities;
using CTTPB.MESCDP.Domain.Interfaces.Repositories;
using CTTPB.MESCDP.Infrastructure.IOC;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;

namespace CTTPB.MESCDP.Application.WebApi.Filters
{
    public class AuthorizeADAttribute : TypeFilterAttribute
    {
        public AuthorizeADAttribute(string claimType, string claimValue) : base(typeof(ClaimRequirementFilter))
        {
            Arguments = new object[] { new Claim(claimType, claimValue) };
        }
    }

    public class ClaimRequirementFilter : IAuthorizationFilter
    {
        readonly Claim _claim;
        private IPermissaoAcessoRepository _permissaoAcessoRepository;
        private IAcaoFuncionalidadeMesRepository _acaoFuncionalidadeMesRepository;

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMemoryCache _memoryCache;
        private const int CacheDurationInMinutes = 20;


        public ClaimRequirementFilter(Claim claim, IHttpContextAccessor httpContextAccessor, IMemoryCache memoryCache)
        {
            _claim = claim;
            _httpContextAccessor = httpContextAccessor;
            _memoryCache = memoryCache;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var hasClaim = context.HttpContext.User.Claims.Any(c => c.Type == _claim.Type && c.Value == _claim.Value);
            bool permitido = false;
            var rolesMes = new List<string>();
            var wi = (WindowsIdentity)_httpContextAccessor.HttpContext.User.Identity;
            string cacheKey = $"getGrupos_{wi.Name}";

            bool permissoesEmCache = _memoryCache.TryGetValue(wi.Name, out rolesMes);

            var funcionalidade = _claim.Value.Substring(0, _claim.Value.LastIndexOf('_'));
            var acao = _claim.Value.Substring(_claim.Value.LastIndexOf('_') + 1,
                _claim.Value.Length - 1 - _claim.Value.Substring(0, _claim.Value.LastIndexOf('_')).Length);


            if (!permissoesEmCache)
            {
                _permissaoAcessoRepository = (_permissaoAcessoRepository == null)
                    ? IOC.Container.Resolve<IPermissaoAcessoRepository>()
                    : _permissaoAcessoRepository;

                IList<string> rolesADUser = new List<string>()
                {
                    "GRUPO_MANUTENCAO", "GRUPO_EVENTO", "GRUPO_PESQUISA"
                };

                //A QUERY EXECUTADA AQUI ESTÁ FUNCIONANDO CONFORME O ESPERADO
                //FAZ JOIN CORRETAMENTE.

                //ENG
                //QUERY PERFORMED HERE IS WORKING AS EXPECTED
                //MAKES JOIN CORRECTLY

                var permissoes = _permissaoAcessoRepository.FindPorGruposAd(rolesADUser);

                //N + 1 PROBLEM
                //FOR EACH LIST ITEM RETURNS TO DATABASE.
                permissoes.ToList().ForEach(p =>
                {
                    rolesMes.Add(p.AcaoFuncionalidadeMes01.NmAcao + "---" + p.AcaoFuncionalidadeMes01.NmFncaoMes);
                });
                //********************


                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(CacheDurationInMinutes));

                _memoryCache.Set(wi.Name, rolesMes, cacheEntryOptions);
            }

            permitido = usuarioPossuiAcesso(acao, funcionalidade, rolesMes);

            if (!permitido)
            {
                context.Result = new ForbidResult();
                try
                {
                    //var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                }
                catch (Exception ex)
                {
                    throw new Exception("CONVERSÃO__ERRO AO OBTER httpContext - " + ex.Message);
                }

                throw new Exception("PERMISSÃO__Usuário não possui acesso ao recurso." + _httpContextAccessor.HttpContext.User.Identity.Name);
            }

            //}
        }

        private bool usuarioPossuiAcesso(string acao, string funcionalidade, List<string> rolesMes)
        {
            var permitido = false;
            rolesMes.ForEach(role =>
            {
                if (role.Split("----")[0].ToUpper().Equals(acao.ToUpper()) &&
                    role.Split("----")[1].ToUpper().Equals(funcionalidade.ToUpper()))
                    permitido = true;
            });
            return permitido;
        }

        private IList<string> getStringNameGroups(IdentityReferenceCollection groups)
        {
            var groupsNames = new List<string>();

            groups.ToList().ForEach(g =>
            {
                var nomeArray = g.Translate(typeof(NTAccount)).ToString().Split(new char[] { '\\' });
                groupsNames.Add(nomeArray[nomeArray.Length - 1]);
            });

            return groupsNames;
        }
    }
}
