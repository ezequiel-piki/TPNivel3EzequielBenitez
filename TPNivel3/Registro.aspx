<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="TPNivel3.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <style> 
       .validacion{
        color:red;
        font-size:14px;
       }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="text-center">Crea tu usuario</h3>
    <div class="container text-center">
    <div class="row align-items-center">
        <div class="col-6 col-md-4 mx-auto">
      <div class="mb-3 row">
    <label for="txtUsuario" class="col-sm-2 col-form-label col-form-label-sm">Email</label>
    <div class="col-sm-10">
        <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control form-control-sm"/>
          <asp:RegularExpressionValidator 
                    ErrorMessage="formato email por favor"
                    CssClass="validacion"
                    ControlToValidate="txtEmail" 
                    runat="server"
                    ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                    />
    </div>
  </div>
  <div class="mb-3 row">
    <label for="txtPassword" class="col-sm-2 col-form-label col-form-label-sm">Password</label>
    <div class="col-sm-10">
        <asp:TextBox runat="server" ID="txtPassword" MinLength="4" type="password"  MaxLength="14" CssClass="form-control form-control-sm"/>  
        <asp:RequiredFieldValidator 
                    ErrorMessage="el password es requerido"
                    ControlToValidate="txtPassword"
                    runat="server"
                    CssClass="validacion"/>
    </div>
  </div>

        </div>

    </div>
        <asp:Button Text="Registrarse" ID="btnRegistrarse" OnClick="btnRegistrarse_Click" CssClass="btn btn-primary text-center" runat="server" />
        <a href="Default.aspx">cancelar</a>
    </div>

</asp:Content>
