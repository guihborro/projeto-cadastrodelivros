<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CatalogoDeLivros.ascx.cs" Inherits="PROJETO_CADASTRO_FINALERA_2.CatalogoDeLivros" %>

<style>
    .Img-btn {
        height: 34px;
        margin: 5px;
        border: 4px solid;
        border-radius: 4px;
        background-color: black;
    }

    .button-container {
        display: inline-flex;
        align-items: center;
    }

    .search-container {
        display: inline-flex;
        align-items: center;
    }

    .input-align {
        padding: 10px 20px;
        font-size: 14px;
    }

    .btn-yellow {
        background-color: black;
        border-color: black;
        color: yellow;
        padding: 13px 26px;
        font-size: 18px;
        border-radius: 4px;
    }

    .btn-yellow2 {
        background-color: black;
        border-color: black;
        color: yellow;
        padding: 10px 14px;
        font-size: 14px;
        border-radius: 4px;
    }

    .form-group {
        display: inline-block;
        margin-right: 20px;
    }

        .form-group label {
            display: block;
        }

        .form-group input[type=text],
        .form-group select {
            width: 150px;
        }
</style>
<script type="text/javascript">
    function checkStatusEdit() {
        var paginasLidas = document.getElementById('<%= EDPaginasLivroTxt.ClientID %>').value;
        var paginasTotais = document.getElementById('<%= EDPaginasTotalLivroTxt.ClientID %>').value;
        var ddlStatusLivro = document.getElementById('<%= EDddlStatusLivro.ClientID %>');

        if (paginasLidas === paginasTotais) {
            ddlStatusLivro.value = "Completo";
            ddlStatusLivro.disabled = true;
        } else {
            ddlStatusLivro.value = "Incompleto";
            ddlStatusLivro.disabled = true;
        }
    }
</script>


<h2>Catálogo de Livros</h2>

