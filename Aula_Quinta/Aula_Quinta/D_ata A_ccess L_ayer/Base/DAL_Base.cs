using Aula_Quinta.Services;

namespace Aula_Quinta.D_ata_A_ccess_L_ayer.Base
{
    public class DAL_Base
    {
        private readonly string _link;
        public DAL_Base(string link) => _link = link;
        protected async Task<string> Pegar_Html() => await HttpRequestService.ConfiguringHttp(_link).Pegar_Html();
    }
}
