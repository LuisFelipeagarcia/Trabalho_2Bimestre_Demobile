<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="pro_remover.aspx.cs" Inherits="DeMobile.pro_remover" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-center text-primary">
        <h2>Inativar Produto</h2>
    </div>
    <div class="row" style="margin-top:15px">
        <div class="col-md-1">
            <label>ID: </label>
            <asp:TextBox ID="txtId" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-7">
            <label>Nome do Produto: </label>           
            <asp:TextBox ID="txtNome" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-4">
            <label>Status</label>
            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control" Enabled="false">
                <asp:ListItem Selected="True" Value=""></asp:ListItem>
                <asp:ListItem Value="A">Ativo</asp:ListItem>
                <asp:ListItem Value="I">Inativo</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    
    <div class="row" style="margin-top:15px">
        <div class="col-md-5">
            <label>Descrição do Produto: </label>
            <asp:TextBox ID="txtDesc" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-4">
            <label>Quantidade no estoque: </label>
            <asp:TextBox ID="txtQtd" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
        </div>
        <div class="col-md-3">
            <label>Valor do produto: </label>  
            <asp:TextBox ID="txtVal" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
        </div>
    </div>
    <div class="row" style="margin-top: 15px">
        <div class="col-md-12 text-right">
            <asp:Button ID="btnInativar" CssClass="btn btn-primary" runat="server" Text="Inativar" OnClick="btnInativar_Click"  />
        </div>
    </div>
    <div class="row" style="margin-top: 15px">
        <div class="col-md-12 text-right">
            <asp:Label ID="lblResultado" runat="server" CssClass="text text-danger"></asp:Label>
        </div>
    </div>
</asp:Content>
