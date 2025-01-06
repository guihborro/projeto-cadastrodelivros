    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    namespace PROJETO_CADASTRO_FINALERA_2
    {
        public class VariaveisLista
        {
            public int Id { get; set; }
            public string NomeLivro { get; set; }
            public string GeneroLivro { get; set; }
            public int RankingLivro { get; set; }
            public int PaginasLivro { get; set; }
            public int PaginasTotalLivro { get; set; }
            public string StatusLivro { get; set; }
            public string AutorLivro { get; set; }
            public DateTime AnoPublicacaoLivro { get; set; }
            public VariaveisLista() { }
            public VariaveisLista(string nomeLivro, string generoLivro, int rankingLivro, int paginaLivro, int paginaTotalLivro, string statusLivro, string autorLivro, DateTime anoPublicacaoLivro)
            {
                NomeLivro = nomeLivro;
                GeneroLivro = generoLivro;
                RankingLivro = rankingLivro;
                PaginasLivro = paginaLivro;
                PaginasTotalLivro = paginaTotalLivro;
                StatusLivro = statusLivro;
                AutorLivro = autorLivro;
                AnoPublicacaoLivro = anoPublicacaoLivro;
            }
        }
    }