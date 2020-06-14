<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="pro_fazerPedido.aspx.cs" Inherits="DeMobile.pro_fazerPedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-center text-primary">
        <h2>Fazer Pedido</h2>
    </div>
    <div class="row" style="margin-top:15px">
        <div class="col-md-5">
            <label>Email: </label>
            <asp:RequiredFieldValidator ID="rfvEmail" ControlToValidate="txtEmail" ErrorMessage="*" ForeColor="Red" runat="server"></asp:RequiredFieldValidator>
            <asp:TextBox ID="txtEmail" runat="server" MaxLength="100" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-5">
            <label>Produto: </label>           
            <asp:TextBox ID="txtNome" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-2">
            <label>Qtde estoque: </label>
            
            <asp:TextBox ID="txtQtd" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
        </div>
    </div>
    <div class="row" style="margin-top:15px">
        <div class="col-md-6">
            <label>Descrição: </label>
            <asp:TextBox ID="txtDesc" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-3">
            <label>Valor p/ Un.: </label>  
            <asp:TextBox ID="txtVal" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
        </div>
        <div class="col-md-3">
            <label>N° de unidades: </label>
            <asp:RequiredFieldValidator ID="rfvnqtd" ControlToValidate="txtnqtd" ErrorMessage="*" ForeColor="Red" runat="server"></asp:RequiredFieldValidator>
            <asp:TextBox ID="txtnqtd" runat="server" CssClass="form-control" onkeypress="return ValidNumeric()"></asp:TextBox>
        </div>
        
    </div>



    <div class="row" style="margin-top: 15px">
        <div class="col-md-12 text-right">
            <asp:Button ID="btnFazerPedido" CssClass="btn btn-primary" runat="server" Text="Salvar" OnClick="btnFazerPedido_Click" />
        </div>
    </div>
    <div class="row" style="margin-top: 15px">
        <div class="col-md-12 text-right">
            <asp:Label ID="lblResultado" runat="server" CssClass="text text-danger"></asp:Label>
        </div>
    </div>
</asp:Content>
