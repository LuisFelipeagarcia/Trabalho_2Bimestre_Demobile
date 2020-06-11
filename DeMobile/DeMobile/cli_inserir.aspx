<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="cli_inserir.aspx.cs" Inherits="DeMobile.cli_inserir" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-center text-primary">
        <h2>Cadastro de Clientes</h2>
    </div>

    <div class="row" style="margin-top:15px">
        <div class="col-md-12">
            <label>Nome: </label>
            <asp:RequiredFieldValidator ID="rfvNome" ControlToValidate="txtNome" ErrorMessage="*" ForeColor="Red" runat="server"></asp:RequiredFieldValidator>
            <asp:TextBox ID="txtNome" runat="server" MaxLength="100" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="row" style="margin-top:15px">
        <div class="col-md-8">
            <label>Email: </label>
            <asp:RequiredFieldValidator ID="rfvEmail" ControlToValidate="txtEmail" ErrorMessage="*" ForeColor="Red" runat="server"></asp:RequiredFieldValidator>
            <asp:TextBox ID="txtEmail" runat="server" MaxLength="100" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-1">
            <label>DDD: </label>
            <asp:RequiredFieldValidator ID="rfvDdd" ControlToValidate="txtDdd" ErrorMessage="*" ForeColor="Red" runat="server"></asp:RequiredFieldValidator>
            <asp:TextBox ID="txtDdd" runat="server" MaxLength="3" CssClass="form-control" onkeypress="return ValidNumeric()"></asp:TextBox>
        </div>
        <div class="col-md-3">
            <label>Telefone: </label>
            <asp:RequiredFieldValidator ID="rfvFone" ControlToValidate="txtFone" ErrorMessage="*" ForeColor="Red" runat="server"></asp:RequiredFieldValidator>
            <asp:TextBox ID="txtFone" runat="server" MaxLength="9" CssClass="form-control" onkeypress="return ValidNumeric()"></asp:TextBox>
        </div>
    </div>
    

    <div class="row" style="margin-top:15px">
        <div class="col-md-7">
            <label>Logradouro: </label>
            <asp:RequiredFieldValidator ID="rfvLog" ControlToValidate="txtLog" ErrorMessage="*" ForeColor="Red" runat="server"></asp:RequiredFieldValidator>
            <asp:TextBox ID="txtLog" runat="server" MaxLength="100" CssClass="form-control" ></asp:TextBox>
        </div>
        <div class="col-md-2">
            <label>Número: </label>
            <asp:RequiredFieldValidator ID="rfvNum" ControlToValidate="txtNum" ErrorMessage="*" ForeColor="Red" runat="server"></asp:RequiredFieldValidator>
            <asp:TextBox ID="txtNum" runat="server"  CssClass="form-control" ></asp:TextBox>
        </div>
        <div class="col-md-3">
            <label>Complemento: </label>
            <asp:TextBox ID="txtComp" runat="server" MaxLength="20" CssClass="form-control" ></asp:TextBox>
        </div>
    </div>
    
    <div class="row" style="margin-top:15px">
        <div class="col-md-5">
            <label>Bairro: </label>
            <asp:RequiredFieldValidator ID="rfvBairro" ControlToValidate="txtBairro" ErrorMessage="*" ForeColor="Red" runat="server"></asp:RequiredFieldValidator>
            <asp:TextBox ID="txtBairro" runat="server" MaxLength="100" CssClass="form-control" ></asp:TextBox>
        </div>
        <div class="col-md-5">
            <label>Cidade: </label>
            <asp:RequiredFieldValidator ID="rfvCidade" ControlToValidate="txtCidade" ErrorMessage="*" ForeColor="Red" runat="server"></asp:RequiredFieldValidator>
            <asp:TextBox ID="txtCidade" runat="server" MaxLength="100" CssClass="form-control" ></asp:TextBox>
        </div>
        <div class="col-md-2">
            <label>UF: </label>
            <asp:RequiredFieldValidator ID="rfvUF" ControlToValidate="txtUF" ErrorMessage="*" ForeColor="Red" runat="server"></asp:RequiredFieldValidator>
            <asp:TextBox ID="txtUF" runat="server" MaxLength="2" CssClass="form-control" ></asp:TextBox>
        </div>
    </div>

    <div class="row" style="margin-top: 15px">
        <div class="col-md-12 text-right">
            <asp:Button ID="btnSalvar" CssClass="btn btn-primary" runat="server" Text="Salvar" OnClick="btnSalvar_Click"  />
        </div>
    </div>
    <div class="row" style="margin-top: 15px">
        <div class="col-md-12 text-right">
            <asp:Label ID="lblResultado" runat="server" CssClass="text text-danger"></asp:Label>
        </div>
    </div>
</asp:Content>
