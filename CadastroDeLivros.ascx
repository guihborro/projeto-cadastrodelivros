<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CadastroDeLivros.ascx.cs" Inherits="PROJETO_CADASTRO_FINALERA_2.CadastroDeLivros" %>

<style>
    .btn-yellow {
        background-color: black;
        border-color: black;
        color: yellow;
        padding: 13px 26px;
        font-size: 18px;
        border-radius: 4px;
        font-family: fantasy;
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
    function checkStatus() {
        var paginasLidas = document.getElementById('<%= PaginasLidasLivroTxt.ClientID %>').value;
        var paginasTotais = document.getElementById('<%= PaginasLivroTxt.ClientID %>').value;
        var ddlStatusLivro = document.getElementById('<%= ddlStatusLivro.ClientID %>');

        if (paginasLidas == paginasTotais) {
            ddlStatusLivro.value = "Completo";
            ddlStatusLivro.disabled = true;
        } else {
            ddlStatusLivro.value = "Incompleto";
            ddlStatusLivro.disabled = true;
        }
    }
</script>

<div style="text-align: center; margin-top: 20px;">
    <div class="form-group">
        <label for="NomeLivroTxt">Nome do Livro:</label>
        <asp:TextBox runat="server" ID="NomeLivroTxt" placeholder="Nome do Livro" />
    </div>
    <div class="form-group">
        <label for="GeneroLivroTxt">Gênero do Livro:</label>
        <asp:TextBox runat="server" ID="GeneroLivroTxt" placeholder="Gênero do Livro" />
    </div>

    <br />
    <br />

    <div class="form-group">
        <label for="PaginasLivroTxt">Páginas:</label>
        <div style="display: flex">
            <asp:TextBox runat="server" ID="PaginasLidasLivroTxt" placeholder="Lidas" Style="width: 75px" onkeyup="checkStatus()" />
            <asp:TextBox runat="server" ID="PaginasLivroTxt" placeholder="Totais" Style="width: 75px" onkeyup="checkStatus()" />
        </div>
    </div>
    <div class="form-group">
        <label for="AutorLivroTxt">Autor do Livro:</label>
        <asp:TextBox runat="server" ID="AutorLivroTxt" placeholder="Autor do Livro" />
    </div>

    <br />
    <br />

    <div class="form-group">
        <label for="DataLivroTxt">Data de Lançamento:</label>
        <asp:TextBox ID="DataLivroTxt" runat="server" CssClass="form-control" placeholder="Selecione a data" type="date"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="ddlAvaliacaoLivro">Avaliação do Livro:</label>
        <asp:DropDownList runat="server" ID="ddlAvaliacaoLivro">
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
        <label for="ddlStatusLivro">Status do Livro:</label>
        <asp:DropDownList runat="server" ID="ddlStatusLivro">
            <asp:ListItem Text="Incompleto" Value="Incompleto" />
            <asp:ListItem Text="Completo" Value="Completo" />
        </asp:DropDownList>
    </div>

    <br />
    <br />

    <asp:Button runat="server" ID="CadastrarLivroBtn" Text="Cadastrar Livro" CssClass="btn btn-yellow" OnClick="CadastrarLivroBtn_Click" /><br />
    <br />
    <br />

    <div id="alertWarningCadastro" runat="server" class="alert alert-warning alert-dismissible fade show" role="alert" style="display: none;">
        <strong>Atenção!</strong>
        <asp:Label ID="AlertMessageLabel3" runat="server" Text=""></asp:Label>
        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
    </div>
</div>
