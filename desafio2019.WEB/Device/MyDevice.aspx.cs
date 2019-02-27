using desafio2019.Entity.MySql;
using desafio2019.Logic.MySql;
using desafio2019.WEB.Enumerador;
using Renci.SshNet;
using System;
using System.Data;
using System.IO;
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
                CargaConnection();
                CargaDevice();
                CargaSensor();
                CargaOperativeSystem();
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


        protected void btnEditar_Command(object sender, CommandEventArgs e)
        {
            try
            {

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
                txtUsuario.Text = dt.Rows[0]["usuario"].ToString();
                txtclave.Text = dt.Rows[0]["clave"].ToString();
                txtNameDevice.Text = dt.Rows[0]["NameDevice"].ToString();

                ScriptManager.RegisterStartupScript(this, typeof(Page), "jsKeys", "javascript:BuscarItem();", true);

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
                Label lblDip = (Label)grvListado.Rows[index].FindControl("lblDip");



                dt = objLo.DevicesJson_Selecionar(Convert.ToInt32(rowid.Text));


                string ruta = "/files/config.json";



                // Setup Credentials and Server Information
                ConnectionInfo ConnNfo = new ConnectionInfo("104.248.211.185", 22, "root", new AuthenticationMethod[]{

                // Pasword based Authentication
                new PasswordAuthenticationMethod("root","iota2019123"),

                // Key Based Authentication (using keys in OpenSSH Format)
                new PrivateKeyAuthenticationMethod("root",new PrivateKeyFile[]{
                    new PrivateKeyFile(@"..\openssh.key","passphrase")
                }),
                    }
                );

                // Execute a (SHELL) Command - prepare upload directory
                using (var sshclient = new SshClient(ConnNfo))
                {
                    sshclient.Connect();
                    using (var cmd = sshclient.CreateCommand("mkdir -p /tmp/uploadtest && chmod +rw /tmp/uploadtest"))
                    {
                        cmd.Execute();
                        Console.WriteLine("Command>" + cmd.CommandText);
                        Console.WriteLine("Return Value = {0}", cmd.ExitStatus);
                    }
                    sshclient.Disconnect();
                }

                // Upload A File
                using (var sftp1 = new SftpClient(ConnNfo))
                {
                    string uploadfn = "Renci.SshNet.dll";

                    sftp1.Connect();
                    sftp1.ChangeDirectory("/opt/prueba/");
                    using (var uplfileStream = System.IO.File.OpenRead(uploadfn))
                    {
                        sftp1.UploadFile(uplfileStream, uploadfn, true);
                    }
                    sftp1.Disconnect();
                }

                // Execute (SHELL) Commands
                using (var sshclient = new SshClient(ConnNfo))
                {
                    sshclient.Connect();

                    // quick way to use ist, but not best practice - SshCommand is not Disposed, ExitStatus not checked...
                    Console.WriteLine(sshclient.CreateCommand("cd /tmp && ls -lah").Execute());
                    Console.WriteLine(sshclient.CreateCommand("pwd").Execute());
                    Console.WriteLine(sshclient.CreateCommand("cd /tmp/uploadtest && ls -lah").Execute());
                    sshclient.Disconnect();
                }
                Console.ReadKey();






                //using (var client = new SshClient("104.248.211.185", "root", "iota2019123"))
                //{
                //    client.Connect();
                //    //client.RunCommand("etc/init.d/networking restart");

                //   client.RunCommand ChangeDirectory("/opt/prueba/");
                //    using (var uplfileStream = System.IO.File.OpenRead(ruta))
                //    {
                //        client.UploadFile(uplfileStream, ruta, true);
                //    }
                //    client.Disconnect();

                //    client.Disconnect();
                //}



                //  SendFileToServer.Send(ruta);

                return;


                /*

                FileInfo Archivo = new FileInfo(HttpContext.Current.Server.MapPath(ruta));
                File.WriteAllText(HttpContext.Current.Server.MapPath(ruta), dt.Rows[0]["DJson"].ToString());

                string destino = "/opt/prueba/";
                string host = lblDip.Text.Trim();
                string username = grvListado.DataKeys[index].Values["usuario"].ToString();
                string password = Seguridad.DesEncriptar(grvListado.DataKeys[index].Values["clave"].ToString());





                SFTPHelper sftp = new SFTPHelper(host, username, password);
                sftp.Connect();
                sftp.Get(ruta, destino);
                sftp.Disconnect();

    */


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
                objEn.Dip = txtIp2.Text.Trim();
                objEn.DeviceID = Convert.ToInt32(ddlTypeDevice.SelectedValue);
                objEn.SensorID = Convert.ToInt32(ddlTypeSensor.SelectedValue);
                objEn.OperSysID = Convert.ToInt32(ddlOperativeSystem.SelectedValue);
                objEn.usuario = txtUsuario.Text.Trim();
                objEn.clave = Seguridad.Encriptar(txtclave.Text);



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

                int temp = 0;
                int hum = 0;
                if (!string.IsNullOrEmpty(txtTempMaxima.Text))
                {
                    temp = 1;
                }
                if (!string.IsNullOrEmpty(txtTempMin.Text))
                {
                    temp = 1;
                }
                if (!string.IsNullOrEmpty(txtHumMax.Text))
                {
                    hum = 1;
                }
                if (!string.IsNullOrEmpty(txtHumMin.Text))
                {
                    hum = 1;
                }

                if (temp == 0 && hum == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerta", "alert('alerta : debe ingresar una temperatura y humedad.');", true);
                    return;
                }

                string cadena = string.Empty;
                cadena = "{  \"simulatedData\": false,  \"interval\": 2000,  \"deviceId\": \"" + hd_dispositivo.Value + "\",  \"LEDPin\": 5,  \"messageMax\": 256,  \"credentialPath\": \"~/.iot-hub\",  \"temperatureAlertMAX\": " + txtTempMaxima.Text + ", \"temperatureAlertMIN\": " + txtTempMin.Text + ", \"HumidityAlertMAX\": " + txtHumMax.Text + ", \"HumidityAlertMin\": " + txtHumMin.Text + ",  \"i2cOption\": { \"pin\": 9,    \"i2cBusNo\": 1,    \"i2cAddress\": 119  } }";

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