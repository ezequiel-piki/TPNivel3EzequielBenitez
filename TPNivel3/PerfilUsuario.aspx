<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PerfilUsuario.aspx.cs" Inherits="TPNivel3.PerfilUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style> 
       .validacion{
        color:red;
        font-size:14px;
       }
    </style>

   <%-- <script>    
        const validar = () => {
            const txtApellido = document.getElementById("txtApellido");
            const txtNombre = document.getElementById("txtNombre");
            if (txtApellido.value == "") {
                txtApellido.classList.add("is-invalid");
                txtApellido.classList.remove("is-valid");
                return false;
            }
            txtApellido.classList.remove("is-invalid");
            txtApellido.classList.add("is-valid");
            return true;
        }
        
       
    </script>--%>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Perfil del Usuario</h3>
    <div class="row">
        <div class="col-md-4">
             <div class="mb-3">
            
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" ID="txtEmail" ReadOnly="true" CssClass="form-control" />
            </div>
            <div class="mb-3">
            
                <label class="form-label">Nombre</label>
                <asp:TextBox runat="server" ID="txtNombre"  CssClass="form-control" MaxLength="12" />
                <asp:RequiredFieldValidator 
                    ErrorMessage="el nombre es requerido"
                    ControlToValidate="txtNombre"
                    runat="server"
                    CssClass="validacion"/>
                <asp:RegularExpressionValidator 
                    ErrorMessage="Solo letras" 
                    ControlToValidate="txtNombre"
                    CssClass="validacion"
                    runat="server"
                    ValidationExpression="[a-zA-Z ]{2,15}"
                    />
            </div>
            <div class="mb-3">
             <label class="form-label">Apellido</label>
             <asp:TextBox runat="server" ID="txtApellido"  CssClass="form-control" MaxLength="12" />
               <asp:RequiredFieldValidator 
                    
                   ErrorMessage="El campo apellido es obligatorio"
                    ControlToValidate="txtApellido" 
                    runat="server"
                    CssClass="validacion"/>
                 <asp:RegularExpressionValidator 
                    ErrorMessage="Solo letras" 
                     CssClass="validacion"
                    ControlToValidate="txtApellido" 
                    runat="server"
                    ValidationExpression="[a-zA-Z ]{2,15}"
                    />
               
               <%-- <asp:RangeValidator 
                    ErrorMessage="Fuera de rango" 
                    ControlToValidate="txtApellido"
                    runat="server" 
                    Type="String"
                    MinimumValue="1"
                    MaximumValue="12"
                    />--%>
                 
                
            </div>
        </div>
        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label">Imagen de Perfil</label>
            <input
                type="file"
                id="txtImagen"
                runat="server" 
                class="form-control"
                />
            </div>
            <asp:Image
                ID="imagenNuevoPerfil"
                CssClass="img-fluid mb-3"
                
                runat="server" 
                ImageUrl="https://www.palomacornejo.com/wp-content/uploads/2021/08/no-image.jpg"
                />
        </div>

        <div class="row">
            <div class="col-md-4">
                <asp:Button
                    Text="Guardar" 
                    ID="btnGuardar"
                    OnClientClick="return validar()"
                    OnClick="btnGuardar_Click" 
                    CssClass="btn btn-primary"
                    runat="server" />
                <a href="Default.aspx">Regresar</a>
            </div>
        </div>
    </div>
</asp:Content>
