﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="pro_detalhes.aspx.cs" Inherits="DeMobile.pro_detalhes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row" style="margin-top:15px">
        <div class="col-md-1">
            <label>ID: </label>
            <asp:TextBox ID="txtId" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-11">
            <label>Nome do Produto: </label>           
            <asp:TextBox ID="txtNome" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
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
            <asp:Button ID="btnVoltar" CssClass="btn btn-primary" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
        </div>
    </div>
</asp:Content>