using desafio2019.Entity.MySql;
using desafio2019.Logic.MySql;
using desafio2019.WEB.Enumerador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace desafio2019.WEB.Device
{
    public partial class NewDevice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargaConnection();
                CargaDevice();
                CargaSensor();
                CargaOperativeSystem();
            }
        }

        private void CargaConnection()
        {
            try
            {
                LoConnection objLo = new LoConnection();
                object objConnection = new object();

                objConnection = objLo.CargaConnection();

                ddlTypeConnection.DataValueField = "rowid";
                ddlTypeConnection.DataTextField = "description";
                ddlTypeConnection.DataSource = objConnection;
                ddlTypeConnection.DataBind();
                ddlTypeConnection.Items.Insert(0, new ListItem("---Select---", "0"));


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargaDevice()
        {
            try
            {
                LoDevice_Type objLo = new LoDevice_Type();
                object objDevice = new object();

                objDevice = objLo.CargaDevice_Type();

                ddlTypeDevice.DataValueField = "rowid";
                ddlTypeDevice.DataTextField = "description";
                ddlTypeDevice.DataSource = objDevice;
                ddlTypeDevice.DataBind();
                ddlTypeDevice.Items.Insert(0, new ListItem("---Select---", "0"));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargaSensor()
        {
            try
            {
                LoSensor objLo = new LoSensor();
                object objSensor = new object();

                objSensor = objLo.CargaSensor();

                ddlTypeSensor.DataValueField = "rowid";
                ddlTypeSensor.DataTextField = "description";
                ddlTypeSensor.DataSource = objSensor;
                ddlTypeSensor.DataBind();
                ddlTypeSensor.Items.Insert(0, new ListItem("---Select---", "0"));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargaOperativeSystem()
        {
            try
            {
                LoOperativeSystem objLo = new LoOperativeSystem();
                object objOperativeSystem = new object();

                objOperativeSystem = objLo.CargaOperativeSystem();

                ddlOperativeSystem.DataValueField = "rowid";
                ddlOperativeSystem.DataTextField = "description";
                ddlOperativeSystem.DataSource = objOperativeSystem;
                ddlOperativeSystem.DataBind();
                ddlOperativeSystem.Items.Insert(0, new ListItem("---Select---", "0"));


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void chkValidarIp_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkValidarIp.Checked)
            {
                lblMensaje.Text = string.Empty;
                return;
            }

            if (IsValidIp(txtIp.Text))
            {
                lblMensaje.Text = "Ip Validada";
            }
            else
            {
                lblMensaje.Text = "Ip Incorrecta";
            }

        }

        public bool IsValidIp(string addr)
        {
            IPAddress ip;
            bool valid = !string.IsNullOrEmpty(addr) && IPAddress.TryParse(addr, out ip);
            return valid;
        }

        protected void btnValidar_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = string.Empty;
            if (IsValidIp(txtIp.Text))
            {
                lblMensaje.Text = "Ip Validada";
            }
            else
            {
                lblMensaje.Text = "Ip Incorrecta";
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            string msg = string.Empty;
            lblMensaje.Text = string.Empty;

            try
            {

                if (!IsValidIp(txtIp.Text))
                {
                    lblMensaje.Text = "Ip Incorrecta";
                    return;
                }

                LoDevices objLo = new LoDevices();
                EnDevices objEn = new EnDevices();

                objEn.ConnectionID = Convert.ToInt32(ddlTypeConnection.SelectedValue);
                objEn.NameDevice = txtNameDevice.Text.Trim();
                objEn.DeviceID = Convert.ToInt32(ddlTypeDevice.SelectedValue);
                objEn.SensorID = Convert.ToInt32(ddlTypeSensor.SelectedValue);
                objEn.OperSysID = Convert.ToInt32(ddlTypeConnection.SelectedValue);
                objEn.usuario = txtUsuario.Text.Trim();
                objEn.clave = Seguridad.Encriptar(txtclave.Text);
                objEn.Dip = txtIp.Text;

                msg = objLo.Devices_Insertar(objEn);
                if (msg.ToUpper() == "EXITO")
                {
                    Response.Redirect("/Device/MyDevice.aspx");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


    }
}