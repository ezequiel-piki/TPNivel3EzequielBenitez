<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaProductos.aspx.cs" Inherits="TPNivel3.ListaProductos" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="ScriptManager2"/>
    <h1>Lista Productos</h1>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <asp:Label Text="Filtrar" runat="server" />
                <asp:TextBox runat="server" CssClass="form-control" ID="filtro" AutoPostBack="true"  OnTextChanged="filtro_TextChanged"/>
            </div>
        </div>
        <div class="col-3 my-4">
            <div class="mb-3">
                 <asp:CheckBox 
                     Text="Filtro Avanzado" 
                     ID="checkFiltroAvanzado" 
                     OnCheckedChanged="checkFiltroAvanzado_CheckedChanged" 
                     AutoPostBack="true" 
                     CssClass="" 
                     runat="server" />
            </div> 
        </div>
        <div class="col-3 my-4">
            <div class="mb-3">
                <asp:Button 
                    CssClass="btn btn-outline-secondary rounded-0"
                    Text="Limpiar Filtro"
                    ID="btnLimpiarFiltro" 
                    OnClick="btnLimpiarFiltro_Click"
                    runat="server" />
            </div>
        </div>
    </div>
    <% if (FiltroAvanzado) {  %> 
    <div class="row">
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="text" ID="labelCampo"  runat="server" CssClass="form-label"/>
                <asp:DropDownList
                    runat="server" 
                    CssClass="form-control" 
                    ID="ddlCampo" 
                    OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged"
                    AutoPostBack="true"
                    >
                    <asp:ListItem Text="Nombre" />
                     <asp:ListItem Text="Precio" />
                    <asp:ListItem Text="Marca" />
                     <asp:ListItem Text="Categoría" />
                </asp:DropDownList>
            </div>
        </div>
          <div class="col-3">
            <div class="mb-3">
                 <asp:Label Text="Criterio" runat="server" />
                <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-control">                   
                </asp:DropDownList>
            </div>
        </div>
          <div class="col-3">
            <div class="mb-3">
                 <asp:Label Text="Filtro Avanzado" CssClass="form-label" runat="server" />
                <asp:TextBox CssClass="form-control" runat="server" ID="txtFiltroAvanzado"/>
            </div>
        </div>

    </div>
      <div class="col-3">
        <div class="col-3">
            <div class="mb-3">
                <asp:Button Text="Buscar" OnClick="btnBuscar_Click" CssClass="btn btn-primary" ID="btnBuscar" runat="server" />
            </div>
        </div>
    </div>
    <% } %>

  
    <div class="container">
        <asp:UpdatePanel runat="server" ID="updatePanel">
            <ContentTemplate>
                  <asp:GridView 
        runat                 ="server" 
        ID                    ="dgvArticulos" 
        CssClass              ="table"
        AutoGenerateColumns   ="false"
        DataKeyNames          ="Id"
        OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged"
        OnPageIndexChanging ="dgvArticulos_PageIndexChanging"
        AllowPaging           ="true"
        PageSize              ="5"
        >
        <Columns>
             <asp:BoundField HeaderText="Nombre"    DataField="Nombre"               />
             <asp:BoundField HeaderText="Código"    DataField="Codigo"               />
             <asp:BoundField HeaderText="Marca"     DataField="Marca.Descripcion"    />
             <asp:BoundField HeaderText="Categoría" DataField="Categoria.Descripcion"/>
             <asp:BoundField HeaderText="Precio" DataField="Precio"/>
             <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="seleccionar"/>
        </Columns>        
    </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
      
                    <a href="FormularioArticulo.aspx" class="btn btn-secondary rounded-0 shadow">Agregar</a>
    </div>
</asp:Content>
