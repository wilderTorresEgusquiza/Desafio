<%@ Page Title="Iniciar sesión" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="desafio2019.WEB.Account.Login" Async="true" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">


    <div class="row">
        <div class="col-md-8">
            <section id="loginForm">
                <div class="form-horizontal">
                    <h4>Utilice una cuenta local para iniciar sesión.</h4>
                    <hr />
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                    <div class="form-group">
                        <asp:Label runat="server" CssClass="col-md-2 control-label">Correo electrónico</asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox runat="server" ID="txtUsuario" CssClass="form-control" />

                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" CssClass="col-md-2 control-label">Contraseña</asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />

                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-5">
                            <div class="checkbox">
                                <asp:CheckBox runat="server" ID="RememberMe" />
                                <asp:Label runat="server" AssociatedControlID="RememberMe">¿Recordar cuenta?</asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-5">
                            <asp:Button runat="server" OnClick="LogIn" Text="Iniciar sesión" CssClass="btn btn-default" />
                            <input id="btnGoogleLogin" type="button" value="Login with Google" class="btn btn-success" />
                            <asp:Button ID="Button1" runat="server" Text="Login with Facebook" OnClick="Button1_Click" CssClass="btn btn-primary" />
                        </div>
                    </div>
                </div>
                <p>
                    <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Registrarse como usuario nuevo</asp:HyperLink>
                </p>
                <p>
                    <%-- Enable this once you have account confirmation enabled for password reset functionality
                    <asp:HyperLink runat="server" ID="ForgotPasswordHyperLink" ViewStateMode="Disabled">Forgot your password?</asp:HyperLink>
                    --%>
                </p>
            </section>
        </div>

    </div>
    <div class="row">
        <div class="col-md-6">
            <asp:Panel ID="pnlFaceBookUser" runat="server" Visible="false">


                <div class="row">
                    <div class="col-md-offset-2 col-lg-4 col-md-4">
                        <div class="form-group">
                            <asp:Image ID="ProfileImage" runat="server" Width="50" Height="50" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-offset-2 col-lg-4 col-md-4">
                        <div class="form-group">
                            <label for="lbl"></label>
                            ID:<asp:Label ID="lblId" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-offset-2 col-lg-4 col-md-4">
                        <div class="form-group">
                            <label for="lbl"></label>
                            Usuario :   <asp:Label ID="lblUserName" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-offset-2 col-lg-4 col-md-4">
                        <div class="form-group">
                            <label for="lbl"></label>
                            Nombre :   <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-offset-2 col-lg-4 col-md-4">
                        <div class="form-group">
                            <label for="lbl"></label>
                            Email :   <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>

            </asp:Panel>

        </div>




    </div>
    <div class="col-md-4">
        <section id="socialLoginForm">
            <uc:OpenAuthProviders runat="server" ID="OpenAuthLogin" />
        </section>
    </div>


    <script src="/Scripts/jquery-3.3.1.min.js"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            $('#btnGoogleLogin').click(function () {
                window.location.href = "";
            })

        });

    </script>





</asp:Content>
