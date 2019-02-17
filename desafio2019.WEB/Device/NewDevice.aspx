<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewDevice.aspx.cs" Inherits="desafio2019.WEB.Device.NewDevice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="wrapper wrapper-content animated fadeInRight">

        <div class="row">
            <div class="col-lg-12">
                <h2 class="page-header">New Device
                </h2>

            </div>
        </div>
        <div class="row">
            <div class="col-lg-4 col-md-4">
                <div class="form-group">
                    <label for="lblTypeConnection">Type Connection</label>
                    <asp:DropDownList ID="ddlTypeConnection" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-4 col-md-4">
                <div class="form-group">
                    <label for="lblTypeDevice">Type Device</label>
                    <asp:DropDownList ID="ddlTypeDevice" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-4 col-md-4">
                <div class="form-group">
                    <label for="lblTypeSensor">Type Sensor</label>
                    <asp:DropDownList ID="ddlTypeSensor" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-4 col-md-4">
                <div class="form-group">
                    <label for="lblOperativeSystem">Operative System</label>
                    <asp:DropDownList ID="ddlOperativeSystem" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
