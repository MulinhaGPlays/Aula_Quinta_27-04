using Aula_Terca.D_ata_A_ccess_L_ayer.Base;
using Aula_Terca.Models;
using HtmlAgilityPack;

namespace Aula_Terca.D_ata_A_ccess_L_ayer
{
    public class DAL_Cursos : DAL_Base
    {
        private List<CursoViewModel> _cursos;
        private string _html = null!;

        public DAL_Cursos() : base("https://www.udemy.com/pt/")
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
            var nodes = doc.DocumentNode.SelectNodes("//*[@class='course-card--container--1QM2W course-card--medium--Fdbz0']").ToList();
            List<CursoViewModel> cursos = nodes.Select(x =>
            {
                var document = new HtmlDocument();
                document.LoadHtml(x.InnerHtml);

                var nodeTitulo = document.DocumentNode.SelectSingleNode("//*[@class='ud-heading-md course-card--course-title--vVEjC']").SelectSingleNode("//a");
                string título = String.Concat(nodeTitulo.ChildNodes.Where(n => n.NodeType == HtmlNodeType.Text).Select(n => n.InnerHtml.Trim()));
                var descrição = document.DocumentNode.SelectSingleNode("//*[@class='ud-sr-only']").SelectNodes("//span").First().InnerText;
                var instrutor = document.DocumentNode.SelectSingleNode("//*[@class='course-card--instructor-list--nH1OC']").InnerText;

                var curso = new CursoViewModel
                {
                    Título = título,
                    Instrutor = instrutor,
                    Descrição = descrição,
                };
                return curso;
            }).ToList();

            return cursos; 
        }

        public CursoViewModel? Pegar_Curso(string instrutor) => _cursos.FirstOrDefault(x => x.Instrutor.Contains(instrutor, StringComparison.InvariantCultureIgnoreCase));
    }
}
