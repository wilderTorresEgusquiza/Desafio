<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewDevice.aspx.cs" Inherits="desafio2019.WEB.Device.NewDevice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="/Scripts/jValidacionGeneral.js" type="text/javascript"></script>

    <div class="page-content">
        <div class="container-fluid">
            <p></p>
            <br />
            <div class="row">
                <div class="col-lg-6 col-md-6">
                    <h2 class="page-header">New Device
                    </h2>

                </div>
            </div>
            <div class="row">
                <div class="col-lg-3 col-md-3">
                    <div class="form-group">
                        <label for="lblTypeConnection">Type Connection</label>
                        <asp:DropDownList ID="ddlTypeConnection" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-3 col-md-3">
                    <div class="form-group">
                        <label for="lblTypeDevice">Type Device</label>
                        <asp:DropDownList ID="ddlTypeDevice" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-3 col-md-3">
                    <div class="form-group">
                        <label for="lblTypeSensor">Type Sensor</label>
                        <asp:DropDownList ID="ddlTypeSensor" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-3 col-md-3">
                    <div class="form-group">
                        <label for="lblOperativeSystem">Operative System</label>
                        <asp:DropDownList ID="ddlOperativeSystem" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-3 col-md-3">
                    <div class="form-group">
                        <label for="lblNameDevice">Name device</label>
                        <asp:TextBox ID="txtNameDevice" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-3 col-md-3">
                    <div class="form-group">
                        <label for="lblIp">Ip Publica</label>
                        <asp:TextBox ID="txtIp" runat="server" CssClass="form-control" placeholder="xxx.xxx.xxx.xxx" onkeyUp="return IpMascara(this,event);"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3">
                    <div class="form-group">
                        <div class="pull-left" style="padding-top: 35px">
                            <asp:CheckBox ID="chkValidarIp" runat="server" Text="Validar" OnCheckedChanged="chkValidarIp_CheckedChanged" AutoPostBack="true" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-3 col-md-3">
                    <div class="form-group">
                        <asp:Label ID="lblMensaje" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-3 col-md-3">
                    <div class="form-group">
                        <label for="lblUser">Usuario</label>
                        <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-3 col-md-3">
                        <div class="form-group">
                            <label for="lblclave">Contraseña</label>
                            <asp:TextBox ID="txtclave" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-3 col-md-3">
                    <div class="form-group">
                        <div class="pull-right">
                            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="btn btn-primary" OnClientClick="return Grabar();" OnClick="btnSalvar_Click" />
                        </div>
                    </div>
                </div>
            </div>


            <script type="text/javascript">

                function IpMascara(ctrl, evt) {
                    var charCode = (evt.which) ? evt.which : event.keyCode
                    var FIND = "."
                    var x = ctrl.value
                    var y = x.indexOf(FIND)

                    //alert(x);
                    //if (x.length == 1 && x < "3") {
                    //    ctrl.value = "";
                    //    return false;
                    //}

                    var IpSegmento = [];

                    var n = 0;
                    for (var i = 0; i < x.length; i++) {
                        if (x.substr(i, 1) == ".") {
                            IpSegmento[n] = i + 1;
                            n = n + 1;
                        }
                    }

                    //for (var i = 0; i < IpSegmento.length; i++) {
                    //    alert(IpSegmento[i]);
                    //}


                    if (x == ".") {
                        ctrl.value = x.substr(0, x.length - 1);
                        return;
                    }


                    if (IpSegmento.length > 3 && x.substr(x.length - 1, 1) == ".") {
                        ctrl.value = x.substr(0, x.length - 1);
                        return;
                    }

                    if (IpSegmento.length > 3 && x.substr(x.length - 1, 1) != ".") {
                        ctrl.style.border = "1px solid Red";
                        return;
                    }

                    if (x.length > 1) {
                        if (x.substr(x.length - 2, 1) == x.substr(x.length - 1, 1)) {
                            ctrl.value = x.substr(0, x.length - 1);
                            return;
                        }
                    }


                    //ctrl.style.border = "1px solid #ccc";
                    //for (var i = 0; i < IpSegmento; i++) {
                    //    //alert(parseInt(x.substr(i,x.length - 1)));
                    //    if (i == 0) {
                    //        if (parseInt(x.substr(i, x.length - 1)) < parseInt("256")) {
                    //            ctrl.style.border = "1px solid #ccc";
                    //        }
                    //        else {
                    //            ctrl.style.border = "1px solid Red";
                    //        }
                    //    }
                    //    if (i == 1) {
                    //        if (parseInt(x.substr(parseInt(IpSegmento[0]), x.length - 1)) < parseInt("256")) {
                    //            ctrl.style.border = "1px solid #ccc";
                    //        }
                    //        else {
                    //            ctrl.style.border = "1px solid Red";
                    //        }
                    //    }

                    //}






                    return true;
                }

                function Validar() {

                    var bolValida = true;
                    if (txtcontrolError(document.getElementById("<%=txtIp.ClientID %>")) == false) bolValida = false;

                    return bolValida;

                }

                function Grabar() {

                    var bolValida = true;

                    if (ddlcontrolError(document.getElementById("<%=ddlTypeConnection.ClientID %>")) == false) bolValida = false;
                    if (ddlcontrolError(document.getElementById("<%=ddlTypeDevice.ClientID %>")) == false) bolValida = false;
                    if (ddlcontrolError(document.getElementById("<%=ddlTypeSensor.ClientID %>")) == false) bolValida = false;
                    if (ddlcontrolError(document.getElementById("<%=ddlOperativeSystem.ClientID %>")) == false) bolValida = false;
                    if (txtcontrolError(document.getElementById("<%=txtIp.ClientID %>")) == false) bolValida = false;
                    if (txtcontrolError(document.getElementById("<%=txtNameDevice.ClientID %>")) == false) bolValida = false;
                    if (txtcontrolError(document.getElementById("<%=txtUsuario.ClientID %>")) == false) bolValida = false;
                    if (txtcontrolError(document.getElementById("<%=txtclave.ClientID %>")) == false) bolValida = false;

                    var usuario = document.getElementById("<%=txtUsuario.ClientID %>");

                    if (usuario.value.trim() == "root" || usuario.value.trim() == "admin") {

                        usuario.style.border = "1px solid #ccc";

                    }
                    else {
                        bolValida = false;
                        usuario.style.border = "1px solid Red";
                        window.alert("Usuario incorrecto: admin | root");

                    }

                    return bolValida;


                }




            </script>


        </div>
    </div>

    <script src="/admin/vendor/jquery/jquery.min.js"></script>
    <script src="/admin/vendor/popper/popper.min.js"></script>
    <script src="/admin/vendor/bootstrap/js/bootstrap.min.js"></script>
    <script src="/admin/vendor/select2/js/select2.full.min.js"></script>
    <script src="/admin/vendor/simplebar/simplebar.js"></script>
    <script src="/admin/vendor/text-avatar/jquery.textavatar.js"></script>
    <script src="/admin/vendor/tippyjs/tippy.all.min.js"></script>
    <script src="/admin/vendor/flatpickr/flatpickr.min.js"></script>
    <script src="/admin/vendor/wnumb/wNumb.js"></script>
    <script src="/admin/js/main.js"></script>


    <script src="/admin/vendor/fileapi/FileAPI.html5.min.js"></script>
    <script src="/admin/js/preview/file-upload.min.js"></script>

    <script src="/admin/js/preview/settings-panel.min.js"></script>
    <script src="/admin/js/preview/slide-nav.min.js"></script>

</asp:Content>
