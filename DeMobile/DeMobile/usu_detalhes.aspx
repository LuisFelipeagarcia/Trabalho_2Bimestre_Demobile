<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="usu_detalhes.aspx.cs" Inherits="DeMobile.usu_detalhes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row" style="margin-top:15px">
        <div class="col-md-1">
            <label>ID: </label>
            <asp:TextBox ID="txtId" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-5">
            <label>Nome: </label>
            <asp:TextBox ID="txtNome" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-4">
            <label>Login: </label>
            <asp:TextBox ID="txtLogin" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-2">
            <label>Nível: </label>
            <asp:DropDownList ID="ddlNivel" runat="server" CssClass="form-control" Enabled="false">
                <asp:ListItem Selected="True" Value=""></asp:ListItem>
                <asp:ListItem Value="A">Administrador</asp:ListItem>
                <asp:ListItem Value="O">Operador</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div class="row" style="margin-top: 15px">
        <div class="col-md-12 text-right">
            <asp:Button ID="btnVoltar" CssClass="btn btn-primary" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
        </div>
    </div>
</asp:Content>
