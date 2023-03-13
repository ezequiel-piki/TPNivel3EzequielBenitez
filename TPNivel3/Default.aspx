<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPNivel3.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style> 
        .card-wrapper{
            column-gap:15px;
        }
        .c-img{
            height:100%;
            object-fit:cover;
            filter:brightness(0.6)
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <h1>Catálogo Web de Artículos</h1>

<%--<% foreach (dominio.Articulo articulo in ListaArticulos){ %>
    

    <div class="card m-2 rounded-0 border border-5 border-info shadow" style="max-width: 540px; --bs-border-opacity: .3;">
  <div class="row g-0">
    
      <div class="col-md-4">

      <img src=" <%: articulo.ImagenUrl %> " class="img-fluid rounded-start" alt="...">
   
        </div>

    <div class="col-md-8">
      <div class="card-body">
        
          <h5 class="card-title">
              
              <%: articulo.Nombre %> 

          </h5>

        <p class="card-text">
           
             <%: articulo.Descripcion %>

        </p>
        
      </div>
      <a 
              type="button" 
              class="btn btn-info rounded-0 shadow float-end" 
              href="Detalle.aspx?id=<%: articulo.Id %>"
              style="--bs-btn-padding-y: .25rem; --bs-btn-padding-x: .5rem; --bs-btn-font-size: .75rem;"
              >
              Ver detalle
          </a>   
    </div>
      
  </div>
    
</div>

 <% } %>--%>
  <div class ="row">
            <asp:Repeater ID="repRepeater" runat="server" >
        <ItemTemplate>
            
      <div class="col-4">

  <div class="card rounded-0 shadow mb-4" >
    
      <img src=" <%#Eval("ImagenUrl")%> " class="card-img-top " alt="img producto" width="100" height="300">
   
      <div class="card-body">
        
          <h5 class="card-title">
              <%#Eval("Nombre") %> 
          </h5>

        <p class="card-text">
             <%#Eval("Descripcion")%>
        </p>
          <div class="text-center">
               <a 
              type="button" 
              class="btn btn-outline-primary btn-sm rounded-0 text-center shadow float-end" 
              href="Detalle.aspx?id=<%#Eval("Id")%>"
              style="--bs-btn-padding-y: .25rem; --bs-btn-padding-x: .5rem; --bs-btn-font-size: .75rem;"
              >
              Detalle
          </a>
          </div>
       
      </div>
         
       <%-- <asp:Button 
            CommandArgument='<%#Eval("Id")%>'
            Text="ejemplo" 
            ID="btnEjemplo" 
            CssClass="btn btn-primary" 
            runat="server" 
            CommandName="ArticuloId" 
            OnClick="btnEjemplo_Click"/>--%>
    
      
  
    
</div>
        
      </div>
        </ItemTemplate>
    </asp:Repeater>

  
  </div>

   

</asp:Content>
