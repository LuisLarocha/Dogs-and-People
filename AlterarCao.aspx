<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AlterarCao.aspx.cs" Inherits="Dog_and_People.AlterarCao" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="jumbotron">
        <h1>Alterar Cão</h1>
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
        <br />
        <p>
            <asp:Button ID="btnAlterarCao" runat="server" CssClass="btn btn-default" Text="Alterar" OnClick="btnAlterarCao_Click"  />
            &nbsp&nbsp&nbsp&nbsp&nbsp
            <asp:Button ID="btnVoltar" runat="server" CssClass="btn btn-default" Text="voltar" OnClick="btnVoltar_Click"  />
        </p>        
    </div>

</asp:Content>
