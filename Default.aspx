<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Dog_and_People._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   
    <div class="jumbotron">
        <h1>Dog and Peoples</h1>
        <asp:Label ID="lblMensagem" runat="server" Text="" Visible="false" Font-Bold="True" ForeColor="#CC0000"></asp:Label>
    </div>
    <div class="container body-content">          
        <p>
            Nome do Dono:        
            <asp:TextBox ID="txtDono" runat="server"></asp:TextBox>
            <asp:Button ID="btnConsultarDono" runat="server" CssClass="btn btn-default" Text="Consultar" OnClick="btnConsultarDono_Click" />
        </p>
        <p> 
            Nome do Cão:            
            <asp:TextBox ID="txtCao" runat="server"></asp:TextBox>
            <asp:Button ID="btnConsultarCao" runat="server" CssClass="btn btn-default" Text="Consultar" OnClick="btnConsultarCao_Click" />
        </p>  
        <br />
        <p>
            <asp:Panel ID="pnlCaesDono" runat="server" Visible="true">
                <asp:GridView ID="gvDonosCaes" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" Width="80%">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="nomeCao" HeaderText="Nome do Cão">
                        <HeaderStyle HorizontalAlign="Center" Width="200px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="raca" HeaderText="Raça">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" Width="150px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="nomeDono" HeaderText="Dono">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" Width="200px" />
                        </asp:BoundField>                    
                    </Columns>
                    <FooterStyle BackColor="#CCCC99" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <RowStyle BackColor="#F7F7DE" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FBFBF2" />
                    <SortedAscendingHeaderStyle BackColor="#848384" />
                    <SortedDescendingCellStyle BackColor="#EAEAD3" />
                    <SortedDescendingHeaderStyle BackColor="#575357" />
                </asp:GridView>
            </asp:Panel>
        </p>
        <asp:Panel ID="pnlDonos" runat="server" Visible="false">
            <p>
                <asp:GridView ID="gvDonos" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" AllowPaging="True" OnRowCommand="gvDonos_RowCommand" Width="80%">
                    <Columns>
                        <asp:BoundField DataField="donoID" HeaderText="Código" />
                        <asp:BoundField DataField="nome" HeaderText="Nome do Dono" />
                        <asp:ButtonField ButtonType="Button" CommandName="Alterar" Text="Alterar" />
                        <asp:ButtonField ButtonType="Button" CommandName="Deletar" Text="Deletar" />
                    </Columns>
                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#242121" />
                </asp:GridView>   
            </p>
        </asp:Panel>

         <asp:Panel ID="pnlCaes" runat="server" Visible="false">
            <p>
                <asp:GridView ID="gvCaes" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Width="80%" OnRowCommand="gvCaes_RowCommand" AllowPaging="True">
                    <Columns>
                        <asp:BoundField DataField="caoID" HeaderText="Código" />
                        <asp:BoundField DataField="nome" HeaderText="Nome do Cão" />
                        <asp:BoundField DataField="raca" HeaderText="Raça do Cão" />
                        <asp:ButtonField ButtonType="Button" CommandName="Alterar" Text="Alterar" />
                        <asp:ButtonField ButtonType="Button" CommandName="Deletar" Text="Deletar" />
                    </Columns>
                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#242121" />
                </asp:GridView>   
            </p>
        </asp:Panel>
        <p>
            <asp:Button ID="btnCadastrarDonos" runat="server" CssClass="btn btn-default" Text="Cadastrar Donos" OnClick="btnCadastrarDonos_Click" />
            <asp:Button ID="btnCadastrarCaes" runat="server" CssClass="btn btn-default" Text="Cadastrar Cães" OnClick="btnCadastrarCaes_Click" />
        </p>
    </div>
  

</asp:Content>
