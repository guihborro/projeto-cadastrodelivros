<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="PROJETO_CADASTRO_FINALERA_2.About" %>

<%@ Register TagPrefix="calc" TagName="CadastroTag" Src="/CadastroDeLivros.ascx" %>
<%@ Register TagPrefix="calc" TagName="CatalogoTag" Src="/CatalogoDeLivros.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">    
    <style>
        body {
            background-color: #ccc;
        }

        .btn-grande {
            width: 200px;
            height: 60px;
            font-size: 18px;
            background-color: black;
            color: yellow;
            border: none;
            margin-top: 20px;
        }

        .btn-container {
            text-align: center;
        }
    </style>

    <main aria-labelledby="title">
        <div class="btn-container">
            <asp:Button runat="server" ID="CadastrarLivroBtn" Text="Cadastro" OnClick="AjustarVisibilidadePanelButton_Click" CssClass="btn-grande" />
            <asp:Button runat="server" ID="CatalogoLivroBtn" Text="Catálogo" OnClick="AjustarVisibilidadePanelButton_Click" CssClass="btn-grande" />
        </div>

        <asp:Panel runat="server" ID="CadastroPanel" Visible="false">
            <calc:CadastroTag ID="CadastroCalc" runat="server" />
        </asp:Panel>

        <asp:Panel runat="server" ID="CatalogoPanel" Visible="false">
            <calc:CatalogoTag ID="CatalogoCalc" runat="server" />
        </asp:Panel>
    </main>
</asp:Content>
