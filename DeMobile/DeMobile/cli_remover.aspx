<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="cli_remover.aspx.cs" Inherits="DeMobile.cli_remover" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-center text-primary">
        <h2>Inativar Cliente</h2>
    </div>
    <div class="row" style="margin-top:15px">
        <div class="col-md-1">
            <label>ID: </label>
            <asp:TextBox ID="txtId" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-9">
            <label>Nome: </label>
            <asp:TextBox ID="txtNome" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-2">
            <label>Status</label>
            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control" Enabled="false">
                <asp:ListItem Selected="True" Value=""></asp:ListItem>
                <asp:ListItem Value="ativo">Ativo</asp:ListItem>
                <asp:ListItem Value="inativo">Inativo</asp:ListItem>
            </asp:DropDownList>
        </div>
        
    </div>
    <div class="row" style="margin-top:15px">
        <div class="col-md-8">
            <label>Email: </label>
            <asp:TextBox ID="txtEmail" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-1">
            <label>DDD: </label>
            <asp:TextBox ID="txtDdd" runat="server" Enabled="false" CssClass="form-control" ></asp:TextBox>
        </div>
        <div class="col-md-3">
            <label>Telefone: </label> 
            <asp:TextBox ID="txtFone" runat="server" Enabled="false" CssClass="form-control" ></asp:TextBox>
        </div>
    </div>
    <div class="row" style="margin-top:15px">
        <div class="col-md-7">
            <label>Logradouro: </label>  
            <asp:TextBox ID="txtLog" runat="server" Enabled="false" CssClass="form-control" ></asp:TextBox>
        </div>
        <div class="col-md-2">
            <label>Número: </label>  
            <asp:TextBox ID="txtNum" runat="server"  CssClass="form-control" Enabled="false"></asp:TextBox>
        </div>
        <div class="col-md-3">
            <label>Complemento: </label>
            <asp:TextBox ID="txtComp" runat="server" Enabled="false" CssClass="form-control" ></asp:TextBox>
        </div>
    </div> 
    <div class="row" style="margin-top:15px">
        <div class="col-md-5">
            <label>Bairro: </label>         
            <asp:TextBox ID="txtBairro" runat="server" Enabled="false" CssClass="form-control" ></asp:TextBox>
        </div>
        <div class="col-md-5">
            <label>Cidade: </label>      
            <asp:TextBox ID="txtCidade" runat="server" Enabled="false" CssClass="form-control" ></asp:TextBox>
        </div>
        <div class="col-md-2">
            <label>UF: </label>   
            <asp:TextBox ID="txtUF" runat="server" Enabled="false" CssClass="form-control" ></asp:TextBox>
        </div>
    </div>
    <div class="row" style="margin-top: 15px">
        <div class="col-md-12 text-right">
            <asp:Button ID="btnRemover" CssClass="btn btn-primary" runat="server" Text="Inativar" OnClick="btnRemover_Click" />
        </div>
    </div>
    <div class="row" style="margin-top: 15px">
        <div class="col-md-12 text-right">
            <asp:Label ID="lblResultado" runat="server" CssClass="text text-danger"></asp:Label>
        </div>
    </div>
</asp:Content>
