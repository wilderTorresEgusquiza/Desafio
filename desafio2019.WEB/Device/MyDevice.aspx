<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyDevice.aspx.cs" Inherits="desafio2019.WEB.Device.MyDevice" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <script src="/Scripts/jValidacionGeneral.js"></script>

    <div class="page-content">
        <div class="container-fluid">

            <p></p>
            <br />

            <div class="row">
                <div class="col-lg-2">
                    <div class="btn-upload btn-upload--fountain-blue">
                        <input type="file" class="btn-upload__input-file">
                        <div class="btn-upload__top-side">
                            <span class="ua-icon-btn-upload btn-upload__icon"></span>

                        </div>
                    </div>
                </div>

            </div>

            <div class="row">
                <div class="col-lg-6 col-md-6">
                    <h2 class="page-header">My Device
                    </h2>

                </div>
            </div>

            <div class="row">
                <div class="col-lg-12 col-md-12">
                    <div class="form-group">
                        <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control" placeholder="Filter by field"></asp:TextBox>
                    </div>
                </div>
            </div>


            <div class="row">
                <div class="col-lg-12 col-md-12">
                    <div class="ibox float-e-margins">

                        <div class="ibox-content">
                            <div style="overflow: auto; width: 100%;" id="divScroll" onscroll="DoScroll()">

                                <asp:GridView ID="grvListado" runat="server" Width="100%" CssClass="table table-hover table-striped table-bordered GridViewPagina" BorderWidth="0px" GridLines="None" AutoGenerateColumns="false" ShowHeaderWhenEmpty="True" DataKeyNames="usuario,clave">
                                    <Columns>
                                        <asp:TemplateField HeaderText="ID" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblrowid" runat="server" Text='<%#  Eval("rowid").ToString() %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="5%" />
                                            <ItemStyle HorizontalAlign="Left" Width="5%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Connection" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblConnection" runat="server" Text='<%#  Eval("Connection").ToString() %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="10%" />
                                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Name" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblNameDevice" runat="server" Text='<%#  Eval("NameDevice").ToString() %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="12%" />
                                            <ItemStyle HorizontalAlign="Left" Width="12%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="IP" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDip" runat="server" Text='<%#  Eval("Dip").ToString() %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="10%" />
                                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Type Device" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDevice" runat="server" Text='<%#  Eval("Device").ToString() %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="18%" />
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Type Sensor" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSensor" runat="server" Text='<%#  Eval("Sensor").ToString() %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="20%" />
                                            <ItemStyle HorizontalAlign="Left" Width="20%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="SO" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOperSystem" runat="server" Text='<%#  Eval("OperSystem").ToString() %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="15%" />
                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <%--                               <a href="#" data-toggle="modal" data-target="#ItemID" onclick='GetItem(<%# "\"" + Eval("rowid").ToString() + "\"" %>)'>
                                                    <span class="fa fa-cloud-download" aria-hidden="true"></span>
                                                </a>--%>
                                                <asp:LinkButton ID="btntxt" Text="" runat="server" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" OnCommand="btntxt_Command"><span class="fa fa-cloud-download" aria-hidden="true"></span></asp:LinkButton>
                                                <asp:LinkButton ID="btnEditar" Text="" runat="server" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" OnCommand="btnEditar_Command"><span class="fa fa-edit" aria-hidden="true"></span></asp:LinkButton>
                                                <a href="#" data-toggle="modal" data-target="#ItemID" onclick='GetItem(<%# "\"" + Eval("rowid").ToString()+ "\",\"" + Eval("NameDevice").ToString()    + "\"" %>)'>
                                                    <span class="fa fa-circle" aria-hidden="true"></span>
                                                </a>
                                                <asp:LinkButton ID="btnEnviar" Text="" runat="server" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" OnCommand="btnEnviar_Command"><span class="fa fa-cloud-upload" aria-hidden="true"></span></asp:LinkButton>
                                            </ItemTemplate>
                                            <HeaderStyle Width="10%" />
                                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <table id="tbSinDatos" style="width: 100%">
                                            <tbody>
                                                <tr>
                                                    <td style="text-align: left">
                                                        <asp:Label ID="lblSinDatos" runat="server" Text="No se encontraron Datos..."></asp:Label>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </EmptyDataTemplate>
                                    <PagerTemplate>
                                    </PagerTemplate>
                                </asp:GridView>


                                <asp:Panel ID="pnlPagina" runat="server" class="pagination" Style="margin-top: 0px">
                                </asp:Panel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="hd_ID" runat="server" />
            <button id="IdPopupBuscaItem" runat="server" type="button" class="btn btn-primary btn-lg" data-toggle="modal" data-target="#myModalBuscaItem" style="display: none"></button>
            <div class="modal fade" id="myModalBuscaItem" role="dialog">
                <div class="modal-dialog modal-sm">
                    <div class="modal-content">
                        <div class="panel-heading" style="background-color: #f5f5f5">
                            <button id="btnCerrar" type="button" class="close refresh-me" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            <h4 class="modal-title" id="myModalLabel">Edit Device</h4>
                        </div>

                        <div class="modal-body">

                            <div class="row">
                                <div class="col-lg-12 col-md-12">
                                    <div class="form-group">
                                        <label for="lblTypeConnection">Type Connection</label>
                                        <asp:DropDownList ID="ddlTypeConnection" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12 col-md-12">
                                    <div class="form-group">
                                        <label for="lblTypeDevice">Type Device</label>
                                        <asp:DropDownList ID="ddlTypeDevice" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12 col-md-12">
                                    <div class="form-group">
                                        <label for="lblTypeSensor">Type Sensor</label>
                                        <asp:DropDownList ID="ddlTypeSensor" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12 col-md-12">
                                    <div class="form-group">
                                        <label for="lblOperativeSystem">Operative System</label>
                                        <asp:DropDownList ID="ddlOperativeSystem" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12 col-md-12">
                                    <div class="form-group">
                                        <label for="lblNameDevice">Name device</label>
                                        <asp:TextBox ID="txtNameDevice" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-8 col-md-8">
                                    <div class="form-group">
                                        <label for="lblIp">Ip Publica</label>
                                        <asp:TextBox ID="txtIp2" runat="server" CssClass="form-control" placeholder="xxx.xxx.xxx.xxx" onkeyUp="return IpMascara(this,event);"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-4 col-md-4">
                                    <div class="form-group">
                                        <div class="pull-left" style="padding-top: 35px">
                                            <asp:CheckBox ID="chkValidarIp" runat="server" Text="Validar" OnCheckedChanged="chkValidarIp_CheckedChanged" AutoPostBack="true" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-8 col-md-8">
                                    <div class="form-group">
                                        <asp:Label ID="lblMensaje" runat="server" Text="" ForeColor="Red"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12 col-md-12">
                                    <div class="form-group">
                                        <label for="lblUser">Usuario</label>
                                        <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12 col-md-12">
                                    <div class="form-group">
                                        <label for="lblclave">Contraseña</label>
                                        <asp:TextBox ID="txtclave" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-lg-12 col-md-12" style="text-align: right; padding-right: 15px">
                                <asp:Button ID="btnSalvar2" runat="server" Text="Salvar" CssClass="btn btn-primary" OnClientClick="return Grabar();" OnClick="btnSalvar2_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>




            <div class="modal fade  bd-example-modal-lg" id="ItemID" tabindex="-1" role="dialog" aria-labelledby="ItemIDModal" aria-hidden="true">
                <div class="modal-dialog  modal-md" role="document">
                    <div class="modal-content">
                        <div class="modal-header" style="background-color: #e7eaec">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                            <h5 class="modal-title" id="AnularModal">configuración del Dispositivo</h5>
                        </div>
                        <div class="modal-body">
                            <asp:HiddenField ID="hd_dispositivo" runat="server" />
                            <div class="row">
                                <div class="col-lg-12 col-md-12">

                                    <table style="align-content: center;">
                                        <tr>
                                            <td style="width: 110px;"></td>
                                            <td>Maxima</td>
                                            <td>Minima</td>
                                        </tr>
                                        <tr>
                                            <td>Temperatura</td>
                                            <td>
                                                <asp:TextBox ID="txtTempMaxima" runat="server" CssClass="form-control" onkeypress="return isDecimalKey(this,event)"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txtTempMin" runat="server" CssClass="form-control" onkeypress="return isDecimalKey(this,event)"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td>Humedad</td>
                                            <td>
                                                <asp:TextBox ID="txtHumMax" runat="server" CssClass="form-control" onkeypress="return isDecimalKey(this,event)"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txtHumMin" runat="server" CssClass="form-control" onkeypress="return isDecimalKey(this,event)"></asp:TextBox></td>
                                        </tr>
                                    </table>

                                </div>
                            </div>

                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnTemperatura" runat="server" Text="Generar" CssClass="btn btn-primary" OnClick="btnTemperatura_Click" OnClientClick="return validarconfig();" />
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">cancelar</button>
                        </div>
                    </div>
                </div>
            </div>



            <script type="text/javascript">

                function BuscarItem() {

                    //$("#IdPopupBuscaItem").click();
                    document.getElementById("<%=IdPopupBuscaItem.ClientID %>").click();

                }

                function validarconfig() {

                    var bolValida = true;
                    var temp = false;
                    var hum = false;

                    if (txtcontrolError(document.getElementById("<%=txtTempMaxima.ClientID %>")) == false) bolValida = false;
                    if (txtcontrolError(document.getElementById("<%=txtTempMin.ClientID %>")) == false) bolValida = false;
                    if (txtcontrolError(document.getElementById("<%=txtHumMax.ClientID %>")) == false) bolValida = false;
                    if (txtcontrolError(document.getElementById("<%=txtHumMin.ClientID %>")) == false) bolValida = false;


                    if (txtcontrolError(document.getElementById("<%=txtTempMaxima.ClientID %>"))) {
                        temp = true;
                    }
                    if (txtcontrolError(document.getElementById("<%=txtTempMin.ClientID %>"))) {
                        temp = true;
                    }

                    if (txtcontrolError(document.getElementById("<%=txtHumMax.ClientID %>"))) {
                        hum = true;
                    }
                    if (txtcontrolError(document.getElementById("<%=txtHumMin.ClientID %>"))) {
                        hum = true;
                    }

                    if (!temp && !hum) {
                        window.alert("debe ingresar una temperatura y humedad");
                        bolValida = false;
                    }
                    if (temp && hum) {
                        bolValida = true;
                    }

                    return bolValida;
                };


                function GetItem(id, dispositivo) {
                    document.getElementById("<%=hd_ID.ClientID %>").value = id;
                    document.getElementById("<%=hd_dispositivo.ClientID %>").value = dispositivo;

                }

                function configuracion2() {

                    var url = 'MyDevice.aspx/temperatura';
                    var prm = {};
                    prm.rowid = document.getElementById("<%=hd_ID.ClientID %>").value;
                    prm.temmax = document.getElementById("<%=txtTempMaxima.ClientID %>").value;
                    prm.temmin = document.getElementById("<%=txtTempMin.ClientID %>").value;
                    prm.hummax = document.getElementById("<%=txtHumMax.ClientID %>").value;
                    prm.humimin = document.getElementById("<%=txtHumMin.ClientID %>").value;

                    var prmJson = {};
                    prmJson.configuracion = JSON.stringify(prm);

                    var rsptaJson = {};
                    rsptaJson = execute(url, prmJson);

                    if (rsptaJson.ErrorJson == 0) {
                        var Estado = $.parseJSON(rsptaJson.response.d);
                        //bindGrid(rsptaJson.response.d);
                    }
                    else {
                        var Estado = rsptaJson.response;
                        alert(Estado);
                    }

                    return true;

                }


                function execute(urlmetodo, parametros) {
                    var rsp = {};
                    $.ajax({
                        url: urlmetodo,
                        type: "POST",
                        data: JSON.stringify(parametros),
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",
                        async: false,
                        cancel: false,
                        success: function (response) {
                            rsp.response = response;
                            rsp.ErrorJson = 0;
                        },
                        failure: function (msg) {
                            alert(msg);
                            rsp = msg;
                        },
                        error: function (xhr, status, error) {
                            var err = eval("(" + xhr.responseText + ")");
                            rsp.response = err.Message;
                            rsp.ErrorJson = 1;
                        }
                    });

                    return rsp;
                }



                function Validar() {

                    var bolValida = true;
                    if (txtcontrolError(document.getElementById("<%=txtIp2.ClientID %>")) == false) bolValida = false;

                    return bolValida;

                }

                function Grabar() {

                    var bolValida = true;

                    if (ddlcontrolError(document.getElementById("<%=ddlTypeConnection.ClientID %>")) == false) bolValida = false;
                    if (ddlcontrolError(document.getElementById("<%=ddlTypeDevice.ClientID %>")) == false) bolValida = false;
                    if (ddlcontrolError(document.getElementById("<%=ddlTypeSensor.ClientID %>")) == false) bolValida = false;
                    if (ddlcontrolError(document.getElementById("<%=ddlOperativeSystem.ClientID %>")) == false) bolValida = false;
                    if (txtcontrolError(document.getElementById("<%=txtIp2.ClientID %>")) == false) bolValida = false;
                    if (txtcontrolError(document.getElementById("<%=txtNameDevice.ClientID %>")) == false) bolValida = false;
                    if (txtcontrolError(document.getElementById("<%=txtUsuario.ClientID %>")) == false) bolValida = false;
                    if (txtcontrolError(document.getElementById("<%=txtclave.ClientID %>")) == false) bolValida = false;

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
