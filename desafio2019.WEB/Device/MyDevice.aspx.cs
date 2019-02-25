using desafio2019.Entity.MySql;
using desafio2019.Logic.MySql;
using desafio2019.WEB.Enumerador;
using OfficeOpenXml;
using Renci.SshNet;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
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



        //protected void btnEditar_Click(object sender, EventArgs e)
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
                //txtclave.Text = Seguridad.DesEncriptar(dt.Rows[0]["clave"].ToString());
                txtclave.Text = dt.Rows[0]["clave"].ToString();
                //txtIp.Text = dt.Rows[0]["NameDevice"].ToString();
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

                dt = objLo.DevicesJson_Selecionar(Convert.ToInt32(rowid.Text));

                string ruta = "/files/config.json";

                FileInfo Archivo = new FileInfo(HttpContext.Current.Server.MapPath(ruta));
                File.WriteAllText(HttpContext.Current.Server.MapPath(ruta), dt.Rows[0]["DJson"].ToString());

                string username = grvListado.DataKeys[index].Values["usuario"].ToString();
                string password = Seguridad.DesEncriptar(grvListado.DataKeys[index].Values["clave"].ToString());


                //const string host = "sftp://104.248.211.185:22/";
                //const string username = "root";
                //const string password = "iota2019123";
                //const string workingdirectory = "/opt/prueba/";
                //const string uploadfile = "/files/config.json";

                string source = @"/files/config.json";
                string destination = @"/opt/prueba/";
                string host = "sftp://104.248.211.185:22";
                int port = 22;  //Port 22 is defaulted for SFTP upload

                sftp.UploadSFTPFile(host, username, password, source, destination, port);



                //string RutaClavePrivada = "C:Rutaid_rsa_nombre";
                //string FrasePaso = "xxxxxxxxxxxxxxxx";
                //Renci.SshNet.PrivateKeyFile ClavePrivada = new Renci.SshNet.PrivateKeyFile(RutaClavePrivada, FrasePaso);
                //object conexion = new PrivateKeyConnectionInfo("xxx.xxx.xxx.xxx", "xxxxxxxxx", ProxyTypes.Socks5, "socks.xxxx.es", 1080, "", "", ClavePrivada);
                //Renci.SshNet.SftpClient Ftp = new Renci.SshNet.SftpClient(conexion);
                //Ftp.Connect();
                //System.IO.Stream fsd = new System.IO.FileStream("c:archivo.txt", System.IO.FileMode.Create);
                //Ftp.DownloadFile("/.ssh/authorized_keys2", fsd);
                //fsd.Close();
                //System.IO.Stream fs = System.IO.File.OpenRead("c:archivo.txt");
                //Ftp.UploadFile(fs, "/files/config.json", true);
                //fs.Close();
                ////  Renombrar un fichero.
                //Ftp.RenameFile("/files/config.json", " / path/archivo_renombrado.txt");
                ////  Eliminar un fichero.
                //Ftp.DeleteFile("/path/archivo_renombrado.txt");
                //Ftp.Disconnect();
                //Ftp.Dispose();







                //const string host = "sftp://104.248.211.185:22/";
                //const string username = "root";
                //const string password = "iota2019123";
                //const string workingdirectory = "/opt/prueba/";
                //const string uploadfile = "/files/config.json";

                //Console.WriteLine("Creating client and connecting");
                //using (var client = new SftpClient(host, 22, username, password))
                //{
                //    client.Connect();
                //   // Console.WriteLine("Connected to {0}", host);

                //    client.ChangeDirectory(workingdirectory);
                //   // Console.WriteLine("Changed directory to {0}", workingdirectory);

                //    var listDirectory = client.ListDirectory(workingdirectory);
                ////    Console.WriteLine("Listing directory:");
                //    //foreach (var fi in listDirectory)
                //    //{
                //    //    Console.WriteLine(" - " + fi.Name);
                //    //}

                //    using (var fileStream = new FileStream(uploadfile, FileMode.Open))
                //    {
                //       // Console.WriteLine("Uploading {0} ({1:N0} bytes)", uploadfile, fileStream.Length);
                //        client.BufferSize = 4 * 1024; // bypass Payload error large files
                //        client.UploadFile(fileStream, Path.GetFileName(uploadfile));
                //    }
                //}



                //var host = "sftp://104.248.211.185:22/opt/prueba/";
                //var port = 22;
                //var username = "root";
                //var password = "iota2019123";

                //// path for file you want to upload
                //var uploadFile = @"c:yourfilegoeshere.txt";

                //using (var client = new SftpClient(host, port, username, password))
                //{
                //    client.Connect();
                //    if (client.IsConnected)
                //    {
                //        //Debug.WriteLine("I'm connected to the client");

                //        using (var fileStream = new FileStream(uploadFile, FileMode.Open))
                //        {

                //            client.BufferSize = 4 * 1024; // bypass Payload error large files
                //            client.UploadFile(fileStream, Path.GetFileName(uploadFile));
                //        }
                //    }
                //    else
                //    {
                //        Debug.WriteLine("I couldn't connect");
                //    }
                //}





                //string host = "sftp://104.248.211.185:22/opt/prueba/config.json";
                //string user = "root";
                //string pass = "iota2019123";
                //string cadenaJson = dt.Rows[0]["DJson"].ToString();
                //string resultado = string.Empty;

                //using (SshClient ssh = new SshClient(host, user, pass))
                //{
                //    ssh.Connect();
                //    var result = ssh.RunCommand("df -h");
                //    ssh.Disconnect();
                //}

                // sftp://104.248.211.185

                //using (WebClient client = new WebClient())
                //{
                //    client.Credentials = new NetworkCredential(user, pass);
                //    client.UploadFile("sftp://104.248.211.185:22/opt/prueba/config.json", WebRequestMethods.Ftp.UploadFile, localFilePath);
                //}

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private class sftp
        {
            public static void UploadSFTPFile(string host, string username,
            string password, string sourcefile, string destinationpath, int port)
            {
                using (SftpClient client = new SftpClient(host, port, username, password))
                {
                    client.Connect();
                    client.ChangeDirectory(destinationpath);
                    using (FileStream fs = new FileStream(sourcefile, FileMode.Open))
                    {
                        client.BufferSize = 4 * 1024;
                        client.UploadFile(fs, Path.GetFileName(sourcefile));
                    }
                }
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