<div>
    <asp:Repeater ID="Repeater1" runat="server" OnDataBinding="Repeater1_DataBinding">
        <HeaderTemplate>
            <table class="table table-bordered border-secondary" word-break="keep-all">
                <thead>
                    <tr class="table-active">
                        <th></th>
                        <th>Nome do Livro</th>
                        <th>Gênero</th>
                        <th>Páginas Lidas</th>
                        <th>Páginas Totais</th>
                        <th>Autor</th>
                        <th>Data de Publicação</th>
                        <th>Avaliação</th>
                        <th>Status</th>
                    </tr>
                </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <asp:CheckBox ID="SelectCheckBox" runat="server" />
                    <asp:HiddenField ID="HiddenId" runat="server" Value='<%# Eval("Id") %>' />
                </td>
                <td><%# Eval("NomeLivro") %></td>
                <td><%# Eval("GeneroLivro") %></td>
                <td><%# Eval("PaginasLivro") %></td>
                <td><%# Eval("PaginasTotalLivro") %></td>
                <td><%# Eval("AutorLivro") %></td>
                <td><%# Eval("AnoPublicacaoLivro", "{0:dd/MM/yyyy}") %></td>
                <td><%# Eval("RankingLivro") %></td>
                <td><%# Eval("StatusLivro") %></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </tbody>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <div style="display: inline-flex">
        <div class="search-container">
            <asp:ImageButton ID="BtnEditar" runat="server" ImageUrl="/Imagens/editar.png" CssClass="Img-btn" OnClick="BtnEditar_Click" />
            <asp:ImageButton ID="BtnExcluir" runat="server" ImageUrl="/Imagens/lixo.png" CssClass="Img-btn" OnClick="BtnExcluir_Click" />
        </div>
        <div class="button-container">
            <asp:ImageButton ID="PesquisarLivros" runat="server" CssClass="Img-btn" ImageUrl="/Imagens/lupa.png" OnClick="PesquisarLivro_Click" />
            <asp:TextBox runat="server" ID="PesquisarLivrosTxt" placeholder="KeyWord" CssClass="input-align" Style="width: 100px" />
        </div>
    </div>

    <br />
    <br />

    <div id="alertWarning" runat="server" class="alert alert-warning alert-dismissible fade show" role="alert" style="display: none;">
        <strong>Atenção!</strong>
        <asp:Label ID="AlertMessageLabel" runat="server" Text=""></asp:Label>
        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
    </div>

    <div id="editModal" runat="server" class="modal" tabindex="-1" >
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Editar Livro</h5>
                </div>
                <div class="modal-body" style="text-align: center; margin-top: 20px;">
                    <div class="form-group">
                        <label for="EDNomeLivroTxt">Nome do Livro:</label>
                        <asp:TextBox ID="EDNomeLivroTxt" runat="server" placeholder="Nome do Livro" />
                    </div>
                    <div class="form-group">
                        <label for="EDGeneroLivroTxt">Gênero do Livro:</label>
                        <asp:TextBox ID="EDGeneroLivroTxt" runat="server" placeholder="Gênero do Livro" />
                    </div>

                    <br />
                    <br />

                    <div class="form-group">
                        <label for="EDPaginasLivroTxt">Páginas:</label>
                        <div style="display: flex">
                            <asp:TextBox ID="EDPaginasLivroTxt" runat="server" placeholder="Lidas" Style="width: 75px" onkeyup="checkStatusEdit()" />
                            <asp:TextBox ID="EDPaginasTotalLivroTxt" runat="server" placeholder="Totais" Style="width: 75px" onkeyup="checkStatusEdit()" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="EDAutorLivroTxt">Autor do Livro:</label>
                        <asp:TextBox ID="EDAutorLivroTxt" runat="server" placeholder="Autor do Livro" />
                    </div>

                    <br />
                    <br />

                    <div class="form-group">
                        <label for="EDDataLivroTxt">Data do Livro:</label>
                        <asp:TextBox ID="EDDataLivroTxt" runat="server" CssClass="form-control" placeholder="Selecione a data" type="date" />
                    </div>
                    <div class="form-group">
                        <label for="EDddlAvaliacaoLivro">Avaliação do Livro:</label>
                        <asp:DropDownList ID="EDddlAvaliacaoLivro" runat="server">
                            <asp:ListItem Text="1" Value="1" />
                            <asp:ListItem Text="2" Value="2" />
                            <asp:ListItem Text="3" Value="3" />
                            <asp:ListItem Text="4" Value="4" />
                            <asp:ListItem Text="5" Value="5" />
                            <asp:ListItem Text="6" Value="6" />
                            <asp:ListItem Text="7" Value="7" />
                            <asp:ListItem Text="8" Value="8" />
                            <asp:ListItem Text="9" Value="9" />
                            <asp:ListItem Text="10" Value="10" />
                        </asp:DropDownList>
                    </div>

                    <br />
                    <br />

                    <div class="form-group">
                        <label for="EDddlStatusLivro">Status do Livro:</label>
                        <asp:DropDownList ID="EDddlStatusLivro" runat="server">
                            <asp:ListItem Text="Incompleto" Value="Incompleto" />
                            <asp:ListItem Text="Completo" Value="Completo" />
                        </asp:DropDownList>
                    </div>

                </div>
                <div class="modal-footer">
                    <asp:Button ID="SalvarEdicao" runat="server" Text="Salvar" CssClass="btn btn-yellow" OnClick="SalvarEdicao_Click" />
                    <asp:Button ID="CancelarEdicao" runat="server" Text="Cancelar" CssClass="btn btn-yellow" OnClick="CancelarEdicao_Click" />
                    <br />
                    <div id="alertWarningEdit" runat="server" class="alert alert-warning alert-dismissible fade show" role="alert" style="display: none;">
                        <strong>Atenção!</strong>
                        <asp:Label ID="AlertMessageLabel2" runat="server" Text=""></asp:Label>
                        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                    </div>
                </div>
            </div>
        </div>
    </div>

</div>
