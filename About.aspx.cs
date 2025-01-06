using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PROJETO_CADASTRO_FINALERA_2
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CadastroPanel.Visible = false;
                CatalogoPanel.Visible = false;
            }
        }

        protected void AjustarVisibilidadePanelButton_Click(object sender, EventArgs e)
        {
            var tbn = sender as Button;

            if (tbn == CadastrarLivroBtn)
            {
                CadastroPanel.Visible = true;
                CatalogoPanel.Visible = false;
            }
            else if (tbn == CatalogoLivroBtn)
            {
                CadastroPanel.Visible = false;
                CatalogoPanel.Visible = true;
                AtualizarCatalogo();
            }
        }

        private void AtualizarCatalogo()
        {
            var livros = Session["Livros"] as List<VariaveisLista>;
            List<VariaveisLista> Livros = CatalogoCalc.CarregarLivrosDoBancoDeDados();
            if (livros == null || livros.Count == 0)
            {
                livros = CatalogoCalc.CarregarLivrosDoBancoDeDados();
                Session["Livros"] = livros;
            }
            
            CatalogoCalc.SetLivros(Livros);
        }
    }
}