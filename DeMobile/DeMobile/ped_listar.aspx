<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ped_listar.aspx.cs" Inherits="DeMobile.ped_listar" %>
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
        <h2>Listagem de Pedidos</h2>
    </div>
    <div class="row" style="margin-top: 15px">
        <div class="col-md-12 text-right">
            <asp:Button ID="btnAdicionar" CssClass="btn btn-primary" runat="server" Text="Adicionar" />
        </div>
    </div>
<p>
        <asp:Repeater ID="rptUsuarios" runat="server" OnItemDataBound="rptUsuarios_ItemDataBound" >
            <HeaderTemplate>
                <table class="table table-hover" id="sisDataTable">
                    <thead>
                        <tr>
                            <td style="width:5%"><strong>ID</strong></td>
                            <td style="width:25%"><strong>Cliente</strong></td>
                            <td style="width:25%"><strong>Produto</strong></td>
                            <td style="width:15%"><strong>qtde de produtos</strong></td>
                            <td style="width:10%"><strong>Valor Final</strong></td>
                            <td style="width:10%; text-align:center"><strong>Status</strong></td>
                            <!--Funções-->
                            <td style="width:10%; text-align:center"><strong>Vizualizar/</strong>
                                                                    <strong>Editar</strong>
                            </td>
                        </tr>
                    </thead>
               
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "id_ped") %>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "nom_cli") %>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "nom_prod") %>
                    </td>
                    <td style="text-align:center">
                        <%# DataBinder.Eval(Container.DataItem, "qtd_ped") %>
                    </td>
                    <td>
                        <label>R$</label>
                        <%# DataBinder.Eval(Container.DataItem, "valor_final_ped") %>
                    </td>
                    
                    <td style="text-align:center">
                        <%# DataBinder.Eval(Container.DataItem, "stt_ped") %>
                    </td>
                    <td style="text-align:center">
                        <asp:LinkButton ID="lnkDetalhes" runat="server">
                            <a href="<%# Eval("id_ped", "ped_detalhes.aspx?id_ped={0}") %>">
                                <span class="fas fa-eye"></span>
                            </a>
                        </asp:LinkButton>
                        <asp:LinkButton ID="LnkEditar" runat="server">
                            <a href="<%# Eval("id_ped", "ped_editar.aspx?id_ped={0}") %>">
                                <span class="fas fa-pencil-alt"></span>
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
