using Aula_Terca.D_ata_A_ccess_L_ayer.Base;
using Aula_Terca.Models;
using HtmlAgilityPack;

namespace Aula_Terca.D_ata_A_ccess_L_ayer
{
    public class DAL_Cursos : DAL_Base
    {
        private List<CursoViewModel> _cursos;
        private string _html = null!;

        public DAL_Cursos() : base("Adicione o link aqui")
        {
            _cursos = new();
        }

        public List<CursoViewModel> Cursos() => _cursos;

        public void Limpar_Cursos() => _cursos.Clear();

        public async Task Preparar_Cursos()
        {
            _html = await this.Pegar_Html();
            List<CursoViewModel> cursos = this.Pegar_Cursos();
            _cursos.AddRange(cursos);
        }

        public async Task Preparar_Novamente_Cursos()
        {
            this.Limpar_Cursos();
            await this.Preparar_Cursos();
        }

        public List<CursoViewModel> Pegar_Cursos()
        {
            HtmlDocument doc = new();
            doc.LoadHtml(_html);

            //Implemente o código aqui

            return new(); //Troque pelo resultado
        }

        public CursoViewModel? Pegar_Curso(string instrutor)
        {
            //Implemente o código aqui

            return new(); //Troque pelo resultado
        }
    }
}
