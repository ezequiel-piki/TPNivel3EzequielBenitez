<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="TPNivel3.Detalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>  Detalle del articulo  </h1>
    
    <%-- Requerido para usar Update Panel --%>
  <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    

    <div class="col-6">
         <div class="row mb-3">
    <label for="txt_id" class="col-sm-2 col-form-label">ID</label>
    <div class="col-sm-10">
      
        <asp:TextBox runat="server" CssClass="form-control" ID="txt_Id" />  

    </div>
  </div>
    
    <div class="row mb-3">
    <label for="txt_Nombre" class="col-sm-2 col-form-label">Nombre</label>
    <div class="col-sm-10">
      
        <asp:TextBox runat="server" CssClass="form-control" ID="txt_Nombre" />  

    </div>
  </div>
    
    <div class="row mb-3">
    <label for="txt_Codigo" class="col-sm-2 col-form-label">Código</label>
    <div class="col-sm-10">
      
        <asp:TextBox runat="server" CssClass="form-control" ID="txt_Codigo" />  

    </div>
        </div>

         <div class="row mb-3">
    
             <label for="txtPrecio" class="col-sm-2 col-form-label">Precio</label>
    
             <div class="col-sm-10">
      
             <asp:TextBox runat="server" CssClass="form-control" ID="txtPrecio" />  

              </div>
          </div>
       
    
    </div>
     <div class="col-6">
          <div class="row mb-3">
    <label for="ddl_Marca" class="col-sm-2 col-form-label">Marca</label>
    <div class="col-sm-10">
      
        <asp:DropDownList runat="server" CssClass="form-select" ID="ddl_Marca"/>  

    </div>
  </div>

    <div class="row mb-3">
    <label for="ddl_Categoria" class="col-sm-2 col-form-label">Categoría</label>
    <div class="col-sm-10">
        <asp:DropDownList runat="server" CssClass="form-select" ID="ddl_Categoria" />  
    </div>
  </div>
    <div class="row mb-3">
    <label for="txt_Descripcion" class="col-sm-2 col-form-label">Descripción</label>
    <div class="col-sm-10">
        <asp:TextBox runat="server" CssClass="form-control" ID="txt_Descripcion" TextMode="MultiLine" />  
    </div>
  </div>
        <asp:UpdatePanel runat="server" ID="updatePanel">
            <ContentTemplate>
                <div class="row mb-3">
     <label for="txt_ImagenUrl" class="col-sm-2 col-form-label">Url Imagen</label>
     <div class="col-sm-10">
        <asp:TextBox
            runat="server" 
            CssClass="form-control"
            ID="txt_ImagenUrl" 
            AutoPostBack="true"
            OnTextChanged="txt_ImagenUrl_TextChanged"
            />  
         <asp:Image 

             Width="60%"
             ID="imgProducto"
             ImageUrl="https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png" runat="server" />
    </div>
  </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        

    </div>
</asp:Content>
