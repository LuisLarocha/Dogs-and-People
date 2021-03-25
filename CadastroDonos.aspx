<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastroDonos.aspx.cs" Inherits="Dog_and_People.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Cadastrar Dono</h1>
        <asp:Label ID="lblMensagem" runat="server" Text="" Visible="false" Font-Bold="True" ForeColor="#CC0000"></asp:Label>
    </div>

    <div class="container body-content">  
        <div>
            <p>
                Nome do Dono:        
                <asp:TextBox ID="txtDono" runat="server"></asp:TextBox>
            </p>
        </div>
       <hr />
        <div>
            <p>
                Dono do(s) Cão(es):                    
            </p>
            <asp:CheckBoxList ID="cblCaes" runat="server" CssClass="cbl" Width="80%" ></asp:CheckBoxList>        
        </div>
        <br />
        <div>
            <asp:Button ID="btnCadastrarDono" runat="server" CssClass="btn btn-default" Text="Cadastrar" OnClick="btnCadastrarDono_Click" />
            <asp:Button ID="btnVoltar" runat="server" CssClass="btn btn-default" Text="voltar" OnClick="btnVoltar_Click" />
        </div>      
          
    </div>

</asp:Content>
