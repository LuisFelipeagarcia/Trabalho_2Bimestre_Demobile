<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="usu_editar.aspx.cs" Inherits="DeMobile.usu_editar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-primary text-center">
        <h2>Edição de Usuário</h2>
    </div>

    <div class="row" style="margin-top:15px">
        <div class="col-md-1">
            <label>ID: </label>
            <asp:TextBox ID="txtId" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-4">
            <label>Nome: </label>
            <asp:RequiredFieldValidator ID="rfvNome" ControlToValidate="txtNome" ErrorMessage="*" ForeColor="Red" runat="server"></asp:RequiredFieldValidator>
            <asp:TextBox ID="txtNome" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-5">
            <label>Login: </label>
            <asp:RequiredFieldValidator ID="rfvLogin" ControlToValidate="txtLogin" ErrorMessage="*" ForeColor="Red" runat="server"></asp:RequiredFieldValidator>
            <asp:TextBox ID="txtLogin" runat="server" MaxLength="10" CssClass="form-control"></asp:TextBox>
        </div>
        
        <div class="col-md-2">
            <label>Nível: </label>
            <asp:RequiredFieldValidator ID="rfvNivel" ControlToValidate="ddlNivel" ErrorMessage="*" ForeColor="Red" runat="server"></asp:RequiredFieldValidator>
            <asp:DropDownList ID="ddlNivel" runat="server" CssClass="form-control">
                <asp:ListItem Selected="True" Value=""></asp:ListItem>
                <asp:ListItem Value="A">Administrador</asp:ListItem>
                <asp:ListItem Value="O">Operador</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div class="row" style="margin-top:15px">
        
    </div>

    <div class="row" style="margin-top: 15px">
        <div class="col-md-12 text-right">
            <asp:Button ID="btnSalvar" CssClass="btn btn-primary" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />
        </div>
    </div>
    <div class="row" style="margin-top: 15px">
        <div class="col-md-12 text-right">
            <asp:Label ID="lblResultado" runat="server" CssClass="text text-danger"></asp:Label>
        </div>
    </div>
</asp:Content>
