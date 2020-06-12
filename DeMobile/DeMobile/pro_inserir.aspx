<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="pro_inserir.aspx.cs" Inherits="DeMobile.pro_inserir" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row" style="margin-top:15px">
        <div class="col-md-12">
            <label>Nome do Produto: </label>
            <asp:RequiredFieldValidator ID="rfvNome" ControlToValidate="txtNome" ErrorMessage="*" ForeColor="Red" runat="server"></asp:RequiredFieldValidator>
            <asp:TextBox ID="txtNome" runat="server" MaxLength="100" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="row" style="margin-top:15px">
        <div class="col-md-5">
            <label>Descrição do Produto: </label>
            <asp:RequiredFieldValidator ID="rfvDesc" ControlToValidate="txtDesc" ErrorMessage="*" ForeColor="Red" runat="server"></asp:RequiredFieldValidator>
            <asp:TextBox ID="txtDesc" runat="server" MaxLength="100" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-4">
            <label>Quantidade no estoque: </label>
            <asp:RequiredFieldValidator ID="rfvQtd" ControlToValidate="txtQtd" ErrorMessage="*" ForeColor="Red" runat="server"></asp:RequiredFieldValidator>
            <asp:TextBox ID="txtQtd" runat="server" CssClass="form-control" onkeypress="return ValidNumeric()"></asp:TextBox>
        </div>
        <div class="col-md-3">
            <label>Valor do produto: </label>
            <asp:RequiredFieldValidator ID="rfvVal" ControlToValidate="txtVal" ErrorMessage="*" ForeColor="Red" runat="server"></asp:RequiredFieldValidator>
            <asp:TextBox ID="txtVal" runat="server" CssClass="form-control" onkeypress="return ValidNumericPonto()"></asp:TextBox>
        </div>
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
