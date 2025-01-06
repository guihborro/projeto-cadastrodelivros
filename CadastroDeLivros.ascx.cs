using System.Collections.Generic;
using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace PROJETO_CADASTRO_FINALERA_2
{
    public partial class CadastroDeLivros : System.Web.UI.UserControl
    {
        private BancoDeDados bancoDeDados = new BancoDeDados();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Livros"] == null)
                {
                    Session["Livros"] = new List<VariaveisLista>();
                }
            }
        }

        private void ShowAlertCadastro()
        {
            alertWarningCadastro.Style["display"] = "block";
        }

        protected void CadastrarLivroBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(NomeLivroTxt.Text) ||
                string.IsNullOrEmpty(GeneroLivroTxt.Text) ||
                string.IsNullOrEmpty(ddlAvaliacaoLivro.SelectedValue) ||
                string.IsNullOrEmpty(AutorLivroTxt.Text) ||
                string.IsNullOrEmpty(PaginasLivroTxt.Text) ||
                string.IsNullOrEmpty(DataLivroTxt.Text) ||
                string.IsNullOrEmpty(ddlStatusLivro.SelectedValue))
            {
                AlertMessageLabel3.Text = "Por favor, preencha todos os campos";
                ShowAlertCadastro();
                return;
            }
            if (!DateTime.TryParse(DataLivroTxt.Text, out DateTime anoPublicacaoLivro))
            {
                AlertMessageLabel3.Text = "A data de publicação deve estar em um formato válido.";
                ShowAlertCadastro();
                return;
            }
            if (int.TryParse(ddlAvaliacaoLivro.SelectedValue, out int avaliacao) && int.TryParse(PaginasLidasLivroTxt.Text, out int paginasLidas) && int.TryParse(PaginasLivroTxt.Text, out int paginas))
            {
                if (paginasLidas > paginas)
                {
                    AlertMessageLabel3.Text = "As páginas lidas não podem ser maiores que o total de páginas";
                    ShowAlertCadastro();
                    return;
                }

                // Se páginas lidas for igual a páginas totais, definir status como "Completo"
                string statusLivro = paginasLidas == paginas ? "Completo" : "Incompleto";

                VariaveisLista novoLivro = new VariaveisLista(
                    NomeLivroTxt.Text,
                    GeneroLivroTxt.Text,
                    avaliacao,
                    paginasLidas,
                    paginas,
                    statusLivro,
                    AutorLivroTxt.Text,
                    DateTime.Parse(DataLivroTxt.Text)
                );

                // Adicionar à lista em sessão
                var livros = Session["Livros"] as List<VariaveisLista>;
                livros.Add(novoLivro);
                Session["Livros"] = livros;

                // Inserir no banco de dados
                string query = "INSERT INTO Livros (NomeLivro, GeneroLivro, PaginasLivro, PaginasTotalLivro, AutorLivro, AnoPublicacaoLivro, RankingLivro, StatusLivro) VALUES (@NomeLivro, @GeneroLivro, @PaginasLivro, @PaginasTotalLivro, @AutorLivro, @AnoPublicacaoLivro, @RankingLivro, @StatusLivro)";
                var parametros = new[]
                {
                    new SqlParameter("@NomeLivro", novoLivro.NomeLivro),
                    new SqlParameter("@GeneroLivro", novoLivro.GeneroLivro),
                    new SqlParameter("@PaginasLivro", novoLivro.PaginasLivro),
                    new SqlParameter("@PaginasTotalLivro", novoLivro.PaginasTotalLivro),
                    new SqlParameter("@AutorLivro", novoLivro.AutorLivro),
                    new SqlParameter("@AnoPublicacaoLivro", novoLivro.AnoPublicacaoLivro),
                    new SqlParameter("@RankingLivro", novoLivro.RankingLivro),
                    new SqlParameter("@StatusLivro", novoLivro.StatusLivro)
                };

                bancoDeDados.Executar(query, parametros);

                // Limpar campos e exibir mensagem de sucesso
                NomeLivroTxt.Text = string.Empty;
                GeneroLivroTxt.Text = string.Empty;
                PaginasLidasLivroTxt.Text = string.Empty;
                PaginasLivroTxt.Text = string.Empty;
                AutorLivroTxt.Text = string.Empty;
                DataLivroTxt.Text = string.Empty;
                ddlAvaliacaoLivro.SelectedIndex = 0;
                ddlStatusLivro.SelectedIndex = 0;

                AlertMessageLabel3.Text = "Cadastro realizado com sucesso";
                ShowAlertCadastro();


                return;
            }
            else
            {
                AlertMessageLabel3.Text = "Páginas do livro devem ser números inteiros";
                ShowAlertCadastro();
                return;
            }
        }
    }
}
