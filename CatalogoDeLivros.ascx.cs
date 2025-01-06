using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace PROJETO_CADASTRO_FINALERA_2
{
    public partial class CatalogoDeLivros : System.Web.UI.UserControl
    {
        private BancoDeDados bancoDeDados = new BancoDeDados();

        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Repeater1_DataBinding(object sender, EventArgs e)
        {
            // Your data binding logic here (optional)
        }

        public List<VariaveisLista> CarregarLivrosDoBancoDeDados()
        {
            List<VariaveisLista> livros = new List<VariaveisLista>();

            string query = "SELECT Id, NomeLivro, GeneroLivro, RankingLivro, PaginasLivro, PaginasTotalLivro, AutorLivro, AnoPublicacaoLivro, StatusLivro FROM Livros";

            using (var reader = bancoDeDados.ExecutarLeitura(query))
            {
                while (reader.Read())
                {
                    VariaveisLista livro = new VariaveisLista
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        NomeLivro = reader["NomeLivro"].ToString(),
                        GeneroLivro = reader["GeneroLivro"].ToString(),
                        RankingLivro = Convert.ToInt32(reader["RankingLivro"]),
                        PaginasLivro = Convert.ToInt32(reader["PaginasLivro"]),
                        PaginasTotalLivro = Convert.ToInt32(reader["PaginasTotalLivro"]),
                        AutorLivro = reader["AutorLivro"].ToString(),
                        AnoPublicacaoLivro = Convert.ToDateTime(reader["AnoPublicacaoLivro"]),
                        StatusLivro = reader["StatusLivro"].ToString()
                    };

                    livros.Add(livro);
                }
            }
            return livros;
        }

        private VariaveisLista CarregarLivroDoBancoDeDados(int livroId)
        {
            VariaveisLista livro = null;

            string query = "SELECT Id, NomeLivro, GeneroLivro, PaginasLivro, PaginasTotalLivro, RankingLivro, AutorLivro, AnoPublicacaoLivro, StatusLivro FROM Livros WHERE Id = @Id";
            var parametros = new SqlParameter[]
            {
                new SqlParameter("@Id", livroId)
            };

            using (var reader = bancoDeDados.ExecutarLeitura(query, parametros))
            {
                if (reader.Read())
                {
                    livro = new VariaveisLista
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        NomeLivro = reader["NomeLivro"].ToString(),
                        GeneroLivro = reader["GeneroLivro"].ToString(),
                        RankingLivro = Convert.ToInt32(reader["RankingLivro"]),
                        PaginasLivro = Convert.ToInt32(reader["PaginasLivro"]),
                        PaginasTotalLivro = Convert.ToInt32(reader["PaginasTotalLivro"]),
                        AutorLivro = reader["AutorLivro"].ToString(),
                        AnoPublicacaoLivro = Convert.ToDateTime(reader["AnoPublicacaoLivro"]),
                        StatusLivro = reader["StatusLivro"].ToString()
                    };
                }
            }

            return livro;
        }

        private void ExcluirLivroDoBancoDeDados(int livroId)
        {
            string query = "DELETE FROM Livros WHERE Id = @Id";
            var parametros = new SqlParameter[]
            {
                new SqlParameter("@Id", livroId)
            };

            bancoDeDados.Executar(query, parametros);
            CarregarLivrosDoBancoDeDados();
        }

        private void AtualizarLivroNoBancoDeDados(VariaveisLista livro)
        {
            string query = @"UPDATE Livros 
                            SET NomeLivro = @NomeLivro, GeneroLivro = @GeneroLivro, PaginasLivro = @PaginasLivro, 
                                PaginasTotalLivro = @PaginasTotalLivro, AutorLivro = @AutorLivro, 
                                AnoPublicacaoLivro = @AnoPublicacaoLivro, RankingLivro = @RankingLivro, 
                                StatusLivro = @StatusLivro 
                            WHERE Id = @Id";

            var parametros = new SqlParameter[]
            {
                new SqlParameter("@Id", livro.Id),
                new SqlParameter("@NomeLivro", livro.NomeLivro),
                new SqlParameter("@GeneroLivro", livro.GeneroLivro),
                new SqlParameter("@PaginasLivro", livro.PaginasLivro),
                new SqlParameter("@PaginasTotalLivro", livro.PaginasTotalLivro),
                new SqlParameter("@AutorLivro", livro.AutorLivro),
                new SqlParameter("@AnoPublicacaoLivro", livro.AnoPublicacaoLivro),
                new SqlParameter("@RankingLivro", livro.RankingLivro),
                new SqlParameter("@StatusLivro", livro.StatusLivro)
            };

            bancoDeDados.Executar(query, parametros);
        }

        protected void BtnEditar_Click(object sender, EventArgs e)
        {
            int livrosSelecionados = 0;
            int livroId = 0;

            foreach (RepeaterItem item in Repeater1.Items)
            {
                CheckBox checkBox = item.FindControl("SelectCheckBox") as CheckBox;
                if (checkBox != null && checkBox.Checked)
                {
                    livrosSelecionados++;
                    HiddenField hiddenId = item.FindControl("HiddenId") as HiddenField;
                    if (hiddenId != null)
                    {
                        livroId = Convert.ToInt32(hiddenId.Value);
                    }
                }
            }

            if (livrosSelecionados == 1)
            {
                VariaveisLista livroParaEditar = CarregarLivroDoBancoDeDados(livroId);

                if (livroParaEditar != null)
                {
                    EDNomeLivroTxt.Text = livroParaEditar.NomeLivro;
                    EDGeneroLivroTxt.Text = livroParaEditar.GeneroLivro;
                    EDPaginasLivroTxt.Text = livroParaEditar.PaginasLivro.ToString();
                    EDPaginasTotalLivroTxt.Text = livroParaEditar.PaginasTotalLivro.ToString();
                    EDAutorLivroTxt.Text = livroParaEditar.AutorLivro;
                    EDDataLivroTxt.Text = livroParaEditar.AnoPublicacaoLivro.ToString("yyyy-MM-dd");
                    EDddlAvaliacaoLivro.SelectedValue = livroParaEditar.RankingLivro.ToString();
                    EDddlStatusLivro.SelectedValue = livroParaEditar.StatusLivro;
                    ViewState["EditLivroId"] = livroId;
                    editModal.Style["display"] = "block";
                }
            }
            else if (livrosSelecionados > 1)
            {
                AlertMessageLabel.Text = "Selecione apenas um livro para editar.";
                ShowAlertWarning();
            }
            else
            {
                AlertMessageLabel.Text = "Selecione pelo menos um livro para editar.";
                ShowAlertWarning();
            }
        }

        protected void BtnExcluir_Click(object sender, EventArgs e)
        {
            List<int> livrosExcluirIds = new List<int>();
            foreach (RepeaterItem item in Repeater1.Items)
            {
                CheckBox checkBox = item.FindControl("SelectCheckBox") as CheckBox;
                if (checkBox != null && checkBox.Checked)
                {
                    HiddenField hiddenId = item.FindControl("HiddenId") as HiddenField;
                    int livroId = Convert.ToInt32(hiddenId.Value);
                    livrosExcluirIds.Add(livroId);
                }
            }

            if (livrosExcluirIds.Count > 0)
            {
                foreach (int livroId in livrosExcluirIds)
                {
                    ExcluirLivroDoBancoDeDados(livroId);
                }

                List<VariaveisLista> livros = CarregarLivrosDoBancoDeDados();
                Session["Livros"] = livros;
                SetLivros(livros);
            }
            else
            {
                AlertMessageLabel.Text = "Selecione pelo menos um livro para excluir.";
                ShowAlertWarning();
            }
        }

        protected void SalvarEdicao_Click(object sender, EventArgs e)
        {
            // Verificar se algum campo está vazio
            if (string.IsNullOrWhiteSpace(EDNomeLivroTxt.Text) ||
                string.IsNullOrWhiteSpace(EDGeneroLivroTxt.Text) ||
                string.IsNullOrWhiteSpace(EDPaginasLivroTxt.Text) ||
                string.IsNullOrWhiteSpace(EDPaginasTotalLivroTxt.Text) ||
                string.IsNullOrWhiteSpace(EDAutorLivroTxt.Text) ||
                string.IsNullOrWhiteSpace(EDDataLivroTxt.Text) ||
                string.IsNullOrWhiteSpace(EDddlAvaliacaoLivro.SelectedValue) ||
                string.IsNullOrWhiteSpace(EDddlStatusLivro.SelectedValue))
            {
                AlertMessageLabel2.Text = "Todos os campos devem ser preenchidos.";
                ShowAlertWarningEdit();
                return;
            }

            // Verificar se os campos de páginas contêm valores inteiros
            if (!int.TryParse(EDPaginasLivroTxt.Text, out int paginasLivro) ||
                !int.TryParse(EDPaginasTotalLivroTxt.Text, out int paginasTotalLivro) ||
                !int.TryParse(EDddlAvaliacaoLivro.SelectedValue, out int rankingLivro))
            {
                AlertMessageLabel2.Text = "Os campos de páginas e avaliação devem conter valores inteiros.";
                ShowAlertWarningEdit();
                return;
            }

            if (!DateTime.TryParse(EDDataLivroTxt.Text, out DateTime anoPublicacaoLivro))
            {
                AlertMessageLabel2.Text = "A data de publicação deve estar em um formato válido.";
                ShowAlertWarningEdit();
                return;
            }

            int livroId = (int)ViewState["EditLivroId"];
            VariaveisLista livroAtualizado = new VariaveisLista
            {
                Id = livroId,
                NomeLivro = EDNomeLivroTxt.Text,
                GeneroLivro = EDGeneroLivroTxt.Text,
                PaginasLivro = paginasLivro,
                PaginasTotalLivro = paginasTotalLivro,
                AutorLivro = EDAutorLivroTxt.Text,
                AnoPublicacaoLivro = anoPublicacaoLivro,
                RankingLivro = rankingLivro,
                StatusLivro = paginasLivro == paginasTotalLivro ? "Completo" : "Incompleto"
            };

            AtualizarLivroNoBancoDeDados(livroAtualizado);

            List<VariaveisLista> livros = CarregarLivrosDoBancoDeDados();
            Session["Livros"] = livros;
            SetLivros(livros);

            HideEditModal();
        }

        protected void CancelarEdicao_Click(object sender, EventArgs e)
        {
            HideEditModal();
        }

        private void HideEditModal()
        {
            editModal.Style["display"] = "none";
        }

        private void ShowAlertWarning()
        {
            alertWarning.Style["display"] = "block";
        }

        private void ShowAlertWarningEdit()
        {
            alertWarningEdit.Style["display"] = "block";
        }

        public void SetLivros(List<VariaveisLista> livros)
        {
            Repeater1.DataSource = livros;
            Repeater1.DataBind();
        }

        protected void PesquisarLivro_Click(object sender, EventArgs e)
        {
            string palavraChave = PesquisarLivrosTxt.Text.Trim();

            // Monta a query SQL para buscar livros cujo nome contenha a palavra-chave
            string query = "SELECT Id, NomeLivro, GeneroLivro, RankingLivro, PaginasLivro, PaginasTotalLivro, AutorLivro, AnoPublicacaoLivro, StatusLivro " +
                           "FROM Livros WHERE NomeLivro LIKE @PalavraChave";

            // Adiciona o parâmetro com a palavra-chave
            SqlParameter[] parametros = new SqlParameter[]
            {
        new SqlParameter("@PalavraChave", "%" + palavraChave + "%")
            };

            // Executa a consulta e preenche a lista de livros
            List<VariaveisLista> livros = new List<VariaveisLista>();
            using (var reader = bancoDeDados.ExecutarLeitura(query, parametros))
            {
                while (reader.Read())
                {
                    VariaveisLista livro = new VariaveisLista
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        NomeLivro = reader["NomeLivro"].ToString(),
                        GeneroLivro = reader["GeneroLivro"].ToString(),
                        RankingLivro = Convert.ToInt32(reader["RankingLivro"]),
                        PaginasLivro = Convert.ToInt32(reader["PaginasLivro"]),
                        PaginasTotalLivro = Convert.ToInt32(reader["PaginasTotalLivro"]),
                        AutorLivro = reader["AutorLivro"].ToString(),
                        AnoPublicacaoLivro = Convert.ToDateTime (reader["AnoPublicacaoLivro"]),
                        StatusLivro = reader["StatusLivro"].ToString()
                    };
                    livros.Add(livro);
                }
            }

            // Atualiza a Repeater com os livros encontrados
            SetLivros(livros);
        }
    }
}

