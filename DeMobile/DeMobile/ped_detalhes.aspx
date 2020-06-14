<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ped_detalhes.aspx.cs" Inherits="DeMobile.ped_detalhes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-center text-primary">
        <h2>Detalhes do Pedido</h2>
    </div>
    <div class="row">
        <div class="col-md-1">
            <label>ID: </label>
            <asp:TextBox ID="txtId" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-7">
            <label>Nome: </label>
            <asp:TextBox ID="txtNomeCli" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-4">
            <label>Status</label>
            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control" Enabled="false">
                <asp:ListItem Selected="True" Value=""></asp:ListItem>
                <asp:ListItem Value="Em Andamento">Em Andamento</asp:ListItem>
                <asp:ListItem Value="Finalizado">Finalizado</asp:ListItem>
                <asp:ListItem Value="Cancelado">Cancelado</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="col-md-5">
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
        <div class="col-md-3">
            <label>Nome do Produto: </label>           
            <asp:TextBox ID="txtNomeprod" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-md-6">
            <label>Descrição do Produto: </label>
            <asp:TextBox ID="txtDesc" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-3">
            <label>N° de unidades: </label>          
            <asp:TextBox ID="txtnqtd" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
        </div>
        <div class="col-md-3">
            <label>Valor do Pedido: </label>  
            <asp:TextBox ID="txtValF" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
        </div>
    </div>
    <div class="row" style="margin-top: 15px">
        <div class="col-md-12 text-right">
            <asp:Button ID="btnVoltar" CssClass="btn btn-primary" runat="server" Text="Voltar" OnClick="btnVoltar_Click"/>
        </div>
    </div>
    <div class="row" style="margin-top: 15px">
        <div class="col-md-12 text-right">
            <asp:Label ID="lblMsg" runat="server" CssClass="text text-danger"></asp:Label>
        </div>
    </div>
    
</asp:Content>
