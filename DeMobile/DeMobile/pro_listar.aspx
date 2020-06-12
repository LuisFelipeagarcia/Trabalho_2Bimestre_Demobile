<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="pro_listar.aspx.cs" Inherits="DeMobile.pro_listar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css"
        href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.13.0/css/all.min.css">

    <link rel="stylesheet" type="text/css"
        href="https://cdn.datatables.net/1.10.20/css/jquery.dataTables.min.css" />

    <script src="Scripts/jquery-3.0.0.min.js"></script>

    <script src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js">
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-center text-primary">
        <h2>Listagem de Produtos</h2>
    </div>
    <div class="row" style="margin-top: 15px">
        <div class="col-md-12 text-right">
            <asp:Button ID="btnAdicionar" CssClass="btn btn-primary" runat="server" Text="Adicionar" OnClick="btnAdicionar_Click" />
        </div>
    </div>
<p>
        <asp:Repeater ID="rptUsuarios" runat="server">
            <HeaderTemplate>
                <table class="table table-hover" id="sisDataTable">
                    <thead>
                        <tr>
                            <td style="width:10%"><strong>ID</strong></td>
                            <td style="width:33%"><strong>Descrição</strong></td>
                            <td style="width:15%"><strong>Valor p/<br/> Un.</strong></td>
                            <td style="width:15%; text-align:center"><strong>qtde estoque</strong></td>
                            <!--Funções-->
                            <td style="width:7%; text-align:center"><strong>Vizualizar/</strong>
                                                                    <strong>Editar</strong>
                            </td>
                            <td style="width:10%; text-align:center"><strong>Fazer Pedido</strong></td>
                            <td style="width:10%; text-align:center"><strong>Remover</strong></td>
                        </tr>
                    </thead>
               
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "id_prod") %>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "nom_prod") %>
                    </td>
                    <td>
                        <label>R$</label>
                        <%# DataBinder.Eval(Container.DataItem, "preco_unit_prod") %>
                    </td>
                    <td style="text-align:center">
                        <%# DataBinder.Eval(Container.DataItem, "qtd_esto_prod") %>
                    </td>
                    <td style="text-align:center">
                        <asp:LinkButton ID="lnkDetalhes" runat="server">
                            <a href="<%# Eval("id_prod", "pro_detalhes.aspx?id_prod={0}") %>">
                                <span class="fas fa-eye"></span>
                            </a>
                        </asp:LinkButton>
                        <asp:LinkButton ID="LnkEditar" runat="server">
                            <a href="<%# Eval("id_prod", "pro_editar.aspx?id_prod={0}") %>">
                                <span class="fas fa-pencil-alt"></span>
                            </a>
                        </asp:LinkButton>
                    </td>
                    <td style="text-align:center">
                        <asp:LinkButton ID="LnkPedir" runat="server">
                            <a href="<%# Eval("id_prod", "pro_fazerPedido.aspx?id_prod={0}") %>">
                                <span class="fas fa-tag"></span>
                            </a>
                        </asp:LinkButton>
                    </td>
                    <td style="text-align:center">
                        <asp:LinkButton ID="LnkRemover" runat="server">
                            <a href="<%# Eval("id_prod", "pro_remover.aspx?id_prod={0}") %>">
                                <span class="fas fa-trash-alt"></span>
                            </a>
                        </asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </p>
    <div class="row">
        <div class="col-md-12">
            <asp:Label runat="server" Text="" ID="lblMsg"></asp:Label>
        </div>
    </div>

    <script>
        
        $('#sisDataTable').dataTable({
            "language": {
            "url": "https://cdn.datatables.net/plug-ins/1.10.20/i18n/Portuguese-Brasil.json"
            }
            });
    </script>
</asp:Content>
