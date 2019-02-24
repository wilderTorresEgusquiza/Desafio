using desafio2019.Entity.MySql;
using desafio2019.Logic.MySql;
using OfficeOpenXml;
using Renci.SshNet;
using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace desafio2019.WEB.Device
{
    public partial class MyDevice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Devices_Lista();
            }
        }

        public void Devices_Lista()
        {
            try
            {
                LoDevices objLo = new LoDevices();
                object objDevices = new object();

                objDevices = objLo.Devices_Lista();
                grvListado.DataSource = objDevices;
                grvListado.DataBind();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        //protected void btnEditar_Click(object sender, EventArgs e)
        protected void btnEditar_Command(object sender, CommandEventArgs e)
        {
            try
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "jsKeys", "javascript:BuscarItem();", true);


                CargaConnection();
                CargaDevice();
                CargaSensor();
                CargaOperativeSystem();

                LoDevices objLo = new LoDevices();
                EnDevices objEn = new EnDevices();

                DataTable dt = new DataTable();

                int index = Convert.ToInt32(e.CommandArgument);
                Label rowid = (Label)grvListado.Rows[index].FindControl("lblrowid");

                dt = objLo.Devices_Selecionar(Convert.ToInt32(rowid.Text));

                hd_ID.Value = rowid.Text;
                ddlTypeConnection.SelectedValue = dt.Rows[0]["ConnectionID"].ToString();
                ddlTypeDevice.SelectedValue = dt.Rows[0]["DeviceID"].ToString();
                ddlTypeSensor.SelectedValue = dt.Rows[0]["SensorID"].ToString();
                ddlOperativeSystem.SelectedValue = dt.Rows[0]["OperSysID"].ToString();
                //txtIp.Text = dt.Rows[0]["NameDevice"].ToString();
                txtNameDevice.Text = dt.Rows[0]["NameDevice"].ToString();


            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        protected void btntxt_Command(object sender, CommandEventArgs e)
        {

            try
            {

                LoDevices objLo = new LoDevices();
                EnDevices objEn = new EnDevices();

                DataTable dt = new DataTable();


                int index = Convert.ToInt32(e.CommandArgument);
                Label OperSystem = (Label)grvListado.Rows[index].FindControl("lblOperSystem");


                string ruta = "/files/" + OperSystem.Text + ".txt";

                FileInfo Archivo = new FileInfo(HttpContext.Current.Server.MapPath(ruta));
                File.WriteAllText(HttpContext.Current.Server.MapPath(ruta), OperSystem.Text);
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + Archivo.Name);
                HttpContext.Current.Response.AddHeader("Content-Length", Archivo.Length.ToString());
                HttpContext.Current.Response.ContentType = "application/octet-stream";
                HttpContext.Current.Response.WriteFile(ruta);

                HttpContext.Current.Response.End();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnEnviar_Command(object sender, CommandEventArgs e)
        {

            try
            {

                LoDevices objLo = new LoDevices();
                EnDevices objEn = new EnDevices();

                DataTable dt = new DataTable();

                int index = Convert.ToInt32(e.CommandArgument);
                Label rowid = (Label)grvListado.Rows[index].FindControl("lblrowid");

                dt = objLo.DevicesJson_Selecionar(Convert.ToInt32(rowid.Text));




                string ruta = "/files/configuracion.json";

              

                FileInfo Archivo = new FileInfo(HttpContext.Current.Server.MapPath(ruta));
                File.WriteAllText(HttpContext.Current.Server.MapPath(ruta), dt.Rows[0]["DJson"].ToString());




                string host = "";
                string user = "";
                string pass = "";
                string cadenaJson = dt.Rows[0]["DJson"].ToString();
                string resultado = string.Empty;

                //using (SshClient ssh = new SshClient(host, user, pass))
                //{
                //    ssh.Connect();
                //    var result = ssh.RunCommand("df -h");
                //    ssh.Disconnect();
                //}

                // sftp://104.248.211.185

                using (WebClient client = new WebClient())
                {
                    client.Credentials = new NetworkCredential(user, pass);
                    client.UploadFile("sftp://104.248.211.185:22/opt/prueba/config.json", WebRequestMethods.Ftp.UploadFile, localFilePath);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void chkValidarIp_CheckedChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "jsKeys", "javascript:BuscarItem();", true);

            if (!chkValidarIp.Checked)
            {
                lblMensaje.Text = string.Empty;
                return;
            }

            if (IsValidIp(txtIp2.Text.Trim()))
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

        protected void btnSalvar2_Click(object sender, EventArgs e)
        {
            string msg = string.Empty;
            lblMensaje.Text = string.Empty;

            try
            {

                if (!IsValidIp(txtIp2.Text))
                {
                    lblMensaje.Text = "Ip Incorrecta";
                    return;
                }

                LoDevices objLo = new LoDevices();
                EnDevices objEn = new EnDevices();

                objEn.rowid = Convert.ToInt32(hd_ID.Value);
                objEn.ConnectionID = Convert.ToInt32(ddlTypeConnection.SelectedValue);
                objEn.NameDevice = txtNameDevice.Text.Trim();
                objEn.DeviceID = Convert.ToInt32(ddlTypeDevice.SelectedValue);
                objEn.SensorID = Convert.ToInt32(ddlTypeSensor.SelectedValue);
                objEn.OperSysID = Convert.ToInt32(ddlOperativeSystem.SelectedValue);

                msg = objLo.Devices_Editar(objEn);
                if (msg.ToUpper() == "EXITO")
                {
                    Devices_Lista();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }




        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static object Configuracion_Insertar(string temperatura)
        {
            DataTable dt = new DataTable();

            #region INGRESO_DE_DATOS

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var objJson = serializer.Deserialize<dynamic>(temperatura);

            string msg = string.Empty;
            LoDevices objLo = new LoDevices();
            EnDevices objEn = new EnDevices();

            objEn.rowid = Convert.ToInt32(objJson["Id"]);
            objEn.temmax = objJson["temperatureAlertMAX"];
            objEn.temmin = objJson["temperatureAlertMIN"];
            objEn.hummax = objJson["HumidityAlertMAX"];
            objEn.hummin = objJson["HumidityAlertMin"];

            // msg = objLo.Devices_configuracion(objEn);
            if (msg.ToUpper() == "EXITO")
            {
                //Devices_Lista();
            }


            #endregion INGRESO_DE_DATOS
            object objProducto = new object();
            return objProducto;
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static object temperatura(string configuracion)
        {
            DataTable dt = new DataTable();

            #region INGRESO_DE_DATOS

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var objJson = serializer.Deserialize<dynamic>(configuracion);

            string msg = string.Empty;
            LoDevices objLo = new LoDevices();
            EnDevices objEn = new EnDevices();

            objEn.rowid = Convert.ToInt32(objJson["Id"]);
            objEn.temmax = objJson["temperatureAlertMAX"];
            objEn.temmin = objJson["temperatureAlertMIN"];
            objEn.hummax = objJson["HumidityAlertMAX"];
            objEn.hummin = objJson["HumidityAlertMin"];

            //msg = objLo.Devices_configuracion(objEn);
            if (msg.ToUpper() == "EXITO")
            {
                //Devices_Lista();
            }


            #endregion INGRESO_DE_DATOS
            object objProducto = new object();
            return objProducto;
        }



        protected void btnTemperatura_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = string.Empty;
                LoDevices objLo = new LoDevices();
                EnDevices objEn = new EnDevices();

                int temp = 1;
                int hum = 1;
                if (string.IsNullOrEmpty(txtTempMaxima.Text))
                {
                    temp = 0;
                }
                if (string.IsNullOrEmpty(txtTempMin.Text))
                {
                    temp = 0;
                }
                if (string.IsNullOrEmpty(txtTempMaxima.Text))
                {
                    hum = 0;
                }
                if (string.IsNullOrEmpty(txtTempMin.Text))
                {
                    hum = 0;
                }

                if (temp == 0 && hum == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerta", "alert('alerta : debe ingresar una temperatura y humedad.');", true);
                    return;
                }

                string cadena = string.Empty;
                cadena = "{  \"simulatedData\": false,  \"interval\": 2000,  \"deviceId\": \"Raspberry Pi Node\",  \"LEDPin\": 5,  \"messageMax\": 256,  \"credentialPath\": \"~/.iot-hub\",  \"temperatureAlertMAX\": " + txtTempMaxima.Text + ", \"temperatureAlertMIN\": " + txtTempMin.Text + ", \"HumidityAlertMAX\": " + txtHumMax.Text + ", \"HumidityAlertMin\": " + txtHumMin.Text + ",  \"i2cOption\": { \"pin\": 9,    \"i2cBusNo\": 1,    \"i2cAddress\": 119  } }";

                msg = objLo.Devices_configuracion(Convert.ToInt32(hd_ID.Value), cadena);
                if (msg.ToUpper() == "EXITO")
                {
                    Devices_Lista();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}