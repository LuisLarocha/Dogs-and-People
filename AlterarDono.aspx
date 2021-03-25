<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AlterarDono.aspx.cs" Inherits="Dog_and_People.AlterarDono" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Alterar Dono</h1>
        <asp:Label ID="lblMensagem" runat="server" Text="" Visible="false" Font-Bold="True" ForeColor="#CC0000"></asp:Label>
    </div>
    <div class="container body-content">   
        <p>
            Nome do Dono:        
            <asp:TextBox ID="txtDono" runat="server" Width="500px"></asp:TextBox>
        </p>
        <br />
        <p>
            <asp:Button ID="btnAlterarDono" runat="server" CssClass="btn btn-default" Text="Alterar" OnClick="btnAlterarDono_Click" />
            &nbsp&nbsp&nbsp&nbsp&nbsp
            <asp:Button ID="btnVoltar" runat="server" CssClass="btn btn-default" Text="voltar" OnClick="btnVoltar_Click" />
        </p>        
    </div>

</asp:Content>
