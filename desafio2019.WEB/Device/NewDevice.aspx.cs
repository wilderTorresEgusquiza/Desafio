using desafio2019.Logic.MySql;
using System;
using System.Collections.Generic;
using System.Linq;
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
                LoDevice objLo = new LoDevice();
                object objDevice = new object();

                objDevice = objLo.CargaDevice();

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


    }
}