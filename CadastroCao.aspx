<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastroCao.aspx.cs" Inherits="Dog_and_People.CadastroCao" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Cadastrar Cão</h1>
        <asp:Label ID="lblMensagem" runat="server" Text="" Visible="false" Font-Bold="True" ForeColor="#CC0000"></asp:Label>
    </div>
    <div class="container body-content">   
        <p>
            Raça do Cão:        
            <asp:TextBox ID="txtRaca" runat="server" Width="500px"></asp:TextBox>
        </p>
        <p>
            Nome do Cão:        
            <asp:TextBox ID="txtCao" runat="server" Width="500px"></asp:TextBox>
        </p>
         <p>
            Nome do Dono:        
            <asp:DropDownList ID="ddlDonos" runat="server" AutoPostBack="True" Width="500px"></asp:DropDownList>
        </p>
        <br />
        <p>
            <asp:Button ID="btnCadastrarDono" runat="server" CssClass="btn btn-default" Text="Cadastrar" OnClick="btnCadastrarDono_Click" />
            &nbsp&nbsp&nbsp&nbsp&nbsp
            <asp:Button ID="btnVoltar" runat="server" CssClass="btn btn-default" Text="voltar" OnClick="btnVoltar_Click" />
        </p>        
    </div>
</asp:Content>
