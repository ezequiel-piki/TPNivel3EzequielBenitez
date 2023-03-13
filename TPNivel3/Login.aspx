<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPNivel3.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <h3 class="text-center">Login</h3>
    
    <div class="container text-center">
    <div class="row align-items-center" >
        <div class="col-6 col-md-4 mx-auto" >
      <div class="mb-3 row">
    <label  class="col-sm-2 col-form-label col-form-label-sm">Email</label>
    <div class="col-sm-10">
        <asp:TextBox runat="server" required ID="txtEmailLogin" CssClass="form-control form-control-sm"/>
    </div>
  </div>
  <div class="mb-3 row">
    <label class="col-sm-2 col-form-label col-form-label-sm">Password</label>
    <div class="col-sm-10">
        <asp:TextBox type ="password" required runat="server" ID="txtPasswordLogin" CssClass="form-control form-control-sm"/>  
    </div>
  </div>

        </div>

    </div>
        <asp:Button Text="Login" ID="btnLoguearse" OnClick="btnLoguearse_Click" CssClass="btn btn-primary text-center" runat="server" />
        <a href="#">cancelar</a>
    </div>
</asp:Content>
