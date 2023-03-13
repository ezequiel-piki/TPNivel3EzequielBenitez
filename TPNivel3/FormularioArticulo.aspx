<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioArticulo.aspx.cs" Inherits="TPNivel3.FromularioArticulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

 <style> 
       .validacion{
        color:red;
        font-size:14px;
       }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
        <asp:RequiredFieldValidator 
                    ErrorMessage="el nombre del articulo es requerido"
                    ControlToValidate="txt_Nombre"
                    runat="server"
                    CssClass="validacion"/>
    </div>
  </div>
    
         <div class="row mb-3">
    <label for="txt_Codigo" class="col-sm-2 col-form-label">Código</label>
    <div class="col-sm-10">
      
        <asp:TextBox runat="server" CssClass="form-control" ID="txt_Codigo" />  
        <asp:RequiredFieldValidator 
                    ErrorMessage="el codigo es requerido"
                    ControlToValidate="txt_Codigo"
                    runat="server"
                    CssClass="validacion"/>
    </div>
    </div>
         <div class="row mb-3">
    <label for="txt_Precio" class="col-sm-2 col-form-label">Precio</label>
    <div class="col-sm-10">
      
        <asp:TextBox runat="server" CssClass="form-control" ID="txtPrecio" />  
        <asp:RequiredFieldValidator 
                    ErrorMessage="el precio es requerido"
                    ControlToValidate="txtPrecio"
                    runat="server"
                    CssClass="validacion"/>
        <asp:RegularExpressionValidator 
                    ErrorMessage="Solo números." 
                    ControlToValidate="txtPrecio"
                    CssClass="validacion"
                    runat="server"
                    ValidationExpression="^[0-9]+([,][0-9]+)?$"
                    />
    </div>
  </div>
        
    
    
     </div>
        
    

    <div class="col-md-6">
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
        <asp:RequiredFieldValidator 
                    ErrorMessage="El articulo debe tener una descripcion"
                    ControlToValidate="txt_Descripcion"
                    runat="server"
                    CssClass="validacion"/>
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
  
   
        
   

    
    <asp:Button 
        Text="Aceptar" 
        OnClick="btn_aceptar_Click"
        ID="btn_aceptar" 
        CssClass="btn btn-primary"
        runat="server" />
    
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:Button Text="Eliminar" ID="btnEliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" runat="server" />

            <% if (ConfirmarEliminacion)
                { %>
            <div class="mb-3">
                <asp:CheckBox Text="confirmar eliminación" ID="checkConfirmarEliminación" runat="server" />
                <asp:Button Text="ELIMINAR" OnClick="btnConfirmarEliminar_Click" CssClass="btn btn-outline-danger" ID="btnConfirmarEliminar" runat="server" />
            </div>
            <%} %>
        </ContentTemplate>
    </asp:UpdatePanel>
   
    <a href="ListaProductos.aspx">cancelar</a>
</asp:Content>
